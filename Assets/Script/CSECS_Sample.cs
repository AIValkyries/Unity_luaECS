/****************************************************
 *  Copyright © 2018-2020 #AUTHORNAME#. All rights reserved.
 *------------------------------------------------------------------------
 *  文件：CSECS_Sample.cs
 *  作者：Lonely
 *  日期：Created by #CreateTime#
 *  功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSECS_Sample : MonoBehaviour 
{
	void Awake()
	{
		Contexts.sharedInstance.SetAllContexts();
		GameWorld.GetInstance().Initialize(false);
	}
	 
}
