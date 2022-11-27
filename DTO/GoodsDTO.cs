using System;

namespace DTO
{
    public class GoodsDTO
    {
        public int GoodsId { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
