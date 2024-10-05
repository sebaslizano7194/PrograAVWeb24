﻿using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShippersDALImpl : DALGenericoImpl<Shipper>, IShippersDAL
    {
        NorthwndContext context;

        public ShippersDALImpl(NorthwndContext context): base(context) 
        { 
            this.context = context; 
        }
        
    }
}
