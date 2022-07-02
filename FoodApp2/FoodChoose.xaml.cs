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

namespace FoodApp2
{
    /// <summary>
    /// Interaction logic for FoodChoose.xaml
    /// </summary>
    public partial class FoodChoose : Window
    {
        public FoodChoose()
        {
            InitializeComponent();
            FoodAppEntities FA = new FoodAppEntities();




            this.Usersgrid2.ItemsSource = FA.Users.ToList();
            this.RestaurantGrid.ItemsSource = FA.Restaurant.ToList();
            this.FoodTypeGrid.ItemsSource =FA.FoodType.ToList();
            this.FoodGrid.ItemsSource = FA.Food.ToList();
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            OrderGrid.Items.Add(new 
                {
                    Name = Name2TXT.Text,
                    Surname = Surname2TXT.Text,
                    Address = Address2TXT.Text,
                    PhoneNumber = PhoneNumber2TXT.Text,
                    RestaurantName = RestaurantTXT.Text,
                    FoodTypeName = FoodTypeTXT.Text,
                    FoodName = FoodTXT.Text
                });
                
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
           if  (MessageBox.Show(this, "If you close this window, all data will be lost.","Confrimation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                MainWindow win2 = new MainWindow();
                win2.Show();
                this.Close();
            }
            else 
            {
                
            }
        }
    }
}
