using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelloTxt.Request
{
    public sealed partial class UserGetFriendsRequest : ServiceRequest
    {
        /// <summary>
        /// Social network accounts from which the friends are taken. Must be in the format social_id-code_social_id,social_id-code_social_id... code_social_id is 4+ characters long and social_id is 2 characters long [tw, fb, id, ps, bb, wp,...].
        /// Not required
        /// </summary>
        public string networks { get; set; }
    }
}
