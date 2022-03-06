using Booking.Car;
using Booking.Customer;

namespace Booking.Booking;

public class Booking : IBooking
{
    public Guid Id { get; }
    public ICar Car { get; private set; }
    public ICustomer Customer { get; private set; }
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }
    public Boolean isOpen { get; set; }
    public Bill ForecastBill { get; }
    public short ForecastKilometers { get; }

    public Booking(ICar car, ICustomer customer, DateTime @from, DateTime to, short forecastKilometers)
    {
        Id = Guid.NewGuid();
        Car = car ?? throw new ArgumentNullException(nameof(car));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        From = @from;
        To = to;
        ForecastKilometers = forecastKilometers;
        ForecastBill = new Bill(this, forecastKilometers);
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