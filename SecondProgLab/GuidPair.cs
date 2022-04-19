using System;

namespace SecondProgLab
{
    /// <summary>
    /// Данный класс используется для связки предмета, преподавателя, экзаментора со студентом.
    /// </summary>
    public class GuidPair
    {
        private string _name = "";
        /// <remarks name="Name">Имя предмета.</remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Guid _subjectGUID = new Guid();
        /// <remarks name="SubjectGUID">Уникальный id предмета.</remarks>
        public Guid SubjectGUID
        {
            get { return _subjectGUID; }
            set { _subjectGUID = value; }
        }

        private Guid _teacherGUID = new Guid();
        /// <remarks name="TeacherGUID">id преподавателя.</remarks>
        public Guid TeacherGUID
        {
            get { return _teacherGUID; }
            set { _teacherGUID = value; }
        }

        private Guid _examinerGUID = new Guid();
        /// <remarks name="ExaminerGUID">id экзаменатора.</remarks>
        public Guid ExaminerGUID
        {
            get { return _examinerGUID; }
            set { _examinerGUID = value; }
        }

        private int _termGrade = 0;
        /// <remarks name="TermGrade">Оценка за семестр.</remarks>
        public int TermGrade
        {
            get { return _termGrade; }
            set { _termGrade = value; }
        }

        private int _examGrade = 0;
        /// <remarks name="ExamGrade">Оценка за экзамен.</remarks>
        public int ExamGrade
        {
            get { return _examGrade; }
            set { _examGrade = value; }
        }

        private int _totalGrade = 0;
        /// <remarks name="TotalGrade">Суммарный балл.</remarks>
        public int TotalGrade
        {
            get { return _totalGrade; }
            set { _totalGrade = value; }
        }

        /// <remarks name="CalculateGrade()">Функция расчёта суммарного балла (TotalGrade)</remarks>
        public void CalculateGrade()
        {
            _totalGrade = _termGrade + _examGrade;
        }
    }
}
