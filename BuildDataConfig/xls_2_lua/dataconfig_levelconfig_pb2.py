# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: dataconfig_levelconfig.proto

from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='dataconfig_levelconfig.proto',
  package='dataconfig',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=b'\n\x1c\x64\x61taconfig_levelconfig.proto\x12\ndataconfig\";\n\x0bLevelConfig\x12\n\n\x02ID\x18\x01 \x01(\r\x12\x0c\n\x04Name\x18\x02 \x01(\t\x12\x12\n\nLevelResID\x18\x03 \x01(\r\":\n\x10LevelConfigArray\x12&\n\x05items\x18\x01 \x03(\x0b\x32\x17.dataconfig.LevelConfigb\x06proto3'
)




_LEVELCONFIG = _descriptor.Descriptor(
  name='LevelConfig',
  full_name='dataconfig.LevelConfig',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='ID', full_name='dataconfig.LevelConfig.ID', index=0,
      number=1, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='Name', full_name='dataconfig.LevelConfig.Name', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=b"".decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='LevelResID', full_name='dataconfig.LevelConfig.LevelResID', index=2,
      number=3, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=44,
  serialized_end=103,
)


_LEVELCONFIGARRAY = _descriptor.Descriptor(
  name='LevelConfigArray',
  full_name='dataconfig.LevelConfigArray',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='items', full_name='dataconfig.LevelConfigArray.items', index=0,
      number=1, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=105,
  serialized_end=163,
)

_LEVELCONFIGARRAY.fields_by_name['items'].message_type = _LEVELCONFIG
DESCRIPTOR.message_types_by_name['LevelConfig'] = _LEVELCONFIG
DESCRIPTOR.message_types_by_name['LevelConfigArray'] = _LEVELCONFIGARRAY
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

LevelConfig = _reflection.GeneratedProtocolMessageType('LevelConfig', (_message.Message,), {
  'DESCRIPTOR' : _LEVELCONFIG,
  '__module__' : 'dataconfig_levelconfig_pb2'
  # @@protoc_insertion_point(class_scope:dataconfig.LevelConfig)
  })
_sym_db.RegisterMessage(LevelConfig)

LevelConfigArray = _reflection.GeneratedProtocolMessageType('LevelConfigArray', (_message.Message,), {
  'DESCRIPTOR' : _LEVELCONFIGARRAY,
  '__module__' : 'dataconfig_levelconfig_pb2'
  # @@protoc_insertion_point(class_scope:dataconfig.LevelConfigArray)
  })
_sym_db.RegisterMessage(LevelConfigArray)


# @@protoc_insertion_point(module_scope)
