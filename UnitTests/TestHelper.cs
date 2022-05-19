using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using ContosoCrafts.WebSite.Services;

namespace UnitTests
{
    /// <summary>
    /// Helper to hold the web start settings
    ///
    /// HttpClient
    /// 
    /// Action Contect
    /// 
    /// The View Data and Teamp Data
    /// 
    /// The Product Service
    /// </summary>
    public static class TestHelper
    {
        // Data middle tier
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;

        // Data middle tier
        public static IUrlHelperFactory UrlHelperFactory;

        // Data middle tier
        public static DefaultHttpContext HttpContextDefault;

        // Data middle tier
        public static IWebHostEnvironment WebHostEnvironment;

        // Data middle tier
        public static ModelStateDictionary ModelState;

        // Data middle tier
        public static ActionContext ActionContext;

        // Data middle tier
        public static EmptyModelMetadataProvider ModelMetadataProvider;

        // Data middle tier
        public static ViewDataDictionary ViewData;

        // Data middle tier
        public static TempDataDictionary TempData;

        // Data middle tier
        public static PageContext PageContext;

        // Data middle tier
        public static JsonFileLocationService ProductService;

        // Data middle tier
        public static JsonFileUserService UserService;

        // Data middle tier
        public static JsonFileMeetupService MeetupService;

        // Data middle tier
        public static JsonFileLocationTypeService LocationTypeService;

        // Data middle tier
        public static JsonFileLocationHoursService LocationHoursService;

        // Data middle tier
        public static JsonFileAttendeeService AttendeeService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        static TestHelper()
        {
            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            MockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            MockWebHostEnvironment.Setup(m => m.WebRootPath).Returns(TestFixture.DataWebRootPath);
            MockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            HttpContextDefault = new DefaultHttpContext()
            {
                TraceIdentifier = "trace",
            };
            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            ModelState = new ModelStateDictionary();

            ActionContext = new ActionContext(HttpContextDefault, HttpContextDefault.GetRouteData(), new PageActionDescriptor(), ModelState);

            ModelMetadataProvider = new EmptyModelMetadataProvider();
            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);
            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            PageContext = new PageContext(ActionContext)
            {
                ViewData = ViewData,
                HttpContext = HttpContextDefault
            };

            // Initialize location service
            ProductService = new JsonFileLocationService(MockWebHostEnvironment.Object);

            JsonFileLocationService productService;

            productService = new JsonFileLocationService(TestHelper.MockWebHostEnvironment.Object);

            // Initialize user service
            UserService = new JsonFileUserService(MockWebHostEnvironment.Object);

            JsonFileUserService userService;

            userService = new JsonFileUserService(TestHelper.MockWebHostEnvironment.Object);

            // Initialize meetup service
            MeetupService = new JsonFileMeetupService(MockWebHostEnvironment.Object);

            JsonFileMeetupService meetupService;

            meetupService = new JsonFileMeetupService(TestHelper.MockWebHostEnvironment.Object);

            // Initialize location type service
            LocationTypeService = new JsonFileLocationTypeService(TestHelper.MockWebHostEnvironment.Object);

            // Initialize location hours service
            LocationHoursService = new JsonFileLocationHoursService(TestHelper.MockWebHostEnvironment.Object);

            // Initialize attendee service
            AttendeeService = new JsonFileAttendeeService(TestHelper.MockWebHostEnvironment.Object);
        }

    }
}
