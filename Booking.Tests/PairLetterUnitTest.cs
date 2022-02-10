using System;
using System.Linq;
using Booking.Registration;
using Xunit;

namespace Booking.Tests;

public class PairLetterUnitTest
{
    [Fact]
    public void pairLetterShouldStartAtAA()
    {
        PairLetter pairLetter = new PairLetter();
        assertPairLetter(pairLetter, LetterEnum.A, LetterEnum.A);
    }

    private static void assertPairLetter(PairLetter pairLetter, LetterEnum expecterItem1, LetterEnum expectedItem2)
    {
        Assert.Equal(expecterItem1, pairLetter.Current.Item1.Current);
        Assert.Equal(expectedItem2, pairLetter.Current.Item2.Current);
    }

    [Fact]
    public void letterShouldIncrement()
    {
        PairLetter pairLetter = new PairLetter();
        pairLetter.next();
        assertPairLetter(pairLetter,LetterEnum.A, LetterEnum.B);
        incrementBy(2, pairLetter);
        assertPairLetter(pairLetter,LetterEnum.A, LetterEnum.D);
        incrementBy(9, pairLetter);
        assertPairLetter(pairLetter,LetterEnum.A, LetterEnum.M);
        incrementBy(13, pairLetter);
        assertPairLetter(pairLetter,LetterEnum.A, LetterEnum.Z);
        pairLetter.next();
        assertPairLetter(pairLetter,LetterEnum.B, LetterEnum.A);
        incrementBy(26*10 + 4, pairLetter);
        assertPairLetter(pairLetter,LetterEnum.L, LetterEnum.E);
    }

    [Fact]
    public void pairLetterShouldNotIncrementAfterZZ()
    {
        PairLetter pairLetter = new PairLetter();
        incrementBy(26*25 + 25, pairLetter);
        assertPairLetter(pairLetter, LetterEnum.Z, LetterEnum.Z);
        pairLetter.next();
        assertPairLetter(pairLetter, LetterEnum.Z, LetterEnum.Z);
    }

    [Fact]
    public void pairLetterShouldReset()
    {
        PairLetter pairLetter = new PairLetter();
        incrementBy(26*25 + 25, pairLetter);
        assertPairLetter(pairLetter, LetterEnum.Z, LetterEnum.Z);
        pairLetter.reset();
        assertPairLetter(pairLetter, LetterEnum.A, LetterEnum.A); 
    }
    
    private static void incrementBy(int stepNumber, PairLetter pairLetter)
    {
        foreach (var i in Enumerable.Range(1, stepNumber))
        {
            pairLetter.next();
        }
    }
    
}