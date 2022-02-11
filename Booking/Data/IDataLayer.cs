namespace Booking.Data;

public interface IDataLayer<T>
{
    List<T> Entities { get; set; }
    void Add(T newEntity);
}