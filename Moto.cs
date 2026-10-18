using System;
namespace trabajoPracticoPOO{
    public class Moto : Vehiculo{
        private int cilindrada;

        //Constructores
        public Moto( string patente, string marca, string modelo, int año, double precioPorDia, bool estaDisponible, int cilindrada ) : base( patente, marca, modelo, año, precioPorDia, estaDisponible ){
            this.cilindrada = cilindrada;
        }
        //Metodos
        public override void mostrar(){
            Console.WriteLine( "Patente: {0}\nMarca: {1}\nModelo: {2}\nAño: {3}\nPrecio por dia: ${4}\nDisponibilidad: {5}\nCilindrada: {6}\nPosibilidad de seguro adicional: {7}", patente, marca, modelo, año, precioPorDia.ToString("N2"), estaDisponible, cilindrada,seguroAdicional );
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
    }
}