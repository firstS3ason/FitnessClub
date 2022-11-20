using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProblems.Models
{
    public class TrainingsList
    {
        [Key]

        public int ID { get; set; }

        public string? CoachName { get; set; }

        public string? TypeOfExcersice { get; set; }

        public int Repeats { get; set; }

        public int ActionsPerRepeat { get; set; }
        public string? CreatedForWho { get; set; }

    }
}
