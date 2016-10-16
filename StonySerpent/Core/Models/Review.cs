using System;

namespace StonySerpent.Core.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string SerialNumber { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }

        public DateTime DateTime { get; set; }
    }
}