using NewProblems.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProblems.Interfaces.ToBuyer
{
    public interface IBuyerWindow
    {
        void SendingInfo(UsersContext context);
         void ChoosingCoach(UsersContext context);

        public DateTime DateOfBeingPartners { get; set; }
        public static string? UserName { get; set; }

    }
}
