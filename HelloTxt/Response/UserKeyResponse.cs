using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HelloTxt.Response
{
    /// <remarks/>
    [Serializable, XmlRoot("rsp")]
    public partial class UserKeyResponse : ServiceResponse
    {

        private string user_keyField;

        private string statusField;

        /// <remarks/>
        public string user_key
        {
            get
            {
                return this.user_keyField;
            }
            set
            {
                this.user_keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }

}
