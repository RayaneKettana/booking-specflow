namespace Booking.Customer;

public class CustomerDecorator : ICustomer
{
    public Guid Id => _customer.Id;
    public string FirstName => _customer.FirstName;

    public string LastName => _customer.LastName;
    public DateOnly Birthday => _customer.Birthday;
    public DateOnly? DatePermitObtained => _customer.DatePermitObtained;
    public string DrivingLicenceNumber => _customer.DrivingLicenceNumber;
    public string Password => _customer.Password;
    
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