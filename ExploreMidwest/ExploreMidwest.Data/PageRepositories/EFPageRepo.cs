using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExploreMidwest.Model;
using System.Data.Entity.Migrations;

namespace ExploreMidwest.Data.PageRepositories
{
    public class EFPageRepo : IPageRepo
    {
        ExploreMidwestDBContext context = new ExploreMidwestDBContext();

        public void AddPage(Page page)
        {
            context.Page.Add(page);
            context.SaveChanges();
        }

        public void EditPage(Page page)
        {
            context.Page.AddOrUpdate(page);
            context.SaveChanges();
        }

        public List<Page> GetAllPages()
        {
            var pages = from p in context.Page
                        select p;
            return pages.ToList();
        }

        public Page GetPage(int pageId)
        {
            var page = (from p in context.Page where p.PageId == pageId select p).FirstOrDefault();
            return page;
        }

        public void RemovePage(int pageId)
        {
            var page = (from p in context.Page where p.PageId == pageId select p).FirstOrDefault();
            context.Page.Remove(page);
            context.SaveChanges();
        }
    }
}
