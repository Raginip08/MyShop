using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public abstract class Base
    {
        public string Id { get; set; }
        public DateTime createdAt { get; set; }

        public Base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.createdAt = DateTime.Now;
        }
    }
}
