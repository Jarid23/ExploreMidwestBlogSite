using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreMidwest.Web.Models
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        
        public IEnumerable<Category> CategoryItems { get; set; }

        public BlogVM()
        {
            CategoryItems = new List<Category>();
        }

        public void SetCategories(IEnumerable<Category> category)
        {             
            foreach (var c in category)
            {
                
                //CategoryItems.Add(new Category()
                //{
                //    value = c.CategoryId.ToString(),
                //    Text = c.CategoryType
                    
                //});
            }
        }
    }
}