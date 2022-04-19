namespace SecondProgLab
{
    partial class AddSubjectsToTeacher
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
            this.teacherSubjectsTable = new System.Windows.Forms.DataGridView();
            this.removeBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.allSubjectsTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.teacherSubjectsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.allGroupsTable = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.currentSubjectGroupsTable = new System.Windows.Forms.DataGridView();
            this.removeGroupBtn = new System.Windows.Forms.Button();
            this.addGroupBtn = new System.Windows.Forms.Button();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupSubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupSubjectGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.teacherSubjectsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSubjectsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allGroupsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentSubjectGroupsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // teacherSubjectsTable
            // 
            this.teacherSubjectsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teacherSubjectsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupSubjectName,
            this.GroupSubjectGUID});
            this.teacherSubjectsTable.Location = new System.Drawing.Point(342, 29);
            this.teacherSubjectsTable.Name = "teacherSubjectsTable";
            this.teacherSubjectsTable.Size = new System.Drawing.Size(243, 191);
            this.teacherSubjectsTable.TabIndex = 9;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(261, 133);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 8;
            this.removeBtn.Text = "<-----";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(261, 94);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "----->";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // allSubjectsTable
            // 
            this.allSubjectsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allSubjectsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectName,
            this.SubjectGUID});
            this.allSubjectsTable.Location = new System.Drawing.Point(12, 29);
            this.allSubjectsTable.Name = "allSubjectsTable";
            this.allSubjectsTable.Size = new System.Drawing.Size(243, 191);
            this.allSubjectsTable.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Список предметов преподавателя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Список всех предметов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(257, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Предмет";
            // 
            // teacherSubjectsComboBox
            // 
            this.teacherSubjectsComboBox.FormattingEnabled = true;
            this.teacherSubjectsComboBox.Location = new System.Drawing.Point(238, 281);
            this.teacherSubjectsComboBox.Name = "teacherSubjectsComboBox";
            this.teacherSubjectsComboBox.Size = new System.Drawing.Size(121, 21);
            this.teacherSubjectsComboBox.TabIndex = 21;
            this.teacherSubjectsComboBox.SelectedIndexChanged += new System.EventHandler(this.teacherSubjectsComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Список всех групп";
            // 
            // allGroupsTable
            // 
            this.allGroupsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allGroupsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.allGroupsTable.Location = new System.Drawing.Point(102, 334);
            this.allGroupsTable.Name = "allGroupsTable";
            this.allGroupsTable.Size = new System.Drawing.Size(153, 191);
            this.allGroupsTable.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Список групп по предмету";
            // 
            // currentSubjectGroupsTable
            // 
            this.currentSubjectGroupsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentSubjectGroupsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.currentSubjectGroupsTable.Location = new System.Drawing.Point(342, 334);
            this.currentSubjectGroupsTable.Name = "currentSubjectGroupsTable";
            this.currentSubjectGroupsTable.Size = new System.Drawing.Size(153, 191);
            this.currentSubjectGroupsTable.TabIndex = 17;
            // 
            // removeGroupBtn
            // 
            this.removeGroupBtn.Location = new System.Drawing.Point(261, 438);
            this.removeGroupBtn.Name = "removeGroupBtn";
            this.removeGroupBtn.Size = new System.Drawing.Size(75, 23);
            this.removeGroupBtn.TabIndex = 16;
            this.removeGroupBtn.Text = "<-----";
            this.removeGroupBtn.UseVisualStyleBackColor = true;
            this.removeGroupBtn.Click += new System.EventHandler(this.removeGroupBtn_Click);
            // 
            // addGroupBtn
            // 
            this.addGroupBtn.Location = new System.Drawing.Point(261, 399);
            this.addGroupBtn.Name = "addGroupBtn";
            this.addGroupBtn.Size = new System.Drawing.Size(75, 23);
            this.addGroupBtn.TabIndex = 15;
            this.addGroupBtn.Text = "----->";
            this.addGroupBtn.UseVisualStyleBackColor = true;
            this.addGroupBtn.Click += new System.EventHandler(this.addGroupBtn_Click);
            // 
            // SubjectName
            // 
            this.SubjectName.HeaderText = "Предмет";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // SubjectGUID
            // 
            this.SubjectGUID.HeaderText = "GUID";
            this.SubjectGUID.Name = "SubjectGUID";
            this.SubjectGUID.ReadOnly = true;
            // 
            // GroupSubjectName
            // 
            this.GroupSubjectName.HeaderText = "Предмет";
            this.GroupSubjectName.Name = "GroupSubjectName";
            this.GroupSubjectName.ReadOnly = true;
            // 
            // GroupSubjectGUID
            // 
            this.GroupSubjectGUID.HeaderText = "GUID";
            this.GroupSubjectGUID.Name = "GroupSubjectGUID";
            this.GroupSubjectGUID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Группа";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Группа";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // AddSubjectsToTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 546);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.teacherSubjectsComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.allGroupsTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentSubjectGroupsTable);
            this.Controls.Add(this.removeGroupBtn);
            this.Controls.Add(this.addGroupBtn);
            this.Controls.Add(this.teacherSubjectsTable);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.allSubjectsTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "AddSubjectsToTeacher";
            this.Text = "Редактирование преподавателя";
            ((System.ComponentModel.ISupportInitialize)(this.teacherSubjectsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSubjectsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allGroupsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentSubjectGroupsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView teacherSubjectsTable;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.DataGridView allSubjectsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox teacherSubjectsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView allGroupsTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView currentSubjectGroupsTable;
        private System.Windows.Forms.Button removeGroupBtn;
        private System.Windows.Forms.Button addGroupBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupSubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupSubjectGUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectGUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}