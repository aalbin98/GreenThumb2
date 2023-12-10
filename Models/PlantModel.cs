using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb2.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }
        public string PlantName { get; set; } = null!;

        public List<InstructionModel> Instructions { get; set; }

    }
}
