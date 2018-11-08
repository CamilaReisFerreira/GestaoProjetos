using GestaoProjetos.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DAL.Interfaces
{
    public interface IProjetoDAL
    {
        IList<Projeto> ListarProjetos();

        void Add(Projeto item);

        void Update(Projeto item);

        void Delete(long Id);

        Projeto GetProjeto(long Id);
    }
}
