
GiveGift = {girlname = nil}
 
function GiveGift:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o;
end
 
Pursuit = GiveGift:new()
 
function Pursuit:new(o,name)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	o.girlname = name
	return o;
end
 
function Pursuit:GiveDolls()
	if self.girlname ~= nil then
		print("送"..self.girlname.."洋娃娃")
	end
end
function Pursuit:GiveFlowers()
	if self.girlname ~= nil then
		print("送"..self.girlname.."玫瑰花")
	end
end
function Pursuit:GiveChocolate()
	if self.girlname ~= nil then
		print("送"..self.girlname.."巧克力")
	end
end
Proxy = GiveGift:new()
 
function Proxy:new(o,name)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	o.pursuit = Pursuit:new({},name)
	return o;
end
 
function Proxy:GiveDolls()
	self.pursuit:GiveDolls()
end
 
function Proxy:GiveFlowers()
	self.pursuit:GiveFlowers()
end
 
function Proxy:GiveChocolate()
	self.pursuit:GiveChocolate()
end
 
XieTingFeng = Proxy:new({},"张伯芝")
 
XieTingFeng:GiveDolls()
 
XieTingFeng:GiveFlowers()
 
XieTingFeng:GiveChocolate()