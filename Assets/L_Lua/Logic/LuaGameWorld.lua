local M = class("MainSystems",Systems)

-- 在这里引用 管理Systems
ModuleManagerSystems = require("Framework.managers.ModuleManagerSystems")
ConfigDataCenterSystems = require("Framework.managers.ConfigDataCenterSystems")

function M:ctor()
	self.super:ctor()

	self:Add(ModuleManagerSystems)
	self:Add(ConfigDataCenterSystems)
end


function M:Initialize()
	self.super:Initialize()  -- 这里要调用父类的 方法

	local module = ModuleParam()
	module.InstantiationType = require("Test.TestViewSystem")
	module.ViewPath = "L_Resources/ViewPrefabs/TestView.prefab";
	module.Param = nil

	ModuleManagerSystems:CallModule(
		MODULE_ID.TEST_MODULE,
		ModuleEvent.OPEN_VIEW,
		module)
	
end



return M;