using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Code_CH.Models;

namespace Code_CH.Controllers
{
    public class HomeController : Controller
    {
        CuaHangEntities2 database = new CuaHangEntities2();
        public ActionResult Index()
        {
            return View(database.DauSanPhams);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Accout_Admin ad)
        {
            var check = database.Accout_Admin.Where(s => s.User.Equals(ad.User) && s.Password.Equals(ad.Password)).FirstOrDefault();
            if (check == null)
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
                return View("", ad);
            }
            else
            {
                Session["Admin"] = ad.User;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult DauSanPham(string _name)
        {
           /* var DauSanPham = database.DauSanPhams.ToList().OrderByDescending(s => s.maDSP).ToList();
            if (Session["Admin"] != null)
            {
                if (_name == null)
                {
                    return View(DauSanPham);
                }
                else
                    return View(database.DauSanPhams.Where(s => s.tenSP.Contains(_name)).ToList());
            }
            else
                return RedirectToAction("Index", "Home");*/
            return View(database.DauSanPhams);

        }
        /*----- Đăng xuất -----*/

        public ActionResult Logout(Accout_Admin ad)
        {
            Session["Admin"] = null;
            return RedirectToAction("", "");

        }

        /*---- Đổi mật khẩu ----*/
        public ActionResult ChangePass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePass(Accout_Admin ad, string _name, string _newPass, string _nhapLaiPass)
        {
            ad = database.Accout_Admin.Where(s => s.maAdmin == 1 && s.Password == _name).FirstOrDefault();            
            if (ad != null)
            {
                if (_newPass == _nhapLaiPass)
                {
                    ad.Password = _newPass;
                    database.Entry(ad).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();
                    ViewBag.Error_ChangePass = "Đổi mật khẩu thành công";
                }
                else
                {
                    ViewBag.Error_ChangePass = "Mật khẩu không trùng khớp";
                }
                return View("ChangePass", ad);
            }
            else
            {
                ViewBag.Error_ChangePass = "Mật khẩu cũ không đúng!";
                return View("ChangePass", ad);

            }
        }

        /*Quản lí đầu sản phẩm*/
        public ActionResult ThemDauSanPham()
        {
            DauSanPham dsp = new DauSanPham();
            return View(dsp);
        }

        [HttpPost]
        public object ThemDauSanPham(DauSanPham sanpham, string imageUploader)
        {
            if (sanpham.imageUploader != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(sanpham.imageUploader.FileName);
                string extension = Path.GetExtension(sanpham.imageUploader.FileName);
                fileName = fileName + extension;
                sanpham.hinhanhSP = "~/Content/Image_SanPham/" + fileName;
                sanpham.imageUploader.SaveAs(Path.Combine(Server.MapPath("~/Content/Image_SanPham/"), fileName));
                sanpham.soluongSP = 0;
            /*    //sanpham.giaSP = gia;
                sanpham.hinhanhSP = null;*/

                database.DauSanPhams.Add(sanpham);
                database.SaveChanges();
             /*   return RedirectToAction("Index", "Home", sanpham);*/

            }
            return RedirectToAction("Index", "Home", sanpham);
            //sanpham.tenSP = tenSanPham;
            //sanpham.loaiSP = theLoai;

        }
        /*   [HttpPost]
       public object ThemDauSanPham( DauSanPham dausanpham, string imageUploader, string tenSanPham, string theLoai, float gia)
         {
             try
             {
                 if (dausanpham.imageUploader != null)
                 {
                     string fileName = Path.GetFileNameWithoutExtension(dausanpham.imageUploader.FileName);
                     string extension = Path.GetExtension(dausanpham.imageUploader.FileName);
                     fileName = fileName + extension;
                     dausanpham.hinhanhSP = "~/Content/Image_SanPham/" + fileName;
                     dausanpham.imageUploader.SaveAs(Path.Combine(Server.MapPath("~/Content/imgsach/"), fileName));
                 }

                 var check = database.DauSanPhams.Where(a => a.maDSP == maDauSanPham).SingleOrDefault();
                 if (check == null)
                 {
                     *//* sanpham.maDSP = maDauSanPham;*//*
                     dausanpham.tenSP = tenSanPham;
                     dausanpham.loaiSP = theLoai;
                     dausanpham.soluongSP = 0;
                     dausanpham.giaSP = gia;

                     database.DauSanPhams.Add(dausanpham);
                     *//* database.SubmitChanges();*//*
                     database.SaveChanges();
                     return RedirectToAction("Index", "Home", dausanpham);

                 }
                 else
                 {
                     ViewBag.ThemDauSanPham = "Trùng mã sản phẩm!";
                     return View(dausanpham);
                 }
             }
             catch
             {
                 return View(Content("Dữ Liệu đã tồn tại!!"));
             }
         }*/
        public ActionResult SuaDauSanPham(int id)
        {
            return View(database.DauSanPhams.Where(a => a.maDSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaDauSanPham(int id, DauSanPham DauSanPham, string imageUploader,string imageUploader2, string imageUploader3, string imageUploader4, string imageUploader5, string imageUploader6)
        {
            DauSanPham = database.DauSanPhams.Where(item => item.maDSP == id).SingleOrDefault();
            DauSanPham.hinhanhSP = "~/Content/Image_SanPham/" + imageUploader;
            DauSanPham.hinhanhphu1 = "~/Content/Image_SanPham/" + imageUploader2;
            DauSanPham.hinhanhphu2 = "~/Content/Image_SanPham/" + imageUploader3;
            DauSanPham.hinhanhphu3 = "~/Content/Image_SanPham/" + imageUploader4;
            DauSanPham.hinhanhphu4 = "~/Content/Image_SanPham/" + imageUploader5;
            DauSanPham.hinhanhphu5 = "~/Content/Image_SanPham/" + imageUploader6;
            database.Entry(DauSanPham).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            /*ViewBag.SuaDauSach_suss = "Sửa thành công !!!";*/
            return RedirectToAction("Index","Home", DauSanPham);
        }
        public ActionResult EditUploadImage(int id)
        {
            return View(database.DauSanPhams.Where(a => a.maDSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditUploadImage(int id, DauSanPham DauSanPham, string imageUploader, string imageUploader2, string imageUploader3, string imageUploader4, string imageUploader5, string imageUploader6)
        {
            DauSanPham = database.DauSanPhams.Where(item => item.maDSP == id).SingleOrDefault();
            DauSanPham.hinhanhSP = "~/Content/Image_SanPham/" + imageUploader;
            DauSanPham.hinhanhphu1 = "~/Content/Image_SanPham/" + imageUploader2;
            DauSanPham.hinhanhphu2 = "~/Content/Image_SanPham/" + imageUploader3;
            DauSanPham.hinhanhphu3 = "~/Content/Image_SanPham/" + imageUploader4;
            DauSanPham.hinhanhphu4 = "~/Content/Image_SanPham/" + imageUploader5;
            DauSanPham.hinhanhphu5 = "~/Content/Image_SanPham/" + imageUploader6;
            database.Entry(DauSanPham).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            /*ViewBag.SuaDauSach_suss = "Sửa thành công !!!";*/
            return RedirectToAction("Index", "Home", DauSanPham);
        }
        [HttpGet]
        public ActionResult XoaDauSanPham(int id)
        {
            ViewBag.Message = string.Format("Hello {0}.\\nCurrent Date and Time: {1}", id, DateTime.Now.ToString());
            var DauSanPham = database.DauSanPhams.Where(a => a.maDSP == id).SingleOrDefault();
            database.DauSanPhams.Remove(DauSanPham);
            database.SaveChanges();
            return RedirectToAction("Index", "Home");
            /* var check = database.DauSanPhams.Where(a => a.maDSP == id).FirstOrDefault();
             if (check == null)
             {
                 var DauSanPham = database.DauSanPhams.Where(a => a.maDSP == id).SingleOrDefault();
                 database.DauSanPhams.Remove(DauSanPham);
                 database.SaveChanges();
             }
             else
             {
                 ViewBag.Error_XoaDauSach = "Không thể xoá vì còn tồn tại sách thuộc đầu sách này";
             }
             return RedirectToAction("Index", "Home");*/

        }
/*Chi tiết sản phẩm*/
        public ActionResult ChiTietSanPham()
        {
            return View(database.SanPhams);
        }

        //Thêm Chi tiết sản phẩm
        public ActionResult ThemChiTietSanPham(int id)
        {
            var flag = database.DauSanPhams.Where(a => a.maDSP == id).SingleOrDefault();
            SanPham dsp = new SanPham();
            /* ViewBag.Id_SanPham = id.ToString();
             ViewBag.Ten_SanPham = flag.tenSP;*/
            return View(dsp);
        }
        [HttpPost]
        public ActionResult ThemChiTietSanPham(SanPham sanpham, int id, int sks)
        {
              var DauSanPham = database.DauSanPhams.Where(a => a.maDSP == id).SingleOrDefault();
              var checkSoLuong = database.SanPhams.Where(a => a.maDSP == id).Count();
            int soluongSP = sks;


            if (checkSoLuong == 0)
            {
                for (int i = 1; i <= soluongSP; i++)
                {
                    var a = new SanPham();
                    a.maSP = id;
                    a.sokiemsoat = i;

                    database.SanPhams.Add(a);
                }
                /*----- Cap nhat so luong -----*/
              
                DauSanPham.soluongSP += soluongSP;

                database.SaveChanges();
                ViewBag.ThemSach_message_suss = "Thêm thành công!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                for (int i = checkSoLuong + 1; i <= checkSoLuong + soluongSP; i++)
                {
                    var a = new SanPham();
                    a.maDSP = id;
                    a.sokiemsoat = i;
                    database.SanPhams.Add(a);
                }
                /*----- Cap nhat so luong -----*/
                DauSanPham.soluongSP += soluongSP;

                database.SaveChanges();
                ViewBag.ThemSach_message_suss = "Thêm thành công!";
                return RedirectToAction("Index", "Home");
            }
        }
       

     }
}