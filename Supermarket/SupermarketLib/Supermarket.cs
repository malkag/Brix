using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SupermarketLib
{
    public class Supermarket
    {
        private const int NUM_OF_CASHIERS = 5;
        private const int NUM_OF_BUYERS = 100;

        BuyersQueue _buyersQueue = new BuyersQueue();

        public void Start()
        {
            SetMiniumThreads(); //will fasten the process

            DateTime sTime = DateTime.Now;

            List<Cashier> cashires = Enumerable.Range(0, NUM_OF_CASHIERS).Select(x => new Cashier { ID = x + 1 }).ToList(); //init cashiers
            List<Task> tasks = cashires.Select(x => Task.Run(() => x.HandleQueue(_buyersQueue))).ToList(); //start a seperate task for each cashier
            tasks.Add(Task.Run(() => FillBuyerQueue(_buyersQueue))); //add a task for filling the buyers queue
            Task.WaitAll(tasks.ToArray());

            DateTime eTime = DateTime.Now;
            WriteTotalTimeToConsole(sTime, eTime);
        }


        private void SetMiniumThreads()
        {
            int minWorker, minIOC;
            // Get the current settings.
            ThreadPool.GetMinThreads(out minWorker, out minIOC);
            ThreadPool.SetMinThreads(NUM_OF_CASHIERS + 1, minIOC);
        }

        private async Task FillBuyerQueue(BuyersQueue BuyerQueue)
        {
            //In a "real" program we will check which Bbuyer finished his shopping, before adding him to the queue
            for (int i = 0; i <= NUM_OF_BUYERS; i++) 
            {
                await _buyersQueue.EnqueueBuyer(new Buyer() { FirstName = $"F{i}", LastName = $"L{i}", StartWaiting = DateTime.Now });
            }
            _buyersQueue.SignForNoMoreBuyers(); //must sign that there are no more buyers that can join the queue
        }

        private static void WriteTotalTimeToConsole(DateTime sTime, DateTime eTime)
        {
            TimeSpan total = eTime - sTime;
            Console.WriteLine($"All {NUM_OF_BUYERS} buyers were handled in {total.Duration()} by {NUM_OF_CASHIERS} cashiers.");
        }
    }
}
