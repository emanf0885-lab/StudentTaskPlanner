using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentTaskPlanner.Presentation
{
    public class StudyScheduleForm : Form
    {
        private ComboBox dayComboBox =
            new ComboBox();

        private TextBox subjectTextBox =
            new TextBox();

        private TextBox topicTextBox =
            new TextBox();

        private DateTimePicker startTimePicker =
            new DateTimePicker();

        private DateTimePicker endTimePicker =
            new DateTimePicker();

        private Button addButton =
            new Button();

        private Button clearButton =
            new Button();

        private DataGridView scheduleGrid =
            new DataGridView();

        public StudyScheduleForm()
        {
            CreateInterface();
        }

        private void CreateInterface()
        {
            this.Text =
                "Study Schedule";

            this.Size =
                new Size(1050, 680);

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.MinimumSize =
                new Size(900, 600);

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
                "Study Schedule";

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
                "Organize your weekly study sessions.";

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
            // DAY
            // =====================================================

            Label dayLabel =
                CreateFieldLabel("Day");

            dayLabel.Location =
                new Point(30, 105);

            dayComboBox.Location =
                new Point(30, 130);

            dayComboBox.Size =
                new Size(150, 35);

            dayComboBox.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            dayComboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            dayComboBox.Items.Add("Monday");
            dayComboBox.Items.Add("Tuesday");
            dayComboBox.Items.Add("Wednesday");
            dayComboBox.Items.Add("Thursday");
            dayComboBox.Items.Add("Friday");
            dayComboBox.Items.Add("Saturday");
            dayComboBox.Items.Add("Sunday");

            dayComboBox.SelectedIndex = 0;

            // =====================================================
            // SUBJECT
            // =====================================================

            Label subjectLabel =
                CreateFieldLabel("Subject");

            subjectLabel.Location =
                new Point(200, 105);

            subjectTextBox.Location =
                new Point(200, 130);

            subjectTextBox.Size =
                new Size(190, 35);

            subjectTextBox.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            // =====================================================
            // TOPIC
            // =====================================================

            Label topicLabel =
                CreateFieldLabel("Study Topic");

            topicLabel.Location =
                new Point(410, 105);

            topicTextBox.Location =
                new Point(410, 130);

            topicTextBox.Size =
                new Size(220, 35);

            topicTextBox.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            // =====================================================
            // START TIME
            // =====================================================

            Label startLabel =
                CreateFieldLabel("Start Time");

            startLabel.Location =
                new Point(650, 105);

            startTimePicker.Location =
                new Point(650, 130);

            startTimePicker.Size =
                new Size(130, 35);

            startTimePicker.Font =
                new Font(
                    "Segoe UI",
                    9
                );

            startTimePicker.Format =
                DateTimePickerFormat.Custom;

            startTimePicker.CustomFormat =
                "hh:mm tt";

            startTimePicker.ShowUpDown = true;

            // =====================================================
            // END TIME
            // =====================================================

            Label endLabel =
                CreateFieldLabel("End Time");

            endLabel.Location =
                new Point(800, 105);

            endTimePicker.Location =
                new Point(800, 130);

            endTimePicker.Size =
                new Size(130, 35);

            endTimePicker.Font =
                new Font(
                    "Segoe UI",
                    9
                );

            endTimePicker.Format =
                DateTimePickerFormat.Custom;

            endTimePicker.CustomFormat =
                "hh:mm tt";

            endTimePicker.ShowUpDown = true;

            // =====================================================
            // ADD BUTTON
            // =====================================================

            addButton.Text =
                "Add Session";

            StyleButton(
                addButton,
                Color.FromArgb(
                    37,
                    99,
                    235
                ),
                Color.White
            );

            addButton.Location =
                new Point(30, 185);

            addButton.Click +=
                AddButton_Click;

            // =====================================================
            // CLEAR BUTTON
            // =====================================================

            clearButton.Text =
                "Clear Schedule";

            StyleButton(
                clearButton,
                Color.White,
                Color.FromArgb(
                    51,
                    65,
                    85
                )
            );

            clearButton.Location =
                new Point(165, 185);

            clearButton.Click +=
                ClearButton_Click;

            // =====================================================
            // TABLE
            // =====================================================

            CreateScheduleGrid();

            // =====================================================
            // ADD CONTROLS
            // =====================================================

            this.Controls.Add(
                headingLabel
            );

            this.Controls.Add(
                subtitleLabel
            );

            this.Controls.Add(
                dayLabel
            );

            this.Controls.Add(
                dayComboBox
            );

            this.Controls.Add(
                subjectLabel
            );

            this.Controls.Add(
                subjectTextBox
            );

            this.Controls.Add(
                topicLabel
            );

            this.Controls.Add(
                topicTextBox
            );

            this.Controls.Add(
                startLabel
            );

            this.Controls.Add(
                startTimePicker
            );

            this.Controls.Add(
                endLabel
            );

            this.Controls.Add(
                endTimePicker
            );

            this.Controls.Add(
                addButton
            );

            this.Controls.Add(
                clearButton
            );

            this.Controls.Add(
                scheduleGrid
            );
        }

        // =========================================================
        // FIELD LABEL
        // =========================================================

        private Label CreateFieldLabel(
            string text)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

            label.ForeColor =
                Color.FromArgb(
                    51,
                    65,
                    85
                );

            label.AutoSize = true;

            return label;
        }

        // =========================================================
        // BUTTON STYLE
        // =========================================================

        private void StyleButton(
            Button button,
            Color backgroundColor,
            Color textColor)
        {
            button.Size =
                new Size(
                    125,
                    38
                );

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
        // GRID
        // =========================================================

        private void CreateScheduleGrid()
        {
            scheduleGrid.Location =
                new Point(30, 245);

            scheduleGrid.Size =
                new Size(950, 350);

            scheduleGrid.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            scheduleGrid.BackgroundColor =
                Color.White;

            scheduleGrid.BorderStyle =
                BorderStyle.None;

            scheduleGrid.AllowUserToAddRows =
                false;

            scheduleGrid.AllowUserToDeleteRows =
                false;

            scheduleGrid.ReadOnly =
                true;

            scheduleGrid.RowHeadersVisible =
                false;

            scheduleGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            scheduleGrid.MultiSelect =
                false;

            scheduleGrid.EnableHeadersVisualStyles =
                false;

            scheduleGrid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            scheduleGrid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            scheduleGrid.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

            scheduleGrid.ColumnHeadersHeight =
                42;

            scheduleGrid.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9
                );

            scheduleGrid.DefaultCellStyle.ForeColor =
                Color.FromArgb(
                    30,
                    41,
                    59
                );

            scheduleGrid.RowTemplate.Height =
                40;

            scheduleGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            scheduleGrid.Columns.Add(
                "Day",
                "Day"
            );

            scheduleGrid.Columns.Add(
                "Subject",
                "Subject"
            );

            scheduleGrid.Columns.Add(
                "Topic",
                "Study Topic"
            );

            scheduleGrid.Columns.Add(
                "Start",
                "Start Time"
            );

            scheduleGrid.Columns.Add(
                "End",
                "End Time"
            );
        }

        // =====================================================
        // ADD SESSION
        // =====================================================

        private void AddButton_Click(
            object? sender,
            EventArgs e)
        {
            string subject =
                subjectTextBox.Text.Trim();

            string topic =
                topicTextBox.Text.Trim();

            if (subject == "")
            {
                MessageBox.Show(
                    "Please enter the subject.",
                    "Missing Subject",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                subjectTextBox.Focus();

                return;
            }

            if (topic == "")
            {
                MessageBox.Show(
                    "Please enter the study topic.",
                    "Missing Topic",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                topicTextBox.Focus();

                return;
            }

            if (endTimePicker.Value.TimeOfDay <=
                startTimePicker.Value.TimeOfDay)
            {
                MessageBox.Show(
                    "End time must be later than start time.",
                    "Invalid Time",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            scheduleGrid.Rows.Add(
                dayComboBox.SelectedItem?.ToString(),
                subject,
                topic,
                startTimePicker.Value.ToString(
                    "hh:mm tt"
                ),
                endTimePicker.Value.ToString(
                    "hh:mm tt"
                )
            );

            subjectTextBox.Clear();

            topicTextBox.Clear();

            subjectTextBox.Focus();
        }

        // =====================================================
        // CLEAR
        // =====================================================

        private void ClearButton_Click(
            object? sender,
            EventArgs e)
        {
            if (scheduleGrid.Rows.Count == 0)
            {
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Clear all study sessions?",
                    "Clear Schedule",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result ==
                DialogResult.Yes)
            {
                scheduleGrid.Rows.Clear();
            }
        }
    }
}