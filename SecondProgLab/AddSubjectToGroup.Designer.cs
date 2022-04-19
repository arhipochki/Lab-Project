namespace SecondProgLab
{
    partial class AddSubjectToGroup
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
            this.addSubjectBtn = new System.Windows.Forms.Button();
            this.removeSubjectBtn = new System.Windows.Forms.Button();
            this.groupSubjectsTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.allSubjectsTable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupSubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupSubjectGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupSubjectsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSubjectsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // addSubjectBtn
            // 
            this.addSubjectBtn.Location = new System.Drawing.Point(273, 99);
            this.addSubjectBtn.Name = "addSubjectBtn";
            this.addSubjectBtn.Size = new System.Drawing.Size(75, 23);
            this.addSubjectBtn.TabIndex = 1;
            this.addSubjectBtn.Text = "----->";
            this.addSubjectBtn.UseVisualStyleBackColor = true;
            this.addSubjectBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeSubjectBtn
            // 
            this.removeSubjectBtn.Location = new System.Drawing.Point(273, 138);
            this.removeSubjectBtn.Name = "removeSubjectBtn";
            this.removeSubjectBtn.Size = new System.Drawing.Size(75, 23);
            this.removeSubjectBtn.TabIndex = 2;
            this.removeSubjectBtn.Text = "<-----";
            this.removeSubjectBtn.UseVisualStyleBackColor = true;
            this.removeSubjectBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // groupSubjectsTable
            // 
            this.groupSubjectsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupSubjectsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupSubjectName,
            this.GroupSubjectGUID});
            this.groupSubjectsTable.Location = new System.Drawing.Point(354, 34);
            this.groupSubjectsTable.Name = "groupSubjectsTable";
            this.groupSubjectsTable.Size = new System.Drawing.Size(243, 191);
            this.groupSubjectsTable.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список предметов группы";
            // 
            // allSubjectsTable
            // 
            this.allSubjectsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allSubjectsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectName,
            this.SubjectGUID});
            this.allSubjectsTable.Location = new System.Drawing.Point(24, 34);
            this.allSubjectsTable.Name = "allSubjectsTable";
            this.allSubjectsTable.Size = new System.Drawing.Size(243, 191);
            this.allSubjectsTable.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Список всех предметов";
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
            // AddSubjectToGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 236);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.allSubjectsTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupSubjectsTable);
            this.Controls.Add(this.removeSubjectBtn);
            this.Controls.Add(this.addSubjectBtn);
            this.Name = "AddSubjectToGroup";
            this.Text = "Изменить предметы";
            ((System.ComponentModel.ISupportInitialize)(this.groupSubjectsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSubjectsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addSubjectBtn;
        private System.Windows.Forms.Button removeSubjectBtn;
        private System.Windows.Forms.DataGridView groupSubjectsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView allSubjectsTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupSubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupSubjectGUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectGUID;
    }
}