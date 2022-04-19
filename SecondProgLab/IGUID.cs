using System;

namespace SecondProgLab
{
    /// <summary>
    /// Интерфейс, в котором заложен Guid и функция его генерации
    /// </summary>
    internal interface IGUID
    {
        Guid GUID { get; }
        void GenerateGUID();
    }
}
