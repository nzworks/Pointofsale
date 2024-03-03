using Microsoft.EntityFrameworkCore;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class MenuItemsRepo
    {
        private readonly PosDbContext _context;

        public MenuItemsRepo(PosDbContext context)
        {
            _context = context;
        }

        public void AddMenuItem(MenuItems menuItems)
        {
            _context.MenuItems.Add(menuItems);
            _context.SaveChanges();
        }

        public void UpdateMenuItem(MenuItems menuItems)
        {
            _context.MenuItems.Update(menuItems);
            _context.SaveChanges();
        }

        public void DeleteMenuItem(int menuitemId)
        {
            var menuitem = _context.MenuItems.Find(menuitemId);
            if (menuitem != null)
            {
                _context.MenuItems.Remove(menuitem);
                _context.SaveChanges();
            }
        }

        public MenuItems GetMenuItem(int menuitemId)
        {
            return _context.MenuItems.Find(menuitemId);
        }

        public IEnumerable<MenuItems> GetAllMenuItems()
        {
            return _context.MenuItems.ToList();
        }

        
        public IEnumerable<MenuItems> GetAllMenuItemsWithCategories()
        {
            // Include related category
            return _context.MenuItems.Include(m => m.MenuItemCategories)
                .ThenInclude(mc => mc.Category).ToList();
        }

        public void AddMenuItemCategory(MenuItemCategory menuItemCategory)
        {
            _context.MenuItemCategories.Add(menuItemCategory);
            _context.SaveChanges();
        }

        public void RemoveMenuItemCategory(MenuItemCategory menuItemCategory)
        {
            _context.MenuItemCategories.Remove(menuItemCategory);
            _context.SaveChanges();
        }
    }
}
