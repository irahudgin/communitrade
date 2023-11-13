using communiTrade.Core;
using communiTrade.MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace communiTrade.MVVM.ViewModel
{
    public class FeaturedViewModel : ObservableObject
    {
        private HttpClient client;
        private List<Item> _featuredItems;

        public List<Item> FeaturedItems
        {
            get { return _featuredItems; }
            set
            {
                _featuredItems = value;
                OnPropertyChanged(nameof(FeaturedItems));
            }
        }


        public FeaturedViewModel(HttpClient httpClient)
        {
            client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public FeaturedViewModel()
        {
        }

        public async Task InitializeAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7009/Trade/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var server_response = await client.GetStringAsync("GetAllItems");
                Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

                FeaturedItems = response_JSON.items;
            }
            catch (Exception)
            {
                FeaturedItems = null;
            }
        }
    }
}