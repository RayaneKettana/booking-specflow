namespace Booking.Registration;

public class TripletNumber : ICounter<int, TripletNumber>
{
    public int Current { get; set; } = 1;

    public TripletNumber next()
    {
        var prev = Copy(Current);
        Current++;
        return prev;
    }

    public bool hasNext()
    {
        return Current < 1000;
    }

    public void reset()
    {
        Current = 0;
    }

    public static TripletNumber Copy(int Int)
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