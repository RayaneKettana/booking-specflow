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
        var prev = Copy(Current.Item1, Current.Item2, Current.Item3);
        if (!Current.Item3.hasNext() & !Current.Item2.hasNext())
        {
            Current.Item1.next();
            Current.Item2.reset(); 
            Current.Item3.reset();
        } else if (!Current.Item3.hasNext())
        {
            Current.Item2.next();
            Current.Item3.reset();
        }
        else
        {
            Current.Item3.next();
        }

        return prev;
    }

    public bool hasNext()
    {
        return Current.Item1.hasNext() | Current.Item2.hasNext() | Current.Item3.hasNext();
    }

    public void reset()
    {
        Current.Item1.reset();
        Current.Item2.reset();
        Current.Item3.reset();
    }

    private static Registration Copy(PairLetter item1, TripletNumber item2, PairLetter item3)
    {
        return new Registration()
        {
            Current = new Tuple<PairLetter, TripletNumber, PairLetter>(
                PairLetter.Copy(item1.Current.Item1, item1.Current.Item2),
                TripletNumber.Copy(item2.Current),
                PairLetter.Copy(item3.Current.Item1, item3.Current.Item2)
            )
        };
    }

    public override string ToString()
    {
        return Current.Item1 + " " + Current.Item2 + " " + Current.Item3;
    }
    
}