using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Start
{
    public enum ProblemType
    {
        Home,
        Work
    }
    public class Problem
    {
        public string ProblemName { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public ProblemType ProblemType { get; set; }

        public override string ToString()
        {
            return $"{ProblemName}: {Description} - {ProblemType} / Piority: {Priority}";
        }
    }
}
