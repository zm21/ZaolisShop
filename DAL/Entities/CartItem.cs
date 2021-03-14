using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int ProductInfoId { get; set; }

        [Required]
        public virtual ProductInfo ProductInfo { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public virtual Cart Cart { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
