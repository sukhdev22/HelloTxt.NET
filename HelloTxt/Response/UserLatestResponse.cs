using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HelloTxt.Response
{
    /// <remarks/>
    [Serializable, XmlRoot("rsp")]
    public partial class UserLatestResponse : ServiceResponse
    {

        private rspMessage[] messagesField;

        private string statusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("message", IsNullable = false)]
        public rspMessage[] messages
        {
            get
            {
                return this.messagesField;
            }
            set
            {
                this.messagesField = value;
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
    public partial class rspMessage
    {

        private string titleField;

        private string bodyField;

        private string imgField;

        private string img_rawField;

        private uint idField;

        /// <remarks/>
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }

        /// <remarks/>
        public string img
        {
            get
            {
                return this.imgField;
            }
            set
            {
                this.imgField = value;
            }
        }

        /// <remarks/>
        public string img_raw
        {
            get
            {
                return this.img_rawField;
            }
            set
            {
                this.img_rawField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
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
    }

}
