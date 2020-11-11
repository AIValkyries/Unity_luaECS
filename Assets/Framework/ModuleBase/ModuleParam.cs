///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/6 16:33:46
/// 描 述：
///</summary>
///----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ModuleParam
{
    public string ViewPath;
    public Type InstantiationType;
    public object Param;
}

/// <summary>
/// 模块事件
/// </summary>
public enum MODULE_EVENT
{
    OpenView = 1000000,
    CloseView = 1000001,
}
