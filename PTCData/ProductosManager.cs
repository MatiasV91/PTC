using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace PTCData
{
    public class ProductosManager
    {
        private EFDbContext _contexto;

        public ProductosManager()
        {
            _contexto = new EFDbContext();
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
            ret = _contexto.Productos.ToList();
            if (!string.IsNullOrEmpty(ent.NombreProducto))
            {
                ret = ret.Where(p => p.NombreProducto.ToLower().Contains(ent.NombreProducto.ToLower())).ToList();
            }
            return ret;
        }

        public Productos Get(int productoId)
        {
            var entidad = _contexto.Productos.SingleOrDefault(p => p.ProductosId == productoId);
            return entidad;
        }

        public bool Actualizar(Productos entidad)
        {
            bool ret = false;
            ret = Validar(entidad);
            if (ret)
            {
                var producto = _contexto.Productos.SingleOrDefault(p => p.ProductosId == entidad.ProductosId);
                if(producto != null)
                {
                    producto.NombreProducto = entidad.NombreProducto;
                    producto.Precio = entidad.Precio;
                    producto.FechaIntroduccion = entidad.FechaIntroduccion;
                    producto.Url = entidad.Url;
                    _contexto.SaveChanges();
                }            
            }
            return ret;
        }

        public bool Eliminar(Productos entidad)
        {
            var producto = _contexto.Productos.SingleOrDefault(p => p.ProductosId == entidad.ProductosId);
            if(producto != null)
            {
                _contexto.Productos.Remove(producto);
                _contexto.SaveChanges();
            }
            
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
                
                _contexto.Productos.Add(entidad);
                _contexto.SaveChanges();
            }
            
            return ret;
        }


        private List<Productos> CrearMockData()
        {

            List<Productos> ret = new List<Productos>();

            ret.Add(new Productos()
            {
                ProductosId = 1,
                NombreProducto = "Extendiendo Bootstrap...",
                FechaIntroduccion = Convert.ToDateTime("6/11/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductosId = 1,
                NombreProducto = "Desarrollando en Bootstrap...",
                FechaIntroduccion = Convert.ToDateTime("6/11/2016"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductosId = 1,
                NombreProducto = "Desarrollar Apps Moviles.",
                FechaIntroduccion = Convert.ToDateTime("6/10/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductosId = 1,
                NombreProducto = "Entendiendo Bootstrap...",
                FechaIntroduccion = Convert.ToDateTime("6/05/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductosId = 1,
                NombreProducto = "Desarrollar Sitios Web...",
                FechaIntroduccion = Convert.ToDateTime("6/02/2017"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            ret.Add(new Productos()
            {
                ProductosId = 1,
                NombreProducto = "Creando un Negocio...",
                FechaIntroduccion = Convert.ToDateTime("9/11/2015"),
                Url = "URL",
                Precio = Convert.ToDecimal(290.00)
            });

            return ret;
        }
    }
}
