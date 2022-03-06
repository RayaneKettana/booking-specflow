using Booking.Booking;

namespace Booking.Data;

public interface IDataLayer<T> where T : IEntity
{
    List<T> Entities { get; set; }
    T Add(T newEntity);
    T Update(T updatedEntity);
    T? Get(Guid id);
}