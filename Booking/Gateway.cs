using Booking.Booking;
using Booking.Car;
using Booking.Customer;
using Booking.Seed;

namespace Booking;

public class Gateway
{
    private AuthenticatedCustomer? _customer;
    private CustomerStore _customerStore;
    private BookingService _bookingService;
    private BookingStore _bookingStore;
    private CarStore _carStore;

    public Gateway()
    {
        _customerStore = CustomerStore.GetInstance();
        _bookingService = BookingService.GetInstance();
    }
    public Gateway(FakeData<Customer.Customer>? fakeCustomers = null,
        FakeData<ICar> fakeCars = null,
        FakeData<IBooking> fakeBookings = null)
    {
        _customerStore = CustomerStore.GetInstance();
        if (fakeCustomers != null) _customerStore.init(fakeCustomers);
        _bookingStore = BookingStore.GetInstance();
        if (fakeBookings != null) _bookingStore.Init(fakeBookings);
        _carStore = CarStore.GetInstance();
        if (fakeCars != null) _carStore.init(fakeCars);
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
            : "personne n'est connecté";
    }

    public string Logout()
    {
        if (_customer != null && _customer.Logout())
        {
            _customer = null;
            return "Vous êtes déconnecté";
        }

        return "Déconnection impossible";
    }
    
    public List<ICar> GetCarsList(DateTime from, DateTime to)
    {
        return CheckIsConnected() 
            ? _bookingService.GetAvailableCar(from, to)
            : new List<ICar>();
    }

    private bool CheckIsConnected()
    {
        return _customer != null && _customer.isConnected();
    }

    public string Book(ICar car, DateTime from, DateTime to, short forecastKilometers)
    {
        if (CheckIsConnected() && Validator.Validator.canBookACar(_customer, car))
        {
            try
            {
                var forecastBill = _bookingService.AddBooking(car.Registration, _customer, @from, to, forecastKilometers);
                return "Réservation est un succès : Facture prévisionnel " + forecastBill;
            }
            catch (Exception e)
            {
                return "Réservation impossible : " + e.Message;
            }
        }

        return "Réservation impossible";
    }


    public string CloseBooking(string registration, short actualKilometer)
    {
        if (CheckIsConnected())
        {
            var actualBill = _bookingService.CloseBooking(registration, actualKilometer);
            return "Réservation cloturée : Facture " + actualBill;
        }

        return "Cloture impossible";
    }

    public string StartBooking(string registration)
    {
        if (CheckIsConnected())
        {
            _bookingService.startBooking(registration);
            return "Voici les clé de votre voiture de location";
        }

        return "Départ impossible";
        
    }
}