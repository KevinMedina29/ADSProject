using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IMateria
    {
        public int AgregarMateria(Materia materia);
        public int ActualizarMateria (int Id, Materia materia);
        public bool EliminarMateria(int Id);
        public List<Materia> ObtenerTodasLasMaterias();
        public Materia ObtenerMateriaPorID(int Id);
    }
}
