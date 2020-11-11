///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/5 9:30:52
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModuleManagerSystems : Feature
{
    public ModuleManagerSystems():
        base("Module Manager Systems")
    {

    }

    public override void Initialize(System.Object param = null)
    {
        ModuleManagerEntity entity = Contexts.moduleManager.CreateEntity();
        ModuleManagerCompoent compoent = entity.AddModuleManagerCompoent();
        compoent.ModuleMap = new Dictionary<int, Type>();
        compoent.MountedModules = new Dictionary<int, ModuleBaseSystems>();

        // 加载 UIRoot 放在这里很别扭啊....
        ModuleBaseEntity moduleBaseEntity = Contexts.moduleBase.CreateEntity();
        UIManagerCompoent viewDisplay = moduleBaseEntity.AddUIManagerCompoent();

        GameObject prefab = 
            GameWorld.Resources.LoadAsset<GameObject>
            (ModuleBaseSystems.UICommon.RootPath);

        if (prefab == null)
        {
            Debug.LogError("没有找到UIRoot");
            return;
        }

        viewDisplay.Root = GameObject.Instantiate(prefab);
        viewDisplay.Layers = new GameObject[(int)ViewLayer.MAX];
        viewDisplay.UIPrefabs = new Dictionary<string, GameObject>();
        viewDisplay.UIViews = new Dictionary<GameObject, GameObject>();

        for (int i = 0; i < viewDisplay.Root.transform.childCount; i++)
        {
            viewDisplay.Layers[i] = viewDisplay.Root.transform.GetChild(i).gameObject;
        }

        GameObject @object = new GameObject("EventSystem");
        @object.AddComponent<EventSystem>();
        @object.AddComponent<StandaloneInputModule>();

        UnityEngine.Object.DontDestroyOnLoad(viewDisplay.Root);
        UnityEngine.Object.DontDestroyOnLoad(@object);

        base.Initialize(param);

        RegisterModuleType(compoent.ModuleMap);
    }

    void RegisterModuleType(Dictionary<int, Type> ModuleMap)
    {
        ModuleMap.Add((int)ModuleID.TestModule, typeof(TestModuleBase));

    }

    void _callModule(int moduleId, int op, ModuleParam param)
    {
        ModuleManagerCompoent compoent = Contexts.moduleManager.moduleManagerCompoent;
        compoent.PreModuleID = moduleId;

        Type type = null;

        if (!compoent.ModuleMap.TryGetValue(moduleId, out type))
        {
            Debug.LogError(string.Format("模块=[{0}]没有注册!", moduleId));
            return;
        }

        ModuleBaseSystems moduleBase = null;

        if (!compoent.MountedModules.TryGetValue(moduleId, out moduleBase)) 
        {
            moduleBase = (ModuleBaseSystems)Activator.CreateInstance(type);
            moduleBase.Initialize();
            Add(moduleBase);
        }

        moduleBase.Call(op, param);

        if (!compoent.MountedModules.ContainsKey(moduleId))
            compoent.MountedModules.Add(moduleId, null);

        compoent.MountedModules[moduleId] = moduleBase;
    }

    void _closeModule(int moduleId, int op, ModuleParam param)
    {
        ModuleManagerCompoent compoent = Contexts.moduleManager.moduleManagerCompoent;

        ModuleBaseSystems moduleBase;

        if (compoent.MountedModules.TryGetValue(moduleId, out moduleBase)) 
        {
            Remove(moduleBase);
            moduleBase.Call(op, param);
            moduleBase.TearDown();

            compoent.MountedModules.Remove(moduleId);
        }
    }


    public static void CallModule(int moduleId, int op, ModuleParam param)
    {
        GameWorld.Modules._callModule(moduleId, op, param);
    }

    public static void CloseModule(int moduleId, int op, ModuleParam param)
    {
        GameWorld.Modules._closeModule(moduleId, op, param);
    }


}
