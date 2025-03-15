using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.BaseDtos
{
    [Table("Entities")]
    public class EntityDto
    {
        [PrimaryKey, AutoIncrement, Indexed, NotNull]
        public uint Id { get; set; }
    }
}
