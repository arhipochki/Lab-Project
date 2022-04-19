namespace SecondProgLab
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addGroupBtn = new System.Windows.Forms.Button();
            this.studentsTable = new System.Windows.Forms.DataGridView();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Examiner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentRatinColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.changeSubjectsBtn = new System.Windows.Forms.Button();
            this.suggestionTeachersTable = new System.Windows.Forms.DataGridView();
            this.TeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsTermTeacher = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsExamTeacher = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentTeacherGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTeachersTable = new System.Windows.Forms.DataGridView();
            this.FullTeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllTeacherSubjects = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CurrentTeacherGroups = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentSubjectRatin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentTeacherRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherGUIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addTeacherBtn = new System.Windows.Forms.Button();
            this.removeTeacherBtn = new System.Windows.Forms.Button();
            this.addStudentBtn = new System.Windows.Forms.Button();
            this.removeStudentBtn = new System.Windows.Forms.Button();
            this.subjectTable = new System.Windows.Forms.DataGridView();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDelBtn = new System.Windows.Forms.Button();
            this.subjectAddBtn = new System.Windows.Forms.Button();
            this.removeGroupBtn = new System.Windows.Forms.Button();
            this.changeGroupNameBtn = new System.Windows.Forms.Button();
            this.changeTeacherSubjectsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suggestionTeachersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allTeachersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(144, 50);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(121, 21);
            this.groupComboBox.TabIndex = 0;
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(71, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Группа";
            // 
            // addGroupBtn
            // 
            this.addGroupBtn.Location = new System.Drawing.Point(312, 22);
            this.addGroupBtn.Name = "addGroupBtn";
            this.addGroupBtn.Size = new System.Drawing.Size(133, 23);
            this.addGroupBtn.TabIndex = 2;
            this.addGroupBtn.Text = "Добавить группу";
            this.addGroupBtn.UseVisualStyleBackColor = true;
            this.addGroupBtn.Click += new System.EventHandler(this.addGroupBtn_Click);
            // 
            // studentsTable
            // 
            this.studentsTable.AllowUserToAddRows = false;
            this.studentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentName,
            this.Subject,
            this.Teacher,
            this.Examiner,
            this.TermGrade,
            this.ExamGrade,
            this.TotalGrade,
            this.StudentRatinColumn});
            this.studentsTable.Location = new System.Drawing.Point(57, 411);
            this.studentsTable.MultiSelect = false;
            this.studentsTable.Name = "studentsTable";
            this.studentsTable.Size = new System.Drawing.Size(843, 300);
            this.studentsTable.TabIndex = 3;
            this.studentsTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.studentsTable_CellBeginEdit);
            this.studentsTable.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.studentsTable_CellValidated);
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Имя";
            this.StudentName.Name = "StudentName";
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Предмет";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Teacher
            // 
            this.Teacher.HeaderText = "Преподователь";
            this.Teacher.Name = "Teacher";
            this.Teacher.ReadOnly = true;
            // 
            // Examiner
            // 
            this.Examiner.HeaderText = "Экзаменатор";
            this.Examiner.Name = "Examiner";
            this.Examiner.ReadOnly = true;
            // 
            // TermGrade
            // 
            this.TermGrade.HeaderText = "Баллы за семестр";
            this.TermGrade.Name = "TermGrade";
            // 
            // ExamGrade
            // 
            this.ExamGrade.HeaderText = "Баллы за экзамен";
            this.ExamGrade.Name = "ExamGrade";
            // 
            // TotalGrade
            // 
            this.TotalGrade.HeaderText = "Итог";
            this.TotalGrade.Name = "TotalGrade";
            this.TotalGrade.ReadOnly = true;
            // 
            // StudentRatinColumn
            // 
            this.StudentRatinColumn.HeaderText = "Рейтинг";
            this.StudentRatinColumn.Name = "StudentRatinColumn";
            this.StudentRatinColumn.ReadOnly = true;
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Location = new System.Drawing.Point(144, 163);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(121, 21);
            this.subjectComboBox.TabIndex = 4;
            this.subjectComboBox.SelectedIndexChanged += new System.EventHandler(this.subjectComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(57, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Предметы";
            // 
            // changeSubjectsBtn
            // 
            this.changeSubjectsBtn.Location = new System.Drawing.Point(312, 163);
            this.changeSubjectsBtn.Name = "changeSubjectsBtn";
            this.changeSubjectsBtn.Size = new System.Drawing.Size(133, 23);
            this.changeSubjectsBtn.TabIndex = 6;
            this.changeSubjectsBtn.Text = "Изменить предметы";
            this.changeSubjectsBtn.UseVisualStyleBackColor = true;
            this.changeSubjectsBtn.Click += new System.EventHandler(this.changeSubjectsBtn_Click);
            // 
            // suggestionTeachersTable
            // 
            this.suggestionTeachersTable.AllowUserToAddRows = false;
            this.suggestionTeachersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suggestionTeachersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeacherName,
            this.IsTermTeacher,
            this.IsExamTeacher,
            this.Rating,
            this.CurrentTeacherGuid});
            this.suggestionTeachersTable.Location = new System.Drawing.Point(974, 411);
            this.suggestionTeachersTable.MultiSelect = false;
            this.suggestionTeachersTable.Name = "suggestionTeachersTable";
            this.suggestionTeachersTable.Size = new System.Drawing.Size(543, 300);
            this.suggestionTeachersTable.TabIndex = 7;
            // 
            // TeacherName
            // 
            this.TeacherName.HeaderText = "Преподаватель";
            this.TeacherName.Name = "TeacherName";
            this.TeacherName.ReadOnly = true;
            // 
            // IsTermTeacher
            // 
            this.IsTermTeacher.HeaderText = "Семинарист";
            this.IsTermTeacher.Name = "IsTermTeacher";
            this.IsTermTeacher.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsTermTeacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsExamTeacher
            // 
            this.IsExamTeacher.HeaderText = "Экзаменатор";
            this.IsExamTeacher.Name = "IsExamTeacher";
            this.IsExamTeacher.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsExamTeacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Rating
            // 
            this.Rating.HeaderText = "Рейтинг";
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            // 
            // CurrentTeacherGuid
            // 
            this.CurrentTeacherGuid.HeaderText = "GUID";
            this.CurrentTeacherGuid.Name = "CurrentTeacherGuid";
            this.CurrentTeacherGuid.ReadOnly = true;
            // 
            // allTeachersTable
            // 
            this.allTeachersTable.AllowUserToAddRows = false;
            this.allTeachersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allTeachersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullTeacherName,
            this.AllTeacherSubjects,
            this.CurrentTeacherGroups,
            this.CurrentSubjectRatin,
            this.CurrentTeacherRating,
            this.TeacherGUIDColumn});
            this.allTeachersTable.Location = new System.Drawing.Point(774, 51);
            this.allTeachersTable.MultiSelect = false;
            this.allTeachersTable.Name = "allTeachersTable";
            this.allTeachersTable.Size = new System.Drawing.Size(743, 287);
            this.allTeachersTable.TabIndex = 8;
            this.allTeachersTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.allTeachersTable_CellBeginEdit);
            this.allTeachersTable.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.allTeachersTable_CellValidated);
            // 
            // FullTeacherName
            // 
            this.FullTeacherName.HeaderText = "Ф.И.О.";
            this.FullTeacherName.Name = "FullTeacherName";
            this.FullTeacherName.Width = 150;
            // 
            // AllTeacherSubjects
            // 
            this.AllTeacherSubjects.HeaderText = "Предметы";
            this.AllTeacherSubjects.Name = "AllTeacherSubjects";
            this.AllTeacherSubjects.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllTeacherSubjects.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CurrentTeacherGroups
            // 
            this.CurrentTeacherGroups.HeaderText = "Группы";
            this.CurrentTeacherGroups.Name = "CurrentTeacherGroups";
            this.CurrentTeacherGroups.ReadOnly = true;
            // 
            // CurrentSubjectRatin
            // 
            this.CurrentSubjectRatin.HeaderText = "Рейтинг по предмету";
            this.CurrentSubjectRatin.Name = "CurrentSubjectRatin";
            this.CurrentSubjectRatin.ReadOnly = true;
            this.CurrentSubjectRatin.Width = 150;
            // 
            // CurrentTeacherRating
            // 
            this.CurrentTeacherRating.HeaderText = "Рейтинг";
            this.CurrentTeacherRating.Name = "CurrentTeacherRating";
            this.CurrentTeacherRating.ReadOnly = true;
            // 
            // TeacherGUIDColumn
            // 
            this.TeacherGUIDColumn.HeaderText = "GUID";
            this.TeacherGUIDColumn.Name = "TeacherGUIDColumn";
            this.TeacherGUIDColumn.ReadOnly = true;
            // 
            // addTeacherBtn
            // 
            this.addTeacherBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTeacherBtn.Location = new System.Drawing.Point(774, 22);
            this.addTeacherBtn.Name = "addTeacherBtn";
            this.addTeacherBtn.Size = new System.Drawing.Size(30, 23);
            this.addTeacherBtn.TabIndex = 9;
            this.addTeacherBtn.Text = "+";
            this.addTeacherBtn.UseVisualStyleBackColor = true;
            this.addTeacherBtn.Click += new System.EventHandler(this.addTeacherBtn_Click);
            // 
            // removeTeacherBtn
            // 
            this.removeTeacherBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeTeacherBtn.Location = new System.Drawing.Point(810, 22);
            this.removeTeacherBtn.Name = "removeTeacherBtn";
            this.removeTeacherBtn.Size = new System.Drawing.Size(30, 23);
            this.removeTeacherBtn.TabIndex = 10;
            this.removeTeacherBtn.Text = "-";
            this.removeTeacherBtn.UseVisualStyleBackColor = true;
            this.removeTeacherBtn.Click += new System.EventHandler(this.removeTeacherBtn_Click);
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.Location = new System.Drawing.Point(57, 380);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(32, 23);
            this.addStudentBtn.TabIndex = 11;
            this.addStudentBtn.Text = "+";
            this.addStudentBtn.UseVisualStyleBackColor = true;
            this.addStudentBtn.Click += new System.EventHandler(this.addStudentBtn_Click);
            // 
            // removeStudentBtn
            // 
            this.removeStudentBtn.Location = new System.Drawing.Point(95, 380);
            this.removeStudentBtn.Name = "removeStudentBtn";
            this.removeStudentBtn.Size = new System.Drawing.Size(32, 23);
            this.removeStudentBtn.TabIndex = 12;
            this.removeStudentBtn.Text = "-";
            this.removeStudentBtn.UseVisualStyleBackColor = true;
            this.removeStudentBtn.Click += new System.EventHandler(this.removeStudentBtn_Click);
            // 
            // subjectTable
            // 
            this.subjectTable.AllowUserToAddRows = false;
            this.subjectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectName,
            this.SubjectGUID});
            this.subjectTable.Location = new System.Drawing.Point(488, 51);
            this.subjectTable.MultiSelect = false;
            this.subjectTable.Name = "subjectTable";
            this.subjectTable.Size = new System.Drawing.Size(244, 287);
            this.subjectTable.TabIndex = 13;
            this.subjectTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.subjectTable_CellBeginEdit);
            this.subjectTable.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.subjectTable_CellValidated);
            // 
            // SubjectName
            // 
            this.SubjectName.HeaderText = "Название";
            this.SubjectName.Name = "SubjectName";
            // 
            // SubjectGUID
            // 
            this.SubjectGUID.HeaderText = "GUID";
            this.SubjectGUID.Name = "SubjectGUID";
            this.SubjectGUID.ReadOnly = true;
            // 
            // subjectDelBtn
            // 
            this.subjectDelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subjectDelBtn.Location = new System.Drawing.Point(524, 22);
            this.subjectDelBtn.Name = "subjectDelBtn";
            this.subjectDelBtn.Size = new System.Drawing.Size(30, 23);
            this.subjectDelBtn.TabIndex = 15;
            this.subjectDelBtn.Text = "-";
            this.subjectDelBtn.UseVisualStyleBackColor = true;
            this.subjectDelBtn.Click += new System.EventHandler(this.subjectDelBtn_Click);
            // 
            // subjectAddBtn
            // 
            this.subjectAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subjectAddBtn.Location = new System.Drawing.Point(488, 22);
            this.subjectAddBtn.Name = "subjectAddBtn";
            this.subjectAddBtn.Size = new System.Drawing.Size(30, 23);
            this.subjectAddBtn.TabIndex = 14;
            this.subjectAddBtn.Text = "+";
            this.subjectAddBtn.UseVisualStyleBackColor = true;
            this.subjectAddBtn.Click += new System.EventHandler(this.subjectAddBtn_Click);
            // 
            // removeGroupBtn
            // 
            this.removeGroupBtn.Location = new System.Drawing.Point(312, 79);
            this.removeGroupBtn.Name = "removeGroupBtn";
            this.removeGroupBtn.Size = new System.Drawing.Size(133, 23);
            this.removeGroupBtn.TabIndex = 16;
            this.removeGroupBtn.Text = "Удалить группу";
            this.removeGroupBtn.UseVisualStyleBackColor = true;
            this.removeGroupBtn.Click += new System.EventHandler(this.removeGroupBtn_Click);
            // 
            // changeGroupNameBtn
            // 
            this.changeGroupNameBtn.Location = new System.Drawing.Point(312, 51);
            this.changeGroupNameBtn.Name = "changeGroupNameBtn";
            this.changeGroupNameBtn.Size = new System.Drawing.Size(133, 23);
            this.changeGroupNameBtn.TabIndex = 17;
            this.changeGroupNameBtn.Text = "Изменить имя группы";
            this.changeGroupNameBtn.UseVisualStyleBackColor = true;
            this.changeGroupNameBtn.Click += new System.EventHandler(this.changeGroupNameBtn_Click);
            // 
            // changeTeacherSubjectsBtn
            // 
            this.changeTeacherSubjectsBtn.Location = new System.Drawing.Point(846, 22);
            this.changeTeacherSubjectsBtn.Name = "changeTeacherSubjectsBtn";
            this.changeTeacherSubjectsBtn.Size = new System.Drawing.Size(133, 23);
            this.changeTeacherSubjectsBtn.TabIndex = 18;
            this.changeTeacherSubjectsBtn.Text = "Изменить предметы";
            this.changeTeacherSubjectsBtn.UseVisualStyleBackColor = true;
            this.changeTeacherSubjectsBtn.Click += new System.EventHandler(this.changeTeacherSubjectsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 737);
            this.Controls.Add(this.changeTeacherSubjectsBtn);
            this.Controls.Add(this.changeGroupNameBtn);
            this.Controls.Add(this.removeGroupBtn);
            this.Controls.Add(this.subjectDelBtn);
            this.Controls.Add(this.subjectAddBtn);
            this.Controls.Add(this.subjectTable);
            this.Controls.Add(this.removeStudentBtn);
            this.Controls.Add(this.addStudentBtn);
            this.Controls.Add(this.removeTeacherBtn);
            this.Controls.Add(this.addTeacherBtn);
            this.Controls.Add(this.allTeachersTable);
            this.Controls.Add(this.suggestionTeachersTable);
            this.Controls.Add(this.changeSubjectsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subjectComboBox);
            this.Controls.Add(this.studentsTable);
            this.Controls.Add(this.addGroupBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupComboBox);
            this.Name = "Form1";
            this.Text = "Lab Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.studentsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suggestionTeachersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allTeachersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addGroupBtn;
        private System.Windows.Forms.DataGridView studentsTable;
        private System.Windows.Forms.ComboBox subjectComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button changeSubjectsBtn;
        private System.Windows.Forms.DataGridView suggestionTeachersTable;
        private System.Windows.Forms.DataGridView allTeachersTable;
        private System.Windows.Forms.Button addTeacherBtn;
        private System.Windows.Forms.Button removeTeacherBtn;
        private System.Windows.Forms.Button addStudentBtn;
        private System.Windows.Forms.Button removeStudentBtn;
        private System.Windows.Forms.DataGridView subjectTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectGUID;
        private System.Windows.Forms.Button subjectDelBtn;
        private System.Windows.Forms.Button subjectAddBtn;
        private System.Windows.Forms.Button removeGroupBtn;
        private System.Windows.Forms.Button changeGroupNameBtn;
        private System.Windows.Forms.Button changeTeacherSubjectsBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullTeacherName;
        private System.Windows.Forms.DataGridViewComboBoxColumn AllTeacherSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentTeacherGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentSubjectRatin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentTeacherRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherGUIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherName;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsTermTeacher;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsExamTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentTeacherGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Examiner;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentRatinColumn;
    }
}

