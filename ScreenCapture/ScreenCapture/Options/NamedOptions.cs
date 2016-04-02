using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Options
{
    class NamedOptions : Options
    {
        #region Class Variables

        private string name;

        #endregion Class Variables

        public NamedOptions(string name, Options options)
        {
            Name = name;

            Width = options.Width;
            Height = options.Height;
            SourcePoint = options.SourcePoint;
            Fullscreen = options.Fullscreen;
        }

        /// <summary>
        /// Getters and setter for the name.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = (value == null || value.Equals("")) ? "null" : value;
            }
        }
    }
}
