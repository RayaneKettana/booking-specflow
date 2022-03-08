using Booking.Customer;

namespace Booking.Validator;

public static class Validator
{

    public static bool hasLincenceDriver(ICustomer customer)
    {
        if (customer.DatePermitObtained == null)
        {
            return false;
        }
        return true;
    }
    
    public static int isLegalAge(ICustomer customer)
    {
        return 1;
    }
}