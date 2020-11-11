local Entity  = require("Framework.entitas.Entity")
local Group   = require("Framework.entitas.Group")
local Matcher = require("Framework.entitas.Matcher")
local Delegate = require("Framework.entitas.Delegate")

local M = {}
M.__index = M
M.__tostring = function (t)
	-- 实体
	-- 组
	-- 实体pool 
	local str = "";

	for k,v in pairs(t._entities) do
		if #str > 0 then
            str = str .. ","
        end
		if v then
			 str = str .. tostring(v)
		end
	end

	for k,v in pairs(t._groups) do
		if #str>0 then
			str = str..","
		end
		if v then
			str = str .. tostring(v)
		end
	end

	return string.format("\n<Context_%d\n %s\n>", t._uid, str)
end

function M:New(tb)
	local tb = tb or {}
	
	tb._groups   = {}        -- 组集合

    tb._entities = {}        -- 实体集合

    tb._entities_pool = {}   -- 实体pool集合

    tb._uid = 1

    tb._size = 0

    -- 组件事件
    tb.comp_added    = function(...)    return tb._comp_added(tb, ...) end

    tb.comp_removed  = function(...)  return tb._comp_removed(tb, ...) end

    tb.comp_replaced = function(...) return tb._comp_replaced(tb, ...) end

    -- contex事件
    tb._on_entity_created    = Delegate:New();
 
    tb._on_entity_destroyed  = Delegate:New();

    tb._on_group_created     = Delegate:New();

    tb._on_group_destroyed   = Delegate:New();

	setmetatable(tb,M)
	return tb
end

function M:GetSize()
	return self._size;
end

function M:CreateEntity()
	local entity = table.remove(self._entities_pool)
	if not entity then
		entity = Entity:New()
		entity.on_component_added:Add(self.comp_added)
		entity.on_component_removed:Add(self.comp_removed)
		entity.on_component_replaced:Add(self.comp_replaced)
	end

	entity:Activate(self._uid)
	self._entities[entity._creationIndex] = entity
	self._uid = self._uid+1
	self._size = self._size+1
	self._on_entity_created(self,entity)

	return entity;
end

function M:DestroyEntity( entity )

	if not entity then
		error("Entity is nil");
	end
	if not self:HasEntity(entity) then
		error("The context does not contain this entity:"..tostring(entity))
	end

	entity:Destroy();
	self._entities[entity._creationIndex] = nil
	table.insert(self._entities_pool,entity)
	self._size = self._size - 1
	self._on_entity_destroyed(self,entity)
end

function M:HasEntity( entity )
	return self._entities[entity._creationIndex];
end

function M:CreateSilentlyEntity( matcher )
	local group = self._groups[matcher]
	if group then
		return group:GetSingleEntity();
	end

	group = Group:New(matcher)

	local entity = self:CreateEntity();

	local compoents = matcher._all;

	for k,v in pairs(compoents) do
		entity:Add(v)
	end
	
	group:HandleEntity(entity)
	self._groups[matcher] = group;

	self._on_group_created(self,group)

	return group:GetSingleEntity()
end

function M:GetSilentlyEntity( matcher )
	local group = self:GetGroup(matcher)
	if not group then
		return nil
	end

	return group:GetSingleEntity();
end


function M:GetGroup( matcher )
	local group = self._groups[matcher]
	if group then
		return group
	end

	group = Group:New(matcher)

	for k,_e in pairs(self._entities) do
		if _e then
			group:HandleEntity(_e)
		end
	end

	self._groups[matcher] = group;

	self._on_group_created(self,group)

	return group
end


function M:DestroyAllEntity()
	for k,v in pairs(self._entities) do
		if v then
			self:DestroyEntity(v)
		end	
	end
end


-- 实体组件改变的时候回调
 function M:_comp_added(entity,compoent )
	for _,group in pairs(self._groups) do
		group:HandleEntity(entity)
	end
end

 function M:_comp_removed(entity,compoent )
	for _,group in pairs(self._groups) do
		group:HandleEntity(entity)
	end
end

 function M:_comp_replaced(entity,compoent )
	for _,group in pairs(self._groups) do
		group:HandleEntity(entity)
	end
end


return M;