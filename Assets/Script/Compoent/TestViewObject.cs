/****************************************************
 *  Copyright © 2018-2020 #AUTHORNAME#. All rights reserved.
 *------------------------------------------------------------------------
 *  文件：TestViewObject.cs
 *  作者：Lonely
 *  日期：Created by #CreateTime#
 *  功能：Nothing
*****************************************************/

using Entitas.CodeGenerator.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[TestModule]
public class TestViewObject : IComponent 
{
	public Button BtnClose;
	public Text TextName;
	public Text TextAge;
	public Text TextGender;
	public Text TextNation;
	public Text TextEducation;
	public Text TextPower;
	public Text TextIntelligence;
	public Text TextAgile;
}
