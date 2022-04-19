using System;
using System.Collections.Generic;

namespace SecondProgLab
{
    /// <summary>
    /// Класс студента.
    /// </summary>
    public class Student : BaseInfo
    {
        
        private string _group = "";
        /// <remarks name = "Group" > Группа, к которой принадлежит студент. </remarks>
        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        private List<GuidPair> _grades = new List<GuidPair>();
        /// <remarks name = "Grades" > Список предметов, связанных с преподавателями, с баллами по каждому предмету. </remarks>
        public List<GuidPair> Grades
        {
            get { return _grades; }
            set { _grades = value; }
        }

        private double _rating = 0;
        /// <remarks name = "Rating" > Рейтинг студента, основывается на количестве предметов и баллам по этим предметам. </remarks>
        public new double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        /// <remarks name = "CalculateRating()" > Рейтинг студента высчитывается как среднее значение по всем предметам, сумма всех баллов (сумма всех TotalGrade) поделить на количество предметов.</remarks>
        public void CalculateRating()
        {
            _rating = 0;

            foreach (var subject in _grades)
            {
                _rating += subject.TotalGrade;
            }

            _rating = Math.Round(_rating / _grades.Count, 4);
        }
    }
}