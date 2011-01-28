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

namespace HelloTxt.v2
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
        /// Generic post request.
        /// </summary>
        /// <typeparam name="K">Request Type</typeparam>
        /// <typeparam name="T">Response Type</typeparam>
        /// <param name="query">e.g. user.validate</param>
        /// <param name="request">The Request</param>
        /// <returns></returns>
        public T PostRequest<K, T>(string query, K request)
        {
            using (var client = GetDefaultClient())
            {
                // build form data post
                HttpMultipartMimeForm form = CreateMimeForm<K>(request);
                //form.Add("app_key", this.AppKey);
                //form.Add("user_key", this.UserKey);

                // call method
                using (HttpResponseMessage response = client.Post(query, form.CreateHttpContent()))
                {
                    response.EnsureStatusIsSuccessful();
                    return response.Content.ReadAsXmlSerializable<T>();
                }
            }
        }

        /// <summary>
        /// Generic GET request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetRequest<T>(string query)
        {
            HttpClient client = GetDefaultClient();

            HttpResponseMessage response = client.Get(query);
            response.EnsureStatusIsSuccessful();

            T data = default(T);
            try
            {
                data = response.Content.ReadAsXmlSerializable<T>();
                return data;
            }
            catch (Exception ex)
            {
                Console.Write(String.Format("{0}: {1}", ex.Message, ex.InnerException.Message));
            }

            return data;
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

        /// <summary>
        /// Builds a HttpMultipartMimeForm from a request object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpMultipartMimeForm CreateMimeForm<T>(T request)
        {
            HttpMultipartMimeForm form = new HttpMultipartMimeForm();

            Type type = request.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (Attribute attribute in property.GetCustomAttributes(true))
                {
                    RequiredAttribute requiredAttribute = attribute as RequiredAttribute;
                    if (requiredAttribute != null)
                    {
                        if (!requiredAttribute.IsValid(property.GetValue(request, null)))
                        {
                            //Console.WriteLine("{0} [type = {1}] [value = {2}]", property.Name, property.PropertyType, property.GetValue(property, null));
                            throw new ValidationException(String.Format("{0} [type = {1}] requires a valid value", property.Name, property.PropertyType));
                        }
                    }
                }

                if (property.PropertyType == typeof(FileInfo))
                {
                    FileInfo fi = (FileInfo)property.GetValue(request, null);
                    HttpFormFile file = new HttpFormFile();
                    file.Content = HttpContent.Create(fi, "application/octet-stream");
                    file.FileName = fi.Name;
                    file.Name = "image";

                    form.Files.Add(file);
                }
                else
                {
                    form.Add(property.Name, String.Format("{0}", property.GetValue(request, null)));
                }
            }    

            return form;
        }
    }
}
