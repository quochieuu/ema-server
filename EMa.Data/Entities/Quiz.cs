using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string QuestionName { get; set; }
        public int NoAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public string InCorrectAnswer1 { get; set; }
        public string InCorrectAnswer2 { get; set; }
        public string InCorrectAnswer3 { get; set; }
        public string InCorrectAnswer4 { get; set; }
        public string InCorrectAnswer5 { get; set; }

    }
}
