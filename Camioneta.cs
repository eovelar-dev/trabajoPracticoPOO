using System;
namespace trabajoPracticoPOO{
    public class Camioneta : Vehiculo{
        private int capacidadDeCarga;
        private bool es4x4;
        private double precioSeguro = 12000;

        //Constructores
        public Camioneta( string patente, string marca, string modelo, int año, double precioPorDia, bool estaDisponible, int capacidadDeCarga, bool es4x4 ) : base( patente, marca, modelo, año, precioPorDia, estaDisponible ){
            this.capacidadDeCarga = capacidadDeCarga;
            this.es4x4 = es4x4;
            seguroAdicional = true;
        }

        //Metodos
        public override void mostrar(){
            base.mostrar();
            if( seguroAdicional ){
                Console.WriteLine("Precio por dia del seguro: ${0}", precioSeguro.ToString("N2"));
            }
            Console.WriteLine("Capacidad de Carga: {0}Kg\n4x4: {1}", capacidadDeCarga.ToString("N0"), es4x4);
            if( es4x4 ){
                Console.WriteLine("Precio por dia con recargo por 4x4: ${0}", calcularCostoPorDia().ToString("N2") );
            }
        }
        public override double calcularCostoPorDia(){
            if( es4x4 ){
                return (precioPorDia+5000);
            }
            else{
                return precioPorDia;
            }
        }
    }
}