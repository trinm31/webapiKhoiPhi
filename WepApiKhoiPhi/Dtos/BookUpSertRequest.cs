using System;
using System.ComponentModel.DataAnnotations;

namespace WepApiKhoiPhi.Dtos
{
    public class BookUpSertRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
    }
}