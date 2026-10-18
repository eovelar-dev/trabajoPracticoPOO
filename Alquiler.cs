using System;
namespace trabajoPracticoPOO{
    public class Alquiler{
        private Cliente cliente;
        private Vehiculo vehiculo;
        private int dias;
        private double costoTotal;

        //Constructores
        public Alquiler( Cliente cliente, Vehiculo vehiculo, int dias ){
            this.cliente = cliente;
            this.vehiculo = vehiculo;
            this.dias = dias;
            costoTotal = dias*vehiculo.calcularCostoPorDia();
        }
        //Metodos
    }
}