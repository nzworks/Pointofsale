using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Orders
    {
        [Key]
        [Column("order_id")]
        public int order_id {  get; set; }

        [ForeignKey("Users")]
        [Column("user_id")]
        public int? user_id { get; set; }
        public DateTime? order_date {  get; set; }
        public float? total_amount { get; set; }
        public string? payment_status { get; set; }

    }
}
