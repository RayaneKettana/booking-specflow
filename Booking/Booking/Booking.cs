using Booking.Car;

namespace Booking.Booking;

public class Booking
{
    public Registration.Registration RegistrationCar { get; private set; }
    public Customer.Customer Customer { get; private set; }
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }

    public Booking(Registration.Registration registrationCar, Customer.Customer customer, DateTime @from, DateTime to)
    {
        RegistrationCar = registrationCar ?? throw new ArgumentNullException(nameof(registrationCar));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        From = @from;
        To = to;
    }
    
}