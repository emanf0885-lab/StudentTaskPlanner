using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StudentTaskPlanner.BusinessLogic;
using StudentTaskModel = StudentTaskPlanner.Models.Task;

namespace StudentTaskPlanner.Presentation
{
    public class MainForm : Form
    {
        private Panel sidebarPanel = new Panel();
        private Panel topPanel = new Panel();
        private Panel contentPanel = new Panel();

        private Label logoLabel = new Label();
        private Label logoSubLabel = new Label();

        private Button dashboardButton = new Button();
        private Button addTaskButton = new Button();
        private Button viewTasksButton = new Button();
        private Button studyScheduleButton = new Button();

        private Label welcomeLabel = new Label();
        private Label welcomeSubLabel = new Label();
        private Label dateLabel = new Label();

        private Label totalNumberLabel = new Label();
        private Label pendingNumberLabel = new Label();
        private Label completedNumberLabel = new Label();

        private Label progressNumberLabel = new Label();
        private Label progressInfoLabel = new Label();
        private ProgressBar progressBar = new ProgressBar();

        private DataGridView recentTasksGrid =
            new DataGridView();

        private TaskManager taskManager;

        public MainForm()
        {
            taskManager = new TaskManager();

            CreateInterface();

            UpdateDashboard();
        }

        // =========================================================
        // MAIN INTERFACE
        // =========================================================

        private void CreateInterface()
        {
            this.Text =
                "Student Task & Study Planner";

            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.Size =
                new Size(
                    1250,
                    780
                );

            this.MinimumSize =
                new Size(
                    1050,
                    680
                );

            this.BackColor =
                Color.FromArgb(
                    245,
                    247,
                    250
                );

            this.FormBorderStyle =
                FormBorderStyle.Sizable;

            this.MaximizeBox = true;

            this.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            CreateSidebar();
            CreateTopPanel();
            CreateContent();

            this.Controls.Add(
                contentPanel
            );

            this.Controls.Add(
                topPanel
            );

            this.Controls.Add(
                sidebarPanel
            );
        }

        // =========================================================
        // SIDEBAR
        // =========================================================

