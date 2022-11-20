using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace NewProblems.Models
{
    public class Coaches
    {
        [Key]

        public int CoachId { get; set; }

        public string? CoachName { get; set; }

        public int Age { get; set; }

        public string? Gender { get; set; }

        public int YearsInStudyPractise { get; set; }

        public DateTime InOurGymFrom { get; set; }

        public string? SpecialistIn { get; set; }


    }
}
