﻿using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Models
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        
        public List<SelectListItem> CategoryItems { get; set; }       

        public BlogVM()
        {
            CategoryItems = new List<SelectListItem>();
           
        }

        public void SetCategories(List<Category> category)
        {             
            foreach (var c in category)
            {
                
                CategoryItems.Add(new SelectListItem()
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryType

                });
            }
        }

        

    }
}