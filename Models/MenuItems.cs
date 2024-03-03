using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class MenuItems
    {

        public MenuItems()
        {
            this.Categories = new HashSet<CategoryMdl>();
        }
        [Key]
        [Column("menuitem_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int menuitem_id { get; set; }
        public string? item_name { get; set; }
        [ForeignKey("Category")]
        [Column("category_id")]
        public int? category_id { get; set; }
        public string? item_image { get; set; }
        public string? item_description { get; set; }
        public decimal? item_price { get; set; }
        [NotMapped]
        public virtual ICollection<CategoryMdl>? Categories { get; set; }

        public virtual ICollection<MenuItemCategory> MenuItemCategories { get; set; }

    }
}