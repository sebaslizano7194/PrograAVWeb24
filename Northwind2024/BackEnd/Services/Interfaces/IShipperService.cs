using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {
        bool Agregar(ShippersDTO shipper);
        bool Editar(ShippersDTO shipper);
        bool Eliminar(ShippersDTO shipper);
        /// <summary>
        ///  Obtiene Shipper por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShippersDTO Obtener (int id);
        /// <summary>
        /// Obtiene todos los Shippers
        /// </summary>
        /// <returns></returns>
        List<ShippersDTO> Obtener();
    }
}
