using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoreCrudApp.Models
{
    public class Categories
    {
       

        [Key]
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public ICollection<Exercise> Exercise { get; set; }

        public Categories()
        {
            Exercise = new HashSet<Exercise>();
        }
    }
}
