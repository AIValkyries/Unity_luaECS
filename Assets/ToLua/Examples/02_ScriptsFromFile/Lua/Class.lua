

local function serach(k,pilts)
	for i=1,#pilts do
		local v = pilts[i][k]
		if v then return v end;
	end

	return nil
end

function createClass(...)
	local c = {}
	local parents = {...}

	setmetatable(c,{__index=function (t,k)
		return serach(k,parents)
	end})

	c.__index = c
	function c:new(o)
		o = o or {}
		setmetatable(o,c)
		return o
	end

	return c
end

function  new(c)
	local o = {}
	setmetatable(o,{__index=c})
	return o
end
