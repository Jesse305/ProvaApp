using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace ProvaApp.Models
{
    [DataTable("Cars")]
    public class Car
    {
        [Version]
        public string AzureVersion { get; set; }
        public string Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string PaginaWeb { get; set; }
    }
}
