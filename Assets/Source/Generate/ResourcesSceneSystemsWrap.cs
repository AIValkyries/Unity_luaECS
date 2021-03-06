﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ResourcesSceneSystemsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ResourcesSceneSystems), typeof(Entitas.Feature));
		L.RegFunction("SetupAssetBundle", SetupAssetBundle);
		L.RegFunction("LoadSceneAsync", LoadSceneAsync);
		L.RegFunction("UnloadScene", UnloadScene);
		L.RegFunction("New", _CreateResourcesSceneSystems);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateResourcesSceneSystems(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				ResourcesSceneSystems obj = new ResourcesSceneSystems();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: ResourcesSceneSystems.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupAssetBundle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			ResourcesSceneSystems.SetupAssetBundle();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadSceneAsync(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			SceneAsyncLoader o = ResourcesSceneSystems.LoadSceneAsync(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadScene(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			SceneAsyncLoader o = ResourcesSceneSystems.UnloadScene(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

