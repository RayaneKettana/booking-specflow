namespace Booking.Registration;

public class TripletNumber : ICounter<int, TripletNumber>
{
    public int Current { get; set; } = 1;

    public TripletNumber next()
    {
        return Copy(Current + 1);
    }

    public bool hasNext()
    {
        return Current < 1000;
    }

    public TripletNumber reset()
    {
        return Copy(0);
    }

    private static TripletNumber Copy(int Int)
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