-- Matcher 一组组件ID
-- 所做的工作就是判断实体是否存在 一组ID集合
local function string_components( components )
	if not components then
		return ""
	end

	local str = ""
	for _,v in pairs(components) do
		if #str >0 then
			str = str.. ",\n"
		end

		if v then
			str = str.."compoent="..v._name
		end
	end

	return str;
end

local function string_compoents_ex(components)
	if not components or #components==0 then
		return ""
	end
	local str = ""

	for _,v in pairs(components) do
		if #str>0 then
			str = str..","
		end

		if v then
			str = str.."compoent="..v._name
		end
	end

	return str
end


local M = {}
M.__index = M
M.__tostring = function (t )
	   return string.format("<Matcher [all=({%s})]>",
        string_components(t._all))
end

-- 是否全等
local function components_eql( comps1,comps2 )
	
	for k,v in pairs(comps1) do
		if not comps2[k] or not comps1[k]._name ~= comps2[k]._name then
			return false
		end
	end
    return true;
end

-- 是否包含
local  function components_has( comps,comp )
	for _,v in pairs(comps) do
		if  v._name == comp._name then
			return true
		end
	end
	return false
end


function  M:MatchEntity(entity)
	if not self._all then
		return false
	end

	if entity:HasAll(self._all)	then
		return true;
	end

	return false
end


function  M:Match(coms)
	if not self._all then
		return false
	end

	if components_eql(self._all,comps) then
		return true
	end
	return false;
end


function M:MatchOne(comp)
	if not self._all then
		return false
	end

	if components_has(self._all,comp) then
		return true
	end

	return false;
end


return function (allOf)
	 local tb = {_all = allOf}
	 return setmetatable(tb,M);
end