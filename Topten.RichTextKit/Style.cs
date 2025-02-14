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

using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.RichTextKit
{
    /// <summary>
    /// A basic implementation of IStyle interface provides styling 
    /// information for a run of text.
    /// </summary>
    public class Style : IStyle
    {
        void CheckNotSealed()
        {
            if (_sealed)
                throw new InvalidOperationException("Style has been sealed and can't be modified");
        }

        /// <summary>
        /// Seals the style to prevent it from further modification
        /// </summary>
        public void Seal()
        {
            _sealed = true;
        }

        /// <summary>
        /// The font family for text this text run (defaults to "Arial").
        /// </summary>
        public string FontFamily
        {
            get => _fontFamily;
            set { CheckNotSealed(); _fontFamily = value; }
        }

        /// <summary>
        /// The font size for text in this run (defaults to 16).
        /// </summary>
        public float FontSize
        {
            get => _fontSize;
            set { CheckNotSealed(); _fontSize = value; }
        }

        /// <summary>
        /// The font weight for text in this run (defaults to 400).
        /// </summary>
        public int FontWeight
        {
            get => _fontWeight;
            set { CheckNotSealed(); _fontWeight = value; }
        }

        /// <summary>
        /// True if the text in this run should be displayed in an italic
        /// font; otherwise False (defaults to false).
        /// </summary>
        public bool FontItalic
        {
            get => _fontItalic;
            set { CheckNotSealed(); _fontItalic = value; }
        }

        /// <summary>
        /// The underline style for text in this run (defaults to None).
        /// </summary>
        public UnderlineStyle Underline
        {
            get => _underlineStyle;
            set { CheckNotSealed(); _underlineStyle = value; }
        }

        /// <summary>
        /// The strike through style for the text in this run (defaults to None).
        /// </summary>
        public StrikeThroughStyle StrikeThrough
        {
            get => _strikeThrough;
            set { CheckNotSealed(); _strikeThrough = value; }
        }

        /// <summary>
        /// The line height for text in this run as a multiplier (defaults to 1.0).
        /// </summary>
        public float LineHeight
        {
            get => _lineHeight;
            set { CheckNotSealed(); _lineHeight = value; }
        }

        /// <summary>
        /// The text color for text in this run (defaults to black).
        /// </summary>
        public SKColor TextColor
        {
            get => _textColor;
            set { CheckNotSealed(); _textColor = value; }
        }
        
        /// <summary>
        /// The underline color for the text in this run (defaults to the current text color)
        /// </summary>
        public SKColor? UnderlineColor
        {
            get => _underlineColor;
            set { CheckNotSealed(); _underlineColor = value; }
        }

        /// <summary>
        /// Sets the underline or strike-through stroke thickness(defaults to the current strike-through or underline thickness depending on context)
        /// </summary>
        public float? StrokeThickness
        {
            get => _strokeThickness;
            set { CheckNotSealed(); _strokeThickness = value; }
        }

        /// <summary>
        /// Sets whether to draw underlines or overlines over glyphs or not
        /// </summary>
        public bool StrokeInkSkip
        {
            get => _strokeInkSkip;
            set { CheckNotSealed(); _strokeInkSkip = value; }
        }

        /// <summary>
        /// Y Offset for the underline, this value is added to the base value!
        /// </summary>
        public float UnderlineOffset
        {
            get => _underlineOffset;
            set { CheckNotSealed(); _underlineOffset = value;}
        }

        /// <summary>
        /// Y Offset for the overline, this value is added to the base value!
        /// </summary>
        public float OverlineOffset
        {
            get => _overlineOffset;
            set { CheckNotSealed(); _overlineOffset = value; }
        }

        /// <summary>
        /// Y Offset for the strike-through, this value is added to the base value!
        /// </summary>
        public float StrikeThroughOffset
        {
            get => _strikethroughOffset;
            set { CheckNotSealed(); _strikethroughOffset = value; }
        }

        /// <summary>
        /// Sets the stroke line style for underline/overline/strike throughs
        /// </summary>
        public UnderlineType UnderlineStrokeType
        {
            get => _underlineType;
            set { CheckNotSealed(); _underlineType = value; }
        }

        /// <summary>
        /// The background color of this run (no background is painted by default).
        /// </summary>
        public SKColor BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                CheckNotSealed();
                _backgroundColor = value;
            }
        }

        /// <summary>
        /// The character spacing for text in this run (defaults to 0).
        /// </summary>
        public float LetterSpacing
        {
            get => _letterSpacing;
            set { CheckNotSealed(); _letterSpacing = value; }
        }

        /// <summary>
        /// The font variant (ie: super/sub-script) for text in this run.
        /// </summary>
        public FontVariant FontVariant
        {
            get => _fontVariant;
            set { CheckNotSealed(); _fontVariant = value; }
        }

        /// <summary>
        /// Text direction override for this span
        /// </summary>
        public TextDirection TextDirection
        {
            get => _textDirection;
            set { CheckNotSealed(); _textDirection = value; }
        }

        /// <inheritdoc />
        public char ReplacementCharacter
        {
            get => _replacementCharacter;
            set { CheckNotSealed(); _replacementCharacter = value; }
        }

        /// <summary>
        /// Add a text effect to this style
        /// </summary>
        public void AddEffect(TextEffect textEffect)
        {
            if (_textEffects == null)
                _textEffects = new List<TextEffect>();

            _textEffects.Add(textEffect);
        }


        /// <summary>
        /// Remove all text effects
        /// </summary>
        public void ClearEffects()
		{
            _textEffects?.Clear();

        }

        /// <summary>
        /// Effects to apply
        /// </summary>
        public IEnumerable<TextEffect> TextEffects => _textEffects;

        bool _sealed;
        string _fontFamily = "Arial";
        float _fontSize = 16;
        int _fontWeight = 400;
        bool _fontItalic;
        UnderlineStyle _underlineStyle;
        StrikeThroughStyle _strikeThrough;
        float _lineHeight = 1.0f;
        SKColor _textColor = new SKColor(0xFF000000);
        SKColor? _underlineColor = null;
        float? _strokeThickness = null;
        bool _strokeInkSkip = true;
        float _underlineOffset = 0.0f;
        float _overlineOffset = 0.0f;
        float _strikethroughOffset = 0.0f;
        UnderlineType _underlineType = UnderlineType.Solid;
        SKColor _backgroundColor = SKColor.Empty;
        float _letterSpacing;
        FontVariant _fontVariant;
        TextDirection _textDirection = TextDirection.Auto;
        char _replacementCharacter = '\0';
        List<TextEffect> _textEffects;

        /// <summary>
        /// Modifies this style with one or more attribute changes and returns a new style
        /// </summary>
        /// <remarks>
        /// Note this method always creates a new style instance.To avoid creating excessive 
        /// style instances, consider using the StyleManager which caches instances of styles 
        /// with the same attributes
        /// </remarks>
        /// <param name="fontFamily">The new font family</param>
        /// <param name="fontSize">The new font size</param>
        /// <param name="fontWeight">The new font weight</param>
        /// <param name="fontItalic">The new font italic</param>
        /// <param name="underline">The new underline style</param>
        /// <param name="strikeThrough">The new strike-through style</param>
        /// <param name="lineHeight">The new line height</param>
        /// <param name="textColor">The new text color</param>
        /// <param name="backgroundColor">The new background color</param>
        /// <param name="letterSpacing">The new letterSpacing</param>
        /// <param name="fontVariant">The new font variant</param>
        /// <param name="textDirection">The new text direction</param>
        /// <param name="replacementCharacter">The new replacement character</param>
        /// <param name="underlineColor">The stroke color</param>
        /// <param name="strokeThickness">The thickness of the strike-through/underline stroke</param>
        /// <param name="strokeInkSkip">Decides whether underlines or overlines draw over glyphs or not</param>
        /// <param name="strokeUnderlineType">Specify the style for how the line should be drawn</param>
        /// <param name="underlineOffset">Adds an offset to the base underline offset</param>
        /// <param name="overlineOffset">Adds an offset to the base overline offset</param>
        /// <param name="strikethroughOffset">Adds an offset to the base strike-through offset</param>
        /// <returns>A new style with the passed attributes changed</returns>
        public Style Modify(
               string fontFamily = null,
               float? fontSize = null,
               int? fontWeight = null,
               bool? fontItalic = null,
               UnderlineStyle? underline = null,
               StrikeThroughStyle? strikeThrough = null,
               float? lineHeight = null,
               SKColor? textColor = null,
               SKColor? backgroundColor = null,
               float? letterSpacing = null,
               FontVariant? fontVariant = null,
               TextDirection? textDirection = null,
               char? replacementCharacter = null,
               SKColor? underlineColor = null,
               float? strokeThickness = null,
               bool? strokeInkSkip = null,
               UnderlineType? strokeUnderlineType = null,
               float? underlineOffset = null,
               float? overlineOffset = null,
               float? strikethroughOffset = null
            )
        {
            // Resolve new style against current style
            return new Style()
            {
                FontFamily = fontFamily ?? this.FontFamily,
                FontSize = fontSize ?? this.FontSize,
                FontWeight = fontWeight ?? this.FontWeight,
                FontItalic = fontItalic ?? this.FontItalic,
                Underline = underline ?? this.Underline,
                StrikeThrough = strikeThrough ?? this.StrikeThrough,
                LineHeight = lineHeight ?? this.LineHeight,
                TextColor = textColor ?? this.TextColor,
                BackgroundColor = backgroundColor ?? this.BackgroundColor,
                LetterSpacing = letterSpacing ?? this.LetterSpacing,
                FontVariant = fontVariant ?? this.FontVariant,
                TextDirection = textDirection ?? this.TextDirection,
                ReplacementCharacter = replacementCharacter ?? this.ReplacementCharacter,
                UnderlineColor = underlineColor ?? this.UnderlineColor,
                StrokeThickness = strokeThickness ?? this.StrokeThickness,
                StrokeInkSkip = strokeInkSkip ?? this.StrokeInkSkip,
                UnderlineStrokeType = strokeUnderlineType ?? this.UnderlineStrokeType,
                UnderlineOffset = underlineOffset ?? this.UnderlineOffset,
                OverlineOffset = overlineOffset ?? this.OverlineOffset,
                StrikeThroughOffset = strikethroughOffset ?? this.StrikeThroughOffset
            };
        }
    }
}