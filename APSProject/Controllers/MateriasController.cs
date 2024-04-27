using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ADSProject.Controller
{
    [Route("api/carreras/")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateria materia;
        public const string COD_EXITO = "000000";
        public const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public MateriasController(IMateria materia)
        {
            this.materia = materia;
        }

        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria([FromBody] Materia materia)
        {
            try
            {
                int contador = this.materia.AgregarMateria(materia);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("actualizarMateria/{Id}")]
        public ActionResult<string> ActualizarMateria(int id, [FromBody] Materia materia)
        {
            try
            {
                int contador = this.materia.ActualizarMateria(id, materia);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("eliminarMateria/{Id}")]
        public ActionResult<string> EliminarMateria(int id)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(id);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("obtenerMateriaPorID/{Id}")]
        public ActionResult<Materia> ObtenerMateriaPorID(int id)
        {
            try
            {
                Materia materia = this.materia.ObtenerMateriaPorID(id);

                if (materia != null)
                {
                    return Ok(materia);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del estudiante";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("obtenerMateria")]
        public ActionResult<List<Materia>> ObtenerMateria()
        {
            try
            {
                List<Materia> lstMateria = this.materia.ObtenerTodasLasMaterias();

                return Ok(lstMateria);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
