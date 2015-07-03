namespace task1
{
    using System;

    class SampleClassTest
    {
        public static void Main()
        {
            var classInstance = new SampleClass();

            classInstance.SampleClassMethod(true);
        }
    }

    class SampleClass
    {
        public void SampleClassMethod(bool input)
        {
            string inputAsString = input.ToString();

            Console.WriteLine(inputAsString);
        }
    }
}
