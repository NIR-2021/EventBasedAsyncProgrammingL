public class ThreasholdReachedEventArgs : EventArgs
{
    public int threashold { get; set; }
    public DateTime dateTime { get; set; }
}

public class ClassWithEvent
{
    public int counter = 0;
    public int _threashold { get; set; }
    public ClassWithEvent(int threashold) { 
        _threashold = threashold;
    }
    
    public void addOne()
    {
        counter++;
        if(counter > _threashold)
        {
            ThreasholdReachedEventArgs threashold = new() ;
            threashold.dateTime = DateTime.Now ;
            threashold.threashold = _threashold;
            OnThreasholdReached(threashold);
        }
    }

    public void OnThreasholdReached(ThreasholdReachedEventArgs e)
    {
        EventHandler<ThreasholdReachedEventArgs> handler = threasholdReachedEventArgs;
        if(handler != null )
        {
            handler(this, e);
        }
        else
        {
            Console.WriteLine("No subscriber for Threashold reached event");
        }
    }

    public event EventHandler<ThreasholdReachedEventArgs> threasholdReachedEventArgs;

}


class Program
{
    public static void Main(string[] args)
    {
        ClassWithEvent c = new ClassWithEvent(6);
        //c.threasholdReachedEventArgs += c_threasholdReachedEventArgs;

        Console.WriteLine("Press a key to add one more.");
        while(Console.ReadKey(true).KeyChar == 'a')
        {
            Console.WriteLine("adding one more.");
            c.addOne();
        }
    }

    public static void c_threasholdReachedEventArgs(object sender, ThreasholdReachedEventArgs e)
    {
        Console.WriteLine($"Threashold of {e.threashold} at {e.dateTime}.");
    }
}