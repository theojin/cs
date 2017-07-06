using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetworkConnectivity
{
    public class BookManager : INotifyPropertyChanged
    {
        public string Url => "http://xam150.azurewebsites.net/api/books/";
        private string autorizationCode;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Book> books;

        public List<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged();
            }
        }


        public async Task<HttpClient> GetClient()
        {
            var client = new HttpClient();
            if (string.IsNullOrEmpty(autorizationCode))
            {
                autorizationCode = await client.GetStringAsync(Url + "login"); // For token
                autorizationCode = JsonConvert.DeserializeObject<string>(autorizationCode);
            }

            client.DefaultRequestHeaders.Add("Authorization", autorizationCode);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task GetAll()
        {
            var client = await GetClient();
            string result = await client.GetStringAsync(Url);
            var books = JsonConvert.DeserializeObject<List<Book>>(result);
        }
    }
}
