using Booking.Booking;

namespace Booking.Car;

public interface ICar : IEntity
{
    string Color { get; }
    string Brand { get; }
    string Model { get; }
    Registration.Registration Registration { get; }
}