using System;
using NUnit.Framework;
using WebService.REST;


namespace WebService.REST.Test
{
    [TestFixture]
    public class AllStateTest
    {
        private IAllState _allState;

        [SetUp]
        public void Setup()
        {
            this._allState = new AllState();
        }

        [TearDown]
        public void TearDown()
        {

        }

        // This test will fail since largest city is not implemented for American samoa, Guam, Northern Mariana Islands, Puerto Rico,U.S. Virgin Islands
        [Test, TestCaseSource("StateByName")]
        [Description("Verify user entered state Name or Abbrevation returns corresponding Largest city and Capital")]
        public void ValidSearchLargestCityAndCapitalByNameTest(string searchString, string expectedLargestCity, string expectedCapital)
        {
            this._allState.SearchLargestCityAndCapital(searchString);
            Assert.AreEqual(expectedLargestCity, this._allState.LargestCity);
            Assert.AreEqual(expectedCapital, this._allState.Capital);
        }

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
            new string [] {"New Jersey","Newark","Trenton}" },
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
    }
}
