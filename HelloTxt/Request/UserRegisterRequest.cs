using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelloTxt.Request
{
    public sealed partial class UserRegisterRequest : ServiceRequest
    {
        /// <summary>
        /// New user's email
        /// Required
        /// </summary>
        [Required]
        public string email { get; set; }

        /// <summary>
        /// New user's password (min 5 chars). If left blank a random one will be generated and sent to the user's email
        /// Not required
        /// </summary>
        public string pass { get; set; }
    }
}
