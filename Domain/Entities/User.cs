using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoCA.Domain.Entities
{
    class AppUser
    {
        Guid Id { get; set; }
        string UserName { get; set; } = null!;
        string PasswordHash { get; set; } = null!;

        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}
