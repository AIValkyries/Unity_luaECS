// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: dataconfig_npcinfo.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dataconfig {

  /// <summary>Holder for reflection information generated from dataconfig_npcinfo.proto</summary>
  public static partial class DataconfigNpcinfoReflection {

    #region Descriptor
    /// <summary>File descriptor for dataconfig_npcinfo.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataconfigNpcinfoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhkYXRhY29uZmlnX25wY2luZm8ucHJvdG8SCmRhdGFjb25maWciRAoHTnBj",
            "SW5mbxIKCgJJZBgBIAEoDRIMCgROYW1lGAIgASgJEhAKCE5wY1RpdGxlGAMg",
            "ASgJEg0KBVJlc0lkGAQgASgNIjIKDE5wY0luZm9BcnJheRIiCgVpdGVtcxgB",
            "IAMoCzITLmRhdGFjb25maWcuTnBjSW5mb2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.NpcInfo), global::Dataconfig.NpcInfo.Parser, new[]{ "Id", "Name", "NpcTitle", "ResId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.NpcInfoArray), global::Dataconfig.NpcInfoArray.Parser, new[]{ "Items" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class NpcInfo : pb::IMessage<NpcInfo>,IComponent {
    private static readonly pb::MessageParser<NpcInfo> _parser = new pb::MessageParser<NpcInfo>(() => new NpcInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NpcInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigNpcinfoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NpcInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NpcInfo(NpcInfo other) : this() {
      id_ = other.id_;
      name_ = other.name_;
      npcTitle_ = other.npcTitle_;
      resId_ = other.resId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NpcInfo Clone() {
      return new NpcInfo(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private uint id_;
    /// <summary>
    ///* NPCID 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    /// <summary>
    ///* 名字 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "NpcTitle" field.</summary>
    public const int NpcTitleFieldNumber = 3;
    private string npcTitle_ = "";
    /// <summary>
    ///* 称号 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string NpcTitle {
      get { return npcTitle_; }
      set {
        npcTitle_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ResId" field.</summary>
    public const int ResIdFieldNumber = 4;
    private uint resId_;
    /// <summary>
    ///* 对应的资源ID 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ResId {
      get { return resId_; }
      set {
        resId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NpcInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NpcInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Name != other.Name) return false;
      if (NpcTitle != other.NpcTitle) return false;
      if (ResId != other.ResId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (NpcTitle.Length != 0) hash ^= NpcTitle.GetHashCode();
      if (ResId != 0) hash ^= ResId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(Id);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (NpcTitle.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(NpcTitle);
      }
      if (ResId != 0) {
        output.WriteRawTag(32);
        output.WriteUInt32(ResId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (NpcTitle.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(NpcTitle);
      }
      if (ResId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ResId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NpcInfo other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.NpcTitle.Length != 0) {
        NpcTitle = other.NpcTitle;
      }
      if (other.ResId != 0) {
        ResId = other.ResId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Id = input.ReadUInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            NpcTitle = input.ReadString();
            break;
          }
          case 32: {
            ResId = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class NpcInfoArray : pb::IMessage<NpcInfoArray>,IComponent {
    private static readonly pb::MessageParser<NpcInfoArray> _parser = new pb::MessageParser<NpcInfoArray>(() => new NpcInfoArray());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NpcInfoArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigNpcinfoReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NpcInfoArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NpcInfoArray(NpcInfoArray other) : this() {
      items_ = other.items_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NpcInfoArray Clone() {
      return new NpcInfoArray(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Dataconfig.NpcInfo> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::Dataconfig.NpcInfo.Parser);
    private readonly pbc::RepeatedField<global::Dataconfig.NpcInfo> items_ = new pbc::RepeatedField<global::Dataconfig.NpcInfo>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Dataconfig.NpcInfo> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NpcInfoArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NpcInfoArray other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!items_.Equals(other.items_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= items_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      items_.WriteTo(output, _repeated_items_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += items_.CalculateSize(_repeated_items_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NpcInfoArray other) {
      if (other == null) {
        return;
      }
      items_.Add(other.items_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            items_.AddEntriesFrom(input, _repeated_items_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
