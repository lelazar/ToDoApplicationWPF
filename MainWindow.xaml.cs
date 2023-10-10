using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateItemCount()
        {
            ItemCountLabel.Content = ToDoListBox.Items.Count.ToString();  // Update ItemCountLabel
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewItemTextBox.Text == "")
            {
                MessageBox.Show("You did not specify a task!");
                return;
            }

            ToDoListBox.Items.Add(NewItemTextBox.Text);
            NewItemTextBox.Clear();
            UpdateItemCount();

            // Animate AddButton
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.5,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true
            };
            AddButton.BeginAnimation(OpacityProperty, animation);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Task completed!");
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // SaveFileDialog instantiating and set for saving text files
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = ".txt";

            // Show save file dialog box and check if user clicked the save button
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                // The chosen file path
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Writing the items of the listbox to the file and show a message box if it was successful
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var item in ToDoListBox.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                    MessageBox.Show("To-Do List successfully exported!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;  // The sender is a Button
            StackPanel parent = (StackPanel)button.Parent;  // Parent of the Button is a StackPanel
            CheckBox checkBox = (CheckBox)parent.Children[0];  // First of the StackPanel's children is a CheckBox

            ToDoListBox.Items.Remove(checkBox.Content);
            UpdateItemCount();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoListBox.Items.Count == 0)
            {
                MessageBox.Show("No data to be sorted!");
                return;
            }

            var sortedList = ToDoListBox.Items.Cast<string>().OrderBy(item => item).ToList();
            ToDoListBox.Items.Clear();
            foreach (var item in sortedList)
            {
                ToDoListBox.Items.Add(item);
            }
        }
    }
}
