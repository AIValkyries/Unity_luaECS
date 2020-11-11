--- 模块系统
--- 包含ViewSystem 和 ControllerSystem
--  每个ViewSystem 都会注册 ControllerSystem
local Systems = require("Framework.entitas.Systems")
require("Framework.moduleBase.Entity.FrameworkSilentlyEntity");
require("Framework.moduleBase.Component.ViewSystemComponent")
require("Framework.moduleBase.ModuleParam")

ViewManagerCompoent = UIManagerCompoentEntity:Get(UIManagerComponent);

local M = class("ModuleBaseSystems",Systems:New());


function M:ctor()
	self.super:ctor()

	self._view_bind_controller = {}
	self._view_system_bind_entity = {}
	self:ViewBindContoller();
end

function M:ViewBindContoller()
	
end


function M:Call(op,param)

	if op == ModuleEvent.OPEN_VIEW then
		self:_openView(param.InstantiationType,param.ViewPath)
	elseif op == ModuleEvent.CLOSE_VIEW then
		 self:_closeView(param.InstantiationType);
	end

	self:OnCall(op,param)
end

function M:OnCall(op,param)


end


function M:_openView(viewSystemType,viewPath)
	local prefab = nil;

	if not ViewManagerCompoent.UIPrefabs[viewPath] then
		prefab = GameWorld.Resources:LoadAsset(viewPath,typeof(GameObject))
		ViewManagerCompoent.UIPrefabs[viewPath] = prefab
	end

	local viewObject = nil;

	if not ViewManagerCompoent.UIViews[prefab] then
		viewObject = GameObject.Instantiate(prefab)
		viewObject.name = viewObject.name.."_lua"
		ViewManagerCompoent.UIViews[prefab] = viewObject
	end

	local entity = ModuleBaseContext:CreateEntity();

	local component = entity:Add(ViewSystemComponent)
	component.gameObject = viewObject;
	component.ViewPath = viewPath;

	local viewSystem = viewSystemType:New()
	viewSystem:RegistViewCompoent(component);
	viewSystem:Initialize();

	if self._view_bind_controller[viewSystemType] then
		local controller = self._view_bind_controller[viewSystemType]:New()
		controller:Initialize(viewObject)
	end

	component.gameObject.transform:SetParent(self:GetParent(component))
	local rectTransform = viewObject:GetComponent(typeof(RectTransform))

	rectTransform.anchoredPosition3D = Vector3.zero;
	viewObject.transform.localRotation = Quaternion.identity;
	viewObject:SetActive(true);

	if not self._view_system_bind_entity[viewSystemType] then
		self._view_system_bind_entity[viewSystemType] = entity;
	end
end


function M:_closeView(viewSystemType)
	local entity = self._view_system_bind_entity[viewSystemType]

	local viewCompoent = entity:Get(ViewSystemComponent)

	local prefab = ViewManagerCompoent.UIPrefabs[viewCompoent.ViewPath]

	if prefab then
		local allowDestroyingAssets = false;

		if not viewCompoent.CachePrefab then
			ViewManagerCompoent.UIPrefabs[viewCompoent.ViewPath] = nil
			allowDestroyingAssets = true;
		end

		local gameObject = ViewManagerCompoent.UIViews[prefab]

		if not viewCompoent.CacheGameObjet then
			 GameObject.DestroyImmediate(gameObject, allowDestroyingAssets);
			 ViewManagerCompoent.UIViews[prefab] = nil
		else
			gameObject:SetActive(false);
            gameObject.transform.position = Vector3(99999,99999,99999);
		end
	end

	ModuleBaseContext:DestroyEntity(entity)
	self._view_system_bind_entity[viewSystemType] = nil
end

function M:GetParent(compoent )
	return ViewManagerCompoent.Layers[compoent.layer].transform
end

function M:GetRequirePaths()
	return ""
end


return M;