        private void CreateSidebar()
        {
            sidebarPanel.BackColor =
                Color.FromArgb(
                    18,
                    27,
                    41
                );

            sidebarPanel.Dock =
                DockStyle.Left;

            sidebarPanel.Width =
                245;

            // -----------------------------------------------------
            // LOGO
            // -----------------------------------------------------

            logoLabel.Text =
                "STUDY";

            logoLabel.Font =
                new Font(
                    "Segoe UI",
                    25,
                    FontStyle.Bold
                );

            logoLabel.ForeColor =
                Color.White;

            logoLabel.AutoSize = true;

            logoLabel.Location =
                new Point(
                    32,
                    30
                );

            logoSubLabel.Text =
                "STUDENT PLANNER";

            logoSubLabel.Font =
                new Font(
                    "Segoe UI",
                    8,
                    FontStyle.Bold
                );

            logoSubLabel.ForeColor =
                Color.FromArgb(
                    148,
                    163,
                    184
                );

            logoSubLabel.AutoSize = true;

            logoSubLabel.Location =
                new Point(
                    35,
                    70
                );

            // -----------------------------------------------------
            // MENU BUTTONS
            // -----------------------------------------------------

            dashboardButton.Text =
                "▣    Dashboard";

            StyleMenuButton(
                dashboardButton
            );

            dashboardButton.Location =
                new Point(
                    18,
                    135
                );

            dashboardButton.BackColor =
                Color.FromArgb(
                    37,
                    99,
                    235
                );

            addTaskButton.Text =
                "+    Add Task";

            StyleMenuButton(
                addTaskButton
            );

            addTaskButton.Location =
                new Point(
                    18,
                    190
                );

            addTaskButton.Click +=
                AddTaskButton_Click;

            viewTasksButton.Text =
                "☷    View Tasks";

            StyleMenuButton(
                viewTasksButton
            );

            viewTasksButton.Location =
                new Point(
                    18,
                    245
                );

            viewTasksButton.Click +=
                ViewTasksButton_Click;

            studyScheduleButton.Text =
                "▣    Study Schedule";

            StyleMenuButton(
                studyScheduleButton
            );

            studyScheduleButton.Location =
                new Point(
                    18,
                    300
                );

            studyScheduleButton.Click +=
                StudyScheduleButton_Click;

            // -----------------------------------------------------
            // SIDEBAR SEPARATOR
            // -----------------------------------------------------

            Panel separator =
                new Panel();

            separator.BackColor =
                Color.FromArgb(
                    51,
                    65,
                    85
                );

            separator.Location =
                new Point(
                    30,
                    375
                );

            separator.Size =
                new Size(
                    180,
                    1
                );

            // -----------------------------------------------------
            // PRODUCTIVITY AREA
            // -----------------------------------------------------

            Label productivityTitle =
                new Label();

            productivityTitle.Text =
                "PRODUCTIVITY";

            productivityTitle.Font =
                new Font(
                    "Segoe UI",
                    8,
                    FontStyle.Bold
                );

            productivityTitle.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            productivityTitle.AutoSize = true;

            productivityTitle.Location =
                new Point(
                    35,
                    405
                );

            Label productivityText =
                new Label();

            productivityText.Text =
                "Plan your tasks\r\n" +
                "Track your progress\r\n" +
                "Stay organized";

            productivityText.Font =
                new Font(
                    "Segoe UI",
                    9
                );

            productivityText.ForeColor =
                Color.FromArgb(
                    148,
                    163,
                    184
                );

            productivityText.AutoSize = true;

            productivityText.Location =
                new Point(
                    35,
                    430
                );

            // -----------------------------------------------------
            // BOTTOM SIDEBAR TEXT
            // -----------------------------------------------------

            Label bottomLabel =
                new Label();

            bottomLabel.Text =
                "Plan  •  Track  •  Achieve";

            bottomLabel.Font =
                new Font(
                    "Segoe UI",
                    8
                );

            bottomLabel.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            bottomLabel.AutoSize = true;

            sidebarPanel.Resize +=
                delegate
                {
                    bottomLabel.Location =
                        new Point(
                            35,
                            sidebarPanel.ClientSize.Height - 40
                        );
                };

            bottomLabel.Location =
                new Point(
                    35,
                    700
                );

            // -----------------------------------------------------
            // ADD CONTROLS
            // -----------------------------------------------------

            sidebarPanel.Controls.Add(
                logoLabel
            );

            sidebarPanel.Controls.Add(
                logoSubLabel
            );

            sidebarPanel.Controls.Add(
                dashboardButton
            );

            sidebarPanel.Controls.Add(
                addTaskButton
            );

            sidebarPanel.Controls.Add(
                viewTasksButton
            );

            sidebarPanel.Controls.Add(
                studyScheduleButton
            );

            sidebarPanel.Controls.Add(
                separator
            );

            sidebarPanel.Controls.Add(
                productivityTitle
            );

            sidebarPanel.Controls.Add(
                productivityText
            );

            sidebarPanel.Controls.Add(
                bottomLabel
            );
        }

        private void StyleMenuButton(
            Button button)
        {
            button.Size =
                new Size(
                    209,
                    46
                );

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                0;

            button.BackColor =
                Color.FromArgb(
                    18,
                    27,
                    41
                );

            button.ForeColor =
                Color.FromArgb(
                    226,
                    232,
                    240
                );

            button.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            button.TextAlign =
                ContentAlignment.MiddleLeft;

            button.Padding =
                new Padding(
                    16,
                    0,
                    0,
                    0
                );

            button.Cursor =
                Cursors.Hand;
        }

        // =========================================================
        // TOP HEADER
        // =========================================================

        private void CreateTopPanel()
        {
            topPanel.BackColor =
                Color.White;

            topPanel.Dock =
                DockStyle.Top;

            topPanel.Height =
                125;

            // -----------------------------------------------------
            // WELCOME TITLE
            // -----------------------------------------------------

            welcomeLabel.Text =
                "Good day!";

            welcomeLabel.Font =
                new Font(
                    "Segoe UI",
                    23,
                    FontStyle.Bold
                );

            welcomeLabel.ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42
                );

            welcomeLabel.AutoSize = true;

            welcomeLabel.Location =
                new Point(
                    35,
                    23
                );

            // -----------------------------------------------------
            // SUBTITLE
            // -----------------------------------------------------

            welcomeSubLabel.Text =
                "Manage your academic tasks and stay on track.";

            welcomeSubLabel.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            welcomeSubLabel.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            welcomeSubLabel.AutoSize = true;

            welcomeSubLabel.Location =
                new Point(
                    38,
                    68
                );

            // -----------------------------------------------------
            // DATE
            // -----------------------------------------------------

