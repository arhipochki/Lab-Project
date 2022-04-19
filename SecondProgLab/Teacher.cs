using System;
using System.Collections.Generic;

namespace SecondProgLab
{
    /// <summary>
    /// Класс преподавателя.
    /// </summary>
    public class Teacher : BaseInfo
    {
        private List<Subject> _subjects = new List<Subject>();
        /// <remarks name="Subjects">Список всех предметов преподавателя.</remarks>
        public List<Subject> Subjects
        { 
            get { return _subjects; } 
            set { _subjects = value; }
        }

        /// <remarks name="Subjects">Подсчёт рейтинга преподавателя как сумма всех рейтингов по каждому предмету, делённое на их количество.</remarks>
        public void CalculateRating()
        {
            Rating = 0;

            foreach (var subject in Subjects)
            {
                Rating += subject.Rating;
            }

            Rating = Math.Round(Rating / Subjects.Count, 4);
        }
    }
}
