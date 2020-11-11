-- 事件系统
local M = class("EventSystems");

function  M:ctor()
	self._event_systems = {}
end

function M:Has( moduleID )
	 return self._event_systems[moduleID];
end

function M:_registered( eventSystem )
	local moduleID = eventSystem.GetModuleID();
	if not self:Has(moduleID) then
		self._event_systems[moduleID] = {}
	end

     local listeners = eventSystem.GetListener();

     for k,v in pairs(listeners) do
     	if v then
     		self._event_systems[moduleID][v] = eventSystem
     	end
     end

end

function M:_uninstall( eventSystem )
	local moduleID = eventSystem.GetModuleID();
	if not self:Has(moduleID) then
		return;
	end

	local listeners = eventSystem.GetListener();
    for k,v in pairs(listeners) do
     	if v then
     		self._event_systems[moduleID][v] = nil
     	end
     end

end

function M:_notify( moduleID,op,param)
	if not self:Has(moduleID) then
		error("该模块=["..moduleID.."]没有注册事件")
		return;
	end

	local tableList = self._event_systems[moduleID]

	if tableList[op] then
		tableList[op]:Notify(op,param)
	else
		error("模块=["..moduleID.."]不存在事件=["..op.."]")
	end
	
end


return M;