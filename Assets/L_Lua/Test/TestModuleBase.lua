
TestViewSystem = require("Test.TestViewSystem")
TestViewController = require("Test.TestViewController")
require("Test.TestTools")

local M = class("TestModuleBase",ModuleBaseSystems)

TestModule = Context:New()

function M:ViewBindContoller()
	self._view_bind_controller[TestViewSystem] = TestViewController
end


function M:GetRequirePaths()
	local paths = 
	{
		"Test.TestTools",
		"Test.TestModuleBase",
		"Test.TestViewController",
		"Test.TestViewSystem"
	};
	return paths
end

return M;