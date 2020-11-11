/****************************************************
 *  Copyright © 2018-2020 #AUTHORNAME#. All rights reserved.
 *------------------------------------------------------------------------
 *  文件：UnityTools.cs
 *  作者：Lonely
 *  日期：Created by #CreateTime#
 *  功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class UnityTools
{
    public static T GetComponent<T>(this Transform transform,string path)
    {
        return transform.Find(path).GetComponent<T>();
    }

    public static void AddListener(this Button button, UnityAction call)
    {
        button.onClick.AddListener(call);
    }



}
