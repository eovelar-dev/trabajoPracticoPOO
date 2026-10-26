using System;
using System.Collections.Generic;
using System.IO;
namespace trabajoPracticoPOO{
    class Program{
        public static void Main( string[] Args ){
        
            //Ubicacion de los archivos
            string pathVehiculos = "./listaDeVehiculos.csv";
            string pathClientes = "./listaDeClientes.csv";
            string pathAlquileres = "./listaDeAlquileres.csv";
            //Declaracion de listas
            List<Vehiculo> listaDeVehiculos = new List<Vehiculo>();
            List<Cliente> listaDeClientes = new List<Cliente>();
            List<Alquiler> listaDeAlquileres = new List<Alquiler>();
            //PreCarga de Listas
            leerAutos( pathVehiculos, listaDeVehiculos );
            leerClientes( pathClientes, listaDeClientes );
            leerAlquileres( pathAlquileres, listaDeAlquileres, listaDeClientes, listaDeVehiculos );
            int opcion = 0;
            do{
                Console.WriteLine("MENU PRINCIPAL\n[1]Agregar un vehiculo a la agencia\n[2]Eliminar un vehiculo utilizando la patente\n[3]Registrar un cliente\n[4]Realizar un alquiler\n[5]Mostrar listado completo de vehiculos\n[6]Mostrar listado completo de clientes\n[7]Mostrar historial de alquileres realizados\n[8]Mostrar vehiculos que permiten seguro adicional\n[9]Salir");
                try{
                    Console.Write("Ingrese una opcion: ");
                    opcion = int.Parse( Console.ReadLine() );
                    validarOpcion( opcion, 1, 9 );
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
                case 1: agregarUnVehiculo( listaDeVehiculos, pathVehiculos );
                teclaParaContinuar();
                break;
                case 2:
                try{
                    Console.Write("Ingrese la patente del vehiculo que desea eliminar:");
                    string patente = Console.ReadLine().ToUpper();
                    eliminarUnVehiculo( listaDeVehiculos, patente, pathVehiculos );
                }
                catch( FormatException ex ){
                    Console.WriteLine( ex.Message );
                    teclaParaContinuar();
                }
                teclaParaContinuar();
                break;
                case 3: break;
                case 4: break;
                case 5: mostrarListadoDeVehiculos( listaDeVehiculos );
                teclaParaContinuar();
                break;
                case 6: mostrarListadoDeClientes( listaDeClientes ); 
                teclaParaContinuar();
                break;
                case 7: mostrarListadoDeAlquileres( listaDeAlquileres );
                teclaParaContinuar();
                break;
                case 8: mostrarVehiculosAsegurables( listaDeVehiculos );
                teclaParaContinuar();
                break;
                default: break;
            }

            }while( opcion != 9 );
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
        public static void leerClientes( string path, List<Cliente> lista ){
            if( File.Exists( path ) ){
                using( StreamReader sr = new StreamReader( path ) ){
                    string linea;
                    while( ( linea = sr.ReadLine() ) != null ){
                        string[] partes = linea.Split(",");
                        lista.Add( new Cliente( partes[0], partes[1], int.Parse( partes[2] ), int.Parse( partes[3] ) ) );
                    }
                }
            }
            else{
                Console.WriteLine( "No se encontro ningun registro de clientes." );
            }
        }
        public static void leerAlquileres( string path, List<Alquiler> lista, List<Cliente> clientes, List<Vehiculo> vehiculos ){
            if( File.Exists( path ) ){
                using( StreamReader sr = new StreamReader( path ) ){
                    string linea;
                    while( ( linea = sr.ReadLine() ) != null ){
                        string[] partes = linea.Split(",");
                        lista.Add( new Alquiler( clientes[encontrarCliente( clientes, int.Parse(partes[0]) )], vehiculos[encontrarPatente( vehiculos, partes[1] )], int.Parse( partes[2] ), double.Parse( partes[3] ) ) );
                    }
                }
            }
            else{
                Console.WriteLine( "No se encontro ningun registro de clientes." );
            }
        }
        public static int encontrarPatente( List<Vehiculo> lista, string patente ){
            int pos = 0;
            foreach( Vehiculo v in lista ){
                if( v.PATENTE.ToUpper() == patente.ToUpper() ){
                    return pos; 
                }
            }
            return -1;
        }
        public static int encontrarCliente( List<Cliente> lista, int dni ){
            int pos = 0;
            foreach( Cliente c in lista ){
                if( c.DNI == dni ){
                    return pos;
                }
            }
            return -1;
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
                if( opcion != 4 ){
                    Console.WriteLine("A continuacion ingrese los datos del vehiculo:");
                    Console.Write( "Patente: " );
                    partes.Add( Console.ReadLine().ToUpper() );
                    Console.Write( "Marca: " );
                    partes.Add( Console.ReadLine() );
                    Console.Write( "Modelo: " );
                    partes.Add( Console.ReadLine() );
                    Console.Write( "Año: " );
                    partes.Add( Console.ReadLine() );
                    Console.Write( "precioPorDia: " );
                    partes.Add( Console.ReadLine() );
                    Console.Write( "estaDisponible: " );
                    partes.Add( Console.ReadLine() );
                }
                switch( opcion ){
                    case 1:
                    Console.Write("Cantidad de puertas:");
                    partes.Add( Console.ReadLine() );
                    Console.Write("Caja automatica (True/False):");
                    partes.Add( Console.ReadLine() );
                    if( encontrarPatente( lista, partes[0] ) < 0 ){
                        lista.Add( new Auto( partes[0], partes[1], partes[2], int.Parse(partes[3]), double.Parse(partes[4]), bool.Parse(partes[5]), int.Parse(partes[6]),bool.Parse(partes[7]) ) );
                        using( StreamWriter sw = new StreamWriter( path, true ) ){
                            sw.WriteLine( lista[lista.Count-1].obtenerCsv() );
                        }

                    }
                    else{
                        Console.WriteLine("No es posible agregar el vehiculo a la lista debido a que ya se encuentra otro vehiculo registrado con esa patente.");
                    }
                    break;
                    case 2: 
                    Console.Write("Cilindrada:");
                    partes.Add( Console.ReadLine() );
                    if( encontrarPatente( lista, partes[0] ) < 0 ){
                        lista.Add( new Moto( partes[0], partes[1], partes[2], int.Parse(partes[3]), double.Parse(partes[4]), bool.Parse(partes[5]), int.Parse(partes[6]) ) );
                        using( StreamWriter sw = new StreamWriter( path, true ) ){
                            sw.WriteLine( lista[lista.Count-1].obtenerCsv() );
                        }

                    }
                    else{
                        Console.WriteLine("No es posible agregar el vehiculo a la lista debido a que ya se encuentra otro vehiculo registrado con esa patente.");
                    }
                    break;
                    case 3: 
                    Console.Write("Capacidad de carga:");
                    partes.Add( Console.ReadLine() );
                    Console.Write("4x4 (True/False):");
                    partes.Add( Console.ReadLine() );
                    if( encontrarPatente( lista, partes[0] ) < 0 ){
                        lista.Add( new Camioneta( partes[0], partes[1], partes[2], int.Parse(partes[3]), double.Parse(partes[4]), bool.Parse(partes[5]), int.Parse(partes[6]),bool.Parse(partes[7]) ) );
                        using( StreamWriter sw = new StreamWriter( path, true ) ){
                            sw.WriteLine( lista[lista.Count-1].obtenerCsv() );
                        }

                    }
                    else{
                        Console.WriteLine("No es posible agregar el vehiculo a la lista debido a que ya se encuentra otro vehiculo registrado con esa patente.");
                    }
                    break;
                    default: break;
                }
            }while( opcion != 4 );
        }
        //Opcion 2
        public static void eliminarUnVehiculo( List<Vehiculo> lista,string patente, string path ){
            int indice = encontrarPatente( lista, patente );
            if( indice >= 0 ){
                lista.RemoveAt(indice);
                using( StreamWriter sw = new StreamWriter( path ) ){
                    foreach( Vehiculo v in lista ){
                        sw.WriteLine( v.obtenerCsv() );
                    }
                }
                Console.WriteLine("Vehiculo eliminado correctamente.");
            }
            else{
                Console.WriteLine( "Vehiculo no encontrado." );
            }
        }
        //Opcion 3
        //public static void registrarCliente();
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
        //Opcion 6
        public static void mostrarListadoDeClientes( List<Cliente> lista ){
            if( lista.Count>0 ){
                foreach( Cliente c in lista ){
                    c.mostrar();
                    Console.WriteLine("************");
                }
            }
            else{
                Console.WriteLine("No se encontro ningun cliente registrado.");
            }
        }
        //Opcion 7
        public static void mostrarListadoDeAlquileres( List<Alquiler> lista ){
            if( lista.Count>0 ){
                foreach( Alquiler a in lista ){
                a.mostrar();
                Console.WriteLine("**********");
                }
            }
            else{
                Console.WriteLine("No se encontro ningun alquiler registrado.");
            }
        }
        //Opcion 8
        public static void mostrarVehiculosAsegurables( List<Vehiculo> lista ){
            foreach( Vehiculo v in lista ){
                if( v.SEGURO ){
                    v.mostrarInfoSeguro();
                    Console.WriteLine("*********");
                }
            }
        }
    }
}