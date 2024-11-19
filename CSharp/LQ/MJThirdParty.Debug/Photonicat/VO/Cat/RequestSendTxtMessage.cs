using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Photonicat.VO.Cat
{
    public class RequestSendTxtMessage
    {
        [Required]
        [DataMember]
        [DefaultValue("10086")]
        public string send_to { get; set; } = string.Empty;

        [Required]
        [DefaultValue("hf")]
        public string msg { get; set; } = string.Empty;
    }
}
