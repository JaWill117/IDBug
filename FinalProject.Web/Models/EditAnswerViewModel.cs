using System.Collections.Generic;

namespace FinalProject.Web.Models
{
    public class EditAnswerViewModel
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public List<EditAnswerPestViewModel> PestAnswers { get; set; }
        public string QuestionText { get; set; }
        public int QuestionId { get; set; }
    }
}