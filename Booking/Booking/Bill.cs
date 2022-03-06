namespace Booking.Booking;

public class Bill
{
    public IBooking Booking { get; }
    public short Kilometers { get; }

    public Bill(IBooking booking, short kilometers)
    {
        Booking = booking;
        Kilometers = kilometers;
    }

    public override string ToString()
    {
        return "le " + Booking.To.ToShortDateString() 
                             + " au nom de " + Booking.Customer.FirstName + " " + Booking.Customer.LastName 
                             + " pour un montant de " + Price() + " €";
    }

    private double Price()
    {
        return Booking.Car.BasePrice + Booking.Car.PerKilometerPrice * Kilometers;
    }
    
}