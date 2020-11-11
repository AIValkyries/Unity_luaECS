/****************************************************
 *  Copyright © 2018-2020 #AUTHORNAME#. All rights reserved.
 *------------------------------------------------------------------------
 *  文件：TestViewSystem.cs
 *  作者：Lonely
 *  日期：Created by #CreateTime#
 *  功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cs;

public class TestViewSystem : ViewSystem
{
    public override void RegistViewCompoent(ViewSystemCompoent viewCompoent)
    {
        viewCompoent.CacheGameObjet = false;
        viewCompoent.CachePrefab = false;
        viewCompoent.layer = ViewLayer.TOP;   
    }


    public override void Notify(int op, object param)
    {
        switch (op)
        {
            case (int)TEST_MODDULE_EVENT.SHOW_TEST_VIEW:
                {
                    ShowView((TestModuleEntity)param);
                }
                break;
        }
    }


    void ShowView(TestModuleEntity moduleEntity)
    {
        TestViewObject @object = moduleEntity.testViewObject;
        HeroInfo heroInfo = moduleEntity.heroInfo;
        PersonalInfo personalInfo = moduleEntity.personalInfo;

        @object.TextName.text = heroInfo.Name;
        @object.TextAge.text = heroInfo.Age.ToString();
        @object.TextGender.text = heroInfo.Gender.ToString();
        @object.TextNation.text = heroInfo.Nation;

        @object.TextEducation.text = personalInfo.Education;
        @object.TextPower.text = personalInfo.Power.ToString();
        @object.TextIntelligence.text = personalInfo.Intelligence.ToString();
        @object.TextAgile.text = personalInfo.Agile.ToString();
    }

    #region 事件属性

    public override int GetModuleID()
    {
        return (int)ModuleID.TestModule;
    }

    public override int[] GetListener()
    {
        return new int[] { (int)TEST_MODDULE_EVENT.SHOW_TEST_VIEW };
    }

    #endregion


}
