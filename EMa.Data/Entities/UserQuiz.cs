using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class UserQuiz
    {
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string Answer { get; set; }
        public bool RightOrWrong { get; set; }
        public int NoExams { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
