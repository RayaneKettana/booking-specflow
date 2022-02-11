namespace Booking.Data;

public class DataLayer <T> : IDataLayer<T>
{
    public List<T> Entities { get; set; }
    
    public DataLayer()
    {
        Entities = new List<T>();
    }

    public void Add(T newEntity)
    {
        Entities.Add(newEntity);
    }
    
}