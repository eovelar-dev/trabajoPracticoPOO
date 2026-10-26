using System;
namespace trabajoPracticoPOO{
    public class Cliente{

        //Atributos
        private string nombre;
        private string apellido;
        private int dni;
        private int telefono;

        //Constructores
        public Cliente( string nombre, string apellido, int dni, int telefono ){
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
        }
        public Cliente( string nombre, string apellido, int dni ){
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }
        public Cliente( int dni ){
            this.dni = dni;
        }

        //Propiedad get
        public int DNI{
            get{
                return dni;
            }
        }

        //Metodos
        public void mostrar(){
            Console.WriteLine( "Nombre: {0}\nApellido: {1}\nDNI: {2}\nTelefono: {3}",nombre,apellido, dni.ToString("N0"), telefono );
        }
        public string obtenerCsv(){
            return string.Format("{0},{1},{2},{3}",nombre,apellido,dni,telefono);
        }
    }
}