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
        public MajorCategory Category { get; set; }
        public bool NumberOfLegs { get; set; }
        public bool Tail { get; set; }
        public bool BigAbdomen { get; set; }
        public bool Hair { get; set; }
        public bool color { get; set; }
        public bool DistinctCharacterisc { get; set; }
        public string URLPic { get; set; }
        public string URLInfo { get; set; }

    }


    public enum MajorCategory
    {
        Arachids,
        Insects,
        Rodents
    }
}

