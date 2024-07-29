
public class DateRule : Rule
{
    public DateOnly FromInclusive { get; init; }
    public DateOnly UntilExclusive { get; init; }

    private double Specifity => 1.0d / (double)(UntilExclusive.DayNumber - FromInclusive.DayNumber);

    public override double Priority => Specifity;
}