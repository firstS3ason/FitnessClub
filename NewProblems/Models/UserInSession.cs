using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NewProblems.WIndows;

namespace NewProblems.Models
{
    public class UserInSession <T> where T: Users  // воссоздаем возможность в виде закрепления текущего, что пользуется программой пользователя, как экземпляр к свойству.
    { 


        public string User { get; set; }
        public string TypeOfPerson { get; set; }
        public UserInSession(T user)
        {
            User = user.Login;
            TypeOfPerson = user.Permissions;
        }
    }
}
