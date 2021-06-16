using System.Collections.Generic;
namespace Series.Interfaces
{
    //Interface com métodos obrigatórios na implementação dela
    public interface IRepositorio<T> //T é u tipo genérico para se referir ao IRepositorio
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id,T entidade);
         int ProximoId();
    }
}