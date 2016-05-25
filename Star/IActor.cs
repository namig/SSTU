using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star
{
    [Entity("http://www.films.org#Actor")]
    public interface IActor
    {
        [Identifier("actors#", KeyProperties = new[] { "Name" })]
        string Id { get;  }

        [PropertyType("http://www.films.org#name")]
        string Name { get; set; }

        [PropertyType("http://www.films.org#dob")]
        DateTime DateOfBirth { get; set; }

        [PropertyType("http://www.films.org#playIn")]
        ICollection<IFilm> Films { get; set; }
    }
}
