using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class ProductosManager
    {
        public ProductosManager()
        {
            ErroresValidacion = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string,string>> ErroresValidacion { get; set; }


        public List<Productos> Get()
        {
            return Get(new Productos());
        }

        public List<Productos> Get(Productos ent)
        {
            List<Productos> ret = new List<Productos>();
            ret = CrearMockData();
            if (!string.IsNullOrEmpty(ent.NombreProducto))
            {
                ret = ret.Where(p => p.NombreProducto.ToLower().Contains(ent.NombreProducto.ToLower())).ToList();
            }
            return ret;
        }

        public Productos Get(int productoId)
        {
            List<Productos> ret = new List<Productos>();

            Productos entidad = null;
            ret = CrearMockData();
            entidad = ret.Find(p => p.ProductoId == productoId);
            return entidad;
        }

        public bool Actualizar(Productos entidad)
        {
            bool ret = false;
            ret = Validar(entidad);
            if (ret)
            {
                //TODO: Codigo para Actualizar entry
            }
            return ret;
        }

        public bool Eliminar(Productos entidad)
        {
            //TODO: Codigo para eliminar producto
            return true;
        }

        public bool Validar(Productos entidad)
        {
            ErroresValidacion.Clear();
            if (!string.IsNullOrEmpty(entidad.NombreProducto))
            {
                if(entidad.NombreProducto.ToLower() == entidad.NombreProducto)
                {
                    ErroresValidacion.Add(new KeyValuePair<string, string>("NombreProducto", "El nombre del producto no debe ser todo en letra minuscula"));
                }
            }

            return (ErroresValidacion.Count == 0);
        }

        public bool Insertar(Productos entidad)
        {
            bool ret = false;

            ret = Validar(entidad);
            if (ret)
            {
                //TODO: Codigo par INSERTAR
            }
            return ret;
        }


        private List<Productos> CrearMockData()
        {

            List<Productos> ret = new List<Productos>();

            ret.Add(new Productos()
            {
                ProductoId = 1,
                NombreProducto = "Extendiendo Bootstrap...",
                FechaIntroduccion = Convert.ToDateTime("6/11/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductoId = 1,
                NombreProducto = "Desarrollando en Bootstrap...",
                FechaIntroduccion = Convert.ToDateTime("6/11/2016"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductoId = 1,
                NombreProducto = "Desarrollar Apps Moviles.",
                FechaIntroduccion = Convert.ToDateTime("6/10/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductoId = 1,
                NombreProducto = "Entendiendo Bootstrap...",
                FechaIntroduccion = Convert.ToDateTime("6/05/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductoId = 1,
                NombreProducto = "Desarrollar Sitios Web...",
                FechaIntroduccion = Convert.ToDateTime("6/02/2017"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductoId = 1,
                NombreProducto = "Creando un Negocio...",
                FechaIntroduccion = Convert.ToDateTime("9/11/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            return ret;
        }
    }
}
