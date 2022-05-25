using CAI_10_AgendaV3.AccesoDatos.Utilidades;
using CAI_10_AgendaV3.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Collections.Specialized;

namespace CAI_10_AgendaV3.AccesoDatos
{
    public static class AgendaDatos
    {
        public static List<Contacto> TraerTodos()
        {
            string json2 = WebHelper.Get("agenda/860540"); // trae un texto en formato json de una web
            List<Contacto> resultado = MapList(json2);
            return resultado;
        }

        public static List<Contacto> Traer(int usuario)
        {
            string json2 = WebHelper.Get("agenda/"+usuario.ToString()); // trae un texto en formato json de una web
            List<Contacto> resultado = MapList(json2);
            return resultado;
        }
        public static Contacto TraerPorTelefono(string telefono)
        {
            string json2 = WebHelper.Get("agenda/"+ telefono + "/telefono"); // trae un texto en formato json de una web
            Contacto resultado = MapObj(json2);
            return resultado;
        }


        private static List<Contacto> MapList(string json)
        {
            List<Contacto> lst = JsonConvert.DeserializeObject<List<Contacto>>(json); // deserializacion
            return lst;
            //JsonConvert.D
        }

        private static Contacto MapObj(string json)
        {
            Contacto lst = JsonConvert.DeserializeObject<Contacto>(json); // deserializacion
            return lst;
        }

        public static TransactionResult Insertar(Contacto contacto)
        {
            NameValueCollection obj = ReverseMap(contacto); //serializacion -> json

            string json = WebHelper.Post("agenda", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public static TransactionResult Actualizar(Contacto contacto)
        {
            NameValueCollection obj = ReverseMap(contacto);

            string json = WebHelper.Put("agenda", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }
        private static NameValueCollection ReverseMap(Contacto contacto)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", contacto.ID.ToString());
            n.Add("Direccion", contacto.Direccion);
            n.Add("Telefono", contacto.Telefono);
            n.Add("Email", contacto.Email);

            if (contacto is ContactoPersona)
            {
                ContactoPersona contactoPersona = (ContactoPersona)contacto;
                n.Add("Nombre", contactoPersona.Nombre);
                n.Add("Apellido", contactoPersona.Apellido);
                n.Add("FechaNacimiento", contactoPersona.FechaNacimiento.ToString("yyyy-MM-dd"));
            }
            else
            {
                ContactoEmpresa contactoEmpresa = (ContactoEmpresa)contacto;
                n.Add("FechaConstitucion", contactoEmpresa.FechaConstitucion.ToString("yyy-MM-dd"));
                n.Add("RazonSocial", contactoEmpresa.RazonSocial);
            }
            n.Add("Usuario", "860540");
            return n;
        }
    }
}
