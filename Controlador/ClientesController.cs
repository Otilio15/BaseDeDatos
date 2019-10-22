using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;




namespace Controlador
{
   public class ClientesController
    {

        PARQUEOEntities db = new PARQUEOEntities();

        public bool GuardarCliente(int id, string nombre, string cedula )
        {
            bool resultado = false;

            try
            {
                CLIENTE cliente = new CLIENTE();

                cliente.IDcliente = id;
                cliente.Nombre = nombre;
                cliente.Cedula= cedula;
                db.CLIENTES.Add(cliente);
                db.SaveChanges();

                System.Data.Entity.Core.Objects.ObjectParameter mensaje = new System.Data.Entity.Core.Objects.ObjectParameter("Mensaje","");
                db.GenereaTiquete("user", id, "1212DDD", mensaje );

               

                return resultado = true;
            }
            catch (Exception ex)
            {

                return resultado = false;
                throw;
            }


            return resultado;
        }


        public bool ActualizarCliente(int id, string nombre, string cedula)
        {
            bool resultado = false;

            try
            {
                CLIENTE cliente = new CLIENTE();

                cliente = (from A in db.CLIENTES where A.IDcliente == id select A).First();

                cliente.Nombre = nombre;
                cliente.Cedula = cedula;
                db.SaveChanges();

                return resultado = true;
            }
            catch (Exception ex)
            {

                return resultado = false;
                throw;
            }


            return resultado;
        }

        public bool EliminarCliente(string cedula)
        {
            bool resultado = false;

            try
            {
                CLIENTE cliente = new CLIENTE();


                cliente= (from A in db.CLIENTES where A.Cedula == cedula select A).First();

                db.CLIENTES.Remove(cliente);
                db.SaveChanges();

                return resultado = true;
            }
            catch (Exception ex)
            {

                return resultado = false;
                throw;
            }


            return resultado;
        }

        public CLIENTE RetornarCliente(string cedula)
        {
            CLIENTE cliente = new CLIENTE();
            
            try
            {
                cliente = (from A in db.CLIENTES where A.Cedula == cedula select A).First();
            }
            catch (Exception ex)
            {
                return cliente = null;
                throw;
            }
            return cliente;
        }
    }
}
