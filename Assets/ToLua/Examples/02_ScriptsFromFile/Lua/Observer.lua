-- 观察者模式


Subject = {}
 
function Subject:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end
 
ConcreteSubject = Subject:new()
 
function ConcreteSubject:Attach(theconcreteobserver)
	if self.observers == nil then
		self.observers = {}
	end
	table.insert(self.observers,theconcreteobserver)
end
 
function ConcreteSubject:Detach(theconcreteobserver)
	for k, v in pairs(self.observers) do
		if v == theconcreteobserver then
			table.remove(self.observers,k)
			break
		end
	end
end
 
function ConcreteSubject:Notify()
	for _, v in pairs(self.observers) do
		v:Update()
	end
end


Observer = {}
 
function Observer:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end
 
ConcreteObserver = Observer:new()
 
function ConcreteObserver:new(s,n)
	o = {}
	setmetatable(o,self)
	self.__index = self
	o.subject = s
	o.observername = n
	return o
end
 
function ConcreteObserver:Update()
	print("陈冠稀大喊："..self.observername.."!!"..self.subject.subjectstate)
end
 
s = ConcreteSubject:new()
 
s:Attach(ConcreteObserver:new(s,"张伯芝"))
zhongxintong = ConcreteObserver:new(s,"钟欣同")
chenwenyuan  = ConcreteObserver:new(s,"陈文援")
s:Attach(zhongxintong)
s:Attach(chenwenyuan)
s.subjectstate = "谢霆疯来了,快躲起来!!"
s:Notify()
 
s:Detach(zhongxintong)
s:Detach(chenwenyuan)
s.subjectstate = "谢霆疯走了,快回家!!"
s:Notify()
 
 
