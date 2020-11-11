///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/3 17:20:57
/// 描 述：
///</summary>
///----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;


public class FSMState<T>
{
    int _state;

    public FSMState(int state)
    {
        _state = state;
    }


    public virtual void OnEnter(T owner)
    {
        
    }

    public virtual void OnExit(T owner)
    {
        
    }


}
