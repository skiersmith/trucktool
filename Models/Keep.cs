using System;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public int UserId { get; set; }

        public int Keeps { get; set; }
        public int Views { get; set; }


    }
}