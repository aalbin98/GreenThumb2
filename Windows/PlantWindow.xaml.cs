using GreenThumb2.Database;
using GreenThumb2.Models;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
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

                foreach (var plant in plants)
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

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;

            if (selectedItem != null)
            {
                PlantModel selectedPlant = (PlantModel)selectedItem.Tag;
                int selectedPlantId = selectedPlant.PlantId;

                PlantDetailsWindow detailsWindow = new(selectedPlantId);
                detailsWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a plant to show details.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstPlants.SelectedItem == null)
            {
                MessageBox.Show("You need to select a plant to delete");
            }
            else
            {
                ListViewItem selecteditem = (ListViewItem)lstPlants.SelectedItem;
                PlantModel selectedPlant = (PlantModel)selecteditem.Tag;

                using (GreenThumb2DbContext context = new())
                {
                    PlantRepository plantRepository = new PlantRepository(context);
                    plantRepository.DeletePlant(selectedPlant.PlantId);
                    context.SaveChanges();
                }
            }

            UpdateUi();
        }
        public void UpdateUi()
        {
            lstPlants.Items.Clear();

            using (GreenThumb2DbContext context = new())
            {
                PlantRepository plantrepository = new(context);

                var plants = plantrepository.GetAll();

                foreach (var plant in plants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.PlantName;

                    lstPlants.Items.Add(item);
                }
            }

        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text.Trim();

            lstPlants.Items.Clear();

            using (GreenThumb2DbContext context = new GreenThumb2DbContext())
            {
                PlantRepository plantRepository = new PlantRepository(context);

                var plants = plantRepository.GetAll();

                foreach (var plant in plants)
                {
                    if (plant.PlantName.ToLower().StartsWith(searchText))
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = plant;
                        item.Content = plant.PlantName;

                        lstPlants.Items.Add(item);
                    }
                }
            }
        }

    }
}
