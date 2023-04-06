namespace Gobi.Test.Jr.Domain.Interfaces
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAll();
        void Add(TodoItem todoItem);
        void Update(TodoItem todoItem);
        TodoItem GetById(int todoItemId);
        void Delete(int todoItemId);
    }
}
