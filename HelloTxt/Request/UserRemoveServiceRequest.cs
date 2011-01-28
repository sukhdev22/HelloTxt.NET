using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelloTxt.Request
{
    /// <summary>
    /// User.RemoveService Request object
    /// </summary>
    public sealed partial class UserRemoveServiceRequest : ServiceRequest
    {
        /// <summary>
        /// Service to add/update. [tw, fb, id, ps, bb, wp,...]
        /// Required
        /// </summary>
        [Required]
        public string service { get; set; }

        /// <summary>
        /// The service's code you want to update.
        /// Required
        /// </summary>
        [Required]
        public string code { get; set; }
    }
}
