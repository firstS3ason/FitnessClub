using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProblems.Interfaces
{
    public interface IBuyerWindow
    {
        public void SendingInfo();
        public void ChoosingCoach();

        public DateTime DateOfBeingPartners { get; set; }
        public string UserName { get; set; }


       
        
    }
}
