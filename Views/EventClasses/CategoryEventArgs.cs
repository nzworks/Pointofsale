using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Views.EventClasses
{
    public class CategoryEventArgs: EventArgs
    {
        public CategoryMdl CategoryAdded { get; set; }

        public CategoryEventArgs(CategoryMdl category)
        {
            CategoryAdded = category;
        }
    }
}
