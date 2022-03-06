using Booking.Car;
using Booking.Customer;

namespace Booking.Booking;

public class Booking : IBooking
{
    public Guid Id { get; }
    public Registration.Registration RegistrationCar { get; private set; }
    public ICustomer Customer { get; private set; }
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }
    public Boolean isOpen { get; set; }

    public Booking(Registration.Registration registrationCar, ICustomer customer, DateTime @from, DateTime to)
    {
        Id = Guid.NewGuid();
        RegistrationCar = registrationCar ?? throw new ArgumentNullException(nameof(registrationCar));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        From = @from;
        To = to;
    }

    public override bool Equals(Object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Booking booking = (Booking) obj;
        return Id.Equals(booking.Id);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
    
}