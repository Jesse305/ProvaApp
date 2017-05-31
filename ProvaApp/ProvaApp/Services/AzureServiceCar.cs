using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace ProvaApp.Services
{
    class AzureServiceCar<T>
    {
        IMobileServiceClient Client;
        IMobileServiceTable<T> Table;

        public AzureServiceCar()
        {
            string URL = "endereço do backend"; //Endereço do backend do azuere, aqui criei uma tabela sql
            Client = new MobileServiceClient(URL);
            Table = Client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }
    }
}
