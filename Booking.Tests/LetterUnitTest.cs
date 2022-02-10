using System;
using System.Linq;
using Booking.Registration;
using Xunit;

namespace Booking.Tests;

public class LetterUnitTest
{
    [Fact]
    public void letterShouldStartAtA()
    {
        var letter = new Letter();
        Assert.Equal(LetterEnum.A,letter.Current);
    }

    [Fact]
    public void letterShouldIncrement()
    {
        var letter = new Letter();
        letter.next();
        Assert.Equal(LetterEnum.B, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.C, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.D, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.E, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.F, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.G, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.H, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.I, letter.Current );
        letter.next();
        Assert.Equal(LetterEnum.J, letter.Current );
    }

    [Fact]
    public void letterShouldNotIncrementAfterZ()
    {
        var letter = new Letter();
        foreach (var i in Enumerable.Range(1,25))
        {
            letter.next();
        }
        Assert.Equal(LetterEnum.Z, letter.Current);
        letter.next();
        Assert.Equal(LetterEnum.Z, letter.Current);
    }
    
    [Fact]
    public void letterShouldReset()
    {
        var letter = new Letter();
        foreach (var i in Enumerable.Range(1,25))
        {
            letter.next();
        }
        Assert.Equal(LetterEnum.Z, letter.Current);
        letter.reset();
        Assert.Equal(LetterEnum.A, letter.Current);
    }
}