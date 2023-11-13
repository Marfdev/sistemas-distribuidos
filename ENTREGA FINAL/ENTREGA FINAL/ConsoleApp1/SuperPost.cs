using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SuperPost
    {
        public int Id { get; set; }
        public int userId { get; set; }

        public string title { get; set; }

        public string body { get; set; }

        public List<Comment> comments { get; set; }
        public SuperPost(int Id, int userId, string title, string body, List<Comment> comments)
        {
            this.Id = Id;
            this.userId = userId;
            this.title = title;
            this.body = body;
            this.comments = comments;
        }
    }
}
