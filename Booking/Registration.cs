namespace Booking;

public class Registration : ICounter<Tuple<ICounter<LetterEnum>, ICounter<int>, ICounter<LetterEnum>>>
{
    public Tuple<ICounter<LetterEnum>, ICounter<int>, ICounter<LetterEnum>> Current { get; set; }

    public ICounter<Tuple<ICounter<LetterEnum>, ICounter<int>, ICounter<LetterEnum>>> next()
    {
        if (!Current.Item3.hasNext() && !Current.Item2.hasNext())
        {
            return Copy(Current.Item1.next(), Current.Item2.reset(), Current.Item3.reset());
        }
        if (!Current.Item3.hasNext() && !Current.Item2.hasNext())
        {
            return Copy(Current.Item1, Current.Item2.next(), Current.Item3.reset());
        }

        return Copy(Current.Item1, Current.Item2, Current.Item3.next());
    }

    public bool hasNext()
    {
        return Current.Item1.hasNext() || Current.Item2.hasNext() || Current.Item3.hasNext();
    }

    public ICounter<Tuple<ICounter<LetterEnum>, ICounter<int>, ICounter<LetterEnum>>> reset()
    {
        return Copy(Current.Item1.reset(), Current.Item2.reset(), Current.Item3.reset());
    }

    private static Registration Copy(ICounter<LetterEnum> item1, ICounter<int> item2, ICounter<LetterEnum> item3)
    {
        return new Registration()
        {
            Current = new Tuple<ICounter<LetterEnum>, ICounter<int>, ICounter<LetterEnum>>(
                item1,
                item2,
                item3
            )
        };
    }
    
}