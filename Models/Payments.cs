using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Payments
    {
        [Key]
        [Column("payment_id")]
        public int payment_id {  get; set; }
        [ForeignKey("Orders")]
        [Column("order_id")]
        public int order_id {  get; set; }
        public int amount { get; set; }
        public string payment_method { get; set; }
        public DateTime transaction_date { get; set; }

    }
}
