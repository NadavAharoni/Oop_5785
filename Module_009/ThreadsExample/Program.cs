namespace ThreadsExample
{
    using System;
    using System.Threading;

    class ThreadSafeQueue
    {
        private Queue<long> queue = new Queue<long>();
        private Mutex mut = new Mutex();

        public bool enqueueInProgress = true;

        // arr is used for statistics
        public long[] arr = new long[1000];

        public long Count { get { return queue.Count; } }

        public void Enqueue(long value)
        {
            mut.WaitOne();
            queue.Enqueue(value);
            mut.ReleaseMutex();
        }

        public long Dequeue()
        {
            mut.WaitOne();
            long value = queue.Dequeue();
            mut.ReleaseMutex();

            return value;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main thread started");

            ThreadSafeQueue queue = new ThreadSafeQueue();

            // Create two threads

            // ThreadStart f1 = () => PushToQueue(queue);
            // ThreadStart f2 = () => PopFromQueue(queue);
            // Thread thread1 = new Thread(f1);
            // Thread thread2 = new Thread(f2);

            Thread thread1 = new Thread( () => PushToQueue(queue) );
            Thread thread2 = new Thread( () => PopFromQueue(queue) );

            // Start both threads
            thread1.Start();
            thread2.Start();

            // Wait for both threads to complete
            thread1.Join();
            Console.WriteLine("thread1 ended");
            thread2.Join();
            Console.WriteLine("thread2 ended");

            Console.WriteLine("Main thread ended");
        }

        static void PushToQueue(ThreadSafeQueue queue)
        {
            for (int i = 1; i <= 1000; i++)
            {
                queue.Enqueue(i);
            }
            Console.WriteLine($"PushToQueue: queue.Count={queue.Count}");
            queue.enqueueInProgress = false;
        }

        static void PopFromQueue(ThreadSafeQueue queue)
        {
            while (queue.enqueueInProgress || queue.Count > 0)
            {
                if (queue.Count > 0)
                {
                    long value = queue.Dequeue();
                    queue.arr[value-1] = queue.Count;
                }
            }

            // We don't print inside the loop, because printing
            // is an expensive operation
            for (int i = 0; i < queue.arr.Length; i++)
            {
                Console.WriteLine($"value={i}, queue.Count={queue.arr[i]}");
            }
        }
    }
}
