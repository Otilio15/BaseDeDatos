using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;


namespace Controlador
{
    public class VehiculosController
    {
        PARQUEOEntities db = new PARQUEOEntities();

        public bool GuardarVehículo (string placa, string marca, int modelo)
        {
            bool resultado = false;

            try
            {
                VEHICULO Carro = new VEHICULO();

                Carro.Marca = marca;
                Carro.Modelo = modelo;
                Carro.NumeroPlaca = placa;
                db.VEHICULOS.Add(Carro);
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


        public bool ActualizarVehículo(string placa, string marca, int modelo)
        {
            bool resultado = false;

            try
            {
                VEHICULO Carro = new VEHICULO();

                Carro = (from A in db.VEHICULOS where A.NumeroPlaca == placa select A).First();

                Carro.Marca = marca;
                Carro.Modelo = modelo;
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

        public bool EliminarVehículo(string placa)
        {
            bool resultado = false;

            try
            {
                VEHICULO Carro = new VEHICULO();

                Carro = (from A in db.VEHICULOS where A.NumeroPlaca == placa select A).First();

                db.VEHICULOS.Remove(Carro);
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

        public VEHICULO RetornarVehiculo(string placa)
        {
            VEHICULO Carro = new VEHICULO();
            try
            {
                Carro = (from A in db.VEHICULOS where A.NumeroPlaca == placa select A).First();
                return Carro;
            }
            catch (Exception ex)
            {
                return Carro = null;
                throw;
            }
            return Carro;
        }
    }


   
}
