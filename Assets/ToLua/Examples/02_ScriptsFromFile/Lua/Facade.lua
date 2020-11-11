
System = {}
 
function System:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o;
end
 
SubSystemOne = System:new()
 
function SubSystemOne:MethodOne()
	print("调用子系统一的方法一")
end
 
function SubSystemOne:MethodTwo()
	print("调用子系统一的方法二")
end
 
function SubSystemOne:MethodThree()
	print("调用子系统一的方法三")
end
 
SubSystemTwo = System:new()
 
function SubSystemTwo:MethodOne()
	print("调用子系统二的方法一")
end
 
function SubSystemTwo:MethodTwo()
	print("调用子系统二的方法二")
end
 
SubSystemThree = System:new()
 
function SubSystemThree:MethodOne()
	print("调用子系统三的方法一")
end
 
Facade = {}
function Facade:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	o.one = SubSystemOne:new()
	o.two = SubSystemTwo:new()
	o.three = SubSystemThree:new()
	return o;
end
 
function Facade:MethodOne()
	self.one:MethodOne()
	self.one:MethodThree()
	self.two:MethodTwo()
end
 
function Facade:MethodTwo()
	self.one:MethodTwo()
	self.two:MethodOne()
	self.three:MethodOne()
end
 
function Facade:MethodThree()
	self.one:MethodOne()
	self.two:MethodOne()
	self.three:MethodOne()
end
 
facade = Facade:new()
 
facade:MethodOne()
