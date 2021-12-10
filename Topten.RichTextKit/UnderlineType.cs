using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.RichTextKit
{
    /// <summary>
    /// The line type of strike-through, underlines or overlines
    /// </summary>
    public enum UnderlineType
    {
        /// <summary>
        /// Default option to just draw a solid line
        /// </summary>
        Solid = 0,

        /// <summary>
        /// Draw a dotted line
        /// </summary>
        Dotted = 1,

        /// <summary>
        /// Draw a dashed line
        /// </summary>
        Dashed = 2,

        /// <summary>
        /// Draw two lines
        /// </summary>
        Double = 3,

        /// <summary>
        /// Draw squggly lines
        /// </summary>
        Wavy = 4,
    }
}
