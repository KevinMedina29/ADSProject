using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> lstMateria = new List<Materia>
        {
            new Materia{IdMateria=1, NombreMateria="Analisis de Sistemas"}
        };

        public int ActualizarMateria(int id, Materia materia)
        {
            try
            {
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == id);

                lstMateria[indice] = materia;

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarMateria(Materia materia)
        {
            try
            {
                if (lstMateria.Count > 0)
                {
                    materia.IdMateria = lstMateria.Last().IdMateria + 1;
                }
                lstMateria.Add(materia);

                return materia.IdMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarMateria(int id)
        {
            try
            {
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == id);

                lstMateria.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Materia ObtenerMateriaPorID(int id)
        {
            try
            {
                Materia materia = lstMateria.FirstOrDefault(tmp => tmp.IdMateria == id);

                return materia;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            try
            {
                return lstMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
