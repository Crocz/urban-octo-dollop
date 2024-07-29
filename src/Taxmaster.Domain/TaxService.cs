
namespace Taxmaster.Domain;

public class TaxService
{
    private readonly IRuleRepository _ruleRepository;

    public TaxService(IRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;
    }
    public async Task<decimal> GetTax(string municipality, DateTime date)
    {
        var rules = (await _ruleRepository.Get(municipality, date)).ToList();
        rules.Sort();
        rules.Reverse();
        return rules.FirstOrDefault()?.TaxRate ?? throw new TaxPolicyNotFound(municipality, date);
    }

    public async Task PostTax(string municipality, decimal taxrate, DateTime startDateInclusive, DateTime endDateExclusive)
    {
        await _ruleRepository.Create(municipality, taxrate, startDateInclusive, endDateExclusive);
    }
}
