
namespace TestEmployees
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxSearchFlags = new System.Windows.Forms.ComboBox();
            this.txbSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.Fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEmploy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateUnemploy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxSearchValues = new System.Windows.Forms.ComboBox();
            this.cbxStatisticStatuses = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbIsUneployed = new System.Windows.Forms.CheckBox();
            this.txbStatisticsOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxSearchFlags
            // 
            this.cbxSearchFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchFlags.FormattingEnabled = true;
            this.cbxSearchFlags.Items.AddRange(new object[] {
            "Должность",
            "Отдел",
            "Статус",
            "Фамилия"});
            this.cbxSearchFlags.Location = new System.Drawing.Point(13, 13);
            this.cbxSearchFlags.Name = "cbxSearchFlags";
            this.cbxSearchFlags.Size = new System.Drawing.Size(204, 21);
            this.cbxSearchFlags.TabIndex = 0;
            this.cbxSearchFlags.SelectedIndexChanged += new System.EventHandler(this.cbxSearchFlags_SelectedIndexChanged);
            // 
            // txbSearchText
            // 
            this.txbSearchText.Location = new System.Drawing.Point(13, 40);
            this.txbSearchText.Name = "txbSearchText";
            this.txbSearchText.Size = new System.Drawing.Size(388, 20);
            this.txbSearchText.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(407, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 48);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvResult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fio,
            this.Status,
            this.Department,
            this.Position,
            this.DateEmploy,
            this.DateUnemploy});
            this.dgvResult.Location = new System.Drawing.Point(13, 66);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(970, 426);
            this.dgvResult.TabIndex = 4;
            this.dgvResult.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResult_ColumnHeaderMouseClick);
            // 
            // Fio
            // 
            this.Fio.DataPropertyName = "Fio";
            this.Fio.HeaderText = "ФИО";
            this.Fio.Name = "Fio";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Отдел";
            this.Department.Name = "Department";
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "Должность";
            this.Position.Name = "Position";
            // 
            // DateEmploy
            // 
            this.DateEmploy.DataPropertyName = "DateEmploy";
            this.DateEmploy.HeaderText = "Дата приема на работу";
            this.DateEmploy.Name = "DateEmploy";
            // 
            // DateUnemploy
            // 
            this.DateUnemploy.DataPropertyName = "DateUnemploy";
            this.DateUnemploy.HeaderText = "Дата увольнения";
            this.DateUnemploy.Name = "DateUnemploy";
            // 
            // cbxSearchValues
            // 
            this.cbxSearchValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchValues.FormattingEnabled = true;
            this.cbxSearchValues.Location = new System.Drawing.Point(223, 12);
            this.cbxSearchValues.Name = "cbxSearchValues";
            this.cbxSearchValues.Size = new System.Drawing.Size(178, 21);
            this.cbxSearchValues.TabIndex = 1;
            // 
            // cbxStatisticStatuses
            // 
            this.cbxStatisticStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatisticStatuses.FormattingEnabled = true;
            this.cbxStatisticStatuses.Location = new System.Drawing.Point(12, 549);
            this.cbxStatisticStatuses.Name = "cbxStatisticStatuses";
            this.cbxStatisticStatuses.Size = new System.Drawing.Size(163, 21);
            this.cbxStatisticStatuses.TabIndex = 5;
            this.cbxStatisticStatuses.SelectedIndexChanged += new System.EventHandler(this.cbxStatisticStatuses_SelectedIndexChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(181, 549);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(138, 20);
            this.dtpStartDate.TabIndex = 6;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(325, 549);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(127, 20);
            this.dtpEndDate.TabIndex = 7;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Статус";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 524);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Начальная дата выборки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Конечная дата выборки";
            // 
            // chbIsUneployed
            // 
            this.chbIsUneployed.AutoSize = true;
            this.chbIsUneployed.Location = new System.Drawing.Point(459, 549);
            this.chbIsUneployed.Name = "chbIsUneployed";
            this.chbIsUneployed.Size = new System.Drawing.Size(61, 17);
            this.chbIsUneployed.TabIndex = 11;
            this.chbIsUneployed.Text = "уволен";
            this.chbIsUneployed.UseVisualStyleBackColor = true;
            this.chbIsUneployed.CheckedChanged += new System.EventHandler(this.chbIsUneployed_CheckedChanged);
            // 
            // txbStatisticsOutput
            // 
            this.txbStatisticsOutput.AcceptsReturn = true;
            this.txbStatisticsOutput.Location = new System.Drawing.Point(12, 577);
            this.txbStatisticsOutput.Multiline = true;
            this.txbStatisticsOutput.Name = "txbStatisticsOutput";
            this.txbStatisticsOutput.ReadOnly = true;
            this.txbStatisticsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbStatisticsOutput.Size = new System.Drawing.Size(971, 172);
            this.txbStatisticsOutput.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 502);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Статистика:";
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1012, 750);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbStatisticsOutput);
            this.Controls.Add(this.chbIsUneployed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbxStatisticStatuses);
            this.Controls.Add(this.cbxSearchValues);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txbSearchText);
            this.Controls.Add(this.cbxSearchFlags);
            this.Name = "MainWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ComboBox cbxSearchFlags;
        private System.Windows.Forms.TextBox txbSearchText;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.ComboBox cbxSearchValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateEmploy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateUnemploy;
        private System.Windows.Forms.ComboBox cbxStatisticStatuses;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbIsUneployed;
        private System.Windows.Forms.TextBox txbStatisticsOutput;
        private System.Windows.Forms.Label label4;
    }
}

