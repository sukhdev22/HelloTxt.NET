using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloTxt.v1;
using HelloTxt.Response;
using HelloTxt.Request;
using System.Configuration;

/*
 * Copyright (C) 2011 Ben Powell http://twitter.com/junto
 * http://blog.benpowell.co.uk/
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace HelloTextTests
{
    /// <summary>
    /// Summary description for TestHelloTxt_v1
    /// </summary>
    [TestClass]
    public class TestHelloTxt_v1
    {
        /// <summary>
        /// Gets or sets the app_key.
        /// </summary>
        /// <value>
        /// The app_key.
        /// </value>
        private string app_key { get; set; }

        /// <summary>
        /// Gets or sets the user_key.
        /// </summary>
        /// <value>
        /// The user_key.
        /// </value>
        private string user_key { get; set; }

        /// <summary>
        /// Our API
        /// </summary>
        private HelloTxtAPI api = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestHelloTxt_v1"/> class.
        /// </summary>
        public TestHelloTxt_v1()
        {
            // Get configs
            this.app_key = ConfigurationManager.AppSettings["app_key"];
            this.user_key = ConfigurationManager.AppSettings["user_key"];

            // our api
            this.api = new HelloTxtAPI(this.app_key, this.user_key);
        }

        /// <summary>
        /// 
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Verifies the user key configuration settings.
        /// </summary>
        [TestMethod]
        public void VerifyUserKeyConfigurationSettings_v1()
        {
            string value = ConfigurationManager.AppSettings["user_key"];
            Assert.IsFalse(String.IsNullOrEmpty(value), "No user_key in App.Config found.");
        }

        /// <summary>
        /// Verifies the app key configuration settings.
        /// </summary>
        [TestMethod]
        public void VerifyAppKeyConfigurationSettings_v1()
        {
            string value = ConfigurationManager.AppSettings["app_key"];
            Assert.IsFalse(String.IsNullOrEmpty(value), "No app_key in App.Config found.");
        }

        /// <summary>
        /// Executes the user validate.
        /// </summary>
        [TestMethod]
        public void ExecuteUserValidate_v1()
        {
            UserValidateResponse rsp = api.Validate();

            Assert.AreEqual(rsp.status, "OK");
        }

        /// <summary>
        /// Executes the user post.
        /// </summary>
        [TestMethod]
        public void ExecuteUserPost_v1()
        {
            //
            bool isDebug = true;

            UserPostRequest request = new UserPostRequest();
            request.body = "body test";
            request.title = "title test";
            request.networks = String.Empty;
            request.poi_lat = String.Empty;
            request.poi_long = String.Empty;
            request.poi_name = String.Empty;
            request.scheduled_time = DateTime.Now.AddMinutes(10).ToString("s");

            // Comment this in if you are running MSTEST in Visual Studio
            /*var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var fileName = System.IO.Path.Combine(path, "cute.jpg");
            request.image = new System.IO.FileInfo(fileName);*/

            //
            request.debug = (isDebug) ? "1" : "0";

            ServiceResponse rsp = api.Post(request);

            //
            Assert.AreEqual(rsp.status, (isDebug) ? "DEBUG" : "OK");
        }

        /// <summary>
        /// Executes the user services.
        /// </summary>
        [TestMethod]
        public void ExecuteUserServices_v1()
        {
            UserServicesResponse rsp = api.Services();

            Assert.AreEqual(rsp.status, "OK");
        }

        /// <summary>
        /// Executes the user latest.
        /// </summary>
        [TestMethod]
        public void ExecuteUserLatest_v1()
        {
            UserLatestResponse rsp = api.Lastest();

            Assert.AreEqual(rsp.status, "OK");
        }

        /// <summary>
        /// Executes the user get friends.
        /// </summary>
        [TestMethod]
        public void ExecuteUserGetFriends_v1()
        {
            UserGetFriendsRequest request = new UserGetFriendsRequest();
            request.networks = String.Empty;

            UserGetFriendsResponse rsp = api.GetFriends(request);

            Assert.AreEqual(rsp.status, "OK");
        }

        /// <summary>
        /// Executes the user check friends.
        /// </summary>
        [TestMethod]
        public void ExecuteUserCheckFriends_v1()
        {
            ServiceResponse rsp = api.CheckFriends();

            Assert.AreEqual(rsp.status, "OK");
        }

        /// <summary>
        /// Executes the user register.
        /// </summary>
        [TestMethod]
        public void ExecuteUserRegister_v1()
        {
            UserRegisterRequest request = new UserRegisterRequest();
            request.email = "incorrect email address format.com";
            request.pass = "anything";

            UserRegisterResponse rsp = api.Register(request);

            Assert.AreEqual(rsp.status, "FAIL");
        }

        /// <summary>
        /// Executes the user add service.
        /// </summary>
        [TestMethod]
        public void ExecuteUserAddService_v1()
        {
            UserAddServiceRequest request = new UserAddServiceRequest();
            request.code = "123";
            request.nick = "nickname";
            request.service = "abc";
            request.pwd = "9876";

            ServiceResponse rsp = api.AddService(request);

            Assert.AreEqual(rsp.status, "FAIL");
        }

        /// <summary>
        /// Executes the user removed service.
        /// </summary>
        [TestMethod]
        public void ExecuteUserRemovedService_v1()
        {
            UserRemoveServiceRequest request = new UserRemoveServiceRequest();
            request.code = "123";
            request.service = "abc";

            ServiceResponse rsp = api.RemoveService(request);

            Assert.AreEqual(rsp.status, "FAIL");
        }

        /// <summary>
        /// Executes the user key.
        /// </summary>
        [TestMethod]
        public void ExecuteUserKey_v1()
        {
            UserKeyRequest request = new UserKeyRequest();
            request.mobile_key = "123";

            UserKeyResponse rsp = api.Key(request);

            Assert.AreEqual(rsp.status, "FAIL");
        }
    }
}
