using Booking.Customer;
using Booking.Data;
using Booking.Seed;

namespace Booking.Booking;

public class BookingStore
{
    private static BookingStore? _bookingStore;
    private IDataLayer<IBooking> _dataLayer;

    public BookingStore()
    {
        _dataLayer = new DataLayer<IBooking>();
    }
    

    public static BookingStore GetInstance()
    {
        return _bookingStore ??= new BookingStore();
    }

    public List<IBooking> GetByPeriod(DateTime from, DateTime to)
    {
        return _dataLayer.Entities.FindAll(booking => from <= booking.From && to >= booking.To);
    }

    public void Init(FakeData<IBooking> fakeBookings)
    {
        _dataLayer = fakeBookings;
    }


    public IBooking? Add(Registration.Registration registration, ICustomer customer, DateTime from, DateTime to)
    {
        return _dataLayer.Add(new Booking(registration, customer, from, to));
        // TO DO Check the booking doesn't exist  
    }

    public ClosedBooking Close(IBooking bookingToClose, short actualKilometers)
    {
        ClosedBooking closedBooking = new ClosedBooking(bookingToClose, actualKilometers);
        _dataLayer.Update(closedBooking);
        return closedBooking;
    }

    public IBooking? GetOpenByRegistration(string registration)
    {
        return EntitiesWhereRegistration(registration)
            .FirstOrDefault(booking => booking.isOpen);
    }

    private IEnumerable<IBooking> EntitiesWhereRegistration(string registration)
    {
        return _dataLayer.Entities
            .Where(booking => booking.RegistrationCar.ToString().Equals(registration));
    }

    public IBooking? GetByRegistration(string registration)
    {
        return EntitiesWhereRegistration(registration)
            .FirstOrDefault();
    }

    public IBooking Open(IBooking booking)
    {
        booking.isOpen = true;
        return _dataLayer.Update(booking);
    }
}