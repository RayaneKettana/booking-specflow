using System.Reflection.Metadata;
using Booking.Data;
using Booking.Seed;

namespace Booking.Customer;

public class CustomerStore
{
    private static CustomerStore? _customer;
    private IDataLayer<Customer> _dataLayer;

    public CustomerStore()
    {
        _dataLayer = new DataLayer<Customer>();
    }

    public void init(FakeData<Customer> fakeCustomers)
    {
        _dataLayer = fakeCustomers;
    }
    
    public static CustomerStore GetInstance()
    {
        return _customer ??= new CustomerStore();
    }
    

    public AuthenticatedCustomer Register(string firstName, string lastName, DateOnly birthday, DateOnly datePermitObtained,
        string drivingLicenceNumber, string password)
    {
        var newCustomer = new Customer(firstName, lastName, birthday, datePermitObtained, drivingLicenceNumber, password);
        _dataLayer.Add(newCustomer);
        return new AuthenticatedCustomer(newCustomer);
    }

    public AuthenticatedCustomer? Login(string firstName, string password)
    {
        Customer? customer = _dataLayer.Entities.FirstOrDefault(customer =>
            customer.firstName == firstName & customer.password == password);
        return customer != null ? new AuthenticatedCustomer(customer) : null;
    }
    
}