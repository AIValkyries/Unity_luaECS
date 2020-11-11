local M = class("FsmMachine")

function M:ctor()
	self._states = {}
	self._current = {}
end

function M:AddState( baseState )
	self._states[baseState.__cname] = baseState
end


function M:AddInitState(baseState)
	 self._current = baseState;
	 self._current:OnEnter()
end

function M:UpdateState(...)
	self._current:OnUpdate(...)
end



function M:ChangeState(state,...)
	if self._current.__cname == state.__cname then
		print("同一个状态不能转换!!!!")
		return;
	end
	if not self._states[state.__cname] then
		error("["..state.__cname.."]不存在这个状态!!!!")
	end
	self._current:OnLeave(...)
	self._current = self._states[state.__cname];
	self._current:OnEnter(...)

end


return M;