namespace Booking.Registration;

public enum LetterEnum
{
    A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
}
public class Letter : ICounter<LetterEnum, Letter>
{
    public LetterEnum Current { get; set; } = LetterEnum.A;
    
    public Letter next()
    {
        var prev = Copy(Current);
        if (Current != LetterEnum.Z)
        {
            var nextIndex = ((int) Current) + 1;
            Current =  (LetterEnum) nextIndex;
        }
        return prev;
    }

    public bool hasNext()
    {
        return Current != LetterEnum.Z;
    }

    public void reset()
    {
        Current = LetterEnum.A;
    }

    public static Letter Copy(LetterEnum letterEnum)
    {
        return new Letter()
        {
            Current = letterEnum
        };
    }

    public override string ToString()
    {
        return Current.ToString();
    }
}