using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Repository
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }
        public int Stars { get; set; }
    }
}
