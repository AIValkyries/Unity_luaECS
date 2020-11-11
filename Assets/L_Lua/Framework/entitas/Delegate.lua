local M = {}
M.__index = M

M.__call =function (t,...)
	for k,_ in pairs(t._listeners) do
		k(...)
	end
end


function M:New()
	local tb = {}
	tb._listeners = {}
	tb.Size = 0;
	return setmetatable(tb,M);
end


function M:Add( f )
	 if not self._listeners[f] then
	 	self._listeners[f] = true
	 	self.Size  = self.Size+1;
	 	return true;
	 end
	 return false;
end

function M:Remove( f )
	if not self._listeners[f] then
		return false;
	end
	self._listeners[f] = nil
	self.Size = self.Size-1;
    return f;
end

function  M:Size( )
	return self.Size;
end

function  M:Has( f )
	 return self._listeners[f];
end

function M:Clear()
	for k,_ in pairs(self._listeners) do
		self._listeners[k] = nil
	end
	self.Size = 0
end


return M;