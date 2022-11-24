using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services
{
    class DdlCategory
    {
        public DdlCategory(int id, string name, bool v)
        {
            ID = id;
            Name = name;
            Check_Status = v;
        }

        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public Boolean Check_Status
        {
            get;
            set;
        }
    }
}
