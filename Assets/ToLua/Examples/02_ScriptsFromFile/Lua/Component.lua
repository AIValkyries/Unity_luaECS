Component = {}
 
function Component:new(name)
	o = {}
	setmetatable(o,self)
	self.__index = self
	o.name = name
	return o;
end
 
Composite = Component:new()
 
function Composite:new(name)
	o = {}
	setmetatable(o,self)
	self.__index = self
	o.children = {}
	o.name = name
	return o;
end
 
function Composite:Add(c)
	table.insert(self.children,c)
end
 
function Composite:Remove(c)
	for k,v in pairs(self.children) do
		if v == c then
			table.remove(self.children,k)
		end
	end
end
 
function Composite:Fuck()
	--print(self.name)
	for _,v in pairs(self.children) do
		v:Fuck()
	end
end
function Composite:Announce()
	print(self.name)
	for _,v in pairs(self.children) do
		v:Announce()
	end
end
Leaf = Component:new()
 
function Leaf:new(name)
	o = {}
	setmetatable(o,self)
	self.__index = self
	o.name = name
	return o;
end
 
function Leaf:Fuck()
	print("法克油,"..self.name)
end
 
function Leaf:Announce()
	print(self.name..",今天是我们一头汗集团正式进军海外的第一天，希望大家更加用心工作")
end
--************************** 实例一 ***************************
chenguanxi = Composite:new("陈冠稀")
first = Composite:new("第一批曝光")
first:Add(Leaf:new("张伯芝"))
first:Add(Leaf:new("钟欣同"))
chenguanxi:Add(first)
 
second = Composite:new("第二批曝光")
second:Add(Leaf:new("陈文援"))
chenguanxi:Add(second)
chenguanxi:Fuck()
 
--************************** 实例二 ***************************
yitouhan = Composite:new("一头汗集团广州总部")
yitouhan:Add(Leaf:new("人力资源部"))
yitouhan:Add(Leaf:new("程序部"))
yitouhan:Add(Leaf:new("运营部"))
yitouhan:Add(Leaf:new("运维部"))
 
shenzhen = Composite:new("一头汗集团深圳分部")
shenzhen:Add(Leaf:new("人力资源部"))
shenzhen:Add(Leaf:new("程序部"))
shenzhen:Add(Leaf:new("港澳台合作部"))
 
beijing  = Composite:new("一头汗集团北京分部")
beijing:Add(Leaf:new("人力资源部"))
beijing:Add(Leaf:new("程序部"))
 
shanghai = Composite:new("一头汗集团上海分部")
shanghai:Add(Leaf:new("人力资源部"))
shanghai:Add(Leaf:new("程序部"))
 
yitouhan:Add(shenzhen)
yitouhan:Add(beijing)
yitouhan:Add(shanghai)
 
yitouhan:Announce()