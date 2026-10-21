using System;
namespace trabajoPracticoPOO{
    public class Moto : Vehiculo{
        private int cilindrada;

        //Constructores
        public Moto( string patente, string marca, string modelo, int año, double precioPorDia, bool estaDisponible, int cilindrada ) : base( patente, marca, modelo, año, precioPorDia, estaDisponible ){
            this.cilindrada = cilindrada;
        }
        public Moto(){
        }
        //Metodos
        public override void mostrar(){
            base.mostrar();
            Console.WriteLine( "Cilindrada: {0}",cilindrada );
            if( cilindrada < 250 ){
                Console.WriteLine("Precio por dia con descuento: ${0}", calcularCostoPorDia().ToString("N2") );
            }
        }
        public override double calcularCostoPorDia(){
            if( cilindrada>=250 ){
                return precioPorDia;
            }
            else{
                return (precioPorDia-precioPorDia*0.15);
            }
        }
        public override string obtenerCsv(){
            return string.Format( "Moto,{0},{1}", base.obtenerCsv(),cilindrada );
        }
    }
}