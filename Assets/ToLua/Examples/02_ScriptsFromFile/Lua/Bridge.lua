System = {}
 
function System:new(n)
	o = {}
	setmetatable(o,self)
	self.__index = self
	o.phonename = n
	return o;
end
 
function System:GetSystem()
	if self.phonename == "Iphone5s" then
		return "IOS 7"
	elseif self.phonename == "Lumia1020" then
		return "WP 8"
	end
end
 
CPU = {}
 
function CPU:new(n)
	o = {}
	setmetatable(o,self)
	self.__index = self
	o.phonename = n
	return o;
end
 
function CPU:GetCPU()
	if self.phonename == "Iphone5s" then
		return "苹果 A7/M7协处理器"
	elseif self.phonename == "Lumia1020" then
		return "高通 Adreno 225"
	end
end
 
Memory = {}
 
function Memory:new(n)
	o = {}
	setmetatable(o,self)
	self.__index = self
	o.phonename = n
	return o;
end
 
function Memory:GetMemory()
	if self.phonename == "Iphone5s" then
		return "RAM容量：1GB "
	elseif self.phonename == "Lumia1020" then
		return "RAM容量：2GB"
	end
end
 
 
Cellphone = {}
 
function Cellphone:new(n,o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	self.system = System:new(n)
	self.cpu = CPU:new(n)
	self.memory = Memory:new(n)
	self.phonename = n
	return o;
end
 
function Cellphone:ShowDetail()
	print(self.phonename)
	print(self.system:GetSystem())
	print(self.cpu:GetCPU())
	print(self.memory:GetMemory())
end
 
Iphone5s = Cellphone:new()
 
function Iphone5s:Description()
	print("就三个字，'土豪金'")
end
 
Lumia1020 = Cellphone:new()
 
function Lumia1020:Description()
	print("最好的相机手机，诺基亚，质量的保证")
end
 
 
phone = Iphone5s:new("Iphone5s")
phone:Description()
phone:ShowDetail()
 
 
phone = Lumia1020:new("Lumia1020")
phone:Description()
phone:ShowDetail()