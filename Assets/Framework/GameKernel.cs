///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/4 20:45:27
/// 描 述：
///</summary>
///----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Dataconfig;
using UnityEngine.EventSystems;

public class GameKernel : LuaClient
{
    public bool NotRunCs = true;

    protected override void InitPre()
    {
        DontDestroyOnLoad(gameObject);
        Contexts.sharedInstance.SetAllContexts();
        GameWorld.GetInstance().Initialize(NotRunCs);

        if (!NotRunCs)
        {
            LoadConfig();
        }
    }

    void LoadConfig()
    {
        LevelConfigArray levelConfigArray = 
            ProtobufDataConfigSystems.LoadConfig<LevelConfigArray>("dataconfig_levelconfig");

        for (int i = 0; i < levelConfigArray.Items.Count; i++) 
        {
            LevelConfig levelConfig = levelConfigArray.Items[i];
            Debug.Log(levelConfig.ToString());
        }
    }

    void Update()
    {
        if (!NotRunCs)
            GameWorld.GetInstance().Execute();
    }

   


}
