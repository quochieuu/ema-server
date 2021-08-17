using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMa.Data.Entities
{
    public class LessionQuiz
    {
        public Guid Id { get; set; }
        public string QuestionType { get; set; }
        public Guid LesionId { get; set; }
        public Guid QuizId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Lession Lession { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