            dateLabel.Text =
                DateTime.Now.ToString(
                    "dddd, dd MMMM yyyy"
                );

            dateLabel.Font =
                new Font(
                    "Segoe UI",
                    9
                );

            dateLabel.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            dateLabel.AutoSize = true;

            dateLabel.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            dateLabel.Location =
                new Point(
                    850,
                    73
                );

            // -----------------------------------------------------
            // QUICK ADD BUTTON
            // -----------------------------------------------------

            Button quickAddButton =
                new Button();

            quickAddButton.Text =
                "+  Add New Task";

            quickAddButton.Size =
                new Size(
                    160,
                    42
                );

            quickAddButton.BackColor =
                Color.FromArgb(
                    37,
                    99,
                    235
                );

            quickAddButton.ForeColor =
                Color.White;

            quickAddButton.FlatStyle =
                FlatStyle.Flat;

            quickAddButton.FlatAppearance.BorderSize =
                0;

            quickAddButton.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

            quickAddButton.Cursor =
                Cursors.Hand;

            quickAddButton.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            quickAddButton.Click +=
                AddTaskButton_Click;

            topPanel.Resize +=
                delegate
                {
                    quickAddButton.Location =
                        new Point(
                            topPanel.ClientSize.Width -
                            quickAddButton.Width -
                            35,
                            32
                        );

                    dateLabel.Location =
                        new Point(
                            topPanel.ClientSize.Width -
                            dateLabel.Width -
                            38,
                            78
                        );
                };

            quickAddButton.Location =
                new Point(
                    940,
                    32
                );

            topPanel.Controls.Add(
                welcomeLabel
            );

            topPanel.Controls.Add(
                welcomeSubLabel
            );

            topPanel.Controls.Add(
                dateLabel
            );

            topPanel.Controls.Add(
                quickAddButton
            );
        }

        // =========================================================
        // MAIN CONTENT
        // =========================================================

        private void CreateContent()
        {
            contentPanel.Dock =
                DockStyle.Fill;

            contentPanel.BackColor =
                Color.FromArgb(
                    245,
                    247,
                    250
                );

            contentPanel.Padding =
                new Padding(
                    30,
                    25,
                    30,
                    25
                );

            TableLayoutPanel mainLayout =
                new TableLayoutPanel();

            mainLayout.Dock =
                DockStyle.Fill;

            mainLayout.ColumnCount = 1;

            mainLayout.RowCount = 4;

            mainLayout.RowStyles.Add(
                new RowStyle(
                    SizeType.Absolute,
                    32
                )
            );

            mainLayout.RowStyles.Add(
                new RowStyle(
                    SizeType.Absolute,
                    145
                )
            );

            mainLayout.RowStyles.Add(
                new RowStyle(
                    SizeType.Absolute,
                    110
                )
            );

            mainLayout.RowStyles.Add(
                new RowStyle(
                    SizeType.Percent,
                    100
                )
            );

            // -----------------------------------------------------
            // OVERVIEW TITLE
            // -----------------------------------------------------

            Label overviewLabel =
                new Label();

            overviewLabel.Text =
                "Overview";

            overviewLabel.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold
                );

            overviewLabel.ForeColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            overviewLabel.Dock =
                DockStyle.Fill;

            overviewLabel.TextAlign =
                ContentAlignment.MiddleLeft;

            // -----------------------------------------------------
            // SECTIONS
            // -----------------------------------------------------

            Panel statisticsPanel =
                CreateStatisticsSection();

            Panel progressPanel =
                CreateProgressSection();

            Panel recentPanel =
                CreateRecentTasksPanel();

            mainLayout.Controls.Add(
                overviewLabel,
                0,
                0
            );

            mainLayout.Controls.Add(
                statisticsPanel,
                0,
                1
            );

            mainLayout.Controls.Add(
                progressPanel,
                0,
                2
            );

            mainLayout.Controls.Add(
                recentPanel,
                0,
                3
            );

