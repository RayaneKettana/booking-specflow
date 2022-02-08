namespace Booking;

public class TripletNumber : ICounter<TripletNumber>
{
    private int _tripletNumber;
    
    public TripletNumber next()
    {
        throw new NotImplementedException();
    }

    public TripletNumber getCurrent()
    {
        return this;
    }
}