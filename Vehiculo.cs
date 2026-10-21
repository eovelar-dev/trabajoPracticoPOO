using System;
namespace trabajoPracticoPOO{
    public abstract class Vehiculo{
        
        //Atributos
        protected string patente;
        protected string marca;
        protected string modelo;
        protected int año;
        protected double precioPorDia;
        protected bool estaDisponible;
        protected bool seguroAdicional = false;

        //Constructores
        public Vehiculo( string patente, string marca, string modelo, int año, double precioPorDia, bool estaDisponible ){
            this.patente = patente;
            this.marca = marca;
            this.modelo = modelo;
            this.año = año;
            this.precioPorDia = precioPorDia;
            this.estaDisponible = estaDisponible;
        }
        public Vehiculo(){
        }
        //Propiedades Get y Set
        public string PATENTE{
            get{
                return patente;
            }
        }
        //Metodos
        public virtual void mostrar(){
             Console.WriteLine( "Patente: {0}\nMarca: {1}\nModelo: {2}\nAño: {3}\nPrecio por dia: ${4}\nDisponibilidad: {5}\nPosibilidad de seguro adicional: {6}", patente, marca, modelo, año, precioPorDia.ToString("N2"), estaDisponible, seguroAdicional );
        }
        public abstract double calcularCostoPorDia(); 
        public virtual string obtenerCsv(){
            return string.Format( "{0},{1},{2},{3},{4},{5}", patente, marca, modelo, año, precioPorDia, estaDisponible );
        }
    }
}