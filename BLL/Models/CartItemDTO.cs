using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class CartItemDTO
    {
        public int Id { get; set; }

        public int ProductInfoId { get; set; }

        public string Name { get; set; }

        public decimal TotalPrice => Price * Count;

        public decimal Price { get; set; }

        public string Image { get; set; }

        [Range(1,100)]
        public int Count { get; set; }
    }
}
