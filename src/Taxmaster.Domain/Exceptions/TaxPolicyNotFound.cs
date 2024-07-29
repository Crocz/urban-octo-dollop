
public class TaxPolicyNotFound : TaxmasterException
{
    public string Name { get; }
    public DateTime Date { get; }

    public TaxPolicyNotFound(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }
}