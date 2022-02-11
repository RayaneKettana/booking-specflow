using Booking.Data;

namespace Booking.Seed;

public class FakeData<T> : IDataLayer<T>
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
}