using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelloTxt.Request
{
    /// <summary>
    /// The base service request
    /// </summary>
    public partial class ServiceRequest
    {
        /// <summary>
        /// Application Key. Always required
        /// </summary>
        [Required]
        public string app_key { get; set; }

        /// <summary>
        /// User Key. Usually required.
        /// </summary>
        public string user_key { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequest"/> class.
        /// </summary>
        public ServiceRequest()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequest"/> class.
        /// </summary>
        /// <param name="_app_key">The _app_key.</param>
        /// <param name="_user_key">The _user_key.</param>
        public ServiceRequest(string _app_key, string _user_key)
        {
            this.app_key = _app_key;
            this.user_key = _user_key;
        }
    }
}
