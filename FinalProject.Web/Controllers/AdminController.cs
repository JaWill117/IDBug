using FinalProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Web.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        public ActionResult QuestionDetail(int id)
        {
            var question = db.Questions.Find(id);

            return View(question);
        }

        public ActionResult EditAnswer(int id)
        {
            var answer = db.Answers.Find(id);

            var allPests = db.Pests.Select(x => new EditAnswerPestViewModel() { AlreadyAssociated = x.PestAnswers.Any(pa => pa.Id == id), PestId = x.Id, PestName = x.PestName }).ToList();

            var model = new EditAnswerViewModel
            {
                AnswerId = answer.Id,
                AnswerText = answer.Text,
                QuestionId = answer.ParentQuestion.Id,
                QuestionText = answer.ParentQuestion.Text,
                PestAnswers = allPests
            };

            return View(model);
        }

        public ActionResult UpdatePestAnswer(int answerId, int pestId, bool associate)
        {
            var pest = db.Pests.Find(pestId);
            var answer = db.Answers.Find(answerId);

            if (associate)
            {
                if (pest.PestAnswers.Contains(answer))
                    return Content("Already Associated");

                pest.PestAnswers.Add(answer);
            }
            else
            {
                if (!pest.PestAnswers.Contains(answer))
                    return Content("Already NOT Associated");

                pest.PestAnswers.Remove(answer);
            }

            db.SaveChanges();

            return Content($"Done: {answerId} {pestId} {associate}");
        }
    }
}