using System;
using System.Collections.Generic;
using System.IO;
namespace trabajoPracticoPOO{
    class Program{
        public static void Main( string[] Args ){
        
            List<Vehiculo> listaDeVehiculos = new List<Vehiculo>();
            leerAutos( "listaDeVehiculos.csv", listaDeVehiculos );

            foreach( Vehiculo v in listaDeVehiculos ){
                v.mostrar();
                Console.WriteLine("********");
            }

            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
        }
        //Funciones
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