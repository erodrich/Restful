using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Mensajes : IMensajes
    {
        public string ObtenerSaludo()
        {

            HttpWebRequest req = WebRequest.Create("http://localhost:17202/Hora.svc/ObtenerHora") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string horaCadena = reader.ReadToEnd();
            int hora = Int32.Parse(horaCadena);
            if (hora < 12)
            {
                return "Buenos dias";
            }
            else if (hora < 19)
            {
                return "Buenas tardes";
            }
            else
            {
                return "Buenas noches";
            }
            
        }

    }
}
