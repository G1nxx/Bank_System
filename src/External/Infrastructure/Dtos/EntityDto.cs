using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    [Table("Entities")]
    internal class EntityDto
    {
        [PrimaryKey, AutoIncrement, Indexed, NotNull]
        public uint Id { get; set; }
    }
}
