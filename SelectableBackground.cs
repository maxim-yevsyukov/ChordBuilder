using System.Drawing;

namespace ToliyGuitarSchoolHelper
{
    class SelectableBackground
    {
        private string _displayName;

        private Image _image;

        public Image Image
        {
            get
            {
                return _image;
            }
        }

        public SelectableBackground(string path, string displayName)
        {
            _image = Image.FromFile(path);
            _displayName = displayName;
        }

        public override string ToString()
        {
            return _displayName;
        }
    }
}
