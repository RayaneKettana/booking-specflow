namespace Booking;

public class PairLetter : ICounter<Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>>
{
    public Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>> Current { get; set; }

    public ICounter<Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>> next()
    {
        if (!Current.Item2.hasNext())
        {
            return Copy(Current.Item1.next(), Current.Item2.reset());
        }

        return Copy(Current.Item1, Current.Item2.next());
    }

    public bool hasNext()
    {
        return Current.Item1.hasNext() || Current.Item2.hasNext();
    }

    public ICounter<Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>> reset()
    {
        return Copy(Current.Item1.reset(), Current.Item2.reset());
    }
    private static PairLetter Copy(ICounter<LetterEnum> item1, ICounter<LetterEnum> item2)
    {
        return new PairLetter()
        {
            Current = new Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>(
                item1,
                item2
            )
        };
    }
    
}