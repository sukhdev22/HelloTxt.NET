using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelloTxt.Request
{
    public sealed partial class UserKeyRequest : ServiceRequest
    {
        /// <summary>
        /// User Mobile Key.
        /// Required
        /// </summary>
        [Required]
        public string mobile_key { get; set; }
    }
}
