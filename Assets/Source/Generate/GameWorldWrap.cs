﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GameWorldWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameWorld), typeof(Entitas.Feature));
		L.RegFunction("GetInstance", GetInstance);
		L.RegFunction("Add", Add);
		L.RegFunction("Initialize", Initialize);
		L.RegFunction("TearDown", TearDown);
		L.RegFunction("New", _CreateGameWorld);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("SceneManager", get_SceneManager, null);
		L.RegVar("Resources", get_Resources, null);
		L.RegVar("TcpNetwork", get_TcpNetwork, null);
		L.RegVar("Config", get_Config, null);
		L.RegVar("Dispatch", get_Dispatch, null);
		L.RegVar("Scene", get_Scene, null);
		L.RegVar("Modules", get_Modules, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGameWorld(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				GameWorld obj = new GameWorld();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: GameWorld.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			GameWorld o = GameWorld.GetInstance();
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameWorld obj = (GameWorld)ToLua.CheckObject(L, 1, typeof(GameWorld));
			Entitas.ISystem arg0 = (Entitas.ISystem)ToLua.CheckObject<Entitas.ISystem>(L, 2);
			Entitas.Systems o = obj.Add(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				GameWorld obj = (GameWorld)ToLua.CheckObject(L, 1, typeof(GameWorld));
				obj.Initialize();
				return 0;
			}
			else if (count == 2)
			{
				GameWorld obj = (GameWorld)ToLua.CheckObject(L, 1, typeof(GameWorld));
				object arg0 = ToLua.ToVarObject(L, 2);
				obj.Initialize(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameWorld.Initialize");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TearDown(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameWorld obj = (GameWorld)ToLua.CheckObject(L, 1, typeof(GameWorld));
			obj.TearDown();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SceneManager(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, GameWorld.SceneManager);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Resources(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, GameWorld.Resources);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TcpNetwork(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, GameWorld.TcpNetwork);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Config(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, GameWorld.Config);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Dispatch(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, GameWorld.Dispatch);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Scene(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, GameWorld.Scene);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Modules(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, GameWorld.Modules);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

