using BackEnd.DTO;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        IShipperService shipperService;

        public ShipperController(IShipperService shipperService)
        {
            this.shipperService = shipperService;   
        }
        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<ShippersDTO> Get()
        {
            return shipperService.Obtener();
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ShippersDTO Get(int id)
        {
            return shipperService.Obtener(id);
        }

        // POST api/<ShipperController>
        [HttpPost]
        public IActionResult Post([FromBody] ShippersDTO shipper)
        {
            shipperService.Agregar(shipper);
            return Ok(shipper);
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ShippersDTO shipper)
        {
            shipperService.Editar(shipper);
            return Ok(shipper);
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ShippersDTO shipper = new ShippersDTO
            {
                ShipperId = id
            };

            //ShipperService.Eliminar(shipper);
        }
    }
}
