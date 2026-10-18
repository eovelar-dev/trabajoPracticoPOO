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
        public Vehiculo( string patente, string marca, string modelo, int año){
            this.patente = patente;
            this.marca = marca;
            this.modelo = modelo;
            this.año = año;
            this.estaDisponible = false;
        }

        //Metodos
        public abstract void mostrar();
        public abstract double calcularCostoPorDia();
    }
}