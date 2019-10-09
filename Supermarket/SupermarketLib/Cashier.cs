using System;
using System.Threading.Tasks;

namespace SupermarketLib
{
    public class Cashier
    {
        private const string TIME_FORMAT = "HH:mm:ss.fffffff";
        private static readonly Random _random = new Random();

        public int ID { get; set; }

        public async Task HandleQueue(BuyersQueue buyersQueue)
        {
            Console.WriteLine($"{ToString()} started working");

            bool stillHasBuyers = true;
            while (stillHasBuyers)
            {
                Buyer buyer = buyersQueue.DequeueCutomer(); //dequeue a buyer
                if (buyer != null)
                    await HandleBuyer(buyer);
                else if (buyersQueue.HasNoMoreBuyers) //no more buyers in the supermarket
                    stillHasBuyers = false;
            }

            Console.WriteLine($"{ToString()} ended working");
        }

        private async Task HandleBuyer(Buyer buyer)
        {
            buyer.EndWaiting = DateTime.Now;
            Console.WriteLine($"{buyer.ToString()} waited {buyer.WaitingTime.Value.Ticks} ticks ({buyer.StartWaiting.ToString(TIME_FORMAT)}-{buyer.EndWaiting.Value.ToString(TIME_FORMAT)}), is currently handled by {ToString()}");
            int rand = _random.Next(1, 5);
            await Task.Delay(rand*1000); //"handeling" Buyer

            Console.WriteLine($"Handling {buyer.ToString()} took {rand} seconds");
        }

        public override string ToString()
        {
            return $"Cashier #{ID}";
        }
    }
}
