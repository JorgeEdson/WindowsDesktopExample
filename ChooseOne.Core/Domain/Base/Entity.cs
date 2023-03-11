using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Core.Domain.Base
{
    public abstract class Entity
    {
        public int Id { get;  set; }
        public DateTime CreationDate { get;  set; }

        public Entity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
