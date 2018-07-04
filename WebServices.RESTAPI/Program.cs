using System;
namespace WebService.RESTAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of all state class
            AllState allState = new AllState();
            
            // Ask for user input            
            Console.WriteLine("Please enter the United States Name or Abbreviation");
            string userInput = Console.ReadLine();
            allState.SearchLargestCityAndCapital(userInput);            
        }
    }   
}
