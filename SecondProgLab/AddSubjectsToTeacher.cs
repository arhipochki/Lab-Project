using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecondProgLab
{
    /// <summary>
    /// Форма для работы с преподавателем.
    /// </summary>
    public partial class AddSubjectsToTeacher : Form
    {
        private List<string> copyAllGroups;                 // Копия всех групп.
        private Dictionary<string, Guid> copyAllSubjects;   // Копия всех предметов.
        private Teacher pointerTeacher;                     // Указатель на конкретного учителя.

        /// <summary>
        /// Конструктор формы, принимает 3 аргумента.
        /// </summary>
        /// <param name="allSubjects">Список всех предметов.</param>
        /// <param name="teacher">Указатель на учителя для редакции.</param>
        /// <param name="allGroups">Список всех групп.</param>
        public AddSubjectsToTeacher(Dictionary<string, Guid> allSubjects, Teacher teacher, List<string> allGroups)
        {
            InitializeComponent();

            // Создаём копию всех предметов, чтобы не поломать основной словарь.
            copyAllSubjects = new Dictionary<string, Guid>(allSubjects);

            // Создаём ссылку на список предметов преподавателя.
            pointerTeacher = teacher;

            // Создаём копию всех всех групп.
            copyAllGroups = new List<string>(allGroups);

            // Заполняем таблицы, выпадающий список.
            FillAllSubjectsTable();
            FillTeacherSubjectsTable();
            FillTeacherSubjectsComboBox();
        }

        /// <summary>
        /// Функция заполнения таблицы предметов преподавателя.
        /// </summary>
        private void FillTeacherSubjectsTable()
        {
            this.teacherSubjectsTable.Rows.Clear();

            // Т.к. количество строк в таблице не может быть равно 0, проверяем количество предметов у преподавателя.
            if (pointerTeacher.Subjects.Count == 0)
                this.teacherSubjectsTable.RowCount = 1;
            else
                this.teacherSubjectsTable.RowCount = pointerTeacher.Subjects.Count;

            // Заполняем таблицу предметов преподавателя: имя, id предмета.
            int _row = 0;
            foreach (var subject in pointerTeacher.Subjects)
            {
                int _col = 0;

                this.teacherSubjectsTable.Rows[_row].Cells[_col++].Value = subject.Name;
                this.teacherSubjectsTable.Rows[_row].Cells[_col++].Value = subject.GUID;

                _row++;
            }
        }

        /// <summary>
        /// Функция заполнения таблицы всех предметов.
        /// </summary>
        private void FillAllSubjectsTable()
        {
            // Делаем выборку только тех предметов, которых нет у преподавателя.
            try
            {
                foreach (var subject in pointerTeacher.Subjects)
                {
                    copyAllSubjects.Remove(subject.Name);
                }
            }
            catch (Exception ex)
            {
                pointerTeacher.Subjects.Add(new Subject());
            }

            this.allSubjectsTable.Rows.Clear();

            // Т.к. количество строк в таблице не может быть равно 0, проверяем количество оставшихся предметов.
            if (copyAllSubjects.Count == 0)
                this.allSubjectsTable.RowCount = 1;
            else
                this.allSubjectsTable.RowCount = copyAllSubjects.Count;

            // Заполняем таблицу всех доступных предметов: имя, id предмета.
            int _row = 0;
            foreach (var subject in copyAllSubjects)
            {
                int _col = 0;

                this.allSubjectsTable.Rows[_row].Cells[_col++].Value = subject.Key;
                this.allSubjectsTable.Rows[_row].Cells[_col++].Value = subject.Value;

                _row++;
            }
        }

        /// <summary>
        /// Функция заполнения выпадающего меню со списком предметов преподавателя.
        /// </summary>
        private void FillTeacherSubjectsComboBox()
        {
            this.teacherSubjectsComboBox.Items.Clear();
            this.teacherSubjectsComboBox.Text = "";
            foreach (var subject in pointerTeacher.Subjects)
            {
                this.teacherSubjectsComboBox.Items.Add(subject.Name);
            }

            // Если есть хотя бы 1 предмет, то выставялем первый предмет как выбранный.
            if (pointerTeacher.Subjects.Count > 0)
                this.teacherSubjectsComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Функция, привязанная к кнопке addBtn: добавляет предмет к списку предметов преподавателя.
        /// </summary>
        private void addBtn_Click(object sender, EventArgs e)
        {
            int row = 0;
            // Выходим, когда не выбрано поле, а кнопка была нажата.
            if (this.allSubjectsTable.Rows[row].Cells[0].Value == null) 
                return;

            // Если выбрали ячейку, то получаем её номер строки.
            if (this.allSubjectsTable.CurrentCell != null)
                row = this.allSubjectsTable.CurrentCell.RowIndex;

            // Создаём новый предмет, который будет добавлен к списку преподавателя.
            Subject newSubject = new Subject();

            newSubject.Name = this.allSubjectsTable.Rows[row].Cells[0].Value.ToString();
            newSubject.GUID = copyAllSubjects[newSubject.Name];

            pointerTeacher.Subjects.Add(newSubject);

            // Обновляем таблицы, выпадающее меню.
            FillAllSubjectsTable();
            FillTeacherSubjectsTable();
            FillTeacherSubjectsComboBox();
        }

        /// <summary>
        /// Функция, привязанная к кнопке removeBtn: удаляет предмет из списка предметов преподавателя.
        /// </summary>
        private void removeBtn_Click(object sender, EventArgs e)
        {
            int pos = 0;
            // Если выбрали ячейку, то получаем её номер строки.
            if (this.teacherSubjectsTable.CurrentCell != null)
                pos = this.teacherSubjectsTable.CurrentCell.RowIndex;

            try
            {   // Ловим ошибку, когда наш список пустой.
                copyAllSubjects.Add(pointerTeacher.Subjects[pos].Name, pointerTeacher.Subjects[pos].GUID);

                pointerTeacher.Subjects.RemoveAt(pos);

                // Обновляем таблицы, выпадающее меню.
                FillAllSubjectsTable();
                FillTeacherSubjectsTable();
                FillTeacherSubjectsComboBox();
            }
            catch (Exception ex)
            {
                ; // Пропускаем ошибку.
            }
        }

        /// <summary>
        /// Функция заполняет таблицу всех доступных групп.
        /// </summary>
        private void FillAllGroupsTable()
        {
            // Индекс выбранного предмета.
            int currentSubjectIdx = this.teacherSubjectsComboBox.SelectedIndex;

            // Временный список групп.
            List<string> tempList = new List<string>(copyAllGroups);

            // Удаляем из временного списка групп те группы, которые уже в подчинении у преподавателя.
            foreach (var group in pointerTeacher.Subjects[currentSubjectIdx].Groups.Keys)
            {
                tempList.Remove(group);
            }

            this.allGroupsTable.Rows.Clear();

            // Т.к. количество строк в таблице не может быть равно 0, проверяем количество оставшихся групп.
            if (tempList.Count == 0)
                this.allGroupsTable.RowCount = 1;
            else
                this.allGroupsTable.RowCount = tempList.Count;

            int row = 0;
            // Заполняем таблицу доступными группами.
            foreach (var group in tempList)
            {
                this.allGroupsTable.Rows[row].Cells[0].Value = group;
                row++;
            }
        }

        /// <summary>
        /// Функция заполнения таблицы групп, который находятся в попечении преподавателя.
        /// </summary>
        private void FillTeacherGroupsTable()
        {
            int pos = this.teacherSubjectsComboBox.SelectedIndex;
            if (pos == -1) // Если в выпадающем меню ничего не выбрано - выходим.
                return;

            this.currentSubjectGroupsTable.Rows.Clear();

            // Т.к. количество строк в таблице не может быть равно 0, проверяем количество групп.
            if (pointerTeacher.Subjects[pos].Groups.Count == 0)
                this.currentSubjectGroupsTable.RowCount = 1;
            else
                this.currentSubjectGroupsTable.RowCount = pointerTeacher.Subjects[pos].Groups.Count;
            
            int row = 0;
            foreach (var group in pointerTeacher.Subjects[pos].Groups.Keys)
            {
                this.currentSubjectGroupsTable.Rows[row].Cells[0].Value = group;
                row++;
            }
        }

        /// <summary>
        /// Функция, привязанная к кнопке addGroupBtn: добавляет группу в список групп преподавателя по конкретному предмету. 
        /// </summary>
        private void addGroupBtn_Click(object sender, EventArgs e)
        {
            int row = 0;
            int currentSubject = this.teacherSubjectsComboBox.SelectedIndex;

            // Выходим, когда не выбрано поле, а кнопка была нажата или если в выпадающем меню ничего не выбрано.
            if (this.allGroupsTable.Rows[row].Cells[0].Value == null || currentSubject == -1)
                return;

            // Если выбрали ячейку, то получаем её номер строки.
            if (this.allGroupsTable.CurrentCell != null)
                row = this.allGroupsTable.CurrentCell.RowIndex;

            // Добавляем группу.
            pointerTeacher.Subjects[currentSubject].Groups.Add(this.allGroupsTable.Rows[row].Cells[0].Value.ToString(), 0);

            // Обновляем таблицы.
            FillAllGroupsTable();
            FillTeacherGroupsTable();
        }

        /// <summary>
        /// Функция, привязанная к кнопке removeGroupBtn: удаляем группу из списка групп преподавателя по конкретному предмету.
        /// </summary>
        private void removeGroupBtn_Click(object sender, EventArgs e)
        {
            int row = 0;
            // Если выбрали ячейку, то получаем её номер строки.
            if (this.currentSubjectGroupsTable.CurrentCell != null)
                row = this.currentSubjectGroupsTable.CurrentCell.RowIndex;

            try // Ловим ошибку, когда наш список пустой.
            {   
                int currentSubject = this.teacherSubjectsComboBox.SelectedIndex;
                // Выходим, когда не выбрано поле, а кнопка была нажата или если в выпадающем меню ничего не выбрано.
                if (currentSubject == -1 || this.currentSubjectGroupsTable.Rows[row].Cells[0].Value == null)
                    return;

                string currentGroup = this.currentSubjectGroupsTable.Rows[row].Cells[0].Value.ToString();

                // Если в копии групп нет выбранной, тогда добавляем. Нужно это будет для правильного заполнения таблиц.
                if (!copyAllGroups.Contains(currentGroup))
                    copyAllGroups.Add(currentGroup);

                // Из списка групп преподавателя удаляем.
                pointerTeacher.Subjects[currentSubject].Groups.Remove(currentGroup);

                // Обновляем таблицы.
                FillAllGroupsTable();
                FillTeacherGroupsTable();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        /// <summary>
        /// Функция, привязанная к событию изменения индекса в выпадающем меню: обновляет таблицы.
        /// </summary>
        private void teacherSubjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAllGroupsTable();
            FillTeacherGroupsTable();
        }
    }
}