            contentPanel.Controls.Add(
                mainLayout
            );
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        private Panel CreateStatisticsSection()
        {
            Panel panel =
                new Panel();

            panel.Dock =
                DockStyle.Fill;

            TableLayoutPanel cards =
                new TableLayoutPanel();

            cards.Dock =
                DockStyle.Fill;

            cards.ColumnCount = 3;

            cards.RowCount = 1;

            cards.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.33f
                )
            );

            cards.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.33f
                )
            );

            cards.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.34f
                )
            );

            Panel totalCard =
                CreateStatisticsCard(
                    "TOTAL TASKS",
                    "0",
                    "Tasks",
                    Color.FromArgb(
                        37,
                        99,
                        235
                    ),
                    out totalNumberLabel
                );

            Panel pendingCard =
                CreateStatisticsCard(
                    "PENDING",
                    "0",
                    "To complete",
                    Color.FromArgb(
                        245,
                        158,
                        11
                    ),
                    out pendingNumberLabel
                );

            Panel completedCard =
                CreateStatisticsCard(
                    "COMPLETED",
                    "0",
                    "Finished",
                    Color.FromArgb(
                        16,
                        185,
                        129
                    ),
                    out completedNumberLabel
                );

            cards.Controls.Add(
                totalCard,
                0,
                0
            );

            cards.Controls.Add(
                pendingCard,
                1,
                0
            );

            cards.Controls.Add(
                completedCard,
                2,
                0
            );

            panel.Controls.Add(
                cards
            );

            return panel;
        }

        private Panel CreateStatisticsCard(
            string title,
            string number,
            string unit,
            Color accentColor,
            out Label numberLabel)
        {
            Panel card =
                new Panel();

            card.BackColor =
                Color.White;

            card.Dock =
                DockStyle.Fill;

            card.Margin =
                new Padding(
                    0,
                    0,
                    12,
                    10
                );

            // Left accent
            Panel accent =
                new Panel();

            accent.BackColor =
                accentColor;

            accent.Dock =
                DockStyle.Left;

            accent.Width = 5;

            // Title
            Label titleLabel =
                new Label();

            titleLabel.Text =
                title;

            titleLabel.Font =
                new Font(
                    "Segoe UI",
                    8,
                    FontStyle.Bold
                );

            titleLabel.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            titleLabel.AutoSize = true;

            titleLabel.Location =
                new Point(
                    22,
                    18
                );

            // Number
            numberLabel =
                new Label();

            numberLabel.Text =
                number;

            numberLabel.Font =
                new Font(
                    "Segoe UI",
                    29,
                    FontStyle.Bold
                );

            numberLabel.ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42
                );

            numberLabel.AutoSize = true;

            numberLabel.Location =
                new Point(
                    20,
                    42
                );

            // Unit
            Label unitLabel =
                new Label();

            unitLabel.Text =
                unit;

            unitLabel.Font =
                new Font(
                    "Segoe UI",
                    8
                );

            unitLabel.ForeColor =
                Color.FromArgb(
                    148,
                    163,
                    184
                );

            unitLabel.AutoSize = true;

            unitLabel.Location =
                new Point(
                    72,
                    67
                );

            card.Controls.Add(
                accent
            );

            card.Controls.Add(
                titleLabel
            );

            card.Controls.Add(
                numberLabel
            );

            card.Controls.Add(
                unitLabel
            );

            return card;
        }

        // =========================================================
        // PROGRESS
        // =========================================================

        private Panel CreateProgressSection()
        {
            Panel panel =
                new Panel();

            panel.BackColor =
                Color.White;

            panel.Dock =
                DockStyle.Fill;

            // -----------------------------------------------------
            // TITLE
            // -----------------------------------------------------

            Label title =
                new Label();

            title.Text =
                "Task Completion";

            title.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            title.ForeColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            title.AutoSize = true;

            title.Location =
                new Point(
                    20,
                    16
                );

            // -----------------------------------------------------
            // INFORMATION TEXT
            // -----------------------------------------------------

            progressInfoLabel =
                new Label();

            progressInfoLabel.Text =
                "0 of 0 tasks completed";

            progressInfoLabel.Font =
                new Font(
                    "Segoe UI",
                    8
                );

            progressInfoLabel.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            progressInfoLabel.AutoSize = true;

            progressInfoLabel.Location =
                new Point(
                    20,
                    43
                );

            // -----------------------------------------------------
            // PERCENTAGE
            // -----------------------------------------------------

            progressNumberLabel =
                new Label();

            progressNumberLabel.Text =
                "0%";

            progressNumberLabel.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            progressNumberLabel.ForeColor =
                Color.FromArgb(
                    37,
                    99,
                    235
                );

            progressNumberLabel.AutoSize = true;

            progressNumberLabel.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            progressNumberLabel.Location =
                new Point(
                    900,
                    16
                );

            // -----------------------------------------------------
            // PROGRESS BAR
            // -----------------------------------------------------

            progressBar =
                new ProgressBar();

            progressBar.Minimum = 0;

            progressBar.Maximum = 100;

            progressBar.Value = 0;

            progressBar.Style =
                ProgressBarStyle.Continuous;

            progressBar.Height =
                14;

            progressBar.Location =
                new Point(
                    20,
                    68
                );

            progressBar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            progressBar.Width =
                800;

            panel.Resize +=
                delegate
                {
                    progressBar.Width =
                        panel.ClientSize.Width - 40;

                    progressNumberLabel.Location =
                        new Point(
                            panel.ClientSize.Width -
                            progressNumberLabel.Width -
                            20,
                            16
                        );
                };

            panel.Controls.Add(
                title
            );

            panel.Controls.Add(
                progressInfoLabel
            );

            panel.Controls.Add(
                progressNumberLabel
            );

            panel.Controls.Add(
                progressBar
            );

            return panel;
        }

        // =========================================================
        // RECENT TASKS
        // =========================================================

        private Panel CreateRecentTasksPanel()
        {
            Panel panel =
                new Panel();

            panel.BackColor =
                Color.White;

            panel.Dock =
                DockStyle.Fill;

            // -----------------------------------------------------
            // TITLE
            // -----------------------------------------------------

            Label title =
                new Label();

            title.Text =
                "Recent Tasks";

            title.Font =
                new Font(
                    "Segoe UI",
                    15,
                    FontStyle.Bold
                );

            title.ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42
                );

            title.AutoSize = true;

            title.Location =
                new Point(
                    20,
                    15
                );

            // -----------------------------------------------------
            // SUBTITLE
            // -----------------------------------------------------

            Label subtitle =
                new Label();

            subtitle.Text =
                "Your latest academic activities";

            subtitle.Font =
                new Font(
                    "Segoe UI",
                    8
                );

            subtitle.ForeColor =
                Color.FromArgb(
                    100,
                    116,
                    139
                );

            subtitle.AutoSize = true;

            subtitle.Location =
                new Point(
                    22,
                    43
                );

            // -----------------------------------------------------
            // TABLE
            // -----------------------------------------------------

            CreateRecentTasksGrid();

            recentTasksGrid.Location =
                new Point(
                    20,
                    72
                );

            recentTasksGrid.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            recentTasksGrid.Width =
                700;

            recentTasksGrid.Height =
                250;

            panel.Resize +=
                delegate
                {
                    recentTasksGrid.Width =
                        panel.ClientSize.Width - 40;

                    recentTasksGrid.Height =
                        panel.ClientSize.Height - 82;
                };

            panel.Controls.Add(
                title
            );

            panel.Controls.Add(
                subtitle
            );

            panel.Controls.Add(
                recentTasksGrid
            );

            return panel;
        }

        // =========================================================
        // TASK TABLE
        // =========================================================

        private void CreateRecentTasksGrid()
        {
            recentTasksGrid.BackgroundColor =
                Color.White;

            recentTasksGrid.BorderStyle =
                BorderStyle.FixedSingle;

            recentTasksGrid.AllowUserToAddRows =
                false;

            recentTasksGrid.AllowUserToDeleteRows =
                false;

            recentTasksGrid.AllowUserToResizeRows =
                false;

            recentTasksGrid.ReadOnly =
                true;

            recentTasksGrid.RowHeadersVisible =
                false;

            recentTasksGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            recentTasksGrid.MultiSelect =
                false;

            recentTasksGrid.AutoGenerateColumns =
                false;

            recentTasksGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            recentTasksGrid.EnableHeadersVisualStyles =
                false;

            // -----------------------------------------------------
            // HEADER
            // -----------------------------------------------------

            recentTasksGrid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            recentTasksGrid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            recentTasksGrid.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

            recentTasksGrid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            recentTasksGrid.ColumnHeadersHeight =
                38;

            // -----------------------------------------------------
            // CELLS
            // -----------------------------------------------------

            recentTasksGrid.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9
                );

            recentTasksGrid.DefaultCellStyle.ForeColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            recentTasksGrid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    219,
                    234,
                    254
                );

            recentTasksGrid.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42
                );

            recentTasksGrid.RowTemplate.Height =
                36;

            // -----------------------------------------------------
            // COLUMNS
            // -----------------------------------------------------

            DataGridViewTextBoxColumn titleColumn =
                new DataGridViewTextBoxColumn();

            titleColumn.Name =
                "TitleColumn";

            titleColumn.HeaderText =
                "Task";

            titleColumn.DataPropertyName =
                "Title";

            titleColumn.FillWeight =
                35;

            DataGridViewTextBoxColumn dueDateColumn =
                new DataGridViewTextBoxColumn();

            dueDateColumn.Name =
                "DueDateColumn";

            dueDateColumn.HeaderText =
                "Due Date";

            dueDateColumn.DataPropertyName =
                "DueDate";

            dueDateColumn.DefaultCellStyle.Format =
                "dd-MMM-yyyy";

            dueDateColumn.FillWeight =
                20;

            DataGridViewTextBoxColumn priorityColumn =
                new DataGridViewTextBoxColumn();

            priorityColumn.Name =
                "PriorityColumn";

            priorityColumn.HeaderText =
                "Priority";

            priorityColumn.DataPropertyName =
                "Priority";

            priorityColumn.FillWeight =
                20;

            DataGridViewTextBoxColumn statusColumn =
                new DataGridViewTextBoxColumn();

            statusColumn.Name =
                "StatusColumn";

            statusColumn.HeaderText =
                "Status";

            statusColumn.DataPropertyName =
                "Status";

            statusColumn.FillWeight =
                25;

            recentTasksGrid.Columns.Add(
                titleColumn
            );

            recentTasksGrid.Columns.Add(
                dueDateColumn
            );

            recentTasksGrid.Columns.Add(
                priorityColumn
            );

            recentTasksGrid.Columns.Add(
                statusColumn
            );
        }

        // =========================================================
        // ADD TASK
        // =========================================================

        private void AddTaskButton_Click(
            object? sender,
            EventArgs e)
        {
            using (
                AddTaskForm addTaskForm =
                new AddTaskForm()
            )
            {
                DialogResult result =
                    addTaskForm.ShowDialog(
                        this
                    );

                if (
                    result ==
                    DialogResult.OK
                )
                {
                    UpdateDashboard();
                }
            }
        }

        // =========================================================
        // VIEW TASKS
        // =========================================================

        private void ViewTasksButton_Click(
            object? sender,
            EventArgs e)
        {
            using (
                ViewTasksForm viewTasksForm =
                new ViewTasksForm()
            )
            {
                viewTasksForm.ShowDialog(
                    this
                );
            }

            UpdateDashboard();
        }

        // =========================================================
        // STUDY SCHEDULE
        // =========================================================

        private void StudyScheduleButton_Click(
            object? sender,
            EventArgs e)
        {
            using (
                StudyScheduleForm studyScheduleForm =
                new StudyScheduleForm()
            )
            {
                studyScheduleForm.ShowDialog(
                    this
                );
            }
        }

        // =========================================================
        // UPDATE DASHBOARD
        // =========================================================

        private void UpdateDashboard()
        {
            try
            {
                List<StudentTaskModel> tasks =
                    taskManager.GetAllTasks();

                int totalTasks =
                    tasks.Count;

                int pendingTasks = 0;

                int completedTasks = 0;

                for (
                    int i = 0;
                    i < tasks.Count;
                    i++
                )
                {
                    if (
                        tasks[i].Status ==
                        "Completed"
                    )
                    {
                        completedTasks++;
                    }
                    else
                    {
                        pendingTasks++;
                    }
                }

                totalNumberLabel.Text =
                    totalTasks.ToString();

                pendingNumberLabel.Text =
                    pendingTasks.ToString();

                completedNumberLabel.Text =
                    completedTasks.ToString();

                int completionPercentage = 0;

                if (totalTasks > 0)
                {
                    completionPercentage =
                        (
                            completedTasks * 100
                        )
                        /
                        totalTasks;
                }

                progressNumberLabel.Text =
                    completionPercentage.ToString()
                    + "%";

                progressInfoLabel.Text =
                    completedTasks.ToString()
                    + " of "
                    + totalTasks.ToString()
                    + " tasks completed";

                progressBar.Value =
                    completionPercentage;

                recentTasksGrid.DataSource =
                    null;

                recentTasksGrid.DataSource =
                    tasks;
            }
            catch (Exception)
            {
                totalNumberLabel.Text =
                    "0";

                pendingNumberLabel.Text =
                    "0";

                completedNumberLabel.Text =
                    "0";

                progressNumberLabel.Text =
                    "0%";

                progressInfoLabel.Text =
                    "0 of 0 tasks completed";

                progressBar.Value =
                    0;

                recentTasksGrid.DataSource =
                    null;
            }
        }
    }
}