using System.Collections.Generic;
using NUnit.Framework;


namespace WebService.RESTAPI.Test
{
    [TestFixture]
    public class AllStateTest
    {
        private IAllState _allState;

        [SetUp]
        public void Setup()
        {
            // Instantiate class under test for every test case
            _allState = new AllState();
        }

        [TearDown]
        public void TearDown()
        {

        }

        // Note: 5 tests will fail since largest city is not implemented for American samoa, Guam, Northern Mariana Islands, Puerto Rico,U.S. Virgin Islands
        [Test, TestCaseSource("StateByName")]
        [Description("Verify user entered state Name or Abbrevation returns corresponding Largest city and Capital")]
        public void ValidSearchLargestCityAndCapitalByNameTest(string searchState, string expectedLargestCity, string expectedCapital)
        {
            _allState.SearchLargestCityAndCapital(searchState);
            Assert.AreEqual(expectedLargestCity, _allState.LargestCity);
            Assert.AreEqual(expectedCapital, _allState.Capital);
        }

        [TestCase("alabama", "Birmingham", "Montgomery", Description = "Single word all lower case letters")]
        [TestCase("ALABAMA", "Birmingham", "Montgomery", Description = "Single word all upper case letters")]
        [TestCase("AlAbAmA", "Birmingham", "Montgomery", Description = "Single word mixed case letters")]
        [TestCase("NEW york", "New York City", "Albany", Description = "First word Upper and second word lower letter")]
        [Description("Verify case change is not having impact on search result")]
        public void ValidSearchLargestCityAndCapitalByDifferentCaseNameTest(string searchState, string expectedLargestCity, string expectedCapital)
        {
            _allState.SearchLargestCityAndCapital(searchState);
            Assert.AreEqual(expectedLargestCity, _allState.LargestCity);
            Assert.AreEqual(expectedCapital, _allState.Capital);
        }

        [TestCase("Albama", Description = "Typo in search case")]
        [TestCase(" Alabama", Description = "Leading Space with search state")]
        [TestCase("West Virginia ", Description = "Trailing space with search state")]
        [TestCase("New York City", Description = "Search with symmetrical name as state")]
        [Description("Verify invalid search string will return error message to user")]
        public void InValidSearchLargestCityAndCapitalByNameTest(string searchState)
        {
            _allState.SearchLargestCityAndCapital(searchState);
            Assert.AreEqual("Invalid User Input, Enter Valid State Name or Press Q + Enter to close", _allState.ErrorInfo);
            Assert.IsNull(_allState.LargestCity);
            Assert.IsNull(_allState.Capital);
        }

        [Test]
        [Description("Verify empty search string will result in null reference for ErrorInfo, LargestCity, Capital")]
        public void EmptySearchLargestCityAndCapitalByNameTest()
        {
            _allState.SearchLargestCityAndCapital("");
            Assert.IsNull(_allState.ErrorInfo);
            Assert.IsNull(_allState.LargestCity);
            Assert.IsNull(_allState.Capital);
        }

        // Note: 5 tests will fail since largest city is not implemented for American samoa, Guam, Northern Mariana Islands, Puerto Rico,U.S. Virgin Islands
        [Test, TestCaseSource("StateByAbbreviation")]
        [Description("Verify user entered state Name or Abbrevation returns corresponding Largest city and Capital")]
        public void ValidSearchLargestCityAndCapitalByAbbreviationTest(string searchState, string expectedLargestCity, string expectedCapital)
        {
            _allState.SearchLargestCityAndCapital(searchState);
            Assert.AreEqual(expectedLargestCity, _allState.LargestCity);
            Assert.AreEqual(expectedCapital, _allState.Capital);
        }

        [TestCase("ok", "Oklahoma City", "Oklahoma City", Description = "All lower case letters")]
        [TestCase("OK", "Oklahoma City", "Oklahoma City", Description = "All upper case letters")]
        [Description("Verify case change is not having impact on search result")]
        public void ValidSearchLargestCityAndCapitalByDifferentCaseAbbreviationTest(string searchState, string expectedLargestCity, string expectedCapital)
        {
            _allState.SearchLargestCityAndCapital(searchState);
            Assert.AreEqual(expectedLargestCity, _allState.LargestCity);
            Assert.AreEqual(expectedCapital, _allState.Capital);
        }

