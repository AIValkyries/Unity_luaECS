Visitor = {}
 
function Visitor:new(n,o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	self.name = n	
	return o;
end
 
ConcreteVisitor1 = Visitor:new()
 
function ConcreteVisitor1:VisitConcreteElementA(c)
	print(c.name.." 被 "..self.name.."访问")
end
 
function ConcreteVisitor1:VisitConcreteElementB(c)
	print(c.name.." 被 "..self.name.."访问")
end
 
ConcreteVisitor2 = Visitor:new()
 
function ConcreteVisitor2:VisitConcreteElementA(c)
	print(c.name.." 被 "..self.name.."访问")
end
 
function ConcreteVisitor2:VisitConcreteElementB(c)
	print(c.name.." 被 "..self.name.."访问")
end
 
Element = {}
 
function Element:new(n,o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	self.name = n	
	return o;
end
 
ConcreteElementA = Element:new()
 
function ConcreteElementA:Accept(v)
	v:VisitConcreteElementA(self)
end
 
ConcreteElementB = Element:new()
 
function ConcreteElementB:Accept(v)
	v:VisitConcreteElementB(self)
end
 
ObjectStructure = {}
 
function ObjectStructure:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self	
	o.elements = {}
	return o
end	
 
function ObjectStructure:Attach(e)
	table.insert(self.elements,e)
end
 
function ObjectStructure:Detach(e)
	for k, v in pairs(self.elements) do
		if v == theconcreteobserver then
			table.remove(self.elements,k)
			break
		end
	end
end
 
function ObjectStructure:Accept(v)
	for _,e in ipairs(self.elements) do
		e:Accept(v)
	end
end
obj = ObjectStructure:new()
obj:Attach(ConcreteElementA:new("XX博物馆"))
obj:Attach(ConcreteElementB:new("XX动物园"))
 
xiaoming = ConcreteVisitor1:new("小明")
xiaohong = ConcreteVisitor2:new("小红")
 
obj:Accept(xiaoming)
obj:Accept(xiaohong)