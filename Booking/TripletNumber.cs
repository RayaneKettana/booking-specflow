namespace Booking;

public class TripletNumber : ICounter<int>
{
    public int Current { get; set; }

    public ICounter<int> next()
    {
        return new TripletNumber()
        {
            Current = Current+1
        };
    }

    public bool hasNext()
    {
        return Current < 1000;
    }

    public ICounter<int> reset()
    {
        return new TripletNumber
        {
            Current = 0
        };
    }
    
}