        [TestCase("OKL", Description = "Typo in search case")]
        [TestCase(" OK", Description = "Leading Space with search state")]
        [TestCase("OK ", Description = "Trailing space with search state")]
        [TestCase("O K", Description = "Space between character")]
        [Description("Verify invalid search string will return error message to user")]
        public void InValidSearchLargestCityAndCapitalByAbbreviationTest(string searchState)
        {
            _allState.SearchLargestCityAndCapital(searchState);
            Assert.AreEqual("Invalid User Input, Enter Valid State Name or Press Q + Enter to close", _allState.ErrorInfo);
            Assert.IsNull(_allState.LargestCity);
            Assert.IsNull(_allState.Capital);
        }

        [Test, TestCaseSource("AllStatesInfo")]
        [Description("Verify all states Name, Abbreviation, Largest city, Capital matches")]
        public void GetAllStatesInfoTest(int index, string expectedName, string expectedAbbreviation, string expectedLargestCity, string expectedCapital)
        {
            List<AllState> _allStatesList = _allState.GetAllStatesInfo();

            foreach (AllState item in _allStatesList)
            {
                Assert.AreEqual(expectedName, _allStatesList[index-1].Name);
                Assert.AreEqual(expectedAbbreviation, _allStatesList[index - 1].Abbreviation);
                Assert.AreEqual(expectedLargestCity, _allStatesList[index - 1].LargestCity);
                Assert.AreEqual(expectedCapital, _allStatesList[index - 1].Capital);
            }
        }

        #region Test Data

        // Test data for ValidSearchLargestCityAndCapitalByNameTest
        static object[] StateByName = {
            new string [] { "Alabama", "Birmingham","Montgomery" },
            new string [] {"Alaska","Anchorage","Juneau" },
            new string [] {"Arizona","Phoenix","Phoenix" },
            new string [] {"Arkansas","Little Rock","Little Rock" },
            new string [] {"California","Los Angeles","Sacramento" },
            new string [] {"Colorado","Denver","Denver" },
            new string [] {"Connecticut","Bridgeport","Hartford" },
            new string [] {"Delaware","Wilmington","Dover" },
            new string [] {"Florida","Jacksonville","Tallahassee" },
            new string [] {"Georgia","Atlanta","Atlanta" },
            new string [] {"Hawaii","Honolulu","Honolulu" },
            new string [] {"Idaho","Boise","Boise" },
            new string [] {"Illinois","Chicago","Springfield" },
            new string [] {"Indiana","Indianapolis","Indianapolis" },
            new string [] {"Iowa","Des Moines","Des Moines" },
            new string [] {"Kansas","Wichita","Topeka" },
            new string [] {"Kentucky","Louisville","Frankfort" },
            new string [] {"Louisiana","New Orleans","Baton Rouge" },
            new string [] {"Maine","Portland","Augusta" },
            new string [] {"Maryland","Baltimore","Annapolis" },
            new string [] {"Massachusetts","Boston","Boston" },
            new string [] {"Michigan","Detroit","Lansing" },
            new string [] {"Minnesota","Minneapolis","St. Paul" },
            new string [] {"Mississippi","Jackson","Jackson" },
            new string [] {"Missouri","Kansas City","Jefferson City" },
            new string [] {"Montana","Billings","Helena" },
            new string [] {"Nebraska","Omaha","Lincoln" },
            new string [] {"Nevada","Las Vegas","Carson City"},
            new string [] {"New Hampshire","Manchester","Concord" },
            new string [] {"New Jersey","Newark","Trenton" },
            new string [] {"New Mexico","Albuquerque","Santa Fe" },
            new string [] {"New York","New York City","Albany" },
            new string [] {"North Carolina","Charlotte","Raleigh" },
            new string [] {"North Dakota","Fargo","Bismarck" },
            new string [] {"Ohio","Columbus","Columbus" },
            new string [] {"Oklahoma","Oklahoma City","Oklahoma City" },
            new string [] {"Oregon","Portland","Salem" },
            new string [] {"Pennsylvania","Philadelphia","Harrisburg" },
            new string [] {"Rhode Island","Providence","Providence" },
            new string [] {"South Carolina","Charleston","Columbia" },
            new string [] {"South Dakota","Sioux Falls","Pierre" },
            new string [] {"Tennessee","Nashville","Nashville" },
            new string [] {"Texas","Houston","Austin" },
            new string [] {"Utah","Salt Lake City","Salt Lake City" },
            new string [] {"Vermont","Burlington","Montpelier" },
            new string [] {"Virginia","Virginia Beach","Richmond" },
            new string [] {"Washington","Seattle","Olympia" },
            new string [] {"West Virginia","Charleston","Charleston" },
            new string [] {"Wisconsin","Milwaukee","Madison" },
            new string [] {"Wyoming","Cheyenne","Cheyenne" },
            new string [] {"American Samoa","Pago Pago","Pago Pago" },
            new string [] {"Guam","Dedeo","Hagåtña" },
            new string [] {"Northern Mariana Islands","Saipan","Saipan" },
            new string [] {"Puerto Rico","San Juan","San Juan" },
            new string [] {"U.S. Virgin Islands", "St Croix", "Charlotte Amalie" }
        };

