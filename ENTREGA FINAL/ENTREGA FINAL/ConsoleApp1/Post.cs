using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Post
    {
        public int Id { get; set; }
        public int userId { get; set; }

        public string title { get; set; }

        public string body { get; set; }
        public Post( int Id, int userId, string title, string body) {
            this.Id = Id;
            this.userId = userId;
            this.title = title;
            this.body = body;
        }
    }
}
