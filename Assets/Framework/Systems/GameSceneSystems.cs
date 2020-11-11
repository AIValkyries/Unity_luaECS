///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/5 9:44:52
/// 描 述：TODO
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameSceneSystems : Feature
{
    FSMStateManager<GameSceneSystems> _fsm;

    public GameSceneSystems() : base("Game Scene Systems")
    {
        
    }

}
