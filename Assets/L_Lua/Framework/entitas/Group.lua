-- 一组组件ID的集合
local Delegate = require("Framework.entitas.Delegate")

local M = {}
M.__index = M

M.__tostring = function(t)
    local str = "";

    for k,v in pairs(t._entities) do
    	if #str >0 then
    		str = str.. ",\n"
    	end

    	if k then
    		 str = str .. tostring(k)
    	end
    end

    str = str.."\n"..tostring(t._matcher)

    return string.format("<Group [{%s}]\n>", str)
end

function M:New( matcher )
	if not matcher then
		error("Group 的 Matcher 不能为空!!!!")
		return;
	end

	local tb = {}

	tb.on_entity_added    = Delegate:New();

	tb.on_entity_removed  = Delegate:New();

	tb._matcher = matcher;

	tb._entities = {}

	tb._size = 0

	return setmetatable(tb,M);
end

function M:HandleEntity( entity )
	if self._matcher:MatchEntity(entity) then
		if self:Add(entity) then
			self.on_entity_added(self,entity)
		end
	else
		if self:Remove(entity) then
			self.on_entity_removed(self,entity)
		end
	end

end

function M:GetSingleEntity()
	local count = self._size;
	if count == 1 then
		return self:At(1);
	end

	if count == 0 then
		return nil
	end

     error(string.format("Cannot get a single entity from a group containing %d entities", count))
end

function M:ContainsEntity( entity )
	return self._entities[entity]; 
end

 function M:Add( entity )
	 if not self._entities[entity] then
	 	self._entities[entity] = true;
	 	self._size =self._size+1
	 	return true
	 end
	 return false
end

 function M:Remove( entity )
	 if self._entities[entity] then
	 	self._entities[entity] = nil
	 	self._size = self._size -1
	 	return entity;
	 end
	 return false
end

 function M:At( pos )
	 local n = 0
	 for k,_ in pairs(self._entities) do
	 	n = n+1
	 	if n == pos then
	 		return k
	 	end
	 end
	 return nil
end

 function M:Clear(  )
	 self._entities = nil
end

return M;

