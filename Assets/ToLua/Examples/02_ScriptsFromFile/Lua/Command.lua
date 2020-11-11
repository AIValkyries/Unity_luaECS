
-- 命令模式

require "Class"

Command = 
{
	receiver = nil
}

function  Command:Execute()
	
end

ConcreteCommand1 = createClass(Command)

function  ConcreteCommand1:Execute()
	self.receiver.Action1()
end

ConcreteCommand2  = createClass(Command)
function  ConcreteCommand2:Execute()
	self.receiver:Action2()
end


Receiver =  {}
function Receiver:Action1()
	print("来一条清蒸鱼")
end
 
function Receiver:Action2()
	print("来一个蛋糕")
end



Invoker = {}
function Invoker:SetCommand(c)
	table.insert(self.allcommand,c)
end

function Invoker:ExecuteCommand()
	for _,v in pairs(self.allcommand) do
		v:Execute()
	end
end

function  test()
   chef = Receiver:new()
   fish = ConcreteCommand1:new(chef)
   cake = ConcreteCommand2:new(chef)

   waiter = Invoker:new()
   waiter:SetCommand(fish)
   waiter:SetCommand(cake)

   waiter:ExecuteCommand()

end