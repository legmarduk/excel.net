using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BOL;
using BOL.Helpers;

namespace BOL
{
    public class Parameter
    {

        public static Coneccion Leer_parametros()
        {
            XDocument Config = new XDocument();
            Config = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "/Parameter.config");

            var Parameter = (from el in Config.Elements("Parameter")
                             select new Coneccion
                             {
                                 Servidor = el.Element("SERVER").Value.ToString(),
                               
                                 Bd = el.Element("DATABASE").Value.ToString(),
                              
                                 ConString = "Data source=" + el.Element("SERVER").Value.ToString() + " ; Initial Catalog=" + el.Element("DATABASE").Value.ToString() + "; Integrated Security = true; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
                                                                                               
                             }).FirstOrDefault();
            return (Coneccion)Parameter;

        }


    }
}
