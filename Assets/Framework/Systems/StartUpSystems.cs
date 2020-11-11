///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/5 9:25:07
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class StartUpSystems : Feature
{
    public StartUpSystems() : base("StartUp Systems")
    {
        Add(new ResourcesUpdateSystem());

    }

    public override void Initialize(System.Object param = null)
    {
        base.Initialize(param);

        ModuleParam module = new ModuleParam();
        module.InstantiationType = typeof(TestViewSystem);
        module.ViewPath = "L_Resources/ViewPrefabs/TestView.prefab";
        module.Param = null;

        ModuleManagerSystems.CallModule(
            (int)ModuleID.TestModule,
            (int)MODULE_EVENT.OpenView, 
            module);
    }

}
