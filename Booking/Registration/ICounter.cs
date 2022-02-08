namespace Booking.Registration;

public interface ICounter<T>
{
    public T Current { get; set; }

    ICounter<T> next();

    Boolean hasNext();

    ICounter<T> reset();

}