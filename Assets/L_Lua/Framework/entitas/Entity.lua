local Delegate = require("Framework.entitas.Delegate")
local M = {}

-- print string
M.__tostring = function(t)
    local str = ""
    for _, v in pairs(t._components) do
        if #str > 0 then
            str = str .. ",\n"
        end

        if v then
            str = str .. "component="..v._name
        end
    end
    return string.format("\n<Entity_%d\n %s\n>", t._creationIndex, str)
end

function M:New(tb)
	 tb = tb or {}

	 tb._creationIndex = 0

	 tb._is_enabled = false

	 tb.on_component_added    = Delegate:New()

	 tb.on_component_removed  = Delegate:New()

	 tb.on_component_replaced = Delegate:New()
	 -- 组件集合
	 tb._components = {}
	 tb._size = 0;
	 setmetatable(tb,M);
	 M.__index = M;
	 return tb 
end

function M:Activate(creationIndex)
	self._creationIndex = creationIndex;
	self._is_enabled = true;
end

function M:Has( comp_type )
	 return self._components[comp_type._name];
end

function M:HasAll(comp_types)
	 if not comp_types or #comp_types == 0 then
	 	return false;
	 end

	 for _,v in pairs(comp_types) do 
	 	if not self._components[v._name] then
	 		return false
	 	end
	 end

	 return true;
end

function M:Add(comp_type)
	if not self._is_enabled then
		error("Cannot add component entity is not enabled.")
	end
	
	if self:Has(comp_type) then
		 error("Cannot add another component")
	end
	local new_component = comp_type()
	self._components[comp_type._name] = new_component
	self._size = self._size + 1;
	self.on_component_added(self,new_component);

	return new_component;
end


function M:Remove(comp_type)
	if not self._is_enabled then
        error("Cannot add component entity is not enabled.")
    end

    if not self:Has(comp_type) then
        error(string.format("Cannot remove unexisting component %s", tostring(comp_type)))
    end

     self:_replace(comp_type, nil)
     self._size=self._size-1;
end

function M:Replace(oldcomp_type,newcomp_type)
	if not self._is_enabled then
        error("Cannot add component entity is not enabled.")
    end

    if self:Has(oldcomp_type) then
    	self:_replace(oldcomp_type,newcomp_type)
    else
    	self:Add(oldcomp_type)
    end

end

function M:_replace(oldcomp_type,newcomp_type)
	if newcomp_type and oldcomp_type._name ~= newcomp_type._name then
		error("只能替换同类型的组件!!!");
	end
	local comp_value = self._components[oldcomp_type._name];

	if not newcomp_type then  --删除
		self._components[oldcomp_type._name] = nil
		self.on_component_removed(self,comp_value)
	else
		self._components[oldcomp_type._name] = newcomp_type
		self.on_component_replaced(self, comp_value)
	end
end

function M:GetByName( com_Name )
	return self._components[com_Name]
end

function M:Get(comp_type)
	 if not self:Has(comp_type) then
	 	error(string.format("entity has not component '%s'",tostring(comp_type)))
	 end
	return self._components[comp_type._name]
end

function  M:GetAll()
	return self._components;
end

function M:Size()
	return self._size;
end


function M:RemoveAll()
	for k, v in pairs(self._components) do
        if v then
            self:_replace(v, nil)
        end
    end
end

function  M:Destroy()
	self._is_enabled = false;
	self:RemoveAll()
end


return M;
