///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/6 15:38:50
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum ViewLayer
{
    TIP = 0,                    //提示弹窗
    TOP = 1,                    // 上
    MIDDLE = 2,                 // 中
    BOTTOM = 3,                 // 下

    MAX = 4
}

public abstract class ModuleBaseSystems : Feature
{
    public static class UICommon
    {
        public static string RootPath = "L_Resources/UIRoot.prefab";
        public static Vector3 OffsetPos = new Vector3(99999, 99999, 99999);
    }

    /// <summary>
    /// Key:viewSystem
    /// Value:
    /// </summary>
    Dictionary<Type, ModuleBaseEntity> _view_system_bind_entity;

    /// <summary>
    /// 视图绑定 Controller
    /// Key:viewSystem
    /// Value:controller
    /// </summary>
    protected Dictionary<Type, Type> _view_bind_controller;

    public ModuleBaseSystems()
        :base("Module Base Systems")
    {
        _view_bind_controller = new Dictionary<Type, Type>();
        _view_system_bind_entity = new Dictionary<Type, ModuleBaseEntity>();

        ViewBindContoller();
    }
    protected virtual void ViewBindContoller() { }


    public void Call(int op, ModuleParam param)
    {
        switch (op)
        {
            case (int)MODULE_EVENT.OpenView:
                _openView(param.InstantiationType, param.ViewPath);
                break;
            case (int)MODULE_EVENT.CloseView:
                _closeView(param.InstantiationType);
                break;
        }

        OnCall(op, param);
    }

    protected virtual void OnCall(int op, ModuleParam param)
    {
        
    }

    void _openView(Type type, string viewPath)
    {
        GameObject prefab = null;

        UIManagerCompoent viewDisplay = Contexts.moduleBase.uIManagerCompoent;

        if (!viewDisplay.UIPrefabs.TryGetValue(viewPath, out prefab))
        {
            prefab = GameWorld.Resources.LoadAsset<GameObject>(viewPath);
            viewDisplay.UIPrefabs.Add(viewPath, prefab);
        }

        GameObject viewObject;

        if (!viewDisplay.UIViews.TryGetValue(prefab, out viewObject))
        {
            viewObject = GameObject.Instantiate(prefab);
            viewDisplay.UIViews.Add(prefab, viewObject);
        }

        ModuleBaseEntity entity = Contexts.moduleBase.CreateEntity();
        ViewSystemCompoent compoent = entity.AddViewSystemCompoent();
        compoent.gameObject = viewObject;
        compoent.ViewPath = viewPath;

        ViewSystem viewSystem = (ViewSystem)Activator.CreateInstance(type);
        viewSystem.RegistViewCompoent(compoent);
        viewSystem.Initialize();

        if (_view_bind_controller.ContainsKey(viewSystem.GetType()))
        {
            Type cType = _view_bind_controller[viewSystem.GetType()];
            ViewControllerSystem viewController = (ViewControllerSystem)Activator.CreateInstance(cType);
            viewController.Initialize(compoent.gameObject);
        }

        compoent.gameObject.transform.SetParent(GetParent(compoent));

        RectTransform rectTransform = viewObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition3D = Vector3.zero;
        viewObject.transform.localRotation = Quaternion.identity;
        viewObject.SetActive(true);

        if (!_view_system_bind_entity.ContainsKey(type))
            _view_system_bind_entity.Add(type, entity);
    }

    /// <summary>
    /// 路径相对路径
    /// L_Resources/ViewPrefabs/...
    /// </summary>
    /// <param name="viewPath"></param>
    void _openView<T>(string viewPath) where T : ViewSystem, new()
    {
        Type type = typeof(T);
        _openView(type, viewPath);
    }

    void _closeView<T>() where T : ViewSystem, new()
    {
        Type type = typeof(T);
        _closeView(type);
    }

    void _closeView(Type type)
    {
        // 移除entity?
        // 移除prefab？
        // 移除Gameobject?
        ModuleBaseEntity entity = null;

        if (!_view_system_bind_entity.TryGetValue(type, out entity))
        {
            Debug.LogError(string.Format("视图=[{0}],没有存储Entity??", type.Name));
            return;
        }

        ViewSystemCompoent viewCompoent = entity.viewSystemCompoent;
        UIManagerCompoent managerCompoent = Contexts.moduleBase.uIManagerCompoent;

        GameObject prefab = null;

        if (managerCompoent.UIPrefabs.TryGetValue(viewCompoent.ViewPath, out prefab))
        {
            bool allowDestroyingAssets = false;
            if (!viewCompoent.CachePrefab)
            {
                managerCompoent.UIPrefabs.Remove(viewCompoent.ViewPath);
                allowDestroyingAssets = true;
            }
            GameObject @object = managerCompoent.UIViews[prefab];

            if (!viewCompoent.CacheGameObjet)
            {
                GameObject.DestroyImmediate(@object, allowDestroyingAssets);

                managerCompoent.UIViews.Remove(prefab);
            }
            else
            {
                @object.SetActive(false);
                @object.transform.position = UICommon.OffsetPos;
            }
        }

        Contexts.moduleBase.DestroyEntity(entity);
        _view_system_bind_entity.Remove(type);
    }

    Transform GetParent(ViewSystemCompoent compoent)
    {
        return Contexts.moduleBase.uIManagerCompoent.Layers[(int)compoent.layer].transform;
    }

}
