///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/6 15:49:10
/// 描 述：
///</summary>
///----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Timeline;

public class DispatchSystems : EventSystems
{
    public DispatchSystems()
    {
        // 注册常驻事件

    }

    public static void Registered(IEventSystem eventSystem)
    {
        GameWorld.Dispatch._registered(eventSystem);
    }

    public static void Uninstall(IEventSystem eventSystem)
    {
        GameWorld.Dispatch._uninstall(eventSystem);
    }

    public static void Notify(int moduleID, int op, System.Object param = null)
    {
        GameWorld.Dispatch._notify(moduleID, op, param);
    }
}
