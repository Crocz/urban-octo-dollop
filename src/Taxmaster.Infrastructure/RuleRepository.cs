
using Microsoft.EntityFrameworkCore;
using Taxmaster.Domain;
using Taxmaster.Infrastructure;

public class RuleRepository : IRuleRepository
{
    private readonly RuleContext _ruleContext;

    public RuleRepository(RuleContext context)
    {
        _ruleContext = context;
    }

    public async Task Create(string municipality, decimal taxrate, DateTime startDate, DateTime endDate)
    {
        var lowerCaseMunicipality = municipality.ToLower();
        var m = await _ruleContext.Municipalities.FirstOrDefaultAsync(m => m.Id == lowerCaseMunicipality);
        if (m is null)
        {
            m = new DbMunicipality
            {
                Id = lowerCaseMunicipality,
                Rules = new List<DbDateRule>()
            };
            _ruleContext.Municipalities.Add(m);
        }
        m.Rules.Add(new DbDateRule
        {
            MunicipalityId = lowerCaseMunicipality,
            TaxRate = taxrate,
            UtcStartTime = ToUtc(startDate),
            UtcEndTime = ToUtc(endDate)
        });
        await _ruleContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Rule>> Get(string municipality, DateTime date)
    {
        var lowerCaseMunicipality = municipality.ToLower();
        var utcDate = ToUtc(date);
        var m = await _ruleContext.Municipalities
            .Include(m => m.Rules)
            .FirstOrDefaultAsync(m => m.Id == lowerCaseMunicipality);

        return m is null
            ? Enumerable.Empty<Rule>()
            : m.Rules
            .Where(r =>
                r.UtcStartTime <= utcDate && r.UtcEndTime > utcDate
            )
            .Select(r => ToDateRule(r) as Rule);
    }

    private DateTime ToUtc(DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
    }

    private DateRule ToDateRule(DbDateRule rule)
    {
        return new DateRule
        {
            TaxRate = rule.TaxRate,
            FromInclusive = DateOnly.FromDateTime(rule.UtcStartTime),
            UntilExclusive = DateOnly.FromDateTime(rule.UtcEndTime),
        };
    }
}
