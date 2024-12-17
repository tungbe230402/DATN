using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    [Authorize]
    public class HistoryOrderController : Controller
    {
        // GET: HistoryOrder
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            var userName = User.Identity.Name;
            var user = db.Users.FirstOrDefault(u => u.UserName == userName);
            var email = user.Email;
            var orders = db.Orders.Where(x => x.Email == email).OrderByDescending(o => o.CreatedDate).ToList();

            if (page == null)
            {
                page = 1;
            }
            var pageSize = 5;
            var pageNumber = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ViewDetail(int id) 
        {
            var item = db.Orders.Find(id);
            return View(item);
        }
    }
}