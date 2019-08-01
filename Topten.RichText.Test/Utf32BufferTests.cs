﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Topten.RichText.Test
{
    public class Utf32BufferTests
    {
        const string mixedString = "This\r\na\r\nstring\n🌐 🍪 🍕 🚀\n يتكلّم \n हालाँकि प्रचलित रूप पूज 緳 踥踕";

        [Fact]
        public void Map32to16Test()
        {
            // Arrange
            var buf = new Utf32Buffer();

            // Act
            buf.Add(mixedString);

            // Assert
            for (int i32 = 0; i32 < buf.Length; i32++)
            {
                var i16 = buf.Utf32OffsetToUtf16Offset(i32);
                var i32b = buf.Utf16OffsetToUtf32Offset(i16);
                Assert.Equal(i32, i32b);
            }

        }

        [Fact]
        public void Map16to32Test()
        {
            // Arrange
            var buf = new Utf32Buffer();

            // Act
            buf.Add(mixedString);

            // Assert
            for (int i = 0; i < mixedString.Length; i++)
            {
                char ch = mixedString[i];
                var ch32 = buf[buf.Utf16OffsetToUtf32Offset(i)];
                if (ch >= 0xD800 && ch <= 0xDFFF)
                {
                    var chL = mixedString[i+1];
                    var ch32actual = 0x10000 | ((ch - 0xD800) << 10) | (chL - 0xDC00);
                    Assert.Equal(ch32, ch32actual);
                    i++;
                }
                else if (ch == '\r' && mixedString[i+1] == '\n')
                {
                    Assert.Equal('\n', ch32);
                    i++;
                }
                else
                {
                    Assert.Equal(ch, ch32);
                }
            }
        }

        [Fact]
        public void MapSurrogateToBase()
        {
            // Arrange
            var buf = new Utf32Buffer();

            // Act
            buf.Add(mixedString);

            // Assert
            for (int i = 0; i < mixedString.Length; i++)
            {
                char ch = mixedString[i];
                if ((ch >= 0xDC00 && ch <= 0xDFFF) || (ch == '\n' && mixedString[i-1] == '\r'))
                {
                    int prior = buf.Utf16OffsetToUtf32Offset(i - 1);
                    int current = buf.Utf16OffsetToUtf32Offset(i);
                    Assert.Equal(prior, current);
                }
            }
        }

        [Fact]
        public void ConvertToUtf16()
        {
            // Arrange
            var buf = new Utf32Buffer();

            // Act
            buf.Add(mixedString);
            var str2 = Utf32Utils.FromUtf32(buf.AsSlice());

            // Assert
            Assert.Equal(mixedString.Replace("\r", ""), str2);
        }
    }
}
