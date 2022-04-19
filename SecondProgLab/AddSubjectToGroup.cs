using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecondProgLab
{
    /// <summary>
    /// Форма для добавления предмета в список предметов группы.
    /// </summary>
    public partial class AddSubjectToGroup : Form
    {
        private Dictionary<string, Guid> copyAllSubjects;   // Копия всех предметов.
        private List<Student> pointerStudents;              // Указатель на список студентов.

        /// <summary>
        /// Конструктор формы, принимает 2 аргумента.
        /// </summary>
        /// <param name="allSubjects">Словарь всех предметов.</param>
        /// <param name="students">Список студентов группы.</param>
        public AddSubjectToGroup(Dictionary<string, Guid> allSubjects, List<Student> students)
        {
            InitializeComponent();

            // Создаём копию всех предметов, чтобы не поломать основной словарь.
            copyAllSubjects = new Dictionary<string, Guid>(allSubjects);

            // Создаём ссылку на список студентов.
            pointerStudents = students;

            // Заполняем таблицы.
            FillAllSubjectsTable();
            FillGroupSubjectsTable();
        }

        /// <summary>
        /// Функция заполнения таблицы всех доступных для выбора предметорв.
        /// </summary>
        private void FillAllSubjectsTable()
        {
            // Делаем выборку только тех предметов, которых нет у группы.
            try
            {
                foreach (var subject in pointerStudents[0].Grades)
                {
                    copyAllSubjects.Remove(subject.Name);
                }
            }
            catch (Exception ex)
            {
                pointerStudents.Add(new Student());
            }

            this.allSubjectsTable.Rows.Clear();

            // Т.к. количество строк в таблице не может быть равно 0, проверяем количество оставшихся предметов.
            if (copyAllSubjects.Count == 0)
                this.allSubjectsTable.RowCount = 1;
            else
                this.allSubjectsTable.RowCount = copyAllSubjects.Count;

            int _row = 0;
            // Заполняем таблицу как: название предмета, id предмета.
            foreach (var subject in copyAllSubjects)
            {
                int _col = 0;

                this.allSubjectsTable.Rows[_row].Cells[_col++].Value = subject.Key;
                this.allSubjectsTable.Rows[_row].Cells[_col++].Value = subject.Value;

                _row++;
            }
        }

        /// <summary>
        /// Функция заполнения списка предметов группы.
        /// </summary>
        private void FillGroupSubjectsTable()
        {
            this.groupSubjectsTable.Rows.Clear();

            // Т.к. количество строк в таблице не может быть равно 0, проверяем количество предметов группы.
            if (pointerStudents[0].Grades.Count == 0)
                this.groupSubjectsTable.RowCount = 1;
            else
                this.groupSubjectsTable.RowCount = pointerStudents[0].Grades.Count;

            int _row = 0;
            
            // Заполняем таблицу как: название предмета, id предмета.
            foreach (var subject in pointerStudents[0].Grades)
            {
                int _col = 0;

                this.groupSubjectsTable.Rows[_row].Cells[_col++].Value = subject.Name;
                this.groupSubjectsTable.Rows[_row].Cells[_col++].Value = subject.SubjectGUID;

                _row++;
            }
        }

        /// <summary>
        /// Функция, привязанная к кнопке addBtn: добавляет предмет в список предметов группы.
        /// </summary>
        private void addBtn_Click(object sender, EventArgs e)
        {
            int row = 0;
            // Если ячейка не выбрана, а кнока была нажата - выходим.
            if (this.allSubjectsTable.Rows[row].Cells[0].Value == null)
                return;

            // Получаем индекс строки выбранной ячейки
            if (this.allSubjectsTable.CurrentCell != null)
                row = this.allSubjectsTable.CurrentCell.RowIndex;

            // Создаём новый предмет
            GuidPair newSubject = new GuidPair();

            newSubject.Name = this.allSubjectsTable.Rows[row].Cells[0].Value.ToString();
            newSubject.SubjectGUID = copyAllSubjects[newSubject.Name];

            // Добавляем новый предмет для каждого студента группы.
            foreach (var student in pointerStudents)
            {
                student.Grades.Add(newSubject);
            }

            // Обновляем таблицы.
            FillGroupSubjectsTable();
            FillAllSubjectsTable();
        }

        /// <summary>
        /// Функция, привязанная к кнопке removeBtn: удаляет предмет из списка предметов группы.
        /// </summary>
        private void removeBtn_Click(object sender, EventArgs e)
        {
            int row = 0;
            // Получаем индекс строки выбранной ячейки.
            if (this.groupSubjectsTable.CurrentCell != null)
                row = this.groupSubjectsTable.CurrentCell.RowIndex;

            try // Ловим ошибку, когда наш список пустой.
            {   
                // Возвращаем предмет обратно в список всех предметов.
                copyAllSubjects.Add(pointerStudents[0].Grades[row].Name, pointerStudents[0].Grades[row].SubjectGUID);

                // У группы предмет удаляем.
                foreach (var student in pointerStudents)
                {
                    student.Grades.RemoveAt(row);
                }

                // Обновляем таблицы.
                FillGroupSubjectsTable();
                FillAllSubjectsTable();
            }
            catch (Exception ex)
            {
                ; // Пропускаем ошибку.
            }
        }
    }
}
