using apiRESTCenso.Models;
using System; 
using System.Collections.Generic;
using System.Linq; 
using System.Net; 
using System.Net.Http; 
using System.Web.Http; 

namespace apiRESTCenso.Controllers 
{
    // Declara la clase que maneja las solicitudes HTTP
    public class CensoController : ApiController 
    {
        // Definición del arreglo de objetos que almacenará los registros del censo
        public static clsCenso[] objCenso = null;

        // GET: api/Censo
        // Método para obtener todos los registros del censo
        public IEnumerable<clsCenso> Get() 
        {
            // Retorna el arreglo completo de objetos clsCenso
            return objCenso;
        }

        // GET: api/Censo/5
        // Método para obtener un registro específico por ID
        public clsCenso Get(int id) 
        {
            // Inicializa una variable para almacenar el resultado
            clsCenso elemento = null; 
            // Verifica si el arreglo ha sido inicializado
            if (objCenso != null) 
            {
                // Itera sobre el arreglo de censo
                foreach (var item in objCenso)
                {
                    // Busca el elemento con el ID especificado
                    if (item != null && item.id == id) 
                    {
                        // Guarda el elemento encontrado
                        elemento = item;
                        // Sale del bucle una vez que encuentra el elemento
                        break; 
                    }
                }
            }
            // Retorna el elemento encontrado o null si no se encuentra
            return elemento; 
        }

        // POST: api/Censo
        // Método para agregar un nuevo registro en una posición específica
        public string Post(int posicion, [FromBody] clsCenso modelo) 
        {
            // Verifica si el arreglo no ha sido inicializado
            if (objCenso == null) 
            {
                // Crea un arreglo con 5 espacios
                objCenso = new clsCenso[5];
                // Inicializa cada posición con un nuevo objeto clsCenso
                for (int i = 0; i < 5; i++) 
                {
                    objCenso[i] = new clsCenso();
                }
            }
            // Verifica si la posición es válida
            if (posicion >= 0 && posicion < objCenso.Length) 
            {
                // Asigna el objeto recibido en la posición especificada
                objCenso[posicion] = new clsCenso 
                {
                    id = modelo.id,
                    curp = modelo.curp,
                    nombre = modelo.nombre,
                    apellidoPaterno = modelo.apellidoPaterno,
                    apellidoMaterno = modelo.apellidoMaterno,
                    direccion = modelo.direccion,
                    actividadEconomica = modelo.actividadEconomica
                };
                return "1"; // Indica éxito
            }
            return "0"; // Indica que la posición es inválida
        }

        // PUT: api/Censo/5
        // Método para actualizar un registro en una posición específica
        public string Put(int posicion, [FromBody] clsCenso modelo) 
        {
            // Verifica si el arreglo está inicializado y si la posición es válida
            if (objCenso != null && posicion >= 0 && posicion < objCenso.Length) 
            {
                // Actualiza los datos del objeto en la posición especificada
                objCenso[posicion] = new clsCenso 
                {
                    id = modelo.id,
                    curp = modelo.curp,
                    nombre = modelo.nombre,
                    apellidoPaterno = modelo.apellidoPaterno,
                    apellidoMaterno = modelo.apellidoMaterno,
                    direccion = modelo.direccion,
                    actividadEconomica = modelo.actividadEconomica
                };
                return "1"; // Indica éxito
            }
            // Retorna "-1" si el arreglo no ha sido inicializado, "0" si la posición es inválida
            return objCenso == null ? "-1" : "0"; 
        }

        // DELETE: api/Censo/5
        // Método para eliminar un registro en una posición específica
        public string Delete(int posicion) 
        {
            // Verifica si el arreglo está inicializado y si la posición es válida
            if (objCenso != null && posicion >= 0 && posicion < objCenso.Length) 
            {
                // Reinicia el objeto en la posición especificada
                objCenso[posicion] = new clsCenso(); 
                return "1"; // Indica éxito
            }
            // Retorna "-1" si el arreglo no ha sido inicializado, "0" si la posición es inválida
            return objCenso == null ? "-1" : "0"; 
        }
    }
}
