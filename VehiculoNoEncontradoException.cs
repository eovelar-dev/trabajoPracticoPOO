using System;
public class VehiculoNoEncontradoException : Exception{

    public VehiculoNoEncontradoException() : base("Vehiculo no registrado en el sistema."){
    } 
    public VehiculoNoEncontradoException( string mensaje ) : base(mensaje){
    } 

}