using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class ArithmeticTest : AbstractDecodeTest
    {
        /// <summary>
        /// Add With Carry
        /// <remarks>ADDC</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00010100 00000000", "ADC", "AL,00")]
        [InlineData("00010100 11000100", "ADC", "AL,C4")]
        /* */
        [InlineData("00010101 00000000 00110100", "ADC", "AX,3400")]
        [InlineData("00010101 11101010 11001110", "ADC", "AX,CEEA")]
        /* */
        [InlineData("00010011 00000000", "ADC", "AX,Word Ptr [BX+SI]")]
        [InlineData("00010011 11000111", "ADC", "AX,DI")]
        [InlineData("00010011 01000000 00010001", "ADC", "AX,Word Ptr [BX+SI+11]")]
        [InlineData("00010011 01010110 11111010", "ADC", "DX,Word Ptr [BP-06]")]
        [InlineData("00010011 00000110 00010001 00000000", "ADC", "AX,Word Ptr [0011]")]
        [InlineData("00010011 10101001 10001000 01110100", "ADC", "BP,Word Ptr [BX+DI+7488]")]
        /* */
        [InlineData("00010010 00000000", "ADC", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00010010 11010011", "ADC", "DL,BL")]
        [InlineData("00010010 01000000 10111100", "ADC", "AL,Byte Ptr [BX+SI-44]")]
        [InlineData("00111110 00010010 00010001", "ADC", "DL,Byte Ptr DS:[BX+DI]")]
        [InlineData("00010010 00000110 00010001 00000000", "ADC", "AL,Byte Ptr [0011]")]
        [InlineData("00010010 00100110 01001010 11001101", "ADC", "AH,Byte Ptr [CD4A]")]
        /* */
        [InlineData("10000001 00010000 00010001 00000000", "ADC", "Word Ptr [BX+SI],0011")]
        [InlineData("10000001 11010000 00010001 00000000", "ADC", "AX,0011")]
        [InlineData("00111110 10000001 00010001 00000000 11001000", "ADC", "Word Ptr DS:[BX+DI],C800")]
        [InlineData("10000001 01010000 00010001 00000000 11001000", "ADC", "Word Ptr [BX+SI+11],C800")]
        [InlineData("10000001 00010110 00010001 00000000 11001000 00000000", "ADC", "Word Ptr [0011],00C8")]
        [InlineData("10000001 10010000 00010001 00000000 11001000 00000000", "ADC", "Word Ptr [BX+SI+0011],00C8")]
        [InlineData("00100110 10000001 10010110 01101110 10001000 00101001 11010101", "ADC", "Word Ptr ES:[BP-7792],D529")]
        /* */
        [InlineData("10000011 00010000 00010001", "ADC", "Word Ptr [BX+SI],+11")]
        [InlineData("10000011 11010011 00001001", "ADC", "BX,+09")]
        [InlineData("00111110 10000011 00010001 00000000", "ADC", "Word Ptr DS:[BX+DI],+00")]
        [InlineData("10000011 01010000 00010001 00000000", "ADC", "Word Ptr [BX+SI+11],+00")]
        [InlineData("10000011 00010110 00010001 00000000 11001000", "ADC", "Word Ptr [0011],-38")]
        [InlineData("10000011 10010000 00010001 00000000 11001000", "ADC", "Word Ptr [BX+SI+0011],-38")]
        /* */
        [InlineData("00010001 00000000", "ADC", "Word Ptr [BX+SI],AX")]
        [InlineData("00010001 11010111", "ADC", "DI,DX")]
        [InlineData("00010001 01000000 00010001", "ADC", "Word Ptr [BX+SI+11],AX")]
        [InlineData("00111110 00010001 00010001", "ADC", "Word Ptr DS:[BX+DI],DX")]
        [InlineData("00010001 00000110 00010001 00000000", "ADC", "Word Ptr [0011],AX")]
        [InlineData("00010001 10101011 10011011 01101011", "ADC", "Word Ptr [BP+DI+6B9B],BP")]
        /* */
        [InlineData("10000010 00010000 00010001", "ADC", "Byte Ptr [BX+SI],11")]
        [InlineData("10000010 11010000 00010001", "ADC", "AL,11")]
        [InlineData("00111110 10000010 00010101 00001011", "ADC", "Byte Ptr DS:[DI],0B")]
        [InlineData("10000010 01010000 00010001 00000000", "ADC", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000010 00010110 00010001 00000000 11001000", "ADC", "Byte Ptr [0011],C8")]
        [InlineData("10000010 10010000 00010001 00000000 11001000", "ADC", "Byte Ptr [BX+SI+0011],C8")]
        /* */
        [InlineData("10000000 00010000 00010001", "ADC", "Byte Ptr [BX+SI],11")]
        [InlineData("10000000 11010100 00001001", "ADC", "AH,09")]
        [InlineData("00111110 10000000 00010001 00000000", "ADC", "Byte Ptr DS:[BX+DI],00")]
        [InlineData("10000000 01010000 00010001 00000000", "ADC", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000000 00010110 00010001 00000000 11001000", "ADC", "Byte Ptr [0011],C8")]
        [InlineData("10000000 10010000 00010001 00000000 11001000", "ADC", "Byte Ptr [BX+SI+0011],C8")]
        /* */
        [InlineData("00010000 00000000", "ADC", "Byte Ptr [BX+SI],AL")]
        [InlineData("00010000 11000101", "ADC", "CH,AL")]
        [InlineData("00010000 01000010 11110011", "ADC", "Byte Ptr [BP+SI-0D],AL")]
        [InlineData("00111110 00010000 00010001", "ADC", "Byte Ptr DS:[BX+DI],DL")]
        [InlineData("00010000 00000110 00010001 00000000", "ADC", "Byte Ptr [0011],AL")]
        [InlineData("00010000 10000000 00010001 00000000", "ADC", "Byte Ptr [BX+SI+0011],AL")]
        /* */
        public void CheckAdc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Add
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00000100 00000000", "ADD", "AL,00")]
        [InlineData("00000100 10100000", "ADD", "AL,A0")]
        /* */
        [InlineData("00000101 00101010 11011110", "ADD", "AX,DE2A")]
        [InlineData("00000101 11001111 00001001", "ADD", "AX,09CF")]
        /* */
        [InlineData("00000011 00000000", "ADD", "AX,Word Ptr [BX+SI]")]
        [InlineData("00000011 11110110", "ADD", "SI,SI")]
        [InlineData("00000011 01011000 00001010", "ADD", "BX,Word Ptr [BX+SI+0A]")]
        [InlineData("00111110 00000011 00010001", "ADD", "DX,Word Ptr DS:[BX+DI]")]
        [InlineData("00000011 00000110 00010001 00000000", "ADD", "AX,Word Ptr [0011]")]
        [InlineData("00000011 10001011 10011101 00010010", "ADD", "CX,Word Ptr [BP+DI+129D]")]
        /* */
        [InlineData("00000010 00000000", "ADD", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00000010 11000010", "ADD", "AL,DL")]
        [InlineData("00000010 01000000 00010001", "ADD", "AL,Byte Ptr [BX+SI+11]")]
        [InlineData("00111110 00000010 00010001", "ADD", "DL,Byte Ptr DS:[BX+DI]")]
        [InlineData("00000010 00000110 00010001 00000000", "ADD", "AL,Byte Ptr [0011]")]
        [InlineData("00000010 10001011 10111001 10100111", "ADD", "CL,Byte Ptr [BP+DI-5847]")]
        /* */
        [InlineData("10000001 00000001 01011100 10100101", "ADD", "Word Ptr [BX+DI],A55C")]
        [InlineData("10000001 11000000 00010001 00000000", "ADD", "AX,0011")]
        [InlineData("10000001 01000000 00010001 00000000 11001000", "ADD", "Word Ptr [BX+SI+11],C800")]
        [InlineData("10000001 01000100 00010001 00000000 11001000", "ADD", "Word Ptr [SI+11],C800")]
        [InlineData("00100110 10000001 01000011 00100100 10101101 10101011", "ADD", "Word Ptr ES:[BP+DI+24],ABAD")]
        [InlineData("10000001 00000110 00010001 00000000 11001000 00000000", "ADD", "Word Ptr [0011],00C8")]
        /* */
        [InlineData("10000011 00000000 10010100", "ADD", "Word Ptr [BX+SI],-6C")]
        [InlineData("10000011 11000011 00001001", "ADD", "BX,+09")]
        [InlineData("10000011 01000000 00010001 00000000", "ADD", "Word Ptr [BX+SI+11],+00")]
        [InlineData("10000011 01000100 00010001 00000000", "ADD", "Word Ptr [SI+11],+00")]
        [InlineData("10000011 00000110 00010001 00000000 11001000", "ADD", "Word Ptr [0011],-38")]
        [InlineData("10000011 10000000 00010001 00000000 11001000", "ADD", "Word Ptr [BX+SI+0011],-38")]
        /* */
        [InlineData("00000001 00000000", "ADD", "Word Ptr [BX+SI],AX")]
        [InlineData("00000001 11010010", "ADD", "DX,DX")]
        [InlineData("00000001 01000001 10001101", "ADD", "Word Ptr [BX+DI-73],AX")]
        [InlineData("00111110 00000001 00010001", "ADD", "Word Ptr DS:[BX+DI],DX")]
        [InlineData("00000001 00000110 00010001 00000000", "ADD", "Word Ptr [0011],AX")]
        [InlineData("00000001 10011000 01011011 00100000", "ADD", "Word Ptr [BX+SI+205B],BX")]
        [InlineData("00110110 00000001 00001110 01011100 11010111", "ADD", "Word Ptr SS:[D75C],CX")]
        /* */
        [InlineData("10000010 00000000 11000011", "ADD", "Byte Ptr [BX+SI],C3")]
        [InlineData("10000010 11000000 00010001", "ADD", "AL,11")]
        [InlineData("00110110 10000010 00000000 10110010", "ADD", "Byte Ptr SS:[BX+SI],B2")]
        [InlineData("10000010 01000100 00010001 00000000", "ADD", "Byte Ptr [SI+11],00")]
        [InlineData("10000010 00000110 00010001 00000000 11001000", "ADD", "Byte Ptr [0011],C8")]
        [InlineData("10000010 10000000 00010001 00000000 11001000", "ADD", "Byte Ptr [BX+SI+0011],C8")]
        /* */
        [InlineData("10000000 00000000 11000000", "ADD", "Byte Ptr [BX+SI],C0")]
        [InlineData("10000000 11000100 00001001", "ADD", "AH,09")]
        [InlineData("10000000 01000000 00010001 00000000", "ADD", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000000 01000100 00010001 00000000", "ADD", "Byte Ptr [SI+11],00")]
        [InlineData("10000000 00000110 00010001 00000000 11001000", "ADD", "Byte Ptr [0011],C8")]
        [InlineData("10000000 10000000 00010001 00000000 11001000", "ADD", "Byte Ptr [BX+SI+0011],C8")]
        /* */
        [InlineData("00000000 00000000", "ADD", "Byte Ptr [BX+SI],AL")]
        [InlineData("00000000 11100010", "ADD", "DL,AH")]
        [InlineData("00000000 01000011 01100101", "ADD", "Byte Ptr [BP+DI+65],AL")]
        [InlineData("00111110 00000000 00010001", "ADD", "Byte Ptr DS:[BX+DI],DL")]
        [InlineData("00000000 00000110 00010001 00000000", "ADD", "Byte Ptr [0011],AL")]
        [InlineData("00000000 10000000 00010001 00000000", "ADD", "Byte Ptr [BX+SI+0011],AL")]
        [InlineData("00110110 00000000 10111101 00110011 10001011", "ADD", "Byte Ptr SS:[DI-74CD],BH")]
        /* */
        public void CheckAdd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Compare Two Operands
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00111100 00000000", "CMP", "AL,00")]
        [InlineData("00111100 10110001", "CMP", "AL,B1")]
        /* */
        [InlineData("00111101 00000000 11111110", "CMP", "AX,FE00")]
        [InlineData("00111101 11101000 00000001", "CMP", "AX,01E8")]
        /* */
        [InlineData("00111011 00000000", "CMP", "AX,Word Ptr [BX+SI]")]
        [InlineData("00111011 11010011", "CMP", "DX,BX")]
        [InlineData("00111011 01011001 11000011", "CMP", "BX,Word Ptr [BX+DI-3D]")]
        [InlineData("00111110 00111011 00010001", "CMP", "DX,Word Ptr DS:[BX+DI]")]
        [InlineData("00111011 00000110 00010001 00000000", "CMP", "AX,Word Ptr [0011]")]
        [InlineData("00111011 10000000 00010001 00000000", "CMP", "AX,Word Ptr [BX+SI+0011]")]
        /* */
        [InlineData("00111010 00000000", "CMP", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00111010 11010101", "CMP", "DL,CH")]
        [InlineData("00111010 01000000 00111111", "CMP", "AL,Byte Ptr [BX+SI+3F]")]
        [InlineData("00111110 00111010 00010001", "CMP", "DL,Byte Ptr DS:[BX+DI]")]
        [InlineData("00111010 00000110 00010001 00000000", "CMP", "AL,Byte Ptr [0011]")]
        [InlineData("00111010 10000000 00010001 00000000", "CMP", "AL,Byte Ptr [BX+SI+0011]")]
        /* */
        [InlineData("10000001 00111000 00010001 00000000", "CMP", "Word Ptr [BX+SI],0011")]
        [InlineData("10000001 11111000 00010001 00000000", "CMP", "AX,0011")]
        [InlineData("10000001 01111000 00010001 00000000 11001000", "CMP", "Word Ptr [BX+SI+11],C800")]
        [InlineData("10000001 01111100 00010001 00000000 11001000", "CMP", "Word Ptr [SI+11],C800")]
        [InlineData("10000001 00111110 00010001 00000000 11001000 00000000", "CMP", "Word Ptr [0011],00C8")]
        [InlineData("10000001 10111111 00101000 00100011 00100111 11011111", "CMP", "Word Ptr [BX+2328],DF27")]
        /* */
        [InlineData("10000011 00111000 00010001", "CMP", "Word Ptr [BX+SI],+11")]
        [InlineData("10000011 11111011 00001001", "CMP", "BX,+09")]
        [InlineData("10000011 01111000 00010001 00000000", "CMP", "Word Ptr [BX+SI+11],+00")]
        [InlineData("10000011 01111100 00010001 00000000", "CMP", "Word Ptr [SI+11],+00")]
        [InlineData("10000011 00111110 00010001 00000000 11001000", "CMP", "Word Ptr [0011],-38")]
        [InlineData("10000011 10111000 00010001 00000000 11001000", "CMP", "Word Ptr [BX+SI+0011],-38")]
        /* */
        [InlineData("00111001 00000000", "CMP", "Word Ptr [BX+SI],AX")]
        [InlineData("00111001 11011011", "CMP", "BX,BX")]
        [InlineData("00111001 01000000 00010001", "CMP", "Word Ptr [BX+SI+11],AX")]
        [InlineData("00111110 00111001 00010001", "CMP", "Word Ptr DS:[BX+DI],DX")]
        [InlineData("00111001 00000110 00010001 00000000", "CMP", "Word Ptr [0011],AX")]
        [InlineData("00111001 10000000 00010001 00000000", "CMP", "Word Ptr [BX+SI+0011],AX")]
        /* */
        [InlineData("10000010 00111000 00010001", "CMP", "Byte Ptr [BX+SI],11")]
        [InlineData("10000010 11111000 00010001", "CMP", "AL,11")]
        [InlineData("10000010 01111000 00010001 00000000", "CMP", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000010 01111100 00010001 00000000", "CMP", "Byte Ptr [SI+11],00")]
        [InlineData("10000010 00111110 00010001 00000000 11001000", "CMP", "Byte Ptr [0011],C8")]
        [InlineData("10000010 10111000 00010001 00000000 11001000", "CMP", "Byte Ptr [BX+SI+0011],C8")]
        [InlineData("00110110 10000010 10111010 10101111 00000011 11011001", "CMP", "Byte Ptr SS:[BP+SI+03AF],D9")]
        /* */
        [InlineData("10000000 00111000 00010001", "CMP", "Byte Ptr [BX+SI],11")]
        [InlineData("10000000 11111100 00001001", "CMP", "AH,09")]
        [InlineData("10000000 01111000 00010001 00000000", "CMP", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000000 01111100 00010001 00000000", "CMP", "Byte Ptr [SI+11],00")]
        [InlineData("10000000 00111110 00010001 00000000 11001000", "CMP", "Byte Ptr [0011],C8")]
        [InlineData("10000000 10111000 00110100 00010101 00110110", "CMP", "Byte Ptr [BX+SI+1534],36")]
        /* */
        [InlineData("00111000 00000000", "CMP", "Byte Ptr [BX+SI],AL")]
        [InlineData("00111000 11011000", "CMP", "AL,BL")]
        [InlineData("00111000 01100000 00010101", "CMP", "Byte Ptr [BX+SI+15],AH")]
        [InlineData("00111110 00111000 00010001", "CMP", "Byte Ptr DS:[BX+DI],DL")]
        [InlineData("00111000 00000110 00010001 00000000", "CMP", "Byte Ptr [0011],AL")]
        [InlineData("00111000 10111011 10101110 10001111", "CMP", "Byte Ptr [BP+DI-7052],BH")]
        /* */
        public void CheckCmp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decrement by 1
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00110110 11111110 00011000", "DEC", "Byte Ptr SS:[BX+SI]")]
        /* */
        [InlineData("01001000", "DEC", "AX")]
        /* */
        [InlineData("11111111 00001000", "DEC", "Word Ptr [BX+SI]")]
        [InlineData("11111111 11001000", "DEC", "AX")]
        [InlineData("11111111 01001010 00110101", "DEC", "Word Ptr [BP+SI+35]")]
        [InlineData("11111111 01001100 00010001", "DEC", "Word Ptr [SI+11]")]
        [InlineData("11111111 00001110 00010001 00000000", "DEC", "Word Ptr [0011]")]
        [InlineData("11111111 10001000 00010001 00000000", "DEC", "Word Ptr [BX+SI+0011]")]
        /* */
        [InlineData("11111110 00001000", "DEC", "Byte Ptr [BX+SI]")]
        [InlineData("11111110 11001100", "DEC", "AH")]
        [InlineData("11111110 01001000 00010001", "DEC", "Byte Ptr [BX+SI+11]")]
        [InlineData("11111110 01001100 00010001", "DEC", "Byte Ptr [SI+11]")]
        [InlineData("11111110 00001110 00010001 00000000", "DEC", "Byte Ptr [0011]")]
        [InlineData("11111110 10001000 00010001 00000000", "DEC", "Byte Ptr [BX+SI+0011]")]
        /* */
        public void CheckDec(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unsigned Divide
        /// <remarks>DIVU</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110111 00110011", "DIV", "Word Ptr [BP+DI]")]
        [InlineData("11110111 11110011", "DIV", "BX")]
        [InlineData("11110111 01110000 00010001", "DIV", "Word Ptr [BX+SI+11]")]
        [InlineData("11110111 01110100 00010001", "DIV", "Word Ptr [SI+11]")]
        [InlineData("11110111 00110110 00010001 00000000", "DIV", "Word Ptr [0011]")]
        [InlineData("11110111 10110010 01000000 01100011", "DIV", "Word Ptr [BP+SI+6340]")]
        /* */
        [InlineData("11110110 00110000", "DIV", "Byte Ptr [BX+SI]")]
        [InlineData("11110110 11110100", "DIV", "AH")]
        [InlineData("11110110 01110000 00010001", "DIV", "Byte Ptr [BX+SI+11]")]
        [InlineData("11110110 01110100 00010001", "DIV", "Byte Ptr [SI+11]")]
        [InlineData("11110110 00110110 00010001 00000000", "DIV", "Byte Ptr [0011]")]
        [InlineData("11110110 10110000 00010001 00000000", "DIV", "Byte Ptr [BX+SI+0011]")]
        /* */
        public void CheckDiv(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Signed Divide
        /// <remarks>DIV</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110111 00111000", "IDIV", "Word Ptr [BX+SI]")]
        [InlineData("11110111 11111011", "IDIV", "BX")]
        [InlineData("11110111 01111000 10010100", "IDIV", "Word Ptr [BX+SI-6C]")]
        [InlineData("11110111 01111100 00010001", "IDIV", "Word Ptr [SI+11]")]
        [InlineData("11110111 00111110 00010001 00000000", "IDIV", "Word Ptr [0011]")]
        [InlineData("11110111 10111000 00010001 00000000", "IDIV", "Word Ptr [BX+SI+0011]")]
        /* */
        [InlineData("11110110 00111000", "IDIV", "Byte Ptr [BX+SI]")]
        [InlineData("11110110 11111100", "IDIV", "AH")]
        [InlineData("11110110 01111000 00010001", "IDIV", "Byte Ptr [BX+SI+11]")]
        [InlineData("11110110 01111100 00010001", "IDIV", "Byte Ptr [SI+11]")]
        [InlineData("11110110 00111110 00010001 00000000", "IDIV", "Byte Ptr [0011]")]
        [InlineData("11110110 10111000 00010001 00000000", "IDIV", "Byte Ptr [BX+SI+0011]")]
        /* */
        public void CheckIdiv(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Signed Multiply
        /// <remarks>MUL</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01101001 00011001 00110000 11100010", "IMUL", "BX,Word Ptr [BX+DI],E230")]
        [InlineData("01101001 11000000 00010001 00000000", "IMUL", "AX,AX,0011")]
        [InlineData("00111110 01101001 00010001 00000000 11001000", "IMUL", "DX,Word Ptr DS:[BX+DI],C800")]
        [InlineData("01101001 01000000 00010001 00000000 11001000", "IMUL", "AX,Word Ptr [BX+SI+11],C800")]
        [InlineData("01101001 00000110 00010001 00000000 11001000 00000000", "IMUL", "AX,Word Ptr [0011],00C8")]
        [InlineData("01101001 10111001 10001000 00101111 11110011 01001111", "IMUL", "DI,Word Ptr [BX+DI+2F88],4FF3")]
        [InlineData("00110110 01101001 10101100 01110010 01111101 00100110 00000011", "IMUL", "BP,Word Ptr SS:[SI+7D72],0326")]
        /* */
        [InlineData("01101011 00010111 11110001", "IMUL", "DX,Word Ptr [BX],F1")]
        [InlineData("01101011 11011011 00001001", "IMUL", "BX,BX,09")]
        [InlineData("00111110 01101011 00010001 00000000", "IMUL", "DX,Word Ptr DS:[BX+DI],00")]
        [InlineData("01101011 01001010 01010101 01100001", "IMUL", "CX,Word Ptr [BP+SI+55],61")]
        [InlineData("01101011 00000110 00010001 00000000 11001000", "IMUL", "AX,Word Ptr [0011],C8")]
        [InlineData("01101011 00000110 01001111 11000001 10101001", "IMUL", "AX,Word Ptr [C14F],A9")]
        /* */
        [InlineData("11110111 00101000", "IMUL", "Word Ptr [BX+SI]")]
        [InlineData("11110111 11101011", "IMUL", "BX")]
        [InlineData("11110111 01101000 00010001", "IMUL", "Word Ptr [BX+SI+11]")]
        [InlineData("11110111 01101100 00010001", "IMUL", "Word Ptr [SI+11]")]
        [InlineData("11110111 00101110 00010001 00000000", "IMUL", "Word Ptr [0011]")]
        [InlineData("11110111 10101000 00110001 01100100", "IMUL", "Word Ptr [BX+SI+6431]")]
        /* */
        [InlineData("11110110 00101000", "IMUL", "Byte Ptr [BX+SI]")]
        [InlineData("11110110 11101100", "IMUL", "AH")]
        [InlineData("11110110 01101000 00010001", "IMUL", "Byte Ptr [BX+SI+11]")]
        [InlineData("11110110 01101100 00010001", "IMUL", "Byte Ptr [SI+11]")]
        [InlineData("11110110 00101110 00010001 00000000", "IMUL", "Byte Ptr [0011]")]
        [InlineData("11110110 10101011 10101000 00011001", "IMUL", "Byte Ptr [BP+DI+19A8]")]
        /* */
        public void CheckImul(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Increment by 1
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11111110 01100001 00101011", "INC", "Byte Ptr [BX+DI+2B]")]
        /* */
        [InlineData("01000000", "INC", "AX")]
        /* */
        [InlineData("11111111 00000000", "INC", "Word Ptr [BX+SI]")]
        [InlineData("11111111 11000000", "INC", "AX")]
        [InlineData("11111111 01000000 00010001", "INC", "Word Ptr [BX+SI+11]")]
        [InlineData("11111111 01000100 00010001", "INC", "Word Ptr [SI+11]")]
        [InlineData("11111111 00000110 00010001 00000000", "INC", "Word Ptr [0011]")]
        [InlineData("11111111 10000000 00010001 00000000", "INC", "Word Ptr [BX+SI+0011]")]
        /* */
        [InlineData("11111110 00000000", "INC", "Byte Ptr [BX+SI]")]
        [InlineData("11111110 11000010", "INC", "DL")]
        [InlineData("11111110 01000000 00010001", "INC", "Byte Ptr [BX+SI+11]")]
        [InlineData("11111110 01000111 11011111", "INC", "Byte Ptr [BX-21]")]
        [InlineData("11111110 00000110 00010001 00000000", "INC", "Byte Ptr [0011]")]
        [InlineData("11111110 10000000 00010001 00000000", "INC", "Byte Ptr [BX+SI+0011]")]
        /* */
        public void CheckInc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unsigned Multiply
        /// <remarks>MULU</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110111 00100000", "MUL", "Word Ptr [BX+SI]")]
        [InlineData("11110111 11100011", "MUL", "BX")]
        [InlineData("11110111 01100000 01001011", "MUL", "Word Ptr [BX+SI+4B]")]
        [InlineData("11110111 01100100 00010001", "MUL", "Word Ptr [SI+11]")]
        [InlineData("11110111 00100110 00010001 00000000", "MUL", "Word Ptr [0011]")]
        [InlineData("11110111 10100000 00010001 00000000", "MUL", "Word Ptr [BX+SI+0011]")]
        /* */
        [InlineData("11110110 00100000", "MUL", "Byte Ptr [BX+SI]")]
        [InlineData("11110110 11100100", "MUL", "AH")]
        [InlineData("11110110 01100001 10001001", "MUL", "Byte Ptr [BX+DI-77]")]
        [InlineData("11110110 01100100 00010001", "MUL", "Byte Ptr [SI+11]")]
        [InlineData("11110110 00100110 00010001 00000000", "MUL", "Byte Ptr [0011]")]
        [InlineData("11110110 10100000 00010001 00000000", "MUL", "Byte Ptr [BX+SI+0011]")]
        /* */
        public void CheckMul(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Two's Complement Negation
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110111 00011000", "NEG", "Word Ptr [BX+SI]")]
        [InlineData("11110111 11011010", "NEG", "DX")]
        [InlineData("11110111 01011000 00010001", "NEG", "Word Ptr [BX+SI+11]")]
        [InlineData("11110111 01011100 00010001", "NEG", "Word Ptr [SI+11]")]
        [InlineData("11110111 00011110 00010001 00000000", "NEG", "Word Ptr [0011]")]
        [InlineData("11110111 10011000 00010001 00000000", "NEG", "Word Ptr [BX+SI+0011]")]
        /* */
        [InlineData("11110110 00011000", "NEG", "Byte Ptr [BX+SI]")]
        [InlineData("11110110 11011100", "NEG", "AH")]
        [InlineData("11110110 01011000 00010001", "NEG", "Byte Ptr [BX+SI+11]")]
        [InlineData("11110110 01011100 00010001", "NEG", "Byte Ptr [SI+11]")]
        [InlineData("11110110 10011000 00010001 00000000", "NEG", "Byte Ptr [BX+SI+0011]")]
        [InlineData("11110110 10011111 00101000 00000000", "NEG", "Byte Ptr [BX+0028]")]
        /* */
        public void CheckNeg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// <remarks>SUBC</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00011100 00000001", "SBB", "AL,01")]
        [InlineData("00011100 10110001", "SBB", "AL,B1")]
        /* */
        [InlineData("00011101 00000000 00001000", "SBB", "AX,0800")]
        [InlineData("00011101 00000001 11010001", "SBB", "AX,D101")]
        /* */
        [InlineData("00011011 00000000", "SBB", "AX,Word Ptr [BX+SI]")]
        [InlineData("00011011 11000000", "SBB", "AX,AX")]
        [InlineData("00011011 01001101 11111111", "SBB", "CX,Word Ptr [DI-01]")]
        [InlineData("00011011 01110000 10010101", "SBB", "SI,Word Ptr [BX+SI-6B]")]
        [InlineData("00011011 00000110 00010001 00000000", "SBB", "AX,Word Ptr [0011]")]
        [InlineData("00011011 10000000 10111100 11110010", "SBB", "AX,Word Ptr [BX+SI-0D44]")]
        /* */
        [InlineData("00011010 00000000", "SBB", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00011010 11000000", "SBB", "AL,AL")]
        [InlineData("00011010 01101011 01100101", "SBB", "CH,Byte Ptr [BP+DI+65]")]
        [InlineData("00111110 00011010 00010001", "SBB", "DL,Byte Ptr DS:[BX+DI]")]
        [InlineData("00011010 00000110 00010001 00000000", "SBB", "AL,Byte Ptr [0011]")]
        [InlineData("00011010 10001000 10000100 10011110", "SBB", "CL,Byte Ptr [BX+SI-617C]")]
        /* */
        [InlineData("10000001 00011000 00010001 00000000", "SBB", "Word Ptr [BX+SI],0011")]
        [InlineData("10000001 11011000 00010001 00000000", "SBB", "AX,0011")]
        [InlineData("10000001 01011000 00010001 00000000 11001000", "SBB", "Word Ptr [BX+SI+11],C800")]
        [InlineData("10000001 01011100 00010001 00000000 11001000", "SBB", "Word Ptr [SI+11],C800")]
        [InlineData("00111110 10000001 01011010 10100011 00001100 00000011", "SBB", "Word Ptr DS:[BP+SI-5D],030C")]
        [InlineData("10000001 00011110 00010001 00000000 11001000 00000000", "SBB", "Word Ptr [0011],00C8")]
        /* */
        [InlineData("10000011 00011000 00010001", "SBB", "Word Ptr [BX+SI],+11")]
        [InlineData("10000011 11011011 00001001", "SBB", "BX,+09")]
        [InlineData("10000011 01011000 00010001 00000000", "SBB", "Word Ptr [BX+SI+11],+00")]
        [InlineData("10000011 01011100 00010001 00000000", "SBB", "Word Ptr [SI+11],+00")]
        [InlineData("10000011 00011110 00010001 00000000 11001000", "SBB", "Word Ptr [0011],-38")]
        [InlineData("10000011 10011000 00010001 00000000 11001000", "SBB", "Word Ptr [BX+SI+0011],-38")]
        /* */
        [InlineData("00011001 00000000", "SBB", "Word Ptr [BX+SI],AX")]
        [InlineData("00011001 11011011", "SBB", "BX,BX")]
        [InlineData("00011001 01110001 01010101", "SBB", "Word Ptr [BX+DI+55],SI")]
        [InlineData("00111110 00011001 00010001", "SBB", "Word Ptr DS:[BX+DI],DX")]
        [InlineData("00011001 00000110 00010001 00000000", "SBB", "Word Ptr [0011],AX")]
        [InlineData("00011001 10000000 00010001 00000000", "SBB", "Word Ptr [BX+SI+0011],AX")]
        [InlineData("00111110 00011001 10100111 11011101 10101010", "SBB", "Word Ptr DS:[BX-5523],SP")]
        /* */
        [InlineData("10000010 00011000 00010001", "SBB", "Byte Ptr [BX+SI],11")]
        [InlineData("10000010 11011000 00010001", "SBB", "AL,11")]
        [InlineData("10000010 01011000 00010001 00000000", "SBB", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000010 01011100 00010001 00000000", "SBB", "Byte Ptr [SI+11],00")]
        [InlineData("00101110 10000010 01011001 01011011 01000100", "SBB", "Byte Ptr CS:[BX+DI+5B],44")]
        [InlineData("10000010 00011110 00010001 00000000 11001000", "SBB", "Byte Ptr [0011],C8")]
        /* */
        [InlineData("10000000 00011000 00010001", "SBB", "Byte Ptr [BX+SI],11")]
        [InlineData("10000000 11011100 00001001", "SBB", "AH,09")]
        [InlineData("10000000 01011000 00010001 00000000", "SBB", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000000 01011100 00010001 00000000", "SBB", "Byte Ptr [SI+11],00")]
        [InlineData("10000000 00011110 00010001 00000000 11001000", "SBB", "Byte Ptr [0011],C8")]
        [InlineData("10000000 10011000 00010001 00000000 11001000", "SBB", "Byte Ptr [BX+SI+0011],C8")]
        /* */
        [InlineData("00011000 00000000", "SBB", "Byte Ptr [BX+SI],AL")]
        [InlineData("00011000 11000000", "SBB", "AL,AL")]
        [InlineData("00011000 01000000 00010001", "SBB", "Byte Ptr [BX+SI+11],AL")]
        [InlineData("00111110 00011000 00010001", "SBB", "Byte Ptr DS:[BX+DI],DL")]
        [InlineData("00011000 00000110 00010001 00000000", "SBB", "Byte Ptr [0011],AL")]
        [InlineData("00011000 10000000 00010001 00000000", "SBB", "Byte Ptr [BX+SI+0011],AL")]
        /* */
        public void CheckSbb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Subtract
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00101100 00000000", "SUB", "AL,00")]
        [InlineData("00101100 10101110", "SUB", "AL,AE")]
        /* */
        [InlineData("00101101 00000000 10001011", "SUB", "AX,8B00")]
        [InlineData("00101101 00000001 11111100", "SUB", "AX,FC01")]
        /* */
        [InlineData("00101011 00000000", "SUB", "AX,Word Ptr [BX+SI]")]
        [InlineData("00101011 11101111", "SUB", "BP,DI")]
        [InlineData("00101011 01000011 10001101", "SUB", "AX,Word Ptr [BP+DI-73]")]
        [InlineData("00111110 00101011 00010001", "SUB", "DX,Word Ptr DS:[BX+DI]")]
        [InlineData("00100110 00101011 01001010 01010100", "SUB", "CX,Word Ptr ES:[BP+SI+54]")]
        [InlineData("00101011 00000110 00010001 00000000", "SUB", "AX,Word Ptr [0011]")]
        /* */
        [InlineData("00101010 00000000", "SUB", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00101010 11000000", "SUB", "AL,AL")]
        [InlineData("00101010 01001010 01101000", "SUB", "CL,Byte Ptr [BP+SI+68]")]
        [InlineData("00111110 00101010 00010001", "SUB", "DL,Byte Ptr DS:[BX+DI]")]
        [InlineData("00101010 00000110 00010001 00000000", "SUB", "AL,Byte Ptr [0011]")]
        [InlineData("00101010 10000011 00001001 01111000", "SUB", "AL,Byte Ptr [BP+DI+7809]")]
        [InlineData("00110110 00101010 10101010 00011001 10110001", "SUB", "CH,Byte Ptr SS:[BP+SI-4EE7]")]
        /* */
        [InlineData("10000001 00101000 00010001 00000000", "SUB", "Word Ptr [BX+SI],0011")]
        [InlineData("10000001 11101000 00010001 00000000", "SUB", "AX,0011")]
        [InlineData("10000001 01101000 00010001 00000000 11001000", "SUB", "Word Ptr [BX+SI+11],C800")]
        [InlineData("10000001 01101100 00010001 00000000 11001000", "SUB", "Word Ptr [SI+11],C800")]
        [InlineData("00111110 10000001 01101110 01100000 01011100 11110000", "SUB", "Word Ptr DS:[BP+60],F05C")]
        [InlineData("10000001 00101110 00010001 00000000 11001000 00000000", "SUB", "Word Ptr [0011],00C8")]
        /* */
        [InlineData("10000011 00101000 00010001", "SUB", "Word Ptr [BX+SI],+11")]
        [InlineData("10000011 11101011 00001001", "SUB", "BX,+09")]
        [InlineData("10000011 01101000 00010001 00000000", "SUB", "Word Ptr [BX+SI+11],+00")]
        [InlineData("10000011 01101100 00010001 00000000", "SUB", "Word Ptr [SI+11],+00")]
        [InlineData("10000011 00101110 00010001 00000000 11001000", "SUB", "Word Ptr [0011],-38")]
        [InlineData("10000011 10101000 00010001 00000000 11001000", "SUB", "Word Ptr [BX+SI+0011],-38")]
        /* */
        [InlineData("00101001 00000000", "SUB", "Word Ptr [BX+SI],AX")]
        [InlineData("00101001 11011011", "SUB", "BX,BX")]
        [InlineData("00101001 01101010 10010010", "SUB", "Word Ptr [BP+SI-6E],BP")]
        [InlineData("00111110 00101001 00010001", "SUB", "Word Ptr DS:[BX+DI],DX")]
        [InlineData("00101001 00000110 00010001 00000000", "SUB", "Word Ptr [0011],AX")]
        [InlineData("00101001 10110011 01100010 11101001", "SUB", "Word Ptr [BP+DI-169E],SI")]
        /* */
        [InlineData("10000010 00101000 00010001", "SUB", "Byte Ptr [BX+SI],11")]
        [InlineData("10000010 11101000 00010001", "SUB", "AL,11")]
        [InlineData("10000010 01101000 00010001 00000000", "SUB", "Byte Ptr [BX+SI+11],00")]
        [InlineData("10000010 01101100 00010001 00000000", "SUB", "Byte Ptr [SI+11],00")]
        [InlineData("10000010 00101110 00010001 00000000 11001000", "SUB", "Byte Ptr [0011],C8")]
        [InlineData("10000010 10101000 00010001 00000000 11001000", "SUB", "Byte Ptr [BX+SI+0011],C8")]
        /* */
        [InlineData("10000000 00101000 01011100", "SUB", "Byte Ptr [BX+SI],5C")]
        [InlineData("10000000 11101100 00001001", "SUB", "AH,09")]
        [InlineData("10000000 01101001 00100000 11111101", "SUB", "Byte Ptr [BX+DI+20],FD")]
        [InlineData("10000000 01101100 00010001 00000000", "SUB", "Byte Ptr [SI+11],00")]
        [InlineData("10000000 00101110 00010001 00000000 11001000", "SUB", "Byte Ptr [0011],C8")]
        [InlineData("10000000 10101000 00010001 00000000 11001000", "SUB", "Byte Ptr [BX+SI+0011],C8")]
        [InlineData("00111110 10000000 00101110 10011010 10101000 11111001", "SUB", "Byte Ptr DS:[A89A],F9")]
        /* */
        [InlineData("00101000 00000000", "SUB", "Byte Ptr [BX+SI],AL")]
        [InlineData("00101000 11100100", "SUB", "AH,AH")]
        [InlineData("00100110 00101000 00001100", "SUB", "Byte Ptr ES:[SI],CL")]
        [InlineData("00101000 01010001 10010110", "SUB", "Byte Ptr [BX+DI-6A],DL")]
        [InlineData("00101000 00000110 00010001 00000000", "SUB", "Byte Ptr [0011],AL")]
        [InlineData("00101000 10001000 01100010 00110001", "SUB", "Byte Ptr [BX+SI+3162],CL")]
        /* */
        public void CheckSub(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
