namespace Booking.Registration;

public class PairLetter : ICounter<Tuple<Letter, Letter>, PairLetter>
{
    public Tuple<Letter, Letter> Current { get; set; }

    public PairLetter()
    {
        Current = new Tuple<Letter, Letter>(
            new Letter(),
            new Letter()
        );
    }

    public PairLetter next()
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

    public PairLetter reset()
    {
        return Copy(Current.Item1.reset(), Current.Item2.reset());
    }
    private static PairLetter Copy(Letter item1, Letter item2)
    {
        return new PairLetter()
        {
            Current = new Tuple<Letter, Letter>(
                item1,
                item2
            )
        };
    }
    public override string ToString()
    {
        return Current.Item1.ToString() + Current.Item2.ToString();
        
    }
}