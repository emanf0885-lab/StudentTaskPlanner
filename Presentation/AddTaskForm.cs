using System;
using System.Drawing;
using System.Windows.Forms;
using StudentTaskPlanner.BusinessLogic;
using StudentTaskModel = StudentTaskPlanner.Models.Task;

namespace StudentTaskPlanner.Presentation
{
    public class AddTaskForm : Form
    {
        private TextBox titleTextBox = new TextBox();
        private TextBox descriptionTextBox = new TextBox();

        private DateTimePicker dueDatePicker =
            new DateTimePicker();

        private ComboBox priorityComboBox =
            new ComboBox();

        private Button saveButton =
            new Button();

        private Button cancelButton =
            new Button();

        private TaskManager taskManager;

        public AddTaskForm()
        {
            taskManager = new TaskManager();

            CreateInterface();
        }

        private void CreateInterface()
        {
            this.Text = "Add New Task";

            this.Size = new Size(
                560,
                620
            );

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.BackColor =
                Color.FromArgb(245, 247, 250);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;

            this.MinimizeBox = false;

            // =====================================================
            // TITLE
            // =====================================================

            Label headingLabel = new Label();

            headingLabel.Text =
                "Create New Task";

            headingLabel.Font = new Font(
                "Segoe UI",
                20,
                FontStyle.Bold
            );

            headingLabel.ForeColor =
                Color.FromArgb(15, 23, 42);

            headingLabel.AutoSize = true;

            headingLabel.Location =
                new Point(40, 30);

            // =====================================================
            // SUBTITLE
            // =====================================================

            Label subtitleLabel = new Label();

            subtitleLabel.Text =
                "Add an academic task to your planner.";

            subtitleLabel.Font = new Font(
                "Segoe UI",
                9.5f
            );

            subtitleLabel.ForeColor =
                Color.FromArgb(100, 116, 139);

            subtitleLabel.AutoSize = true;

            subtitleLabel.Location =
                new Point(43, 70);

            // =====================================================
            // TITLE FIELD
            // =====================================================

            Label titleLabel = CreateFieldLabel(
                "Task Title"
            );

            titleLabel.Location =
                new Point(40, 115);

            titleTextBox.Location =
                new Point(40, 140);

            titleTextBox.Size =
                new Size(450, 35);

            titleTextBox.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            // =====================================================
            // DESCRIPTION FIELD
            // =====================================================

            Label descriptionLabel = CreateFieldLabel(
                "Description"
            );

            descriptionLabel.Location =
                new Point(40, 190);

            descriptionTextBox.Location =
                new Point(40, 215);

            descriptionTextBox.Size =
                new Size(450, 80);

            descriptionTextBox.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            descriptionTextBox.Multiline = true;

            descriptionTextBox.ScrollBars =
                ScrollBars.Vertical;

            // =====================================================
            // DUE DATE
            // =====================================================

            Label dueDateLabel = CreateFieldLabel(
                "Due Date"
            );

            dueDateLabel.Location =
                new Point(40, 320);

            dueDatePicker.Location =
                new Point(40, 345);

            dueDatePicker.Size =
                new Size(450, 35);

            dueDatePicker.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            dueDatePicker.Format =
                DateTimePickerFormat.Short;

            dueDatePicker.MinDate =
                DateTime.Today;

            // =====================================================
            // PRIORITY
            // =====================================================

            Label priorityLabel = CreateFieldLabel(
                "Priority"
            );

            priorityLabel.Location =
                new Point(40, 400);

            priorityComboBox.Location =
                new Point(40, 425);

            priorityComboBox.Size =
                new Size(450, 35);

            priorityComboBox.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            priorityComboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            priorityComboBox.Items.Add("High");
            priorityComboBox.Items.Add("Medium");
            priorityComboBox.Items.Add("Low");

            priorityComboBox.SelectedIndex = 1;

            // =====================================================
            // SAVE BUTTON
            // =====================================================

            saveButton.Text =
                "Save Task";

            saveButton.Size =
                new Size(135, 42);

            saveButton.Location =
                new Point(220, 490);

            saveButton.BackColor =
                Color.FromArgb(37, 99, 235);

            saveButton.ForeColor =
                Color.White;

            saveButton.FlatStyle =
                FlatStyle.Flat;

            saveButton.FlatAppearance.BorderSize =
                0;

            saveButton.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            saveButton.Cursor =
                Cursors.Hand;

            saveButton.Click += SaveButton_Click;

            // =====================================================
            // CANCEL BUTTON
            // =====================================================

            cancelButton.Text =
                "Cancel";

            cancelButton.Size =
                new Size(110, 42);

            cancelButton.Location =
                new Point(365, 490);

            cancelButton.BackColor =
                Color.White;

            cancelButton.ForeColor =
                Color.FromArgb(71, 85, 105);

            cancelButton.FlatStyle =
                FlatStyle.Flat;

            cancelButton.FlatAppearance.BorderColor =
                Color.FromArgb(203, 213, 225);

            cancelButton.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            cancelButton.Cursor =
                Cursors.Hand;

            cancelButton.Click += CancelButton_Click;

            // =====================================================
            // ADD CONTROLS
            // =====================================================

            this.Controls.Add(headingLabel);
            this.Controls.Add(subtitleLabel);

            this.Controls.Add(titleLabel);
            this.Controls.Add(titleTextBox);

            this.Controls.Add(descriptionLabel);
            this.Controls.Add(descriptionTextBox);

            this.Controls.Add(dueDateLabel);
            this.Controls.Add(dueDatePicker);

            this.Controls.Add(priorityLabel);
            this.Controls.Add(priorityComboBox);

            this.Controls.Add(saveButton);
            this.Controls.Add(cancelButton);

            this.AcceptButton =
                saveButton;

            this.CancelButton =
                cancelButton;
        }

        private Label CreateFieldLabel(
            string text)
        {
            Label label = new Label();

            label.Text = text;

            label.Font = new Font(
                "Segoe UI",
                9,
                FontStyle.Bold
            );

            label.ForeColor =
                Color.FromArgb(51, 65, 85);

            label.AutoSize = true;

            return label;
        }

        private void SaveButton_Click(
            object? sender,
            EventArgs e)
        {
            string title =
                titleTextBox.Text.Trim();

            string description =
                descriptionTextBox.Text.Trim();

            if (title == "")
            {
                MessageBox.Show(
                    "Please enter a task title.",
                    "Missing Title",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                titleTextBox.Focus();

                return;
            }

            StudentTaskModel newTask =
                new StudentTaskModel();

            newTask.Title = title;

            newTask.Description =
                description;

            newTask.DueDate =
                dueDatePicker.Value.Date;

            newTask.Priority =
                priorityComboBox.SelectedItem?
                .ToString() ?? "Medium";

            newTask.Status =
                "Pending";

            taskManager.AddTask(newTask);

            MessageBox.Show(
                "Task added successfully.",
                "Task Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.DialogResult =
                DialogResult.OK;

            this.Close();
        }

        private void CancelButton_Click(
            object? sender,
            EventArgs e)
        {
            this.DialogResult =
                DialogResult.Cancel;

            this.Close();
        }
    }
}