﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            var pageSize = 3;
            if (page == null)
            {
                page = 1;
            }
            var pageNumber = page.HasValue ? Convert.ToInt32(page.Value) : 1;
            IEnumerable<Posts> items = db.Posts.Where(x => x.IsActive).OrderByDescending(x => x.CreatedDate);
            items = items.ToPagedList(pageNumber, pageSize);
            return View(items);
        }

        public ActionResult Detail(int id)
        {
            var item = db.Posts.Find(id);
            return View(item);
        }
    }
}