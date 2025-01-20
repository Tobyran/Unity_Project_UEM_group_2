using UnityEngine;

public class Transicion
{
    public Condicion condicion;
    public Estado siguiendoEstado;


    public Transicion(Condicion con, Estado est)
    {
        condicion = con;
        siguiendoEstado = est;
    }
}
