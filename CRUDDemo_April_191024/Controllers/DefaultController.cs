using CRUDDemo_April_191024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDDemo_April_191024.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowAll()
        {
           StudDBEntities1 dbo=new StudDBEntities1();
            List<tblStudent> studList = dbo.tblStudents.ToList();
            return View(studList);
        }
        public ActionResult Edit(int id)
        {
            StudDBEntities1 db = new StudDBEntities1();
            tblStudent  stud = db.tblStudents.Find(id);
            return View(stud);
        }
        [HttpPost]
        public ActionResult Edit(tblStudent st)
        {
            //Edit logic

            StudDBEntities1 dbo = new StudDBEntities1();
            tblStudent s1 = dbo.tblStudents.Find(st.id);
            s1.name = st.name;
            s1.totalMarks = st.totalMarks;
            s1.div = st.div;
            int n = dbo.SaveChanges();
            return RedirectToAction("ShowAll");
        }

    }
}