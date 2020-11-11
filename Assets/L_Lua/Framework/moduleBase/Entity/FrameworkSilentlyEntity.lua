
require("Framework.moduleBase.Entity.FrameworkContexts")
require("Framework.moduleBase.Component.UIManagerComponent");
require("Framework.moduleBase.Component.ModuleManagerComponent");

UIManagerCompoentEntity = ModuleBaseContext:CreateSilentlyEntity(Matcher({UIManagerComponent}))
ModuleManagerEntity     =  ModuleManagerContext:CreateSilentlyEntity(Matcher({ModuleManagerComponent}))
