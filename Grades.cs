using System.Collections.Generic;

/*
 * DEPRECATED
 */

namespace SecondProgLab
{
    internal class Grades
    {
        private List<string> _groups = new List<string>();
        public List<string> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        private Dictionary<Dictionary<string, string>, int> _marks = new Dictionary<Dictionary<string, string>, int>(); // Group, Name -> mark
        public Dictionary<Dictionary<string, string>, int> Marks
        {
            get { return _marks; }
            set { _marks = value; }
        }
    }
}
