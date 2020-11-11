///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/3 17:35:54
/// 描 述：
///</summary>
///----------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Collections;
using Entitas;

/// <summary>
///  
/// </summary>
public sealed class GameWorld : Feature
{
    private static GameWorld _instance;
    private static readonly System.Object _lockHelper = new System.Object();

    public static GameWorld GetInstance()
    {
        if (_instance == null)
        {
            lock (_lockHelper)
            {
                if (_instance == null)
                    _instance = new GameWorld();
            }
        }
        return _instance;
    }

    static Dictionary<Type, ISystem> _systems = new Dictionary<Type, ISystem>();

    public GameWorld() : base("Game World Systems")
    {
        Add(new DispatchSystems());
        Add(new GameSceneSystems());

        Add(new ProtobufDataConfigSystems());
        Add(new ResourcesSystems());
        Add(new ResourcesSceneSystems());
        Add(new TcpNetworkSystems());

  
    }

    public override Systems Add(ISystem system)
    {
        base.Add(system);

        if (!_systems.ContainsKey(system.GetType()))
            _systems.Add(system.GetType(), system);
        return this;
    }


    public override void Initialize(System.Object param = null)
    {
        bool NotRunCs = (bool)param;
        if (!NotRunCs)
        {
            Add(new ModuleManagerSystems());
            Add(new StartUpSystems());
        }

        base.Initialize(param);
    }

    public override void TearDown()
    {
        base.TearDown();

    }



    public static ResourcesSceneSystems SceneManager
    {
        get
        {
            Type type = typeof(ResourcesSceneSystems);
            if (_systems.ContainsKey(type))
            {
                return _systems[type] as ResourcesSceneSystems;
            }
            return null;
        }
    }
    public static ResourcesSystems Resources
    {
        get
        {
            Type type = typeof(ResourcesSystems);
            if (_systems.ContainsKey(type))
            {
                return _systems[type] as ResourcesSystems;
            }
            return null;
        }
    }
    public static TcpNetworkSystems TcpNetwork
    {
        get
        {
            Type type = typeof(TcpNetworkSystems);
            if (_systems.ContainsKey(type))
            {
                return _systems[type] as TcpNetworkSystems;
            }
            return null;
        }
    }

    public static ProtobufDataConfigSystems Config
    {
        get
        {
            Type type = typeof(ProtobufDataConfigSystems);
            if (_systems.ContainsKey(type))
            {
                return _systems[type] as ProtobufDataConfigSystems;
            }
            return null;
        }
    }

    public static DispatchSystems Dispatch
    {
        get
        {
            Type type = typeof(DispatchSystems);
            if (_systems.ContainsKey(type))
            {
                return _systems[type] as DispatchSystems;
            }
            return null;
        }
    }
    public static GameSceneSystems Scene
    {
        get
        {
            Type type = typeof(GameSceneSystems);
            if (_systems.ContainsKey(type))
            {
                return _systems[type] as GameSceneSystems;
            }
            return null;
        }
    }

    public static ModuleManagerSystems Modules
    {
        get
        {
            Type type = typeof(ModuleManagerSystems);
            if (_systems.ContainsKey(type))
            {
                return _systems[type] as ModuleManagerSystems;
            }
            return null;
        }
    }

 

}
