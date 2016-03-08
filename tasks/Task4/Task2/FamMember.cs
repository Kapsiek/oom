using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface FamMember   // public interface for sub classes
    {
      
      string Member_status { get; }  // Super Class property

      int Next_Year(int ago);  // Age changer Method for all Sub-Classes 

    }
}
