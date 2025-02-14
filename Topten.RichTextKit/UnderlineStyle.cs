﻿// RichTextKit
// Copyright © 2019-2020 Topten Software. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may 
// not use this product except in compliance with the License. You may obtain 
// a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
// License for the specific language governing permissions and limitations 
// under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topten.RichTextKit
{
    /// <summary>
    /// Describes the underline style for a run of text
    /// </summary>
    public enum UnderlineStyle
    {
        /// <summary>
        /// No underline.
        /// </summary>
        None = 0,

        /// <summary>
        /// Underline with gaps over descenders.
        /// </summary>
        Gapped = 1,

        /// <summary>
        /// Underline with no gaps over descenders.
        /// </summary>
        Solid = 2,

        /// <summary>
        /// Underline style for IME input
        /// </summary>
        ImeInput = 4,

        /// <summary>
        /// Underline style for converted IME input
        /// </summary>
        ImeConverted = 8,

        /// <summary>
        /// Underline style for converted IME input (target clause)
        /// </summary>
        ImeTargetConverted = 16,

        /// <summary>
        /// Underline style for unconverted IME input (target clause)
        /// </summary>
        ImeTargetNonConverted = 32,

        /// <summary>
        /// Create a line over the top of the text
        /// </summary>
        Overline = 64,
    }
}
