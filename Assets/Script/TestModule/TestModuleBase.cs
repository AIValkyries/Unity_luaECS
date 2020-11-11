/****************************************************
 *  Copyright © 2018-2020 #AUTHORNAME#. All rights reserved.
 *------------------------------------------------------------------------
 *  文件：TestModuleBase.cs
 *  作者：Lonely
 *  日期：Created by #CreateTime#
 *  功能：Nothing
*****************************************************/

using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleID
{
	TestModule = 1
}

public enum TEST_MODDULE_EVENT
{
	SHOW_TEST_VIEW = 1
}

public class TestModuleBase : ModuleBaseSystems
{


    protected override void ViewBindContoller()
    {
        _view_bind_controller.Add(typeof(TestViewSystem), typeof(TestViewController));
    }



}
