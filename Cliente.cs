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

    }
}