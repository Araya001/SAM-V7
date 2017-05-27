using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAM_V7.Models;
using System.Data.Entity.Infrastructure;

namespace SAM_V7.Controllers
{
    public class ProposalsController : Controller
    {
        private SAM_V7Context db = new SAM_V7Context();

        // GET: Proposals
        public ActionResult Index(string searchString, string oname)
        {
            string test = Session["OrganName"].ToString();


            var movies = from m in db.Proposals
                         select m;

            if ((Session["PSUPassport"] != null) && (Session["Position"].Equals("Advisor")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.Result1 == null).OrderByDescending(s => s.DocNo);
                }

            }
            else if ((Session["PSUPassport"] != null) && (Session["OrganName"].Equals("Student Union")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.Result2 == null&& s.Result1!=null && s.Result1.Equals("Accept")).OrderByDescending(s => s.DocNo);
                }
            }
            else if ((Session["PSUPassport"] != null) && (Session["OrganName"].Equals("Student Council")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.Result3 == null&&s.Result2!=null && s.Result2.Equals("Accept")).OrderByDescending(s => s.DocNo);
                }
            }
            else if ((Session["PSUPassport"] != null) && (Session["Position"].Equals("Head of Student Activity section")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.Result4 == null&& s.Result3!=null && s.Result3.Equals("Accept")).OrderByDescending(s => s.DocNo);
                }
            }
            else if ((Session["PSUPassport"] != null) && (Session["Position"].Equals("Head of Student Affairs division")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.Result5 == null&& s.Result4!=null&& s.Result4.Equals("Accept")).OrderByDescending(s => s.DocNo);
                }
            }
            else if ((Session["PSUPassport"] != null) && (Session["Position"].Equals("Assistant to the President for Student Development")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.Result6 == null && s.Result5 != null && s.Result5.Equals("Accept")).OrderByDescending(s => s.DocNo);
                }
            }
            else if ((Session["PSUPassport"] != null) && (Session["Position"].Equals("Vice President for Academic Affairs for Phuket Campus")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.Result7 == null && s.Result6 != null && s.Result6.Equals("Accept")).OrderByDescending(s => s.DocNo);
                }
            }
            else if ((Session["PSUPassport"] != null) && (Session["Position"].Equals("Student Activity Staffs")))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString));
                }
                else
                {
                    movies = movies.Where(s => s.DocNo != null).OrderByDescending(s => s.DocNo);
                }
            }else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.ActName.Equals(searchString)&&s.OrganName.Equals(test));
                }
                else
                {
                    movies = movies.Where(s => s.DocNo != null && s.OrganName.Equals(test)).OrderByDescending(s => s.DocNo);
                }
    
            }


            return View(movies.ToList());
        }


        public ActionResult Remark(string id)
        {
           
            Proposal p = db.Proposals.FirstOrDefault(m => m.DocNo == id);
            
            
            return View(p);
        }

        public FileResult Download(int id)
        {
            var fileToRetrieve = db.Files.FirstOrDefault(f => f.FileId == id);
            Console.Out.Write(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }



        // GET: Proposals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = db.Proposals.Include(s => s.Files).SingleOrDefault(s => s.DocNo == id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // GET: Proposals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proposals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocNo,OrganName,Date,Subject,ActName,StartDate,EndDate,Place,StdBudget,OthName,OthBudget,Total,Act1,Act2,Act3,Act4,Act5,Act6,Result1,Comment1,Result1Date,Result2,Comment2,Result2Date,Result3,Comment3,Result3Date,Result4,Comment4,Result4Date,Result5,Comment5,Result5Date,Result6,Comment6,Result6Date,Result7,Comment7,Result7Date,Remark")] Proposal proposal, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {

                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }


                        proposal.Files = new List<File> { avatar };
                    }
                    db.Proposals.Add(proposal);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(proposal);
        }

        // GET: Proposals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = db.Proposals.Include(s => s.Files).SingleOrDefault(s => s.DocNo == id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // POST: Proposals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocNo,OrganName,Date,Subject,ActName,StartDate,EndDate,Place,StdBudget,OthName,OthBudget,Total,Act1,Act2,Act3,Act4,Act5,Act6,Result1,Comment1,Result1Date,Result2,Comment2,Result2Date,Result3,Comment3,Result3Date,Result4,Comment4,Result4Date,Result5,Comment5,Result5Date,Result6,Comment6,Result6Date,Result7,Comment7,Result7Date,Remark")] Proposal proposal, HttpPostedFileBase upload, string id)
        {

            try
            { 
                if (ModelState.IsValid)
                {
                 
                    if (upload != null && upload.ContentLength > 0)
                    {
                            var avatar = new File
                            {
                                FileName = System.IO.Path.GetFileName(upload.FileName),
                                FileType = FileType.Avatar,
                                ContentType = upload.ContentType
                            };
                            using (var reader = new System.IO.BinaryReader(upload.InputStream))
                            {
                                avatar.Content = reader.ReadBytes(upload.ContentLength);
                            }

                            proposal.Files = new List<File> { avatar };
                        }
                    }
                    if (proposal.Result1 == "Edit"|| proposal.Result1 == "Reject") {
                        proposal.Remark = proposal.Remark + "     " + Session["Position"] + "    >>>>>>> " + "       [" + proposal.Result1Date + "]   " + proposal.Result1 + "    Comment : " + proposal.Comment1;
                    }
                    if (proposal.Result2 == "Edit" || proposal.Result2 == "Reject")
                    {
                        proposal.Remark = proposal.Remark + "     " + Session["Position"] + "   >>>>>>> " + "       [" + proposal.Result2Date + "]   " + proposal.Result2 + "    Comment : " + proposal.Comment2;
                    }
                    if (proposal.Result3 == "Edit" || proposal.Result3 == "Reject")
                    {
                        proposal.Remark = proposal.Remark + "     " + Session["Position"] + "   >>>>>>> " + "       [" + proposal.Result3Date + "]   " + proposal.Result3 + "    Comment : " + proposal.Comment3;
                    }
                    if (proposal.Result4 == "Edit" || proposal.Result4 == "Reject")
                    {
                        proposal.Remark = proposal.Remark + "     " + Session["Position"] + "   >>>>>>> " + "       [" + proposal.Result4Date + "]   " + proposal.Result4 + "    Comment : " + proposal.Comment4;
                    }
                    if (proposal.Result5 == "Edit" || proposal.Result5 == "Reject")
                    {
                        proposal.Remark = proposal.Remark + "     " + Session["Position"] + "   >>>>>>> " + "       [" + proposal.Result5Date + "]   " + proposal.Result5 + "    Comment : " + proposal.Comment5;
                    }
                    if (proposal.Result6 == "Edit" || proposal.Result6 == "Reject")
                    {
                        proposal.Remark = proposal.Remark + "     " + Session["Position"] + "   >>>>>>> " + "       [" + proposal.Result6Date + "]   " + proposal.Result6 + "    Comment : " + proposal.Comment6;
                    }
                    if (proposal.Result7 == "Edit" || proposal.Result7 == "Reject")
                    {
                        proposal.Remark = proposal.Remark + "     " + Session["Position"] + "   >>>>>>> " + "       [" + proposal.Result7Date + "]   " + proposal.Result7 + "    Comment : " + proposal.Comment7;
                    }
                    db.Entry(proposal).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(proposal);
        }

        // GET: Proposals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = db.Proposals.Find(id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // POST: Proposals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, int did)
        {
            File file = db.Files.FirstOrDefault(s => s.FileId == did);
            Proposal proposal = db.Proposals.FirstOrDefault(s => s.DocNo == id);
            db.Files.Remove(file);
            db.Proposals.Remove(proposal);
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
