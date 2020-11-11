///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/6 17:01:14
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas.CodeGenerator.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[ModuleManager,Unique]
public class ModuleManagerCompoent : IComponent
{
    public int PreModuleID = -1;

    /// <summary>
    /// 这是个常量，要在程序运行前注册
    /// Key:模块ID
    /// Value:模块类型
    /// </summary>
    public Dictionary<int, Type> ModuleMap;

    /// <summary>
    /// 临时存储，方便卸载模块
    /// Key:模块ID
    /// Value:具体模块
    /// </summary>
    public Dictionary<int, ModuleBaseSystems> MountedModules;

}
