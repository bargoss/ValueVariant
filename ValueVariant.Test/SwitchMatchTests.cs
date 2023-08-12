using Xunit;

namespace ValueVariant.Test
{
    public class SwitchMatchTests
    {
        [Fact]
        public void Test1()
        {
            TestVariantBargos a  = 1;
            a.Switch(
                i => { },
                command => { },
                bargos => { },
                b => { }
            );
        }
    }

    [ValueVariant]
    public readonly partial struct TestVariantBargos : IValueVariant<TestVariantBargos, int, PlayerCommand, Bargos, bool>
    {
        
    }

    public struct PlayerCommand
    {
        public int A;
        public int B;
    }
    public struct Bargos
    {
        public double A;
        public float B;
    }
}
