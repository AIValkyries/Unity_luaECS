///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/6 10:06:42
/// 描 述：
///</summary>
///----------------------------------------------------------------

using Entitas;
using Entitas.CodeGenerator.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[ModuleBase, Unique]
public class UIManagerCompoent : IComponent
{
    public GameObject[] Layers;
    public GameObject Root;    // 加载

    /// <summary>
    /// Key:view路径
    /// Value:view的prefab
    /// </summary>
    public Dictionary<string, GameObject> UIPrefabs;

    /// <summary>
    /// Key:Prefab
    /// Value:实例
    /// </summary>
    public Dictionary<GameObject, GameObject> UIViews;


}
