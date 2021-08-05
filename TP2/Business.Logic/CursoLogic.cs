using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter CursoData { get; set; }
        public CursoLogic(CursoAdapter cursoAdapter)
        {
            CursoData = cursoAdapter;
        }
        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }
        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }
        public List<Curso> GetCursosProfesor(int idProfesor)
        {
            return CursoData.GetCursosProfesor(idProfesor);
        }
        public void Delete(int id)
        {
            CursoData.Delete(id);
        }
        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }
    }
}
