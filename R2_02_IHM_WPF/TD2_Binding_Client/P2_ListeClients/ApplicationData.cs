
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_ListeClients
{

        public class ApplicationData
        {
       
            private ObservableCollection<Client> lesClients;
            public String path = AppDomain.CurrentDomain.BaseDirectory+"\\LesClients.json";

        public ObservableCollection<Client> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
            }
        }

        public ApplicationData()
            {

                this.Charge();
            }
            public void Charge()
            {
                try
                {
                    LesClients =  new ObservableCollection<Client>( JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(path)));
                }
                catch (Exception e) { throw; }
            }
            public void Sauvegarde()
            {
                try
                {
                    String txt = JsonConvert.SerializeObject(LesClients);
                    File.WriteAllText(path, txt);
                }
                catch (Exception e) { throw; }

            }

        }
    
}
