namespace Booking;

public class PairLetter : ICounter<Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>>
{
    public Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>> Current { get; set; }

    public ICounter<Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>> next()
    {
        if (!Current.Item2.hasNext())
        {
            return new PairLetter()
            {
                Current = new Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>(
                    Current.Item1.next(),
                    Current.Item2.reset()
                )
            };
        }

        return new PairLetter()
        {
            Current = new Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>(
                Current.Item1,
                Current.Item2.next()
            )
        };

    }

    public bool hasNext()
    {
        return Current.Item1.hasNext() || Current.Item2.hasNext();
    }

    public ICounter<Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>> reset()
    {
        return new PairLetter()
        {
            Current = new Tuple<ICounter<LetterEnum>, ICounter<LetterEnum>>(
                Current.Item1.reset(),
                Current.Item2.reset()
            )
        };
    }
}