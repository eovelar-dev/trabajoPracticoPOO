using System;
namespace trabajoPracticoPOO{
    public class Auto : Vehiculo{
        private int cantidadDePuertas;
        private bool cajaAutomatica;

        //Constructor
        public Auto( string patente, string marca, string modelo, int año, double precioPorDia, bool estaDisponible, int cantidadDePuertas, bool cajaAutomatica ) : base( patente, marca, modelo, año, precioPorDia, estaDisponible ) {
            this.cantidadDePuertas = cantidadDePuertas;
            this.cajaAutomatica = cajaAutomatica;
        }

        //Metodos
        public override void mostrar(){
            Console.WriteLine( "Patente: {0}\nMarca: {1}\nModelo: {2}\nAño: {3}\nPrecio por dia: ${4}\nDisponibilidad: {5}\nCantidad de puertas: {6}\nCaja Automatica: {7}", patente, marca, modelo, año, precioPorDia.ToString("N2"), estaDisponible, cantidadDePuertas, cajaAutomatica );
            if( cajaAutomatica ){
                Console.WriteLine("Precio por dia con recargo por caja automatica: ${0}", calcularCostoPorDia().ToString("N2"));
            }
        }
        public override double calcularCostoPorDia(){
            if( !cajaAutomatica ){
                return precioPorDia;
            }
            else{
                return precioPorDia*0.1;
            }
        }
    }
}