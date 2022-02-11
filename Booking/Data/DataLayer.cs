namespace Booking.Data;

public class DataLayer <T> : IDataLayer<T>
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
    
}