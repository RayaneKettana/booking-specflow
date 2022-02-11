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
}