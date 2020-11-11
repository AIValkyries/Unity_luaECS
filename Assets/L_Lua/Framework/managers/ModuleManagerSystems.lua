
require("Framework.moduleBase.Entity.FrameworkSilentlyEntity");
require("Framework.moduleBase.Component.ModuleManagerComponent")
require("Framework.moduleBase.Component.UIManagerComponent")
require("Logic.ModuleConst")

ModuleManagerCompoent = ModuleManagerEntity:Get(ModuleManagerComponent);
ViewManagerCompoent   = UIManagerCompoentEntity:Get(UIManagerComponent);

local M = class("ModuleManagerSystems",Systems:New())


function M:Initialize()
	 print("ModuleManagerSystems.....Initialize")
	 
	 ModuleManagerCompoent.ModuleMap      = {}
	 ModuleManagerCompoent.MountedModules = {}

	 local prefab = GameWorld.Resources:LoadAsset("L_Resources/UIRoot.prefab",typeof(GameObject))

	 if prefab == nil then
	 	error("没有找到UIRoot");
	 end

	 ViewManagerCompoent.Root = GameObject.Instantiate(prefab);
	 ViewManagerCompoent.Layers = {}
	 ViewManagerCompoent.UIPrefabs = {}
	 ViewManagerCompoent.UIViews = {}

	 for k=1, ViewManagerCompoent.Root.transform.childCount do
	 	ViewManagerCompoent.Layers[k] = ViewManagerCompoent.Root.transform:GetChild(k-1).gameObject;
	 end

	 local gameObject = GameObject("EventSystem")

	 gameObject:AddComponent(typeof(EventSystem));
     gameObject:AddComponent(typeof(StandaloneInputModule));

     GameObject.DontDestroyOnLoad(ViewManagerCompoent.Root);
     GameObject.DontDestroyOnLoad(gameObject);

     self:RegisterModuleType()
end


function M:RegisterModuleType()

	-- 在这里注册模块
	ModuleManagerCompoent.ModuleMap[MODULE_ID.TEST_MODULE] = function ()
	    -- 填写 需要 require 的路径，方便后面卸载
         require("Test.TestTools")
         TestModuleBase = require("Test.TestModuleBase")
         TestViewController = require("Test.TestViewController")
         TestViewSystem = require("Test.TestViewSystem")
         return TestModuleBase;
	end


end


function M:CallModule( moduleId, op, param )

	ModuleManagerCompoent.PreModuleID = moduleId

	if not ModuleManagerCompoent.ModuleMap[moduleId] then
		error("模块=["..moduleId.."]没有注册!!");
		return;
	end

	local moduleBase = ModuleManagerCompoent.MountedModules[moduleId]

	if not moduleBase then
		moduleBase = ModuleManagerCompoent.ModuleMap[moduleId]():New()
		moduleBase:Initialize()
		self:Add(moduleBase);
	else
		moduleBase = ModuleManagerCompoent.MountedModules[moduleId]
	end

	moduleBase:Call(op, param)

	ModuleManagerCompoent.MountedModules[moduleId] = moduleBase
end

function M:CloseModule( moduleId, op, param )

	local moduleBase = ModuleManagerCompoent.MountedModules[moduleId]

	if moduleBase then
		self:Remove(moduleBase);
        moduleBase:Call(op, param);
        moduleBase:TearDown();

        local requirePaths = moduleBase:GetRequirePaths()
        if requirePaths then
        	for k,_v in pairs(requirePaths) do
        		for key,_ in pairs(package.loaded) do
        			if string.find(tostring(key),_v) == 1 then
        				package.loaded[key] = nil
        			end
        		end
        	end
        end

        ModuleManagerCompoent.MountedModules[moduleId] = nil
	end

end


return M;