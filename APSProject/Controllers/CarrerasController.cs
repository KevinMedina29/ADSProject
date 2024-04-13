using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ADSProject.Controllers
{
    [Route("api/carreras/")]
    public class CarrerasController : ControllerBase
    {
            private readonly ICarrera carrera;
            public const string COD_EXITO = "000000";
            public const string COD_ERROR = "999999";
            private string pCodRespuesta;
            private string pMensajeUsuario;
            private string pMensajeTecnico;

            public CarrerasController(ICarrera carrera)
            {
                this.carrera = carrera;
            }

            [HttpPost("agregarCarrera")]
            public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
            {
            try
            {
                int contador = this.carrera.AgregarCarrera(carrera);

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

            [HttpPost("actualizarCarrera/{Id}")]
            public ActionResult<string> ActualizarCarrera(int id, [FromBody] Carrera carrera)
            {
                try
                {
                    int contador = this.carrera.ActualizarCarrera(id, carrera);

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

            [HttpDelete("eliminarCarrera/{Id}")]
            public ActionResult<string> EliminarCarrera(int id)
            {
                try
                {
                    bool eliminado = this.carrera.EliminarCarrera(id);

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

            [HttpGet("obtenerCarreraPorID/{Id}")]
            public ActionResult<Carrera> ObtenerCarreraPorID(int id)
            {
                try
                {
                    Carrera carrera = this.carrera.ObtenerCarreraPorID(id);

                    if (carrera != null)
                    {
                        return Ok(carrera);
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

            [HttpGet("obtenerCarrera")]
            public ActionResult<List<Carrera>> ObtenerCarrera()
            {
                try
                {
                    List<Carrera> lstCarrera = this.carrera.ObtenerTodasLasCarreras();

                    return Ok(lstCarrera);
                }
                catch (Exception)
                {

                    throw;
                }
            }
    }
}
