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
            .Select((booking => booking.Car.Registration)).ToList();

        return _carStore.GetAllCarsExcept(unavailableRegistrations);
    }

    public Bill AddBooking(Registration.Registration registration, AuthenticatedCustomer customer, DateTime from, DateTime to, short forecastKilometer)
    {
        var byRegistration = _carStore.GetByRegistration(registration);
        var car = byRegistration
                  ?? throw new InvalidOperationException("Car corresponding to this registration not found : " + registration);
        return _bookingStore.Add(car, customer, from, to, forecastKilometer)
            ?? throw new InvalidOperationException("Booking is not create" + registration);
    }

    public Bill CloseBooking(string registration, short actualKilometer)
    {
        var booking = _bookingStore.GetOpenByRegistration(registration) 
                      ?? throw new InvalidOperationException("Open booking corresponding to this registration not found");
        var closedBooking = _bookingStore.Close(booking , actualKilometer);
        return closedBooking.ActualBill;
    }

    public IBooking startBooking(string registration)
    {
        var booking = _bookingStore.GetByRegistration(registration);
        return _bookingStore.Open(booking ??
                                  throw new InvalidOperationException(
                                      "booking corresponding to this registration not found"));
    }
}