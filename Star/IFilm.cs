using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star
{
    [Entity("http://www.films.org#Film")]
    public interface IFilm
    {
        [Identifier("http://www.films.org/films#")]
        string Id { get; }
        [PropertyType("http://www.films.org#name")]
        string Name { get; set; }

        [InverseProperty("Films")]
        ICollection<IActor> Actors { get; }
    }
}
