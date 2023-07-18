using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Sprint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TrelloSprintId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
