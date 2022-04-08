using System;
using System.ValueVariant;

using MessagePack;

using Variant.Test;

using Xunit;

namespace ValueVariant.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            TestVariant v = default(int);
            Assert.Equal(v.Accept(new TestVariantVisitor()), (int)v.TypeIndex);

            v = default(TestStruct<Guid>);
            Assert.Equal(v.Accept(new TestVariantVisitor()), (int)v.TypeIndex);

            v = default(DateTime);
            Assert.Equal(v.Accept(new TestVariantVisitor()), (int)v.TypeIndex);
        }

        [Fact]
        public void Test2()
        {
            TestVariant v;
            int v1;
            TestStruct<Guid> v2;
            DateTime v3;
            byte[]? buff;
            TestVariant d;

            var intValue = 0x12345678;
            v = intValue;
            Assert.Equal(TypeIndex3.Type1, v.TypeIndex);
            Assert.Equal(intValue, v.Item1);
            Assert.True(v.TryGetValue(out v1));
            Assert.False(v.TryGetValue(out v2));
            Assert.False(v.TryGetValue(out v3));
            Assert.Equal(intValue, v1);
            buff = MessagePackSerializer.Serialize(v);
            d = MessagePackSerializer.Deserialize<TestVariant>(buff);
            Assert.Equal(v, d);

            var guid = new TestStruct<Guid>(Guid.NewGuid());
            v = guid;
            Assert.Equal(TypeIndex3.Type2, v.TypeIndex);
            Assert.Equal(guid, v.Item2);
            Assert.False(v.TryGetValue(out v1));
            Assert.True(v.TryGetValue(out v2));
            Assert.False(v.TryGetValue(out v3));
            Assert.Equal(guid, v2);
            buff = MessagePackSerializer.Serialize(v);
            d = MessagePackSerializer.Deserialize<TestVariant>(buff);
            Assert.Equal(v, d);

            var now = DateTime.UtcNow;
            v = now;
            Assert.Equal(TypeIndex3.Type3, v.TypeIndex);
            Assert.Equal(now, v.Item3);
            Assert.False(v.TryGetValue(out v1));
            Assert.False(v.TryGetValue(out v2));
            Assert.True(v.TryGetValue(out v3));
            Assert.Equal(now, v3);
            buff = MessagePackSerializer.Serialize(v);
            d = MessagePackSerializer.Deserialize<TestVariant>(buff);
            Assert.Equal(v, d);
        }
    }
}
