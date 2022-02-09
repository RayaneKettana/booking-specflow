namespace Booking.Registration;

public interface ICounter<T, out U>
{
    public T Current { get; set; }

    U next();

    Boolean hasNext();

    U reset();

}