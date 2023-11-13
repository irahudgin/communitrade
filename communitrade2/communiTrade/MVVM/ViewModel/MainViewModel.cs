using communiTrade.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communiTrade.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewComand { get; set; }
        public RelayCommand RegisterViewComand { get; set; }

        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand MessagesViewCommand { get; set; }
        public RelayCommand MyPostsViewCommand { get; set; }
        public RelayCommand FavouritesViewCommand { get; set; }
        public RelayCommand FeaturedViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public RegisterViewModel RegisterVm { get; set; }
        public DiscoveryViewModel DiscoveryVM { get; set; }
        public LoginViewModel LoginVm { get; set; }
        public MessagesViewModel MessagesVm { get; set; }
        public MyPostsViewModel MyPostsVm { get; set; }
        public FavouritesViewModel FavouritesVm { get; set; }
        public FeaturedViewModel FeaturedVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            RegisterVm = new RegisterViewModel();
            DiscoveryVM = new DiscoveryViewModel();
            LoginVm = new LoginViewModel();
            MessagesVm = new MessagesViewModel();
            MyPostsVm = new MyPostsViewModel();
            FavouritesVm = new FavouritesViewModel();
            FeaturedVM = new FeaturedViewModel();

            CurrentView = HomeVm;

            HomeViewComand = new RelayCommand(obj =>
            {
                CurrentView = HomeVm;
            });

            RegisterViewComand = new RelayCommand(obj =>
            {
                CurrentView = RegisterVm;
            });

            LoginViewCommand = new RelayCommand(obj =>
            {
                CurrentView = LoginVm;
            });

            DiscoveryViewCommand = new RelayCommand(obj =>
            {
                CurrentView = DiscoveryVM;
            });

            MessagesViewCommand = new RelayCommand(obj =>
            {
                CurrentView = MessagesVm;
            });

            MyPostsViewCommand = new RelayCommand(obj =>
            {
                CurrentView = MyPostsVm;
            });

            FavouritesViewCommand = new RelayCommand(obj =>
            {
                CurrentView = FavouritesVm;
            });

            FeaturedViewCommand = new RelayCommand(obj =>
            {
                CurrentView = FeaturedVM;
            });
        }
    }
}