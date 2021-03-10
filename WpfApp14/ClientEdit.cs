using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp14
{
    class ClientEdit
    {
        public List<Client> Clients { get; set; } = new List<Client>();

        public void Add()
        {
            Clients.Add(new Client { FirstName = "Имя", LastName = "Фамилия" });
        }

        public ClientEdit()
        {
            Clients.Add(new Client { FirstName = "ALEXA", LastName="GOOO", FatherName="GOGO", CarNumber="AAA44AA", CarBrand="LADA" });
        }

        internal void Remove(Client client)
        {
            Clients.Remove(client);
        }

        internal void SaveClient(Client original, Client copy)
        {
            int index = Clients.IndexOf(original);
            Clients[index] = copy;
        }

        internal void MarkDate(Client client)
        {
            int index = Clients.IndexOf(client);
            Clients[index].VisitLog.Add(DateTime.Now);
        }
    }
}
