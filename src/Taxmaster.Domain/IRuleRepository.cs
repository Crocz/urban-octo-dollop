namespace Taxmaster.Domain;

public interface IRuleRepository
{
    Task<IEnumerable<Rule>> Get(string municipality, DateTime date);
    Task Create(string municipality, decimal taxrate, DateTime startDate, DateTime endDate);
}