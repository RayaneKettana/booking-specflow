using Booking.Booking;
using Booking.Data;

namespace Booking.Seed;

public class FakeData<T> : IDataLayer<T> where T : IEntity
{
    public List<T> Entities { get; set; }

    public FakeData(List<T> entities)
    {
        Entities = entities;
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