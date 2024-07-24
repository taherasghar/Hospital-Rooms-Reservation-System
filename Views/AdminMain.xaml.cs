using Hospital.Data.IRepository;
using Hospital.Data.Repository;
using Hospital.Data.Repository.IRepository;
using Hospital.DTOs;
using Hospital.Models;
using Hospital.ViewModels;
using System.Windows;


namespace Hospital.Views
{
    /// <summary>
    /// Interaction logic for AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {

    
        public AdminMain(AdminMainViewModel viewModel)
        {
            InitializeComponent(); 
            DataContext = viewModel;

        }

       
    }
}
