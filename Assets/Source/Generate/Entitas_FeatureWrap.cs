﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Entitas_FeatureWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Entitas.Feature), typeof(Entitas.Unity.VisualDebugging.DebugSystems));
		L.RegFunction("New", _CreateEntitas_Feature);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateEntitas_Feature(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				Entitas.Feature obj = new Entitas.Feature(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Entitas.Feature.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

