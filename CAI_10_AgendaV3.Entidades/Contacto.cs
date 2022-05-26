using System;


namespace CAI_10_AgendaV3.Entidades
{
    public class Contacto
    {

        //Variables de clase, por orden de importancia
        internal int _id;
        internal string _nombre;
        internal string _apellido;
        internal string _razonSocial;
        internal string _telefono;
        internal string _direccion;
        internal DateTime _fechaNacimiento;
        internal DateTime _fechaConstitucion;

        //Propiedades de clase
        public int ID
        {
            get { return _id; }
        }
        public string Nombre
        {
            get { return _nombre; }
        }
        public string Apellido
        {
            get { return _apellido; }
        }
        public string RazonSocial
        {
            get { return _razonSocial; }
        }
        public string Telefono
        {
            get { return _telefono; }
        }
        public string Direccion
        {
            get { return _direccion; }
        }
        public DateTime FechaConstitucion
        {
            get { return _fechaConstitucion; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
        }

        //Constructores de clase

        public Contacto(int id, string telefono, string direccion, string nombre = null, string apellido = null, string razonSocial = null, DateTime? fechaNacimiento = null, DateTime? fechaConstitucion = null)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _razonSocial = razonSocial; 
            _telefono = telefono;
            _direccion = direccion;
            if (fechaConstitucion != null) { _fechaConstitucion = (DateTime)fechaConstitucion; }
            if (fechaNacimiento != null) { _fechaNacimiento = (DateTime)fechaNacimiento; }
        }
        
        //Métodos de clase
        public void ActualizarID(int id)
        {
            _id = id;
        }
        public void ActualizarNombre(string nombre)
        {
            _nombre = nombre;
        }

        public void ActualizarApellido(string apellido)
        {
            _apellido = apellido;
        }
        public void ActualizarRazonSocial(string razonSocial)
        {
            _razonSocial = razonSocial;
        }
        public void ActualizarTelefono(string tel)
        {
            _telefono = tel;
        }
        public void ActualizarDireccion(string direccion)
        {
            _direccion = direccion;
        }
        public void ActualizarFechaNacimiento(DateTime fechaNac)
        {
            if (VerificarFechaIngresada(fechaNac))
            {
                _fechaNacimiento = fechaNac;
            }
            else
            {
                _fechaNacimiento = DateTime.Parse("01/01/1800");
            }
        }
        public void ActualizarFechaConstitucion(DateTime fechaConst)
        {
            if (VerificarFechaIngresada(fechaConst))
            {
                _fechaConstitucion = fechaConst;
            }
            else
            {
                _fechaConstitucion = DateTime.Parse("01/01/1800");
            }
        }
        public int Antiguedad()
        {
            return Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(_fechaConstitucion.ToString("yyyy"));
        }
        public int Edad()
        {
            return Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(_fechaNacimiento.ToString("yyyy"));
        }
        /// <summary>
        /// Esté método evalúa la fecha ingresada y la compara con la fecha de HOY
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>True si la fecha ingresada es menor a hoy, de lo contrario false</returns>
        internal bool VerificarFechaIngresada(DateTime fecha)
        {
            if (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(fecha.ToString("yyyy")) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
