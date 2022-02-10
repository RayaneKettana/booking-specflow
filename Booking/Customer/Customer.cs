namespace Booking.Customer;

public class Customer : ICustomer
{
    public string firstName;
    public string lastName;
    public DateOnly birthday;
    public DateOnly datePermitObtained;
    public string drivingLicenceNumber;
    public string password;
    public bool Connected { get; } = false;
    public string FirstName => firstName;
    public string LastName => lastName;
    public DateOnly Birthday => birthday;
    public DateOnly DatePermitObtained => datePermitObtained;
    public string DrivingLicenceNumber => drivingLicenceNumber;
    public string Password => password;
    


    public Customer(string firstName, string lastName, DateOnly birthday, DateOnly datePermitObtained, string drivingLicenceNumber, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthday = birthday;
        this.datePermitObtained = datePermitObtained;
        this.drivingLicenceNumber = drivingLicenceNumber;
        this.password = password;
    }

    public bool isConnected()
    {
        return false;
    }
    
}