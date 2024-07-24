using Hospital.Commands;
using Hospital.Data.IRepository;
using Hospital.Data.Repository.IRepository;
using Hospital.Models;
using Hospital.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class DoctorMainViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        private object _currentView;
        private string _firstName;
        private string _lastName;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }


        public DoctorMainViewModel(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            UserSessionService userSession = _serviceProvider.GetRequiredService<UserSessionService>();
            _firstName = userSession.FirstName;
            _lastName = userSession.LastName;
            ExecuteShowDoctorsPatientsView(null);
        }
        private void ExecuteShowDoctorsPatientsView(object parameter)
        {
            CurrentView = _serviceProvider.GetRequiredService<DoctorsPatientsReservations>();
        }
    }
}
