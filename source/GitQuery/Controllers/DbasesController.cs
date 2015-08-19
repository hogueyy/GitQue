using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using GitQuery.Models;
using System.Data.SqlClient;
using System.IO;
using System.Data.Common;

namespace GitQuery.Controllers
{
    public class DbasesController : Controller
    {
        private ApplicationDbContext Userdb;
        private UserManager<ApplicationUser> manager;
        private UserStore<ApplicationUser> store;
        private ApplicationDbContext db = new ApplicationDbContext();
        private string[] dbNames = {"Oracle", "MySQL", "MS SQL Server", "PostgreSQL"};

        public DbasesController()
        {
            Userdb = new ApplicationDbContext();
            store = new UserStore<ApplicationUser>(Userdb);
            manager = new UserManager<ApplicationUser>(store);
        }

        // GET: Dbases
        public async Task<ActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            ViewBag.Commits = currentUser.commits;
            if (currentUser.commits.Count > 0)
            {
                ViewBag.First = currentUser.commits.First();
                ViewBag.Day = ViewBag.First.created_at.DayOfWeek;
            }
            foreach(Dbase b in currentUser.bases.ToList())
            {
                // if a new Dbase has been created, but not authenticated, remove it
                if(!b.authenticated)
                {
                    currentUser.bases.Remove(b);
                    Userdb.Bases.Remove(b);
                    Userdb.SaveChanges();
                }

                // if a user began the 'Undo Query' process but did not finish, delete the associated 'updates.txt'. It contains temporary/private info
                if (b.badCommit != -1)
                {
                    Commit com = Userdb.Commits.Find(b.badCommit);
                    System.IO.File.Delete(Server.MapPath("~/App_Data/" + com.User.Email + "/" + com.name + "/updates.txt"));
                    com.uid = "*";
                    com.password = "*";
                    b.badCommit = -1;
                    Userdb.SaveChanges();
                }

                // if a commit was created more than a month ago, remove it from GitQuery database and delete all of its data
                foreach(Commit c in b.commits)
                {
                    if(Math.Abs(DateTime.Today.DayOfYear - c.created_at.DayOfYear) > 31)
                    {
                        Directory.Delete(Server.MapPath("~/App_Data/" + c.User.Email + "/" + c.name), true);
                        Userdb.Commits.Remove(c);
                        b.commits.Remove(c);
                        Userdb.SaveChanges();
                    }
                }
            }
            return View(currentUser.bases);
        }

        // GET: Dbases/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            if (id == null)
            {
                id = currentUser.currentID;
            }
            Dbase dbase = db.Bases.Find(id);
            if (dbase == null)
            {
                return HttpNotFound();
            }
            currentUser.currentID = dbase.ID;
            Userdb.SaveChanges();

            // take the last 10 commits. of these, find out when the oldest commit was created at
            ViewBag.Commits = dbase.commits.Skip(Math.Max(0, dbase.commits.Count - 10));
            if (ViewBag.Commits.Count > 0)
            {
                ViewBag.First = dbase.commits.First();
                ViewBag.Day = ViewBag.First.created_at.DayOfWeek;
            }
            return View(dbase);
        }

        // GET: Dbases/Create
        public ActionResult Create(int? step, int? dbType)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (step == null){ViewBag.Step = 0;}
            else 
            {
                ViewBag.Step = step;
                ViewBag.dbType = dbType;
            }
            ViewBag.Error = "";
            return View();
        }

        // POST: Dbases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,name,server,dbType")] Dbase dbase)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            ViewBag.Step = 1;
            if (ModelState.IsValid)
            {
                // For some reason, the HiddenFor for model.dbType in Create.cshtml always sets 'value' equal to an int when converted to HTML. 
                // So, this conversion is neccessary
                dbase.dbType = dbNames[Convert.ToInt32(dbase.dbType)];
                Userdb.Bases.Add(dbase);
                dbase.User = currentUser;
                await Userdb.SaveChangesAsync();
                currentUser.bases.Add(dbase);
                currentUser.currentDB = currentUser.bases.Last();
                currentUser.currentID = dbase.ID;
                await Userdb.SaveChangesAsync();
                ViewBag.Step = 2;
            }

            return View(dbase);
        }

        [ActionName("Create2")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(String username, String pass)
        {
            await Task.Delay(1000);
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            ViewBag.Step = 2;
            Dbase curDB = Userdb.Bases.Find(currentUser.currentID);
            string connectionString =
                "Data Source=" + curDB.server +
                ";Initial Catalog=" + curDB.name;
            connectionString += ";User Id=" + username +
                                ";Password=" + pass + ";";
            ViewBag.Error = "";
            using (DbConnection connection = QueryController.getConnectionType(connectionString, curDB.dbType))
            {
                // Open the connection  
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return RedirectToAction("Error");
                }
            }
            if(ViewBag.Error == "")
            {
                currentUser.currentDB.authenticated = true;
                Userdb.SaveChanges();
            }
             
            return RedirectToAction("Index");
        }

        // GET: Dbases/Edit/5
        public ActionResult Error()
        {
            return View();
        }

        // GET: Dbases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dbase dbase = db.Bases.Find(id);
            if (dbase == null)
            {
                return HttpNotFound();
            }
            return View(dbase);
        }

        // POST: Dbases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,server")] Dbase dbase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbase);
        }

        // GET: Dbases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dbase dbase = db.Bases.Find(id);
            if (dbase == null)
            {
                return HttpNotFound();
            }
            return View(dbase);
        }

        // POST: Dbases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dbase dbase = db.Bases.Find(id);
            db.Bases.Remove(dbase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}