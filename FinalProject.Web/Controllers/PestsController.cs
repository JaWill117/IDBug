using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Web.Models;

namespace FinalProject.Web.Controllers
{
    public class PestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowNextQuestion()
        {

            //grab the question id out of the session, if it's not set assume question id of 1
            //then find that question in the db
            //create the view model to dispaly the question and answer to the user.

            int questionId = 1;
            if (Session["CurrentQuestionId"] != null)
            {
                questionId = (int)Session["CurrentQuestionId"];
            }
            else
            {
                Session["CurrentQuestionId"] = 1;
            }
            var question = db.Questions.Find(questionId);

            var model = new QuestionViewModel();
            model.QuestionId = question.Id;
            model.QuestionText = question.Text;
           // model.Answers = question.Answers.Select(a => new KeyValuePair(a.Id, a.Text));

            return View();
        }

        [HttpPost]
        public ActionResult ShowNextQuestion(int SelectedAnswer)
        {

            //SelectedAnswer is the id of the answer they selected. Find it and find that answer's next question id .
            //also store the selected answer in the session
            //redirect them back to ShowNextQuestion
            Session["CurrentQuestionId"] = db.Answers.Find(SelectedAnswer).NextQuestion.Id;

            //if the answer's next question is null then redirect them to a results page or something
            return RedirectToAction("ShowNextQuestion");
        }


        // GET: Pests
        public ActionResult Index()
        {
            return View(db.Pests.ToList());
        }

        // GET: Pests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pest pest = db.Pests.Find(id);
            if (pest == null)
            {
                return HttpNotFound();
            }
            return View(pest);
        }

        // GET: Pests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pest pest)
        {
            if (ModelState.IsValid)
            {
                db.Pests.Add(pest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pest);
        }

        // GET: Pests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pest pest = db.Pests.Find(id);
            if (pest == null)
            {
                return HttpNotFound();
            }
            return View(pest);
        }

        // POST: Pests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pest pest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pest);
        }

        // GET: Pests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pest pest = db.Pests.Find(id);
            if (pest == null)
            {
                return HttpNotFound();
            }
            return View(pest);
        }

        // POST: Pests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pest pest = db.Pests.Find(id);
            db.Pests.Remove(pest);
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

        public class QuestionViewModel
        {
            public QuestionViewModel()
            {
                
            }

            public object Answers { get; internal set; }
            public int QuestionId { get; internal set; }
            public string QuestionText { get; internal set; }
        }

        public class KeyValuePair
        {
            public int id;
            public string text;

            public KeyValuePair(int id, string text)
            {
                this.id = id;
                this.text = text;
            }
        }
    }
}
