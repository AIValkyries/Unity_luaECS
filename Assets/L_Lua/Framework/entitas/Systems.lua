

local  M = class("Systems")

function M:ctor()
	self._initialize_system = {}
	self._execute_systems = {}
	self._cleanup_systems = {}
	self._tear_down_systems = {}

end

function M:Add(system)
	if system.Initialize then
		table.insert(self._initialize_system,system);
	end
	if system.Execute then
		table.insert(self._execute_systems,system);
	end

	if system.Cleanup then
		 table.insert(self._cleanup_systems, system)
	end

	if system.TearDown then
        table.insert(self._tear_down_systems, system)
    end
end

function M:Remove(system)
	if system.Initialize then
		for k,v in pairs(self._initialize_system) do
			if v == system then
				table.remove(self._initialize_system,k)
			end
		end
	end
	if system.Execute then
		for k,v in pairs(self._execute_systems) do
			if v == system then
				table.remove(self._execute_systems,k)
			end
		end
	end

	if system.Cleanup then
		for k,v in pairs(self._cleanup_systems) do
			if v == system then
				table.remove(self._cleanup_systems,k)
			end
		end
	end

	if system.TearDown then
		for k,v in pairs(self._tear_down_systems) do
			if v == system then
				table.remove(self._tear_down_systems,k)
			end
		end
    end
end

function M:Initialize(param)	
	for _,system in pairs(self._initialize_system) do
		system:Initialize(param);
	end
end

function M:Execute()
	for _,system in pairs(self._execute_systems) do
		system:Execute()
	end
end

function M:Cleanup()
	for _,system in pairs(self._cleanup_systems) do
		system:Cleanup()
	end
end

function M:TearDown()
	for _,system in pairs(self._tear_down_systems) do
		system:TearDown()
	end
end


return M;