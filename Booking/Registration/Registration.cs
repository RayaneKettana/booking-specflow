namespace Booking.Registration;

public class Registration : ICounter<Tuple<PairLetter, TripletNumber, PairLetter>, Registration>
{
    public Tuple<PairLetter, TripletNumber, PairLetter> Current { get; set; }

    public Registration()
    {
        Current = new Tuple<PairLetter, TripletNumber, PairLetter>(
            new PairLetter(),
            new TripletNumber(),
            new PairLetter()
        );
    }

    public Registration next()
    {
        if (!Current.Item3.hasNext() && !Current.Item2.hasNext())
        {
            return Copy(Current.Item1.next() as PairLetter, Current.Item2.reset() as TripletNumber, Current.Item3.reset() as PairLetter);
        }
        if (!Current.Item3.hasNext() && !Current.Item2.hasNext())
        {
            return Copy(Current.Item1, Current.Item2.next() as TripletNumber, Current.Item3.reset() as PairLetter);
        }

        return Copy(Current.Item1, Current.Item2, Current.Item3.next() as PairLetter);
    }

    public bool hasNext()
    {
        return Current.Item1.hasNext() || Current.Item2.hasNext() || Current.Item3.hasNext();
    }

    public Registration reset()
    {
        return Copy((PairLetter) Current.Item1.reset(), (TripletNumber) Current.Item2.reset(), (PairLetter) Current.Item3.reset());
    }

    private static Registration Copy(PairLetter item1, TripletNumber item2, PairLetter item3)
    {
        return new Registration()
        {
            Current = new Tuple<PairLetter, TripletNumber, PairLetter>(
                item1,
                item2,
                item3
            )
        };
    }

    public override string ToString()
    {
        return Current.Item1 + " " + Current.Item2 + " " + Current.Item3;
    }
    
}