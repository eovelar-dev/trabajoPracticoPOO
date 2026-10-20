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
                    teclaParaContinuar();
                }
                catch( FormatException ex ){
                    Console.WriteLine( ex.Message );
                    teclaParaContinuar();
                }
                catch( OverflowException ex ){
                    Console.WriteLine( ex.Message );
                    teclaParaContinuar();
                }
                switch( opcion ){
                case 1: agregarUnVehiculo( listaDeVehiculos, "./listaDeVehiculos.csv" );
                teclaParaContinuar();
                break;
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: mostrarListadoDeVehiculos( listaDeVehiculos );
                teclaParaContinuar();
                break;
                case 6: break;
                default: break;
            }

            }while( opcion != 6 );
            teclaParaContinuar();
        }
        //Funciones
        public static void teclaParaContinuar(){
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
        }
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
        //Opcion 1
        public static void agregarUnVehiculo( List<Vehiculo> lista, string path ){
            int opcion = 0;
            do{
                try{
                    Console.WriteLine("Seleccione el tipo de vehiculo que desea agregar: \n[1]Auto\n[2]Moto\n[3]Camioneta\n[4]Salir");
                    opcion = int.Parse( Console.ReadLine() );
                    validarOpcion( opcion, 1, 4 );
                }
                catch( OpcionInvalidaException ex ){
                    Console.WriteLine( ex.Message );
                    teclaParaContinuar();
                }
                catch( FormatException ex ){
                    Console.WriteLine( ex.Message );
                    teclaParaContinuar();
                }
                catch( OverflowException ex ){
                    Console.WriteLine( ex.Message );
                    teclaParaContinuar();
                }
                List<string> partes= new List<string>();
                Console.WriteLine("A continuacion ingrese los datos del vehiculo:");
                Console.Write( "Patente: " );
                partes[0] = string.Parse( Console.ReadLine() );
                Console.Write( "Marca: " );
                partes[1] = Console.ReadLine();
                Console.Write( "Modelo: " );
                partes[2] = Console.ReadLine();
                Console.Write( "Año: " );
                partes[3] = Console.ReadLine();
                Console.Write( "precioPorDia: " );
                partes[4] = Console.ReadLine();
                Console.Write( "estaDisponible: " );
                partes[5] = Console.ReadLine();
                switch( opcion ){
                    case 1:
                    Console.Write("Cantidad de puertas:");
                    partes[6] = Console.ReadLine();
                    Console.Write("Caja automatica (True/False):");
                    partes[7] = Console.ReadLine();
                    break;
                    case 2: 
                    Console.Write("Cilindrada:");
                    partes[6] = Console.ReadLine();
                    break;
                    case 3: 
                    Console.Write("Capacidad de carga:");
                    partes[6] = Console.ReadLine();
                    Console.Write("4x4 (True/False):");
                    partes[7] = Console.ReadLine();
                    break;
                    default: break;
                }
                
            }while( opcion != 4 );
        }
        //Opcion 5
        public static void mostrarListadoDeVehiculos( List<Vehiculo> lista ){
            if( lista.Count>0 ){
                foreach( Vehiculo v in lista ){
                    v.mostrar();
                    Console.WriteLine("************");
                }
            }
            else{
                Console.WriteLine("No se encontro ningun vehiculo registrado.");
            }
        }
    }
}