# To-Do List Application Documentation

## Overview

The To-Do List application is built using Windows Presentation Foundation (WPF). It is designed to help users manage their tasks with a simple and intuitive 
graphical user interface. The project covers the usage of various WPF controls like Textbox, Button, ListBox, and others. It also demonstrates the use of XAML 
for layout and C# for event handling and other logic.

## Features

1. **Add New Task**: Users can add a new task by typing it into a textbox and then clicking the "Add" button.
2. **Remove Task**: Each task comes with an 'X' button that allows users to remove it.
3. **Sort Tasks**: Users can sort the list of tasks alphabetically by clicking the "Sort" button.
4. **Task Counter**: Displays the number of tasks in the list.
5. **Task Status**: Each task comes with a checkbox to mark it as completed.
6. **Export Task List**: Users can export the list of tasks to a text file.
7. **Stylized Buttons**: Unified button styles and hover effects.
8. **Adjustable Font Size and Opacity**: Sliders for adjusting the ListBox font size and opacity.

## Code Structure

### MainWindow.xaml

Defines the GUI of the application, which includes a TextBox for entering new tasks, Buttons for adding, sorting, and exporting tasks, and a ListBox 
to display the tasks. It also contains Sliders to adjust the ListBox's font size and opacity.

### MainWindow.xaml.cs

Contains all the backend logic for the application.

Functions

1. **UpdateItemCount()**: Updates the task counter label to reflect the number of items in the list.
2. **AddButton_Click()**: Adds a new task to the ListBox and clears the TextBox. It also animates the Add button.
3. **CheckBox_Checked()**: Displays a message box when a task is marked as completed.
4. **ExportButton_Click()**: Exports the list of tasks to a .txt file.
5. **RemoveItemButton_Click()**: Removes a task from the ListBox.
6. **SortButton_Click()**: Sorts the tasks in the ListBox alphabetically.
