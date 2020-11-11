
local M = class("ViewSystem");

function M:Initialize()
	EventSystems:_registered(self);
end

function M:TearDown()
	EventSystems:_uninstall(self);
end

function M:RegistViewCompoent( viewCompoent )
	
end

function M:Execute()


end

function M:GetModuleID()
	
end

function  M:GetListener()
	
end

function M:Notify( op,param )
	
end


return M;