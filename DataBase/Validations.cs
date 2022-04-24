using System;


namespace DataBase
{
    public static class Validations
    {
        public static int IntValidation(this string input)
        {
            int newInput;
            while (!int.TryParse(input, out newInput))
            {
                Console.WriteLine("Input is not an integer number, please repeat input");
                input = Console.ReadLine();
            }
            return newInput;
        }
        public static Guid GuidValidation(this string input)
        {
            Guid newInput;
            while(!Guid.TryParse(input,out newInput))
            {
                Console.WriteLine("Input is not in Guid Format, Try again");
                input = Console.ReadLine();
            }
            return newInput;
        }
    }
    
}
