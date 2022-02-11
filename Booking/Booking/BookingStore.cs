namespace Booking.Booking;

public class BookingStore
{
    private static BookingStore? _bookingStore;
    private readonly List<Booking> _bookingsList = new List<Booking>();
    

    public static BookingStore GetInstance()
    {
        return _bookingStore ??= new BookingStore();
    }

    public List<Booking> GetByPeriod(DateTime from, DateTime to)
    {
        return _bookingsList.FindAll(booking => from <= booking.From && to >= booking.To);
    }
    
}