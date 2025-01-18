internal class Program
{
    delegate void delegate1(int item);
    static void Sum(ref long sum, int item)
    { 
        sum += item;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        int[] numbers = { 1, 2, 3, 4, 5 };
        var sumCalculator = new SumCalculator();

        ArrayProcessor.ProcessArray(numbers, sumCalculator.AddToSum);

        int totalSum = sumCalculator.GetSum(); // Returns 15
        Console.WriteLine($"Total sum: {totalSum}");

        long sum1 = 0;
        Action<int> f1 = (int item) => { Sum(ref sum1, item); };
        ArrayProcessor.ProcessArray(numbers, f1);
        Console.WriteLine($"Total sum 2: {totalSum}");
    }
}
