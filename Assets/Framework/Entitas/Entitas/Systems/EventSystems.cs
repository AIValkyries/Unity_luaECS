///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/4 15:56:27
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class EventSystems : Feature
{
    /// <summary>
    /// Key:模块ID
    /// Value:
    /// {
    ///     Key:事件ID
    ///     Value:事件监听系统
    /// }
    /// </summary>
    protected readonly Dictionary<int, Dictionary<int, IEventSystem>> _event_systems;

    public EventSystems():base("Event Systems")
    {
        _event_systems = new Dictionary<int, Dictionary<int, IEventSystem>>();
    }

    protected void _registered(IEventSystem eventSystem)
    {
        int moduleID = eventSystem.GetModuleID();
        if (!_event_systems.ContainsKey(moduleID))
            _event_systems.Add(moduleID, new Dictionary<int, IEventSystem>());

        int[] listeners = eventSystem.GetListener();
        Dictionary<int, IEventSystem> datas = _event_systems[moduleID];

        for (int i = 0; i < listeners.Length; i++)
        {
            if (!datas.ContainsKey(listeners[i]))
                datas.Add(listeners[i], eventSystem);
        }
    }

    protected void _uninstall(IEventSystem eventSystem)
    {
        int moduleID = eventSystem.GetModuleID();
        if (!_event_systems.ContainsKey(moduleID))
            return;

        int[] listeners = eventSystem.GetListener();
        Dictionary<int, IEventSystem> datas = _event_systems[moduleID];
        for (int i = 0; i < listeners.Length; i++)
        {
            if (datas.ContainsKey(listeners[i]))
                datas.Remove(listeners[i]);
        }
    }

    protected void _notify(int moduleID, int op, System.Object param = null)
    {
        if (!_event_systems.ContainsKey(moduleID))
        {
            Debug.LogError(string.Format("模块=[{0}]没有注册事件", moduleID));
            return;
        }

        Dictionary<int, IEventSystem> events = _event_systems[moduleID];

        if (!events.ContainsKey(op))
        {
            Debug.LogError(string.Format("模块=[{0}]没有注册事件=[{1}]", moduleID, op));
            return;
        }

        events[op].Notify(op, param);
    }


}
