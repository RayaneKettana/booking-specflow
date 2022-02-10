using Booking.Car;

namespace Booking.Booking;

public class BookingService
{
    private BookingStore _bookingStore;
    private Car.CarStore _carStore;
    private static BookingService? _instance;

    public static BookingService getInstance()
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
            .getByPeriod(from, to)
            .Select((booking => booking.RegistrationCar)).ToList();

        return _carStore.GetAllCarsExcept(unavailableRegistrations);
    }
}