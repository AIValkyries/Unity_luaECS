///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/6 9:55:43
/// 描 述：
///</summary>
///----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[ModuleBase]
public class ViewSystemCompoent : IComponent
{
    // 这个不需要在viewSystem找那个设置
    public GameObject gameObject;
    public string ViewPath;

    public ViewLayer layer;
    public bool CachePrefab;   //缓存prefab
    public bool CacheGameObjet; // 缓存gameObject
}
