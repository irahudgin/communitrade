﻿using communiTrade.Core;
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
        public RelayCommand RegisterViewComand { get; set; }

        public RelayCommand DiscoveryViewCommand{ get; set; }

        public HomeViewModel HomeVm{ get; set; }
        public RegisterViewModel RegisterVm { get; set; }
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
			RegisterVm = new RegisterViewModel();
			DiscoveryVM = new DiscoveryViewModel();

			CurrentView = HomeVm;

			HomeViewComand = new RelayCommand(obj => 
			{
				CurrentView = HomeVm;
			});

            RegisterViewComand = new RelayCommand(obj =>
            {
                CurrentView = RegisterVm;
            });

            DiscoveryViewCommand = new RelayCommand(obj =>
            {
                CurrentView = DiscoveryVM;
            });
        }
    }
}
