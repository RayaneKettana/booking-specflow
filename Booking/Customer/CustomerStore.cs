using System.Reflection.Metadata;

namespace Booking.Customer;

public class CustomerStore
{
    private static CustomerStore? _customer;
    private readonly List<Customer> _customerList;

    public CustomerStore(List<Customer> customers)
    {
        _customerList = customers;
    }

    public static CustomerStore GetInstance()
    {
        return _customer ??= new CustomerStore(new List<Customer>
            {
                new Customer("John",
                    "Smith",
                    new DateOnly(1998, 06, 02),
                    new DateOnly(2018, 02,05),
                    "1234565431"),

                new Customer("Mike",
                    "Adams",
                    new DateOnly(1995,12, 04),
                    new DateOnly(2014, 10, 05),
                    "198721431"),
            }
        );
    }

    public AuthenticatedDecorator Register(string firstName, string lastName, DateOnly birthday, DateOnly datePermitObtained,
        string drivingLicenceNumber)
    {
        var newCustomer = new Customer(firstName, lastName, birthday, datePermitObtained, drivingLicenceNumber);
        _customerList.Add(newCustomer);
        return new AuthenticatedDecorator(newCustomer); 
    }
}