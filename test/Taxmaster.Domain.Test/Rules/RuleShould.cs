using Xunit;

namespace Taxmaster.Domain.Test.Rules
{
    public class RuleShould
    {
        [Fact]
        public void CompareLessToAHigherPriorityRule()
        {
            var lower = new TestRule{ Prio = 1};
            var higher = new TestRule{ Prio = 2};
            var result = lower.CompareTo(higher);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CompareEqualToSamePriorityRule()
        {
            var equal1 = new TestRule{ Prio = 1};
            var equal2 = new TestRule{ Prio = 1};
            var result = equal1.CompareTo(equal2);
            Assert.Equal(0, result);
        }

        [Fact]
        public void CompareMoreToALowerPriorityRule()
        {
            var lower = new TestRule{ Prio = 1};
            var higher = new TestRule{ Prio = 2};
            var result = higher.CompareTo(lower);
            Assert.Equal(1, result);
        }
    }

    class TestRule : Rule
    {
        public double Prio { get; init; }
        public override double Priority => Prio;
        public TestRule(){}
    }
}