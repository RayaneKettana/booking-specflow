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
                    new DateOnly(06, 02, 1998),
                    new DateOnly(12, 05, 2018),
                    "1234565431"),

                new Customer("Mike",
                    "Adams",
                    new DateOnly(12, 04, 1995),
                    new DateOnly(10, 05, 2014),
                    "198721431"),
            }
        );
    }

    public string Register(string firstName, string lastName, DateOnly birthday, DateOnly datePermitObtained,
        string drivingLicenceNumber)
    {
        var newCustomer = new Customer(firstName, lastName, birthday, datePermitObtained, drivingLicenceNumber);
        _customerList.Add(newCustomer);
        var message = "Welcome";
        return message; 
    }
}