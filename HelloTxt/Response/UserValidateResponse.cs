using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HelloTxt.Response
{
    [Serializable, XmlRoot("rsp")]
    public partial class UserValidateResponse : ServiceResponse
    {

        private string nickField;

        private string nameField;

        private string statusField;

        [XmlElement("nick")]
        public string nick
        {
            get
            {
                return this.nickField;
            }
            set
            {
                this.nickField = value;
            }
        }

        [XmlElement("name")]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

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
