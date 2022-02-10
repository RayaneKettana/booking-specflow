using System.Reflection.Metadata;

namespace Booking.Customer;

public class CustomerStore
{
    private static CustomerStore? _customer;
    public  List<Customer> _customerList { get; }

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
                    "1234565431", password:"password1234"),

                new Customer("Mike",
                    "Adams",
                    new DateOnly(1995,12, 04),
                    new DateOnly(2014, 10, 05),
                    "198721431", "password4321"),
            }
        );
    }
    

    public AuthenticatedCustomer Register(string firstName, string lastName, DateOnly birthday, DateOnly datePermitObtained,
        string drivingLicenceNumber, string password)
    {
        var newCustomer = new Customer(firstName, lastName, birthday, datePermitObtained, drivingLicenceNumber, password);
        _customerList.Add(newCustomer);
        return new AuthenticatedCustomer(newCustomer);
    }
}