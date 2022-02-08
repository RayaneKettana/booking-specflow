namespace Booking;

public interface ICounter<T>
{
    T next();
    T getCurrent();
}