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
        var prev = Copy(Current.Item1, Current.Item2);
        if (!Current.Item2.hasNext())
        {
            Current.Item1.next();
            Current.Item2.reset();
        }

        Current.Item2.next();
        return prev;
    }

    public bool hasNext()
    {
        return Current.Item1.hasNext() || Current.Item2.hasNext();
    }

    public PairLetter reset()
    {
        return Copy(Current.Item1.reset(), Current.Item2.reset());
    }
    public static PairLetter Copy(Letter item1, Letter item2)
    {
        return new PairLetter()
        {
            Current = new Tuple<Letter, Letter>(
                Letter.Copy(item1.Current),
                Letter.Copy(item2.Current)
            )
        };
    }
    public override string ToString()
    {
        return Current.Item1.ToString() + Current.Item2.ToString();
        
    }
}