using NewProblems.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace NewProblems.Interfaces.ToCoach
{
    public interface ICoachWindow
    {
        public static string? CurrentCoach { get; set; }

         void InvitesLoad(UsersContext context);

         void CreatingProgramm(); // Method for the button with factiolly same name; Opening new, secondary window.



    }
}
