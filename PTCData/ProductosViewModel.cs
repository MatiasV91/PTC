using PTCComun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class ProductosViewModel : ViewModelBase
    {
        public ProductosViewModel() : base()
        {
            Productos = new List<Productos>();
            Buscar = new Productos();
            Entidad = new Productos();
        }

        public Productos Entidad { get; set; }      
        public List<Productos> Productos { get; set; }
        public Productos Buscar { get; set; }

        protected override void Init()
        {
            Productos = new List<Productos>();
            Buscar = new Productos();
            Entidad = new Productos();
            base.Init();
        }

        protected override void Guardar()
        {
            ProductosManager mgr = new ProductosManager();
            if (Modo == "Agregar")
            {
                if (EsValido)
                {
                    mgr.Insertar(Entidad);
                }               
            }
            else
            {
                mgr.Actualizar(Entidad);
            }
            ErroresValidacion = mgr.ErroresValidacion;

            base.Guardar();
        }

        protected override void Agregar()
        {
            EsValido = true;
            Entidad = new Productos();
            Entidad.FechaIntroduccion = DateTime.Now;
            Entidad.Url = "http://";
            Entidad.Precio = 0;
            base.Agregar();
        }

        protected override void Editar()
        {
            ProductosManager mgr = new ProductosManager();
            Entidad = mgr.Get(Convert.ToInt32(Argumento));
            base.Editar();
        }

        protected override void Eliminar()
        {
            ProductosManager mgr = new ProductosManager();
            Entidad = new Productos();
            Entidad.ProductosId = Convert.ToInt32(Argumento);
            mgr.Eliminar(Entidad);
            Get();
            base.Eliminar();
        }

        protected override void ResetBusqueda()
        {
            Buscar = new Productos();
            base.ResetBusqueda();
        }

        protected override void Get()
        {
            ProductosManager mgr = new ProductosManager();
            Productos = mgr.Get(Buscar);
            base.Get();
        }
    }
}