        // Test data for ValidSearchLargestCityAndCapitalByAbbreviationTest
        static object[] StateByAbbreviation = {
            new string [] { "AL", "Birmingham","Montgomery" },
            new string [] { "AK", "Anchorage","Juneau" },
            new string [] { "AZ", "Phoenix","Phoenix" },
            new string [] { "AR", "Little Rock","Little Rock" },
            new string [] { "CA", "Los Angeles","Sacramento" },
            new string [] { "CO", "Denver","Denver" },
            new string [] { "CT", "Bridgeport","Hartford" },
            new string [] { "DE", "Wilmington","Dover" },
            new string [] { "FL", "Jacksonville","Tallahassee" },
            new string [] { "GA", "Atlanta","Atlanta" },
            new string [] { "HI", "Honolulu","Honolulu" },
            new string [] { "ID", "Boise","Boise" },
            new string [] { "IL", "Chicago","Springfield" },
            new string [] { "IN", "Indianapolis","Indianapolis" },
            new string [] { "IA", "Des Moines","Des Moines" },
            new string [] { "KS", "Wichita","Topeka" },
            new string [] { "KY", "Louisville","Frankfort" },
            new string [] { "LA", "New Orleans","Baton Rouge" },
            new string [] { "ME", "Portland","Augusta" },
            new string [] { "MD", "Baltimore","Annapolis" },
            new string [] { "MA", "Boston","Boston" },
            new string [] { "MI", "Detroit","Lansing" },
            new string [] { "MN", "Minneapolis","St. Paul" },
            new string [] { "MS", "Jackson","Jackson" },
            new string [] { "MO", "Kansas City","Jefferson City" },
            new string [] { "MT", "Billings","Helena" },
            new string [] { "NE", "Omaha","Lincoln" },
            new string [] { "NV", "Las Vegas","Carson City"},
            new string [] {"NH","Manchester","Concord" },
            new string [] {"NJ","Newark","Trenton" },
            new string [] {"NM","Albuquerque","Santa Fe" },
            new string [] {"NY","New York City","Albany" },
            new string [] {"NC","Charlotte","Raleigh" },
            new string [] {"ND","Fargo","Bismarck" },
            new string [] {"OH","Columbus","Columbus" },
            new string [] {"OK","Oklahoma City","Oklahoma City" },
            new string [] {"OR","Portland","Salem" },
            new string [] {"PA","Philadelphia","Harrisburg" },
            new string [] {"RI","Providence","Providence" },
            new string [] {"SC","Charleston","Columbia" },
            new string [] {"SD","Sioux Falls","Pierre" },
            new string [] {"TN","Nashville","Nashville" },
            new string [] {"TX","Houston","Austin" },
            new string [] {"UT","Salt Lake City","Salt Lake City" },
            new string [] {"VT","Burlington","Montpelier" },
            new string [] {"VA","Virginia Beach","Richmond" },
            new string [] {"WA","Seattle","Olympia" },
            new string [] {"WV","Charleston","Charleston" },
            new string [] {"WI","Milwaukee","Madison" },
            new string [] {"WY","Cheyenne","Cheyenne" },
            new string [] {"AS","Pago Pago","Pago Pago" },
            new string [] {"GU","Dedeo","Hagåtña" },
            new string [] {"MP","Saipan","Saipan" },
            new string [] {"PR","San Juan","San Juan" },
            new string [] {"VI", "St Croix", "Charlotte Amalie" }
        };


