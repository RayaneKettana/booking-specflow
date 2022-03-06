using Booking.Car;
using Booking.Customer;

namespace Booking.Booking;

public class BookingService
{
    private BookingStore _bookingStore;
    private CarStore _carStore;
    private static BookingService? _instance;

    public static BookingService GetInstance()
    {
        return _instance ??= new BookingService(BookingStore.GetInstance(), CarStore.GetInstance());
    }

    public BookingService(BookingStore bookingStore, CarStore carStore)
    {
        _bookingStore = bookingStore ?? throw new ArgumentNullException(nameof(bookingStore));
        _carStore = carStore ?? throw new ArgumentNullException(nameof(carStore));
    }

    public List<Car.Car> getAvailableCar(DateTime from, DateTime to)
    {
        var unavailableRegistrations = _bookingStore
            .GetByPeriod(from, to)
            .Select((booking => booking.RegistrationCar)).ToList();

        return _carStore.GetAllCarsExcept(unavailableRegistrations);
    }

    public void AddBooking(Registration.Registration registration, AuthenticatedCustomer customer, DateTime from, DateTime to)
    {
        _bookingStore.Add(registration, customer, from, to);
    }

    public ClosedBooking closeBooking(string registration, short actualKilometer)
    {
        var booking = _bookingStore.GetOpenByRegistration(registration);
        return _bookingStore.Close(booking ?? throw new InvalidOperationException("Open booking corresponding to this registration not found"), actualKilometer);
    }

    public IBooking startBooking(string registration)
    {
        var booking = _bookingStore.GetByRegistration(registration);
        return _bookingStore.Open(booking ??
                                  throw new InvalidOperationException(
                                      "booking corresponding to this registration not found"));
    }
}