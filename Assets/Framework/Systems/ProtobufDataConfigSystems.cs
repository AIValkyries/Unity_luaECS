///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/4 14:42:45
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using System;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf;
using Dataconfig;
using UnityEngine;
using LuaInterface;

public class ProtobufDataConfigSystems : Feature
{
    const string _path = "L_Resources/DataConfig/";
    Dictionary<string, IMessage> _configs = new Dictionary<string, IMessage>();
    Dictionary<string, byte[]> _luaConfigs = new Dictionary<string, byte[]>();

    public ProtobufDataConfigSystems() : base("DataConfig Systems")
    {
         
    }

    T _LoadConfig<T>(string fileName) where T : IMessage<T>, new()
    {
        if (_configs.ContainsKey(fileName))
            return (T)_configs[fileName];

        string relativePath = string.Format("{0}{1}.bytes", _path, fileName);

        TextAsset textAsset = GameWorld.Resources.LoadAsset<TextAsset>(relativePath);

        if (textAsset == null) 
        {
            Debug.LogError(string.Format("配置文件加载错误,路径为={0}", relativePath));
            return default(T);
        }

        T t = new T();
        t = (T)t.Descriptor.Parser.ParseFrom(textAsset.bytes);
        _configs.Add(fileName, t);

        return t;
    }

    void _Uninstall(string fileName)
    {
        if (_configs.ContainsKey(fileName))
            _configs.Remove(fileName);
    }

    LuaByteBuffer _ReadDataConfigForLua(string fileName)
    {
        byte[] bytesData = null;

        if (!_luaConfigs.TryGetValue(fileName, out bytesData)) 
        {
            string relativePath = string.Format("{0}{1}.bytes", _path, fileName);
            TextAsset textAsset = GameWorld.Resources.LoadAsset<TextAsset>(relativePath);
            if (textAsset == null)
            {
                Debug.LogError(string.Format("配置文件加载错误,路径为={0}", relativePath));
                return null;
            }
            bytesData = textAsset.bytes;
        }

        return new LuaByteBuffer(bytesData);
    }

    void _UninstallForLua(string fileName)
    {
        if (_luaConfigs.ContainsKey(fileName))
        {
            _luaConfigs.Remove(fileName);
        }
    }

    public static T LoadConfig<T>(string fileName) where T : IMessage<T>, new()
    {
        return GameWorld.Config._LoadConfig<T>(fileName);
    }

    public static void Uninstall(string fileName)
    {
        GameWorld.Config._Uninstall(fileName);
    }


    public static LuaByteBuffer ReadDataConfigForLua(string fileName)
    {
        return GameWorld.Config._ReadDataConfigForLua(fileName);
    }

    public static void UninstallForLua(string fileName)
    {
        GameWorld.Config._UninstallForLua(fileName);
    }




}
