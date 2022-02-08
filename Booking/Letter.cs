namespace Booking;

public enum LetterEnum
{
    A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
}
public class Letter : ICounter<LetterEnum>
{
    public LetterEnum Current { get; set; }
    
    public ICounter<LetterEnum> next()
    {
        var nextIndex = ((int) Current) + 1;
        return Copy((LetterEnum) nextIndex);
    }

    public bool hasNext()
    {
        return Current != LetterEnum.Z;
    }

    public ICounter<LetterEnum> reset()
    {
        return Copy(LetterEnum.A);
    }

    private static Letter Copy(LetterEnum letterEnum)
    {
        return new Letter()
        {
            Current = letterEnum
        };
    }
}