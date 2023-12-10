using GreenThumb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb2.Database
{
    internal class InstructionRepository
    {
        private readonly GreenThumb2DbContext _context;
        public InstructionRepository(GreenThumb2DbContext context)
        {
            _context = context;
        }
    }
}
