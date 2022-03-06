using Booking.Booking;

namespace Booking.Car;

public interface ICar : IEntity
{
    string Color { get; }
    string Brand { get; }
    string Model { get; }
    short Cv { get; }
    double BasePrice { get; }
    double PerKilometerPrice { get; }
    Registration.Registration Registration { get; }
}