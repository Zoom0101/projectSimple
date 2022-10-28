using SachAdoNet.Models;
using SachAdoNet.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachAdoNet.Controllers
{
    public class BookController : Controller
    {
       public ActionResult GetbookDetail()
        {
            BookRes br = new BookRes();
            return View(br.GetBook());
        }
        public ActionResult AddNewBook(BookModel bkM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BookRes br = new BookRes();
                    if (br.AddBook(bkM))
                    {
                        ViewBag.Messager = "Thêm sách mới thành công";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }

        }
    }
}
