using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IShippersDAL ShippersDAL { get; set; }
        private NorthwndContext _northWindContext;

        public UnidadDeTrabajo(NorthwndContext northWindContext,
                        IShippersDAL shippersDAL

            )
        {
            this._northWindContext = northWindContext;
            this.ShippersDAL = shippersDAL;

        }


        public bool Complete()
        {
            try
            {
                _northWindContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._northWindContext.Dispose();
        }
    }
}
