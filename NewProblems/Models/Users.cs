using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.ComponentModel.DataAnnotations; // Для создания "ключевого" поля.
using NewProblems.Contexts;

namespace NewProblems.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string? Login { get; set; }
        public string? Password{ get; set; }
        public string? Permissions { get; set; }
    }
}
