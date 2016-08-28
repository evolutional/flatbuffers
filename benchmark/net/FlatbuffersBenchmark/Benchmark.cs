using fbbench;
using FlatBuffers;

namespace FlatBuffersBenchmark
{
    public class Benchmark
    {
        private readonly FooBar _fooBar = new FooBar();
        private readonly Bar _bar = new Bar();
        private readonly Foo _foo = new Foo();

        private const int VecLen = 3;
        private const string Location = "http://google.com/flatbuffers/";
        private const bool Initialized = true;
        private const AnEnum AnEnum = fbbench.AnEnum.Bananas;


        public int Encode(ByteBuffer buffer)
        {
            var builder = new FlatBufferBuilder(buffer);

            var fooBars = new Offset<FooBar>[VecLen];
            for (var i = 0; i < VecLen; i++)
            {

                var name = builder.CreateString("Hello, World!");

                FooBar.StartFooBar(builder);
                FooBar.AddName(builder, name);
                FooBar.AddRating(builder, 3.1415432432445543543 + i);
                FooBar.AddPostfix(builder, (byte)('!' + i));

                var bar = Bar.CreateBar(builder,
                    // Foo fields (nested struct)
                        0xABADCAFEABADCAFEL + (ulong)i,
                        (short)(10000 + i),
                        (sbyte)('@' + i),
                        1000000 + (uint)i,
                    // Bar fields
                        123456 + i,
                        3.14159f + i,
                        (ushort)(10000 + i));

                FooBar.AddSibling(builder, bar);
                var fooBar = FooBar.EndFooBar(builder);
                fooBars[i] = fooBar;
            }

            var list = FooBarContainer.CreateListVector(builder, fooBars);
            var loc = builder.CreateString(Location);

            FooBarContainer.StartFooBarContainer(builder);
            FooBarContainer.AddLocation(builder, loc);
            FooBarContainer.AddInitialized(builder, Initialized);
            FooBarContainer.AddFruit(builder, AnEnum);
            FooBarContainer.AddLocation(builder, loc);
            FooBarContainer.AddList(builder, list);
            var fooBarContainer = FooBarContainer.EndFooBarContainer(builder);
            builder.Finish(fooBarContainer.Value);

            return buffer.Position;
        }

        public FooBarContainer Decode(ByteBuffer buffer)
        {
            return FooBarContainer.GetRootAsFooBarContainer(buffer);
        }

        public long Use(ByteBuffer buffer)
        {
            // The root object really should be reusable
            var fooBarContainer = FooBarContainer.GetRootAsFooBarContainer(buffer);

            long sum = 0;
            sum += fooBarContainer.Initialized ? 1 : 0;
            sum += fooBarContainer.Location.Length;
            sum += (short)fooBarContainer.Fruit;

            var length = fooBarContainer.ListLength;
            for (var i = 0; i < length; i++)
            {

                fooBarContainer.GetList(_fooBar, i);
                sum += _fooBar.Name.Length;
                sum += _fooBar.Postfix;
                sum += (long)_fooBar.Rating;

                _fooBar.GetSibling(_bar);
                sum += _bar.Size;
                sum += _bar.Time;

                _bar.GetParent(_foo);
                sum += _foo.Count;
                sum += (long)_foo.Id;
                sum += _foo.Length;
                sum += _foo.Prefix;
            }

            return sum;

        }
    }
}