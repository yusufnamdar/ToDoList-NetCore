using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Database
{
    public class ToDoContext : DbContext//extend DbContext???
    {
        public ToDoContext(DbContextOptions<ToDoContext> options):base(options)//parameter ?--ctor props??
        {
            
        }

        public DbSet<TodoList> ToDoList { get; set; }//wut-command or not?
    }
}
