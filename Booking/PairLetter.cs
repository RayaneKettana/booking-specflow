namespace Booking;

public class PairLetter : ICounter<PairLetter>
{
    private string _first;

    public string First => _first;

    public string Second => _second;

    private string _second;

    public PairLetter(string first, string second)
    {
        _first = first ?? throw new ArgumentNullException(nameof(first));
        _second = second ?? throw new ArgumentNullException(nameof(second));
    }

    public PairLetter next()
    {
        return this;
    }

    public PairLetter getCurrent()
    {
        return this;
    }
}