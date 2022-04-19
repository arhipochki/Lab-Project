using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SecondProgLab
{
    /// <summary>
    /// Данный модуль выступает в роли загрузчика из JSON, а также сохраняет данные в JSON формате.
    /// </summary>
    internal class MainModule
    {
        /// <summary>
        /// Функция загрузки студентов.
        /// </summary>
        /// <returns>Возвращает словарь из группы и списка студентов в группе (List Student).</returns>
        public Dictionary<string, List<Student>> LoadStudents()
        {
            string _fileName = "Students.json";

            if (!File.Exists(_fileName))
            {
                // Возможно, создать файл с 1 элементом с пустыми значениями.
                return new Dictionary<string, List<Student>>();
            }

            var _jsonString = File.ReadAllText("Students.json");
            
            return JsonConvert.DeserializeObject<Dictionary<string, List<Student>>>(_jsonString);
        }

        /// <summary>
        /// Функция загрузки преподавателей.
        /// </summary>
        /// <returns>Возвращает словарь из уникального id для учителя и класса Teacher.</returns>
        public Dictionary<Guid, Teacher> LoadTeachers()
        {
            string _fileName = "GuidTeachers.json";

            if (!File.Exists (_fileName))
            {
                return new Dictionary<Guid, Teacher>();
            }

            var _jsonString = File.ReadAllText(_fileName);

            return JsonConvert.DeserializeObject<Dictionary<Guid, Teacher>>(_jsonString);
        }
        /// <summary>
        /// Функция загрузки предметов.
        /// </summary>
        /// <returns>Возвращает словарь из наименования предмета и его уникального id.</returns>
        public Dictionary<string, Guid> LoadSubjects()
        {
            string _fileName = "SubjectsGuid.json";

            if (!File.Exists(_fileName))
            {
                return new Dictionary<string, Guid>();
            }

            var _jsonString = File.ReadAllText(_fileName);

            return JsonConvert.DeserializeObject<Dictionary<string, Guid>>(_jsonString);
        }

        /// <summary>
        /// Сохраняет словарь студентов в JSON файл.
        /// </summary>
        /// <param name="students">Словарь студентов</param>
        public void SaveStudents(Dictionary<string, List<Student>> students)
        {
            string _fileName = "Students.json";

            string _jsonString = JsonConvert.SerializeObject(students, Formatting.Indented);

            File.WriteAllText(_fileName, _jsonString);
        }

        /// <summary>
        /// Сохраняет словарь преподавателей в JSON файл.
        /// </summary>
        /// <param name="teachers">Словарь преподавателей</param>
        public void SaveTeachers(Dictionary<Guid, Teacher> teachers)
        {
            string _fileName = "GuidTeachers.json";

            string _jsonString = JsonConvert.SerializeObject(teachers, Formatting.Indented);

            File.WriteAllText(_fileName, _jsonString);
        }

        /// <summary>
        /// Сохраняет словарь предметов в JSON файл.
        /// </summary>
        /// <param name="subjects">Словарь предметов</param>
        public void SaveSubjects(Dictionary<string, Guid> subjects)
        {
            string _fileName = "SubjectsGuid.json";

            string _jsonString = JsonConvert.SerializeObject(subjects, Formatting.Indented);

            File.WriteAllText(_fileName, _jsonString);
        }
    }
}
