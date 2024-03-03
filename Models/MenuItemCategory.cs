using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class MenuItemCategory
    {
        [Key]
        public int MenuItemId { get; set; }
        [Key]
        public int CategoryId {  get; set; }
        [ForeignKey("MenuItemId")]
        public MenuItems MenuItem {  get; set; }

        [ForeignKey("CategoryId")]
        public CategoryMdl Category { get; set; }
    }
}
