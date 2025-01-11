using System.Runtime.Intrinsics.X86;

namespace GenericStack
{
    class MyClass
    {
        private int i;
        public MyClass(int i)
        {
            this.i = i;
        }
    }

    struct MyStruct
    {
        private int i = 1000;
        public MyStruct(int i)
        {
            this.i = i;
        }

        public override string ToString()
        {
            return i.ToString();
        }
    }

    public class StackException : Exception
    {
        private int _stackNum;
        // private T Value = default;
        public StackException(string message, int num) : base(message)
        {
            _stackNum = num;
        }

        public int getNum()
        {
            return _stackNum;
        }
    }

    class StackCounter
    {
        protected static int _stackCounter = 0;
    }

    class Stack<T> : StackCounter
    {
        private T[] _arr;
        private int _index;
        private int _myNumber;


        public Stack(int size)
        {
            _arr = new T[size];
            _index = 0;
            _myNumber = _stackCounter++;

            Console.WriteLine($"inside public Stack(int size) _stackCounter={_stackCounter}");
        }
        public void Pop()
        {
            _index--;
        }
        public void Push(T x)
        {
            _arr[_index++] = x;
        }
        public T Top() 
        {
            // return _arr[_index - 1];

            if (_index > 0)
            {
                return _arr[_index - 1];
            }
            // else
            throw new StackException($"Top function failed because index = {_index}", _myNumber);
        }

        public int Count()
        {
            return _index;
        }
    }
    internal class Program
    {
        static void f1()
        {
            Stack<double> s1 = new Stack<double>(10);
            s1.Push(1.23);
            Console.WriteLine($"s1.Top()={s1.Top()}");
            s1.Push(2.34);
            Console.WriteLine($"s1.Top()={s1.Top()}");
            s1.Pop();
            Console.WriteLine($"s1.Top()={s1.Top()}");
            s1.Pop();
            Console.WriteLine($"s1.Top()={s1.Top()}");
        }

        static void f2()
        {
            Stack<MyClass> s2 = new Stack<MyClass>(10);
            MyClass m = s2.Top();
            if (m == null)
            {
                Console.WriteLine("s2.Top() is null");
            }
            else
            {
                Console.WriteLine($"s2.Top()={s2.Top()}");
            }

            Stack<MyStruct> s3 = new Stack<MyStruct>(10);
            if (s3.Count() > 0)
            {
                MyStruct s = s3.Top();
                Console.WriteLine($"top of s3 ={s}");
            }
            MyStruct my1 = new MyStruct(123);
        }
        
        static int f3(int d)
        {
            return 1 / d;
        }

        static void Main(string[] args)
        {
            try
            {
                f3(0);
                f1();
            }
            catch (StackException e)
            {
                Console.WriteLine($"error: {e.Message}, stack: {e.getNum()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"error: {e}");
            }

            Console.WriteLine("---------------------");

            try
            {
                f2();
            }
            catch (StackException e)
            {
                Console.WriteLine($"error: {e.Message}, stack: {e.getNum()}");
            }
        }
    }
}
