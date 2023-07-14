using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    [Keyless]
    public class ListOfCommits
    {
        public string sha { get; set; }
        public int commitCount { get; set; }
        public Commit commit { get; set; }
    }

    public class Commit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string commitSha { get; set; }
        public Author author { get; set; }
        public Committer committer { get; set; }
        public string message { get; set; }
        public DateTime Date { get; set; }
        public int comment_count { get; set; }
    }

    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }
    }

    public class Committer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }
    }

    public class RootObject
    {
        public List<ListOfCommits> commits { get; set; }
    }
}