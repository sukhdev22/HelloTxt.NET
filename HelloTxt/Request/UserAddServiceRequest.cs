using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelloTxt.Request
{
    public sealed partial class UserAddServiceRequest : ServiceRequest
    {
        [Required]
        /// <summary>
        /// Service to add/update. [tw, fb, id, ps, bb, wp,...]
        /// Required
        /// </summary>
        public string service { get; set; }

        /// <summary>
        /// The service's code you want to update.
        /// Not required
        /// </summary>
        public string code { get; set; }

        [Required]
        /// <summary>
        /// The service's nick you want to add/update.
        /// Required
        /// </summary>
        public string nick { get; set; }

        [Required]
        /// <summary>
        /// The service's password you want to add/update. (base64 encoded)
        /// Required
        /// </summary>
        public string pwd { get; set; }
    }
}
