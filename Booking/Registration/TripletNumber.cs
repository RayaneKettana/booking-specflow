namespace Booking.Registration;

public class TripletNumber : ICounter<int>
{
    public int Current { get; set; } = 1;

    public ICounter<int> next()
    {
        return Copy(Current + 1);
    }

    public bool hasNext()
    {
        return Current < 1000;
    }

    public ICounter<int> reset()
    {
        return Copy(0);
    }

    private static ICounter<int> Copy(int Int)
    {
        return new TripletNumber
        {
            Current = Int
        };
    }

    public override string ToString()
    {
        return Current.ToString();
    }
}