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
        public ICultureDAL CultureDAL { get; set; }

        private Adventureworks2016Context _Context;
        public UnidadDeTrabajo(Adventureworks2016Context Context,
                        ICultureDAL categoryDAL) 
        {
                this._Context = Context;
                this.CultureDAL = categoryDAL;
        }
       

        public bool Complete()
        {
            try
            {
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._Context.Dispose();
        }
    }
}
