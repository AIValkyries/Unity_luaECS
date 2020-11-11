
-- PreModuleID = int
   -- /// <summary>
   -- /// 这是个常量，要在程序运行前注册
   -- /// Key:模块ID
   -- /// Value:模块类型
   -- /// </summary>
-- ModuleMap = Dictionary<int, Type>

   -- /// <summary>
   -- /// 临时存储，方便卸载模块
   -- /// Key:模块ID
   -- /// Value:具体模块
   -- /// </summary>
-- MountedModules = Dictionary<int, ModuleBaseSystems>
ModuleManagerComponent = MakeComponent("ModuleManagerCompoent","PreModuleID","ModuleMap","MountedModules")