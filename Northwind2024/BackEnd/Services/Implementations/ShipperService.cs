using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ShipperService : IShipperService
    {
        IUnidadDeTrabajo Unidad;

        public ShipperService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }
        #region Convertir

        Shipper Convertir(ShippersDTO shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,

            };
        }

        ShippersDTO Convertir (Shipper shipper)
        {
            return new ShippersDTO
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName
            };
        }

        #endregion 
        public bool Agregar(ShippersDTO shipper)
        {
            Shipper entity = Convertir(shipper);
            Unidad.ShippersDAL.Add(entity);
            return Unidad.Complete();
        }

        public bool Editar(ShippersDTO shipper)
        {
            var entity = Convertir(shipper);
            Unidad.ShippersDAL.Update(entity);
            return Unidad.Complete();   
        }

        public bool Eliminar(ShippersDTO shipper)
        {
            Unidad.ShippersDAL.Remove(Convertir(shipper));
            return Unidad.Complete();  
        }

        public ShippersDTO Obtener(int id)
        {
            return Convertir(Unidad.ShippersDAL.Get(id));

        }

        public List<ShippersDTO> Obtener()
        {
            List<ShippersDTO> list = new List<ShippersDTO>();
            var shippers = Unidad.ShippersDAL.GetAll().ToList();

            foreach (var item in shippers)
            {
                list.Add(Convertir(item));
            }

            return list;
        }
    }
}
