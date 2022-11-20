using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProblems.Models
{
    public class CoachInvites
    {
            [Key]
            public int ID { get; set; }

            public string? RequestStatus { get; set; }

            public string? CoachName { get; set; }
            
            public string? NameOfPostMan { get; set; }

    }
}
