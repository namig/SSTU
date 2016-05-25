using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star
{
    [Entity]
    public interface IFilm
    {
        //[Identifier("http://www.films.org/films/")]
        string Id { get; }
        string Name { get; set; }

        [InverseProperty("Films")]
        ICollection<IActor> Actors { get; }
    }
}
