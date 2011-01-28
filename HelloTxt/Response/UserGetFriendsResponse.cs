using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HelloTxt.Response
{
    [Serializable, XmlRoot("rsp")]
    public partial class UserGetFriendsResponse : ServiceResponse
    {

        private rspFriend[] friendsField;

        private string statusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("friend", IsNullable = false)]
        public rspFriend[] friends
        {
            get
            {
                return this.friendsField;
            }
            set
            {
                this.friendsField = value;
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
    public partial class rspFriend
    {

        private string nameField;

        private string nicknameField;

        private string avatarField;

        private rspFriendStatus statusField;

        private uint idField;

        private string service_idField;

        private string service_codeField;

        /// <remarks/>
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
        public string nickname
        {
            get
            {
                return this.nicknameField;
            }
            set
            {
                this.nicknameField = value;
            }
        }

        /// <remarks/>
        public string avatar
        {
            get
            {
                return this.avatarField;
            }
            set
            {
                this.avatarField = value;
            }
        }

        /// <remarks/>
        public rspFriendStatus status
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string service_id
        {
            get
            {
                return this.service_idField;
            }
            set
            {
                this.service_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string service_code
        {
            get
            {
                return this.service_codeField;
            }
            set
            {
                this.service_codeField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rspFriendStatus
    {

        private uint idField;

        private uint timeField;

        private string valueField;

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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


    //[Serializable, XmlRoot("rsp")]
    //public partial class UserGetFriendsResponse
    //{

    //    private rspFriend[] friendsField;

    //    private string statusField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayItemAttribute("friend", IsNullable = false)]
    //    public rspFriend[] friends
    //    {
    //        get
    //        {
    //            return this.friendsField;
    //        }
    //        set
    //        {
    //            this.friendsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string status
    //    {
    //        get
    //        {
    //            return this.statusField;
    //        }
    //        set
    //        {
    //            this.statusField = value;
    //        }
    //    }
    //}
    ///// <remarks/>
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //public partial class rspFriend
    //{

    //    private string nameField;

    //    private string nicknameField;

    //    private string avatarField;

    //    private rspFriendStatus statusField;

    //    private byte idField;

    //    private string service_idField;

    //    private string service_codeField;

    //    /// <remarks/>
    //    public string name
    //    {
    //        get
    //        {
    //            return this.nameField;
    //        }
    //        set
    //        {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string nickname
    //    {
    //        get
    //        {
    //            return this.nicknameField;
    //        }
    //        set
    //        {
    //            this.nicknameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string avatar
    //    {
    //        get
    //        {
    //            return this.avatarField;
    //        }
    //        set
    //        {
    //            this.avatarField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public rspFriendStatus status
    //    {
    //        get
    //        {
    //            return this.statusField;
    //        }
    //        set
    //        {
    //            this.statusField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public byte id
    //    {
    //        get
    //        {
    //            return this.idField;
    //        }
    //        set
    //        {
    //            this.idField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string service_id
    //    {
    //        get
    //        {
    //            return this.service_idField;
    //        }
    //        set
    //        {
    //            this.service_idField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string service_code
    //    {
    //        get
    //        {
    //            return this.service_codeField;
    //        }
    //        set
    //        {
    //            this.service_codeField = value;
    //        }
    //    }
    //}
    ///// <remarks/>
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //public partial class rspFriendStatus
    //{

    //    private uint timeField;

    //    private string valueField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public uint time
    //    {
    //        get
    //        {
    //            return this.timeField;
    //        }
    //        set
    //        {
    //            this.timeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlTextAttribute()]
    //    public string Value
    //    {
    //        get
    //        {
    //            return this.valueField;
    //        }
    //        set
    //        {
    //            this.valueField = value;
    //        }
    //    }
    //}

}
