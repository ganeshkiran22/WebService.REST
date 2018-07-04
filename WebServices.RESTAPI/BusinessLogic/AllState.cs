using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebService.RESTAPI
{
    public class AllState : IAllState
    {
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string Capital { get; private set; }
        public string LargestCity { get; private set; }
        public string ErrorInfo { get; private set; }

        /// <summary>
        /// Returns the list of All state object built from JSON response
        /// </summary>
        /// <returns>_states</returns>
        public List<AllState> GetAllStatesInfo()
        {
            // Consuming RESTful API with Http client request handler
            IRequestHandler httpClientRequestHandler = new HttpClientRequestHandler();

            //Build All States list at once
            var allStates = GetAllStateResponse(httpClientRequestHandler);
            List<AllState> _states = new List<AllState>();

            foreach (var jToken in allStates.Children())
            {
                var result = (JObject)jToken;
                _states.Add(new AllState
                {
                    Abbreviation = result.GetValue("abbr").ToString() == null ? "" : result.GetValue("abbr").ToString(),
                    Capital = result.GetValue("capital").ToString() == null ? "" : result.GetValue("capital").ToString(),
                    LargestCity = result.GetValue("largest_city") == null ? "" : result.GetValue("largest_city").ToString(),
                    Name = result.GetValue("name").ToString() == null ? "" : result.GetValue("name").ToString()
                });
            }

            return _states;
        }

        /// <summary>
        /// Searches for Largest city and Capital based on State name or abbreviation
        /// </summary>
        /// <param name="searchState"></param>
        public void SearchLargestCityAndCapital(string searchState)
        {
            string _userInput = searchState;
            while (_userInput != String.Empty)
            {
                // Check if _User input is null to break the looping.
                // This logic is used to wait for user input. When user is done with search - Enter key press will result in console window closure.
                //ToDo: Alternate logic could be do ask user to press 'ESC' key and then handle it to close the Environment.
                if (_userInput == null)
                {
                    break;
                }

                //// If user is intending to close
                //if (_userInput.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
                //{
                //    Environment.Exit(0);
                //}

                // Iterate through states list and look for user input match 
                var _result = GetAllStatesInfo().Where(x => x.Name.Equals(_userInput, StringComparison.CurrentCultureIgnoreCase) || x.Abbreviation.Equals(_userInput, StringComparison.CurrentCultureIgnoreCase));
                if (_result != null && _result.Count() > 0)
                {
                    this.LargestCity = _result.FirstOrDefault().LargestCity;
                    this.Capital = _result.FirstOrDefault().Capital;
                    Console.WriteLine("Largest City: {0}", this.LargestCity);
                    Console.WriteLine("Capital: {0}", this.Capital);
                    _userInput = Console.ReadLine();
                }
                else
                {
                    ErrorInfo = "Invalid User Input, Enter Valid State Name or Press Q + Enter to close";
                    Console.WriteLine(this.ErrorInfo);
                    _userInput = Console.ReadLine();

                }
            }
        }

        private JToken GetAllStateResponse(IRequestHandler requestHandler)
        {
            return requestHandler.GetAllStateResponse(HttpClientRequestHandler.Url);
        }
    }
}
