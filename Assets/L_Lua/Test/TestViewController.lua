require("protocol_generated.cs_personal_pb")


local  M = class("TestViewController")


function M.CloseTestView( )

    local group = TestModule:GetGroup(Matcher({TestViewObject}))

    for k,v in pairs(group._entities) do
        if k then
            TestModule:DestroyEntity(k)
        end
    end

    local param = ModuleParam()
    param.InstantiationType = TestViewSystem

    ModuleManagerSystems:CloseModule(
        MODULE_ID.TEST_MODULE,
        ModuleEvent.CLOSE_VIEW,
        param)


end


function M:Initialize( gameObject )

	local testModuleEntity = TestModule:CreateEntity();

	local pInfo = testModuleEntity:Add(PersonalInfo)
	local heroInfo = testModuleEntity:Add(HeroInfo)
	local viewObject = testModuleEntity:Add(TestViewObject)

	heroInfo.Name = "Lonely";
    heroInfo.Age = 27;
    heroInfo.Gender = 10;
    heroInfo.Nation = "汉族";

    pInfo.Education = "幼儿园小班(班霸)";
    pInfo.Power = 10;
    pInfo.Intelligence = 11;
    pInfo.Agile = 12;

    local transform = gameObject.transform;
    
    viewObject.BtnClose  = SubComponentGet(transform,"Close",typeof(Button))
    viewObject.TextName  = SubComponentGet(transform,"Name/Text",typeof(Text))
    viewObject.TextAge  = SubComponentGet(transform,"Age/Text",typeof(Text))
    viewObject.TextGender  = SubComponentGet(transform,"Gender/Text",typeof(Text))
    viewObject.TextNation  = SubComponentGet(transform,"Nation/Text",typeof(Text))
    viewObject.TextEducation  = SubComponentGet(transform,"Education/Text",typeof(Text))
    viewObject.TextPower  = SubComponentGet(transform,"Power/Text",typeof(Text))
    viewObject.TextIntelligence  = SubComponentGet(transform,"Intelligence/Text",typeof(Text))
    viewObject.TextAgile  = SubComponentGet(transform,"Agile/Text",typeof(Text))

    AddClickCallback(viewObject.BtnClose,self.CloseTestView)

    EventSystems:_notify(
        MODULE_ID.TEST_MODULE,
        MODULE_EVENT.SHOW_TEST_VIEW,
        testModuleEntity)

end





return M;