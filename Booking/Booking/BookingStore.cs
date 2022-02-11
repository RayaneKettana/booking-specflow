using Booking.Customer;
using Booking.Data;
using Booking.Seed;

namespace Booking.Booking;

public class BookingStore
{
    private static BookingStore? _bookingStore;
    private IDataLayer<Booking> _dataLayer;

    public BookingStore()
    {
        _dataLayer = new DataLayer<Booking>();
    }
    

    public static BookingStore GetInstance()
    {
        return _bookingStore ??= new BookingStore();
    }

    public List<Booking> GetByPeriod(DateTime from, DateTime to)
    {
        return _dataLayer.Entities.FindAll(booking => from <= booking.From && to >= booking.To);
    }

    public void Init(FakeData<Booking> fakeBookings)
    {
        _dataLayer = fakeBookings;
    }


    public Booking Add(Registration.Registration registration, ICustomer customer, DateTime from, DateTime to)
    {
        return _dataLayer.Add(new Booking(registration, customer, from, to));
        // TO DO Check the booking doesn't exist  
    }
}