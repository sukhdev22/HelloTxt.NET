using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace HelloTxt.Request
{
    public sealed partial class UserPostRequest : ServiceRequest
    {
        /// <summary>
        /// Message body.
        /// Required
        /// Note: Not required if there is an multimedia.
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// No description in API documentation
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Social network accounts to update. Must be in the format social_id-code_social_id,social_id-code_social_id... code_social_id is 4+ characters long and social_id is 2 characters long [tw, fb, id, ps, bb, wp,...].
        /// No required
        /// </summary>
        public string networks { get; set; }

        /// <summary>
        /// Latitude of the POI associated to the post
        /// Not Required
        /// </summary>
        public string poi_lat { get; set; }

        /// <summary>
        /// Longititude of the POI associated to the post
        /// Not required
        /// </summary>
        public string poi_long { get; set; }

        /// <summary>
        /// Name of the POI associated to the post. If left blank and the poi_lat and poi_long parameters are provided it defaults to 'current position'
        /// Not required
        /// </summary>
        public string poi_name { get; set; }

        /// <summary>
        /// Scheduled time of the post. (Must be in the ISO 8601 format: dealt with by Tostring("s") automatically)
        /// Not Required
        /// </summary>
        public string scheduled_time { get; set; }

        /// <summary>
        /// RAW encoded image. format jpg, gif, png
        /// Not requried
        /// </summary>
        public FileInfo image { get; set; }

        /// <summary>
        /// Set this value to "1" to avoid posting test data.
        /// Not required
        /// </summary>
        public string debug { get; set; }
    }
}
