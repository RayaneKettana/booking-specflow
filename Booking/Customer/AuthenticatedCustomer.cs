using System.Timers;
using Timer = System.Timers.Timer;

namespace Booking.Customer;

public class AuthenticatedCustomer : CustomerDecorator
{
   private readonly Timer timer;
   private bool IsConnected = true;

   public AuthenticatedCustomer(ICustomer customer) : base(customer)
   {
      timer = new System.Timers.Timer(2000000);
      timer.Elapsed += Disconnect;
      timer.AutoReset = false;
      timer.Enabled = true;
   }

   public void Disconnect(object? sender, ElapsedEventArgs e)
   {
      IsConnected = false;
   }

   public void Disconnect()
   {
      IsConnected = false;
   }
   public bool isConnected()
   {
      return IsConnected;
   }
    
}