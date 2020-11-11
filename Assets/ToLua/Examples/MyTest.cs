using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using System;

public class MyTest : MonoBehaviour
{
    public TextAsset asset;
    LuaState state = null;

    static LuaFunction mainFunction = null;

	void Start ()
    {
        new LuaResLoader();
        state = new LuaState();
        state.Start();
        LuaBinder.Bind(state);

        state.DoFile("Main.lua");
        mainFunction = state.GetFunction("Main");
        mainFunction.BeginPCall();
        mainFunction.PCall();
        mainFunction.EndPCall();
    }

    void Update ()
    {
        state.CheckTop();
    }
}
