using System;
namespace trabajoPracticoPOO{
    public class Auto : Vehiculo{
        private int cantidadDePuertas;
        private bool cajaAutomatica;
        private double precioSeguro = 8000;

        //Constructor
        public Auto( string patente, string marca, string modelo, int año, double precioPorDia, bool estaDisponible, int cantidadDePuertas, bool cajaAutomatica ) : base( patente, marca, modelo, año, precioPorDia, estaDisponible ) {
            this.cantidadDePuertas = cantidadDePuertas;
            this.cajaAutomatica = cajaAutomatica;
            seguroAdicional = true;
        }

        //Metodos
        public override void mostrar(){
            base.mostrar();
            if( seguroAdicional ){
                Console.WriteLine("Precio por dia del seguro: ${0}", precioSeguro.ToString("N2"));
            }
            Console.WriteLine( "Cantidad de puertas: {0}\nCaja automatica: {1}", cantidadDePuertas, cajaAutomatica );
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
        public override string obtenerCsv(){
            return string.Format( "Auto,{0},{1},{2}", base.obtenerCsv(),cantidadDePuertas,cajaAutomatica );
        }
    }
}