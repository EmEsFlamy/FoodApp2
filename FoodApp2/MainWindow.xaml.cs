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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FoodAppEntities FA = new FoodAppEntities();
            var users = from d in FA.Users
                        select new
                        {
                            ClientName = d.Name,
                            ClientSurname = d.Surname,
                            ClientAddres = d.Address,
                            ClientPhoneNumber = d.PhoneNumber
                        };
            
            this.Gridusers.ItemsSource = users.ToList();
        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            FoodAppEntities FA = new FoodAppEntities();

            if (txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "" || txtPhoneNumber.Text == "")
            {
                MessageBox.Show(this, "refill the data", "Confrimation");
                return;
            }
            else
            {
               
                Users Userobject = new Users()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhoneNumber.Text
                };
                FA.Users.Add(Userobject);
                FA.SaveChanges();
            }
        }

        private void btnLoadUsers_Click(object sender, RoutedEventArgs e)
        {
            FoodAppEntities FA = new FoodAppEntities();

            this.Gridusers.ItemsSource = FA.Users.ToList();
        }

        private long upadatingUserID = 0;
        private void Gridusers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FoodAppEntities FA = new FoodAppEntities();
            if (this.Gridusers.SelectedIndex >= 0)
            {
                if (this.Gridusers.SelectedItems.Count >= 0)
                {
                    if (this.Gridusers.SelectedItems[0].GetType() == typeof(Users))
                    {
                        Users d = (Users)this.Gridusers.SelectedItems[0];
                        this.txtName2.Text = d.Name;
                        this.txtSurname2.Text = d.Surname;
                        this.txtAddress2.Text = d.Address;
                        this.txtPhoneNumber2.Text = d.PhoneNumber;
                        this.upadatingUserID = d.userID;
                        FA.SaveChanges();
                    }

                    
                }
            }


        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            FoodAppEntities FA = new FoodAppEntities();

           

            var user = FA.Users.FirstOrDefault(x => x.userID == ((Users)Gridusers.SelectedItem).userID);

            if (MessageBox.Show(this, "Are you sure you want update user?", "Confrimation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                if (user != null)
            {
                user.Name = this.txtName2.Text;
                user.Surname = this.txtSurname2.Text;
                user.Address = this.txtAddress2.Text;
                user.PhoneNumber = this.txtPhoneNumber2.Text;
                FA.SaveChanges();
            }
                else 
                {

                }



        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            FoodAppEntities FA = new FoodAppEntities();
            
            

            
                var user = FA.Users.FirstOrDefault(x => x.userID == ((Users)Gridusers.SelectedItem).userID);


            if (MessageBox.Show(this, "Are you sure you want delete user?", "Confrimation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                if (user != null)
                {

                    FA.Users.Remove(user);
                    FA.SaveChanges();
                }
                else 
                {
                }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FoodChoose win2 = new FoodChoose();
            win2.Show();
            this.Close();
        }
    }
}
