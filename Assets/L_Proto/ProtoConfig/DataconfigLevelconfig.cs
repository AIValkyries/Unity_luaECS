// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: dataconfig_levelconfig.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dataconfig {

  /// <summary>Holder for reflection information generated from dataconfig_levelconfig.proto</summary>
  public static partial class DataconfigLevelconfigReflection {

    #region Descriptor
    /// <summary>File descriptor for dataconfig_levelconfig.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataconfigLevelconfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChxkYXRhY29uZmlnX2xldmVsY29uZmlnLnByb3RvEgpkYXRhY29uZmlnIjsK",
            "C0xldmVsQ29uZmlnEgoKAklEGAEgASgNEgwKBE5hbWUYAiABKAkSEgoKTGV2",
            "ZWxSZXNJRBgDIAEoDSI6ChBMZXZlbENvbmZpZ0FycmF5EiYKBWl0ZW1zGAEg",
            "AygLMhcuZGF0YWNvbmZpZy5MZXZlbENvbmZpZ2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.LevelConfig), global::Dataconfig.LevelConfig.Parser, new[]{ "ID", "Name", "LevelResID" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.LevelConfigArray), global::Dataconfig.LevelConfigArray.Parser, new[]{ "Items" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class LevelConfig : pb::IMessage<LevelConfig>,IComponent {
    private static readonly pb::MessageParser<LevelConfig> _parser = new pb::MessageParser<LevelConfig>(() => new LevelConfig());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LevelConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigLevelconfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig(LevelConfig other) : this() {
      iD_ = other.iD_;
      name_ = other.name_;
      levelResID_ = other.levelResID_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfig Clone() {
      return new LevelConfig(this);
    }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private uint iD_;
    /// <summary>
    ///* 关卡ID 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ID {
      get { return iD_; }
      set {
        iD_ = value;
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

    /// <summary>Field number for the "LevelResID" field.</summary>
    public const int LevelResIDFieldNumber = 3;
    private uint levelResID_;
    /// <summary>
    ///* 动态配置文件，在资源表中 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint LevelResID {
      get { return levelResID_; }
      set {
        levelResID_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LevelConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LevelConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ID != other.ID) return false;
      if (Name != other.Name) return false;
      if (LevelResID != other.LevelResID) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ID != 0) hash ^= ID.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (LevelResID != 0) hash ^= LevelResID.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ID != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(ID);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (LevelResID != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(LevelResID);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ID);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (LevelResID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LevelResID);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LevelConfig other) {
      if (other == null) {
        return;
      }
      if (other.ID != 0) {
        ID = other.ID;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.LevelResID != 0) {
        LevelResID = other.LevelResID;
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
            ID = input.ReadUInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            LevelResID = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LevelConfigArray : pb::IMessage<LevelConfigArray>,IComponent {
    private static readonly pb::MessageParser<LevelConfigArray> _parser = new pb::MessageParser<LevelConfigArray>(() => new LevelConfigArray());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LevelConfigArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigLevelconfigReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfigArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfigArray(LevelConfigArray other) : this() {
      items_ = other.items_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LevelConfigArray Clone() {
      return new LevelConfigArray(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Dataconfig.LevelConfig> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::Dataconfig.LevelConfig.Parser);
    private readonly pbc::RepeatedField<global::Dataconfig.LevelConfig> items_ = new pbc::RepeatedField<global::Dataconfig.LevelConfig>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Dataconfig.LevelConfig> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LevelConfigArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LevelConfigArray other) {
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
    public void MergeFrom(LevelConfigArray other) {
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
