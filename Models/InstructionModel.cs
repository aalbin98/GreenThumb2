using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb2.Models
{
    public class InstructionModel
    {
        [Key]
        public int InstructionId { get; set; }
        public string? Instruction { get; set; }
        public int PlantId { get; set; }

        [ForeignKey("PlantId")]
        public PlantModel PlantModel { get; set; }
    }
}
