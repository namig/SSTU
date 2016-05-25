using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star
{
    [Entity]
    public interface IActor
    {
        //[Identifier("http://www.films.org/actors/")]
        string Id { get;  }

        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        
        ICollection<IFilm> Films { get; set; }
    }
}
