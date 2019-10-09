using System;

namespace SupermarketLib
{
    public class Buyer
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public DateTime StartWaiting { get; set; }
        public DateTime? EndWaiting { get; set; }
        public TimeSpan? WaitingTime
        {
            get { return !EndWaiting.HasValue ? null : EndWaiting - StartWaiting; }
        }
       
        public override string ToString()
        {
            return $"\"{FirstName} {LastName}\"";
        }
    }
}
