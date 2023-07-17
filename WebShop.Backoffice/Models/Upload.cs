using Microsoft.AspNetCore.Mvc;

namespace WebShop.Backoffice.Models
{
    public class Upload
    {
        public string UrlImage { get; set; }
        public Byte[] Image { get; set; }
    }
}
