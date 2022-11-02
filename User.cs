using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    internal class User
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
