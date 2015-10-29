namespace StackImplementation
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var stack = new MyStack<int>();

            stack.Push(12);
            stack.Push(50);
            Console.WriteLine("Pop: " + stack.Pop());

            stack.Push(-115);
            stack.Push(65);
            stack.Push(22);
            Console.WriteLine("Peek: " + stack.Peek());

            stack.Push(512);
            stack.Push(602);
            stack.Push(16);
            Console.WriteLine("Pop: " + stack.Pop());

            Console.WriteLine(string.Join(" -> ", stack));
        }
    }
}
