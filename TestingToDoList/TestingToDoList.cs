using ToDoWPF;

namespace TestingToDoList
{
    public class TestingToDoList
    {
        /// <summary>
        /// Tester för AddTask, RemoveTask och invalid index.
        /// </summary>
        public class ToDoListTests
        {
            private ToDoList _toDoList;
            public ToDoListTests()
            {
                _toDoList = new ToDoList();
            }

            [Fact]
            public void AddTask_ShouldAddTaskToList()
            {
                var task = "Test Task";
                _toDoList.AddTask(task);
                var tasks = _toDoList.GetAllTasks();
                Assert.Contains(task, tasks);
            }

            [Fact]
            public void RemoveTask_ShouldRemoveTaskFromlist()
            {
                var task = "Task to remove";
                _toDoList.AddTask(task);
                _toDoList.RemoveTask(0);
                var tasks = _toDoList.GetAllTasks();
                Assert.DoesNotContain(task, tasks);
            }

            [Fact]
            public void RemoveTask_InvalidIndex_ShouldNotThrowException()
            {
                var task = "Valid task";
                _toDoList.AddTask(task);
                _toDoList.RemoveTask(10); //Invalid index.
                var tasks = _toDoList.GetAllTasks();
                Assert.Single(tasks); //Den ursprungliga tasken ska finnas kvar.
            }
        }
    }
}