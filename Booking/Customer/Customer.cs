namespace Booking.Customer;

public class Customer
{


    public string firstName;
    public string lastName;
    public DateOnly birthday;
    public DateOnly datePermitObtained;
    public string drivingLicenceNumber;
    
    public DateOnly Birthday => birthday;

    public DateOnly DatePermitObtained => datePermitObtained;

    public string DrivingLicenceNumber => drivingLicenceNumber;
    
    public Customer(string firstName, string lastName, DateOnly birthday, DateOnly datePermitObtained, string drivingLicenceNumber)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthday = birthday;
        this.datePermitObtained = datePermitObtained;
        this.drivingLicenceNumber = drivingLicenceNumber;
    }
    
    

    
}