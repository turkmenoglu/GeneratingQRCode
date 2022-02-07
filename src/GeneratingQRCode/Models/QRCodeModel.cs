using System.ComponentModel.DataAnnotations;

namespace GeneratingQRCode.Models
{
    public class QRCodeModel
    {
        [Required]
        public string QRCodeText { get; set; }
    }
}
