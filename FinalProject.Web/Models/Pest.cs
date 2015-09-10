using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Web.Models
{
    public class Pest
    {
        public int Id { get; set; }
        public string PestName { get; set; }
        public string Description { get; set; }

        public ICollection<Answer> PestAnswers { get; set; }
        //public MajorCategory Category { get; set; }
        //public string URLPic { get; set; }
        //public string URLInfo { get; set; }
        //public int NumberOfLegs { get; set; }
        //public bool Tail { get; set; }
        //public bool BigAbdomen { get; set; }
        //public bool Hair { get; set; }
        //public string DistinctCharacterisc { get; set; }
        //public PestColor Color { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Answer> LeadingAnswers { get; set; }
    }

    public class Answer
    {
        public int  Id { get; set; }
        public string Text { get; set; }
        public Question NextQuestion { get; set; }
        public Question ParentQuestion { get; set; }

        public ICollection<Pest> AssociatedPest { get; set; }
    }

  //  public enum MajorCategory
  //  {
  //      Arachnids,
  //      Insects,
  //      Rodents
  //  }
  //  [Flags]
  //  public enum PestColor
  //  {
  //      White = 1,
  //      Black = 2, 
  //      Red = 4,
  //      Orange = 8,
  //      Brown = 16,
  //      Tan = 32,
  //      Grey = 64,
  //      yellow = 128,
  //  }
}   

