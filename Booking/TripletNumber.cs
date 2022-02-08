namespace Booking;

public class TripletNumber : ICounter<int>
{
    public int Current { get; set; }

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
}