///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/3 17:22:21
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using System.Text;


public class FSMStateManager<T>
{
    public FSMStateManager(T owner)
    {
        _owner = owner;

        _currentState = null;
        _previousState = null;
        _globalState = null;
    }

    private FSMState<T> _currentState;
    private FSMState<T> _previousState;
    private FSMState<T> _globalState;

    private T _owner;

    public FSMState<T> CurrentState
    {
        get { return _currentState; }
    }

    public FSMState<T> PreviousState
    {
        get { return _previousState; }
    }

    public FSMState<T> GlobalState
    {
        get { return _globalState; }
    }


    public void SetFirstState(FSMState<T> state)
    {
        _currentState = state;
        if (_currentState != null)
        {
            _currentState.OnEnter(_owner);
        }
    }

    public void SetGlobalState(FSMState<T> state)
    {
        _globalState = state;
    }

    public void changeState(FSMState<T> state)
    {
        //状态没有变化就不要切换
        if (_currentState == state)
            return;

        _previousState = _currentState;
        _currentState = state;
        if (_previousState != null)
        {
            _previousState.OnExit(_owner);
        }
        if (_currentState != null)
        {
            _currentState.OnEnter(_owner);
        }
    }

    /// <summary>
    /// 重置状态机，当前状态为空
    /// </summary>
    public void ResetState()
    {
        _previousState = _currentState;
        _currentState = null;

        if (_previousState != null)
        {
            _previousState.OnExit(_owner);
        }
    }

}
