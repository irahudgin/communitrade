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

        public RelayCommand HomeViewComand{ get; set; }
        public RelayCommand DiscoveryViewCommand{ get; set; }

        public HomeViewModel HomeVm{ get; set; }
        public DiscoveryViewModel DiscoveryVM{ get; set; }

        private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set { 
					_currentView = value;
					OnPropertyChanged();
				}
		}

		public MainViewModel() 
		{
			HomeVm = new HomeViewModel();
			DiscoveryVM = new DiscoveryViewModel();
			CurrentView = HomeVm;

			HomeViewComand = new RelayCommand(obj => 
			{
				CurrentView = HomeVm;
			});

            DiscoveryViewCommand = new RelayCommand(obj =>
            {
                CurrentView = DiscoveryVM;
            });
        }
    }
}
