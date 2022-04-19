using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecondProgLab
{
    /// <summary>
    /// Форма основного окна.
    /// </summary>
    public partial class Form1 : Form
    {
        MainModule mainModule = new MainModule();   // Создаём копию класса MainModule для работы с загрузкой и сохранением данных.

        Dictionary<string, List<Student>> students = new Dictionary<string, List<Student>>();   // Список студентов.
        Dictionary<Guid, Teacher> teachers = new Dictionary<Guid, Teacher>();                   // Список преподавателей.
        Dictionary<string, Guid> subjects = new Dictionary<string, Guid>();                     // Список предметов.

        string[] ANSWERS = { "Да", "Нет" };     // Список для заполнения выпадющих меню.

        bool USER_INPUT = false;                // Статус ввода пользователем.

        public Form1()
        {
            InitializeComponent();

            // Подключаем EventHandler'ы для последующей обработки выпадающих меню в таблицах
            this.allTeachersTable.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(allTeachersTable_EditingControlShowing);
            this.suggestionTeachersTable.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(suggestionTeachersTable_EditingControlShowing);

            // Загружаем данные.
            students = mainModule.LoadStudents();
            teachers = mainModule.LoadTeachers();
            subjects = mainModule.LoadSubjects();

            // Заполняем таблицы, выпадающее меню.
            FillGroupComboBox();
            FillSubjectTable();
            FillAllTeachersTable();
        }

        /// <summary>
        /// Функция заполнения таблицы предложенных преподавателей по конкретному предмету.
        /// </summary>
        private void FillSuggestionTeachersTable()
        {
            this.suggestionTeachersTable.Rows.Clear();

            int currentSubjectIdx = this.subjectComboBox.SelectedIndex;
            // Если предмет не выбран - выходим.
            if (currentSubjectIdx == -1)
                return;

            string currentGroup = this.groupComboBox.SelectedItem.ToString();

            int row = 0;
            foreach (var teacher in teachers)
            {
                int col = 0;
                foreach (var subject in teacher.Value.Subjects)
                {
                    int currentSubjectTeacherIdx = 0;   // Индекс выбранного предмета относительно списка преподавателя.
                    if (subject.Name == this.subjectComboBox.SelectedItem.ToString()) // Если совпал, тогда заполняем поля.
                    {
                        this.suggestionTeachersTable.Rows.Add();

                        this.suggestionTeachersTable.Rows[row].Cells[col++].Value = teacher.Value.Name;

                        // Создаём экземпял выпадающего меню для таблицы.
                        DataGridViewComboBoxCell semenarianCell = new DataGridViewComboBoxCell();
                        semenarianCell.Items.Clear();
                        semenarianCell.DataSource = ANSWERS;    // Заполняем возможными предметами.

                        // Если преподаватель указан как семинарист или в его списке есть данная группа, тогда выставляем значение "да"
                        if (students[this.groupComboBox.SelectedItem.ToString()][0].Grades[this.subjectComboBox.SelectedIndex].TeacherGUID == teacher.Value.GUID || teacher.Value.Subjects[currentSubjectTeacherIdx].Groups.ContainsKey(currentGroup))
                        {
                            semenarianCell.Value = ANSWERS[0];

                            // Также не забываем присвоить id учителя группе.
                            foreach (var student in students[currentGroup])
                            {
                                student.Grades[currentSubjectIdx].TeacherGUID = teacher.Value.GUID;
                            }
                        }
                        else // Иначе значение "нет".
                            semenarianCell.Value = ANSWERS[1];

                        this.suggestionTeachersTable.Rows[row].Cells[col++] = semenarianCell;


                        DataGridViewComboBoxCell examCell = new DataGridViewComboBoxCell();
                        examCell.Items.Clear();
                        examCell.DataSource = ANSWERS;

                        // Если преподаватель указан в качестве экзаменатора, тогда выставляем значение "да"
                        if (students[this.groupComboBox.SelectedItem.ToString()][0].Grades[this.subjectComboBox.SelectedIndex].ExaminerGUID == teacher.Value.GUID)
                            examCell.Value = ANSWERS[0];
                        else // Иначе "нет"
                            examCell.Value = ANSWERS[1];

                        this.suggestionTeachersTable.Rows[row].Cells[col++] = examCell;

                        this.suggestionTeachersTable.Rows[row].Cells[col++].Value = teacher.Value.Rating;

                        this.suggestionTeachersTable.Rows[row].Cells[col++].Value = teacher.Value.GUID;

                        row++;
                    }
                    currentSubjectTeacherIdx++;
                }
            }
        }

        /// <summary>
        /// Функция заполнения таблицы студентов.
        /// </summary>
        private void FillStudentsTable()
        {
            string currentGroup = this.groupComboBox.SelectedItem.ToString();

            this.studentsTable.Rows.Clear();

            this.studentsTable.RowCount = students[currentGroup].Count;

            this.subjectComboBox.Items.Clear();
            this.subjectComboBox.Text = "";

            try // Если список предметов пуской, кидаем ошибку и идём к следующему пункту, инчае заполняем выпадающее меню.
            {
                if (students[currentGroup][0].Grades.Count == 0)
                {
                    throw new Exception();
                }

                foreach (var subject in students[currentGroup][0].Grades)
                {
                    this.subjectComboBox.Items.Add(subject.Name);
                }
            }
            catch (Exception ex)
            {
                this.suggestionTeachersTable.Rows.Clear();
                return;
            }

            if (this.subjectComboBox.Items.Count > 0)
            {
                // Выставляем статус ввода пользователем на ложь, т.к. это нужно для последующего корректного заполнения таблицы
                // иначе будет всё перемешено.
                USER_INPUT = false;

                this.subjectComboBox.SelectedIndex = 0;

                int currentSubject = this.subjectComboBox.SelectedIndex;

                int row = 0;
                foreach (var student in students[currentGroup])
                {
                    int col = 0;

                    this.studentsTable.Rows[row].Cells[col++].Value = student.Name;
                    this.studentsTable.Rows[row].Cells[col++].Value = this.subjectComboBox.SelectedItem;

                    // Если id семинариста не равен нулевому, т.е. семинарист назначен, тогда выдаём его имя
                    if (student.Grades[currentSubject].TeacherGUID != new Guid())
                        this.studentsTable.Rows[row].Cells[col].Value = teachers[student.Grades[currentSubject].TeacherGUID].Name;
                    else // Иначе "Отсутствует" 
                        this.studentsTable.Rows[row].Cells[col].Value = "Отсутствует";

                    col++;

                    // Аналогично для экзаменатора.
                    if (student.Grades[currentSubject].ExaminerGUID != new Guid())
                        this.studentsTable.Rows[row].Cells[col].Value = teachers[student.Grades[currentSubject].ExaminerGUID].Name;
                    else
                        this.studentsTable.Rows[row].Cells[col].Value = "Отсутствует";

                    col++;

                    this.studentsTable.Rows[row].Cells[col++].Value = student.Grades[currentSubject].TermGrade;
                    this.studentsTable.Rows[row].Cells[col++].Value = student.Grades[currentSubject].ExamGrade;
                    this.studentsTable.Rows[row].Cells[col++].Value = student.Grades[currentSubject].TotalGrade;

                    this.studentsTable.Rows[row].Cells[col++].Value = student.Rating;

                    row++;
                }
            }
        }

        /// <summary>
        /// Функция, привязанная к смене индекса в выпадающем меню групп: обновляет таблицу студентов и таблицу предложенных преподавателей.
        /// </summary>
        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentsTable();

            FillSuggestionTeachersTable();
        }

        /// <summary>
        /// Функция, привязанная к смене индекса в выпадающем меню предметов группы: обновляет таблицу студентов и таблицу предложенных преподавателей.
        /// </summary>
        private void subjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int row = 0;
                string currentGroup = this.groupComboBox.SelectedItem.ToString();
                int currentSubjectIdx = this.subjectComboBox.SelectedIndex;
                foreach (var student in students[currentGroup])
                {
                    bool found = false;
                    // Проверяем по id, есть предмет в списке
                    foreach (var subj in student.Grades)
                        if (subj.SubjectGUID == subjects[this.subjectComboBox.SelectedItem.ToString()])
                            found = true;

                    // Если нет - добавляем
                    if (!found)
                        student.Grades.Add(new GuidPair
                        {
                            Name = this.subjectComboBox.SelectedItem.ToString(),
                            SubjectGUID = subjects[this.subjectComboBox.SelectedItem.ToString()],
                            ExaminerGUID = students[currentGroup][0].Grades[currentSubjectIdx].ExaminerGUID,
                            TeacherGUID = students[currentGroup][0].Grades[currentSubjectIdx].TeacherGUID
                        });

                    int col = 1;

                    this.studentsTable.Rows[row].Cells[col++].Value = this.subjectComboBox.SelectedItem;

                    // Проверяем, назначен ли семинарист и экзаменатор.
                    if (student.Grades[currentSubjectIdx].TeacherGUID != new Guid())
                        this.studentsTable.Rows[row].Cells[col].Value = teachers[student.Grades[currentSubjectIdx].TeacherGUID].Name;
                    else
                        this.studentsTable.Rows[row].Cells[col].Value = "Отсутствует";

                    col++;

                    if (student.Grades[currentSubjectIdx].ExaminerGUID != new Guid())
                        this.studentsTable.Rows[row].Cells[col].Value = teachers[student.Grades[currentSubjectIdx].ExaminerGUID].Name;
                    else
                        this.studentsTable.Rows[row].Cells[col].Value = "Отсутствует";

                    col++;

                    this.studentsTable.Rows[row].Cells[col++].Value = student.Grades[currentSubjectIdx].TermGrade;
                    this.studentsTable.Rows[row].Cells[col++].Value = student.Grades[currentSubjectIdx].ExamGrade;
                    this.studentsTable.Rows[row].Cells[col++].Value = student.Grades[currentSubjectIdx].TotalGrade;

                    row++;
                }
            }
            catch (Exception ex)
            {
                ;
            }

            try
            {
                FillSuggestionTeachersTable();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        /// <summary>
        /// Функция, привязанная к кнопке addGroupBtn: поднимает новое окно с формой добавления группы.
        /// </summary>
        private void addGroupBtn_Click(object sender, EventArgs e)
        {
            AddNew addNewDialog = new AddNew("Добавить группу", "Группа");

            if (addNewDialog.ShowDialog(this) == DialogResult.OK)
            {
                Console.WriteLine("Created");
            }

            addNewDialog.Dispose();

            string group = addNewDialog.GetText();
            if (group != "")
            {
                try
                {
                    students.Add(group, new List<Student> { { new Student() { Grades = new List<GuidPair>() } } });
                    this.groupComboBox.Items.Add(group);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Группа с таким именем уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Функция, привязанная к кнопке changeSubjectsBtn: поднимает форму для редактирования предметов группы.
        /// </summary>
        private void changeSubjectsBtn_Click(object sender, EventArgs e)
        {
            if (this.groupComboBox.SelectedItem != null)
            {
                AddSubjectToGroup addSubjects = new AddSubjectToGroup(subjects, students[this.groupComboBox.SelectedItem.ToString()]);

                if (addSubjects.ShowDialog(this) == DialogResult.OK)
                {
                    Console.WriteLine("Created");
                }

                addSubjects.Dispose();

                // Заполняем выпадающее меню после изменений.
                this.subjectComboBox.Items.Clear();
                foreach (var subject in students[this.groupComboBox.SelectedItem.ToString()][0].Grades)
                {
                    this.subjectComboBox.Items.Add(subject.Name);
                }
                
                try
                {
                    this.subjectComboBox.SelectedIndex = 0;
                }
                catch (Exception ex) // Если список предметов пуст, ставим пустое поле
                {
                    this.subjectComboBox.Text = "";
                    this.subjectComboBox.Items.Clear();
                    this.studentsTable.Rows.Clear(); ;
                    this.suggestionTeachersTable.Rows.Clear();
                }

                mainModule.SaveStudents(students);
            }
            else
                MessageBox.Show("Вы не выбрали группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Функция, привязанная к редактированию ячейки в таблицу студентов: обновляет данные.
        /// </summary>
        private void studentsTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (USER_INPUT)
            {
                int currentSubject = this.subjectComboBox.SelectedIndex;
                string currentGroup = this.groupComboBox.SelectedItem.ToString();
                int pos = this.studentsTable.CurrentCell.RowIndex;
                
                // Если выбранная ячейка превышает количество студентов, добавляем студента в список.
                if (pos > students[currentGroup].Count - 1)
                    students[currentGroup].Add(new Student());

                if (this.studentsTable.CurrentCell.Value != null)
                {
                    switch (this.studentsTable.CurrentCell.ColumnIndex)
                    {
                        case 0: // Столбик с ФИО.
                            students[currentGroup][pos].Name = this.studentsTable.Rows[pos].Cells[0].Value.ToString().Trim();
                            break;
                        case 4: // Столбик с оценкой за семестр.
                            students[currentGroup][pos].Grades[currentSubject].TermGrade = Int32.Parse(this.studentsTable.Rows[pos].Cells[4].Value.ToString());
                            break;
                        case 5: // Столбик с за экзамен.
                            students[currentGroup][pos].Grades[currentSubject].ExamGrade = Int32.Parse(this.studentsTable.Rows[pos].Cells[5].Value.ToString());
                            break;
                        default: // Все остальные столбики не редактируемые.
                            break;
                    }

                    try
                    {
                        // Считаем рейтинг студента и обновляем столбик с рейтингом студента.
                        int lastCol = this.studentsTable.Columns.Count - 1;
                        students[currentGroup][pos].Grades[this.subjectComboBox.SelectedIndex].CalculateGrade();
                        this.studentsTable.Rows[pos].Cells[lastCol - 1].Value = students[currentGroup][pos].Grades[this.subjectComboBox.SelectedIndex].TotalGrade;
                        students[currentGroup][pos].CalculateRating();

                        this.studentsTable.Rows[pos].Cells[lastCol].Value = students[currentGroup][pos].Rating;
                    }
                    catch (Exception ex)
                    {
                        ;
                    }
                }
                else // Перезаполняем таблицу, если пользователь вышел из меню редактирования.
                {
                    switch (this.studentsTable.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.studentsTable.CurrentCell.Value = students[currentGroup][pos].Name;
                            break;
                        case 4:
                            this.studentsTable.CurrentCell.Value = students[currentGroup][pos].Grades[this.subjectComboBox.SelectedIndex].TermGrade;
                            break;
                        case 5:
                            this.studentsTable.CurrentCell.Value = students[currentGroup][pos].Grades[this.subjectComboBox.SelectedIndex].ExamGrade;
                            break;
                        default:
                            break;
                    }
                }

                // Если назначен семинарист, считаем его рейтинг.
                if (students[currentGroup][pos].Grades[currentSubject].TeacherGUID != new Guid())
                {
                    Guid currentGuid = students[currentGroup][pos].Grades[currentSubject].TeacherGUID;

                    int currentSubjectTeacherIdx = -1;

                    for (int i = 0; i < teachers[currentGuid].Subjects.Count; i++)
                    {
                        if (teachers[currentGuid].Subjects[i].GUID == students[currentGroup][pos].Grades[currentSubject].SubjectGUID)
                        {
                            currentSubjectTeacherIdx = i;
                            break;
                        }
                    }

                    // Если предмет найден, тогда считаем рейтинг.
                    if (currentSubjectTeacherIdx > -1)
                    {
                        teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups[currentGroup] = 0;
                        foreach (var student in students[currentGroup])
                        {
                            teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups[currentGroup] += student.Grades[currentSubject].ExamGrade;
                        }

                        teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups[currentGroup] = Math.Round(teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups[currentGroup] / students[currentGroup].Count, 4);
                    }

                    teachers[currentGuid].Subjects[currentSubjectTeacherIdx].CalculateRating();

                    teachers[currentGuid].CalculateRating();
                }

                // Обновляем таблицы.
                FillAllTeachersTable();
                FillSuggestionTeachersTable();

                // Сохраняем.
                mainModule.SaveTeachers(teachers);
                mainModule.SaveStudents(students);

                // Ставим статус ввода пользователем.
                USER_INPUT = false;
            }
        }

        /// <summary>
        /// Функция, привязанная к закрытию формы: сохраняет данные перед выходом.
        /// </summary>
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mainModule.SaveStudents(students);
                mainModule.SaveTeachers(teachers);
                mainModule.SaveSubjects(subjects);
                e.Cancel = false; // Закрываем программу.
            }
            else
            {
                e.Cancel = true; // Отмена выхода.
            }
        }

        /// <summary>
        /// Функция заполнения выпадающего меню с группами.
        /// </summary>
        private void FillGroupComboBox()
        {
            this.groupComboBox.Items.Clear();

            foreach (var group in students)
            {
                this.groupComboBox.Items.Add(group.Key);
            }
        }

        /// <summary>
        /// Функция заполнения таблицы со всеми предметами.
        /// </summary>
        private void FillSubjectTable()
        {
            this.subjectTable.Rows.Clear();

            this.subjectTable.RowCount = subjects.Count;

            int row = 0;
            foreach (var subj in subjects)
            {
                int col = 0;
                this.subjectTable.Rows[row].Cells[col++].Value = subj.Key;
                this.subjectTable.Rows[row].Cells[col++].Value = subj.Value;
                row++;
            }
        }

        /// <summary>
        /// Функция заполнения таблицы со всеми преподавателями.
        /// </summary>
        private void FillAllTeachersTable()
        {
            this.allTeachersTable.Rows.Clear();
            this.allTeachersTable.RowCount = teachers.Count;

            int row = 0;
            
            foreach (var teacher in teachers)
            {
                int col = 0;

                this.allTeachersTable.Rows[row].Cells[col++].Value = teacher.Value.Name;

                // Создаём новое выпадающее меню, в котором будут хранится предметы преподавателя.
                DataGridViewComboBoxCell subjectsCell = new DataGridViewComboBoxCell();

                foreach (var subject in teacher.Value.Subjects)
                    subjectsCell.Items.Add(subject.Name);

                if (subjectsCell.Items.Count > 0)
                {
                    subjectsCell.Value = subjectsCell.Items[0];
                }

                this.allTeachersTable.Rows[row].Cells[col++] = subjectsCell;

                int zeroSubj = 0;
                try
                {
                    this.allTeachersTable.Rows[row].Cells[col++].Value = string.Join(";", teacher.Value.Subjects[zeroSubj].Groups.Keys);
                    this.allTeachersTable.Rows[row].Cells[col].Value = teacher.Value.Subjects[zeroSubj].Rating;
                }
                catch (Exception ex)
                {   // Если предметов нет, тогда пропускаем
                    col--;
                    this.allTeachersTable.Rows[row].Cells[col++].Value = "";
                    this.allTeachersTable.Rows[row].Cells[col].Value = 0;
                }
                col++;

                this.allTeachersTable.Rows[row].Cells[col++].Value = teacher.Value.Rating;
                this.allTeachersTable.Rows[row].Cells[col++].Value = teacher.Key;

                row++;
            }
        }

        /// <summary>
        /// Функция, привязанная к кнопке addStudentBtn: доабавляет нового студента в список и в таблицу.
        /// </summary>
        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            if (this.groupComboBox.SelectedItem == null) // Если группа не выбрана - выходим.
                return;

            this.studentsTable.Rows.Add();

            int currentSubjectIdx = this.subjectComboBox.SelectedIndex;
            string currentSubject = this.subjectComboBox.SelectedItem.ToString();
            string currentGroup = this.groupComboBox.SelectedItem.ToString();

            Student newStudent = new Student();

            // Если уже существует другой студент, то добавляем нового с известными данными о преподавателе и экзаменаторе.
            if (students[currentGroup].Count > 0)
            {
                newStudent.Grades = new List<GuidPair> { new GuidPair {
                                                                    Name = currentSubject,
                                                                    SubjectGUID = subjects[currentSubject],
                                                                    ExaminerGUID = students[currentGroup][0].Grades[currentSubjectIdx].ExaminerGUID,
                                                                    TeacherGUID = students[currentGroup][0].Grades[currentSubjectIdx].TeacherGUID
                                                                   } };
            }
            else // Иначе добавлением только предмет
            {
                newStudent.Grades = new List<GuidPair> { new GuidPair {
                                                                    Name = currentSubject,
                                                                    SubjectGUID = subjects[currentSubject]
                                                                   } };
            }

            newStudent.GenerateGUID();

            students[currentGroup].Add(newStudent);

            int col = 1;
            int row = this.studentsTable.Rows.Count - 1;
            this.studentsTable.Rows[row].Cells[col++].Value = this.subjectComboBox.SelectedItem;

            if (newStudent.Grades[currentSubjectIdx].TeacherGUID != new Guid())
                this.studentsTable.Rows[row].Cells[col].Value = teachers[newStudent.Grades[currentSubjectIdx].TeacherGUID].Name;
            else
                this.studentsTable.Rows[row].Cells[col].Value = "Отсутствует";

            col++;

            if (newStudent.Grades[currentSubjectIdx].ExaminerGUID != new Guid())
                this.studentsTable.Rows[row].Cells[col].Value = teachers[newStudent.Grades[currentSubjectIdx].ExaminerGUID].Name;
            else
                this.studentsTable.Rows[row].Cells[col].Value = "Отсутствует";

            col++;

            this.studentsTable.Rows[row].Cells[col++].Value = newStudent.Grades[currentSubjectIdx].TermGrade;
            this.studentsTable.Rows[row].Cells[col++].Value = newStudent.Grades[currentSubjectIdx].ExamGrade;
            this.studentsTable.Rows[row].Cells[col++].Value = newStudent.Grades[currentSubjectIdx].TotalGrade;
        }

        /// <summary>
        /// Функция, привязанная к кнопке removeStudentBtn: удаляет студента из списка, а также таблицы студентов.
        /// </summary>
        private void removeStudentBtn_Click(object sender, EventArgs e)
        {
            // Если выбраная пуская ячейка - выходим
            if (this.studentsTable.CurrentRow == null || this.groupComboBox.SelectedItem == null)
                return;

            try
            {
                students[this.groupComboBox.SelectedItem.ToString()].RemoveAt(this.studentsTable.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                ;
            }

            this.studentsTable.Rows.RemoveAt(this.studentsTable.CurrentRow.Index);
        }

        /// <summary>
        /// Функция, привязанная к кнопке subjectAddBtn: поднимает окно с добавлением нового предмета.
        /// </summary>
        private void subjectAddBtn_Click(object sender, EventArgs e)
        {
            AddNew addNewDialog = new AddNew("Добавить предмет", "Предмет");

            if (addNewDialog.ShowDialog(this) == DialogResult.OK)
            {
                Console.WriteLine("Created");
            }

            addNewDialog.Dispose();

            string subject = addNewDialog.GetText();
            if (subject != "")
                subjects.Add(subject, Guid.NewGuid());

            FillSubjectTable();

            mainModule.SaveSubjects(subjects);
        }

        /// <summary>
        /// Функция, привязанная к кнопке subjectDelBtn: удаляет предмет из списка и таблицы.
        /// </summary>
        private void subjectDelBtn_Click(object sender, EventArgs e)
        {
            subjects.Remove(this.subjectTable.Rows[this.subjectTable.CurrentRow.Index].Cells[0].Value.ToString());
            
            this.subjectTable.Rows.RemoveAt(this.subjectTable.CurrentRow.Index);

            mainModule.SaveSubjects(subjects);
        }

        /// <summary>
        /// Функция, привязанная к кнопке removeGroupBtn: удаляет группу со всеми её студентами из списка students.
        /// </summary>
        private void removeGroupBtn_Click(object sender, EventArgs e)
        {
            if (this.groupComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            students.Remove(this.groupComboBox.SelectedItem.ToString());

            FillGroupComboBox();

            if (this.groupComboBox.Items.Count > 0)
                this.groupComboBox.SelectedIndex = 0;
            else
                this.groupComboBox.Text = "";

            this.subjectComboBox.Items.Clear();
            this.subjectComboBox.Text = "";

            this.studentsTable.Rows.Clear();

            mainModule.SaveStudents(students);
        }

        /// <summary>
        /// Функция, привязнная к кнопке changeGroupNameBtn: поднимает окно с редактированием названия группы.
        /// </summary>
        private void changeGroupNameBtn_Click(object sender, EventArgs e)
        {
            if (this.groupComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddNew addNew = new AddNew("Переименование", "Имя");

            addNew.SetTextBox(this.groupComboBox.SelectedItem.ToString());

            if (addNew.ShowDialog(this) == DialogResult.OK)
            {
                Console.WriteLine("Created");
            }

            addNew.Dispose();

            string group = addNew.GetText();
            if (group != "")
            {
                int pos = this.groupComboBox.SelectedIndex;

                List<Student> copyList = new List<Student>(students[this.groupComboBox.SelectedItem.ToString()]);
                students.Remove(this.groupComboBox.SelectedItem.ToString());
                students[group] = copyList;

                FillGroupComboBox();

                this.groupComboBox.SelectedIndex = pos;
            }
        }

        /// <summary>
        /// EventHandler для таблицы allTeachersTable: привязывает к ComboBox функцию при изменении индекса.
        /// </summary>
        private void allTeachersTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.allTeachersTable.CurrentCell.ColumnIndex == 1)
            {
                ComboBox teacherSubjectsComboBox = e.Control as ComboBox;
                teacherSubjectsComboBox.SelectedIndexChanged += new EventHandler(teacherSubjectsComboBox_SelectedIndexChanged);
            }
        }

        /// <summary>
        /// Функция, привязанная к событию входа в режим редактирования таблицы студетов: обновляет статус ввода пользователем.
        /// </summary>
        private void studentsTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            USER_INPUT = true;
        }

        /// <summary>
        /// Функция, привязанная к выпадающему меню в таблицу allTeachersTable: выводит данные относительно выбранного предмета.
        /// </summary>
        private void teacherSubjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row = this.allTeachersTable.CurrentCell.RowIndex;
            int lastCol = this.allTeachersTable.Columns.Count - 1;
            Guid currentGuid = (Guid)this.allTeachersTable.Rows[row].Cells[lastCol].Value;

            this.allTeachersTable.Rows[row].Cells[2].Value = string.Join(";", teachers[currentGuid].Subjects[((ComboBox)sender).SelectedIndex].Groups.Keys);
            this.allTeachersTable.Rows[row].Cells[3].Value = teachers[currentGuid].Subjects[((ComboBox)sender).SelectedIndex].Rating;
        }

        /// <summary>
        /// Функция, привязанная к кнопке removeTeacherBtn: удаляет преподавателя из списка и таблицы.
        /// </summary>
        private void removeTeacherBtn_Click(object sender, EventArgs e)
        {
            int lastCol = this.allTeachersTable.Columns.Count - 1;
            if (this.allTeachersTable.CurrentCell != null)
            {
                int pos = this.allTeachersTable.CurrentCell.RowIndex;
                teachers.Remove((Guid)this.allTeachersTable.Rows[pos].Cells[lastCol].Value);
                this.allTeachersTable.Rows.RemoveAt(pos);
            }
        }

        /// <summary>
        /// Функция, привязанная к событию входа в режим редактирования таблицы преподавателей: обновляет статус ввода пользователем.
        /// </summary>
        private void allTeachersTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            USER_INPUT = true;
        }

        /// <summary>
        /// Функция, привязанная к редактированию ячейки в таблице всех преподавателей: обновляет данные.
        /// </summary>
        private void allTeachersTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (USER_INPUT)
            {
                int row = this.allTeachersTable.CurrentCell.RowIndex;
                int col = this.allTeachersTable.CurrentCell.ColumnIndex;
                int lastCol = this.allTeachersTable.Columns.Count - 1;
                Guid currentGuid = (Guid)this.allTeachersTable.Rows[row].Cells[lastCol].Value;

                if (col == 0)
                {
                    teachers[currentGuid].Name = this.allTeachersTable.Rows[row].Cells[0].Value.ToString().Trim();
                }

                USER_INPUT = false;
            }
        }

        /// <summary>
        /// Функция, привязанная к кнопке changeTeacherSubjectsBtn: поднимает форму для обновления предметов и групп у выбранного преподавателя.
        /// </summary>
        private void changeTeacherSubjectsBtn_Click(object sender, EventArgs e)
        {
            if (this.allTeachersTable.CurrentCell != null)
            {
                int row = this.allTeachersTable.CurrentCell.RowIndex;
                int lastCol = this.allTeachersTable.Columns.Count - 1;
                Guid currentGuid = (Guid)this.allTeachersTable.Rows[row].Cells[lastCol].Value;
                
                // Создаём окно
                AddSubjectsToTeacher addSubjects = new AddSubjectsToTeacher(subjects, teachers[currentGuid], students.Keys.ToList());

                if (addSubjects.ShowDialog(this) == DialogResult.OK)
                {
                    Console.WriteLine("Created");
                }

                addSubjects.Dispose();

                // Получаем ссылку на ComboBoxCell и меняем в ней данные.
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)this.allTeachersTable.Rows[row].Cells[1];
                if (teachers[currentGuid].Subjects.Count > 0)
                {
                    comboBoxCell.Items.Clear();
                    foreach (var subject in teachers[currentGuid].Subjects)
                    {
                        comboBoxCell.Items.Add(subject.Name);
                    }

                    comboBoxCell.Value = comboBoxCell.Items[0];
                    this.allTeachersTable.Rows[row].Cells[2].Value = string.Join(";", teachers[currentGuid].Subjects[0].Groups.Keys);
                }
                else
                {
                    comboBoxCell.Value = "";
                    comboBoxCell.Items.Clear();
                    this.allTeachersTable.Rows[row].Cells[2].Value = "";
                }

                mainModule.SaveTeachers(teachers);
            }
            else
                MessageBox.Show("Вы не выбрали преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Функция, привязанная к событию входа в режим редактирования таблицы предметов: обновляет статус ввода пользователем.
        /// </summary>
        private void subjectTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            USER_INPUT = true;
        }

        /// <summary>
        /// Функция, привязанная к редактированию ячейки в таблице всех предметов: обновляет данные.
        /// </summary>
        private void subjectTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (USER_INPUT && this.subjectTable.CurrentCell != null)
            {
                int row = this.subjectTable.CurrentCell.RowIndex;

                // Меняем местами ключ-значения для удобства получения имени предмета для последующей его замены.
                var swappedSubjects = subjects.ToDictionary(x => x.Value, x => x.Key);

                Guid guidOfChangedSubject = (Guid)this.subjectTable.Rows[row].Cells[1].Value;

                swappedSubjects[guidOfChangedSubject] = this.subjectTable.CurrentCell.Value.ToString();

                // Возвращаем обратно
                subjects = swappedSubjects.ToDictionary(x => x.Value, x => x.Key);

                mainModule.SaveSubjects(subjects);

                // Производим замену имени предмета для всех студентов, у кого был данный предмет.
                foreach (var group in students)
                {
                    foreach (var student in group.Value)
                    {
                        foreach (var subject in student.Grades)
                        {
                            // Если нашли предмет в списке студента по GUID, заменяем имя и идём к след студенту.
                            if (subject.SubjectGUID == guidOfChangedSubject)
                            {
                                subject.Name = swappedSubjects[guidOfChangedSubject];
                                break;
                            }
                        }
                    }
                }

                // Обновляем список предметов у группы.
                int currentSubjectComboBoxPos = this.subjectComboBox.SelectedIndex;
                
                this.subjectComboBox.Items.Clear();

                if (this.groupComboBox.SelectedIndex != -1)
                {
                    foreach (var subject in students[this.groupComboBox.SelectedItem.ToString()][0].Grades)
                    {
                        this.subjectComboBox.Items.Add(subject.Name);
                    }

                    this.subjectComboBox.SelectedIndex = currentSubjectComboBoxPos;
                }

                // Производим замену имени предмета для всех преподавателей, у кого был данный предмет.
                foreach (var teacher in teachers)
                {
                    foreach (var subject in teacher.Value.Subjects)
                    {
                        // Если нашли предмет в списке преподавателя по GUID, заменяем и идём к след преподу.
                        if (subject.GUID == guidOfChangedSubject)
                        {
                            subject.Name = swappedSubjects[guidOfChangedSubject];
                            break;
                        }
                    }
                }
                
                // Обновляем таблицу всех преподавателей. 
                FillAllTeachersTable();

                USER_INPUT = false;
            }
        }

        /// <summary>
        /// EventHandler для таблицы suggestionTeachersTable: привязывает к ComboBox функцию при изменении индекса.
        /// </summary>
        private void suggestionTeachersTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.suggestionTeachersTable.CurrentCell.ColumnIndex == 1 || this.suggestionTeachersTable.CurrentCell.ColumnIndex == 2)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += new EventHandler(comboBox_selectedIndexChanged);
            }

        }

        /// <summary>
        /// Функция, привязанная к выпадающему меню в таблице suggestionTeachersTable: выводит данные относительно выбранного предмета, 
        /// а также назначает семинариста/экзаменатора для всей группы.
        /// </summary>
        private void comboBox_selectedIndexChanged(object sender, EventArgs e)
        {
            int row = this.suggestionTeachersTable.CurrentCell.RowIndex;
            int col = this.suggestionTeachersTable.CurrentCell.ColumnIndex;
            int lastCol = this.suggestionTeachersTable.Columns.Count - 1;

            int currentSubjectIdx = this.subjectComboBox.SelectedIndex;
            string currentGroup = this.groupComboBox.SelectedItem.ToString();
            Guid currentGuid = (Guid)this.suggestionTeachersTable.Rows[row].Cells[lastCol].Value;

            int currentSubjectTeacherIdx = -1;

            for (int i = 0; i < teachers[currentGuid].Subjects.Count; i++)
            {
                if (teachers[currentGuid].Subjects[i].GUID == students[currentGroup][0].Grades[currentSubjectIdx].SubjectGUID)
                {
                    currentSubjectTeacherIdx = i;
                    break;
                }
            }

            if (currentSubjectTeacherIdx == -1) // Предмета нет, выходим
                return;

            switch (col)
            {
                case 1: // Если столбик "Семинарист"
                    if (((ComboBox)sender).Text == ANSWERS[0])
                    {
                        if (this.suggestionTeachersTable.Rows[row].Cells[2].Value.ToString() == ANSWERS[1])
                        {
                            foreach (var student in students[currentGroup])
                            {
                                student.Grades[currentSubjectIdx].TeacherGUID = currentGuid;
                            }

                            if (!teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.ContainsKey(currentGroup))
                            {
                                teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.Add(currentGroup, 0);
                            }
                        }
                        else
                        {
                            this.suggestionTeachersTable.Rows[row].Cells[2].Value = ANSWERS[1];
                            foreach (var student in students[currentGroup])
                            {
                                student.Grades[currentSubjectIdx].TeacherGUID = currentGuid;
                                student.Grades[currentSubjectIdx].ExaminerGUID = new Guid(); // Зануляем GUID экзаменатора, т.к. экзаменатор не может быть ещё и семинаристом.
                            }

                            if (!teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.ContainsKey(currentGroup))
                            {
                                teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.Add(currentGroup, 0);
                            }
                        }

                        // Выставляем всем другим учителям значение семинариста "нет".
                        for (int tempRow = 0; tempRow < this.suggestionTeachersTable.Rows.Count; tempRow++)
                        {
                            if (tempRow != row)
                            {
                                this.suggestionTeachersTable.Rows[tempRow].Cells[col].Value = ANSWERS[1];
                            }
                        }
                    }
                    else
                    {
                        foreach (var student in students[currentGroup])
                        {
                            student.Grades[currentSubjectIdx].TeacherGUID = new Guid();
                        }

                        if (teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.ContainsKey(currentGroup))
                        {
                            teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.Remove(currentGroup);
                        }
                    }
                    break;
                case 2: // Если столбик "Экзаменатор"
                    if (((ComboBox)sender).Text == ANSWERS[0])
                    {
                        if (this.suggestionTeachersTable.Rows[row].Cells[1].Value.ToString() == ANSWERS[1])
                        {
                            foreach (var student in students[currentGroup])
                            {
                                student.Grades[currentSubjectIdx].ExaminerGUID = currentGuid;
                            }
                        }
                        else
                        {
                            foreach (var student in students[currentGroup])
                            {
                                student.Grades[currentSubjectIdx].TeacherGUID = new Guid(); // Зануляем GUID семанириста, т.к. семинарист не может быть ещё и экзаменатором.
                                student.Grades[currentSubjectIdx].ExaminerGUID = currentGuid;
                            }

                            this.suggestionTeachersTable.Rows[row].Cells[1].Value = ANSWERS[1];

                            if (teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.ContainsKey(currentGroup))
                            {
                                teachers[currentGuid].Subjects[currentSubjectTeacherIdx].Groups.Remove(currentGroup);
                            }
                        }

                        // Выставляем всем другим учителям значение экзаменатора "нет".
                        for (int tempRow = 0; tempRow < this.suggestionTeachersTable.Rows.Count; tempRow++)
                        {
                            if (tempRow != row)
                            {
                                this.suggestionTeachersTable.Rows[tempRow].Cells[col].Value = ANSWERS[1];
                            }
                        }
                    }
                    else
                    {
                        foreach (var student in students[currentGroup])
                        {
                            student.Grades[currentSubjectIdx].ExaminerGUID = new Guid();
                        }
                    }
                    break;
            }


            // Обновляем данные в таблице студентов.
            int _row = 0;
            foreach (var student in students[currentGroup])
            {
                int _col = 2;
                
                if (student.Grades[currentSubjectIdx].TeacherGUID != new Guid())
                    this.studentsTable.Rows[_row].Cells[_col].Value = teachers[student.Grades[currentSubjectIdx].TeacherGUID].Name;
                else
                    this.studentsTable.Rows[_row].Cells[_col].Value = "Отсутствует";

                _col++;

                if (student.Grades[currentSubjectIdx].ExaminerGUID != new Guid())
                    this.studentsTable.Rows[_row].Cells[_col].Value = teachers[student.Grades[currentSubjectIdx].ExaminerGUID].Name;
                else
                    this.studentsTable.Rows[_row].Cells[_col].Value = "Отсутствует";

                _col++;

                _row++;
            }

            // Обновляем таблицу всех преподавателей.
            FillAllTeachersTable();
        }

        /// <summary>
        /// Функция, привязанная к кнопке addTeacherBtn: добавляет нового преподавателя в список и в таблицу.
        /// </summary>
        private void addTeacherBtn_Click(object sender, EventArgs e)
        {
            this.allTeachersTable.Rows.Add();

            int lastRow = this.allTeachersTable.Rows.Count - 1;
            int lastCol = this.allTeachersTable.Columns.Count - 1;

            Guid newGuid = Guid.NewGuid();

            teachers.Add(newGuid, new Teacher { GUID = newGuid });

            this.allTeachersTable.Rows[lastRow].Cells[lastCol].Value = newGuid;
        }
    }
}