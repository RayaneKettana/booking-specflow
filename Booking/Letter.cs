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
        return new Letter
       {
        Current   = (LetterEnum)nextIndex
       };
    }

    public bool hasNext()
    {
        return Current != LetterEnum.Z;
    }

    public ICounter<LetterEnum> reset()
    {
        return new Letter()
        {
            Current = LetterEnum.A
        };
    }

}