using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) { }

        public override string Excecute(Player p, string[] text)
        {
            
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {

        }

        private string LookAtIn(string thingId)
    }
}
