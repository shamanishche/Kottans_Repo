using System;

namespace Ceasar.Tests
{
    public class CeasarCipher
    {
        private int offset;
        private readonly int[] Coder;
        private readonly int[] DeCoder;

        private const int MinCharCode = 32;
        private const int MaxCharCode = 126;

        public CeasarCipher(int offset)
        {
            this.offset = offset;
            this.Coder = new int[MaxCharCode - MinCharCode + 1];
            this.DeCoder = new int[MaxCharCode - MinCharCode + 1];

            // Normalize offset in case of big of negative value
            if (offset >= 0)
            {
                offset = offset % Coder.Length;
            }
            else
            {
                offset = offset % Coder.Length + Coder.Length;
            }

            // Create array Coder where we store information
            // how to code each valid symbol
            Coder[0] = MinCharCode;
            var charcode = 33;
            for (var i = Coder.Length - offset; i < Coder.Length; i++)
            {
                Coder[i] = charcode;
                charcode++;
            }
            for (var i = 1; i < Coder.Length - offset; i++)
            {
                Coder[i] = charcode;
                charcode++;
            }

            // Create array DeCoder where we store information
            // how to decode each valid symbol
            DeCoder[0] = MinCharCode;
            for (var i = 1; i < DeCoder.Length; i++)
            {
                DeCoder[Coder[i] - MinCharCode] = i + MinCharCode;
            }
        }

        public string Encrypt(string inputText)
        {
            if (inputText == null)
            {
                throw new ArgumentNullException();
            }
            var outputText = "";
            for (var i = 0; i < inputText.Length; i++)
            {
                int charcode = inputText[i];
                if (charcode>=127 || charcode<32)
                {
                    throw new ArgumentOutOfRangeException();
                }
                outputText += (char)Coder[charcode - MinCharCode];
            }
            return outputText;
        }

        public string Decrypt(string inputText)
        {
            if (inputText == null)
            {
                throw new ArgumentNullException();
            }
            var outputText = "";
            for (var i = 0; i < inputText.Length; i++)
            {
                var charcode = inputText[i];
                if (charcode > MaxCharCode || charcode < MinCharCode)
                {
                    throw new ArgumentOutOfRangeException();
                }
                outputText += (char)DeCoder[charcode - MinCharCode];
            }
            return outputText;
        }
    }
}