--- 适配器，面向接口的设计模式

Target = {}
 
function Target:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o;
end
 
function Target:Listen(content)
	print(content)
end
 
Adaptee = {}   -- 适应者
 
function Adaptee:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o;
end
 
function Adaptee:Translate(content)
	--在这里做适配操作
	return "Are you happy?"
end
 
Adapter = Target:new()    -- 适配器
 
function Adapter:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	o.adaptee = Adaptee:new()
	return o;
end
 
function Adapter:Listen(content)
	print(self.adaptee:Translate(content))
end
 
--小明说
c = "你幸福吗？"
aobama = Adapter:new()
--Tom实际听到的是
aobama:Listen(c)