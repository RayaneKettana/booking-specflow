using Booking.Customer;

namespace Booking.Validator;

public static class Validator
{

    private static bool hasLincenceDriver(ICustomer customer)
    {
        if (customer.DatePermitObtained == null)
        {
            return false;
        }
        return true;
    }
    
    private static int customerOld(ICustomer customer)
    {
        var dateNow = DateOnly.FromDateTime(DateTime.Now);
        return dateNow.Year - customer.Birthday.Year;
    }
    
    public static bool canBookACar(ICustomer customer, Car.Car car)
    {
        if (!hasLincenceDriver(customer) || customerOld(customer) < 18)
        {
            return false;
        }

        if (customerOld(customer) < 21 && car.Cv >= 8)
        {
            return false;
        }
        
        if ((customerOld(customer) >= 21 && customerOld(customer) <= 25) && car.Cv >= 13)
        {
            return false;
        }

        return true;
    }
    
}