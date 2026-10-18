using System;
using System.Collections.Generic;
namespace trabajoPracticoPOO{
    class Program{
        public static void Main( string[] Args ){
            List<Vehiculo> listaDeVehiculos = new List<Vehiculo>();
            listaDeVehiculos.Add( new Auto( "HNX020", "Chevrolet", "Corsa Classic", 2008, 10000, true, 3, false ) );
            listaDeVehiculos.Add( new Moto( "ATR420", "Yamaha", "YBR", 2014, 10000, true, 125 ) );
            listaDeVehiculos.Add( new Auto( "KNJ116", "Volkswagen", "Suran", 2012, 13000, true, 3, true ) );
            listaDeVehiculos.Add( new Moto( "ATR421", "Yamaha", "YBR", 2014, 10000, true, 300 ) );
            listaDeVehiculos.Add( new Camioneta( "CAM048", "Fiat", "Strada", 2015, 50000, true, 200, false ) );
            listaDeVehiculos.Add( new Camioneta( "CAM048", "Toyota", "Hilux", 2015, 50000, true, 200, true ) );
            
            foreach( Vehiculo vehiculo in listaDeVehiculos ){
                vehiculo.mostrar();
                Console.WriteLine("**********");
            }

            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}