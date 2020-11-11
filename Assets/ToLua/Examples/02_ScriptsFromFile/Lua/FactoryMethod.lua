-- 工厂方法设计模式 计算器
require "Class"

Operation  = 
{
	NumberA=10,
	NumberB=5,
}

function Operation:GetResult()
	return NumberA,NumberB
end

OperationAdd = createClass(Operation)

function OperationAdd:GetResult()
	if self.NumberA and self.NumberB then
		local value = self.NumberA+self.NumberB;
		return "Add="..value;
	end
	return "Add=0";
end

OperationSub = createClass(Operation)

function OperationSub:GetResult()
	if self.NumberA and self.NumberB then
		local value = self.NumberA-self.NumberB;
		return "Sub="..value;
	end
	return "Sub=0"
end


OperationMul = createClass(Operation)
function OperationMul:GetResult()
	if self.NumberA and self.NumberB then
		local value = self.NumberA*self.NumberB;
		return "Mul="..value;
	end
	return "Mul=0"
end

OperationDiv = createClass(Operation)

function OperationDiv:GetResult()
	if self.NumberA and self.NumberB then
		local value = self.NumberA / self.NumberB;
		return "Div="..value;
	end
	return "Div=0"
end


OperationFactory = {}
function OperationFactory:CreateOperation()
	return nil
end

OperationFactoryAdd = createClass(OperationFactory)
function  OperationFactoryAdd:CreateOperation()
	return OperationAdd:new()
end

OperationFactorySub = createClass(OperationFactory)
function  OperationFactorySub:CreateOperation()
	return OperationSub:new()
end

OperationFactoryMul = createClass(OperationFactory)
function  OperationFactoryMul:CreateOperation()
	return OperationMul:new()
end

OperationFactoryDiv = createClass(OperationFactory)
function  OperationFactoryDiv:CreateOperation()
	return OperationDiv:new()
end

function CreateFactory()
	operadd = OperationFactoryAdd:CreateOperation()
	print(operadd:GetResult())

	opersub = OperationFactorySub:CreateOperation()
    print(opersub:GetResult())

    operMul = OperationFactoryMul:CreateOperation()
    print(operMul:GetResult())

    operDiv = OperationFactoryDiv:CreateOperation()
    print(operDiv:GetResult())

end