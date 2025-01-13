using System.Windows;

namespace ToDoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDoList _toDoList;
        public MainWindow()
        {
            InitializeComponent();
            _toDoList = new ToDoList();
        }
        /// <summary>
        /// Lägger till en todo-item i listan.
        /// </summary>
        /// <param name="sender">sender från MainWindow</param>
        /// <param name="e">event</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;
            if (!string.IsNullOrEmpty(task)) 
            {
                _toDoList.AddTasks(task);
                UpdateTaskList();
                TaskTextBox.Clear();
            }
        }
        /// <summary>
        /// Uppdaterar listan med todo-items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTaskList() 
        {
            TasksListBox.Items.Clear();
            foreach (var task in _toDoList.GetAllTasks()) 
            {
                TasksListBox.Items.Add(task);
            }
        }
        /// <summary>
        /// Tar bort valt todo-item från listan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(Object sender, RoutedEventArgs e) 
        {
            if (TasksListBox.SelectedIndex >= 0) 
            {
                _toDoList.RemoveTask(TasksListBox.SelectedIndex);
                UpdateTaskList();
            }
        }
    }
}