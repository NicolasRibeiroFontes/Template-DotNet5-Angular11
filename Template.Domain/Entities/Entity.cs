using System;

namespace Template.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public int CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public DateTime? UpdatedData { get; set; }
        public bool IsActive { get; set; }
    }
}
