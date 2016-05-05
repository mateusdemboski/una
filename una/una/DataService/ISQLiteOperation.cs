using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using una.Entidades;

namespace una.DataService
{
    public interface ISQLiteOperation
    {
        void Salvar(Pessoa pessoa);
        void Excluir(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);

        IList<Pessoa> Select();
    }
}
