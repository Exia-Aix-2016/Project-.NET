using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DiningRoom : Container<Square>
    {
        public DiningRoom(int numberSquares) : base(numberSquares){}

        public List<Client> getAllClients()
        {
            List<Client> clients = new List<Client>();
            Storage.ForEach(square =>
            {
                square.Items().ForEach(rank =>
                {
                    rank.Items().ForEach(table =>
                    {
                        clients.AddRange(table.Items());
                    });
                });
            });


            return clients;
        }

        
    }
}
