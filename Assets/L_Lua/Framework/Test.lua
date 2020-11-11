TestCompoent = require("Test.TestCompoent")
require("Test.cs_accelerate_pb") 
require("entitas")
require("LuaFsm");

local m = {}
m.__index = m
function m.compoentAdded( entity,comp_type )
    print(entity._creationIndex.."="..tostring(comp_type))
end

function m.compoentremoved( entity,comp_type )
     print(entity._creationIndex.."="..tostring(comp_type))
end

function m.compoentreplaced( entity,comp_type )
     print(entity._creationIndex.."="..tostring(comp_type))
end


function fsm_test()
     local aState = class("AState",BaseState)

     function aState:OnEnter( ... )
         print("进入a状态")
     end

     function aState:OnUpdate( ... )
          print("更新a状态")
     end

     function aState:OnLeave( ... )
         print("离开a状态")
     end

     ---------------------------------------------
     local bState = class("BState",BaseState)

     function bState:OnEnter( ... )
         print("进入B状态")
     end

     function bState:OnUpdate( ... )
          print("更新B状态")
     end

     function bState:OnLeave( ... )
         print("离开B状态")
     end

    ---------------------------------------------

     local cState = class("CState",BaseState)

     function cState:OnEnter( ... )
         print("进入C状态")
     end

     function cState:OnUpdate( ... )
          print("更新C状态")
     end

     function cState:OnLeave( ... )
         print("离开C状态")
     end

     local fsm = FsmMachine:New()

     fsm:AddState(aState)
     fsm:AddState(bState)
     fsm:AddState(cState)

     fsm:AddInitState(aState)

     fsm:ChangeState(bState)

end


function system_test()

    ------------StartGame-------------
    local StartGame = class("StartGame")
    function StartGame:ctor( context )
         self.context = context
    end

    function StartGame:Initialize()
       local entity = self.context:CreateEntity()
       entity:Add(Position)
       print("啊累累=Initialize");
    end

    ------------endSystem--------------
    local EndSystem = class("EndSystem")
    function EndSystem:ctor( context )
        self.context = context;
    end

    function EndSystem:TearDown()
        print("我曹=EndSystem tear_down")
    end

    -------------MoveSystem---------------
    local MoveSystem = class("MoveSystem")
    function MoveSystem:ctor(context)
         self.context = context;
    end

    function MoveSystem:Execute()
         print("麻痹=ReactiveSystem: add entity with component Movable.")
    end


    local context = Context:New();
    local systems = Systems:New()

    systems:Add(StartGame:New(context))
    --systems:Add(EndSystem:New(context))
    --systems:Add(MoveSystem:New(context))

    --systems:Initialize();
    --systems:Execute();
    --systems:TearDown();

end

--lua 生成一个Context
-- 组件对象
-- 单例实体
-- 生成组件和实体
function main( ... )

     fsm_test();
     --system_test();

    -- 创建实例
    -- 创建组 GameWorld
 
    --local entity0 = testContext:CreateEntity()
   
    --entity0:Add(Position)
    --entity0:Add(Move)
    --entity0:Add(Roles)
    --entity0:Add(Weapon)
    --entity0:Add(Pet)
    --entity0:Add(Partner)
    --entity0:Add(AccelerateWarnNotify)

    --print(tostring(entity0))

    --print("组件数量="..entity0:Size())

   -- local entity1 = testContext:CreateEntity()

    --entity1:Add(Position)
    --entity1:Add(Move)
    --entity1:Add(Roles)
    --entity1:Add(Weapon)
    --entity1:Add(Pet)
    --entity1:Add(Partner)

    --local entity2 = testContext:CreateEntity()

    --entity2:Add(Position)
    --entity2:Add(Move)
   -- entity2:Add(Roles)
    --entity2:Add(Weapon)
    --entity2:Add(Pet)
    --entity2:Add(Partner)

    --local group = testContext:GetGroup(Matcher({Position,Weapon}));
    --print(tostring(group))
   

    --local entity3 = testContext:CreateSilentlyEntity(Matcher({Position,Weapon}));
    --print(tostring(entity3))
    --print(tostring(testContext))

    --print(tostring(entity1))


    --testContext:DestroyAllEntity()

    --print(tostring(entity1))

    --local pos = entity0:Get(Position)
    --pos.X = 100
    --print("组件之一=="..pos.X)

    --entity0:Replace(Position,Position())
    --local pos1 = entity0:Get(Position)
   -- print("组件替换=="..pos1.X)

    --entity0:Remove(Position)


    


end

