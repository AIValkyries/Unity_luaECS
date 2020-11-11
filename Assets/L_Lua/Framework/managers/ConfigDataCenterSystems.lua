

local M = class("ConfigDataCenterSystems",Systems:New());

ConfigDataContext = Context:New();
local SilentlyEntity = ConfigDataContext:CreateEntity()

local p = "protobuf_conf_parsers."
local pre = p.."dataconfig_";
local dp = "dataconfig_"
local pdt = {}

local configInitFuncDict = 
{
	[dp.."levelconfig"] = function ()
	   require(pre.."levelconfig_pb")
	   pdt[dp.."levelconfig"] = LevelConfigArray
	end,
};


--[[--
 * @Description:
 * @param:       configName config 对应的 Bytes文件名
 * @return:     
 ]]
function M:LoadConfig( configName )
	configInitFuncDict[configName]();
	local protoBufConfig = pdt[configName];

	local component = SilentlyEntity:GetByName(protoBufConfig._name)
	if component then
		return component;
	end

	protoBufConfig = SilentlyEntity:Add(protoBufConfig)
	-- 从cs中加载文件
	local byteData = ProtobufDataConfigSystems.ReadDataConfigForLua(configName);
	protoBufConfig:ParseFromString(byteData)

	return protoBufConfig
end

--[[--
 * @Description: 卸载Config 包括 require
 * @param: 文件名称
 ]]
function M:UninstallConfig( configName )
	configInitFuncDict[configName]();
	local protoBufConfig = pdt[configName];
	local component = SilentlyEntity:GetByName(protoBufConfig._name)

	if component then
		SilentlyEntity:Remove(component)
	end
	-- 卸载 require  protobuf_conf_parsers.dataconfig_levelconfig_pb
	local moduleName = p..configName.."_pb"
    for key, _ in pairs(package.loaded) do
    	 if string.find(tostring(key), moduleName) == 1 then
    	 	print(moduleName.."=被卸载了!!")
    	 	 package.loaded[key] = nil
    	 end
    end
   
end

resultValue = nil
dataValue = nil

--[[--
 * @Description: 根据ID去得到指定的信息
 * @param:       configName config对应的Bytes文件名
                 IDName     ID字段对应的列名字
                 ID         传入的ID值
 ]]
function M:GetConfigDataByID(configName,IDName,ID)
	 local configDataArray = self:LoadConfig(configName)

	 local items = nil

	 for k, v in pairs(configDataArray) do
	 	if k == "_fields" then
	 		items = v;
	 		break;
	 	end	
	 end

	 if not items then
	 	return nil
	 end

	 for k,v in pairs(items) do
	 	for h,l in pairs(v) do
	 		dataValue = l
	 		local m = loadstring("resultValue = dataValue."..IDName)
	 		m();
	 		if resultValue == ID then
	 			return l
	 		end
	 	end
	 end
	
end













return M;