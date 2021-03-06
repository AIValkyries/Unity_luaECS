// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: dataconfig_monsterfenbao.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dataconfig {

  /// <summary>Holder for reflection information generated from dataconfig_monsterfenbao.proto</summary>
  public static partial class DataconfigMonsterfenbaoReflection {

    #region Descriptor
    /// <summary>File descriptor for dataconfig_monsterfenbao.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataconfigMonsterfenbaoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch5kYXRhY29uZmlnX21vbnN0ZXJmZW5iYW8ucHJvdG8SCmRhdGFjb25maWci",
            "PwoNTW9uc3RlckZlbkJhbxINCgVSZXNJRBgBIAEoDRIOCgZQYWthZ2UYAiAB",
            "KA0SDwoHVmVyc2lvbhgDIAEoDSI+ChJNb25zdGVyRmVuQmFvQXJyYXkSKAoF",
            "aXRlbXMYASADKAsyGS5kYXRhY29uZmlnLk1vbnN0ZXJGZW5CYW9iBnByb3Rv",
            "Mw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.MonsterFenBao), global::Dataconfig.MonsterFenBao.Parser, new[]{ "ResID", "Pakage", "Version" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.MonsterFenBaoArray), global::Dataconfig.MonsterFenBaoArray.Parser, new[]{ "Items" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class MonsterFenBao : pb::IMessage<MonsterFenBao>,IComponent {
    private static readonly pb::MessageParser<MonsterFenBao> _parser = new pb::MessageParser<MonsterFenBao>(() => new MonsterFenBao());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MonsterFenBao> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigMonsterfenbaoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MonsterFenBao() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MonsterFenBao(MonsterFenBao other) : this() {
      resID_ = other.resID_;
      pakage_ = other.pakage_;
      version_ = other.version_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MonsterFenBao Clone() {
      return new MonsterFenBao(this);
    }

    /// <summary>Field number for the "ResID" field.</summary>
    public const int ResIDFieldNumber = 1;
    private uint resID_;
    /// <summary>
    ///* 资源ID 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint ResID {
      get { return resID_; }
      set {
        resID_ = value;
      }
    }

    /// <summary>Field number for the "Pakage" field.</summary>
    public const int PakageFieldNumber = 2;
    private uint pakage_;
    /// <summary>
    ///* 所属包体
    ///0为首包；1为第1补充包；依次类推 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Pakage {
      get { return pakage_; }
      set {
        pakage_ = value;
      }
    }

    /// <summary>Field number for the "Version" field.</summary>
    public const int VersionFieldNumber = 3;
    private uint version_;
    /// <summary>
    ///* 分包版本号 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Version {
      get { return version_; }
      set {
        version_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MonsterFenBao);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MonsterFenBao other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ResID != other.ResID) return false;
      if (Pakage != other.Pakage) return false;
      if (Version != other.Version) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ResID != 0) hash ^= ResID.GetHashCode();
      if (Pakage != 0) hash ^= Pakage.GetHashCode();
      if (Version != 0) hash ^= Version.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ResID != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(ResID);
      }
      if (Pakage != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(Pakage);
      }
      if (Version != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(Version);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ResID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ResID);
      }
      if (Pakage != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Pakage);
      }
      if (Version != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Version);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MonsterFenBao other) {
      if (other == null) {
        return;
      }
      if (other.ResID != 0) {
        ResID = other.ResID;
      }
      if (other.Pakage != 0) {
        Pakage = other.Pakage;
      }
      if (other.Version != 0) {
        Version = other.Version;
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
            ResID = input.ReadUInt32();
            break;
          }
          case 16: {
            Pakage = input.ReadUInt32();
            break;
          }
          case 24: {
            Version = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class MonsterFenBaoArray : pb::IMessage<MonsterFenBaoArray>,IComponent {
    private static readonly pb::MessageParser<MonsterFenBaoArray> _parser = new pb::MessageParser<MonsterFenBaoArray>(() => new MonsterFenBaoArray());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MonsterFenBaoArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigMonsterfenbaoReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MonsterFenBaoArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MonsterFenBaoArray(MonsterFenBaoArray other) : this() {
      items_ = other.items_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MonsterFenBaoArray Clone() {
      return new MonsterFenBaoArray(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Dataconfig.MonsterFenBao> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::Dataconfig.MonsterFenBao.Parser);
    private readonly pbc::RepeatedField<global::Dataconfig.MonsterFenBao> items_ = new pbc::RepeatedField<global::Dataconfig.MonsterFenBao>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Dataconfig.MonsterFenBao> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MonsterFenBaoArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MonsterFenBaoArray other) {
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
    public void MergeFrom(MonsterFenBaoArray other) {
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
