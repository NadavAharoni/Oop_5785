namespace Generic
{
    internal class Program
    {
        struct Point : IComparable<Point>
        {
            public int x;
            public int y;

            public int CompareTo(Point other)
            {
                if (x == other.x)
                {
                    return y.CompareTo(other.y);
                }
                // else
                return x.CompareTo(other.x);
            }
        }

        public static void swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void SortTwo<T>(ref T a, ref T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }

        public static void swapObject(ref Object a, ref Object b)
        {
            Object temp = a;
            a = b;
            b = temp;
        }

        class Example1
        {
            public int value = 0;
        }
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;

            Console.WriteLine($"a={a}, b={b}");

            swap(ref a, ref b);

            Console.WriteLine($"a={a}, b={b}");

            SortTwo(ref a, ref b);

            Console.WriteLine($"After SortTwo: a={a}, b={b}");

            SortTwo(ref a, ref b);

            Console.WriteLine($"After the second SortTwo: a={a}, b={b}");

            double d1 = 1.2;
            double d2 = 2.3;

            Console.WriteLine($"d1.CompareTo(d2) = {d1.CompareTo(d2)}");

            Console.WriteLine($"d1={d1}, d2={d2}");

            // swap(ref d1, ref d2);
            SortTwo(ref d1, ref d2);

            Console.WriteLine($"After SortTwo(ref d1, ref d2):  d1={d1}, d2={d2}");

            SortTwo(ref d2, ref d1);

            Console.WriteLine($"After SortTwo(ref d2, ref d1): d1={d1}, d2={d2}");

            Point p1, p2;
            p1.x = 3;
            p1.y = 2;

            p2.x = 3;
            p2.y = 4;

            Console.WriteLine($"p1: {p1.x},{p1.y}");
            Console.WriteLine($"p2: {p2.x},{p2.y}");

            SortTwo<Point>(ref p2, ref p1);

            Console.WriteLine($"p1: {p1.x},{p1.y}");
            Console.WriteLine($"p2: {p2.x},{p2.y}");

            string s1 = "aaa", s2 = "bbb";
            Console.WriteLine($"s1.CompareTo(s2)={s1.CompareTo(s2)}");

            //Example1 example1_a = new Example1();
            //Example1 example1_b = new Example1();

            //example1_a.value = 1;
            //example1_b.value = 2;

            //Console.WriteLine($"example1_a={example1_a.value}, example1_b={example1_b.value}");

            //swap(ref example1_a, ref example1_b);

            //Console.WriteLine($"example1_a={example1_a.value}, example1_b={example1_b.value}");

            //GenericContainer<Example1> container = new GenericContainer<Example1>();
            //container.Store(example1_b);

            //Example1? e = container.Retrieve();
        }

        class Container
        {
            private Object? _item = null;

            public void Store(Object item)
            {
                _item = item;
            }

            public Object? Retrieve()
            {
                return _item;
            }
        }

        class GenericContainer<T>
        {
            private T? _item;

            public void Store(T item)
            {
                _item = item;
            }

            public T? Retrieve()
            {
                return _item;
            }
        }
    }
}
