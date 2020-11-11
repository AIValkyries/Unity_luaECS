/****************************************************
 *  Copyright © 2018-2020 #AUTHORNAME#. All rights reserved.
 *------------------------------------------------------------------------
 *  文件：TestViewControler.cs
 *  作者：Lonely
 *  日期：Created by #CreateTime#
 *  功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cs;
using System.Text.RegularExpressions;
using Entitas;

public class TestViewController : ViewControllerSystem
{
    public override void Initialize(System.Object param = null)
    {
        TestModuleEntity testModuleEntity = Contexts.testModule.CreateEntity();

        HeroInfo heroInfo = testModuleEntity.AddHeroInfo();
        PersonalInfo info = testModuleEntity.AddPersonalInfo();
        TestViewObject testViewObject = testModuleEntity.AddTestViewObject();

        heroInfo.Name = "Lonely";
        heroInfo.Age = 27;
        heroInfo.Gender = 10;
        heroInfo.Nation = "汉族";

        info.Education = "幼儿园小班(班霸)";
        info.Power = 10;
        info.Intelligence = 11;
        info.Agile = 12;

        Transform transform = ((GameObject)param).transform;

        testViewObject.BtnClose = transform.GetComponent<Button>("Close");
        testViewObject.TextName = transform.GetComponent<Text>("Name/Text");
        testViewObject.TextAge = transform.GetComponent<Text>("Age/Text");
        testViewObject.TextGender = transform.GetComponent<Text>("Gender/Text");
        testViewObject.TextNation = transform.GetComponent<Text>("Nation/Text");
        testViewObject.TextEducation = transform.GetComponent<Text>("Education/Text");
        testViewObject.TextPower = transform.GetComponent<Text>("Power/Text");
        testViewObject.TextIntelligence = transform.GetComponent<Text>("Intelligence/Text");
        testViewObject.TextAgile = transform.GetComponent<Text>("Agile/Text");

        testViewObject.BtnClose.AddListener(CloseTestView);

        DispatchSystems.Notify(
            (int)ModuleID.TestModule,
            (int)TEST_MODDULE_EVENT.SHOW_TEST_VIEW, 
            testModuleEntity);
    }


    void CloseTestView()
    {
        ModuleParam param = new ModuleParam();
        param.InstantiationType = typeof(TestViewSystem);

        ModuleManagerSystems.CloseModule(
            (int)ModuleID.TestModule,
            (int)MODULE_EVENT.CloseView,
            param);

        IGroup<TestModuleEntity> group = Contexts.testModule.GetGroup(TestModuleMatcher.TestViewObject);

        IEntity[] entities = group.GetEntities();

        for (int i = 0; i < entities.Length; i++) 
        {
            Contexts.testModule.DestroyEntity((TestModuleEntity)entities[i]);
        }

        //ModuleParam module = new ModuleParam();
        //module.InstantiationType = typeof(TestViewSystem);
        //module.ViewPath = "L_Resources/ViewPrefabs/TestView.prefab";
        //module.Param = null;

        //ModuleManagerSystems.CallModule(
        //    (int)ModuleID.TestModule,
        //    (int)MODULE_EVENT.OpenView,
        //    module);
    }




}


