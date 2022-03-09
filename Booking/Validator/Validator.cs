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
    
    private static int getAge(DateOnly birthday)
    {
        var dateNow = DateOnly.FromDateTime(DateTime.Now);
        return dateNow.Year - birthday.Year;
    }
    
    public static bool canBookACar(ICustomer customer, Car.Car car)
    {
        if (!hasLincenceDriver(customer) || getAge(customer.Birthday) < 18)
        {
            return false;
        }

        if (getAge(customer.Birthday) < 21 && car.Cv >= 8)
        {
            return false;
        }
        
        if ((getAge(customer.Birthday) >= 21 && getAge(customer.Birthday) <= 25) && car.Cv >= 13)
        {
            return false;
        }

        return true;
    }
    
}