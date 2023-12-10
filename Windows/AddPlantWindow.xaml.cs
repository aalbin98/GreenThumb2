using GreenThumb2.Database;
using GreenThumb2.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public AddPlantWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new();
            plantWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start by adding the desired instructions to the list in the middle by pressing Add Instruction and when you're done simply press \"Add Plant\"", "Adding information");
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            string plantname = txtPlantName.Text;
            if (string.IsNullOrWhiteSpace(plantname))
            {
                MessageBox.Show("You have to enter a plant name","Error");
            }
            else
            {
                using (GreenThumb2DbContext context = new())
                {
                    PlantModel newPlant = new()
                    {
                        PlantName = plantname,
                    };

                    context.Plants.Add(newPlant);
                    context.SaveChanges();

                    MessageBox.Show("Plant added");
                }
            }
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            string instructions = txtInstructions.Text;
            if (string.IsNullOrWhiteSpace(instructions))
            {
                MessageBox.Show("You have not entered any instructions", "Error");
            }
            else
            {
                using (GreenThumb2DbContext context = new())
                {

                }
            }
        }
    }
}
