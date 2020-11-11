local M = class("TestViewSystem",ViewSystem);


function M:RegistViewCompoent(viewCompoent)
	viewCompoent.CacheGameObjet = true;
	viewCompoent.CachePrefab = true;
	viewCompoent.layer = ViewLayer.TOP;
end


function M:GetModuleID()
	return MODULE_ID.TEST_MODULE
end

function  M:GetListener()
	return {MODULE_EVENT.SHOW_TEST_VIEW,MODULE_EVENT.CLOSE_TEST_VIEW}
end

function M:Notify(op,param )

	if op == MODULE_EVENT.SHOW_TEST_VIEW then
		self:ShowView(param)
	elseif op == MODULE_EVENT.CLOSE_TEST_VIEW then
		print("关闭View!!!");
	end

end


function M:ShowView(moduleEntity)

	local object = moduleEntity:Get(TestViewObject);
	local heroInfo = moduleEntity:Get(HeroInfo);
	local personalInfo = moduleEntity:Get(PersonalInfo);

	object.TextName.text = heroInfo.Name;
    object.TextAge.text = heroInfo.Age;
    object.TextGender.text = heroInfo.Gender;
    object.TextNation.text = heroInfo.Nation;

    object.TextEducation.text = personalInfo.Education;
    object.TextPower.text = personalInfo.Power;
    object.TextIntelligence.text = personalInfo.Intelligence;
    object.TextAgile.text = personalInfo.Agile;
end



return M;