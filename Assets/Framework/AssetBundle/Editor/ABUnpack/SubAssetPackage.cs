/****************************************************
	文件：SubAssetPackage.cs
	作者：Lonely
	github：https://github.com/AIValkyries/AssetBundleUpdate
	日期：2020/07/02 22:23:42
	功能：分包
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using Dataconfig;
using System.Xml;
using Google.Protobuf;

public class SubAssetPackage
{
    static List<List<string>> _package_list = new List<List<string>>();
    static List<ResPackageInfo> _res_package_infos = new List<ResPackageInfo>();
    
    /// <summary>
    /// 资源打包标记
    /// 如何ab已经被打包了，则不在重复打包
    /// </summary>
    static Dictionary<string, bool> _assetPackFlags = new Dictionary<string, bool>();

    /// <summary>
    /// 分包信息
    /// </summary>
    static List<AssetDataInfo> _fenBaos = new List<AssetDataInfo>();
    static AssetBundleManifest _assetBundleManifest;

    static BuildTarget _target;
    static int _packageCount = 3;
    static string _fenBaoPath;
    static string _sourcePath;
    static int _fenBaoVersion;

    static void Init()
    {
        _fenBaos.Clear();
        _package_list.Clear();
        _res_package_infos.Clear();
        _assetPackFlags.Clear();
        _target = UnpackCommon.Target;

        ResVersionEditor.Current.Read();

        _fenBaoVersion = UnpackCommon.GetFenBaoVersion();
        _fenBaoPath = AssetBundleServerPath.FenBao.GetFenBaoPath(UnpackCommon.DefaultABPath);
        _sourcePath = UnpackPath.Get();

        AssetBundle assetBundle = AssetBundle.LoadFromFile(UnpackPath.GetMainAssetBundleName()); ;
        _assetBundleManifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        assetBundle.Unload(false);
    }

    // 分包 跟资源key找到assetbundle将其压缩成一个包，
    // 写入版本文件
    public static void Subpackage()
    {
        Init();
        if (_fenBaoVersion < 1)
            Debug.LogError("分包的起始版本是1哦");

        BuildResourcePack();
        GetAssetListIntoPoint();

        // 进行压缩 和写入版本文件
        ArchiveAssetpackage();
        ResVersionEditor.Current.Save(PackageType.CompressionPack);
        FenBaoManifestEditor.Current.Write(_fenBaos);
        //AssetBundlesFileInfoEditor.Current.Save(_assetBundleManifest.GetAllAssetBundles());

        AssetDatabase.Refresh();
        Debug.Log("分包完成!");
    }

    static void ArchiveAssetpackage()
    {
        if (!Directory.Exists(_fenBaoPath))
            Directory.CreateDirectory(_fenBaoPath);
        else
        {
            DirectoryInfo parent = new DirectoryInfo(_fenBaoPath);
            FileInfo[] fileInfos = parent.GetFiles();
            for (int i = 0; i < fileInfos.Length; i++)
                File.Delete(fileInfos[i].FullName);
        }

        for (int i = 0; i < _package_list.Count; i++) 
        {
            AssetDataInfo info = new AssetDataInfo();
            if (_package_list[i].Count <= 0)
                continue;

            if (i == 0)  // 首包
            {
               GetFileToZip(_package_list[i], i,ref info);
            }
            else
            {
                GetFileToZip(_package_list[i], i, ref info);
            }
            _fenBaos.Add(info);
        }
    }

    static void GetFileToZip(
        List<string> assets,
        int fenBaoIndex,
        ref AssetDataInfo fenBaoInfo)
    {
        fenBaoInfo.Name = AssetBundleServerPath.FenBao.GetPackageFileName(UnpackCommon.DefaultABPath, fenBaoIndex);
        string packPath = AssetBundleServerPath.FenBao.GetPackageFullFileName(UnpackCommon.DefaultABPath, fenBaoIndex);

        Dictionary<string, FileStream> assetFiles = new Dictionary<string, FileStream>();

        for (int i = 0; i < assets.Count; i++) 
        {
            string fileFullName = _sourcePath + "/" + assets[i];
            FileStream info = File.Open(fileFullName, FileMode.Open);
            assetFiles.Add(assets[i], info);
        }

        using (ZipOutputStream outStream = new ZipOutputStream(File.Create(packPath)))
        {
            outStream.SetLevel(0);
            Crc32 crc = new Crc32();
            List<byte[]> zipBuffers = new List<byte[]>();

            var itr = assetFiles.Keys.GetEnumerator();
            long index = 0;
            int totalSize = 0;
            while (itr.MoveNext())
            {
                FileStream fs = assetFiles[itr.Current];
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

                ZipEntry entry = new ZipEntry(itr.Current);
                entry.DateTime = File.GetLastAccessTime(itr.Current);
                entry.Size = buffer.Length;
                entry.ZipFileIndex = assetFiles.Count - index++;
                fs.Close();
                crc.Reset();
                crc.Update(buffer);
                entry.Crc = crc.Value;
                outStream.PutNextEntry(entry);
                outStream.Write(buffer, 0, buffer.Length);

                totalSize = (int)outStream.Length;
            }

            outStream.Close();
            itr.Dispose();
        }

        using (FileStream fs = File.Open(packPath, FileMode.Open)) 
        {
            fenBaoInfo.Size = (int)fs.Length;

            byte[] outBytes = new byte[fenBaoInfo.Size];
            fs.Read(outBytes, 0, outBytes.Length);

            fenBaoInfo.MD5 = FileUtils.GetBytesMD5(outBytes);
        }
    }

    static void GetAssetListIntoPoint()
    {
        for (int i = 0; i < _packageCount; i++) 
        {
            _package_list.Add(new List<string>());
        }
        for (int i = 0; i < _res_package_infos.Count; i++) 
        {
            uint index = _res_package_infos[i].PackageIndex;
            string abName = _res_package_infos[i].ABName;
            if (!_package_list[(int)index].Contains(abName))
                _package_list[(int)index].Add(abName);
        }
    }

    static void BuildResourcePack()
    {
        _resConfigArray = LoadConfigFile<ResConfigArray>("L_Resources/DataConfig/dataconfig_resconfig");

        GetSceneFenBaoAsset();
        GetNpcFenBaoAsset();
        GetNPCMissionFenBaoAsset();
        GetMonsterFenBaoAsset();
        GetPlayerFenBaoAsset();
        GetMusicFenBaoAsset();
        GetUIFenBaoAsset();
        GetSoundFenBaoAsset();
        GetSoundMissionFenBaoAsset();
        GetRestFenBaoAsset();
        GetLuaFenBaoAsset();
    }

    static ResConfigArray _resConfigArray;

    #region 场景资源分包

    static LevelConfigArray _levelConfigArray;
    static SceneFenBaoArray _sceneFenBaoArray;

    static void GetSceneFenBaoAsset()
    {
        _levelConfigArray = LoadConfigFile<LevelConfigArray>("L_Resources/DataConfig/dataconfig_levelconfig");
        _sceneFenBaoArray = LoadConfigFile<SceneFenBaoArray>("L_Resources/DataConfig/dataconfig_scenefenbao");

        for (int i = 0; i < _sceneFenBaoArray.Items.Count; i++) 
        {
            SceneFenBao sceneFenBao = _sceneFenBaoArray.Items[i];
            uint sceneId = sceneFenBao.ID;
            uint packageIndex = sceneFenBao.Pakage;

            if (sceneFenBao.Version != _fenBaoVersion)
                continue;

            SceneConfig sceneConfig = GetSceneConfig(sceneId);

            for (int j = 0; j < sceneConfig.Objects.Count; j++)
            {
                string abName = GetAssetOfABNameByPath(sceneConfig.Objects[j].Path);
                string abPath = _sourcePath + "/" + abName;
                BuildResPackageInfo("GetSceneFenBaoAsset", abPath, packageIndex);
            }
        }
    }

    static SceneConfig GetSceneConfig(uint sceneID)
    {
        SceneConfig sceneConfig = new SceneConfig();
        sceneConfig.Objects = new List<SceneConfig.SceneObject>();

        for (int i = 0; i < _levelConfigArray.Items.Count; i++) 
        {
            if (_levelConfigArray.Items[i].ID != sceneID)
                continue;

            string scenePath = "Assets/" + GetAssetPathByResConfig(_levelConfigArray.Items[i].LevelResID) + ".xml";

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(scenePath);

            XmlNodeList parentList = xmldoc.GetElementsByTagName("SceneInfo");

            for (int j = 0; j < parentList.Count; j++)
            {
                XmlNodeList childs = parentList[j].ChildNodes;

                foreach (XmlElement el in childs)
                {
                    SceneConfig.SceneObject sceneObject = new SceneConfig.SceneObject();
                    if (el.Name.Equals("Object"))
                    {
                        sceneObject.Path = el.GetAttribute("Path");
                        sceneConfig.Objects.Add(sceneObject);
                    }
                }
            }
        }

        return sceneConfig;
    }

    #endregion

    #region npc

    static NpcFenBaoArray _npcFenBaoArray;

    static void GetNpcFenBaoAsset()
    {
        _npcFenBaoArray = LoadConfigFile<NpcFenBaoArray>("L_Resources/DataConfig/dataconfig_npcfenbao");

        for (int i = 0; i < _npcFenBaoArray.Items.Count; i++) 
        {
            if (_npcFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            string resPath = GetAssetPathByResConfig(_npcFenBaoArray.Items[i].ResID);
            string abName = GetAssetOfABNameByPath(resPath);
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetNpcFenBaoAsset", abPath, _npcFenBaoArray.Items[i].Pakage);
        }
    }

    #endregion

    #region 任务的npc

    static NPCMissionFenBaoArray _nPCMissionFenBaoArray;
    static TaskInfoArray _taskInfoArray;
    static NpcInfoArray _npcInfoArray;

    static void GetNPCMissionFenBaoAsset()
    {
        _nPCMissionFenBaoArray = LoadConfigFile<NPCMissionFenBaoArray>("L_Resources/DataConfig/dataconfig_npcmissionfenbao");
        _taskInfoArray = LoadConfigFile<TaskInfoArray>("L_Resources/DataConfig/dataconfig_taskinfo");
        _npcInfoArray = LoadConfigFile<NpcInfoArray>("L_Resources/DataConfig/dataconfig_npcinfo");

        for (int i = 0; i < _nPCMissionFenBaoArray.Items.Count; i++) 
        {
            if (_nPCMissionFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            uint taskID = _nPCMissionFenBaoArray.Items[i].TaskID;
            TaskInfo taskInfo = GetTaskInfo(taskID);

            string npcResPath = string.Empty;

            for (int j = 0; j < _npcInfoArray.Items.Count; j++)
            {
                if (_npcInfoArray.Items[j].Id == taskInfo.NPCID)
                {
                    npcResPath = GetAssetPathByResConfig(_npcInfoArray.Items[j].ResId);
                }
            }

            string npcABName = GetAssetOfABNameByPath(npcResPath);
            string npcABPath = _sourcePath + "/" + npcABName;
            BuildResPackageInfo("GetNPCMissionFenBaoAsset", npcABPath, _nPCMissionFenBaoArray.Items[i].Pakage);

            //...正式项目还可能有更多资源
        }
    }

    static TaskInfo GetTaskInfo(uint taskID)
    {
        for (int i = 0; i < _taskInfoArray.Items.Count; i++) 
        {
            if (_taskInfoArray.Items[i].TaskId == taskID) 
            {
                return _taskInfoArray.Items[i];
            }
        }
        return null;
    }

    #endregion

    #region 怪物分包

    static MonsterFenBaoArray _monsterFenBaoArray;

    static void GetMonsterFenBaoAsset()
    {
        _monsterFenBaoArray = LoadConfigFile<MonsterFenBaoArray>("L_Resources/DataConfig/dataconfig_monsterfenbao");

        for (int i = 0; i < _monsterFenBaoArray.Items.Count; i++)
        {
            if (_monsterFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            string resPath = GetAssetPathByResConfig(_monsterFenBaoArray.Items[i].ResID);
            string abName = GetAssetOfABNameByPath(resPath);
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetMonsterFenBaoAsset", abPath, _monsterFenBaoArray.Items[i].Pakage);
        }
    }

    #endregion

    #region 角色分包

    static PlayerFenBaoArray  _playerFenBaoArray;

    static void GetPlayerFenBaoAsset()
    {
        _playerFenBaoArray = LoadConfigFile<PlayerFenBaoArray>("L_Resources/DataConfig/dataconfig_playerfenbao");

        for (int i = 0; i < _playerFenBaoArray.Items.Count; i++)
        {
            if (_playerFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            string resPath = GetAssetPathByResConfig(_playerFenBaoArray.Items[i].ResID);
            string abName = GetAssetOfABNameByPath(resPath);
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetPlayerFenBaoAsset", abPath, _playerFenBaoArray.Items[i].Pakage);
        }

    }

    #endregion

    #region 音乐

    static MusicFenBaoArray  _musicFenBaoArray;

    static void GetMusicFenBaoAsset()
    {
        _musicFenBaoArray = LoadConfigFile<MusicFenBaoArray>("L_Resources/DataConfig/dataconfig_monsterfenbao");

        for (int i = 0; i < _musicFenBaoArray.Items.Count; i++)
        {
            if (_musicFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            string resPath = GetAssetPathByResConfig(_musicFenBaoArray.Items[i].ResID);
            string abName = GetAssetOfABNameByPath(resPath);
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetMusicFenBaoAsset", abPath, _musicFenBaoArray.Items[i].Pakage);
        }

    }

    #endregion

    #region ui分包

    static UIFenBaoArray _uIFenBaoArray;

    static void GetUIFenBaoAsset()
    {
        _uIFenBaoArray = LoadConfigFile<UIFenBaoArray>("L_Resources/DataConfig/dataconfig_uifenbao");
        for (int i = 0; i < _uIFenBaoArray.Items.Count; i++)
        {
            if (_uIFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            string resPath = GetAssetPathByResConfig(_uIFenBaoArray.Items[i].ResID);
            string abName = GetAssetOfABNameByPath(resPath);
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetUIFenBaoAsset", abPath, _uIFenBaoArray.Items[i].Pakage);
        }

    }

    #endregion

    #region Sound

    static SoundFenBaoArray _soundFenBaoArray;

    static void GetSoundFenBaoAsset()
    {
        _soundFenBaoArray = LoadConfigFile<SoundFenBaoArray>("L_Resources/DataConfig/dataconfig_soundfenbao");

        for (int i = 0; i < _soundFenBaoArray.Items.Count; i++)
        {
            if (_soundFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            string resPath = GetAssetPathByResConfig(_soundFenBaoArray.Items[i].ResID);
            string abName = GetAssetOfABNameByPath(resPath);
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetSoundFenBaoAsset", abPath, _soundFenBaoArray.Items[i].Pakage);
        }
    }

    #endregion

    #region 音效

    static SoundMissionFenBaoArray _soundMissionFenBaoArray;

    static void GetSoundMissionFenBaoAsset()
    {
        _soundMissionFenBaoArray = LoadConfigFile<SoundMissionFenBaoArray>("L_Resources/DataConfig/dataconfig_soundmissionfenbao");

        for (int i = 0; i < _soundMissionFenBaoArray.Items.Count; i++)
        {
            if (_soundMissionFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            uint taskID = _nPCMissionFenBaoArray.Items[i].TaskID;
            TaskInfo taskInfo = GetTaskInfo(taskID);

            string musicResPath = string.Empty;

            for (int j = 0; j < _taskInfoArray.Items.Count; j++)
            {
                if (_taskInfoArray.Items[j].TaskId == taskInfo.TaskId)
                    musicResPath = GetAssetPathByResConfig(taskInfo.MusicResID);
            }

            string musicABName = GetAssetOfABNameByPath(musicResPath);
            string musicABPath = _sourcePath + "/" + musicABName;
            BuildResPackageInfo("GetSoundMissionFenBaoAsset", musicABPath, _soundMissionFenBaoArray.Items[i].Pakage);
        }
    }

    #endregion

    #region  其他

    static RestFenBaoArray _restFenBaoArray;

    static void GetRestFenBaoAsset()
    {
        _restFenBaoArray = LoadConfigFile<RestFenBaoArray>("L_Resources/DataConfig/dataconfig_restfenbao");

        for (int i = 0; i < _restFenBaoArray.Items.Count; i++) 
        {
            if (_restFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;

            string resPath = GetAssetPathByResConfig(_restFenBaoArray.Items[i].ResID);
            string abName = GetAssetOfABNameByPath(resPath);
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetRestFenBaoAsset", abPath, _restFenBaoArray.Items[i].Pakage);
        }

    }

    #endregion

    #region lua分包

    static LuaFenBaoArray _luaFenBaoArray;
    static void GetLuaFenBaoAsset()
    {
        _luaFenBaoArray = LoadConfigFile<LuaFenBaoArray>("L_Resources/DataConfig/dataconfig_luafenbao");

        for (int i = 0; i < _luaFenBaoArray.Items.Count; i++) 
        {
            if (_luaFenBaoArray.Items[i].Version != _fenBaoVersion)
                continue;
            string abName = _luaFenBaoArray.Items[i].AbName;
            string abPath = _sourcePath + "/" + abName;
            BuildResPackageInfo("GetLuaFenBaoAsset", abPath, _luaFenBaoArray.Items[i].Pakage);
        }

    }

    #endregion

    static void BuildResPackageInfo(string method, string abPath, uint packageIndex)
    {
        try
        {
            //Debug.Log(method);
            AssetBundle bundle = AssetBundle.LoadFromFile(abPath);

            string[] dependencies = _assetBundleManifest.GetAllDependencies(bundle.name);

            for (int i = 0; i < dependencies.Length; i++)
            {
                BuildResPackageInfo(method, _sourcePath + "/" + dependencies[i], packageIndex);
            }

            if (!_assetPackFlags.ContainsKey(bundle.name))
            {
                ResPackageInfo info = new ResPackageInfo();
                info.ABName = bundle.name;
                info.PackageIndex = packageIndex;

                _res_package_infos.Add(info);

                _assetPackFlags.Add(bundle.name, true);
            }

            bundle.Unload(true);
        }
        catch(System.Exception ex)
        {
            Debug.LogError("method:" + method + " :" + ex.Message);
        }
      
    }

    static string GetAssetPathByResConfig(uint id)
    {
        for (int i = 0; i < _resConfigArray.Items.Count; i++) 
        {
            if (_resConfigArray.Items[i].Id == id) 
            {
                return _resConfigArray.Items[i].ResFile;
            }
        }
        return string.Empty;
    }

    // 获取资源的ab名字根据路径
    static string GetAssetOfABNameByPath(string path)
    {
        string[] split = path.Split('.');
        path = path.Replace("." + split[split.Length - 1], string.Empty);
        string abName = path.Replace("/", ".").ToLower();

        string[] assetBundleNames = _assetBundleManifest.GetAllAssetBundles();

        for (int i = 0; i < assetBundleNames.Length; i++)
        {
            if (assetBundleNames[i] == abName)
                return assetBundleNames[i];
        }

        var itr = UnpackCommon.GetSettingInfo().AssetsMap.Keys.GetEnumerator();
        while (itr.MoveNext())
        {
            string key = itr.Current.Replace("/", ".");
            int index = abName.LastIndexOf(".");
            string name = abName.Substring(0, index);

            if (name == key.ToLower())
            {
                return UnpackCommon.GetSettingInfo().AssetsMap[itr.Current];
            }
        }
        itr.Dispose();

        return string.Empty;
    }


    static T LoadConfigFile<T>(string resPath)where T :IMessage<T>
    {
        T t = default(T);
        string path = "Assets/" + resPath + ".bytes";
        TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
        if (textAsset)
        {
            byte[] bytes = textAsset.bytes;
            return (T)t.Descriptor.Parser.ParseFrom(bytes); 
        }

        return t;
    }


}


public class ResPackageInfo
{
    public string ABName;
    public uint PackageIndex;   // 几号包
}
