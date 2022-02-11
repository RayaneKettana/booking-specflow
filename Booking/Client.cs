using Booking.Booking;
using Booking.Customer;

namespace Booking;

public class Client
{
    private AuthenticatedCustomer? _customer;
    private CustomerStore _customerStore;
    private BookingService _bookingService;

    public Client()
    {
        _customerStore = CustomerStore.GetInstance();
        _bookingService = BookingService.GetInstance();
    }

    public string Register(string firstName, string lastName, DateOnly birthday, DateOnly datePermitObtained,
        string drivingLicenceNumber, string password)
    {
        try
        {
            _customer = _customerStore.Register( firstName, lastName, birthday, datePermitObtained, drivingLicenceNumber, password);
            return "Bienvenue " + firstName;
        }
        catch (Exception e)
        {
            return "Inscription impossible";
        }
    }

    public string Login(string firstName, string password)
    {
        _customer = _customerStore.Login(firstName, password);
        return _customer != null ? "Vous êtes connecté" : "Connection impossible";
    }

    public string Me()
    {
        return CheckIsConnected() 
            ? _customer.FirstName + " est connecté" 
            : " personne n'est connecté";
    }

    public List<Car.Car> GetCarsList(DateTime from, DateTime to)
    {
        return CheckIsConnected() 
            ? _bookingService.getAvailableCar(from, to)
            : new List<Car.Car>();

    }

    private bool CheckIsConnected()
    {
        return _customer != null && _customer.isConnected();
    }
    
}