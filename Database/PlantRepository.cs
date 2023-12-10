using GreenThumb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb2.Database
{
    internal class PlantRepository
    {
        private readonly GreenThumb2DbContext _context;

        public PlantRepository(GreenThumb2DbContext context)
        {
            _context = context;
        }
        public List<PlantModel> GetAll()
        {
            return _context.Plants.ToList();
        }

        public PlantModel? GetById(int id)
        {
            return _context.Plants.FirstOrDefault(p => p.PlantId == id);
        
        }

        public void Delete(int id)
        {

        }
        public List<InstructionModel> GetInstructionsById(int plantId)
        {
            return _context.Instructions.Where(i => i.PlantId == plantId).ToList();
        }
    }
}
