using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace POS.Models
{
    [Table("Category")]
    public class CategoryMdl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public CategoryMdl()
        {
            this.MenuItems = new HashSet<MenuItems>();
        }
        [Key]
        [Column("category_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }
        public string? category_name { get; set; }
        public string? description { get; set; }
        public string? image_path { get; set; }

        [NotMapped]

        public virtual ICollection<MenuItems>? MenuItems { get; set; }

        public virtual ICollection<MenuItemCategory> MenuItemCategories { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
