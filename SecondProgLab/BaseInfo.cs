using System;

namespace SecondProgLab
{
    /// <summary>
    /// Данный класс используется в качестве основного для последующих классов Student и Teacher
    /// Основные поля:
    /// </summary>
    public class BaseInfo : IName, IGUID, IRating
    {
        private string _name = "";
        /// <remarks name="Name">Имя</remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _rating = 0;
        /// <remarks name="Rating">Рейтинг</remarks>
        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        private Guid _guid = new Guid();
        /// <remarks name="GUID" >Уникальный id</remarks>
        public Guid GUID
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <remarks name="GenerateGUID()" >Сгенерировать уникальный id</remarks>
        public void GenerateGUID()
        {
            _guid = Guid.NewGuid();
        }
    }
}
