// automatically generated by the FlatBuffers compiler, do not modify

package MyGame.Example2;

import java.nio.*;
import java.lang.*;
import java.util.*;
import com.google.flatbuffers.*;

@SuppressWarnings("unused")
public final class MonsterT {
}

public final class Monster extends Table {
  public static Monster getRootAsMonster(ByteBuffer _bb) { return getRootAsMonster(_bb, new Monster()); }
  public static Monster getRootAsMonster(ByteBuffer _bb, Monster obj) { _bb.order(ByteOrder.LITTLE_ENDIAN); return (obj.__assign(_bb.getInt(_bb.position()) + _bb.position(), _bb)); }
  public void __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; }
  public Monster __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void startMonster(FlatBufferBuilder builder) { builder.startObject(0); }
  public static int endMonster(FlatBufferBuilder builder) {
    int o = builder.endObject();
    return o;
  }
  public static int CreateMonster(FlatBufferBuilder builder, MonsterT obj) {
    StartMonster(builder);
    return EndMonster(builder);
  }
  public MonsterT unPack()  {
    MonsterT obj = new MonsterT();
    unPackTo(obj);
    return obj;
  }
  public void unPackTo(MonsterT obj)  {
  }
}

