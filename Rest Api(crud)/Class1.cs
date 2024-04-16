using System;

public class Class1
{
	public Class1()
	{
        static void Main(string[] args)
        {
            // Task A: Format string with dash between characters
            string x = "abca";
            string y = string.Join("-", x);
            Console.WriteLine(y);

        }
}
