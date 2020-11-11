
---职责链模式
require "Class"


Handler = 
{
	successor = nil
}

function Handler:SetSuccessor(s)
	self.successor = s
end

function Handler:HandleRequest(r)
end

ConcreteHandler1  = createClass(Handler)

function  ConcreteHandler1:HandleRequest(r)
	if r <= 10 then
		print("Handler1处理了请求")
	elseif self.successor then
		self.successor:HandleRequest(r)
	end
end

ConcreteHandler2 = createClass(Handler)

function  ConcreteHandler2:HandleRequest(r)
    if r > 10 and r <= 20 then
		print("Handler2处理了请求")
	elseif self.successor then
		self.successor:HandleRequest(r)
	end
end

ConcreteHandler3  = createClass(Handler)
function  ConcreteHandler3:HandleRequest(r)
if r > 20 then
		print("Handler3处理了请求")
	elseif self.successor then
		self.successor:HandleRequest(r)
	end

end

function test()
	
h1 = ConcreteHandler1:new()
h2 = ConcreteHandler2:new()
h3 = ConcreteHandler3:new()
 
h1:SetSuccessor(h2)
h2:SetSuccessor(h3)

print("*********************实例一***********************")
h1:HandleRequest(25)
h2:HandleRequest(5)
h3:HandleRequest(15)
 
print("*********************实例二***********************")
h1:HandleRequest(25)
h1:HandleRequest(5)
h1:HandleRequest(15)


end



