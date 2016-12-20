using System.Collections.Generic;

namespace PrettyHair
{
    public class Inbox
    {
        public int NumReceivedMessages { get; internal set; }

        List<string> emails = new List<string>();

        internal void Add(Email o)
        {
            NumReceivedMessages++;
            emails.Add(o.Content);
        }

        internal string GetLatestMessageText()
        {
            return emails[(emails.Count) - 1];
        }
    }
}
