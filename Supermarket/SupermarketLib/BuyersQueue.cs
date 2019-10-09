using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketLib
{
    public class BuyersQueue
    {
        private readonly object _lockingObject = new object();
        private Queue<Buyer> _buyersQueue = new Queue<Buyer>();
        private bool _noMoreBuyers = false;

        public async Task EnqueueBuyer(Buyer Buyer)
        {
            lock (_lockingObject)
            {
                _buyersQueue.Enqueue(Buyer);
                Console.WriteLine($"Enqueued {Buyer}");
            }
            await Task.Delay(1 * 1000);
        }

        public Buyer DequeueCutomer()
        {
            lock (_lockingObject)
            {
                return (_buyersQueue.Any()) ?
                     _buyersQueue.Dequeue() :
                     null;
            }
        }

        public void SignForNoMoreBuyers()
        {
            _noMoreBuyers = true;
        }

        public bool HasNoMoreBuyers

        {
            get
            { 
                if (!_noMoreBuyers) return false; //while not flagged as "no more buyers", return false
                lock (_lockingObject) //even when flagged, must check first if the queue already empty, else must handle the buyers in queue
                {
                    return !_buyersQueue.Any();
                }
            }
        }

    }
}
