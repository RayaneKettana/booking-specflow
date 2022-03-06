namespace Booking.Booking;

public interface IEntity
{
    Guid Id { get; }
    bool Equals(Object obj);
    int GetHashCode();
}