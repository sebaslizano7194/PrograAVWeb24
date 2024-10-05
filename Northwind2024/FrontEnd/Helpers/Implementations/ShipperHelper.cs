using FrontEnd.Helpers.Interfaces;
using FrontEnd.APIModels;
using Newtonsoft.Json;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Implementations
{
    public class ShipperHelper : IShipperHelper
    {
        IServiceRepository _ServiceRepository;

        public ShipperHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        public List<ShipperViewModel> GetShippers()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Shipper");
            List<Shipper> shippers = new List<Shipper>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                shippers = JsonConvert.DeserializeObject<List<Shipper>>(content);
            }

            List<ShipperViewModel> resultado = new List<ShipperViewModel>();
            foreach (var item in shippers)
            {
                resultado.Add(
                            new ShipperViewModel
                            {
                                ShipperId = item.ShipperId,
                                CompanyName = item.CompanyName
                            }
                    );
            }
            return resultado;

        }

        public ShipperViewModel GetShipper(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Shipper/" + id.ToString());
            Shipper shipper = new Shipper();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                shipper = JsonConvert.DeserializeObject<Shipper>(content);
            }

            ShipperViewModel resultado =
                            new ShipperViewModel
                            {
                                ShipperId = shipper.ShipperId,
                                CompanyName = shipper.CompanyName
                            };


            return resultado;
        }

    }
}
