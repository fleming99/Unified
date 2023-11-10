namespace MarketplaceOnline.Models.Repository
{
    public interface IRepository<T>
    {
        public void Adicionar(T entity);
        public void Atualizar(T entity);
        public void Excluir(T entity);
        public T ObterPorId(int id);
        public List<T> ObterTodos();
    }
}
