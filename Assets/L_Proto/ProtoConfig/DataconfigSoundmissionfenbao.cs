// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: dataconfig_soundmissionfenbao.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dataconfig {

  /// <summary>Holder for reflection information generated from dataconfig_soundmissionfenbao.proto</summary>
  public static partial class DataconfigSoundmissionfenbaoReflection {

    #region Descriptor
    /// <summary>File descriptor for dataconfig_soundmissionfenbao.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataconfigSoundmissionfenbaoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiNkYXRhY29uZmlnX3NvdW5kbWlzc2lvbmZlbmJhby5wcm90bxIKZGF0YWNv",
            "bmZpZyJFChJTb3VuZE1pc3Npb25GZW5CYW8SDgoGVGFza0lEGAEgASgNEg4K",
            "BlBha2FnZRgCIAEoDRIPCgdWZXJzaW9uGAMgASgNIkgKF1NvdW5kTWlzc2lv",
            "bkZlbkJhb0FycmF5Ei0KBWl0ZW1zGAEgAygLMh4uZGF0YWNvbmZpZy5Tb3Vu",
            "ZE1pc3Npb25GZW5CYW9iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.SoundMissionFenBao), global::Dataconfig.SoundMissionFenBao.Parser, new[]{ "TaskID", "Pakage", "Version" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Dataconfig.SoundMissionFenBaoArray), global::Dataconfig.SoundMissionFenBaoArray.Parser, new[]{ "Items" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SoundMissionFenBao : pb::IMessage<SoundMissionFenBao>,IComponent {
    private static readonly pb::MessageParser<SoundMissionFenBao> _parser = new pb::MessageParser<SoundMissionFenBao>(() => new SoundMissionFenBao());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SoundMissionFenBao> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigSoundmissionfenbaoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoundMissionFenBao() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoundMissionFenBao(SoundMissionFenBao other) : this() {
      taskID_ = other.taskID_;
      pakage_ = other.pakage_;
      version_ = other.version_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoundMissionFenBao Clone() {
      return new SoundMissionFenBao(this);
    }

    /// <summary>Field number for the "TaskID" field.</summary>
    public const int TaskIDFieldNumber = 1;
    private uint taskID_;
    /// <summary>
    ///* 关键字
    ///通过任务ID，获取情景对话表中使用音乐文件 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint TaskID {
      get { return taskID_; }
      set {
        taskID_ = value;
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
      return Equals(other as SoundMissionFenBao);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SoundMissionFenBao other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TaskID != other.TaskID) return false;
      if (Pakage != other.Pakage) return false;
      if (Version != other.Version) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (TaskID != 0) hash ^= TaskID.GetHashCode();
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
      if (TaskID != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(TaskID);
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
      if (TaskID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TaskID);
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
    public void MergeFrom(SoundMissionFenBao other) {
      if (other == null) {
        return;
      }
      if (other.TaskID != 0) {
        TaskID = other.TaskID;
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
            TaskID = input.ReadUInt32();
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

  public sealed partial class SoundMissionFenBaoArray : pb::IMessage<SoundMissionFenBaoArray>,IComponent {
    private static readonly pb::MessageParser<SoundMissionFenBaoArray> _parser = new pb::MessageParser<SoundMissionFenBaoArray>(() => new SoundMissionFenBaoArray());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SoundMissionFenBaoArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dataconfig.DataconfigSoundmissionfenbaoReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoundMissionFenBaoArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoundMissionFenBaoArray(SoundMissionFenBaoArray other) : this() {
      items_ = other.items_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SoundMissionFenBaoArray Clone() {
      return new SoundMissionFenBaoArray(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Dataconfig.SoundMissionFenBao> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::Dataconfig.SoundMissionFenBao.Parser);
    private readonly pbc::RepeatedField<global::Dataconfig.SoundMissionFenBao> items_ = new pbc::RepeatedField<global::Dataconfig.SoundMissionFenBao>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Dataconfig.SoundMissionFenBao> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SoundMissionFenBaoArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SoundMissionFenBaoArray other) {
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
    public void MergeFrom(SoundMissionFenBaoArray other) {
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