using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCComun
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Init();
        }

        public List<KeyValuePair<string, string>> ErroresValidacion { get; set; }
        public string Modo { get; set; }
        public string Comando { get; set; }
        public string Argumento { get; set; }
        public bool EsAreaDetallesVisible { get; set; }
        public bool EsAreaListaVisible { get; set; }
        public bool EsAreaBusquedaVisible { get; set; }
        public bool EsValido { get; set; }

        public virtual void PedidoMgr()
        {
            switch (Comando.ToLower())
            {
                case "lista":
                case "buscar":
                    Get();
                    break;
                case "resetbusqueda":
                    ResetBusqueda();
                    Get();
                    break;
                case "agregar":
                        Agregar();     
                    break;
                case "guardar":
                    Guardar();
                    if (EsValido)
                    {
                        Get();
                    }
                    break;
                case "editar":
                    EsValido = true;
                    Editar();
                    break;
                case "eliminar":
                    ResetBusqueda();
                    Eliminar();
                    break;
                case "cancelar":
                    ModoLista();
                    Get();
                    break;
                default:
                    break;
            }
        }

        protected virtual void Init()
        {
            Comando = "Lista";
            ErroresValidacion = new List<KeyValuePair<string, string>>();
            Argumento = string.Empty;
            ModoLista();
        }

        protected virtual void ModoLista()
        {
            EsValido = true;
            EsAreaListaVisible = true;
            EsAreaBusquedaVisible = true;
            EsAreaDetallesVisible = false;
            Modo = "Lista";
        }

        protected virtual void ModoAgregar()
        {
            EsAreaListaVisible = false;
            EsAreaBusquedaVisible = false;
            EsAreaDetallesVisible = true;
            Modo = "Agregar";
        }

        protected virtual void ModoEditar()
        {
            EsAreaListaVisible = false;
            EsAreaBusquedaVisible = false;
            EsAreaDetallesVisible = true;
            Modo = "Editar";
        }

        protected virtual void Get()
        {
            
        }

        protected virtual void ResetBusqueda()
        {
        }

        protected virtual void Agregar()
        {
            ModoAgregar();
        }

        protected virtual void Editar()
        {
            ModoEditar();
        }

        protected virtual void Eliminar()
        {
            ModoLista();
        }

        protected virtual void Guardar()
        {
            if (ErroresValidacion.Count > 0)
            {
                EsValido = false;
            }

            if (!EsValido)
            {
                if (Modo == "Agregar")
                {
                    ModoAgregar();
                }
                else
                {
                    ModoEditar();
                }
            }
        }
    }
}   
