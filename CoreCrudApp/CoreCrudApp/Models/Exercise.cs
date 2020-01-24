using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CoreCrudApp.Models
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Duration { get; set; }
        public int? CategoryId { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
