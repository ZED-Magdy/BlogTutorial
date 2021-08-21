using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3
{
    public class DBContext
    {
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
        public DBContext()
        {
            Users = new List<User>();
            Users.AddRange(new List<User>
            {
                new User
                {
                    Name = "Tuqa",
                    Email = "tuqa@mail.com"
                },
                new User
                {
                    Name = "Rama",
                    Email = "rama@mail.com"
                },
                new User
                {
                    Name = "Abdullah",
                    Email = "abdullah@mail.com"
                },
            });

            Posts = new List<Post>();
            Posts.AddRange(new List<Post>
            {
                new Post
                {
                    Title = "Man must explore, and this is exploration at its greatest",
                    Excerpt = "Problems look mighty small from 150 miles up",
                    Owner = Users.Where(user => user.Name == "Tuqa").FirstOrDefault(),
                    Content = "Never in all their history have men been able truly to conceive of the world as one: a single sphere, a globe, having the qualities of a globe, a round earth in which all the directions eventually meet, in which there is no center because every point, or none, is center — an equal earth which ",
                    Id = 1
                },
                new Post
                {
                    Title = "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine.",
                    Excerpt = "Problems look mighty small from 150 miles up",
                    Owner = Users.Where(user => user.Name == "Rama").FirstOrDefault(),
                    Content = "Never in all their history have men been able truly to conceive of the world as one: a single sphere, a globe, having the qualities of a globe, a round earth in which all the directions eventually meet, in which there is no center because every point, or none, is center — an equal earth which ",
                    Id = 2
                },
                new Post
                {
                    Title = "Science has not yet mastered prophecy",
                    Excerpt = "We predict too much for the next year and yet far too little for the next ten.",
                    Owner = Users.Where(user => user.Name == "Abdullah").FirstOrDefault(),
                    Content = "Never in all their history have men been able truly to conceive of the world as one: a single sphere, a globe, having the qualities of a globe, a round earth in which all the directions eventually meet, in which there is no center because every point, or none, is center — an equal earth which ",
                    Id = 3
                },
            });
        }
    }
}
