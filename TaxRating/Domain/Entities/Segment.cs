using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Segment
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Tax { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }

        public Segment()
        {
            Name = string.Empty;
            Created = DateTime.Now;
        }

        public Segment(int id, string name, double tax, bool isActive = true)
        {
            Id = id;
            Name = name;
            Tax = tax;
            IsActive = isActive;
            Created = DateTime.Now;
        }

        public Segment(string name, double tax, bool isActive = true)
        {          
            Name = name;
            Tax = tax;
            IsActive = isActive;
            Created = DateTime.Now;
        }

        public void ChangeActive(bool IsActive)
        {
            this.IsActive = IsActive;
            Updated = DateTime.Now;
        }
      

        public void ChangeSegment(string name, double tax, bool isActive)
        {           
            Name = name;
            Tax = tax;
            IsActive = isActive;
            Updated = DateTime.Now;
        }


    }
}
