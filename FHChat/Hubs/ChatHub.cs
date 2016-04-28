using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Collections;
namespace FHChat.Hubs
{

    public class ChatHub : Hub
    {
        public static Hashtable users = new Hashtable();
        
        public void SendMessage(string name, string message)
        {
            string nameEncoded = HttpUtility.HtmlEncode(name);
            string messageEncoded = HttpUtility.HtmlEncode(message);
                Clients.All.SendMessageToPage(nameEncoded, messageEncoded);
        }
        public override Task OnConnected()
        {
            int i = 0;
            var name = Context.QueryString["name"];
            string listusers = "";
            if (!users.ContainsValue(name))
                users.Add(Context.ConnectionId, name);

            foreach (DictionaryEntry item in users)
            {
                if(name != item.Value.ToString())
                {
                    listusers +=  item.Value.ToString()+",";
                }
            }
                Clients.All.SendStatus(name, listusers);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.QueryString["name"];
            if(users.ContainsValue(name))
            {
                string key = "";
                foreach (DictionaryEntry item in users)
                {
                    if(item.Value.ToString() == name)
                    {
                        key = item.Key.ToString();
                        
                    }
                }
                users.Remove(key);
                Clients.All.SendRemoveStatus(name);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}