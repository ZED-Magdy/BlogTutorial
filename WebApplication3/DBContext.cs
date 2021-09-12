using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3
{
    public class DBContext
    {
        private readonly List<User> _Users = new List<User>();
        public IReadOnlyCollection<User> Users => _Users.AsReadOnly();
        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
        public DBContext()
        {
            _Users.AddRange(new List<User>
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
            Categories = new List<Category>();
            Categories.AddRange(new[]
            {
                new Category
                {
                    Id = 1,
                    Name = "Space"
                },
                new Category
                {
                    Id = 2,
                    Name = "Science"
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
                    Id = 1,
                    Category = Categories.FirstOrDefault(c => c.Id == 1)
                },
                new Post
                {
                    Title = "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine.",
                    Excerpt = "Problems look mighty small from 150 miles up",
                    Owner = Users.Where(user => user.Name == "Rama").FirstOrDefault(),
                    Content = "Never in all their history have men been able truly to conceive of the world as one: a single sphere, a globe, having the qualities of a globe, a round earth in which all the directions eventually meet, in which there is no center because every point, or none, is center — an equal earth which ",
                    Id = 2,
                    Category = Categories.FirstOrDefault(c => c.Id == 2)
                },
                new Post
                {
                    Title = "Science has not yet mastered prophecy",
                    Excerpt = "We predict too much for the next year and yet far too little for the next ten.",
                    Owner = Users.Where(user => user.Name == "Abdullah").FirstOrDefault(),
                    Content = "Never in all their history have men been able truly to conceive of the world as one: a single sphere, a globe, having the qualities of a globe, a round earth in which all the directions eventually meet, in which there is no center because every point, or none, is center — an equal earth which ",
                    Id = 3,
                    Category = Categories.FirstOrDefault(c => c.Id == 2)
                },
            });
            var spaceCategoy = Categories.FirstOrDefault(c => c.Id == 1);
            spaceCategoy.Posts.Add(Posts.FirstOrDefault(p => p.Id == 1));
            var scienceCategory = Categories.FirstOrDefault(c => c.Id == 2);
            scienceCategory.Posts.AddRange(Posts.Where(p => p.Id != 1));
        }
    }
}
