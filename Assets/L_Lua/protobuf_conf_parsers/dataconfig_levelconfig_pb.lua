-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf/protobuf"


local LEVELCONFIG = protobuf.Descriptor();
local LEVELCONFIG_ID_FIELD = protobuf.FieldDescriptor();
local LEVELCONFIG_NAME_FIELD = protobuf.FieldDescriptor();
local LEVELCONFIG_LEVELRESID_FIELD = protobuf.FieldDescriptor();
local LEVELCONFIGARRAY = protobuf.Descriptor();
local LEVELCONFIGARRAY_ITEMS_FIELD = protobuf.FieldDescriptor();

LEVELCONFIG_ID_FIELD.name = "ID"
LEVELCONFIG_ID_FIELD.full_name = ".dataconfig.LevelConfig.ID"
LEVELCONFIG_ID_FIELD.number = 1
LEVELCONFIG_ID_FIELD.index = 0
LEVELCONFIG_ID_FIELD.label = 1
LEVELCONFIG_ID_FIELD.has_default_value = false
LEVELCONFIG_ID_FIELD.default_value = 0
LEVELCONFIG_ID_FIELD.type = 13
LEVELCONFIG_ID_FIELD.cpp_type = 3

LEVELCONFIG_NAME_FIELD.name = "Name"
LEVELCONFIG_NAME_FIELD.full_name = ".dataconfig.LevelConfig.Name"
LEVELCONFIG_NAME_FIELD.number = 2
LEVELCONFIG_NAME_FIELD.index = 1
LEVELCONFIG_NAME_FIELD.label = 1
LEVELCONFIG_NAME_FIELD.has_default_value = false
LEVELCONFIG_NAME_FIELD.default_value = ""
LEVELCONFIG_NAME_FIELD.type = 9
LEVELCONFIG_NAME_FIELD.cpp_type = 9

LEVELCONFIG_LEVELRESID_FIELD.name = "LevelResID"
LEVELCONFIG_LEVELRESID_FIELD.full_name = ".dataconfig.LevelConfig.LevelResID"
LEVELCONFIG_LEVELRESID_FIELD.number = 3
LEVELCONFIG_LEVELRESID_FIELD.index = 2
LEVELCONFIG_LEVELRESID_FIELD.label = 1
LEVELCONFIG_LEVELRESID_FIELD.has_default_value = false
LEVELCONFIG_LEVELRESID_FIELD.default_value = 0
LEVELCONFIG_LEVELRESID_FIELD.type = 13
LEVELCONFIG_LEVELRESID_FIELD.cpp_type = 3

LEVELCONFIG.name = "LevelConfig"
LEVELCONFIG.full_name = ".dataconfig.LevelConfig"
LEVELCONFIG.nested_types = {}
LEVELCONFIG.enum_types = {}
LEVELCONFIG.fields = {LEVELCONFIG_ID_FIELD, LEVELCONFIG_NAME_FIELD, LEVELCONFIG_LEVELRESID_FIELD}
LEVELCONFIG.is_extendable = false
LEVELCONFIG.extensions = {}
LEVELCONFIGARRAY_ITEMS_FIELD.name = "items"
LEVELCONFIGARRAY_ITEMS_FIELD.full_name = ".dataconfig.LevelConfigArray.items"
LEVELCONFIGARRAY_ITEMS_FIELD.number = 1
LEVELCONFIGARRAY_ITEMS_FIELD.index = 0
LEVELCONFIGARRAY_ITEMS_FIELD.label = 3
LEVELCONFIGARRAY_ITEMS_FIELD.has_default_value = false
LEVELCONFIGARRAY_ITEMS_FIELD.default_value = {}
LEVELCONFIGARRAY_ITEMS_FIELD.message_type = LEVELCONFIG
LEVELCONFIGARRAY_ITEMS_FIELD.type = 11
LEVELCONFIGARRAY_ITEMS_FIELD.cpp_type = 10

LEVELCONFIGARRAY.name = "LevelConfigArray"
LEVELCONFIGARRAY.full_name = ".dataconfig.LevelConfigArray"
LEVELCONFIGARRAY.nested_types = {}
LEVELCONFIGARRAY.enum_types = {}
LEVELCONFIGARRAY.fields = {LEVELCONFIGARRAY_ITEMS_FIELD}
LEVELCONFIGARRAY.is_extendable = false
LEVELCONFIGARRAY.extensions = {}

LevelConfig = protobuf.Message(LEVELCONFIG)
LevelConfigArray = protobuf.Message(LEVELCONFIGARRAY)
