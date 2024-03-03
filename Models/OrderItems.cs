using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class OrderItems
    {
        [Key]
        [Column("orderitem_id")]
        public int order_item_id {  get; set; }

        [ForeignKey("Orders")]
        [Column("order_id")]
        public int order_id {  get; set; }

        [ForeignKey("MenuItems")]
        [Column("menuitem_id")]
        public int? menuitem_id { get; set; }
        public int? quantity { get; set; }
        public int? subtotal { get; set; }
    }
}
