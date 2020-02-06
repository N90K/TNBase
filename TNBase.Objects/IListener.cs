namespace TNBase.Objects
{
    // Used for sorting the Listeners.
    public class IListener : System.Collections.Generic.IComparer<Listener>
    {
        // Compare function for sorting in list.
        public int Compare(Listener x, Listener y)
        {
            return string.Compare(x.Surname, y.Surname);
        }
    }


    // Used for sorting the Listeners.
    public class INumbListener : System.Collections.Generic.IComparer<Listener>
    {
        // Compare function for sorting in list.
        public int Compare(Listener x, Listener y)
        {
            return x.Wallet.CompareTo(y.Wallet);
        }
    }
}