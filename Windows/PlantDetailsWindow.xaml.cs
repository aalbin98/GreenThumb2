using GreenThumb2.Database;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GreenThumb2.Windows
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        public PlantDetailsWindow(int id)
        {
            InitializeComponent();

            using (GreenThumb2DbContext context = new())
            {
                PlantRepository plantrepository = new(context);

                var plant = plantrepository.GetById(id);
                var instructions = plantrepository.GetInstructionsById(id);

                if (plant != null) 
                {
                    plantName.Content = plant.PlantName;
                    plantDescription.ItemsSource = instructions;
                }
            }
        }

    }
}
