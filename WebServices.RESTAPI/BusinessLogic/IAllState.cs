using System.Collections.Generic;

namespace WebService.RESTAPI
{
    public interface IAllState
    {
        /// <summary>
        /// Method to search Largest City and Capital based on Name Or Abbreviation
        /// <param name="searchState"></param>        
        /// </summary>
        void SearchLargestCityAndCapital(string searchState);

        /// <summary>
        /// Method to build all states info
        /// <param name="userInput"></param>        
        /// </summary>
        List<AllState> GetAllStatesInfo();

        /// <summary>
        /// Property to read and write Largest City for the user entered state
        /// </summary>
        string LargestCity { get; }

        /// <summary>
        /// Property to read and write Capital of the user entered state 
        /// </summary>
        string Capital { get; }

        /// <summary>
        /// Property to read and write Abbrevation of the state         
        /// </summary>
        string Abbreviation { get; }

        /// <summary>
        /// Proeprty to read and write state Name        
        /// </summary>
        string Name { get; }

        string ErrorInfo { get; }
    }
}
