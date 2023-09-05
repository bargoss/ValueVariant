using Xunit;

namespace ValueVariant.Test
{
    public class SwitchMatchTests
    {
        [Fact]
        public void Test1()
        {
            TestVariantBargos a  = 1;
            a.Switch(i =>
            {

            }, l =>
            {

            }, b =>
            {

            });
        }
    }

    [ValueVariant]
    public partial struct TestVariantBargos : IValueVariant<TestVariantBargos, int, long, bool>
    {
        
    }
}
