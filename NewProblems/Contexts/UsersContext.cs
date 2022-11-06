using Microsoft.EntityFrameworkCore;
using NewProblems.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewProblems.Contexts
{
    /*
     * Заметки:
     * DbContext - Класс, что создан для определения констекста данных, что в дальнейшем будут использоваться при взаимодействии с БД.
     * DbSet или обобщенный аналог - DbSet<Class>, классы : воссоздают экземпляры, хранящиеся внутри себя таблицы, для потенциальной БД.
     * DbContextOptionsBuilder - класс, позволяет создать экземпляр, от лица которого Вы настраиваете подключение к нужной БД.
    */
     
    
    public class UsersContext : DbContext // Для использования методов, конструкторов и свойств ниже, мы воссоздаем наследование от данного класса.
    {
        public DbSet<Users> Users { get; set; } = null!;

      

        public UsersContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=OnlyMyself\YAYA;Database=Fitnesss;Integrated Security=True;");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              base.OnModelCreating(modelBuilder);

              modelBuilder.Entity<Users>().HasData(new Users()
              {
                  ID = 1
                  Login = "Hello",
                  Password = "Here2",
                  Permissions = "Zero"


              }) ;


        }*/

     

        public IQueryable<Users> GetAll()
        {
            return Users;
        }


    }
}
