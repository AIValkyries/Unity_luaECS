///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/5 15:30:13
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using System.Text;

public abstract class ViewSystem : 
    IInitializeSystem, 
    ITearDownSystem,
    IExecuteSystem,
    IEventSystem
{

    public void Initialize(System.Object param = null)
    {
        DispatchSystems.Registered(this);
        OnInitialize();
    }

    public void TearDown()
    {
        DispatchSystems.Uninstall(this);
        OnTearDown();
    }

    protected virtual void OnInitialize() { }
    protected virtual void OnTearDown() { }

    public virtual void RegistViewCompoent(ViewSystemCompoent viewCompoent)
    {
        
    }

    public virtual void Execute()
    {
         
    }

    public virtual int GetModuleID()
    {
        return 0;
    }

    public virtual int[] GetListener()
    {
        return null;
    }

    public virtual void Notify(int op, object param)
    {
         
    }


   
}
