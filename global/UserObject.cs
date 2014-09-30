using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace global.EOSFIDSReference
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.priemton.com/EOS")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.priemton.com/EOS", IsNullable = false)]
    public partial class UserObject : System.Web.Services.Protocols.SoapHeader
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}

namespace global.EOSFIDSReference
{
    public partial class ServicesBinding : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        private UserObject eosSoapHeaderValueField;

        public UserObject EosSoapHeaderValue
        {
            get
            {
                return this.eosSoapHeaderValueField;
            }
            set
            {
                this.eosSoapHeaderValueField = value;
            }
        }
    }
}