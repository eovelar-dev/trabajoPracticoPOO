using System;
using System.Collections.Generic;
using System.IO;
namespace trabajoPracticoPOO{
    class Program{
        public static void Main( string[] Args ){
        
            List<Vehiculo> listaDeVehiculos = new List<Vehiculo>();
            leerAutos( "listaDeVehiculos.csv", listaDeVehiculos );
            int opcion = 0;
            do{
                Console.WriteLine("MENU PRINCIPAL\n[1]Agregar un vehiculo a la agencia\n[2]Eliminar un vehiculo utilizando la patente\n[3]Registrar un cliente\n[4]Realizar un alquiler\n[5]Mostrar listado completo de vehiculos\n[6]Salir");
                try{
                    Console.Write("Ingrese una opcion: ");
                    opcion = int.Parse( Console.ReadLine() );
                    validarOpcion( opcion, 1, 6 );
                }
                catch( OpcionInvalidaException ex ){
                    Console.WriteLine( ex.Message );
                    Console.Write("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch( FormatException ex ){
                    Console.WriteLine( ex.Message );
                    Console.Write("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    Console.Clear();
                }

            }while( opcion != 6 );
            Console.Write("\nPresione cualquier tecla para finalizar...");
            Console.ReadKey(true);
            Console.Clear();
        }
        //Funciones
        public static void validarOpcion( int opcion, int minimo, int maximo ){
            if( opcion<minimo || opcion>maximo ){
                throw new OpcionInvalidaException() ;
            }
        }
        public static void leerAutos(string path, List<Vehiculo> lista){
            if( File.Exists(path) ){
                using( StreamReader sr = new StreamReader(path) ){
                    string linea;
                    while( (linea = sr.ReadLine()) != null ){
                        string[] partes = linea.Split(",");
                        if( partes[0] == "Auto" ){
                            lista.Add(
                                new Auto(
                                    partes[1],
                                    partes[2],
                                    partes[3],
                                    int.Parse( partes[4] ),
                                    double.Parse( partes[5] ),
                                    bool.Parse( partes[6] ),
                                    int.Parse( partes[7] ),
                                    bool.Parse( partes[8] )
                                )
                            );
                        }
                        else if( partes[0] == "Moto" ){
                            lista.Add(
                                new Moto(
                                    partes[1],
                                    partes[2],
                                    partes[3],
                                    int.Parse( partes[4] ),
                                    double.Parse( partes[5] ),
                                    bool.Parse( partes[6] ),
                                    int.Parse( partes[7] )
                                
                                )
                            );
                        }
                        else if( partes[0] == "Camioneta" ){
                            lista.Add(
                                new Camioneta(
                                    partes[1],
                                    partes[2],
                                    partes[3],
                                    int.Parse( partes[4] ),
                                    double.Parse( partes[5] ),
                                    bool.Parse( partes[6] ),
                                    int.Parse( partes[7] ),
                                    bool.Parse( partes[8] ) 
                                )
                            );
                        }
                    }
                }
            }
            else{
                Console.WriteLine("No se encontro ningun registro de vehiculos.");
            }
        }
    }
}