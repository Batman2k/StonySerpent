using System.Collections.Generic;
using StonySerpent.Core.Models;

namespace StonySerpent.Core.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }

        public string Title { get; set; }

        public string SearchTerm { get; set; }
    }
}