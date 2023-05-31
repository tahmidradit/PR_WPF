using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_WPF
{
    public class Order
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; }

        [StringLength(100)]
        public string? CustomerAddress { get; set; }

        [Required, StringLength(100)]
        public string ShippingAddress { get; set; }

        [Required, StringLength(100)]
        public string ItemName { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Minimum Unit Price is 1")]
        public decimal UnitPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Minimum Quantity is 1")]
        public int Quantity { get; set; }
        public int? Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderInvoiceNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime ShippingDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
