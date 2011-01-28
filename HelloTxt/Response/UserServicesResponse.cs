using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HelloTxt.Response
{
    /// <remarks/>
    [Serializable, XmlRoot("rsp")]
    public partial class UserServicesResponse : ServiceResponse
    {

        private rspService[] servicesField;

        private string statusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("service", IsNullable = false)]
        public rspService[] services
        {
            get
            {
                return this.servicesField;
            }
            set
            {
                this.servicesField = value;
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
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rspService
    {

        private string codeField;

        private string nickField;

        private bool checkedField;

        private string inhomeField;

        private string friendField;

        private bool colleagueField;

        private string tagsField;

        private string idField;

        private string nameField;

        private string descriptionField;

        /// <remarks/>
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
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

        /// <remarks/>
        public bool @checked
        {
            get
            {
                return this.checkedField;
            }
            set
            {
                this.checkedField = value;
            }
        }

        /// <remarks/>
        public string inhome
        {
            get
            {
                return this.inhomeField;
            }
            set
            {
                this.inhomeField = value;
            }
        }

        /// <remarks/>
        public string friend
        {
            get
            {
                return this.friendField;
            }
            set
            {
                this.friendField = value;
            }
        }

        /// <remarks/>
        public bool colleague
        {
            get
            {
                return this.colleagueField;
            }
            set
            {
                this.colleagueField = value;
            }
        }

        /// <remarks/>
        public string tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

}
