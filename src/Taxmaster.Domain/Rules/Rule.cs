
public abstract class Rule : IComparable<Rule>
{
    public decimal TaxRate { get; init; }
    public abstract double Priority { get; }

    public int CompareTo(Rule? other) {
        if (other == null) return 1;
        if (other.Priority == Priority) {
            return TaxRate.CompareTo(other.TaxRate);
        }
        return Priority.CompareTo(other.Priority);
    }
}