using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    [Table("Clients")]
    public class ClientDto : UserDto
    {
        [PrimaryKey]
        public uint AccountId { get; set; }
        public string Password { get; set; }
    }
}
