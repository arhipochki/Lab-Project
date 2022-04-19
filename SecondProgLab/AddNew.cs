using System;
using System.Windows.Forms;

namespace SecondProgLab
{
    /// <summary>
    /// Форма для ввода нового значения
    /// </summary>
    public partial class AddNew : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        /// <param name="title">Заголовок окна</param>
        /// <param name="label">Текск поля lable</param>
        public AddNew(string title, string label)
        {
            InitializeComponent();

            this.Text = title;
            this.label.Text = label;
        }

        /// <summary>
        /// Функция, которая вызывается по нажатию кнопки addBtn: сохраняет и закрвыет окно.
        /// </summary>
        private void addBtn_Click(object sender, EventArgs e)
        {
            // Если ввели какое-то значение, просто закрываемся.
            if (this.textBox.Text.Trim() != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка: поле ввода не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Функция, которая вызывается по нажатию кнопки cancelBtn: отменяет ввод.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Очищаем поле ввода и закрываем окно.
            this.textBox.Clear();
            this.Close();
        }

        /// <summary>
        /// Функция, которая возвращает текст из поле ввода.
        /// </summary>
        /// <returns>Возвращает обработанный введённый текст</returns>
        public string GetText()
        {
            return this.textBox.Text.Trim();
        }

        /// <summary>
        /// Заполняет поле ввода для упрощения возможного редактирования того или иного значения.
        /// </summary>
        /// <param name="text">Текст для последующего редактирования</param>
        public void SetTextBox(string text)
        {
            this.textBox.Text = text;
        }
    }
}
