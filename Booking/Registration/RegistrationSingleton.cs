namespace Booking.Registration;

public class RegistrationSingleton
{
    private static Registration? _instance;

    public static Registration GetInstance()
    {
        return _instance ??= new Registration(); 
    }

}