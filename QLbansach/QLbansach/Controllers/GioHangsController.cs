using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLbansach.Models;

namespace QLbansach.Controllers
{
    public class GioHangsController : Controller
    {
        private SachDB db = new SachDB();
        //Lay gio hang
        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if(lstgiohang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì khời taọ giỏ hàng
                lstgiohang = new List<GioHang>();
                Session["GioHang"] = lstgiohang;

            }
            return lstgiohang;

        }
        //Them gio hang
        public ActionResult Themgiohang(int iMasach, string strURL)
        {
            //Lay session ra khoi giỏ
            List<GioHang> lstgiohang = Laygiohang();
            //Kiem tra sach ton tai trong session giohang chua
            GioHang sanpham = lstgiohang.Find(n => n.iMasach == iMasach);
            if(sanpham == null)
            {
                sanpham = new GioHang(iMasach);
                lstgiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }

        }
        //TÍnh tổng số lượng
        private int Tongsoluong()
        {
            int iTongsoluong = 0;
            List<GioHang> lstgiohang = Session["Giohang"] as List<GioHang>;
            if(lstgiohang != null)
            {
                iTongsoluong = lstgiohang.Sum(n => n.iSoluong);
            }
            return iTongsoluong;
        }
        //TÍnh tổng số tien
        private double Tongtien()
        {
            double iTongtien = 0;
            List<GioHang> lstgiohang = Session["Giohang"] as List<GioHang>;
            if (lstgiohang != null)
            {
                iTongtien = lstgiohang.Sum(n => n.dThanhtien);
            }
            return iTongtien;
        }
        // Xây dựng trang giỏ hàng
        public ActionResult Giohang()
        {
            List<GioHang> lstgiohang = Laygiohang();
            if (lstgiohang.Count == 0 )
            {
                return RedirectToAction("Index","SACHes");
            }
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return View(lstgiohang);
        }
        // GET: GioHangs
        public ActionResult Xoagiohang( int iMaSP)
        {
            //Lay giỏ hàng từ session
            List<GioHang> lstgiohang = Laygiohang();
            //Kiểm tra sách đã có trong session giỏ hàng chưa
            GioHang sanpham = lstgiohang.SingleOrDefault(n => n.iMasach == iMaSP);
            if(sanpham != null)
            {
                lstgiohang.RemoveAll(n => n.iMasach == iMaSP);
                return RedirectToAction("Giohang");
            }
            if(lstgiohang.Count == 0)
            {
                return RedirectToAction("Index","SACHes");
            }
            //Nếu tồn tại thì xóa số lượng
            return RedirectToAction("Giohang");
        }
        //Cập nhập giỏ hàng
        public ActionResult Capnhapgiohang(int iMaSP, FormCollection f)
        {
            //Lay giỏ hàng từ session
            List<GioHang> lstgiohang = Laygiohang();
            //Kiểm tra xem sách đã có trong session giỏ hàng chưa?
            GioHang sanpham = lstgiohang.SingleOrDefault(n => n.iMasach == iMaSP);
            //Nếu tồn tại thì sửa số lượng
            if(sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtSoluong"].ToString());

            }
            return RedirectToAction("Giohang");
        }
        //Xóa tất cả giỏ hàng
        public ActionResult Xoatatca()
        {
            //Lay giỏ hàng từ session
            List<GioHang> lstgiohang = Laygiohang();
            lstgiohang.Clear();
            return RedirectToAction("Index","SACHes");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap","KHACHHANGs");
            }
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "SACHes");
            }
            List<GioHang> lstgiohang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return View(lstgiohang);
        }
        public ActionResult Dathang(FormCollection collection)
        {
            //THêm đơn hàng
            DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            List<GioHang> gh = Laygiohang();
            ddh.MaKH = kh.MaKH;
            ddh.Ngaydat = DateTime.Now;
            var Ngaygiao = String.Format("{0:DD/mm/yyy}",collection["Ngaygiao"]);
            ddh.Ngaygiao = DateTime.Parse(Ngaygiao);
            ddh.Tinhtranggiaohang = false;
            db.DONDATHANGs.Add(ddh);
            db.SaveChanges();
            //Thêm đơn đặt hàng
            foreach(var item in gh)
            {
                CHITIETDONTHANG ctdh = new CHITIETDONTHANG();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.Masach = item.iMasach;
                ctdh.Soluong = item.iSoluong;
                ctdh.Dongia = (decimal)item.dDongia;
                db.CHITIETDONTHANGs.Add(ctdh);
            }
            db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHangs");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
   
    }
}
