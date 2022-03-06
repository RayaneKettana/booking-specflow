using Booking.Booking;

namespace Booking.Customer;

public interface ICustomer : IEntity
{
    string FirstName { get; }
    string LastName { get; }
    DateOnly Birthday { get; }
    DateOnly DatePermitObtained { get; }
    string DrivingLicenceNumber { get; }
    string Password { get; }

    public bool isConnected();

}