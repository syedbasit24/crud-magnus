using CRUDMagnus.Data;
using CRUDMagnus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDMagnus.Controllers
{
    public class UserController : Controller
    {

        private readonly UserContext _Db;
        public UserController(UserContext Db)
        {
            _Db = Db;
        }
        public IActionResult UserList()
        {
            try
            {
                //    var userList = _Db.Users.ToList();
                var userList = from a in _Db.Users
                               join b in _Db.place
                               on a.Id equals b.pId into pl
                               from b in pl.DefaultIfEmpty()
                               select new User
                               {
                                   Id = a.Id,
                                   FirstName = a.FirstName,
                                   LastName = a.LastName,
                                   Email = a.Email,
                                   MobileNo = a.MobileNo,
                                   DOB = a.DOB,
                                   Gender = a.Gender,
                                   AWS = a.AWS,
                                   DevOps = a.DevOps,
                                   FullStackDeveloper = a.FullStackDeveloper,
                                   Middleware = a.Middleware,
                                   QAautomation = a.QAautomation,
                                   WebServices = a.WebServices,
                                   place = b == null ? "" : a.place



                               };



                return View(userList);

            }catch(Exception ex)
            {
                return View();
            }
        }
        public IActionResult Create()
        {
            loadPlace();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User u)
        {
            try
            {
               
                if(ModelState.IsValid)
                {
                    if (u.Id == 0)
                    {
                        _Db.Users.Add(u);
                        await _Db.SaveChangesAsync();
                        
                    }
                    else
                    {
                        _Db.Entry(u).State=EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    return RedirectToAction("UserList");

                }

                return View();
            }catch(Exception ex)
            {
                return RedirectToAction("UserList");
            }
        }

        private void loadPlace()
        {
            try
            {
                List<Place> placelist = new List<Place>();
                placelist = _Db.place.ToList();
                placelist.Insert(0, new Place { pId = 0, city = "please select", country="please select"});

                ViewBag.placeList = placelist;

            }catch(Exception ex) { }
        }
       
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var usr = _Db.Users.FindAsync(id);
                if(usr !=null)
                {
                    _Db.Users.Remove(usr);
                    await _Db.SaveChangesAsync(); 
                }
                return RedirectToAction("UserList");

            }catch(Exception ex)
            {
                return RedirectToAction("UserList");

            }
        }
    }
}
