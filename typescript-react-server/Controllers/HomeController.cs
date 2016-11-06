using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace typescript_react_server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            var rappers = new[]
            {
                new Rapper
                {
                    Id = Guid.NewGuid(),
                    Age = 32,
                    Name = "Tony McRapperson",
                    RealName = "Tony Block"
                },
                new Rapper
                {
                    Id = Guid.NewGuid(),
                    Age = 31,
                    Name = "Bob Spanners",
                    RealName = "Robert S"
                }
            };

            var badPeople = new Label("Crime Doing Crew", rappers);

            return Ok(badPeople);
        }
    }

    public class Rapper
    {
        public Guid Id { get; set; }

        public int Age { get; set; }

        public string RealName { get; set; }

        public string Name { get; set; }

        public Guid LabelId { get; set; }
    }

    public class Label
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Rapper[] Rappers { get; set; }

        public Label(string name, IReadOnlyCollection<Rapper> rappers)
        {
            Id = Guid.NewGuid();
            Name = name;

            foreach (var rapper in rappers)
            {
                rapper.LabelId = Id;
            }

            Rappers = rappers.ToArray();
        }
    }
}
