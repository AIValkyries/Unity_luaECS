--- 抽象工厂设计模式
--- 思想:对何种事物进行抽象创建，被创建事物的总体形态，重点要创建的对象是什么，而不是抽象工厂的结构
--- 例如汽车:普通轿车，跑车，大卡车
--- 汽车部位的抽象：轮胎，外壳，引擎

require "Class"

TiresBase  = {Name=""}
ShellBase  = {Name =""}
EngineBase = {Name = ""}
CarBase = 
{
	Tires = nil,    --轮胎
	Shell = nil,    --外壳
	Engine = nil,   --引擎
}

function  CarBase:SetTires(tires)
	self.Tires = tires
end

function  CarBase:SetShell(shell)
	self.Shell = shell
end

function  CarBase:SetEngine(engine)
	self.Engine = engine
end


OrdinaryTires = createClass(TiresBase)
OrdinaryTires.Name = "我是普通轮胎"
SuperTires = createClass(TiresBase)
SuperTires.Name = "我是超级轮胎"
UltimateTires = createClass(TiresBase)
UltimateTires.Name = "哈哈我是究极轮胎"

AltoShell = createClass(ShellBase)
AltoShell.Name="我是奥拓的外壳"
BenzShell = createClass(ShellBase)
BenzShell.Name = "我是奔驰的外壳"
LamborghiniShell = createClass(ShellBase)
LamborghiniShell.Name = "我是兰博基尼的外壳，漂亮吧，哈哈"


CheryEngine = createClass(EngineBase)
CheryEngine.Name = "奇瑞引擎，我曹，你看不起国产???"
B48Engine = createClass(EngineBase)
B48Engine.Name = "不错哦，宝马引擎"
BestEngine = createClass(EngineBase)
BestEngine.Name = "最好的引擎，但是我不知道叫啥!"

CarFactory = {}

function CarFactory:MakeCar()
	return new(CarBase);
end

function CarFactory:MakeTires()
end

function CarFactory:MakeShell()
end

function CarFactory:MakeEngine()
end

RubbishCarFactory = createClass(CarFactory)   -- 垃圾车

function RubbishCarFactory:MakeTires()
	return OrdinaryTires:new()
end

function RubbishCarFactory:MakeShell()
	return AltoShell:new()
end

function RubbishCarFactory:MakeEngine()
	return CheryEngine:new()
end 

SosoCarFactory = createClass(CarFactory)  -- 普通的车

function SosoCarFactory:MakeTires()
	return SuperTires:new()
end

function SosoCarFactory:MakeShell()
	return BenzShell:new()
end

function SosoCarFactory:MakeEngine()
	return B48Engine:new()
end 

LikeCarFactory = createClass(CarFactory)  -- 喜欢的车
function LikeCarFactory:MakeTires()
	return UltimateTires:new()
end

function LikeCarFactory:MakeShell()
	return LamborghiniShell:new()
end

function LikeCarFactory:MakeEngine()
	return BestEngine:new()
end 


function CreateCar(carFactory)
	local car = carFactory:MakeCar()
	local tires = carFactory:MakeTires();
	local shell = carFactory:MakeShell();
	local engine = carFactory:MakeEngine();

	car:SetTires(tires)
	car:SetShell(shell)
	car:SetEngine(engine)

	return car;
end


function ext()

   local  car1 = CreateCar(RubbishCarFactory);
   local  car2 = CreateCar(SosoCarFactory);
   local  car3 = CreateCar(LikeCarFactory);

   print("垃圾车="..car1.Tires.Name)
   print("垃圾车="..car1.Shell.Name)
   print("垃圾车="..car1.Engine.Name)
   print("----------------------------------------------------")

   print("普通的车="..car2.Tires.Name)
   print("普通的车="..car2.Shell.Name)
   print("普通的车="..car2.Engine.Name)
   print("----------------------------------------------------")


   print("喜欢的车="..car3.Tires.Name)
   print("喜欢的车="..car3.Shell.Name)
   print("喜欢的车="..car3.Engine.Name)


end