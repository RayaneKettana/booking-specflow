using System;
using System.Linq;
using Booking.Registration;
using Xunit;

namespace Booking.Tests;

public class RegistrationUnitTest
{
    [Fact]
    public void RegistrationShouldStartAtAA1AA()
    {
        var registration = new Registration.Registration();
        AssertRegistration(registration,
            LetterEnum.A,
            LetterEnum.A,
            1,
            LetterEnum.A,
            LetterEnum.A );
    }

    [Fact]
    public void registrationShouldIncrement()
    {
        var registration = new Registration.Registration();
        registration.next();
        AssertRegistration(registration,
            LetterEnum.A,
            LetterEnum.A,
            1,
            LetterEnum.A,
            LetterEnum.B );
        incrementBy(5, registration);
        AssertRegistration(registration,
            LetterEnum.A,
            LetterEnum.A,
            1,
            LetterEnum.A,
            LetterEnum.G );
        incrementBy(26*30, registration);
        AssertRegistration(registration,
            LetterEnum.A,
            LetterEnum.A,
            2,
            LetterEnum.E,
            LetterEnum.G );
        incrementBy(26*99999, registration);
        AssertRegistration(registration,
            LetterEnum.A,
            LetterEnum.D,
            848,
            LetterEnum.H,
            LetterEnum.G );
    }

    [Fact]
    public void registrationShouldReset()
    {
        var registration = new Registration.Registration();
        incrementBy(26*30, registration);
        registration.reset();
        AssertRegistration(registration,
            LetterEnum.A,
            LetterEnum.A,
            1,
            LetterEnum.A,
            LetterEnum.A );
    }
    
    private void AssertRegistration(Registration.Registration registration, LetterEnum item1, LetterEnum item2, int item3, LetterEnum item4, LetterEnum item5)
    {
        Assert.Equal(item1, registration.Current.Item1.Current.Item1.Current);
        Assert.Equal(item2, registration.Current.Item1.Current.Item2.Current);
        Assert.Equal(item3, registration.Current.Item2.Current);
        Assert.Equal(item4, registration.Current.Item3.Current.Item1.Current);
        Assert.Equal(item5, registration.Current.Item3.Current.Item2.Current);
    }

    private static void incrementBy(int stepNumber, Registration.Registration registration)
    {
        foreach (var i in Enumerable.Range(1, stepNumber))
        {
            registration.next();
        }
    }

}