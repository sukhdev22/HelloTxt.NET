using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloTxt.Response;
using Microsoft.Http;
using System.Xml.Serialization;
using HelloTxt.Request;
using System.Collections.Specialized;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.IO;

/*
 * Copyright (C) 2011 Ben Powell
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

namespace HelloTxt.v1
{
    /// <summary>
    /// See http://hellotxt.com/developers/documentation
    /// </summary>
    public class HelloTxtAPI
    {
        /// <summary>
        /// BaseUrl for the HelloTxt API
        /// </summary>
        private const string baseUrl = "http://hellotxt.com/api/v1/method/";

        /// <summary>
        /// Gets or sets the app key.
        /// </summary>
        /// <value>
        /// The app key.
        /// </value>
        public string AppKey { get; set; }
        /// <summary>
        /// Gets or sets the user key.
        /// </summary>
        /// <value>
        /// The user key.
        /// </value>
        public string UserKey { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="HelloTxtAPI"/> class.
        /// Maybe move these to the request objects???
        /// </summary>
        /// <param name="_appKey">The _app key.</param>
        /// <param name="_userKey">The _user key.</param>
        public HelloTxtAPI(string _appKey, string _userKey)
        {
            this.AppKey = _appKey;
            this.UserKey = _userKey;
        }

        /// <summary>
        /// Validates the given user’s application key.
        /// </summary>
        /// <returns>OK, nick, name. Error message on failure.</returns>
        public UserValidateResponse Validate()
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);

                // call method
                using (HttpResponseMessage response = client.Post("user.validate", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<UserValidateResponse>();
                }
            }
        }

        /// <summary>
        /// Posts a message to the user’s Hellotxt services.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>OK. Error message on failure.</returns>
        public ServiceResponse Post(UserPostRequest request)
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);
                form.Add("body", request.body);
                if (!String.IsNullOrWhiteSpace(request.title)) form.Add("title", request.title);
                if (!String.IsNullOrWhiteSpace(request.networks)) form.Add("networks", request.networks);
                if (!String.IsNullOrWhiteSpace(request.poi_lat)) form.Add("poi_lat", request.poi_lat);
                if (!String.IsNullOrWhiteSpace(request.poi_long)) form.Add("poi_long", request.poi_long);
                if (!String.IsNullOrWhiteSpace(request.poi_name)) form.Add("poi_name", request.poi_name);
                if (!String.IsNullOrWhiteSpace(request.scheduled_time)) form.Add("scheduled_time", request.scheduled_time);
                if (!String.IsNullOrWhiteSpace(request.debug)) form.Add("debug", request.debug);

                if (request.image != null)
                {
                    HttpFormFile file = new HttpFormFile();
                    file.Content = HttpContent.Create(request.image, "application/octet-stream");
                    file.FileName = request.image.Name;
                    file.Name = "image";

                    form.Files.Add(file);
                }

                // call method
                using (HttpResponseMessage response = client.Post("user.post", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<ServiceResponse>();
                }
            }
        }

        /// <summary>
        /// Returns a list of services the particular user has set up through Hellotxt.
        /// </summary>
        /// <returns>OK. Error message on failure.</returns>
        public UserServicesResponse Services()
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);

                // call method
                using (HttpResponseMessage response = client.Post("user.services", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<UserServicesResponse>();
                }
            }
        }

        /// <summary>
        /// Returns a list of 20 status update sent through Hellotxt.
        /// </summary>
        /// <returns>OK, latest 20 status update through Hellotxt. Error message on failure.</returns>
        public UserLatestResponse Lastest()
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);

                // call method
                using (HttpResponseMessage response = client.Post("user.latest", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<UserLatestResponse>();
                }
            }
        }

        /// <summary>
        /// Returns a list of given user's friends.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>OK, list of friends. Error message on failure.</returns>
        public UserGetFriendsResponse GetFriends(UserGetFriendsRequest request)
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);
                if (!String.IsNullOrWhiteSpace(request.networks)) form.Add("networks", request.networks);

                // call method
                using (HttpResponseMessage response = client.Post("user.getfriends", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<UserGetFriendsResponse>();
                }
            }
        }

        /// <summary>
        /// Ask hellotxt to fetch the user's friends status updates from various social networks.
        /// </summary>
        /// <returns>OK. Error message on failure.</returns>
        public ServiceResponse CheckFriends()
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);

                // call method
                using (HttpResponseMessage response = client.Post("user.checkfriends", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<ServiceResponse>();
                }
            }
        }

        /// <summary>
        /// Register a new user in Hellotxt.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>OK, user_key. Error message on failure.</returns>
        public UserRegisterResponse Register(UserRegisterRequest request)
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("email", request.email);
                if (!String.IsNullOrWhiteSpace(request.pass)) form.Add("pass", request.pass);

                // call method
                using (HttpResponseMessage response = client.Post("user.register", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<UserRegisterResponse>();
                }
            }
        }

        /// <summary>
        /// Add/update a service to the given user
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>OK. Error message on failure.</returns>
        public ServiceResponse AddService(UserAddServiceRequest request)
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);
                form.Add("service", request.service);
                if (!String.IsNullOrWhiteSpace(request.code)) form.Add("code", request.code);
                form.Add("nick", request.nick);
                form.Add("pwd", request.pwd);

                // call method
                using (HttpResponseMessage response = client.Post("user.addservice", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<ServiceResponse>();
                }
            }
        }

        /// <summary>
        /// Remove a service from the given user
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>OK. Error message on failure.</returns>
        public ServiceResponse RemoveService(UserRemoveServiceRequest request)
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("user_key", this.UserKey);
                form.Add("service", request.service);
                form.Add("code", request.code);

                // call method
                using (HttpResponseMessage response = client.Post("user.removeservice", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<ServiceResponse>();
                }
            }
        }

        /// <summary>
        /// Give the user's key of the given mobile key's user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>OK, user_key. Error message on failure.</returns>
        public UserKeyResponse Key(UserKeyRequest request)
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = new HttpMultipartMimeForm();
                form.Add("app_key", this.AppKey);
                form.Add("mobile_key", request.mobile_key);

                // call method
                using (HttpResponseMessage response = client.Post("user.key", form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<UserKeyResponse>();
                }
            }
        }

        /// <summary>
        /// Returns the default client
        /// </summary>
        /// <returns></returns>
        private HttpClient GetDefaultClient()
        {
            HttpClient client = new HttpClient(baseUrl);
            client.DefaultHeaders.UserAgent.AddString(@"HelloTxt.NET: Ben Powell: http://blog.benpowell.co.uk");

            return client;
        }

        /// <summary>
        /// Gets Service Request from API constructor params.
        /// </summary>
        /// <returns></returns>
        public ServiceRequest GetServiceRequest()
        {
            return new ServiceRequest(this.AppKey, this.UserKey);
        }
    }
}
