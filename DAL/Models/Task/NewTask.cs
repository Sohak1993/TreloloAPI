using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Task
{
    public class NewTask
    {
        public string Name { get; set; }
        public DateTime DeadLine { get; set; }
        public int IdList { get; set; }
    }
}
