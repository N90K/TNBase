using System.Collections.Generic;

namespace TNBase.Objects
{
    public class IListener : IComparer<Listener>
    {
        public int Compare(Listener x, Listener y)
        {
            return string.Compare(x.Surname, y.Surname);
        }
    }


    public class INumbListener : IComparer<Listener>
    {
        public int Compare(Listener x, Listener y)
        {
            return x.Wallet.CompareTo(y.Wallet);
        }
    }
}