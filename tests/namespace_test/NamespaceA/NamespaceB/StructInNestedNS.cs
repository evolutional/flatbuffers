// automatically generated by the FlatBuffers compiler, do not modify

namespace NamespaceA.NamespaceB
{

using System;
using FlatBuffers;

public struct StructInNestedNS : Accessor
{
  private Struct __p;
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public StructInNestedNS __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int A { get { return __p.bb.GetInt(__p.bb_pos + 0); } }
  public void MutateA(int a) { __p.bb.PutInt(__p.bb_pos + 0, a); }
  public int B { get { return __p.bb.GetInt(__p.bb_pos + 4); } }
  public void MutateB(int b) { __p.bb.PutInt(__p.bb_pos + 4, b); }

  public static Offset<StructInNestedNS> CreateStructInNestedNS(FlatBufferBuilder builder, int A, int B) {
    builder.Prep(4, 8);
    builder.PutInt(B);
    builder.PutInt(A);
    return new Offset<StructInNestedNS>(builder.Offset);
  }
};


}
