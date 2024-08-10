using System;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Data.IRepository;
using Hospital.Data.Repository;
using Hospital.Views;
using Hospital.ViewModels;
using Hospital.Data.Repository.IRepository;


namespace Hospital
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    var connectionString = "Server=localhost;Database=Add_Your_Database_Here;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";

                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    //Services
                    services.AddSingleton<UserSessionService>();

                    // Repositories
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<IPatientRepository, PatientRepository>();
                    services.AddScoped<IRoomRepository, RoomRepository>();
                    services.AddScoped<IReservationRepository, ReservationRepository>();
                    services.AddScoped<IDoctorRepository, DoctorRepository>();

                    //UserControls
                    services.AddTransient<UsersView>();
                    services.AddTransient<DoctorsView>();
                    services.AddTransient<RoomsView>();
                    services.AddTransient<PatientsView>();
                    services.AddTransient<ActiveReservationsView>();
                    services.AddTransient<ClosedReservationsView>();
                    services.AddTransient<DoctorsPatientsReservations>();
                    services.AddTransient<RegistrarRoomsView>();

                    // ViewModels
                    services.AddTransient<LoginViewModel>();
                    services.AddTransient<AdminMainViewModel>();
                    services.AddTransient<RegistrarMainViewModel>();
                    services.AddTransient<DoctorMainViewModel>();
                    services.AddTransient<UsersViewModel>();
                    services.AddTransient<DoctorsViewModel>();
                    services.AddTransient<AddUserViewModel>();
                    services.AddTransient<AddDoctorViewModel>();
                    services.AddTransient<RoomsViewModel>();
                    services.AddTransient<AddRoomViewModel>();
                    services.AddTransient<PatientsViewModel>();
                    services.AddTransient<AddPatientViewModel>();
                    services.AddTransient<ActiveReservationsViewModel>();
                    services.AddTransient<ClosedReservationsViewModel>();
                    services.AddTransient<CreateNewReservationViewModel>();
                    services.AddTransient<CloseReservationViewModel>();
                    services.AddTransient<DoctorPatientsReservationsViewModel>();
                    //Views
                    services.AddTransient<LoginView>();
                    services.AddTransient<AdminMain>();
                    services.AddTransient<RegistrarMain>();
                    services.AddTransient<DoctorMain>();
                    services.AddTransient<AddUserView>();
                    services.AddTransient<AddDoctorView>();
                    services.AddTransient<AddRoomView>();
                    services.AddTransient<AddPatientView>();
                    services.AddTransient<CreateNewReservationView>();
                    services.AddTransient<CloseReservationView>();


                })
                .Build();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            var loginView = _host.Services.GetRequiredService<LoginView>();
            loginView.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
