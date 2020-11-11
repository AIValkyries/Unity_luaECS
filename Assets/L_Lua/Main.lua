require("Global");
--require("protocol_generated.cs_enum_pb");
require("protobuf_conf_parsers.dataconfig_levelconfig_pb")

LuaGameWorld = require("Logic.LuaGameWorld");

function main( ... )

	--print("LuaMain");
	LuaGameWorld  = LuaGameWorld:New()
	LuaGameWorld:Initialize()

	local protoBufConfig =  ConfigDataCenterSystems:GetConfigDataByID("dataconfig_levelconfig","ID",10001)
	protoBufConfig =  ConfigDataCenterSystems:GetConfigDataByID("dataconfig_levelconfig","ID",10001)
	print(tostring(protoBufConfig))

	ConfigDataCenterSystems:UninstallConfig("dataconfig_levelconfig")
	protoBufConfig =  ConfigDataCenterSystems:GetConfigDataByID("dataconfig_levelconfig","ID",10001)
	print(tostring(protoBufConfig))

end