using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json.Linq;


namespace WebService.RESTAPI.Test
{
    [TestFixture]
    public class RequestHandlerTest
    {
        private IRequestHandler _httpClientReqHandler;
        private const string URL = "http://services.groupkt.com/state/get/USA/all";

        [SetUp]
        public void Setup()
        {
            // Instantiate class under test for every test case
            _httpClientReqHandler = new HttpClientRequestHandler();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        [Description("Verify JSON response is not null with valid URL request")]
        public void GetAllStateResponsewithValidURLTest()
        {
            Assert.IsNotNull(_httpClientReqHandler.GetAllStateResponse(URL));
        }

        [Test]
        [Description("Verify Invalid uri exception is thrown when uri is empty")]
        public void EmptyUriTest()
        {
            var ex = Assert.Throws<System.UriFormatException>(() => _httpClientReqHandler.GetAllStateResponse(""));
            Assert.That(ex.Message, Is.EqualTo("Invalid URI: The URI is empty."));
        }

        [Test]
        [Description("Verify JsonReader Exception exception is thrown when uri is invalid")]
        public void InvalidUriTest()
        {
            var ex = Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => _httpClientReqHandler.GetAllStateResponse("http://services.groupkt.com/state/get/USA/all/invalid"));      
        }
    }
}