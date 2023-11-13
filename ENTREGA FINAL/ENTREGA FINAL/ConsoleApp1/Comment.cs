using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Comment
    {
        public int Id { get; set; }
        public int postId { get; set; }

        public string name { get; set; }

        public string email { get; set; }
        public string body { get; set; }
        public Comment(int Id, int postId, string name, string email, string body)
        {
            this.Id = Id;
            this.postId = postId;
            this.name = name;
            this.email = email;
            this.body = body;
        }
    }
}
