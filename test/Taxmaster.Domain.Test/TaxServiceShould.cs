using FakeItEasy;

namespace Taxmaster.Domain.Test;

public class TaxServiceShould
{
    private readonly IRuleRepository _ruleRepository;
    private readonly TaxService _sut;

    public TaxServiceShould()
    {
        _ruleRepository = A.Fake<IRuleRepository>();
        _sut = new TaxService(_ruleRepository);
    }

    [Fact]
    public void ThrowOnGetUnknownOrUnspecified()
    {
        A.CallTo(() => _ruleRepository.Get(A<string>._, A<DateTime>._)).Returns(Task.FromResult<IEnumerable<Rule>>(new List<Rule>()));
        Assert.ThrowsAsync<TaxPolicyNotFound>(() => _sut.GetTax("Unknown", DateTime.Now));
    }

    [Fact]
    public void ReturnTaxRate()
    {
        var rules = new List<Rule> { new TestRule { TaxRate = 0.2m, Prio = 1 } };
        A.CallTo(() => _ruleRepository.Get(A<string>._, A<DateTime>._)).Returns(Task.FromResult<IEnumerable<Rule>>(rules));
        var result = _sut.GetTax("Test", DateTime.Now);
        Assert.Equal(0.2m, result.Result);
    }

    [Fact]
    public void ReturnHighestPriorityTaxRate()
    {
        var rules = new List<Rule> { new TestRule { TaxRate = 0.2m, Prio = 1 }, new TestRule { TaxRate = 0.3m, Prio = 2 } };
        A.CallTo(() => _ruleRepository.Get(A<string>._, A<DateTime>._)).Returns(Task.FromResult<IEnumerable<Rule>>(rules));
        var result = _sut.GetTax("Test", DateTime.Now);
        Assert.Equal(0.3m, result.Result);
    }

    [Fact]
    public void PostTax()
    {
        var start = DateTime.Now;
        var end = DateTime.Now.AddHours(1);
        _sut.PostTax("Test", 0.2m, start, end);
        A.CallTo(() => _ruleRepository.Create("Test", 0.2m, start, end)).MustHaveHappened();
    }

    class TestRule : Rule
    {
        public double Prio { get; init; }
        public override double Priority => Prio;
        public TestRule(){}
    }
}