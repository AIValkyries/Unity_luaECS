# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: dataconfig_npcinfo.proto

from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='dataconfig_npcinfo.proto',
  package='dataconfig',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=b'\n\x18\x64\x61taconfig_npcinfo.proto\x12\ndataconfig\"D\n\x07NpcInfo\x12\n\n\x02Id\x18\x01 \x01(\r\x12\x0c\n\x04Name\x18\x02 \x01(\t\x12\x10\n\x08NpcTitle\x18\x03 \x01(\t\x12\r\n\x05ResId\x18\x04 \x01(\r\"2\n\x0cNpcInfoArray\x12\"\n\x05items\x18\x01 \x03(\x0b\x32\x13.dataconfig.NpcInfob\x06proto3'
)




_NPCINFO = _descriptor.Descriptor(
  name='NpcInfo',
  full_name='dataconfig.NpcInfo',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='Id', full_name='dataconfig.NpcInfo.Id', index=0,
      number=1, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='Name', full_name='dataconfig.NpcInfo.Name', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=b"".decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='NpcTitle', full_name='dataconfig.NpcInfo.NpcTitle', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=b"".decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='ResId', full_name='dataconfig.NpcInfo.ResId', index=3,
      number=4, type=13, cpp_type=3, label=1,
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
  serialized_start=40,
  serialized_end=108,
)


_NPCINFOARRAY = _descriptor.Descriptor(
  name='NpcInfoArray',
  full_name='dataconfig.NpcInfoArray',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='items', full_name='dataconfig.NpcInfoArray.items', index=0,
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
  serialized_start=110,
  serialized_end=160,
)

_NPCINFOARRAY.fields_by_name['items'].message_type = _NPCINFO
DESCRIPTOR.message_types_by_name['NpcInfo'] = _NPCINFO
DESCRIPTOR.message_types_by_name['NpcInfoArray'] = _NPCINFOARRAY
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

NpcInfo = _reflection.GeneratedProtocolMessageType('NpcInfo', (_message.Message,), {
  'DESCRIPTOR' : _NPCINFO,
  '__module__' : 'dataconfig_npcinfo_pb2'
  # @@protoc_insertion_point(class_scope:dataconfig.NpcInfo)
  })
_sym_db.RegisterMessage(NpcInfo)

NpcInfoArray = _reflection.GeneratedProtocolMessageType('NpcInfoArray', (_message.Message,), {
  'DESCRIPTOR' : _NPCINFOARRAY,
  '__module__' : 'dataconfig_npcinfo_pb2'
  # @@protoc_insertion_point(class_scope:dataconfig.NpcInfoArray)
  })
_sym_db.RegisterMessage(NpcInfoArray)


# @@protoc_insertion_point(module_scope)