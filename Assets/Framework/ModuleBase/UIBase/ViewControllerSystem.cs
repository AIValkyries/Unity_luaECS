///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/6 15:54:24
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ViewControllerSystem : 
    IEventSystem, 
    IInitializeSystem,
    ITearDownSystem
{

    public virtual void Notify(int op, object param)
    {
         
    }

    public virtual int[] GetListener()
    {
        return null;
    }

    public virtual int GetModuleID()
    {
        return 0;
    }

    public virtual void Initialize(System.Object param = null)
    {

    }

    public virtual void TearDown()
    {
       
    }


}
