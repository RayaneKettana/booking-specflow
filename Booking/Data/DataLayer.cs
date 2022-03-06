using Booking.Booking;
using Booking.Car;

namespace Booking.Data;

public class DataLayer <T> : IDataLayer<T> where T : IEntity
{
    public List<T> Entities { get; set; }
    
    public DataLayer()
    {
        Entities = new List<T>();
    }

    public T Add(T newEntity)
    {
        Entities.Add(newEntity);
        return newEntity;
    }

    public T Update(T updatedEntity)
    {
        Entities = Entities.Where(entity => !entity.Equals(updatedEntity)).ToList();
        Entities.Add(updatedEntity);
        return updatedEntity;
    }

    public T? Get(Guid id)
    {
        return Entities.FirstOrDefault(entity => entity.Id.Equals(id));
    }
}