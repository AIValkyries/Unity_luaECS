-- 中介者模式
require "Class"

Mediator = {}

function Mediator:Send(c,message)
	for _,v in pairs(self.colleagues) do
		if v ~= c then
			v:GetMessage(message)
		end
	end
end


Colleague = {}

function Colleague:Send(message)
	print(self.name.."说:"..message)
	self.mediator:Send(self,message)
end


function Colleague:GetMessage(message)
	print(self.name.."收到："..message)
end



China = Colleague:new()
 
America = Colleague:new()
 
Russia = Colleague:new()
 
Japan = Colleague:new()
 
SouthKorea = Colleague:new()
 
NorthKorea = Colleague:new()



function  test()
	liufang = ConcreteMediator:new()
 
xijinping = China:new("习近萍",liufang)
 
aobama = America:new("奥爸妈",liufang)
 
pujing = Russia:new("普惊",liufang)
 
anbeijinsan = Japan:new("俺被进三",liufang)
 
piaojinhui = SouthKorea:new("扑僅慧",liufang)
 
jinzhengen = NorthKorea:new("金正嗯",liufang)
 
 
table.insert(liufang.colleagues,xijinping)
 
table.insert(liufang.colleagues,aobama)
 
table.insert(liufang.colleagues,pujing)
 
table.insert(liufang.colleagues,anbeijinsan)
 
table.insert(liufang.colleagues,piaojinhui)
 
table.insert(liufang.colleagues,jinzhengen)
 
xijinping:Send("为了地区安全，我方支持半岛无核化")
print("")
jinzhengen:Send("如果我们放弃核武，我们就会被欺负")
print("")
aobama:Send("如果朝鲜继续发展核武，我国不排除武力去核")
end

