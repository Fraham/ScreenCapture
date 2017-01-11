using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ScreenCapture.Options
{
    [Serializable]
    public class NamedOption : Option
    {
        #region Class variables

        private string name;
        private bool isDefault;

        #endregion

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public NamedOption(string name, Option options, bool isDefault = false) : base(options)
        {
            Name = name;
            IsDefault = isDefault;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NamedOption(string name, bool isDefault = false) : base()
        {
            Name = name;
            IsDefault = isDefault;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="sourcePoint"></param>
        public NamedOption(string name, int width, int height, Point sourcePoint, bool isDefault = false) : base(width, height, sourcePoint)
        {
            Name = name;
            IsDefault = isDefault;
        }

        public NamedOption() : base()
        {
            Name = null;
            IsDefault = false;
        }

        #endregion

        #region Properties

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

        public bool IsDefault
        {
            get
            {
                return isDefault;
            }
            set
            {
                isDefault = value;
            }
        }

        #endregion

        #region Equals

        public override bool Equals(Object obj)
        {
            NamedOption optionsObj = obj as NamedOption;
            if (optionsObj == null)
            {
                return false;
            }

            return optionsObj.Height == Height && optionsObj.Width == Width && optionsObj.SourcePoint == SourcePoint && optionsObj.Fullscreen == Fullscreen && optionsObj.Name.Equals(Name) && IsDefault == optionsObj.isDefault;
        }

        public override int GetHashCode()
        {
            return this.Height + this.Width;
        }

        #endregion
    }
}