using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StudentTaskPlanner.BusinessLogic;
using StudentTaskModel = StudentTaskPlanner.Models.Task;

namespace StudentTaskPlanner.Presentation
{
    public class ViewTasksForm : Form
    {
        private TaskManager taskManager;

        private DataGridView tasksGrid =
            new DataGridView();

        private TextBox searchTextBox =
            new TextBox();

        private Button searchButton =
            new Button();

        private Button showAllButton =
            new Button();

        private Button sortButton =
            new Button();

        private Button completeButton =
            new Button();

        private Button deleteButton =
            new Button();

        public ViewTasksForm()
        {
            taskManager = new TaskManager();

            CreateInterface();

            LoadTasks();
        }

        private void CreateInterface()
        {
            this.Text = "View Tasks";

            this.Size =
                new Size(1050, 650);

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.MinimumSize =
                new Size(900, 550);

            this.BackColor =
                Color.FromArgb(
                    245,
                    247,
                    250
                );

            this.FormBorderStyle =
                FormBorderStyle.Sizable;

            this.MaximizeBox = true;

            // =====================================================
            // HEADER
            // =====================================================

            Label headingLabel =
                new Label();

            headingLabel.Text =
                "My Tasks";

            headingLabel.Font =
                new Font(
                    "Segoe UI",
                    21,
                    FontStyle.Bold
                );

            headingLabel.ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42
                );

            headingLabel.AutoSize = true;

            headingLabel.Location =
                new Point(30, 25);

            Label subtitleLabel =
                new Label();

            subtitleLabel.Text =
                "Search, sort and manage your academic tasks.";

            subtitleLabel.Font =
                new Font(
                    "Segoe UI",
                    9.5f
                );

            subtitleLabel.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            subtitleLabel.AutoSize = true;

            subtitleLabel.Location =
                new Point(33, 62);

            // =====================================================
            // SEARCH
            // =====================================================

            searchTextBox.Location =
                new Point(30, 105);

            searchTextBox.Size =
                new Size(300, 35);

            searchTextBox.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            searchTextBox.PlaceholderText =
                "Search by task title...";

            searchButton.Text =
                "Search";

            StyleActionButton(
                searchButton,
                Color.FromArgb(
                    37,
                    99,
                    235
                ),
                Color.White
            );

            searchButton.Location =
                new Point(345, 103);

            searchButton.Click +=
                SearchButton_Click;

            showAllButton.Text =
                "Show All";

            StyleActionButton(
                showAllButton,
                Color.White,
                Color.FromArgb(
                    51,
                    65,
                    85
                )
            );

            showAllButton.Location =
                new Point(435, 103);

            showAllButton.Click +=
                ShowAllButton_Click;

            // =====================================================
            // SORT
            // =====================================================

            sortButton.Text =
                "Sort by Due Date";

            StyleActionButton(
                sortButton,
                Color.White,
                Color.FromArgb(
                    51,
                    65,
                    85
                )
            );

            sortButton.Location =
                new Point(530, 103);

            sortButton.Click +=
                SortButton_Click;

            // =====================================================
            // TABLE
            // =====================================================

            CreateTasksGrid();

            // =====================================================
            // BOTTOM BUTTONS
            // =====================================================

            completeButton.Text =
                "Mark Complete";

            StyleActionButton(
                completeButton,
                Color.FromArgb(
                    16,
                    185,
                    129
                ),
                Color.White
            );

            completeButton.Location =
                new Point(30, 545);

            completeButton.Click +=
                CompleteButton_Click;

            deleteButton.Text =
                "Delete Task";

            StyleActionButton(
                deleteButton,
                Color.FromArgb(
                    220,
                    38,
                    38
                ),
                Color.White
            );

            deleteButton.Location =
                new Point(170, 545);

            deleteButton.Click +=
                DeleteButton_Click;

            this.Controls.Add(
                headingLabel
            );

            this.Controls.Add(
                subtitleLabel
            );

            this.Controls.Add(
                searchTextBox
            );

            this.Controls.Add(
                searchButton
            );

            this.Controls.Add(
                showAllButton
            );

            this.Controls.Add(
                sortButton
            );

            this.Controls.Add(
                tasksGrid
            );

            this.Controls.Add(
                completeButton
            );

            this.Controls.Add(
                deleteButton
            );
        }

        private void CreateTasksGrid()
        {
            tasksGrid.Location =
                new Point(30, 155);

            tasksGrid.Size =
                new Size(970, 370);

            tasksGrid.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            tasksGrid.BackgroundColor =
                Color.White;

            tasksGrid.BorderStyle =
                BorderStyle.None;

            tasksGrid.AllowUserToAddRows =
                false;

            tasksGrid.AllowUserToDeleteRows =
                false;

            tasksGrid.AllowUserToResizeRows =
                false;

            tasksGrid.ReadOnly =
                true;

            tasksGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            tasksGrid.MultiSelect =
                false;

            tasksGrid.AutoGenerateColumns =
                false;

            tasksGrid.RowHeadersVisible =
                false;

            tasksGrid.EnableHeadersVisualStyles =
                false;

            tasksGrid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            tasksGrid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            tasksGrid.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

            tasksGrid.ColumnHeadersHeight =
                42;

            tasksGrid.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9
                );

