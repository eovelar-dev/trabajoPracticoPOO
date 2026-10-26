using System;
public class ClienteNoEncontradoException : Exception{

    public ClienteNoEncontradoException() : base("Cliente no registrado en el sistema."){
    } 
    public ClienteNoEncontradoException( string mensaje ) : base(mensaje){
    } 

}