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
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        public PlantWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            using (GreenThumb2DbContext context = new())
            {
                PlantRepository plantrepository = new(context);

                var plants = plantrepository.GetAll();

                foreach ( var plant in plants ) 
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.PlantName;

                    lstPlants.Items.Add(item);
                }
            }
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new();
            addPlantWindow.Show();
            Close();
        }
    }
}