            tasksGrid.DefaultCellStyle.ForeColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            tasksGrid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    219,
                    234,
                    254
                );

            tasksGrid.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42
                );

            tasksGrid.RowTemplate.Height =
                40;

            // Title
            DataGridViewTextBoxColumn titleColumn =
                new DataGridViewTextBoxColumn();

            titleColumn.HeaderText =
                "Task";

            titleColumn.DataPropertyName =
                "Title";

            titleColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            titleColumn.FillWeight =
                25;

            // Description
            DataGridViewTextBoxColumn descriptionColumn =
                new DataGridViewTextBoxColumn();

            descriptionColumn.HeaderText =
                "Description";

            descriptionColumn.DataPropertyName =
                "Description";

            descriptionColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            descriptionColumn.FillWeight =
                30;

            // Due date
            DataGridViewTextBoxColumn dueDateColumn =
                new DataGridViewTextBoxColumn();

            dueDateColumn.HeaderText =
                "Due Date";

            dueDateColumn.DataPropertyName =
                "DueDate";

            dueDateColumn.DefaultCellStyle.Format =
                "dd-MMM-yyyy";

            dueDateColumn.Width =
                120;

            // Priority
            DataGridViewTextBoxColumn priorityColumn =
                new DataGridViewTextBoxColumn();

            priorityColumn.HeaderText =
                "Priority";

            priorityColumn.DataPropertyName =
                "Priority";

            priorityColumn.Width =
                100;

            // Status
            DataGridViewTextBoxColumn statusColumn =
                new DataGridViewTextBoxColumn();

            statusColumn.HeaderText =
                "Status";

            statusColumn.DataPropertyName =
                "Status";

            statusColumn.Width =
                110;

            tasksGrid.Columns.Add(
                titleColumn
            );

            tasksGrid.Columns.Add(
                descriptionColumn
            );

            tasksGrid.Columns.Add(
                dueDateColumn
            );

            tasksGrid.Columns.Add(
                priorityColumn
            );

            tasksGrid.Columns.Add(
                statusColumn
            );
        }

        private void StyleActionButton(
            Button button,
            Color backgroundColor,
            Color textColor)
        {
            button.Size =
                new Size(125, 38);

            button.BackColor =
                backgroundColor;

            button.ForeColor =
                textColor;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    203,
                    213,
                    225
                );

            button.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

            button.Cursor =
                Cursors.Hand;
        }

        // =========================================================
        // LOAD TASKS
        // =========================================================

        private void LoadTasks()
        {
            List<StudentTaskModel> tasks =
                taskManager.GetAllTasks();

            tasksGrid.DataSource = null;

            tasksGrid.DataSource =
                tasks;
        }

        // =========================================================
        // SEARCH
        // =========================================================

        private void SearchButton_Click(
            object? sender,
            EventArgs e)
        {
            string searchText =
                searchTextBox.Text.Trim();

            if (searchText == "")
            {
                LoadTasks();

                return;
            }

            List<StudentTaskModel> results =
                taskManager.SearchTasks(
                    searchText
                );

            tasksGrid.DataSource = null;

            tasksGrid.DataSource =
                results;
        }

        // =========================================================
        // SHOW ALL
        // =========================================================

        private void ShowAllButton_Click(
            object? sender,
            EventArgs e)
        {
            searchTextBox.Clear();

            LoadTasks();
        }

        // =========================================================
        // SORT
        // =========================================================

        private void SortButton_Click(
            object? sender,
            EventArgs e)
        {
            List<StudentTaskModel> sortedTasks =
                taskManager.SortByDueDate();

            tasksGrid.DataSource = null;

            tasksGrid.DataSource =
                sortedTasks;
        }

        // =========================================================
        // COMPLETE
        // =========================================================

        private void CompleteButton_Click(
            object? sender,
            EventArgs e)
        {
            string? title =
                GetSelectedTaskTitle();

            if (title == null)
            {
                MessageBox.Show(
                    "Please select a task first.",
                    "No Task Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            bool completed =
                taskManager.CompleteTask(
                    title
                );

            if (completed)
            {
                MessageBox.Show(
                    "Task marked as completed.",
                    "Task Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadTasks();
            }
        }

        // =========================================================
        // DELETE
        // =========================================================

        private void DeleteButton_Click(
            object? sender,
            EventArgs e)
        {
            string? title =
                GetSelectedTaskTitle();

            if (title == null)
            {
                MessageBox.Show(
                    "Please select a task first.",
                    "No Task Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete \"" +
                    title +
                    "\"?",
                    "Delete Task",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            bool deleted =
                taskManager.DeleteTask(
                    title
                );

            if (deleted)
            {
                MessageBox.Show(
                    "Task deleted successfully.",
                    "Task Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadTasks();
            }
        }

        // =========================================================
        // GET SELECTED TASK
        // =========================================================

        private string? GetSelectedTaskTitle()
        {
            if (tasksGrid.SelectedRows.Count == 0)
            {
                return null;
            }

            object? value =
                tasksGrid.SelectedRows[0]
                .Cells[0]
                .Value;

            if (value == null)
            {
                return null;
            }

            return value.ToString();
        }
    }
}