using Microsoft.EntityFrameworkCore;

namespace Taxmaster.Infrastructure;

public class Populator
{
    public int LatestId { get; private set; } = 1;

    public List<DbDateRule> GetRecurringDateRules(string municipality, decimal taxRate, DateOnly startDate, DateOnly endDate, int times)
    {
        var recurringDateRules = new List<DbDateRule>();
        for(int i = 0; i < times; i++)
        {
            var rule = new DbDateRule
            {
                Id = LatestId++,
                TaxRate = taxRate,
                MunicipalityId = municipality,
                UtcStartTime = new DateTime(startDate.Year + i, startDate.Month, startDate.Day, 0, 0, 0, DateTimeKind.Utc),
                UtcEndTime = new DateTime(endDate.Year+ i, endDate.Month, endDate.Day, 0, 0, 0, DateTimeKind.Utc),
            };
            recurringDateRules.Add(rule);
        }
        return recurringDateRules;
    }
}