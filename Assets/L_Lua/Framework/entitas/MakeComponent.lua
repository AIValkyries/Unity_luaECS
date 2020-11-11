
-- name:组件名称
-- ...:组件字段
function make_compoent(name, ... )
	 local tb = {}
	 tb._name   = name;
	 tb._getter = {}
	 tb._setter = {}

	 local keys = {...}
	 for k,_v in pairs(keys) do
	 	tb._getter[_v] = true 
	 end

	 tb.__index = function( self,property )
	     if tb[property] then
	 	    return tb[property]
	     end

	 	 if not tb._getter[property] then
	 	 	error("Field:"..property .. " not found")
	 	 	return nil
	 	 end

	 	 local value = self._setter[property]
	 	 if not value then
	 	  	return "nil"
	 	  end
	 	 return value
	 end

	 tb.__newindex = function( self, property, value )
	 	 if (property=="_name") then
	     	error("Field:"..property.."=该字段是只读的!!!")
	     end
	 	 if not tb._getter[property] then
	 	 error("Field:"..property .. " not found")
	 	 	return nil
	 	 end

	 	self._setter[property] = value
	 end

	 --...:组件字段的值
	 tb.__call = function()
	 	 local self = {}
	 	 self._setter = {}
	 	 setmetatable(self,tb);
	 	 return self
	 end
     return setmetatable({},tb)
end

return make_compoent


