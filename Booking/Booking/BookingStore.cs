namespace Booking.Booking;

public class BookingStore
{
    private static BookingStore? _bookingStore;
    private readonly List<Booking> bookingsList = new List<Booking>();
    

    public static BookingStore GetInstance()
    {
        return _bookingStore ??= new BookingStore();
    }

    // public List<Booking> getByPeriodAndRegistration(DateTime from, DateTime to, List<Registration.Registration> registrations)
    // {
    //     return getByPeriod(from, to).FindAll(booking => registrations.Contains(booking.RegistrationCar));
    // }

    public List<Booking> getByPeriod(DateTime from, DateTime to)
    {
        return bookingsList.FindAll(booking => from <= booking.From && to >= booking.To);
    }
    
}