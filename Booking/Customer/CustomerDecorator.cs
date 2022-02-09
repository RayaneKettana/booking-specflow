namespace Booking.Customer;

public class CustomerDecorator : ICustomer
{
    public string FirstName => _customer.FirstName;

    public string LastName => _customer.LastName;
    public DateOnly Birthday => _customer.Birthday;
    public DateOnly DatePermitObtained => _customer.DatePermitObtained;
    public string DrivingLicenceNumber => _customer.DrivingLicenceNumber;
    protected ICustomer _customer;

    public CustomerDecorator(ICustomer customer)
    {
        _customer = customer;
    }

    public bool isConnected()
    {
       return _customer.isConnected();
    }
    
}