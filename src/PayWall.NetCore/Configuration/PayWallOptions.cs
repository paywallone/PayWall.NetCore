using System.ComponentModel.DataAnnotations;

namespace PayWall.NetCore.Configuration
{
    public class PayWallOptions
    {
        [Required(ErrorMessage = "Prod is required.")]
        public bool Prod { get; set; }
        
        [Required(ErrorMessage = "PublicClient is required.")]
        public string PublicClient { get; set; }
        
        [Required(ErrorMessage = "PublicKey is required.")]
        public string PublicKey { get; set; }
        
        [Required(ErrorMessage = "PrivateClient is required.")]
        public string PrivateClient { get; set; }
        
        [Required(ErrorMessage = "PrivateKey is required.")]
        public string PrivateKey { get; set; }
    }
}