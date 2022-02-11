namespace Booking.Data;

public interface IDataLayer<T>
{
    List<T> Entities { get; set; }
    T Add(T newEntity);
}