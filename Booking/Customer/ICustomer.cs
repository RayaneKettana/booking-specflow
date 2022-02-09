namespace Booking.Customer;

public interface ICustomer
{
    string FirstName { get; }
    string LastName { get; }
    DateOnly Birthday { get; }
    DateOnly DatePermitObtained { get; }
    string DrivingLicenceNumber { get; }

    public bool isConnected();

}