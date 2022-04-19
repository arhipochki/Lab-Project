using System;
using System.Collections.Generic;

namespace SecondProgLab
{
    /// <summary>
    /// Класс предмета, используется в классе Teacher.
    /// </summary>
    public class Subject : IName
    {
        private string _name = "";
        /// <remarks name="Name">Название предмета.</remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Guid _guid = new Guid();
        /// <remarks name="GUID">Уникальный id предмета.</remarks>
        public Guid GUID
        {
            get { return _guid; }
            set { _guid = value; }
        }

        private double _rating = 0;
        /// <remarks name="Rating">Рейтинг по данному предмету.</remarks>
        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        private Dictionary<string, double> _group = new Dictionary<string, double>();
        /// <remarks name="Groups">У каких групп данный предмет.</remarks>
        public Dictionary<string, double> Groups
        {
            get { return _group; }
            set { _group = value; }
        }

        /// <remarks name="CalculateRating()">Подсчёт рейтинга как среднее от суммы средних баллов по группе, делённое на количество групп .</remarks>
        public void CalculateRating()
        {
            _rating = 0;

            foreach (var group in _group)
            {
                _rating += group.Value;
            }

            _rating = Math.Round(_rating / _group.Count, 4);
        }
    }
}