        static object[] AllStatesInfo = {
            new object [] {1,  "Alabama", "AL", "Birmingham","Montgomery" },
            new object [] {2, "Alaska", "AK", "Anchorage","Juneau" },
            new object [] {3, "Arizona","AZ", "Phoenix","Phoenix" },
            new object [] {4, "Arkansas", "AR", "Little Rock","Little Rock" },
            new object [] {5, "California", "CA", "Los Angeles","Sacramento" },
            new object [] {6, "Colorado", "CO", "Denver","Denver" },
            new object [] {7, "Connecticut", "CT", "Bridgeport","Hartford" },
            new object [] {8, "Delaware", "DE", "Wilmington","Dover" },
            new object [] {9, "Florida", "FL", "Jacksonville","Tallahassee" },
            new object [] {10, "Georgia", "GA", "Atlanta","Atlanta" },
            new object [] {11, "Hawaii", "HI", "Honolulu","Honolulu" },
            new object [] {12, "Idaho", "ID", "Boise","Boise" },
            new object [] {13, "Illinois", "IL", "Chicago","Springfield" },
            new object [] {14, "Indiana", "IN", "Indianapolis","Indianapolis" },
            new object [] {15, "Iowa", "IA", "Des Moines","Des Moines" },
            new object [] {16, "Kansas", "KS", "Wichita","Topeka" },
            new object [] {17, "Kentucky", "KY", "Louisville","Frankfort" },
            new object [] {18, "Louisiana", "LA", "New Orleans","Baton Rouge" },
            new object [] {19, "Maine", "ME", "Portland","Augusta" },
            new object [] {20, "Maryland", "MD", "Baltimore","Annapolis" },
            new object [] {21, "Massachusetts", "MA", "Boston","Boston" },
            new object [] {22, "Michigan", "MI", "Detroit","Lansing" },
            new object [] {23, "Minnesota", "MN", "Minneapolis","St. Paul" },
            new object [] {24, "Mississippi", "MS", "Jackson","Jackson" },
            new object [] {25, "Missouri", "MO", "Kansas City","Jefferson City" },
            new object [] {26, "Montana", "MT", "Billings","Helena" },
            new object [] {27, "Nebraska", "NE", "Omaha","Lincoln" },
            new object [] {28, "Nevada", "NV", "Las Vegas","Carson City"},
            new object [] {29, "New Hampshire", "NH", "Manchester","Concord" },
            new object [] {30, "New Jersey", "NJ", "Newark","Trenton" },
            new object [] {31, "New Mexico", "NM", "Albuquerque","Santa Fe" },
            new object [] {32, "New York", "NY", "New York City","Albany" },
            new object [] {33, "North Carolina", "NC", "Charlotte","Raleigh" },
            new object [] {34, "North Dakota", "ND", "Fargo","Bismarck" },
            new object [] {35, "Ohio", "OH","Columbus", "Columbus" },
            new object [] {36, "Oklahoma", "OK", "Oklahoma City","Oklahoma City" },
            new object [] {37, "Oregon", "OR", "Portland","Salem" },
            new object [] {38, "Pennsylvania", "PA", "Philadelphia","Harrisburg" },
            new object [] {39, "Rhode Island", "RI", "Providence","Providence" },
            new object [] {40, "South Carolina", "SC", "Charleston","Columbia" },
            new object [] {41, "South Dakota", "SD", "Sioux Falls","Pierre" },
            new object [] {42, "Tennessee", "TN", "Nashville","Nashville" },
            new object [] {43, "Texas", "TX", "Houston","Austin" },
            new object [] {44, "Utah", "UT", "Salt Lake City","Salt Lake City" },
            new object [] {45, "Vermont", "VT", "Burlington","Montpelier" },
            new object [] {46, "Virginia", "VA", "Virginia Beach","Richmond" },
            new object [] {47, "Washington", "WA", "Seattle","Olympia" },
            new object [] {48, "West Virginia", "WV", "Charleston","Charleston" },
            new object [] {49, "Wisconsin", "WI", "Milwaukee","Madison" },
            new object [] {50, "Wyoming", "WY", "Cheyenne","Cheyenne" },
            new object [] {51, "American Samoa", "AS", "Pago Pago","Pago Pago" },
            new object [] {52, "Guam", "GU", "Dedeo","Hagåtña" },
            new object [] {53, "Northern Mariana Islands", "MP", "Saipan","Saipan" },
            new object [] {54, "Puerto Rico", "PR", "San Juan","San Juan" },
            new object [] {55, "U.S. Virgin Islands", "VI", "St Croix", "Charlotte Amalie" }
        };

        #endregion Test Data
    }
}
