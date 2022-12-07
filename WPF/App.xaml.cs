using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels;
using WPF.ViewModels.ActivityViewModels;
using WPF.ViewModels.CustomerViewModels;
using WPF.ViewModels.ProjectViewModels;
using WPF.ViewModels.UserViewModels;
using WPF.ViewModels.UtilityViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddSingleton<HttpClient>();
            
            services.AddSingleton<UserStore>();
            services.AddSingleton<ActivityStore>();
            services.AddSingleton<CustomerStore>();
            services.AddSingleton<ProjectStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<ApiRepository>();
            services.AddSingleton<ApiAuthRepository>();

            services.AddSingleton<INavigationService>(CreateLoginNavigationService);
            
            services.AddTransient<LoginViewModel>(s => new LoginViewModel(s.GetRequiredService<UserStore>(), 
                CreateHomeNavigationService(s), CreateAddUserNavigationService(s), s.GetRequiredService<ApiAuthRepository>()));
            services.AddTransient<HomeViewModel>(s => new HomeViewModel(s.GetRequiredService<UserStore>(), s.GetRequiredService<ApiRepository>()));
            services.AddTransient<ActivityViewModel>(s => new ActivityViewModel(s.GetRequiredService<ApiRepository>(), CreateAddActivityNavigationService(s), 
                CreateEditActivityNavigationService(s), s.GetRequiredService<ActivityStore>()));
            services.AddTransient<ProjectViewModel>(s => new ProjectViewModel(s.GetRequiredService<ApiRepository>(), CreateAddProjectNavigationService(s),
                CreateEditProjectNavigationService(s), s.GetRequiredService<ProjectStore>()));
            services.AddTransient<CustomerViewModel>(s => new CustomerViewModel(s.GetRequiredService<ApiRepository>(), CreateAddCustomerNavigationService(s),
                CreateEditCustomerNavigationService(s), s.GetRequiredService<CustomerStore>()));
            
            services.AddTransient<AddActivityViewModel>(CreateAddActivityViewModel);
            services.AddTransient<AddNormalActivityViewModel>(CreateAddNormalActivityViewModel);
            services.AddTransient<AddTimerActivityViewModel>(CreateAddTimerActivityViewModel);
            services.AddTransient<EditActivityViewModel>(CreateEditActivityViewModel);
            
            services.AddTransient<AddProjectViewModel>(CreateAddProjectViewModel);
            services.AddTransient<EditProjectViewModel>(CreateEditProjectViewModel);

            services.AddTransient<AddCustomerViewModel>(CreateAddCustomerViewModel);
            services.AddTransient<EditCustomerViewModel>(CreateEditCustomerViewModel);
            
            services.AddTransient<AddUserViewModel>(CreateAddUserViewModel);

            services.AddSingleton<NavbarViewModel>(CreateNavbarViewModel);
            
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        private AddActivityViewModel CreateAddActivityViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateActivityNavigationService(services));

            return new AddActivityViewModel(CreateAddNormalActivityNavigationService(services), CreateAddTimerActivityNavigationService(services), navigationService);
        }
        private AddNormalActivityViewModel CreateAddNormalActivityViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateActivityNavigationService(services));

            return new AddNormalActivityViewModel(services.GetRequiredService<ApiRepository>(), navigationService, services.GetRequiredService<UserStore>());
        }
        private AddTimerActivityViewModel CreateAddTimerActivityViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateActivityNavigationService(services));

            return new AddTimerActivityViewModel(services.GetRequiredService<ApiRepository>(), navigationService, services.GetRequiredService<UserStore>());
        }
        private EditActivityViewModel CreateEditActivityViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateActivityNavigationService(services));

            return new EditActivityViewModel(services.GetRequiredService<ApiRepository>(), navigationService, services.GetRequiredService<UserStore>(),
            services.GetRequiredService<ActivityStore>());
        }
        private AddProjectViewModel CreateAddProjectViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateProjectNavigationService(services));

            return new AddProjectViewModel(services.GetRequiredService<ApiRepository>(),
                navigationService);
        }
        private EditProjectViewModel CreateEditProjectViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateProjectNavigationService(services));

            return new EditProjectViewModel(services.GetRequiredService<ApiRepository>(), navigationService,
                services.GetRequiredService<ProjectStore>());
        }
        private AddCustomerViewModel CreateAddCustomerViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateCustomerNavigationService(services));

            return new AddCustomerViewModel(services.GetRequiredService<ApiRepository>(),
                navigationService);
        }
        private EditCustomerViewModel CreateEditCustomerViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateCustomerNavigationService(services));

            return new EditCustomerViewModel(services.GetRequiredService<ApiRepository>(), navigationService,
                services.GetRequiredService<CustomerStore>());
        }
        private AddUserViewModel CreateAddUserViewModel(IServiceProvider services)
        {
            ModalNavigationStore modalNavigationStore = services.GetRequiredService<ModalNavigationStore>();
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateLoginNavigationService(services));

            return new AddUserViewModel(services.GetRequiredService<ApiRepository>(),
                navigationService);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            
            base.OnStartup(e);
        }

        private NavbarViewModel CreateNavbarViewModel(IServiceProvider serviceProvider)
        {
            return new NavbarViewModel
            (
                CreateHomeNavigationService(serviceProvider),
                CreateActivityNavigationService(serviceProvider),
                CreateCustomerNavigationService(serviceProvider),
                CreateProjectNavigationService(serviceProvider)
            );
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(serviceProvider.GetRequiredService<UserStore>(), 
                serviceProvider.GetRequiredService<NavigationStore>(), 
                serviceProvider.GetRequiredService<HomeViewModel>, 
                serviceProvider.GetRequiredService<NavbarViewModel>,
                serviceProvider.GetRequiredService<INavigationService>());
        }
        private INavigationService CreateActivityNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ActivityViewModel>(serviceProvider.GetRequiredService<UserStore>(), 
                serviceProvider.GetRequiredService<NavigationStore>(), 
                serviceProvider.GetRequiredService<ActivityViewModel>, 
                serviceProvider.GetRequiredService<NavbarViewModel>,
                serviceProvider.GetRequiredService<INavigationService>());
        }
        private INavigationService CreateCustomerNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<CustomerViewModel>(serviceProvider.GetRequiredService<UserStore>(), 
                serviceProvider.GetRequiredService<NavigationStore>(), 
                serviceProvider.GetRequiredService<CustomerViewModel>, 
                serviceProvider.GetRequiredService<NavbarViewModel>,
                serviceProvider.GetRequiredService<INavigationService>());
        }
        private INavigationService CreateProjectNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ProjectViewModel>(serviceProvider.GetRequiredService<UserStore>(), 
                serviceProvider.GetRequiredService<NavigationStore>(), 
                serviceProvider.GetRequiredService<ProjectViewModel>, 
                serviceProvider.GetRequiredService<NavbarViewModel>,
                serviceProvider.GetRequiredService<INavigationService>());
        }
        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<LoginViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), 
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateAddActivityNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddActivityViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddActivityViewModel>());
        }
        private INavigationService CreateAddProjectNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddProjectViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddProjectViewModel>());
        }
        private INavigationService CreateEditProjectNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<EditProjectViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<EditProjectViewModel>());
        }
        private INavigationService CreateAddCustomerNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddCustomerViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddCustomerViewModel>());
        }
        private INavigationService CreateEditCustomerNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<EditCustomerViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<EditCustomerViewModel>());
        }
        private INavigationService CreateAddUserNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddUserViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddUserViewModel>());
        }
        private INavigationService CreateAddNormalActivityNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddNormalActivityViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddNormalActivityViewModel>());
        }
        private INavigationService CreateAddTimerActivityNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddTimerActivityViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddTimerActivityViewModel>());
        }
        private INavigationService CreateEditActivityNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<EditActivityViewModel>(serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<EditActivityViewModel>());
        }
    }
}
