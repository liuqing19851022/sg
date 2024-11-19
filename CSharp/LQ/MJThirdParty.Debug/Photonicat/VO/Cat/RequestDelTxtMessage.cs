using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Photonicat.VO.Cat
{
    public class RequestDelTxtMessage
    {
        [Required]
        [DefaultValue("SM_0")]
        public string msg_id { get; set; } = string.Empty;
    }
}
