using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class ArithmeticTest : AbstractDecodeTest
    {
        /// <summary>
        /// Add With Carry
        /// </summary>
        [Theory]
        [InlineData("00010000 00000000", "ADC", "Byte Ptr [BX+SI],AL")]
        [InlineData("00010000 00000001", "ADC", "Byte Ptr [BX+DI],AL")]
        [InlineData("00010000 11000101", "ADC", "CH,AL")]
        [InlineData("00010000 11011001", "ADC", "CL,BL")]
        [InlineData("00010000 11100100", "ADC", "AH,AH")]
        [InlineData("00010001 00000000", "ADC", "Word Ptr [BX+SI],AX")]
        [InlineData("00010001 00000001", "ADC", "Word Ptr [BX+DI],AX")]
        [InlineData("00010001 00010010", "ADC", "Word Ptr [BP+SI],DX")]
        [InlineData("00010001 00100000", "ADC", "Word Ptr [BX+SI],SP")]
        [InlineData("00010001 00100111", "ADC", "Word Ptr [BX],SP")]
        [InlineData("00010001 00101000", "ADC", "Word Ptr [BX+SI],BP")]
        [InlineData("00010001 00111011", "ADC", "Word Ptr [BP+DI],DI")]
        [InlineData("00010001 11010111", "ADC", "DI,DX")]
        [InlineData("00010001 11011000", "ADC", "AX,BX")]
        [InlineData("00010001 11011011", "ADC", "BX,BX")]
        [InlineData("00010001 11100101", "ADC", "BP,SP")]
        [InlineData("00010001 11101011", "ADC", "BX,BP")]
        [InlineData("00010001 11110110", "ADC", "SI,SI")]
        [InlineData("00010001 11111001", "ADC", "CX,DI")]
        [InlineData("00010010 00000000", "ADC", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00010010 00101000", "ADC", "CH,Byte Ptr [BX+SI]")]
        [InlineData("00010010 11010011", "ADC", "DL,BL")]
        [InlineData("00010010 11100001", "ADC", "AH,CL")]
        [InlineData("00010010 11100100", "ADC", "AH,AH")]
        [InlineData("00010011 00000000", "ADC", "AX,Word Ptr [BX+SI]")]
        [InlineData("00010011 00000001", "ADC", "AX,Word Ptr [BX+DI]")]
        [InlineData("00010011 00100010", "ADC", "SP,Word Ptr [BP+SI]")]
        [InlineData("00010011 00101010", "ADC", "BP,Word Ptr [BP+SI]")]
        [InlineData("00010011 11000111", "ADC", "AX,DI")]
        [InlineData("00010100 00000000", "ADC", "AL,00")]
        [InlineData("00010100 00000001", "ADC", "AL,01")]
        [InlineData("00010100 00111001", "ADC", "AL,39")]
        [InlineData("00010100 01001111", "ADC", "AL,4F")]
        [InlineData("00010100 01011010", "ADC", "AL,5A")]
        [InlineData("00010100 01101000", "ADC", "AL,68")]
        [InlineData("00010100 11000100", "ADC", "AL,C4")]
        [InlineData("00010100 11011010", "ADC", "AL,DA")]
        [InlineData("00010100 11100010", "ADC", "AL,E2")]
        [InlineData("00010000 01000010 11110011", "ADC", "Byte Ptr [BP+SI-0D],AL")]
        [InlineData("00010000 01100010 00111100", "ADC", "Byte Ptr [BP+SI+3C],AH")]
        [InlineData("00010000 01101111 00110100", "ADC", "Byte Ptr [BX+34],CH")]
        [InlineData("00010010 01000000 10111100", "ADC", "AL,Byte Ptr [BX+SI-44]")]
        [InlineData("00010010 01010111 10111001", "ADC", "DL,Byte Ptr [BX-47]")]
        [InlineData("00010010 01100011 10000000", "ADC", "AH,Byte Ptr [BP+DI-80]")]
        [InlineData("00010010 01111101 00100100", "ADC", "BH,Byte Ptr [DI+24]")]
        [InlineData("00010011 01000111 10110100", "ADC", "AX,Word Ptr [BX-4C]")]
        [InlineData("00010011 01010110 11111010", "ADC", "DX,Word Ptr [BP-06]")]
        [InlineData("00010011 01111101 10010001", "ADC", "DI,Word Ptr [DI-6F]")]
        [InlineData("00010101 00000000 00110100", "ADC", "AX,3400")]
        [InlineData("00010101 00000001 01010010", "ADC", "AX,5201")]
        [InlineData("00010101 00010001 10011000", "ADC", "AX,9811")]
        [InlineData("00010101 01111010 10000111", "ADC", "AX,877A")]
        [InlineData("00010101 11001000 00110111", "ADC", "AX,37C8")]
        [InlineData("00010101 11011011 01101001", "ADC", "AX,69DB")]
        [InlineData("00010101 11101010 11001110", "ADC", "AX,CEEA")]
        [InlineData("10000000 00010101 00101111", "ADC", "Byte Ptr [DI],2F")]
        [InlineData("10000000 11010100 00001001", "ADC", "AH,09")]
        [InlineData("10000011 11010011 00001001", "ADC", "BX,+09")]
        [InlineData("00010001 00000110 00101111 00100100", "ADC", "Word Ptr [242F],AX")]
        [InlineData("00010001 00000110 10001001 10001000", "ADC", "Word Ptr [8889],AX")]
        [InlineData("00010001 00110110 00001111 01000010", "ADC", "Word Ptr [420F],SI")]
        [InlineData("00010001 10101011 10011011 01101011", "ADC", "Word Ptr [BP+DI+6B9B],BP")]
        [InlineData("00010010 00100110 01001010 11001101", "ADC", "AH,Byte Ptr [CD4A]")]
        [InlineData("00010011 10010110 01010010 01010010", "ADC", "DX,Word Ptr [BP+5252]")]
        [InlineData("00010011 10011110 00000000 11101010", "ADC", "BX,Word Ptr [BP-1600]")]
        [InlineData("00010011 10101001 10001000 01110100", "ADC", "BP,Word Ptr [BX+DI+7488]")]
        public void CheckAdc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Add
        /// </summary>
        [Theory]
        [InlineData("00000000 00000000", "ADD", "Byte Ptr [BX+SI],AL")]
        [InlineData("00000000 00000001", "ADD", "Byte Ptr [BX+DI],AL")]
        [InlineData("00000000 00000010", "ADD", "Byte Ptr [BP+SI],AL")]
        [InlineData("00000000 00011001", "ADD", "Byte Ptr [BX+DI],BL")]
        [InlineData("00000000 00100001", "ADD", "Byte Ptr [BX+DI],AH")]
        [InlineData("00000000 00111011", "ADD", "Byte Ptr [BP+DI],BH")]
        [InlineData("00000000 11100010", "ADD", "DL,AH")]
        [InlineData("00000000 11100100", "ADD", "AH,AH")]
        [InlineData("00000000 11101001", "ADD", "CL,CH")]
        [InlineData("00000000 11110011", "ADD", "BL,DH")]
        [InlineData("00000001 00000000", "ADD", "Word Ptr [BX+SI],AX")]
        [InlineData("00000001 00000001", "ADD", "Word Ptr [BX+DI],AX")]
        [InlineData("00000001 00000010", "ADD", "Word Ptr [BP+SI],AX")]
        [InlineData("00000001 00111101", "ADD", "Word Ptr [DI],DI")]
        [InlineData("00000001 11010010", "ADD", "DX,DX")]
        [InlineData("00000001 11011000", "ADD", "AX,BX")]
        [InlineData("00000001 11011011", "ADD", "BX,BX")]
        [InlineData("00000001 11100000", "ADD", "AX,SP")]
        [InlineData("00000001 11100100", "ADD", "SP,SP")]
        [InlineData("00000001 11111001", "ADD", "CX,DI")]
        [InlineData("00000010 00000000", "ADD", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00000010 00000001", "ADD", "AL,Byte Ptr [BX+DI]")]
        [InlineData("00000010 00000010", "ADD", "AL,Byte Ptr [BP+SI]")]
        [InlineData("00000010 00000111", "ADD", "AL,Byte Ptr [BX]")]
        [InlineData("00000010 00100101", "ADD", "AH,Byte Ptr [DI]")]
        [InlineData("00000010 11000010", "ADD", "AL,DL")]
        [InlineData("00000010 11011010", "ADD", "BL,DL")]
        [InlineData("00000010 11100000", "ADD", "AH,AL")]
        [InlineData("00000011 00000000", "ADD", "AX,Word Ptr [BX+SI]")]
        [InlineData("00000011 00000001", "ADD", "AX,Word Ptr [BX+DI]")]
        [InlineData("00000011 00000010", "ADD", "AX,Word Ptr [BP+SI]")]
        [InlineData("00000011 11110110", "ADD", "SI,SI")]
        [InlineData("00000011 11111100", "ADD", "DI,SP")]
        [InlineData("00000100 00000000", "ADD", "AL,00")]
        [InlineData("00000100 00000001", "ADD", "AL,01")]
        [InlineData("00000100 00000010", "ADD", "AL,02")]
        [InlineData("00000100 00000011", "ADD", "AL,03")]
        [InlineData("00000100 00000100", "ADD", "AL,04")]
        [InlineData("00000100 00100110", "ADD", "AL,26")]
        [InlineData("00000100 00111011", "ADD", "AL,3B")]
        [InlineData("00000100 10100000", "ADD", "AL,A0")]
        [InlineData("00000100 11001110", "ADD", "AL,CE")]
        [InlineData("00000100 11110110", "ADD", "AL,F6")]
        [InlineData("00000000 01000011 01100101", "ADD", "Byte Ptr [BP+DI+65],AL")]
        [InlineData("00000000 01010011 00111011", "ADD", "Byte Ptr [BP+DI+3B],DL")]
        [InlineData("00000000 01010101 01101100", "ADD", "Byte Ptr [DI+6C],DL")]
        [InlineData("00000001 01000001 10001101", "ADD", "Word Ptr [BX+DI-73],AX")]
        [InlineData("00000001 01000011 11100010", "ADD", "Word Ptr [BP+DI-1E],AX")]
        [InlineData("00000010 01001110 01100101", "ADD", "CL,Byte Ptr [BP+65]")]
        [InlineData("00000010 01011110 10100111", "ADD", "BL,Byte Ptr [BP-59]")]
        [InlineData("00000011 01011000 00001010", "ADD", "BX,Word Ptr [BX+SI+0A]")]
        [InlineData("00000011 01100111 11010100", "ADD", "SP,Word Ptr [BX-2C]")]
        [InlineData("00000011 01101111 00101001", "ADD", "BP,Word Ptr [BX+29]")]
        [InlineData("00000011 01101111 10011100", "ADD", "BP,Word Ptr [BX-64]")]
        [InlineData("00000101 00000000 01001111", "ADD", "AX,4F00")]
        [InlineData("00000101 00000000 01010101", "ADD", "AX,5500")]
        [InlineData("00000101 00000010 10010100", "ADD", "AX,9402")]
        [InlineData("00000101 00101010 11011110", "ADD", "AX,DE2A")]
        [InlineData("00000101 01000111 01000100", "ADD", "AX,4447")]
        [InlineData("00000101 01001110 10001011", "ADD", "AX,8B4E")]
        [InlineData("00000101 01110110 11010000", "ADD", "AX,D076")]
        [InlineData("00000101 10110100 01010001", "ADD", "AX,51B4")]
        [InlineData("00000101 10111110 10111001", "ADD", "AX,B9BE")]
        [InlineData("00000101 11001011 10101101", "ADD", "AX,ADCB")]
        [InlineData("00000101 11001111 00001001", "ADD", "AX,09CF")]
        [InlineData("00000101 11100101 00111101", "ADD", "AX,3DE5")]
        [InlineData("00100110 00000000 00101011", "ADD", "Byte Ptr ES:[BP+DI],CH")]
        [InlineData("10000000 00000000 11000000", "ADD", "Byte Ptr [BX+SI],C0")]
        [InlineData("10000000 00000001 10110011", "ADD", "Byte Ptr [BX+DI],B3")]
        [InlineData("10000000 11000100 00001001", "ADD", "AH,09")]
        [InlineData("10000000 11000100 10000001", "ADD", "AH,81")]
        [InlineData("10000000 11000111 01010000", "ADD", "BH,50")]
        [InlineData("10000010 00000000 11000011", "ADD", "Byte Ptr [BX+SI],C3")]
        [InlineData("10000010 00000001 00001100", "ADD", "Byte Ptr [BX+DI],0C")]
        [InlineData("10000011 00000000 10010100", "ADD", "Word Ptr [BX+SI],-6C")]
        [InlineData("10000011 00000001 11110000", "ADD", "Word Ptr [BX+DI],-10")]
        [InlineData("10000011 11000011 00001001", "ADD", "BX,+09")]
        [InlineData("00000000 10000100 00011100 00100010", "ADD", "Byte Ptr [SI+221C],AL")]
        [InlineData("00000000 10001101 00100001 10001001", "ADD", "Byte Ptr [DI-76DF],CL")]
        [InlineData("00000001 10011000 01011011 00100000", "ADD", "Word Ptr [BX+SI+205B],BX")]
        [InlineData("00000001 10101011 10100110 11011100", "ADD", "Word Ptr [BP+DI-235A],BP")]
        [InlineData("00000010 10001011 10111001 10100111", "ADD", "CL,Byte Ptr [BP+DI-5847]")]
        [InlineData("00000010 10100001 01101111 10100100", "ADD", "AH,Byte Ptr [BX+DI-5B91]")]
        [InlineData("00000010 10101000 01001101 00000011", "ADD", "CH,Byte Ptr [BX+SI+034D]")]
        [InlineData("00000010 10101001 11100010 11111100", "ADD", "CH,Byte Ptr [BX+DI-031E]")]
        [InlineData("00000011 10000111 01100000 00101000", "ADD", "AX,Word Ptr [BX+2860]")]
        [InlineData("00000011 10001011 10011101 00010010", "ADD", "CX,Word Ptr [BP+DI+129D]")]
        [InlineData("00000011 10001111 00001111 11101100", "ADD", "CX,Word Ptr [BX-13F1]")]
        [InlineData("00000011 10010000 11101001 00101100", "ADD", "DX,Word Ptr [BX+SI+2CE9]")]
        [InlineData("00000011 10010101 01010010 11111001", "ADD", "DX,Word Ptr [DI-06AE]")]
        [InlineData("00000011 10100000 10100001 11000000", "ADD", "SP,Word Ptr [BX+SI-3F5F]")]
        [InlineData("00000011 10101111 01011011 01110000", "ADD", "BP,Word Ptr [BX+705B]")]
        [InlineData("00000011 10111011 01000011 11010000", "ADD", "DI,Word Ptr [BP+DI-2FBD]")]
        [InlineData("00111110 00000001 01000001 00100111", "ADD", "Word Ptr DS:[BX+DI+27],AX")]
        [InlineData("10000001 00000000 01101100 01110011", "ADD", "Word Ptr [BX+SI],736C")]
        [InlineData("10000001 00000001 01011100 10100101", "ADD", "Word Ptr [BX+DI],A55C")]
        [InlineData("10000010 01000010 00000011 01000011", "ADD", "Byte Ptr [BP+SI+03],43")]
        [InlineData("00110110 00000000 10111101 00110011 10001011", "ADD", "Byte Ptr SS:[DI-74CD],BH")]
        [InlineData("00110110 00000001 00001110 01011100 11010111", "ADD", "Word Ptr SS:[D75C],CX")]
        [InlineData("10000001 10000111 00001111 10001011 01110101 00001110", "ADD", "Word Ptr [BX-74F1],0E75")]
        public void CheckAdd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Compare Two Operands
        /// </summary>
        [Theory]
        [InlineData("00111000 00000000", "CMP", "Byte Ptr [BX+SI],AL")]
        [InlineData("00111000 00000001", "CMP", "Byte Ptr [BX+DI],AL")]
        [InlineData("00111000 00011101", "CMP", "Byte Ptr [DI],BL")]
        [InlineData("00111000 00101000", "CMP", "Byte Ptr [BX+SI],CH")]
        [InlineData("00111000 11000000", "CMP", "AL,AL")]
        [InlineData("00111000 11001001", "CMP", "CL,CL")]
        [InlineData("00111000 11010010", "CMP", "DL,DL")]
        [InlineData("00111000 11011000", "CMP", "AL,BL")]
        [InlineData("00111000 11011011", "CMP", "BL,BL")]
        [InlineData("00111000 11011111", "CMP", "BH,BL")]
        [InlineData("00111000 11100100", "CMP", "AH,AH")]
        [InlineData("00111000 11101101", "CMP", "CH,CH")]
        [InlineData("00111000 11110100", "CMP", "AH,DH")]
        [InlineData("00111000 11110110", "CMP", "DH,DH")]
        [InlineData("00111000 11111111", "CMP", "BH,BH")]
        [InlineData("00111001 00000000", "CMP", "Word Ptr [BX+SI],AX")]
        [InlineData("00111001 00000001", "CMP", "Word Ptr [BX+DI],AX")]
        [InlineData("00111001 00001000", "CMP", "Word Ptr [BX+SI],CX")]
        [InlineData("00111001 00101100", "CMP", "Word Ptr [SI],BP")]
        [InlineData("00111001 11011011", "CMP", "BX,BX")]
        [InlineData("00111001 11100100", "CMP", "SP,SP")]
        [InlineData("00111001 11111100", "CMP", "SP,DI")]
        [InlineData("00111010 00000000", "CMP", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00111010 00000001", "CMP", "AL,Byte Ptr [BX+DI]")]
        [InlineData("00111010 00100011", "CMP", "AH,Byte Ptr [BP+DI]")]
        [InlineData("00111010 11010101", "CMP", "DL,CH")]
        [InlineData("00111010 11101000", "CMP", "CH,AL")]
        [InlineData("00111010 11110011", "CMP", "DH,BL")]
        [InlineData("00111011 00000000", "CMP", "AX,Word Ptr [BX+SI]")]
        [InlineData("00111011 00000001", "CMP", "AX,Word Ptr [BX+DI]")]
        [InlineData("00111011 00101000", "CMP", "BP,Word Ptr [BX+SI]")]
        [InlineData("00111011 00111011", "CMP", "DI,Word Ptr [BP+DI]")]
        [InlineData("00111011 11010011", "CMP", "DX,BX")]
        [InlineData("00111100 00000000", "CMP", "AL,00")]
        [InlineData("00111100 00000001", "CMP", "AL,01")]
        [InlineData("00111100 00100010", "CMP", "AL,22")]
        [InlineData("00111100 00100101", "CMP", "AL,25")]
        [InlineData("00111100 00101100", "CMP", "AL,2C")]
        [InlineData("00111100 00110001", "CMP", "AL,31")]
        [InlineData("00111100 01011010", "CMP", "AL,5A")]
        [InlineData("00111100 01100001", "CMP", "AL,61")]
        [InlineData("00111100 01110101", "CMP", "AL,75")]
        [InlineData("00111100 10001010", "CMP", "AL,8A")]
        [InlineData("00111100 10001011", "CMP", "AL,8B")]
        [InlineData("00111100 10010111", "CMP", "AL,97")]
        [InlineData("00111100 10011000", "CMP", "AL,98")]
        [InlineData("00111100 10110001", "CMP", "AL,B1")]
        [InlineData("00111100 11011101", "CMP", "AL,DD")]
        [InlineData("00111100 11101000", "CMP", "AL,E8")]
        [InlineData("00111100 11101111", "CMP", "AL,EF")]
        [InlineData("00111000 01001100 11011010", "CMP", "Byte Ptr [SI-26],CL")]
        [InlineData("00111000 01011100 00011101", "CMP", "Byte Ptr [SI+1D],BL")]
        [InlineData("00111000 01100000 00010101", "CMP", "Byte Ptr [BX+SI+15],AH")]
        [InlineData("00111001 01010110 11000011", "CMP", "Word Ptr [BP-3D],DX")]
        [InlineData("00111010 01000000 00111111", "CMP", "AL,Byte Ptr [BX+SI+3F]")]
        [InlineData("00111010 01010010 10101000", "CMP", "DL,Byte Ptr [BP+SI-58]")]
        [InlineData("00111010 01100011 11000001", "CMP", "AH,Byte Ptr [BP+DI-3F]")]
        [InlineData("00111010 01100101 10111111", "CMP", "AH,Byte Ptr [DI-41]")]
        [InlineData("00111011 01011001 11000011", "CMP", "BX,Word Ptr [BX+DI-3D]")]
        [InlineData("00111101 00000000 11111110", "CMP", "AX,FE00")]
        [InlineData("00111101 00000001 01111000", "CMP", "AX,7801")]
        [InlineData("00111101 00000100 10000001", "CMP", "AX,8104")]
        [InlineData("00111101 00001100 01001111", "CMP", "AX,4F0C")]
        [InlineData("00111101 00111010 11001110", "CMP", "AX,CE3A")]
        [InlineData("00111101 01100011 11101011", "CMP", "AX,EB63")]
        [InlineData("00111101 10010110 00011011", "CMP", "AX,1B96")]
        [InlineData("00111101 10110011 11101100", "CMP", "AX,ECB3")]
        [InlineData("00111101 10111001 11011110", "CMP", "AX,DEB9")]
        [InlineData("00111101 11101000 00000001", "CMP", "AX,01E8")]
        [InlineData("10000000 11111100 00001001", "CMP", "AH,09")]
        [InlineData("10000010 00111111 11001001", "CMP", "Byte Ptr [BX],C9")]
        [InlineData("10000011 11111011 00001001", "CMP", "BX,+09")]
        [InlineData("00111000 10111011 10101110 10001111", "CMP", "Byte Ptr [BP+DI-7052],BH")]
        [InlineData("00111000 10111011 11010101 00111000", "CMP", "Byte Ptr [BP+DI+38D5],BH")]
        [InlineData("00111000 10111110 11000101 00111100", "CMP", "Byte Ptr [BP+3CC5],BH")]
        [InlineData("00111001 00100110 11110010 01010001", "CMP", "Word Ptr [51F2],SP")]
        [InlineData("00111001 10100101 01101110 10110011", "CMP", "Word Ptr [DI-4C92],SP")]
        [InlineData("00111001 10110100 01011100 10100110", "CMP", "Word Ptr [SI-59A4],SI")]
        [InlineData("00111010 10011110 11111100 10001100", "CMP", "BL,Byte Ptr [BP-7304]")]
        [InlineData("00111011 10111101 10101001 11101111", "CMP", "DI,Word Ptr [DI-1057]")]
        [InlineData("10000001 11111101 01101011 01000101", "CMP", "BP,456B")]
        [InlineData("10000011 01111111 00010110 01000110", "CMP", "Word Ptr [BX+16],+46")]
        [InlineData("10000000 10111000 00110100 00010101 00110110", "CMP", "Byte Ptr [BX+SI+1534],36")]
        [InlineData("10000001 10111111 00101000 00100011 00100111 11011111", "CMP", "Word Ptr [BX+2328],DF27")]
        public void CheckCmp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decrement by 1
        /// </summary>
        [Theory]
        [InlineData("01001000", "DEC", "AX")]
        [InlineData("01001001", "DEC", "CX")]
        [InlineData("01001010", "DEC", "DX")]
        [InlineData("01001011", "DEC", "BX")]
        [InlineData("01001100", "DEC", "SP")]
        [InlineData("01001101", "DEC", "BP")]
        [InlineData("01001110", "DEC", "SI")]
        [InlineData("01001111", "DEC", "DI")]
        [InlineData("11111110 00101000", "DEC", "Byte Ptr [BX+SI]")]
        [InlineData("11111110 11001100", "DEC", "AH")]
        [InlineData("11111110 11001111", "DEC", "BH")]
        [InlineData("11111110 11101111", "DEC", "BH")]
        [InlineData("11111110 11111001", "DEC", "CL")]
        [InlineData("11111110 11111010", "DEC", "DL")]
        [InlineData("11111111 00001111", "DEC", "Word Ptr [BX]")]
        [InlineData("00110110 11111110 00011000", "DEC", "Byte Ptr SS:[BX+SI]")]
        [InlineData("11111111 01001010 00110101", "DEC", "Word Ptr [BP+SI+35]")]
        [InlineData("11111110 10001100 00111111 01110000", "DEC", "Byte Ptr [SI+703F]")]
        public void CheckDec(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unsigned Divide
        /// </summary>
        [Theory]
        [InlineData("11110110 11110100", "DIV", "AH")]
        [InlineData("11110111 00110011", "DIV", "Word Ptr [BP+DI]")]
        [InlineData("11110111 11110000", "DIV", "AX")]
        [InlineData("11110111 11110001", "DIV", "CX")]
        [InlineData("11110111 11110010", "DIV", "DX")]
        [InlineData("11110111 11110011", "DIV", "BX")]
        [InlineData("11110111 11110100", "DIV", "SP")]
        [InlineData("11110111 11110101", "DIV", "BP")]
        [InlineData("11110111 11110110", "DIV", "SI")]
        [InlineData("11110111 11110111", "DIV", "DI")]
        [InlineData("11110111 10110000 01110000 11110111", "DIV", "Word Ptr [BX+SI-0890]")]
        [InlineData("11110111 10110010 01000000 01100011", "DIV", "Word Ptr [BP+SI+6340]")]
        public void CheckDiv(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Signed Divide
        /// </summary>
        [Theory]
        [InlineData("11110110 11111100", "IDIV", "AH")]
        [InlineData("11110111 11111000", "IDIV", "AX")]
        [InlineData("11110111 11111001", "IDIV", "CX")]
        [InlineData("11110111 11111010", "IDIV", "DX")]
        [InlineData("11110111 11111011", "IDIV", "BX")]
        [InlineData("11110111 11111100", "IDIV", "SP")]
        [InlineData("11110111 11111101", "IDIV", "BP")]
        [InlineData("11110111 11111110", "IDIV", "SI")]
        [InlineData("11110111 11111111", "IDIV", "DI")]
        [InlineData("11110111 01111000 10010100", "IDIV", "Word Ptr [BX+SI-6C]")]
        public void CheckIdiv(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Signed Multiply
        /// </summary>
        [Theory]
        [InlineData("11110110 11101100", "IMUL", "AH")]
        [InlineData("11110111 11101000", "IMUL", "AX")]
        [InlineData("11110111 11101001", "IMUL", "CX")]
        [InlineData("11110111 11101010", "IMUL", "DX")]
        [InlineData("11110111 11101011", "IMUL", "BX")]
        [InlineData("11110111 11101100", "IMUL", "SP")]
        [InlineData("11110111 11101101", "IMUL", "BP")]
        [InlineData("11110111 11101110", "IMUL", "SI")]
        [InlineData("11110111 11101111", "IMUL", "DI")]
        [InlineData("01101011 00010111 11110001", "IMUL", "DX,Word Ptr [BX],F1")]
        [InlineData("01101011 11000111 01001011", "IMUL", "AX,DI,4B")]
        [InlineData("01101011 11000111 01100111", "IMUL", "AX,DI,67")]
        [InlineData("01101011 11010010 11011100", "IMUL", "DX,DX,DC")]
        [InlineData("01101011 11011011 00001001", "IMUL", "BX,BX,09")]
        [InlineData("01101011 11011111 11010111", "IMUL", "BX,DI,D7")]
        [InlineData("01101011 11100011 11101010", "IMUL", "SP,BX,EA")]
        [InlineData("01101011 11100100 01010011", "IMUL", "SP,SP,53")]
        [InlineData("01101011 11101010 00110100", "IMUL", "BP,DX,34")]
        [InlineData("01101011 11110010 11110011", "IMUL", "SI,DX,F3")]
        [InlineData("01101001 00000000 00000010 01011000", "IMUL", "AX,Word Ptr [BX+SI],5802")]
        [InlineData("01101001 00011001 00110000 11100010", "IMUL", "BX,Word Ptr [BX+DI],E230")]
        [InlineData("01101001 11000011 01101100 00101001", "IMUL", "AX,BX,296C")]
        [InlineData("01101001 11001001 10111100 10010111", "IMUL", "CX,CX,97BC")]
        [InlineData("01101001 11010110 00111011 11010111", "IMUL", "DX,SI,D73B")]
        [InlineData("01101001 11110111 01111010 11111010", "IMUL", "SI,DI,FA7A")]
        [InlineData("01101011 01000101 01111110 00001010", "IMUL", "AX,Word Ptr [DI+7E],0A")]
        [InlineData("01101011 01001010 01010101 01100001", "IMUL", "CX,Word Ptr [BP+SI+55],61")]
        [InlineData("01101011 01010110 00010011 10101001", "IMUL", "DX,Word Ptr [BP+13],A9")]
        [InlineData("01101011 01100010 11101011 01111101", "IMUL", "SP,Word Ptr [BP+SI-15],7D")]
        [InlineData("11110110 10101011 10101000 00011001", "IMUL", "Byte Ptr [BP+DI+19A8]")]
        [InlineData("11110110 10101101 01110000 01100101", "IMUL", "Byte Ptr [DI+6570]")]
        [InlineData("11110110 10101101 11000001 10000000", "IMUL", "Byte Ptr [DI-7F3F]")]
        [InlineData("11110111 10101000 00110001 01100100", "IMUL", "Word Ptr [BX+SI+6431]")]
        [InlineData("01101001 01000110 01101011 01110111 11010011", "IMUL", "AX,Word Ptr [BP+6B],D377")]
        [InlineData("01101001 01100000 10001000 10100001 10000011", "IMUL", "SP,Word Ptr [BX+SI-78],83A1")]
        [InlineData("01101001 01111111 00111100 11011001 11000011", "IMUL", "DI,Word Ptr [BX+3C],C3D9")]
        [InlineData("01101011 00000110 01001111 11000001 10101001", "IMUL", "AX,Word Ptr [C14F],A9")]
        [InlineData("01101001 10111001 10001000 00101111 11110011 01001111", "IMUL", "DI,Word Ptr [BX+DI+2F88],4FF3")]
        [InlineData("00110110 01101001 10101100 01110010 01111101 00100110 00000011", "IMUL", "BP,Word Ptr SS:[SI+7D72],0326")]
        public void CheckImul(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Increment by 1
        /// </summary>
        [Theory]
        [InlineData("01000000", "INC", "AX")]
        [InlineData("01000001", "INC", "CX")]
        [InlineData("01000010", "INC", "DX")]
        [InlineData("01000011", "INC", "BX")]
        [InlineData("01000100", "INC", "SP")]
        [InlineData("01000101", "INC", "BP")]
        [InlineData("01000110", "INC", "SI")]
        [InlineData("01000111", "INC", "DI")]
        [InlineData("11111110 00000000", "INC", "Byte Ptr [BX+SI]")]
        [InlineData("11111110 00000001", "INC", "Byte Ptr [BX+DI]")]
        [InlineData("11111110 11000000", "INC", "AL")]
        [InlineData("11111110 11000001", "INC", "CL")]
        [InlineData("11111110 11000010", "INC", "DL")]
        [InlineData("11111110 11000011", "INC", "BL")]
        [InlineData("11111110 11000100", "INC", "AH")]
        [InlineData("11111110 11000101", "INC", "CH")]
        [InlineData("11111110 11000110", "INC", "DH")]
        [InlineData("11111110 11000111", "INC", "BH")]
        [InlineData("11111111 00000000", "INC", "Word Ptr [BX+SI]")]
        [InlineData("11111111 00000001", "INC", "Word Ptr [BX+DI]")]
        [InlineData("11111111 00000101", "INC", "Word Ptr [DI]")]
        [InlineData("11111110 01000111 11011111", "INC", "Byte Ptr [BX-21]")]
        [InlineData("11111110 01100001 00101011", "INC", "Byte Ptr [BX+DI+2B]")]
        [InlineData("11111110 01110000 11110101", "INC", "Byte Ptr [BX+SI-0B]")]
        public void CheckInc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unsigned Multiply
        /// </summary>
        [Theory]
        [InlineData("11110110 11100100", "MUL", "AH")]
        [InlineData("11110111 11100000", "MUL", "AX")]
        [InlineData("11110111 11100001", "MUL", "CX")]
        [InlineData("11110111 11100010", "MUL", "DX")]
        [InlineData("11110111 11100011", "MUL", "BX")]
        [InlineData("11110111 11100100", "MUL", "SP")]
        [InlineData("11110111 11100101", "MUL", "BP")]
        [InlineData("11110111 11100110", "MUL", "SI")]
        [InlineData("11110111 11100111", "MUL", "DI")]
        [InlineData("11110110 01100001 10001001", "MUL", "Byte Ptr [BX+DI-77]")]
        [InlineData("11110111 01100000 01001011", "MUL", "Word Ptr [BX+SI+4B]")]
        public void CheckMul(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Two's Complement Negation
        /// </summary>
        [Theory]
        [InlineData("11110110 11011100", "NEG", "AH")]
        [InlineData("11110111 11011000", "NEG", "AX")]
        [InlineData("11110111 11011001", "NEG", "CX")]
        [InlineData("11110111 11011010", "NEG", "DX")]
        [InlineData("11110111 11011011", "NEG", "BX")]
        [InlineData("11110111 11011100", "NEG", "SP")]
        [InlineData("11110111 11011101", "NEG", "BP")]
        [InlineData("11110111 11011110", "NEG", "SI")]
        [InlineData("11110111 11011111", "NEG", "DI")]
        [InlineData("11110110 10011111 00101000 00000000", "NEG", "Byte Ptr [BX+0028]")]
        public void CheckNeg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// </summary>
        [Theory]
        [InlineData("00011000 00000000", "SBB", "Byte Ptr [BX+SI],AL")]
        [InlineData("00011000 00000001", "SBB", "Byte Ptr [BX+DI],AL")]
        [InlineData("00011000 00101010", "SBB", "Byte Ptr [BP+SI],CH")]
        [InlineData("00011000 11000000", "SBB", "AL,AL")]
        [InlineData("00011000 11100100", "SBB", "AH,AH")]
        [InlineData("00011000 11101010", "SBB", "DL,CH")]
        [InlineData("00011000 11101111", "SBB", "BH,CH")]
        [InlineData("00011001 00000000", "SBB", "Word Ptr [BX+SI],AX")]
        [InlineData("00011001 00000001", "SBB", "Word Ptr [BX+DI],AX")]
        [InlineData("00011001 00001100", "SBB", "Word Ptr [SI],CX")]
        [InlineData("00011001 00111001", "SBB", "Word Ptr [BX+DI],DI")]
        [InlineData("00011001 00111111", "SBB", "Word Ptr [BX],DI")]
        [InlineData("00011001 11011011", "SBB", "BX,BX")]
        [InlineData("00011001 11100110", "SBB", "SI,SP")]
        [InlineData("00011001 11111101", "SBB", "BP,DI")]
        [InlineData("00011001 11111111", "SBB", "DI,DI")]
        [InlineData("00011010 00000000", "SBB", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00011010 00000001", "SBB", "AL,Byte Ptr [BX+DI]")]
        [InlineData("00011011 00000000", "SBB", "AX,Word Ptr [BX+SI]")]
        [InlineData("00011011 00000001", "SBB", "AX,Word Ptr [BX+DI]")]
        [InlineData("00011011 00101000", "SBB", "BP,Word Ptr [BX+SI]")]
        [InlineData("00011011 00101100", "SBB", "BP,Word Ptr [SI]")]
        [InlineData("00011100 00000001", "SBB", "AL,01")]
        [InlineData("00011100 00001000", "SBB", "AL,08")]
        [InlineData("00011100 00010011", "SBB", "AL,13")]
        [InlineData("00011100 00011100", "SBB", "AL,1C")]
        [InlineData("00011100 00101100", "SBB", "AL,2C")]
        [InlineData("00011100 00111001", "SBB", "AL,39")]
        [InlineData("00011100 01000000", "SBB", "AL,40")]
        [InlineData("00011100 01011101", "SBB", "AL,5D")]
        [InlineData("00011100 01011111", "SBB", "AL,5F")]
        [InlineData("00011100 01110010", "SBB", "AL,72")]
        [InlineData("00011100 10000100", "SBB", "AL,84")]
        [InlineData("00011100 10110001", "SBB", "AL,B1")]
        [InlineData("00011100 11010011", "SBB", "AL,D3")]
        [InlineData("00011100 11110010", "SBB", "AL,F2")]
        [InlineData("00011100 11110100", "SBB", "AL,F4")]
        [InlineData("00011000 01000101 00010110", "SBB", "Byte Ptr [DI+16],AL")]
        [InlineData("00011000 01110100 11100100", "SBB", "Byte Ptr [SI-1C],DH")]
        [InlineData("00011001 01011111 01001111", "SBB", "Word Ptr [BX+4F],BX")]
        [InlineData("00011001 01110001 01010101", "SBB", "Word Ptr [BX+DI+55],SI")]
        [InlineData("00011010 01101011 01100101", "SBB", "CH,Byte Ptr [BP+DI+65]")]
        [InlineData("00011010 01111110 11000011", "SBB", "BH,Byte Ptr [BP-3D]")]
        [InlineData("00011011 01001101 11111111", "SBB", "CX,Word Ptr [DI-01]")]
        [InlineData("00011011 01110000 10010101", "SBB", "SI,Word Ptr [BX+SI-6B]")]
        [InlineData("00011101 00000000 00001000", "SBB", "AX,0800")]
        [InlineData("00011101 00000001 11010001", "SBB", "AX,D101")]
        [InlineData("00011101 00001110 01000011", "SBB", "AX,430E")]
        [InlineData("00011101 00111011 00010111", "SBB", "AX,173B")]
        [InlineData("00011101 00111110 11100110", "SBB", "AX,E63E")]
        [InlineData("00011101 01100011 00100010", "SBB", "AX,2263")]
        [InlineData("00011101 10001001 11001001", "SBB", "AX,C989")]
        [InlineData("00011101 10001110 01111001", "SBB", "AX,798E")]
        [InlineData("10000000 11011001 00001000", "SBB", "CL,08")]
        [InlineData("10000000 11011010 00001000", "SBB", "DL,08")]
        [InlineData("10000000 11011011 00001000", "SBB", "BL,08")]
        [InlineData("10000000 11011100 00001000", "SBB", "AH,08")]
        [InlineData("10000000 11011100 00001001", "SBB", "AH,09")]
        [InlineData("10000000 11011101 00001000", "SBB", "CH,08")]
        [InlineData("10000000 11011110 00001000", "SBB", "DH,08")]
        [InlineData("10000000 11011111 00001000", "SBB", "BH,08")]
        [InlineData("10000011 11011011 00001001", "SBB", "BX,+09")]
        [InlineData("00011000 10001101 00100100 11011001", "SBB", "Byte Ptr [DI-26DC],CL")]
        [InlineData("00011001 10000100 00001010 00100011", "SBB", "Word Ptr [SI+230A],AX")]
        [InlineData("00011001 10000110 00100110 10101001", "SBB", "Word Ptr [BP-56DA],AX")]
        [InlineData("00011010 10000100 10101000 11011111", "SBB", "AL,Byte Ptr [SI-2058]")]
        [InlineData("00011010 10001000 10000100 10011110", "SBB", "CL,Byte Ptr [BX+SI-617C]")]
        [InlineData("00011010 10001011 00010110 11001111", "SBB", "CL,Byte Ptr [BP+DI-30EA]")]
        [InlineData("00011010 10111111 00100110 00010110", "SBB", "BH,Byte Ptr [BX+1626]")]
        [InlineData("00011011 00100110 11010100 11000110", "SBB", "SP,Word Ptr [C6D4]")]
        [InlineData("00011011 10000000 10111100 11110010", "SBB", "AX,Word Ptr [BX+SI-0D44]")]
        [InlineData("00011011 10000110 00101011 11111001", "SBB", "AX,Word Ptr [BP-06D5]")]
        [InlineData("00011011 10011111 10011001 00101000", "SBB", "BX,Word Ptr [BX+2899]")]
        [InlineData("00011011 10100000 01110101 10110100", "SBB", "SP,Word Ptr [BX+SI-4B8B]")]
        [InlineData("10000000 01011101 00110001 00011011", "SBB", "Byte Ptr [DI+31],1B")]
        [InlineData("10000001 11011001 01101101 10101000", "SBB", "CX,A86D")]
        [InlineData("00111110 00011001 10100111 11011101 10101010", "SBB", "Word Ptr DS:[BX-5523],SP")]
        [InlineData("10000001 01011010 11000100 01100100 01111000", "SBB", "Word Ptr [BP+SI-3C],7864")]
        [InlineData("10000010 10011111 00011111 11110000 11101100", "SBB", "Byte Ptr [BX-0FE1],EC")]
        public void CheckSbb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Subtract
        /// </summary>
        [Theory]
        [InlineData("00101000 00000000", "SUB", "Byte Ptr [BX+SI],AL")]
        [InlineData("00101000 00000001", "SUB", "Byte Ptr [BX+DI],AL")]
        [InlineData("00101000 00001000", "SUB", "Byte Ptr [BX+SI],CL")]
        [InlineData("00101000 00100111", "SUB", "Byte Ptr [BX],AH")]
        [InlineData("00101000 00101010", "SUB", "Byte Ptr [BP+SI],CH")]
        [InlineData("00101000 11100100", "SUB", "AH,AH")]
        [InlineData("00101000 11101110", "SUB", "DH,CH")]
        [InlineData("00101001 00000000", "SUB", "Word Ptr [BX+SI],AX")]
        [InlineData("00101001 00000001", "SUB", "Word Ptr [BX+DI],AX")]
        [InlineData("00101001 00000100", "SUB", "Word Ptr [SI],AX")]
        [InlineData("00101001 11011011", "SUB", "BX,BX")]
        [InlineData("00101001 11110010", "SUB", "DX,SI")]
        [InlineData("00101010 00000000", "SUB", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00101010 00000001", "SUB", "AL,Byte Ptr [BX+DI]")]
        [InlineData("00101010 00100111", "SUB", "AH,Byte Ptr [BX]")]
        [InlineData("00101010 00110100", "SUB", "DH,Byte Ptr [SI]")]
        [InlineData("00101010 00111011", "SUB", "BH,Byte Ptr [BP+DI]")]
        [InlineData("00101011 00000000", "SUB", "AX,Word Ptr [BX+SI]")]
        [InlineData("00101011 00000001", "SUB", "AX,Word Ptr [BX+DI]")]
        [InlineData("00101011 00011101", "SUB", "BX,Word Ptr [DI]")]
        [InlineData("00101011 00110010", "SUB", "SI,Word Ptr [BP+SI]")]
        [InlineData("00101011 00110111", "SUB", "SI,Word Ptr [BX]")]
        [InlineData("00101011 11101111", "SUB", "BP,DI")]
        [InlineData("00101011 11111110", "SUB", "DI,SI")]
        [InlineData("00101100 00000000", "SUB", "AL,00")]
        [InlineData("00101100 00000001", "SUB", "AL,01")]
        [InlineData("00101100 00001000", "SUB", "AL,08")]
        [InlineData("00101100 01010101", "SUB", "AL,55")]
        [InlineData("00101100 01100010", "SUB", "AL,62")]
        [InlineData("00101100 10101110", "SUB", "AL,AE")]
        [InlineData("00101100 11010011", "SUB", "AL,D3")]
        [InlineData("00101100 11010111", "SUB", "AL,D7")]
        [InlineData("00101100 11101011", "SUB", "AL,EB")]
        [InlineData("00101100 11101110", "SUB", "AL,EE")]
        [InlineData("00101100 11110110", "SUB", "AL,F6")]
        [InlineData("00100110 00101000 00001100", "SUB", "Byte Ptr ES:[SI],CL")]
        [InlineData("00101000 01010001 10010110", "SUB", "Byte Ptr [BX+DI-6A],DL")]
        [InlineData("00101000 01011010 11011010", "SUB", "Byte Ptr [BP+SI-26],BL")]
        [InlineData("00101001 01100110 11101101", "SUB", "Word Ptr [BP-13],SP")]
        [InlineData("00101001 01101010 10010010", "SUB", "Word Ptr [BP+SI-6E],BP")]
        [InlineData("00101001 01110011 01011001", "SUB", "Word Ptr [BP+DI+59],SI")]
        [InlineData("00101010 01001010 01101000", "SUB", "CL,Byte Ptr [BP+SI+68]")]
        [InlineData("00101010 01011110 00101100", "SUB", "BL,Byte Ptr [BP+2C]")]
        [InlineData("00101010 01110101 10011100", "SUB", "DH,Byte Ptr [DI-64]")]
        [InlineData("00101011 01000011 10001101", "SUB", "AX,Word Ptr [BP+DI-73]")]
        [InlineData("00101011 01010010 00101000", "SUB", "DX,Word Ptr [BP+SI+28]")]
        [InlineData("00101011 01011000 00100101", "SUB", "BX,Word Ptr [BX+SI+25]")]
        [InlineData("00101101 00000000 10001011", "SUB", "AX,8B00")]
        [InlineData("00101101 00000001 11111100", "SUB", "AX,FC01")]
        [InlineData("00101101 01000100 11110001", "SUB", "AX,F144")]
        [InlineData("00101101 01010100 01000000", "SUB", "AX,4054")]
        [InlineData("00101101 01100110 00110101", "SUB", "AX,3566")]
        [InlineData("00101101 10111101 10010011", "SUB", "AX,93BD")]
        [InlineData("00101101 10111110 01111010", "SUB", "AX,7ABE")]
        [InlineData("00101101 11000001 00001011", "SUB", "AX,0BC1")]
        [InlineData("00101101 11000010 01101011", "SUB", "AX,6BC2")]
        [InlineData("00101101 11000101 00010000", "SUB", "AX,10C5")]
        [InlineData("10000000 00101000 01011100", "SUB", "Byte Ptr [BX+SI],5C")]
        [InlineData("10000000 11101001 00001000", "SUB", "CL,08")]
        [InlineData("10000000 11101010 00001000", "SUB", "DL,08")]
        [InlineData("10000000 11101011 00001000", "SUB", "BL,08")]
        [InlineData("10000000 11101011 11110010", "SUB", "BL,F2")]
        [InlineData("10000000 11101100 00001000", "SUB", "AH,08")]
        [InlineData("10000000 11101100 00001001", "SUB", "AH,09")]
        [InlineData("10000000 11101101 00001000", "SUB", "CH,08")]
        [InlineData("10000000 11101110 00001000", "SUB", "DH,08")]
        [InlineData("10000000 11101111 00001000", "SUB", "BH,08")]
        [InlineData("10000011 00101000 00000000", "SUB", "Word Ptr [BX+SI],+00")]
        [InlineData("10000011 11101010 11011001", "SUB", "DX,-27")]
        [InlineData("10000011 11101011 00001001", "SUB", "BX,+09")]
        [InlineData("10000011 11101111 10001100", "SUB", "DI,-74")]
        [InlineData("00100110 00101011 01001010 01010100", "SUB", "CX,Word Ptr ES:[BP+SI+54]")]
        [InlineData("00101000 10001000 01100010 00110001", "SUB", "Byte Ptr [BX+SI+3162],CL")]
        [InlineData("00101000 10110110 10010000 01110001", "SUB", "Byte Ptr [BP+7190],DH")]
        [InlineData("00101001 00000110 11110110 00010100", "SUB", "Word Ptr [14F6],AX")]
        [InlineData("00101001 00011110 01110110 01111101", "SUB", "Word Ptr [7D76],BX")]
        [InlineData("00101001 00100110 10011011 01111111", "SUB", "Word Ptr [7F9B],SP")]
        [InlineData("00101001 10011110 01000111 10100111", "SUB", "Word Ptr [BP-58B9],BX")]
        [InlineData("00101001 10110011 01100010 11101001", "SUB", "Word Ptr [BP+DI-169E],SI")]
        [InlineData("00101010 10000011 00001001 01111000", "SUB", "AL,Byte Ptr [BP+DI+7809]")]
        [InlineData("00101010 10010110 00010000 10100001", "SUB", "DL,Byte Ptr [BP-5EF0]")]
        [InlineData("00101010 10011010 01010010 01101000", "SUB", "BL,Byte Ptr [BP+SI+6852]")]
        [InlineData("00101010 10100100 11010011 01011001", "SUB", "AH,Byte Ptr [SI+59D3]")]
        [InlineData("00101010 10101110 10100101 11111101", "SUB", "CH,Byte Ptr [BP-025B]")]
        [InlineData("00101011 00001110 01111110 00000011", "SUB", "CX,Word Ptr [037E]")]
        [InlineData("00101011 10001000 11100001 01000110", "SUB", "CX,Word Ptr [BX+SI+46E1]")]
        [InlineData("00101011 10001011 11010110 01101101", "SUB", "CX,Word Ptr [BP+DI+6DD6]")]
        [InlineData("00101011 10100100 10111111 11110111", "SUB", "SP,Word Ptr [SI-0841]")]
        [InlineData("00101011 10110111 10100011 00110001", "SUB", "SI,Word Ptr [BX+31A3]")]
        [InlineData("10000000 01101001 00100000 11111101", "SUB", "Byte Ptr [BX+DI+20],FD")]
        [InlineData("00110110 00101010 10101010 00011001 10110001", "SUB", "CH,Byte Ptr SS:[BP+SI-4EE7]")]
        [InlineData("00111110 10000000 00101110 10011010 10101000 11111001", "SUB", "Byte Ptr DS:[A89A],F9")]
        [InlineData("10000001 10101110 10111111 11100000 01101010 01001011", "SUB", "Word Ptr [BP-1F41],4B6A")]
        public void CheckSub(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class BitwiseTest : AbstractDecodeTest
    {
        /// <summary>
        /// Logical AND
        /// </summary>
        [Theory]
        [InlineData("00100000 00000001", "AND", "Byte Ptr [BX+DI],AL")]
        [InlineData("00100000 00011010", "AND", "Byte Ptr [BP+SI],BL")]
        [InlineData("00100000 00111111", "AND", "Byte Ptr [BX],BH")]
        [InlineData("00100000 11010001", "AND", "CL,DL")]
        [InlineData("00100000 11100100", "AND", "AH,AH")]
        [InlineData("00100000 11101000", "AND", "AL,CH")]
        [InlineData("00100000 11111100", "AND", "AH,BH")]
        [InlineData("00100001 00000000", "AND", "Word Ptr [BX+SI],AX")]
        [InlineData("00100001 00000001", "AND", "Word Ptr [BX+DI],AX")]
        [InlineData("00100001 00001001", "AND", "Word Ptr [BX+DI],CX")]
        [InlineData("00100001 00010100", "AND", "Word Ptr [SI],DX")]
        [InlineData("00100001 11011000", "AND", "AX,BX")]
        [InlineData("00100001 11011011", "AND", "BX,BX")]
        [InlineData("00100001 11100111", "AND", "DI,SP")]
        [InlineData("00100001 11111010", "AND", "DX,DI")]
        [InlineData("00100010 00000000", "AND", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00100010 00000001", "AND", "AL,Byte Ptr [BX+DI]")]
        [InlineData("00100010 00010101", "AND", "DL,Byte Ptr [DI]")]
        [InlineData("00100010 00011011", "AND", "BL,Byte Ptr [BP+DI]")]
        [InlineData("00100010 00100010", "AND", "AH,Byte Ptr [BP+SI]")]
        [InlineData("00100010 00101000", "AND", "CH,Byte Ptr [BX+SI]")]
        [InlineData("00100010 00101111", "AND", "CH,Byte Ptr [BX]")]
        [InlineData("00100010 00110001", "AND", "DH,Byte Ptr [BX+DI]")]
        [InlineData("00100010 11000100", "AND", "AL,AH")]
        [InlineData("00100010 11000110", "AND", "AL,DH")]
        [InlineData("00100010 11001000", "AND", "CL,AL")]
        [InlineData("00100010 11111010", "AND", "BH,DL")]
        [InlineData("00100011 00000000", "AND", "AX,Word Ptr [BX+SI]")]
        [InlineData("00100011 00000001", "AND", "AX,Word Ptr [BX+DI]")]
        [InlineData("00100011 00001001", "AND", "CX,Word Ptr [BX+DI]")]
        [InlineData("00100011 00101000", "AND", "BP,Word Ptr [BX+SI]")]
        [InlineData("00100011 00111001", "AND", "DI,Word Ptr [BX+DI]")]
        [InlineData("00100100 00000000", "AND", "AL,00")]
        [InlineData("00100100 00000001", "AND", "AL,01")]
        [InlineData("00100100 00001110", "AND", "AL,0E")]
        [InlineData("00100100 00101000", "AND", "AL,28")]
        [InlineData("00100100 00101101", "AND", "AL,2D")]
        [InlineData("00100100 00110111", "AND", "AL,37")]
        [InlineData("00100100 00111011", "AND", "AL,3B")]
        [InlineData("00100100 01010011", "AND", "AL,53")]
        [InlineData("00100100 10011010", "AND", "AL,9A")]
        [InlineData("00100100 10011110", "AND", "AL,9E")]
        [InlineData("00100100 10101100", "AND", "AL,AC")]
        [InlineData("00100100 10111101", "AND", "AL,BD")]
        [InlineData("00100100 10111110", "AND", "AL,BE")]
        [InlineData("00100100 11001101", "AND", "AL,CD")]
        [InlineData("00100100 11010111", "AND", "AL,D7")]
        [InlineData("00100100 11110010", "AND", "AL,F2")]
        [InlineData("00100000 01001010 01111110", "AND", "Byte Ptr [BP+SI+7E],CL")]
        [InlineData("00100000 01001111 11011111", "AND", "Byte Ptr [BX-21],CL")]
        [InlineData("00100000 01010000 00010100", "AND", "Byte Ptr [BX+SI+14],DL")]
        [InlineData("00100001 01100010 10101000", "AND", "Word Ptr [BP+SI-58],SP")]
        [InlineData("00100010 01100010 10001011", "AND", "AH,Byte Ptr [BP+SI-75]")]
        [InlineData("00100011 01000010 01010010", "AND", "AX,Word Ptr [BP+SI+52]")]
        [InlineData("00100011 01110011 00001011", "AND", "SI,Word Ptr [BP+DI+0B]")]
        [InlineData("00100101 00000000 11100011", "AND", "AX,E300")]
        [InlineData("00100101 00000001 10000010", "AND", "AX,8201")]
        [InlineData("00100101 00001100 00011010", "AND", "AX,1A0C")]
        [InlineData("00100101 00110010 00100100", "AND", "AX,2432")]
        [InlineData("00100101 01010011 00101000", "AND", "AX,2853")]
        [InlineData("00100101 10010000 11101001", "AND", "AX,E990")]
        [InlineData("00100101 10011111 00101001", "AND", "AX,299F")]
        [InlineData("00100101 10100110 00111011", "AND", "AX,3BA6")]
        [InlineData("00100101 10101110 10011111", "AND", "AX,9FAE")]
        [InlineData("00100101 10111001 00000110", "AND", "AX,06B9")]
        [InlineData("00100101 11010111 10001100", "AND", "AX,8CD7")]
        [InlineData("00100101 11101010 00110010", "AND", "AX,32EA")]
        [InlineData("00100101 11111100 10100001", "AND", "AX,A1FC")]
        [InlineData("10000000 11100100 00001001", "AND", "AH,09")]
        [InlineData("10000010 00100011 10100010", "AND", "Byte Ptr [BP+DI],A2")]
        [InlineData("10000010 00100100 10011000", "AND", "Byte Ptr [SI],98")]
        [InlineData("10000011 11100011 00001001", "AND", "BX,+09")]
        [InlineData("00100000 00000110 10011111 10100001", "AND", "Byte Ptr [A19F],AL")]
        [InlineData("00100000 10001110 10110001 11100110", "AND", "Byte Ptr [BP-194F],CL")]
        [InlineData("00100001 10011100 11010110 11010000", "AND", "Word Ptr [SI-2F2A],BX")]
        [InlineData("00100001 10100000 00100111 01100010", "AND", "Word Ptr [BX+SI+6227],SP")]
        [InlineData("00100001 10100000 01010011 01000111", "AND", "Word Ptr [BX+SI+4753],SP")]
        [InlineData("00100001 10111001 10100000 11100111", "AND", "Word Ptr [BX+DI-1860],DI")]
        [InlineData("00100010 10001001 01100010 10010001", "AND", "CL,Byte Ptr [BX+DI-6E9E]")]
        [InlineData("00100011 10011001 01111101 10001100", "AND", "BX,Word Ptr [BX+DI-7383]")]
        [InlineData("00100011 10100011 01000100 01101101", "AND", "SP,Word Ptr [BP+DI+6D44]")]
        [InlineData("00101110 00100011 01000111 11001001", "AND", "AX,Word Ptr CS:[BX-37]")]
        [InlineData("00110110 00100000 01010010 00110001", "AND", "Byte Ptr SS:[BP+SI+31],DL")]
        [InlineData("10000000 10100010 11011100 00011011 00001111", "AND", "Byte Ptr [BP+SI+1BDC],0F")]
        public void CheckAnd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// One's Complement Negation
        /// </summary>
        [Theory]
        [InlineData("11110110 11010100", "NOT", "AH")]
        [InlineData("11110111 11010000", "NOT", "AX")]
        [InlineData("11110111 11010001", "NOT", "CX")]
        [InlineData("11110111 11010010", "NOT", "DX")]
        [InlineData("11110111 11010011", "NOT", "BX")]
        [InlineData("11110111 11010100", "NOT", "SP")]
        [InlineData("11110111 11010101", "NOT", "BP")]
        [InlineData("11110111 11010110", "NOT", "SI")]
        [InlineData("11110111 11010111", "NOT", "DI")]
        public void CheckNot(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [Theory]
        [InlineData("00001000 00000000", "OR", "Byte Ptr [BX+SI],AL")]
        [InlineData("00001000 00000001", "OR", "Byte Ptr [BX+DI],AL")]
        [InlineData("00001000 00000010", "OR", "Byte Ptr [BP+SI],AL")]
        [InlineData("00001000 00001100", "OR", "Byte Ptr [SI],CL")]
        [InlineData("00001000 00011010", "OR", "Byte Ptr [BP+SI],BL")]
        [InlineData("00001000 00101011", "OR", "Byte Ptr [BP+DI],CH")]
        [InlineData("00001000 11010101", "OR", "CH,DL")]
        [InlineData("00001000 11100100", "OR", "AH,AH")]
        [InlineData("00001001 00000000", "OR", "Word Ptr [BX+SI],AX")]
        [InlineData("00001001 00000001", "OR", "Word Ptr [BX+DI],AX")]
        [InlineData("00001001 00000010", "OR", "Word Ptr [BP+SI],AX")]
        [InlineData("00001001 11011000", "OR", "AX,BX")]
        [InlineData("00001001 11011011", "OR", "BX,BX")]
        [InlineData("00001001 11100100", "OR", "SP,SP")]
        [InlineData("00001001 11100101", "OR", "BP,SP")]
        [InlineData("00001001 11111011", "OR", "BX,DI")]
        [InlineData("00001010 00000000", "OR", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00001010 00000001", "OR", "AL,Byte Ptr [BX+DI]")]
        [InlineData("00001010 00000010", "OR", "AL,Byte Ptr [BP+SI]")]
        [InlineData("00001010 00010111", "OR", "DL,Byte Ptr [BX]")]
        [InlineData("00001010 00111001", "OR", "BH,Byte Ptr [BX+DI]")]
        [InlineData("00001010 11011101", "OR", "BL,CH")]
        [InlineData("00001010 11101000", "OR", "CH,AL")]
        [InlineData("00001010 11101110", "OR", "CH,DH")]
        [InlineData("00001010 11110000", "OR", "DH,AL")]
        [InlineData("00001010 11111101", "OR", "BH,CH")]
        [InlineData("00001011 00000000", "OR", "AX,Word Ptr [BX+SI]")]
        [InlineData("00001011 00000001", "OR", "AX,Word Ptr [BX+DI]")]
        [InlineData("00001011 00000010", "OR", "AX,Word Ptr [BP+SI]")]
        [InlineData("00001011 00100001", "OR", "SP,Word Ptr [BX+DI]")]
        [InlineData("00001011 00100111", "OR", "SP,Word Ptr [BX]")]
        [InlineData("00001011 00101001", "OR", "BP,Word Ptr [BX+DI]")]
        [InlineData("00001011 11001001", "OR", "CX,CX")]
        [InlineData("00001011 11101001", "OR", "BP,CX")]
        [InlineData("00001011 11110101", "OR", "SI,BP")]
        [InlineData("00001100 00000000", "OR", "AL,00")]
        [InlineData("00001100 00000001", "OR", "AL,01")]
        [InlineData("00001100 00000010", "OR", "AL,02")]
        [InlineData("00001100 00011011", "OR", "AL,1B")]
        [InlineData("00001100 00101000", "OR", "AL,28")]
        [InlineData("00001100 01001001", "OR", "AL,49")]
        [InlineData("00001100 01001110", "OR", "AL,4E")]
        [InlineData("00001100 01010100", "OR", "AL,54")]
        [InlineData("00001100 10001000", "OR", "AL,88")]
        [InlineData("00001100 10001010", "OR", "AL,8A")]
        [InlineData("00001100 10101000", "OR", "AL,A8")]
        [InlineData("00001100 11000101", "OR", "AL,C5")]
        [InlineData("00001100 11001110", "OR", "AL,CE")]
        [InlineData("00001100 11111010", "OR", "AL,FA")]
        [InlineData("00001000 01001101 10101001", "OR", "Byte Ptr [DI-57],CL")]
        [InlineData("00001000 01010100 01111001", "OR", "Byte Ptr [SI+79],DL")]
        [InlineData("00001000 01100100 10000110", "OR", "Byte Ptr [SI-7A],AH")]
        [InlineData("00001001 01011010 01111000", "OR", "Word Ptr [BP+SI+78],BX")]
        [InlineData("00001001 01100000 01111011", "OR", "Word Ptr [BX+SI+7B],SP")]
        [InlineData("00001010 01010000 11101000", "OR", "DL,Byte Ptr [BX+SI-18]")]
        [InlineData("00001010 01111100 11000100", "OR", "BH,Byte Ptr [SI-3C]")]
        [InlineData("00001011 01000011 00011001", "OR", "AX,Word Ptr [BP+DI+19]")]
        [InlineData("00001101 00000001 10110010", "OR", "AX,B201")]
        [InlineData("00001101 00011111 01010011", "OR", "AX,531F")]
        [InlineData("00001101 00110011 00101101", "OR", "AX,2D33")]
        [InlineData("00001101 00111000 10100100", "OR", "AX,A438")]
        [InlineData("00001101 00111001 01110110", "OR", "AX,7639")]
        [InlineData("00001101 01101111 00011100", "OR", "AX,1C6F")]
        [InlineData("00001101 01111011 10110101", "OR", "AX,B57B")]
        [InlineData("00001101 10010111 00000010", "OR", "AX,0297")]
        [InlineData("00001101 10100001 11011001", "OR", "AX,D9A1")]
        [InlineData("00001101 10100001 11100100", "OR", "AX,E4A1")]
        [InlineData("00001101 10100010 00000001", "OR", "AX,01A2")]
        [InlineData("00001101 11001100 01111011", "OR", "AX,7BCC")]
        [InlineData("00001101 11101110 00101111", "OR", "AX,2FEE")]
        [InlineData("10000000 11001010 10110100", "OR", "DL,B4")]
        [InlineData("10000000 11001100 00001001", "OR", "AH,09")]
        [InlineData("10000011 11001011 00001001", "OR", "BX,+09")]
        [InlineData("00001000 00110110 00001010 00000001", "OR", "Byte Ptr [010A],DH")]
        [InlineData("00001000 10000010 00110010 11110101", "OR", "Byte Ptr [BP+SI-0ACE],AL")]
        [InlineData("00001000 10011100 11101010 11001100", "OR", "Byte Ptr [SI-3316],BL")]
        [InlineData("00001000 10100011 10011110 00111111", "OR", "Byte Ptr [BP+DI+3F9E],AH")]
        [InlineData("00001001 10101110 00110001 00101000", "OR", "Word Ptr [BP+2831],BP")]
        [InlineData("00001010 10100001 01011000 11001101", "OR", "AH,Byte Ptr [BX+DI-32A8]")]
        [InlineData("00001010 10110100 01011011 00011110", "OR", "DH,Byte Ptr [SI+1E5B]")]
        [InlineData("00001010 10110111 01010110 11110111", "OR", "DH,Byte Ptr [BX-08AA]")]
        [InlineData("00001010 10111010 00010011 11010000", "OR", "BH,Byte Ptr [BP+SI-2FED]")]
        [InlineData("00001011 00101110 10001110 00111101", "OR", "BP,Word Ptr [3D8E]")]
        [InlineData("00001011 10000100 10001110 10100111", "OR", "AX,Word Ptr [SI-5872]")]
        [InlineData("00001011 10111101 10111001 11101010", "OR", "DI,Word Ptr [DI-1547]")]
        [InlineData("00100110 00001010 01111101 00011000", "OR", "BH,Byte Ptr ES:[DI+18]")]
        [InlineData("00100110 00001001 10010000 11100001 11100111", "OR", "Word Ptr ES:[BX+SI-181F],DX")]
        [InlineData("00110110 00001011 10011011 01000000 00011110", "OR", "BX,Word Ptr SS:[BP+DI+1E40]")]
        [InlineData("10000011 10001001 10111010 01101111 01111001", "OR", "Word Ptr [BX+DI+6FBA],+79")]
        [InlineData("10000001 10001101 10100010 01011010 00110100 10101001", "OR", "Word Ptr [DI+5AA2],A934")]
        public void CheckOr(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Logical Compare
        /// </summary>
        [Theory]
        [InlineData("10000100 00000000", "TEST", "Byte Ptr [BX+SI],AL")]
        [InlineData("10000100 00000001", "TEST", "Byte Ptr [BX+DI],AL")]
        [InlineData("10000100 00001000", "TEST", "Byte Ptr [BX+SI],CL")]
        [InlineData("10000100 11001000", "TEST", "AL,CL")]
        [InlineData("10000100 11011111", "TEST", "BH,BL")]
        [InlineData("10000100 11100100", "TEST", "AH,AH")]
        [InlineData("10000100 11100111", "TEST", "BH,AH")]
        [InlineData("10000100 11101111", "TEST", "BH,CH")]
        [InlineData("10000101 00000000", "TEST", "Word Ptr [BX+SI],AX")]
        [InlineData("10000101 00000001", "TEST", "Word Ptr [BX+DI],AX")]
        [InlineData("10000101 00001101", "TEST", "Word Ptr [DI],CX")]
        [InlineData("10000101 00101010", "TEST", "Word Ptr [BP+SI],BP")]
        [InlineData("10000101 11011010", "TEST", "DX,BX")]
        [InlineData("10000101 11011011", "TEST", "BX,BX")]
        [InlineData("10000101 11100101", "TEST", "BP,SP")]
        [InlineData("10101000 00000000", "TEST", "AL,00")]
        [InlineData("10101000 00000001", "TEST", "AL,01")]
        [InlineData("10101000 00001000", "TEST", "AL,08")]
        [InlineData("10101000 00001011", "TEST", "AL,0B")]
        [InlineData("10101000 00001111", "TEST", "AL,0F")]
        [InlineData("10101000 00011100", "TEST", "AL,1C")]
        [InlineData("10101000 00011110", "TEST", "AL,1E")]
        [InlineData("10101000 01000011", "TEST", "AL,43")]
        [InlineData("10101000 01110111", "TEST", "AL,77")]
        [InlineData("10101000 01111010", "TEST", "AL,7A")]
        [InlineData("10101000 11001100", "TEST", "AL,CC")]
        [InlineData("10101000 11010110", "TEST", "AL,D6")]
        [InlineData("10101000 11011000", "TEST", "AL,D8")]
        [InlineData("10000100 01000011 01101101", "TEST", "Byte Ptr [BP+DI+6D],AL")]
        [InlineData("10000100 01001001 01011101", "TEST", "Byte Ptr [BX+DI+5D],CL")]
        [InlineData("10000100 01011001 01010010", "TEST", "Byte Ptr [BX+DI+52],BL")]
        [InlineData("10000100 01011110 11001011", "TEST", "Byte Ptr [BP-35],BL")]
        [InlineData("10000100 01101100 10101001", "TEST", "Byte Ptr [SI-57],CH")]
        [InlineData("10000101 01010110 10110110", "TEST", "Word Ptr [BP-4A],DX")]
        [InlineData("10000101 01100110 10110111", "TEST", "Word Ptr [BP-49],SP")]
        [InlineData("10101001 00000000 10110100", "TEST", "AX,B400")]
        [InlineData("10101001 00000001 10011111", "TEST", "AX,9F01")]
        [InlineData("10101001 00000111 00111000", "TEST", "AX,3807")]
        [InlineData("10101001 00010000 00001110", "TEST", "AX,0E10")]
        [InlineData("10101001 00010010 00101010", "TEST", "AX,2A12")]
        [InlineData("10101001 10101011 11001000", "TEST", "AX,C8AB")]
        [InlineData("10101001 11011100 10010101", "TEST", "AX,95DC")]
        [InlineData("10101001 11101010 10101001", "TEST", "AX,A9EA")]
        [InlineData("11110110 00000000 00111110", "TEST", "Byte Ptr [BX+SI],3E")]
        [InlineData("11110110 00000001 10100000", "TEST", "Byte Ptr [BX+DI],A0")]
        [InlineData("11110110 11000001 00001000", "TEST", "CL,08")]
        [InlineData("11110110 11000010 00001000", "TEST", "DL,08")]
        [InlineData("11110110 11000011 00001000", "TEST", "BL,08")]
        [InlineData("11110110 11000100 00001000", "TEST", "AH,08")]
        [InlineData("11110110 11000100 00001001", "TEST", "AH,09")]
        [InlineData("11110110 11000101 00001000", "TEST", "CH,08")]
        [InlineData("11110110 11000110 00001000", "TEST", "DH,08")]
        [InlineData("11110110 11000111 00001000", "TEST", "BH,08")]
        [InlineData("10000100 00010110 01010100 01100111", "TEST", "Byte Ptr [6754],DL")]
        [InlineData("10000100 00101110 00011001 01000111", "TEST", "Byte Ptr [4719],CH")]
        [InlineData("10000100 10101110 11001111 11100111", "TEST", "Byte Ptr [BP-1831],CH")]
        [InlineData("10000101 10110110 01010101 11011111", "TEST", "Word Ptr [BP-20AB],SI")]
        [InlineData("11110111 00000000 11100111 10011111", "TEST", "Word Ptr [BX+SI],9FE7")]
        [InlineData("11110111 00000001 01001111 01110110", "TEST", "Word Ptr [BX+DI],764F")]
        [InlineData("11110111 11000011 00001001 00000000", "TEST", "BX,0009")]
        [InlineData("11110111 01000001 01010100 00011110 10111001", "TEST", "Word Ptr [BX+DI+54],B91E")]
        public void CheckTest(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Logical Exclusive OR
        /// </summary>
        [Theory]
        [InlineData("00110000 00000000", "XOR", "Byte Ptr [BX+SI],AL")]
        [InlineData("00110000 00000001", "XOR", "Byte Ptr [BX+DI],AL")]
        [InlineData("00110000 00010101", "XOR", "Byte Ptr [DI],DL")]
        [InlineData("00110000 11000000", "XOR", "AL,AL")]
        [InlineData("00110000 11001001", "XOR", "CL,CL")]
        [InlineData("00110000 11010010", "XOR", "DL,DL")]
        [InlineData("00110000 11011011", "XOR", "BL,BL")]
        [InlineData("00110000 11100100", "XOR", "AH,AH")]
        [InlineData("00110000 11101101", "XOR", "CH,CH")]
        [InlineData("00110000 11110101", "XOR", "CH,DH")]
        [InlineData("00110000 11110110", "XOR", "DH,DH")]
        [InlineData("00110000 11111111", "XOR", "BH,BH")]
        [InlineData("00110001 00000000", "XOR", "Word Ptr [BX+SI],AX")]
        [InlineData("00110001 00000001", "XOR", "Word Ptr [BX+DI],AX")]
        [InlineData("00110001 00100011", "XOR", "Word Ptr [BP+DI],SP")]
        [InlineData("00110001 00101011", "XOR", "Word Ptr [BP+DI],BP")]
        [InlineData("00110001 00111111", "XOR", "Word Ptr [BX],DI")]
        [InlineData("00110001 11011010", "XOR", "DX,BX")]
        [InlineData("00110001 11011011", "XOR", "BX,BX")]
        [InlineData("00110001 11101111", "XOR", "DI,BP")]
        [InlineData("00110010 00000000", "XOR", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00110010 00000001", "XOR", "AL,Byte Ptr [BX+DI]")]
        [InlineData("00110010 00010101", "XOR", "DL,Byte Ptr [DI]")]
        [InlineData("00110010 00100000", "XOR", "AH,Byte Ptr [BX+SI]")]
        [InlineData("00110010 00111000", "XOR", "BH,Byte Ptr [BX+SI]")]
        [InlineData("00110011 00000000", "XOR", "AX,Word Ptr [BX+SI]")]
        [InlineData("00110011 00000001", "XOR", "AX,Word Ptr [BX+DI]")]
        [InlineData("00110011 00001100", "XOR", "CX,Word Ptr [SI]")]
        [InlineData("00110011 00100010", "XOR", "SP,Word Ptr [BP+SI]")]
        [InlineData("00110011 00111001", "XOR", "DI,Word Ptr [BX+DI]")]
        [InlineData("00110011 11000111", "XOR", "AX,DI")]
        [InlineData("00110011 11010100", "XOR", "DX,SP")]
        [InlineData("00110011 11100111", "XOR", "SP,DI")]
        [InlineData("00110011 11101000", "XOR", "BP,AX")]
        [InlineData("00110100 00000000", "XOR", "AL,00")]
        [InlineData("00110100 00000001", "XOR", "AL,01")]
        [InlineData("00110100 00101100", "XOR", "AL,2C")]
        [InlineData("00110100 01100100", "XOR", "AL,64")]
        [InlineData("00110100 01100110", "XOR", "AL,66")]
        [InlineData("00110100 10000000", "XOR", "AL,80")]
        [InlineData("00110100 10001011", "XOR", "AL,8B")]
        [InlineData("00110100 11011000", "XOR", "AL,D8")]
        [InlineData("00110100 11100011", "XOR", "AL,E3")]
        [InlineData("00110100 11110011", "XOR", "AL,F3")]
        [InlineData("00110100 11111000", "XOR", "AL,F8")]
        [InlineData("00110000 01011010 00111100", "XOR", "Byte Ptr [BP+SI+3C],BL")]
        [InlineData("00110000 01100000 01010110", "XOR", "Byte Ptr [BX+SI+56],AH")]
        [InlineData("00110001 01010100 11000110", "XOR", "Word Ptr [SI-3A],DX")]
        [InlineData("00110001 01111011 00101100", "XOR", "Word Ptr [BP+DI+2C],DI")]
        [InlineData("00110010 01001010 01101101", "XOR", "CL,Byte Ptr [BP+SI+6D]")]
        [InlineData("00110011 01010000 10110110", "XOR", "DX,Word Ptr [BX+SI-4A]")]
        [InlineData("00110011 01110011 00010001", "XOR", "SI,Word Ptr [BP+DI+11]")]
        [InlineData("00110011 01110011 11000000", "XOR", "SI,Word Ptr [BP+DI-40]")]
        [InlineData("00110101 00000000 11110010", "XOR", "AX,F200")]
        [InlineData("00110101 00000001 10010101", "XOR", "AX,9501")]
        [InlineData("00110101 00011001 10010111", "XOR", "AX,9719")]
        [InlineData("00110101 00110101 10110001", "XOR", "AX,B135")]
        [InlineData("00110101 01000110 01000111", "XOR", "AX,4746")]
        [InlineData("00110101 01001101 10001000", "XOR", "AX,884D")]
        [InlineData("00110101 01110011 10011101", "XOR", "AX,9D73")]
        [InlineData("00110101 10101000 01111001", "XOR", "AX,79A8")]
        [InlineData("00110101 11000011 11011011", "XOR", "AX,DBC3")]
        [InlineData("00110101 11110100 10111100", "XOR", "AX,BCF4")]
        [InlineData("10000000 00110000 11111011", "XOR", "Byte Ptr [BX+SI],FB")]
        [InlineData("10000000 11110100 00001001", "XOR", "AH,09")]
        [InlineData("10000010 00110001 00111010", "XOR", "Byte Ptr [BX+DI],3A")]
        [InlineData("10000010 00110101 11000001", "XOR", "Byte Ptr [DI],C1")]
        [InlineData("10000011 11110011 00001001", "XOR", "BX,+09")]
        [InlineData("00110000 00010110 00111010 10000001", "XOR", "Byte Ptr [813A],DL")]
        [InlineData("00110000 10101111 00000111 10111011", "XOR", "Byte Ptr [BX-44F9],CH")]
        [InlineData("00110001 10000101 10111011 11000001", "XOR", "Word Ptr [DI-3E45],AX")]
        [InlineData("00110001 10010000 10110101 10000000", "XOR", "Word Ptr [BX+SI-7F4B],DX")]
        [InlineData("00110001 10111111 10110011 01101001", "XOR", "Word Ptr [BX+69B3],DI")]
        [InlineData("00110010 10000010 00111110 00000110", "XOR", "AL,Byte Ptr [BP+SI+063E]")]
        [InlineData("00110010 10001001 10001010 00011100", "XOR", "CL,Byte Ptr [BX+DI+1C8A]")]
        [InlineData("00110010 10100001 00110000 10011111", "XOR", "AH,Byte Ptr [BX+DI-60D0]")]
        [InlineData("00110010 10111110 10010100 01101100", "XOR", "BH,Byte Ptr [BP+6C94]")]
        [InlineData("00110011 00110110 01010001 11100001", "XOR", "SI,Word Ptr [E151]")]
        [InlineData("00110011 10011010 11001111 11111000", "XOR", "BX,Word Ptr [BP+SI-0731]")]
        [InlineData("00110011 10111111 01000110 10100111", "XOR", "DI,Word Ptr [BX-58BA]")]
        [InlineData("10000011 01110110 01101100 10101010", "XOR", "Word Ptr [BP+6C],-56")]
        [InlineData("00101110 00110011 10001000 00101000 00000000", "XOR", "CX,Word Ptr CS:[BX+SI+0028]")]
        [InlineData("10000010 10110001 00011101 10111000 00111011", "XOR", "Byte Ptr [BX+DI-47E3],3B")]
        [InlineData("10000011 10110101 00001011 11011101 00111110", "XOR", "Word Ptr [DI-22F5],+3E")]
        [InlineData("10000011 10110101 01100101 11100010 11100000", "XOR", "Word Ptr [DI-1D9B],-20")]
        [InlineData("10000001 00110110 01011110 01000011 10110001 01111110", "XOR", "Word Ptr [435E],7EB1")]
        public void CheckXor(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class BranchTest : AbstractDecodeTest
    {
        /// <summary>
        /// Jump If Above
        /// </summary>
        [Theory]
        [InlineData("01110111 00000000", "JA", "0002")]
        [InlineData("01110111 00000001", "JA", "0003")]
        [InlineData("01110111 00000010", "JA", "0004")]
        [InlineData("01110111 00000101", "JA", "0007")]
        [InlineData("01110111 00000111", "JA", "0009")]
        [InlineData("01110111 00001011", "JA", "000D")]
        [InlineData("01110111 00011111", "JA", "0021")]
        [InlineData("01110111 00101011", "JA", "002D")]
        [InlineData("01110111 01011100", "JA", "005E")]
        [InlineData("01110111 01101000", "JA", "006A")]
        [InlineData("01110111 10001011", "JA", "FF8D")]
        [InlineData("01110111 10001110", "JA", "FF90")]
        [InlineData("01110111 10011101", "JA", "FF9F")]
        [InlineData("01110111 10100011", "JA", "FFA5")]
        [InlineData("01110111 10101110", "JA", "FFB0")]
        [InlineData("01110111 11001001", "JA", "FFCB")]
        [InlineData("01110111 11111110", "JA", "0000")]
        [InlineData("01110111 11111111", "JA", "0001")]
        public void CheckJa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Below or Equal
        /// </summary>
        [Theory]
        [InlineData("01110110 00000000", "JBE", "0002")]
        [InlineData("01110110 00000001", "JBE", "0003")]
        [InlineData("01110110 00000101", "JBE", "0007")]
        [InlineData("01110110 00000111", "JBE", "0009")]
        [InlineData("01110110 00001011", "JBE", "000D")]
        [InlineData("01110110 00101000", "JBE", "002A")]
        [InlineData("01110110 01010110", "JBE", "0058")]
        [InlineData("01110110 01011101", "JBE", "005F")]
        [InlineData("01110110 01011111", "JBE", "0061")]
        [InlineData("01110110 10010101", "JBE", "FF97")]
        [InlineData("01110110 10010111", "JBE", "FF99")]
        [InlineData("01110110 10100001", "JBE", "FFA3")]
        [InlineData("01110110 10110001", "JBE", "FFB3")]
        [InlineData("01110110 10110100", "JBE", "FFB6")]
        [InlineData("01110110 11011110", "JBE", "FFE0")]
        [InlineData("01110110 11101101", "JBE", "FFEF")]
        [InlineData("01110110 11110110", "JBE", "FFF8")]
        [InlineData("01110110 11111110", "JBE", "0000")]
        [InlineData("01110110 11111111", "JBE", "0001")]
        public void CheckJbe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Carry
        /// </summary>
        [Theory]
        public void CheckJc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// </summary>
        [Theory]
        [InlineData("11100011 00000000", "JCXZ", "0002")]
        [InlineData("11100011 00000001", "JCXZ", "0003")]
        [InlineData("11100011 00000101", "JCXZ", "0007")]
        [InlineData("11100011 00000111", "JCXZ", "0009")]
        [InlineData("11100011 00001011", "JCXZ", "000D")]
        [InlineData("11100011 00111100", "JCXZ", "003E")]
        [InlineData("11100011 01011100", "JCXZ", "005E")]
        [InlineData("11100011 01011110", "JCXZ", "0060")]
        [InlineData("11100011 01100110", "JCXZ", "0068")]
        [InlineData("11100011 01101011", "JCXZ", "006D")]
        [InlineData("11100011 01101100", "JCXZ", "006E")]
        [InlineData("11100011 01110100", "JCXZ", "0076")]
        [InlineData("11100011 10001011", "JCXZ", "FF8D")]
        [InlineData("11100011 11010000", "JCXZ", "FFD2")]
        [InlineData("11100011 11111110", "JCXZ", "0000")]
        [InlineData("11100011 11111111", "JCXZ", "0001")]
        public void CheckJcxz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Greater
        /// </summary>
        [Theory]
        [InlineData("01111111 00000000", "JG", "0002")]
        [InlineData("01111111 00000001", "JG", "0003")]
        [InlineData("01111111 00000101", "JG", "0007")]
        [InlineData("01111111 00000111", "JG", "0009")]
        [InlineData("01111111 00001011", "JG", "000D")]
        [InlineData("01111111 00011011", "JG", "001D")]
        [InlineData("01111111 00110111", "JG", "0039")]
        [InlineData("01111111 01001100", "JG", "004E")]
        [InlineData("01111111 01111100", "JG", "007E")]
        [InlineData("01111111 10010111", "JG", "FF99")]
        [InlineData("01111111 10011000", "JG", "FF9A")]
        [InlineData("01111111 10110100", "JG", "FFB6")]
        [InlineData("01111111 11000100", "JG", "FFC6")]
        [InlineData("01111111 11000101", "JG", "FFC7")]
        [InlineData("01111111 11010010", "JG", "FFD4")]
        [InlineData("01111111 11100000", "JG", "FFE2")]
        [InlineData("01111111 11111110", "JG", "0000")]
        [InlineData("01111111 11111111", "JG", "0001")]
        public void CheckJg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Greater or Equal
        /// </summary>
        [Theory]
        [InlineData("01111101 00000000", "JGE", "0002")]
        [InlineData("01111101 00000001", "JGE", "0003")]
        [InlineData("01111101 00000101", "JGE", "0007")]
        [InlineData("01111101 00000111", "JGE", "0009")]
        [InlineData("01111101 00001011", "JGE", "000D")]
        [InlineData("01111101 00101000", "JGE", "002A")]
        [InlineData("01111101 01011110", "JGE", "0060")]
        [InlineData("01111101 01101001", "JGE", "006B")]
        [InlineData("01111101 10110111", "JGE", "FFB9")]
        [InlineData("01111101 10111100", "JGE", "FFBE")]
        [InlineData("01111101 11001001", "JGE", "FFCB")]
        [InlineData("01111101 11111110", "JGE", "0000")]
        [InlineData("01111101 11111111", "JGE", "0001")]
        public void CheckJge(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Less
        /// </summary>
        [Theory]
        [InlineData("01111100 00000000", "JL", "0002")]
        [InlineData("01111100 00000001", "JL", "0003")]
        [InlineData("01111100 00000101", "JL", "0007")]
        [InlineData("01111100 00000111", "JL", "0009")]
        [InlineData("01111100 00001011", "JL", "000D")]
        [InlineData("01111100 00010000", "JL", "0012")]
        [InlineData("01111100 00011011", "JL", "001D")]
        [InlineData("01111100 00101000", "JL", "002A")]
        [InlineData("01111100 01100111", "JL", "0069")]
        [InlineData("01111100 01111001", "JL", "007B")]
        [InlineData("01111100 10010111", "JL", "FF99")]
        [InlineData("01111100 10100101", "JL", "FFA7")]
        [InlineData("01111100 10101101", "JL", "FFAF")]
        [InlineData("01111100 10110010", "JL", "FFB4")]
        [InlineData("01111100 11011011", "JL", "FFDD")]
        [InlineData("01111100 11111110", "JL", "0000")]
        [InlineData("01111100 11111111", "JL", "0001")]
        public void CheckJl(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Less or Equal
        /// </summary>
        [Theory]
        [InlineData("01111110 00000000", "JLE", "0002")]
        [InlineData("01111110 00000001", "JLE", "0003")]
        [InlineData("01111110 00000101", "JLE", "0007")]
        [InlineData("01111110 00000111", "JLE", "0009")]
        [InlineData("01111110 00001011", "JLE", "000D")]
        [InlineData("01111110 00010011", "JLE", "0015")]
        [InlineData("01111110 00101001", "JLE", "002B")]
        [InlineData("01111110 00101111", "JLE", "0031")]
        [InlineData("01111110 00111101", "JLE", "003F")]
        [InlineData("01111110 00111110", "JLE", "0040")]
        [InlineData("01111110 01000000", "JLE", "0042")]
        [InlineData("01111110 01001001", "JLE", "004B")]
        [InlineData("01111110 01111010", "JLE", "007C")]
        [InlineData("01111110 10111000", "JLE", "FFBA")]
        [InlineData("01111110 11111110", "JLE", "0000")]
        [InlineData("01111110 11111111", "JLE", "0001")]
        public void CheckJle(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Carry
        /// </summary>
        [Theory]
        public void CheckJnc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Overflow
        /// </summary>
        [Theory]
        [InlineData("01110001 00000000", "JNO", "0002")]
        [InlineData("01110001 00000001", "JNO", "0003")]
        [InlineData("01110001 00000101", "JNO", "0007")]
        [InlineData("01110001 00000111", "JNO", "0009")]
        [InlineData("01110001 00001011", "JNO", "000D")]
        [InlineData("01110001 01010000", "JNO", "0052")]
        [InlineData("01110001 01010100", "JNO", "0056")]
        [InlineData("01110001 01101000", "JNO", "006A")]
        [InlineData("01110001 10000001", "JNO", "FF83")]
        [InlineData("01110001 10001000", "JNO", "FF8A")]
        [InlineData("01110001 10010000", "JNO", "FF92")]
        [InlineData("01110001 10011101", "JNO", "FF9F")]
        [InlineData("01110001 10100111", "JNO", "FFA9")]
        [InlineData("01110001 10111000", "JNO", "FFBA")]
        [InlineData("01110001 11001101", "JNO", "FFCF")]
        [InlineData("01110001 11111110", "JNO", "0000")]
        [InlineData("01110001 11111111", "JNO", "0001")]
        public void CheckJno(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Parity
        /// </summary>
        [Theory]
        public void CheckJnp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Sign
        /// </summary>
        [Theory]
        [InlineData("01111001 00000000", "JNS", "0002")]
        [InlineData("01111001 00000001", "JNS", "0003")]
        [InlineData("01111001 00000101", "JNS", "0007")]
        [InlineData("01111001 00000111", "JNS", "0009")]
        [InlineData("01111001 00001011", "JNS", "000D")]
        [InlineData("01111001 00110000", "JNS", "0032")]
        [InlineData("01111001 10010001", "JNS", "FF93")]
        [InlineData("01111001 10010110", "JNS", "FF98")]
        [InlineData("01111001 10011010", "JNS", "FF9C")]
        [InlineData("01111001 10101011", "JNS", "FFAD")]
        [InlineData("01111001 10101101", "JNS", "FFAF")]
        [InlineData("01111001 11111110", "JNS", "0000")]
        [InlineData("01111001 11111111", "JNS", "0001")]
        public void CheckJns(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Zero
        /// </summary>
        [Theory]
        [InlineData("01110101 00000001", "JNZ", "0003")]
        [InlineData("01110101 00000101", "JNZ", "0007")]
        [InlineData("01110101 00000111", "JNZ", "0009")]
        [InlineData("01110101 00001011", "JNZ", "000D")]
        [InlineData("01110101 00100011", "JNZ", "0025")]
        [InlineData("01110101 00111100", "JNZ", "003E")]
        [InlineData("01110101 00111110", "JNZ", "0040")]
        [InlineData("01110101 01010001", "JNZ", "0053")]
        [InlineData("01110101 01110100", "JNZ", "0076")]
        [InlineData("01110101 10000011", "JNZ", "FF85")]
        [InlineData("01110101 10001011", "JNZ", "FF8D")]
        [InlineData("01110101 11111101", "JNZ", "FFFF")]
        [InlineData("01110101 11111110", "JNZ", "0000")]
        [InlineData("01110101 11111111", "JNZ", "0001")]
        public void CheckJnz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Overflow
        /// </summary>
        [Theory]
        [InlineData("01110000 00000000", "JO", "0002")]
        [InlineData("01110000 00000001", "JO", "0003")]
        [InlineData("01110000 00000101", "JO", "0007")]
        [InlineData("01110000 00000111", "JO", "0009")]
        [InlineData("01110000 00001011", "JO", "000D")]
        [InlineData("01110000 01000011", "JO", "0045")]
        [InlineData("01110000 10000111", "JO", "FF89")]
        [InlineData("01110000 10011010", "JO", "FF9C")]
        [InlineData("01110000 11100110", "JO", "FFE8")]
        [InlineData("01110000 11111110", "JO", "0000")]
        [InlineData("01110000 11111111", "JO", "0001")]
        public void CheckJo(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Parity
        /// </summary>
        [Theory]
        public void CheckJp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Sign
        /// </summary>
        [Theory]
        [InlineData("01111000 00000000", "JS", "0002")]
        [InlineData("01111000 00000001", "JS", "0003")]
        [InlineData("01111000 00000011", "JS", "0005")]
        [InlineData("01111000 00000101", "JS", "0007")]
        [InlineData("01111000 00000111", "JS", "0009")]
        [InlineData("01111000 00001011", "JS", "000D")]
        [InlineData("01111000 00001101", "JS", "000F")]
        [InlineData("01111000 00101000", "JS", "002A")]
        [InlineData("01111000 00111001", "JS", "003B")]
        [InlineData("01111000 01000000", "JS", "0042")]
        [InlineData("01111000 01010001", "JS", "0053")]
        [InlineData("01111000 01010010", "JS", "0054")]
        [InlineData("01111000 01011101", "JS", "005F")]
        [InlineData("01111000 10111001", "JS", "FFBB")]
        [InlineData("01111000 11001111", "JS", "FFD1")]
        [InlineData("01111000 11011001", "JS", "FFDB")]
        [InlineData("01111000 11011111", "JS", "FFE1")]
        [InlineData("01111000 11111011", "JS", "FFFD")]
        [InlineData("01111000 11111110", "JS", "0000")]
        [InlineData("01111000 11111111", "JS", "0001")]
        public void CheckJs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Zero
        /// </summary>
        [Theory]
        [InlineData("01110100 00000000", "JZ", "0002")]
        [InlineData("01110100 00000001", "JZ", "0003")]
        [InlineData("01110100 00000101", "JZ", "0007")]
        [InlineData("01110100 00000111", "JZ", "0009")]
        [InlineData("01110100 00001010", "JZ", "000C")]
        [InlineData("01110100 00001011", "JZ", "000D")]
        [InlineData("01110100 01000011", "JZ", "0045")]
        [InlineData("01110100 10000000", "JZ", "FF82")]
        [InlineData("01110100 10001101", "JZ", "FF8F")]
        [InlineData("01110100 10001110", "JZ", "FF90")]
        [InlineData("01110100 10101001", "JZ", "FFAB")]
        [InlineData("01110100 10110011", "JZ", "FFB5")]
        [InlineData("01110100 10111001", "JZ", "FFBB")]
        [InlineData("01110100 11000110", "JZ", "FFC8")]
        [InlineData("01110100 11111110", "JZ", "0000")]
        [InlineData("01110100 11111111", "JZ", "0001")]
        public void CheckJz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class FlagsTest : AbstractDecodeTest
    {
        /// <summary>
        /// Clear Carry Flag
        /// </summary>
        [Theory]
        [InlineData("11111000", "CLC", "")]
        public void CheckClc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Clear Direction Flag
        /// </summary>
        [Theory]
        [InlineData("11111100", "CLD", "")]
        public void CheckCld(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Clear Interrupt Flag
        /// </summary>
        [Theory]
        [InlineData("11111010", "CLI", "")]
        public void CheckCli(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Complement Carry Flag
        /// </summary>
        [Theory]
        [InlineData("11110101", "CMC", "")]
        public void CheckCmc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load Status Flags Into AH Register
        /// </summary>
        [Theory]
        [InlineData("10011111", "LAHF", "")]
        public void CheckLahf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store AH Into Flags
        /// </summary>
        [Theory]
        [InlineData("10011110", "SAHF", "")]
        public void CheckSahf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Set Carry Flag
        /// </summary>
        [Theory]
        [InlineData("11111001", "STC", "")]
        public void CheckStc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Set Direction Flag
        /// </summary>
        [Theory]
        [InlineData("11111101", "STD", "")]
        public void CheckStd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Set Interrupt Flag
        /// </summary>
        [Theory]
        [InlineData("11111011", "STI", "")]
        public void CheckSti(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class InterruptTest : AbstractDecodeTest
    {
        /// <summary>
        /// Check Index Against Bounds
        /// </summary>
        [Theory]
        [InlineData("01100010 00000000", "BOUND", "AX,Word Ptr [BX+SI]")]
        [InlineData("01100010 00000001", "BOUND", "AX,Word Ptr [BX+DI]")]
        [InlineData("01100010 00000111", "BOUND", "AX,Word Ptr [BX]")]
        [InlineData("01100010 00111101", "BOUND", "DI,Word Ptr [DI]")]
        [InlineData("01100010 01000010 00010000", "BOUND", "AX,Word Ptr [BP+SI+10]")]
        [InlineData("01100010 01010011 10100111", "BOUND", "DX,Word Ptr [BP+DI-59]")]
        [InlineData("01100010 01111000 10000011", "BOUND", "DI,Word Ptr [BX+SI-7D]")]
        [InlineData("01100010 00000110 01100101 01011011", "BOUND", "AX,Word Ptr [5B65]")]
        [InlineData("01100010 10000011 10001101 00010011", "BOUND", "AX,Word Ptr [BP+DI+138D]")]
        [InlineData("01100010 10000100 00101110 10101010", "BOUND", "AX,Word Ptr [SI-55D2]")]
        [InlineData("01100010 10010001 10010101 11001110", "BOUND", "DX,Word Ptr [BX+DI-316B]")]
        public void CheckBound(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Halt
        /// </summary>
        [Theory]
        [InlineData("11110100", "HLT", "")]
        public void CheckHlt(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        [Theory]
        [InlineData("11001101 00000000", "INT", "00")]
        [InlineData("11001101 00000001", "INT", "01")]
        [InlineData("11001101 00000011", "INT", "03")]
        [InlineData("11001101 00000111", "INT", "07")]
        [InlineData("11001101 00001001", "INT", "09")]
        [InlineData("11001101 00001101", "INT", "0D")]
        [InlineData("11001101 00010101", "INT", "15")]
        [InlineData("11001101 00110000", "INT", "30")]
        [InlineData("11001101 01010111", "INT", "57")]
        [InlineData("11001101 01101000", "INT", "68")]
        [InlineData("11001101 01101111", "INT", "6F")]
        [InlineData("11001101 10101111", "INT", "AF")]
        [InlineData("11001101 10111001", "INT", "B9")]
        [InlineData("11001101 11010010", "INT", "D2")]
        [InlineData("11001101 11010111", "INT", "D7")]
        [InlineData("11001101 11100001", "INT", "E1")]
        [InlineData("11001101 11100100", "INT", "E4")]
        [InlineData("11001101 11110001", "INT", "F1")]
        public void CheckInt(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        [Theory]
        [InlineData("11001110", "INTO", "")]
        public void CheckInto(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Interrupt Return
        /// </summary>
        [Theory]
        [InlineData("11001111", "IRET", "")]
        public void CheckIret(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class JumpTest : AbstractDecodeTest
    {
        /// <summary>
        /// Call Procedure
        /// </summary>
        [Theory]
        [InlineData("11111111 00010011", "CALL", "[BP+DI]")]
        [InlineData("11111111 11010000", "CALL", "AX")]
        [InlineData("11111111 11010001", "CALL", "CX")]
        [InlineData("11111111 11010010", "CALL", "DX")]
        [InlineData("11111111 11010011", "CALL", "BX")]
        [InlineData("11111111 11010100", "CALL", "SP")]
        [InlineData("11111111 11010101", "CALL", "BP")]
        [InlineData("11111111 11010110", "CALL", "SI")]
        [InlineData("11111111 11010111", "CALL", "DI")]
        [InlineData("11101000 00000001 10101000", "CALL", "A804")]
        [InlineData("11101000 00000110 00000000", "CALL", "0009")]
        [InlineData("11101000 00000111 01100010", "CALL", "620A")]
        [InlineData("11101000 00001101 00011010", "CALL", "1A10")]
        [InlineData("11101000 00011000 00010100", "CALL", "141B")]
        [InlineData("11101000 00101000 00000000", "CALL", "002B")]
        [InlineData("11101000 00111010 00001000", "CALL", "083D")]
        [InlineData("11101000 01001000 01100000", "CALL", "604B")]
        [InlineData("11101000 01111001 10010001", "CALL", "917C")]
        [InlineData("11101000 01111110 10101011", "CALL", "AB81")]
        [InlineData("11101000 10000011 10110101", "CALL", "B586")]
        [InlineData("11101000 11001110 10101110", "CALL", "AED1")]
        [InlineData("11101000 11011000 11011111", "CALL", "DFDB")]
        [InlineData("11101000 11011001 01001001", "CALL", "49DC")]
        [InlineData("11101000 11111110 11111111", "CALL", "0001")]
        [InlineData("11111111 01011001 00011001", "CALL", "FAR [BX+DI+19]")]
        [InlineData("10011010 00000000 00001100 11010010 01001011", "CALL", "4BD2:0C00")]
        [InlineData("10011010 00000001 11110100 11011111 11010111", "CALL", "D7DF:F401")]
        [InlineData("10011010 00000110 11111011 11100010 00110110", "CALL", "36E2:FB06")]
        [InlineData("10011010 00001001 00000000 00001001 00000000", "CALL", "0009:0009")]
        [InlineData("10011010 00101110 10000011 01010011 10100010", "CALL", "A253:832E")]
        [InlineData("10011010 00110101 11110010 01001111 00001001", "CALL", "094F:F235")]
        [InlineData("10011010 01101011 01110000 01011100 00111110", "CALL", "3E5C:706B")]
        [InlineData("10011010 01101110 10100011 10010001 11101001", "CALL", "E991:A36E")]
        [InlineData("10011010 01111011 00110100 00000010 11000111", "CALL", "C702:347B")]
        [InlineData("10011010 10000010 10110101 11100000 00011110", "CALL", "1EE0:B582")]
        [InlineData("10011010 10011110 11011010 11100000 10011110", "CALL", "9EE0:DA9E")]
        [InlineData("10011010 11111111 01111010 01101001 01101010", "CALL", "6A69:7AFF")]
        public void CheckCall(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unconditional Jump
        /// </summary>
        [Theory]
        [InlineData("11101011 00000000", "JMP", "0002")]
        [InlineData("11101011 00000001", "JMP", "0003")]
        [InlineData("11101011 00000111", "JMP", "0009")]
        [InlineData("11101011 00001101", "JMP", "000F")]
        [InlineData("11101011 00110101", "JMP", "0037")]
        [InlineData("11101011 00110111", "JMP", "0039")]
        [InlineData("11101011 01011100", "JMP", "005E")]
        [InlineData("11101011 10001000", "JMP", "FF8A")]
        [InlineData("11101011 10011101", "JMP", "FF9F")]
        [InlineData("11101011 10011110", "JMP", "FFA0")]
        [InlineData("11101011 10101000", "JMP", "FFAA")]
        [InlineData("11101011 10111100", "JMP", "FFBE")]
        [InlineData("11101011 11111111", "JMP", "0001")]
        [InlineData("11111111 00101001", "JMP", "FAR [BX+DI]")]
        [InlineData("11111111 11100000", "JMP", "AX")]
        [InlineData("11111111 11100001", "JMP", "CX")]
        [InlineData("11111111 11100010", "JMP", "DX")]
        [InlineData("11111111 11100011", "JMP", "BX")]
        [InlineData("11111111 11100100", "JMP", "SP")]
        [InlineData("11111111 11100101", "JMP", "BP")]
        [InlineData("11111111 11100110", "JMP", "SI")]
        [InlineData("11111111 11100111", "JMP", "DI")]
        [InlineData("11101001 00000000 11011100", "JMP", "DC03")]
        [InlineData("11101001 00000001 00011110", "JMP", "1E04")]
        [InlineData("11101001 00001110 10010000", "JMP", "9011")]
        [InlineData("11101001 00101111 10111000", "JMP", "B832")]
        [InlineData("11101001 01100100 00100101", "JMP", "2567")]
        [InlineData("11101001 01111101 01011011", "JMP", "5B80")]
        [InlineData("11101001 10000101 10111110", "JMP", "BE88")]
        [InlineData("11101001 10111101 00010101", "JMP", "15C0")]
        [InlineData("11111111 10101000 10101001 01101101", "JMP", "FAR [BX+SI+6DA9]")]
        [InlineData("11101010 00000000 01100010 00110011 10001010", "JMP", "8A33:6200")]
        [InlineData("11101010 00000001 10000001 00101111 01110000", "JMP", "702F:8101")]
        [InlineData("11101010 00001001 00000000 00001001 00000000", "JMP", "0009:0009")]
        [InlineData("11101010 00011001 01100000 10000110 01011110", "JMP", "5E86:6019")]
        [InlineData("11101010 01101110 10001111 00100110 01100001", "JMP", "6126:8F6E")]
        [InlineData("11101010 01110001 01100100 01111010 01111001", "JMP", "797A:6471")]
        [InlineData("11101010 11000010 11100011 00000100 01101011", "JMP", "6B04:E3C2")]
        [InlineData("11101010 11010010 10011110 11110101 01011000", "JMP", "58F5:9ED2")]
        public void CheckJmp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Return From Procedure
        /// </summary>
        [Theory]
        [InlineData("11000011", "RET", "")]
        [InlineData("11000010 00000001 00110110", "RET", "3601")]
        [InlineData("11000010 00000111 00101001", "RET", "2907")]
        [InlineData("11000010 00001001 00000000", "RET", "0009")]
        [InlineData("11000010 00001100 01101001", "RET", "690C")]
        [InlineData("11000010 00100111 01001110", "RET", "4E27")]
        [InlineData("11000010 00110101 00010110", "RET", "1635")]
        [InlineData("11000010 01000010 11010100", "RET", "D442")]
        [InlineData("11000010 01000111 11111111", "RET", "FF47")]
        [InlineData("11000010 01001001 01011110", "RET", "5E49")]
        [InlineData("11000010 01110110 00110000", "RET", "3076")]
        [InlineData("11000010 10010100 10001000", "RET", "8894")]
        [InlineData("11000010 11011001 00010001", "RET", "11D9")]
        public void CheckRet(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Return From Far Procedure
        /// </summary>
        [Theory]
        [InlineData("11001011", "RETF", "")]
        [InlineData("11001010 00000000 10010011", "RETF", "9300")]
        [InlineData("11001010 00000001 11010001", "RETF", "D101")]
        [InlineData("11001010 00001001 00000000", "RETF", "0009")]
        [InlineData("11001010 00010000 00001110", "RETF", "0E10")]
        [InlineData("11001010 00010000 01110000", "RETF", "7010")]
        [InlineData("11001010 01000011 01100000", "RETF", "6043")]
        [InlineData("11001010 01100001 10110101", "RETF", "B561")]
        [InlineData("11001010 01111010 11100001", "RETF", "E17A")]
        [InlineData("11001010 10001001 10011000", "RETF", "9889")]
        [InlineData("11001010 10011101 00100010", "RETF", "229D")]
        [InlineData("11001010 11001000 11101010", "RETF", "EAC8")]
        [InlineData("11001010 11100000 11111101", "RETF", "FDE0")]
        public void CheckRetf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class LoopTest : AbstractDecodeTest
    {
        /// <summary>
        /// Loop According to ECX Counter
        /// </summary>
        [Theory]
        [InlineData("11100010 00000000", "LOOP", "0002")]
        [InlineData("11100010 00000001", "LOOP", "0003")]
        [InlineData("11100010 00000101", "LOOP", "0007")]
        [InlineData("11100010 00000111", "LOOP", "0009")]
        [InlineData("11100010 00001011", "LOOP", "000D")]
        [InlineData("11100010 00001100", "LOOP", "000E")]
        [InlineData("11100010 00011010", "LOOP", "001C")]
        [InlineData("11100010 00100101", "LOOP", "0027")]
        [InlineData("11100010 00110000", "LOOP", "0032")]
        [InlineData("11100010 00111111", "LOOP", "0041")]
        [InlineData("11100010 10011010", "LOOP", "FF9C")]
        [InlineData("11100010 10100100", "LOOP", "FFA6")]
        [InlineData("11100010 10101010", "LOOP", "FFAC")]
        [InlineData("11100010 11011001", "LOOP", "FFDB")]
        [InlineData("11100010 11100110", "LOOP", "FFE8")]
        [InlineData("11100010 11111110", "LOOP", "0000")]
        [InlineData("11100010 11111111", "LOOP", "0001")]
        public void CheckLoop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Equal
        /// </summary>
        [Theory]
        public void CheckLoope(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Not Equal
        /// </summary>
        [Theory]
        public void CheckLoopne(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class MemoryTest : AbstractDecodeTest
    {
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        [Theory]
        [InlineData("11000101 00000000", "LDS", "AX,DWord Ptr [BX+SI]")]
        [InlineData("11000101 00000001", "LDS", "AX,DWord Ptr [BX+DI]")]
        [InlineData("11000101 00000111", "LDS", "AX,DWord Ptr [BX]")]
        [InlineData("11000101 00101100", "LDS", "BP,DWord Ptr [SI]")]
        [InlineData("11000101 00111010", "LDS", "DI,DWord Ptr [BP+SI]")]
        [InlineData("11000101 11000101", "LDS", "AX,DBP")]
        [InlineData("11000101 11001001", "LDS", "CX,DCX")]
        [InlineData("11000101 11011000", "LDS", "BX,DAX")]
        [InlineData("11000101 11111011", "LDS", "DI,DBX")]
        [InlineData("11000101 01000101 11100101", "LDS", "AX,DWord Ptr [DI-1B]")]
        [InlineData("11000101 01100111 01011011", "LDS", "SP,DWord Ptr [BX+5B]")]
        [InlineData("11000101 01111101 11001000", "LDS", "DI,DWord Ptr [DI-38]")]
        [InlineData("11000101 10010101 00100100 00000010", "LDS", "DX,DWord Ptr [DI+0224]")]
        [InlineData("11000101 10110110 00111001 11000110", "LDS", "SI,DWord Ptr [BP-39C7]")]
        public void CheckLds(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load Effective Address
        /// </summary>
        [Theory]
        [InlineData("10001101 00000000", "LEA", "AX,[BX+SI]")]
        [InlineData("10001101 00000001", "LEA", "AX,[BX+DI]")]
        [InlineData("10001101 00000111", "LEA", "AX,[BX]")]
        [InlineData("10001101 00100001", "LEA", "SP,[BX+DI]")]
        [InlineData("10001101 00101000", "LEA", "BP,[BX+SI]")]
        [InlineData("10001101 11000101", "LEA", "AX,BP")]
        [InlineData("10001101 11101001", "LEA", "BP,CX")]
        [InlineData("10001101 11111101", "LEA", "DI,BP")]
        [InlineData("10001101 01000000 01000010", "LEA", "AX,[BX+SI+42]")]
        [InlineData("10001101 01000011 01100100", "LEA", "AX,[BP+DI+64]")]
        [InlineData("10001101 01101011 11111011", "LEA", "BP,[BP+DI-05]")]
        [InlineData("10001101 01110011 10100100", "LEA", "SI,[BP+DI-5C]")]
        [InlineData("10001101 10000110 01101100 01101000", "LEA", "AX,[BP+686C]")]
        [InlineData("10001101 10001011 11110100 01110000", "LEA", "CX,[BP+DI+70F4]")]
        [InlineData("10001101 10011001 10011100 10001011", "LEA", "BX,[BX+DI-7464]")]
        [InlineData("10001101 10101110 01111000 10101010", "LEA", "BP,[BP-5588]")]
        [InlineData("10001101 10110011 01011001 00010010", "LEA", "SI,[BP+DI+1259]")]
        public void CheckLea(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        [Theory]
        [InlineData("11000100 00000000", "LES", "AX,DWord Ptr [BX+SI]")]
        [InlineData("11000100 00000001", "LES", "AX,DWord Ptr [BX+DI]")]
        [InlineData("11000100 00000111", "LES", "AX,DWord Ptr [BX]")]
        [InlineData("11000100 00010000", "LES", "DX,DWord Ptr [BX+SI]")]
        [InlineData("11000100 11000010", "LES", "AX,DDX")]
        [InlineData("11000100 11010001", "LES", "DX,DCX")]
        [InlineData("11000100 11100010", "LES", "SP,DDX")]
        [InlineData("11000100 11101010", "LES", "BP,DDX")]
        [InlineData("11000100 11101100", "LES", "BP,DSP")]
        [InlineData("11000100 11110011", "LES", "SI,DBX")]
        [InlineData("11000100 01000001 00010111", "LES", "AX,DWord Ptr [BX+DI+17]")]
        [InlineData("11000100 00111110 10100010 10011111", "LES", "DI,DWord Ptr [9FA2]")]
        [InlineData("11000100 10000001 10100111 10100111", "LES", "AX,DWord Ptr [BX+DI-5859]")]
        [InlineData("11000100 10000110 00001100 00000111", "LES", "AX,DWord Ptr [BP+070C]")]
        [InlineData("11000100 10010111 11010110 01011000", "LES", "DX,DWord Ptr [BX+58D6]")]
        [InlineData("11000100 10111111 00011110 10110111", "LES", "DI,DWord Ptr [BX-48E2]")]
        public void CheckLes(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move
        /// </summary>
        [Theory]
        [InlineData("10001000 00000000", "MOV", "Byte Ptr [BX+SI],AL")]
        [InlineData("10001000 00000001", "MOV", "Byte Ptr [BX+DI],AL")]
        [InlineData("10001000 00000010", "MOV", "Byte Ptr [BP+SI],AL")]
        [InlineData("10001000 00001011", "MOV", "Byte Ptr [BP+DI],CL")]
        [InlineData("10001000 00011000", "MOV", "Byte Ptr [BX+SI],BL")]
        [InlineData("10001000 00101010", "MOV", "Byte Ptr [BP+SI],CH")]
        [InlineData("10001000 11001110", "MOV", "DH,CL")]
        [InlineData("10001000 11011011", "MOV", "BL,BL")]
        [InlineData("10001000 11100100", "MOV", "AH,AH")]
        [InlineData("10001000 11101010", "MOV", "DL,CH")]
        [InlineData("10001001 00000000", "MOV", "Word Ptr [BX+SI],AX")]
        [InlineData("10001001 00000001", "MOV", "Word Ptr [BX+DI],AX")]
        [InlineData("10001001 11011000", "MOV", "AX,BX")]
        [InlineData("10001001 11011011", "MOV", "BX,BX")]
        [InlineData("10001001 11101101", "MOV", "BP,BP")]
        [InlineData("10001010 00000000", "MOV", "AL,Byte Ptr [BX+SI]")]
        [InlineData("10001010 00000001", "MOV", "AL,Byte Ptr [BX+DI]")]
        [InlineData("10001010 00110000", "MOV", "DH,Byte Ptr [BX+SI]")]
        [InlineData("10001010 11010111", "MOV", "DL,BH")]
        [InlineData("10001010 11011000", "MOV", "BL,AL")]
        [InlineData("10001010 11100100", "MOV", "AH,AH")]
        [InlineData("10001011 00000000", "MOV", "AX,Word Ptr [BX+SI]")]
        [InlineData("10001011 00000001", "MOV", "AX,Word Ptr [BX+DI]")]
        [InlineData("10001011 11010011", "MOV", "DX,BX")]
        [InlineData("10001011 11101010", "MOV", "BP,DX")]
        [InlineData("10001100 00000000", "MOV", "Word Ptr [BX+SI],ES")]
        [InlineData("10001100 00000001", "MOV", "Word Ptr [BX+DI],ES")]
        [InlineData("10001100 00011010", "MOV", "Word Ptr [BP+SI],DS")]
        [InlineData("10001100 00100100", "MOV", "Word Ptr [SI],ES")]
        [InlineData("10001100 00101011", "MOV", "Word Ptr [BP+DI],CS")]
        [InlineData("10001100 00111001", "MOV", "Word Ptr [BX+DI],DS")]
        [InlineData("10001100 11000101", "MOV", "BP,ES")]
        [InlineData("10001100 11010000", "MOV", "AX,SS")]
        [InlineData("10001100 11010100", "MOV", "SP,SS")]
        [InlineData("10001100 11011011", "MOV", "BX,DS")]
        [InlineData("10001100 11110000", "MOV", "AX,SS")]
        [InlineData("10001100 11110111", "MOV", "DI,SS")]
        [InlineData("10001110 00000000", "MOV", "ES,Word Ptr [BX+SI]")]
        [InlineData("10001110 00000001", "MOV", "ES,Word Ptr [BX+DI]")]
        [InlineData("10001110 00010001", "MOV", "SS,Word Ptr [BX+DI]")]
        [InlineData("10001110 00101101", "MOV", "CS,Word Ptr [DI]")]
        [InlineData("10001110 11011011", "MOV", "DS,BX")]
        [InlineData("10001110 11111100", "MOV", "DS,SP")]
        [InlineData("10110000 00000000", "MOV", "AL,00")]
        [InlineData("10110000 00000001", "MOV", "AL,01")]
        [InlineData("10110000 00101000", "MOV", "AL,28")]
        [InlineData("10110000 01001011", "MOV", "AL,4B")]
        [InlineData("10110000 01100001", "MOV", "AL,61")]
        [InlineData("10110000 11100110", "MOV", "AL,E6")]
        [InlineData("10110001 00000000", "MOV", "CL,00")]
        [InlineData("10110001 00000001", "MOV", "CL,01")]
        [InlineData("10110001 00000010", "MOV", "CL,02")]
        [InlineData("10110001 00100000", "MOV", "CL,20")]
        [InlineData("10110001 01001101", "MOV", "CL,4D")]
        [InlineData("10110001 01100010", "MOV", "CL,62")]
        [InlineData("10110001 10001101", "MOV", "CL,8D")]
        [InlineData("10110001 11000000", "MOV", "CL,C0")]
        [InlineData("10110001 11001110", "MOV", "CL,CE")]
        [InlineData("10110010 00000000", "MOV", "DL,00")]
        [InlineData("10110010 00000001", "MOV", "DL,01")]
        [InlineData("10110010 00001001", "MOV", "DL,09")]
        [InlineData("10110010 00010001", "MOV", "DL,11")]
        [InlineData("10110010 00010011", "MOV", "DL,13")]
        [InlineData("10110010 01101010", "MOV", "DL,6A")]
        [InlineData("10110010 10111001", "MOV", "DL,B9")]
        [InlineData("10110010 10111101", "MOV", "DL,BD")]
        [InlineData("10110010 11000001", "MOV", "DL,C1")]
        [InlineData("10110010 11000100", "MOV", "DL,C4")]
        [InlineData("10110010 11100011", "MOV", "DL,E3")]
        [InlineData("10110011 00000000", "MOV", "BL,00")]
        [InlineData("10110011 00000001", "MOV", "BL,01")]
        [InlineData("10110011 00010001", "MOV", "BL,11")]
        [InlineData("10110011 10010000", "MOV", "BL,90")]
        [InlineData("10110011 10011100", "MOV", "BL,9C")]
        [InlineData("10110011 10111001", "MOV", "BL,B9")]
        [InlineData("10110011 11111011", "MOV", "BL,FB")]
        [InlineData("10110100 00000000", "MOV", "AH,00")]
        [InlineData("10110100 00000001", "MOV", "AH,01")]
        [InlineData("10110100 00001001", "MOV", "AH,09")]
        [InlineData("10110100 00101001", "MOV", "AH,29")]
        [InlineData("10110100 00110100", "MOV", "AH,34")]
        [InlineData("10110100 01001111", "MOV", "AH,4F")]
        [InlineData("10110100 01010010", "MOV", "AH,52")]
        [InlineData("10110100 10110110", "MOV", "AH,B6")]
        [InlineData("10110100 11001101", "MOV", "AH,CD")]
        [InlineData("10110100 11011111", "MOV", "AH,DF")]
        [InlineData("10110100 11110110", "MOV", "AH,F6")]
        [InlineData("10110101 00000000", "MOV", "CH,00")]
        [InlineData("10110101 00000001", "MOV", "CH,01")]
        [InlineData("10110101 00011101", "MOV", "CH,1D")]
        [InlineData("10110101 00100101", "MOV", "CH,25")]
        [InlineData("10110101 00100110", "MOV", "CH,26")]
        [InlineData("10110101 01001110", "MOV", "CH,4E")]
        [InlineData("10110101 01010011", "MOV", "CH,53")]
        [InlineData("10110101 10000110", "MOV", "CH,86")]
        [InlineData("10110101 10001011", "MOV", "CH,8B")]
        [InlineData("10110101 10101100", "MOV", "CH,AC")]
        [InlineData("10110101 10111010", "MOV", "CH,BA")]
        [InlineData("10110101 11000000", "MOV", "CH,C0")]
        [InlineData("10110101 11001110", "MOV", "CH,CE")]
        [InlineData("10110101 11010010", "MOV", "CH,D2")]
        [InlineData("10110101 11010101", "MOV", "CH,D5")]
        [InlineData("10110101 11111001", "MOV", "CH,F9")]
        [InlineData("10110110 00000000", "MOV", "DH,00")]
        [InlineData("10110110 00000001", "MOV", "DH,01")]
        [InlineData("10110110 00001110", "MOV", "DH,0E")]
        [InlineData("10110110 00011001", "MOV", "DH,19")]
        [InlineData("10110110 01001010", "MOV", "DH,4A")]
        [InlineData("10110110 01010010", "MOV", "DH,52")]
        [InlineData("10110110 01011001", "MOV", "DH,59")]
        [InlineData("10110110 01100111", "MOV", "DH,67")]
        [InlineData("10110110 10110101", "MOV", "DH,B5")]
        [InlineData("10110110 10111111", "MOV", "DH,BF")]
        [InlineData("10110110 11000100", "MOV", "DH,C4")]
        [InlineData("10110110 11011101", "MOV", "DH,DD")]
        [InlineData("10110110 11110001", "MOV", "DH,F1")]
        [InlineData("10110110 11111010", "MOV", "DH,FA")]
        [InlineData("10110111 00000000", "MOV", "BH,00")]
        [InlineData("10110111 00000001", "MOV", "BH,01")]
        [InlineData("10110111 00111011", "MOV", "BH,3B")]
        [InlineData("10110111 10000100", "MOV", "BH,84")]
        [InlineData("10110111 10001101", "MOV", "BH,8D")]
        [InlineData("10110111 10011100", "MOV", "BH,9C")]
        [InlineData("10110111 11000110", "MOV", "BH,C6")]
        [InlineData("10001000 01000111 10000001", "MOV", "Byte Ptr [BX-7F],AL")]
        [InlineData("10001000 01111010 01100010", "MOV", "Byte Ptr [BP+SI+62],BH")]
        [InlineData("10001001 01001010 00011001", "MOV", "Word Ptr [BP+SI+19],CX")]
        [InlineData("10001010 01010101 10000000", "MOV", "DL,Byte Ptr [DI-80]")]
        [InlineData("10001010 01101111 11100100", "MOV", "CH,Byte Ptr [BX-1C]")]
        [InlineData("10001010 01111010 11001110", "MOV", "BH,Byte Ptr [BP+SI-32]")]
        [InlineData("10001011 01101011 10011101", "MOV", "BP,Word Ptr [BP+DI-63]")]
        [InlineData("10001011 01111011 00010110", "MOV", "DI,Word Ptr [BP+DI+16]")]
        [InlineData("10001011 01111100 00011000", "MOV", "DI,Word Ptr [SI+18]")]
        [InlineData("10001100 01010101 01110100", "MOV", "Word Ptr [DI+74],SS")]
        [InlineData("10001100 01110000 11110000", "MOV", "Word Ptr [BX+SI-10],SS")]
        [InlineData("10001110 01101101 10110011", "MOV", "CS,Word Ptr [DI-4D]")]
        [InlineData("10001110 01111101 00010111", "MOV", "DS,Word Ptr [DI+17]")]
        [InlineData("10001110 01111110 00010100", "MOV", "DS,Word Ptr [BP+14]")]
        [InlineData("10100000 00000000 00110110", "MOV", "AL,[3600]")]
        [InlineData("10100000 00000001 01111110", "MOV", "AL,[7E01]")]
        [InlineData("10100000 00000110 11100111", "MOV", "AL,[E706]")]
        [InlineData("10100000 00001100 10010011", "MOV", "AL,[930C]")]
        [InlineData("10100000 00001100 10110111", "MOV", "AL,[B70C]")]
        [InlineData("10100000 00001110 11111010", "MOV", "AL,[FA0E]")]
        [InlineData("10100000 01001000 11000010", "MOV", "AL,[C248]")]
        [InlineData("10100000 01101000 01111111", "MOV", "AL,[7F68]")]
        [InlineData("10100000 10011011 11111111", "MOV", "AL,[FF9B]")]
        [InlineData("10100000 11100101 11111000", "MOV", "AL,[F8E5]")]
        [InlineData("10100000 11111001 01110001", "MOV", "AL,[71F9]")]
        [InlineData("10100001 00000000 10110110", "MOV", "AX,[B600]")]
        [InlineData("10100001 00000001 01111011", "MOV", "AX,[7B01]")]
        [InlineData("10100001 00110000 11001110", "MOV", "AX,[CE30]")]
        [InlineData("10100001 00111000 11111100", "MOV", "AX,[FC38]")]
        [InlineData("10100001 00111001 10101111", "MOV", "AX,[AF39]")]
        [InlineData("10100001 01101101 10010010", "MOV", "AX,[926D]")]
        [InlineData("10100001 10001011 01011110", "MOV", "AX,[5E8B]")]
        [InlineData("10100001 10100101 01010011", "MOV", "AX,[53A5]")]
        [InlineData("10100001 11011011 00000001", "MOV", "AX,[01DB]")]
        [InlineData("10100010 00000000 00010011", "MOV", "[1300],AL")]
        [InlineData("10100010 00000001 01100011", "MOV", "[6301],AL")]
        [InlineData("10100010 00000001 11001000", "MOV", "[C801],AL")]
        [InlineData("10100010 00001000 01100110", "MOV", "[6608],AL")]
        [InlineData("10100010 00010000 11111110", "MOV", "[FE10],AL")]
        [InlineData("10100010 00101110 00000110", "MOV", "[062E],AL")]
        [InlineData("10100010 01100000 01111101", "MOV", "[7D60],AL")]
        [InlineData("10100010 10100011 11100101", "MOV", "[E5A3],AL")]
        [InlineData("10100010 10101110 01100011", "MOV", "[63AE],AL")]
        [InlineData("10100010 10101111 01011110", "MOV", "[5EAF],AL")]
        [InlineData("10100010 11111111 01110101", "MOV", "[75FF],AL")]
        [InlineData("10100011 00000000 01001010", "MOV", "[4A00],AX")]
        [InlineData("10100011 00000001 10011000", "MOV", "[9801],AX")]
        [InlineData("10100011 00111110 01110010", "MOV", "[723E],AX")]
        [InlineData("10100011 01010000 01110010", "MOV", "[7250],AX")]
        [InlineData("10100011 01111111 11000110", "MOV", "[C67F],AX")]
        [InlineData("10100011 11000010 01101001", "MOV", "[69C2],AX")]
        [InlineData("10100011 11010000 10100111", "MOV", "[A7D0],AX")]
        [InlineData("10100011 11010010 10101001", "MOV", "[A9D2],AX")]
        [InlineData("10100011 11110000 10111110", "MOV", "[BEF0],AX")]
        [InlineData("10111000 00000000 10010001", "MOV", "AX,9100")]
        [InlineData("10111000 00000001 10010011", "MOV", "AX,9301")]
        [InlineData("10111000 00001011 11100100", "MOV", "AX,E40B")]
        [InlineData("10111000 00001110 01111101", "MOV", "AX,7D0E")]
        [InlineData("10111000 01001011 00000100", "MOV", "AX,044B")]
        [InlineData("10111000 01001011 10100011", "MOV", "AX,A34B")]
        [InlineData("10111000 10100111 01111010", "MOV", "AX,7AA7")]
        [InlineData("10111000 11000001 00110001", "MOV", "AX,31C1")]
        [InlineData("10111000 11011111 01010000", "MOV", "AX,50DF")]
        [InlineData("10111000 11100111 00100110", "MOV", "AX,26E7")]
        [InlineData("10111000 11101101 11001110", "MOV", "AX,CEED")]
        [InlineData("10111000 11111000 11111001", "MOV", "AX,F9F8")]
        [InlineData("10111001 00000000 01101000", "MOV", "CX,6800")]
        [InlineData("10111001 00000001 01101111", "MOV", "CX,6F01")]
        [InlineData("10111001 00010010 10101101", "MOV", "CX,AD12")]
        [InlineData("10111001 00010010 10111111", "MOV", "CX,BF12")]
        [InlineData("10111001 00011111 11111000", "MOV", "CX,F81F")]
        [InlineData("10111001 00101100 01011111", "MOV", "CX,5F2C")]
        [InlineData("10111001 00111010 10010111", "MOV", "CX,973A")]
        [InlineData("10111001 01011010 00010100", "MOV", "CX,145A")]
        [InlineData("10111001 01111000 00011001", "MOV", "CX,1978")]
        [InlineData("10111001 10001101 00101001", "MOV", "CX,298D")]
        [InlineData("10111001 11000100 01000001", "MOV", "CX,41C4")]
        [InlineData("10111001 11001100 11011000", "MOV", "CX,D8CC")]
        [InlineData("10111001 11110111 00111010", "MOV", "CX,3AF7")]
        [InlineData("10111010 00000000 11000011", "MOV", "DX,C300")]
        [InlineData("10111010 00000001 10001110", "MOV", "DX,8E01")]
        [InlineData("10111010 00000011 10000001", "MOV", "DX,8103")]
        [InlineData("10111010 01111111 11011100", "MOV", "DX,DC7F")]
        [InlineData("10111010 10111011 01001101", "MOV", "DX,4DBB")]
        [InlineData("10111010 11001001 00001101", "MOV", "DX,0DC9")]
        [InlineData("10111010 11100011 00110100", "MOV", "DX,34E3")]
        [InlineData("10111010 11100100 01110100", "MOV", "DX,74E4")]
        [InlineData("10111010 11101010 11010101", "MOV", "DX,D5EA")]
        [InlineData("10111010 11111101 11011001", "MOV", "DX,D9FD")]
        [InlineData("10111011 00000000 10110010", "MOV", "BX,B200")]
        [InlineData("10111011 00000001 01100011", "MOV", "BX,6301")]
        [InlineData("10111011 00000001 10011010", "MOV", "BX,9A01")]
        [InlineData("10111011 00001001 00000000", "MOV", "BX,0009")]
        [InlineData("10111011 00011011 11111100", "MOV", "BX,FC1B")]
        [InlineData("10111011 01110001 01111000", "MOV", "BX,7871")]
        [InlineData("10111011 10011110 01010101", "MOV", "BX,559E")]
        [InlineData("10111011 10101011 11111011", "MOV", "BX,FBAB")]
        [InlineData("10111011 11101110 10100101", "MOV", "BX,A5EE")]
        [InlineData("10111011 11110101 11110001", "MOV", "BX,F1F5")]
        [InlineData("10111011 11111010 11010011", "MOV", "BX,D3FA")]
        [InlineData("10111100 00000000 01011100", "MOV", "SP,5C00")]
        [InlineData("10111100 00000001 11011010", "MOV", "SP,DA01")]
        [InlineData("10111100 00111011 00000111", "MOV", "SP,073B")]
        [InlineData("10111100 00111011 10110101", "MOV", "SP,B53B")]
        [InlineData("10111100 00111111 10011000", "MOV", "SP,983F")]
        [InlineData("10111100 01010110 00110111", "MOV", "SP,3756")]
        [InlineData("10111100 01100101 11011111", "MOV", "SP,DF65")]
        [InlineData("10111100 10000100 10000000", "MOV", "SP,8084")]
        [InlineData("10111100 10100100 00101001", "MOV", "SP,29A4")]
        [InlineData("10111100 11001101 01101011", "MOV", "SP,6BCD")]
        [InlineData("10111100 11110001 10010101", "MOV", "SP,95F1")]
        [InlineData("10111100 11111101 10010111", "MOV", "SP,97FD")]
        [InlineData("10111101 00000000 00101010", "MOV", "BP,2A00")]
        [InlineData("10111101 00000001 00111011", "MOV", "BP,3B01")]
        [InlineData("10111101 00011000 10010001", "MOV", "BP,9118")]
        [InlineData("10111101 00011000 10111000", "MOV", "BP,B818")]
        [InlineData("10111101 00011011 01101110", "MOV", "BP,6E1B")]
        [InlineData("10111101 00110111 10101000", "MOV", "BP,A837")]
        [InlineData("10111101 10001110 01100011", "MOV", "BP,638E")]
        [InlineData("10111101 11011010 01010000", "MOV", "BP,50DA")]
        [InlineData("10111101 11101100 10100111", "MOV", "BP,A7EC")]
        [InlineData("10111110 00000000 11010011", "MOV", "SI,D300")]
        [InlineData("10111110 00000001 10110011", "MOV", "SI,B301")]
        [InlineData("10111110 00001001 01010101", "MOV", "SI,5509")]
        [InlineData("10111110 00110100 10101111", "MOV", "SI,AF34")]
        [InlineData("10111110 01101000 10000110", "MOV", "SI,8668")]
        [InlineData("10111110 01101111 00101000", "MOV", "SI,286F")]
        [InlineData("10111110 10011101 01011110", "MOV", "SI,5E9D")]
        [InlineData("10111110 11011010 01100100", "MOV", "SI,64DA")]
        [InlineData("10111110 11101010 00011100", "MOV", "SI,1CEA")]
        [InlineData("10111110 11110111 10100110", "MOV", "SI,A6F7")]
        [InlineData("10111111 00000000 01001110", "MOV", "DI,4E00")]
        [InlineData("10111111 00000000 11100010", "MOV", "DI,E200")]
        [InlineData("10111111 00000001 01000110", "MOV", "DI,4601")]
        [InlineData("10111111 00110001 00110110", "MOV", "DI,3631")]
        [InlineData("10111111 01001001 00100111", "MOV", "DI,2749")]
        [InlineData("10111111 01101100 00110011", "MOV", "DI,336C")]
        [InlineData("10111111 01101101 01000100", "MOV", "DI,446D")]
        [InlineData("10111111 01111001 10101101", "MOV", "DI,AD79")]
        [InlineData("10111111 10000001 01010100", "MOV", "DI,5481")]
        [InlineData("10111111 10000100 00011010", "MOV", "DI,1A84")]
        [InlineData("10111111 10001110 01000111", "MOV", "DI,478E")]
        [InlineData("10111111 11011110 00011111", "MOV", "DI,1FDE")]
        [InlineData("10111111 11011110 10010010", "MOV", "DI,92DE")]
        [InlineData("10111111 11101110 00101110", "MOV", "DI,2EEE")]
        [InlineData("11000110 00000000 10001001", "MOV", "Byte Ptr [BX+SI],89")]
        [InlineData("11000110 00000001 01110100", "MOV", "Byte Ptr [BX+DI],74")]
        [InlineData("11000110 00100100 10100010", "MOV", "Byte Ptr [SI],A2")]
        [InlineData("11000110 11001101 11101100", "MOV", "CH,EC")]
        [InlineData("00100110 10100011 01000101 10110100", "MOV", "ES:[B445],AX")]
        [InlineData("00101110 10100010 11000001 00010011", "MOV", "CS:[13C1],AL")]
        [InlineData("00111110 10100010 01101100 11000101", "MOV", "DS:[C56C],AL")]
        [InlineData("10001000 10010100 00101001 01001110", "MOV", "Byte Ptr [SI+4E29],DL")]
        [InlineData("10001000 10010111 11000111 10111011", "MOV", "Byte Ptr [BX-4439],DL")]
        [InlineData("10001000 10011101 10000010 00011101", "MOV", "Byte Ptr [DI+1D82],BL")]
        [InlineData("10001000 10011110 11001110 11100001", "MOV", "Byte Ptr [BP-1E32],BL")]
        [InlineData("10001000 10011111 01100000 01111000", "MOV", "Byte Ptr [BX+7860],BL")]
        [InlineData("10001000 10011111 10101111 00010010", "MOV", "Byte Ptr [BX+12AF],BL")]
        [InlineData("10001000 10101111 10110100 10000101", "MOV", "Byte Ptr [BX-7A4C],CH")]
        [InlineData("10001001 10000010 10001111 00101100", "MOV", "Word Ptr [BP+SI+2C8F],AX")]
        [InlineData("10001001 10011111 01011110 00100010", "MOV", "Word Ptr [BX+225E],BX")]
        [InlineData("10001001 10101100 10010101 11001011", "MOV", "Word Ptr [SI-346B],BP")]
        [InlineData("10001010 10001010 11001101 01100000", "MOV", "CL,Byte Ptr [BP+SI+60CD]")]
        [InlineData("10001010 10101101 11110011 01100110", "MOV", "CH,Byte Ptr [DI+66F3]")]
        [InlineData("10001011 00100110 00001110 10011101", "MOV", "SP,Word Ptr [9D0E]")]
        [InlineData("10001011 00111110 00101110 11101101", "MOV", "DI,Word Ptr [ED2E]")]
        [InlineData("10001011 00111110 10111101 10011010", "MOV", "DI,Word Ptr [9ABD]")]
        [InlineData("10001011 10011011 00011001 00111111", "MOV", "BX,Word Ptr [BP+DI+3F19]")]
        [InlineData("10001011 10011110 00000101 00000101", "MOV", "BX,Word Ptr [BP+0505]")]
        [InlineData("10001011 10110111 11110000 01011011", "MOV", "SI,Word Ptr [BX+5BF0]")]
        [InlineData("10001100 00100110 01010000 11010111", "MOV", "Word Ptr [D750],ES")]
        [InlineData("10001100 00100110 10111100 10001000", "MOV", "Word Ptr [88BC],ES")]
        [InlineData("10001100 10100001 11110111 11100101", "MOV", "Word Ptr [BX+DI-1A09],ES")]
        [InlineData("10001100 10100011 00111110 00001110", "MOV", "Word Ptr [BP+DI+0E3E],ES")]
        [InlineData("10001110 10011100 00011000 01011110", "MOV", "DS,Word Ptr [SI+5E18]")]
        [InlineData("11000111 00000000 00101101 00111011", "MOV", "Word Ptr [BX+SI],3B2D")]
        [InlineData("11000111 00000001 00100000 11110111", "MOV", "Word Ptr [BX+DI],F720")]
        [InlineData("11000111 00100101 10110110 10100101", "MOV", "Word Ptr [DI],A5B6")]
        [InlineData("11000111 11010010 11011011 01001100", "MOV", "DX,4CDB")]
        [InlineData("11000111 11010111 10101100 00010000", "MOV", "DI,10AC")]
        [InlineData("11000111 11101100 00101000 00000000", "MOV", "SP,0028")]
        [InlineData("11000111 11111010 00101000 00000000", "MOV", "DX,0028")]
        [InlineData("11000110 10011100 00001000 01101001 10111100", "MOV", "Byte Ptr [SI+6908],BC")]
        [InlineData("11000110 10110100 01110110 10110001 01011011", "MOV", "Byte Ptr [SI-4E8A],5B")]
        [InlineData("11000110 10111000 11001101 11111000 10010010", "MOV", "Byte Ptr [BX+SI-0733],92")]
        [InlineData("11000111 01011010 11110101 00001110 01100001", "MOV", "Word Ptr [BP+SI-0B],610E")]
        [InlineData("11000111 01011101 00011001 00000011 01101001", "MOV", "Word Ptr [DI+19],6903")]
        [InlineData("11000111 01100111 01010110 10011101 10101001", "MOV", "Word Ptr [BX+56],A99D")]
        [InlineData("11000111 01100111 10011100 10100010 10000100", "MOV", "Word Ptr [BX-64],84A2")]
        [InlineData("11000111 10010011 11101100 11010101 10100101 01010101", "MOV", "Word Ptr [BP+DI-2A14],55A5")]
        [InlineData("11000111 10100011 01101000 01011100 00110011 11001001", "MOV", "Word Ptr [BP+DI+5C68],C933")]
        [InlineData("11000111 10110000 10100011 10010100 01001001 11000101", "MOV", "Word Ptr [BX+SI-6B5D],C549")]
        [InlineData("11000111 10111001 01111110 11101001 10100100 10101010", "MOV", "Word Ptr [BX+DI-1682],AAA4")]
        public void CheckMov(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Exchange Register/Memory
        /// </summary>
        [Theory]
        [InlineData("10010001", "XCHG", "AX,CX")]
        [InlineData("10010010", "XCHG", "AX,DX")]
        [InlineData("10010011", "XCHG", "AX,BX")]
        [InlineData("10010100", "XCHG", "AX,SP")]
        [InlineData("10010101", "XCHG", "AX,BP")]
        [InlineData("10010110", "XCHG", "AX,SI")]
        [InlineData("10010111", "XCHG", "AX,DI")]
        [InlineData("10000110 00000000", "XCHG", "Byte Ptr [BX+SI],AL")]
        [InlineData("10000110 00000001", "XCHG", "Byte Ptr [BX+DI],AL")]
        [InlineData("10000110 00001101", "XCHG", "Byte Ptr [DI],CL")]
        [InlineData("10000110 11000000", "XCHG", "AL,AL")]
        [InlineData("10000110 11001001", "XCHG", "CL,CL")]
        [InlineData("10000110 11010001", "XCHG", "CL,DL")]
        [InlineData("10000110 11010010", "XCHG", "DL,DL")]
        [InlineData("10000110 11010100", "XCHG", "AH,DL")]
        [InlineData("10000110 11011010", "XCHG", "DL,BL")]
        [InlineData("10000110 11011011", "XCHG", "BL,BL")]
        [InlineData("10000110 11100100", "XCHG", "AH,AH")]
        [InlineData("10000110 11101101", "XCHG", "CH,CH")]
        [InlineData("10000110 11110110", "XCHG", "DH,DH")]
        [InlineData("10000110 11111111", "XCHG", "BH,BH")]
        [InlineData("10000111 00000000", "XCHG", "Word Ptr [BX+SI],AX")]
        [InlineData("10000111 00000001", "XCHG", "Word Ptr [BX+DI],AX")]
        [InlineData("10000111 00110001", "XCHG", "Word Ptr [BX+DI],SI")]
        [InlineData("10000111 00110011", "XCHG", "Word Ptr [BP+DI],SI")]
        [InlineData("10000111 11000010", "XCHG", "DX,AX")]
        [InlineData("10000111 11010111", "XCHG", "DI,DX")]
        [InlineData("10000111 11011011", "XCHG", "BX,BX")]
        [InlineData("10000111 11101001", "XCHG", "CX,BP")]
        [InlineData("10000110 01000010 00011001", "XCHG", "Byte Ptr [BP+SI+19],AL")]
        [InlineData("10000110 01011011 10011101", "XCHG", "Byte Ptr [BP+DI-63],BL")]
        [InlineData("10000110 01111101 10001010", "XCHG", "Byte Ptr [DI-76],BH")]
        [InlineData("10000110 00010110 10101010 01111001", "XCHG", "Byte Ptr [79AA],DL")]
        [InlineData("10000110 10001010 11001001 00100000", "XCHG", "Byte Ptr [BP+SI+20C9],CL")]
        [InlineData("10000111 10000011 00001110 11110011", "XCHG", "Word Ptr [BP+DI-0CF2],AX")]
        [InlineData("10000111 10011011 00110001 01011010", "XCHG", "Word Ptr [BP+DI+5A31],BX")]
        [InlineData("10000111 10100101 00101100 11000101", "XCHG", "Word Ptr [DI-3AD4],SP")]
        [InlineData("10000111 10100101 11001011 00100001", "XCHG", "Word Ptr [DI+21CB],SP")]
        [InlineData("10000111 10111100 00010001 11100110", "XCHG", "Word Ptr [SI-19EF],DI")]
        public void CheckXchg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Table Lookup Translation
        /// </summary>
        [Theory]
        [InlineData("11010111", "XLAT", "")]
        public void CheckXlat(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class NumericTest : AbstractDecodeTest
    {
        /// <summary>
        /// ASCII Adjust After Addition
        /// </summary>
        [Theory]
        [InlineData("00110111", "AAA", "")]
        public void CheckAaa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// </summary>
        [Theory]
        [InlineData("11010101 00001010", "AAD", "")]
        public void CheckAad(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// </summary>
        [Theory]
        [InlineData("11010100 00001010", "AAM", "")]
        public void CheckAam(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// </summary>
        [Theory]
        [InlineData("00111111", "AAS", "")]
        public void CheckAas(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Convert Byte to Word
        /// </summary>
        [Theory]
        [InlineData("10011000", "CBW", "")]
        public void CheckCbw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Convert Word to Doubleword
        /// </summary>
        [Theory]
        [InlineData("10011001", "CWD", "")]
        public void CheckCwd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// </summary>
        [Theory]
        [InlineData("00100111", "DAA", "")]
        public void CheckDaa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// </summary>
        [Theory]
        [InlineData("00101111", "DAS", "")]
        public void CheckDas(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class OtherTest : AbstractDecodeTest
    {
        /// <summary>
        /// Make Stack Frame for Params
        /// </summary>
        [Theory]
        [InlineData("11001000 00000000 00100101 01110110", "ENTER", "2500,76")]
        [InlineData("11001000 00000001 11010001 01010010", "ENTER", "D101,52")]
        [InlineData("11001000 00000101 00111110 00011111", "ENTER", "3E05,1F")]
        [InlineData("11001000 00000110 01100101 00101101", "ENTER", "6506,2D")]
        [InlineData("11001000 00001001 00000000 00000111", "ENTER", "0009,07")]
        [InlineData("11001000 00001001 00000000 00001001", "ENTER", "0009,09")]
        [InlineData("11001000 00010001 11000100 10010000", "ENTER", "C411,90")]
        [InlineData("11001000 00101000 00000000 00000000", "ENTER", "0028,00")]
        [InlineData("11001000 00111111 11101010 01110010", "ENTER", "EA3F,72")]
        [InlineData("11001000 01000001 10110011 01011100", "ENTER", "B341,5C")]
        [InlineData("11001000 01001011 11010100 01110111", "ENTER", "D44B,77")]
        [InlineData("11001000 01001101 01010000 11011011", "ENTER", "504D,DB")]
        [InlineData("11001000 01111100 10101000 00100100", "ENTER", "A87C,24")]
        [InlineData("11001000 10011010 11010100 01011110", "ENTER", "D49A,5E")]
        [InlineData("11001000 10100101 10110000 10001000", "ENTER", "B0A5,88")]
        [InlineData("11001000 10101111 00000010 01101110", "ENTER", "02AF,6E")]
        [InlineData("11001000 11011101 01101000 01110000", "ENTER", "68DD,70")]
        public void CheckEnter(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// High Level Procedure Exit
        /// </summary>
        [Theory]
        [InlineData("11001001", "LEAVE", "")]
        public void CheckLeave(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Assert LOCK Signal Prefix
        /// </summary>
        [Theory]
        [InlineData("11110000", "LOCK", "")]
        public void CheckLock(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// No Operation
        /// </summary>
        [Theory]
        [InlineData("10010000", "NOP", "")]
        public void CheckNop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Wait
        /// </summary>
        [Theory]
        [InlineData("10011011", "WAIT", "")]
        public void CheckWait(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class PortsTest : AbstractDecodeTest
    {
        /// <summary>
        /// Input From Port
        /// </summary>
        [Theory]
        [InlineData("11101100", "IN", "AL,DX")]
        [InlineData("11101101", "IN", "AX,DX")]
        [InlineData("11100100 00000000", "IN", "AL,00")]
        [InlineData("11100100 00000001", "IN", "AL,01")]
        [InlineData("11100100 00010110", "IN", "AL,16")]
        [InlineData("11100100 01010111", "IN", "AL,57")]
        [InlineData("11100100 10101100", "IN", "AL,AC")]
        [InlineData("11100100 10101101", "IN", "AL,AD")]
        [InlineData("11100100 10110001", "IN", "AL,B1")]
        [InlineData("11100100 11011111", "IN", "AL,DF")]
        [InlineData("11100101 00000000", "IN", "AX,00")]
        [InlineData("11100101 00000001", "IN", "AX,01")]
        [InlineData("11100101 00010010", "IN", "AX,12")]
        [InlineData("11100101 00011010", "IN", "AX,1A")]
        [InlineData("11100101 00110000", "IN", "AX,30")]
        [InlineData("11100101 01001000", "IN", "AX,48")]
        [InlineData("11100101 10010110", "IN", "AX,96")]
        [InlineData("11100101 10011001", "IN", "AX,99")]
        [InlineData("11100101 10011110", "IN", "AX,9E")]
        [InlineData("11100101 10011111", "IN", "AX,9F")]
        [InlineData("11100101 10110000", "IN", "AX,B0")]
        [InlineData("11100101 11111111", "IN", "AX,FF")]
        public void CheckIn(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        [Theory]
        [InlineData("01101100", "INSB", "")]
        public void CheckInsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        [Theory]
        [InlineData("01101101", "INSW", "")]
        public void CheckInsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output to Port
        /// </summary>
        [Theory]
        [InlineData("11101110", "OUT", "DX,AL")]
        [InlineData("11101111", "OUT", "DX,AX")]
        [InlineData("11100110 00000000", "OUT", "00,AL")]
        [InlineData("11100110 00000001", "OUT", "01,AL")]
        [InlineData("11100110 00011101", "OUT", "1D,AL")]
        [InlineData("11100110 00110000", "OUT", "30,AL")]
        [InlineData("11100110 10000101", "OUT", "85,AL")]
        [InlineData("11100110 10010110", "OUT", "96,AL")]
        [InlineData("11100110 10111100", "OUT", "BC,AL")]
        [InlineData("11100110 11001111", "OUT", "CF,AL")]
        [InlineData("11100110 11010111", "OUT", "D7,AL")]
        [InlineData("11100111 00000000", "OUT", "00,AX")]
        [InlineData("11100111 00000001", "OUT", "01,AX")]
        [InlineData("11100111 00011110", "OUT", "1E,AX")]
        [InlineData("11100111 01010100", "OUT", "54,AX")]
        [InlineData("11100111 01011111", "OUT", "5F,AX")]
        [InlineData("11100111 01111000", "OUT", "78,AX")]
        [InlineData("11100111 10010011", "OUT", "93,AX")]
        [InlineData("11100111 10011001", "OUT", "99,AX")]
        [InlineData("11100111 11000000", "OUT", "C0,AX")]
        [InlineData("11100111 11000110", "OUT", "C6,AX")]
        [InlineData("11100111 11010000", "OUT", "D0,AX")]
        [InlineData("11100111 11100101", "OUT", "E5,AX")]
        public void CheckOut(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        [Theory]
        [InlineData("01101110", "OUTSB", "")]
        public void CheckOutsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        [Theory]
        [InlineData("01101111", "OUTSW", "")]
        public void CheckOutsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class PrefixTest : AbstractDecodeTest
    {
        /// <summary>
        /// Code Segment Register
        /// </summary>
        [Theory]
        public void CheckCs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Data Segment Register
        /// </summary>
        [Theory]
        public void CheckDs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Extra Segment Register
        /// </summary>
        [Theory]
        public void CheckEs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Stack Segment Register
        /// </summary>
        [Theory]
        public void CheckSs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class ShiftTest : AbstractDecodeTest
    {
        /// <summary>
        /// Rotate Through Carry Left
        /// </summary>
        [Theory]
        [InlineData("11010011 11010111", "RCL", "DI,CL")]
        [InlineData("11000000 11010000 00001000", "RCL", "AL,08")]
        [InlineData("11000000 11010001 00001000", "RCL", "CL,08")]
        [InlineData("11000000 11010010 00001000", "RCL", "DL,08")]
        [InlineData("11000000 11010011 00001000", "RCL", "BL,08")]
        [InlineData("11000000 11010100 00001000", "RCL", "AH,08")]
        [InlineData("11000000 11010100 00001001", "RCL", "AH,09")]
        [InlineData("11000000 11010100 01101101", "RCL", "AH,6D")]
        [InlineData("11000000 11010101 00001000", "RCL", "CH,08")]
        [InlineData("11000000 11010110 00001000", "RCL", "DH,08")]
        [InlineData("11000000 11010111 00001000", "RCL", "BH,08")]
        [InlineData("11000001 11010011 00001001", "RCL", "BX,09")]
        [InlineData("11010011 00010110 00010011 01011011", "RCL", "Word Ptr [5B13],CL")]
        [InlineData("11000001 10010100 11011010 11001010 10110011", "RCL", "Word Ptr [SI-3526],B3")]
        public void CheckRcl(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Rotate Through Carry Right
        /// </summary>
        [Theory]
        [InlineData("11010000 11011111", "RCR", "BH,1")]
        [InlineData("11010001 11011100", "RCR", "SP,1")]
        [InlineData("11010010 00011100", "RCR", "Byte Ptr [SI],CL")]
        [InlineData("11010011 11011101", "RCR", "BP,CL")]
        [InlineData("11000000 11011000 00001000", "RCR", "AL,08")]
        [InlineData("11000000 11011001 00001000", "RCR", "CL,08")]
        [InlineData("11000000 11011010 00001000", "RCR", "DL,08")]
        [InlineData("11000000 11011011 00001000", "RCR", "BL,08")]
        [InlineData("11000000 11011100 00001000", "RCR", "AH,08")]
        [InlineData("11000000 11011100 00001001", "RCR", "AH,09")]
        [InlineData("11000000 11011101 00001000", "RCR", "CH,08")]
        [InlineData("11000000 11011110 00001000", "RCR", "DH,08")]
        [InlineData("11000000 11011111 00001000", "RCR", "BH,08")]
        [InlineData("11000001 11011001 01011011", "RCR", "CX,5B")]
        [InlineData("11000001 11011011 00001001", "RCR", "BX,09")]
        [InlineData("11000000 01011100 00111100 10111011", "RCR", "Byte Ptr [SI+3C],BB")]
        [InlineData("11010001 00011110 11101010 10010001", "RCR", "Word Ptr [91EA],1")]
        [InlineData("11010001 10011011 10111101 01110100", "RCR", "Word Ptr [BP+DI+74BD],1")]
        [InlineData("11010001 10011100 11100000 11111110", "RCR", "Word Ptr [SI-0120],1")]
        public void CheckRcr(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Rotate Left
        /// </summary>
        [Theory]
        [InlineData("11010000 00000000", "ROL", "Byte Ptr [BX+SI],1")]
        [InlineData("11010001 00000000", "ROL", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 00000001", "ROL", "Word Ptr [BX+DI],1")]
        [InlineData("11010010 00000000", "ROL", "Byte Ptr [BX+SI],CL")]
        [InlineData("11010010 00000001", "ROL", "Byte Ptr [BX+DI],CL")]
        [InlineData("11010010 11000000", "ROL", "AL,CL")]
        [InlineData("11010011 00000000", "ROL", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 00000001", "ROL", "Word Ptr [BX+DI],CL")]
        [InlineData("11010011 00000101", "ROL", "Word Ptr [DI],CL")]
        [InlineData("11000000 00000000 01100011", "ROL", "Byte Ptr [BX+SI],63")]
        [InlineData("11000000 00000001 01000101", "ROL", "Byte Ptr [BX+DI],45")]
        [InlineData("11000000 00000011 01101000", "ROL", "Byte Ptr [BP+DI],68")]
        [InlineData("11000000 11000000 00001000", "ROL", "AL,08")]
        [InlineData("11000000 11000001 00001000", "ROL", "CL,08")]
        [InlineData("11000000 11000010 00001000", "ROL", "DL,08")]
        [InlineData("11000000 11000011 00001000", "ROL", "BL,08")]
        [InlineData("11000000 11000100 00001000", "ROL", "AH,08")]
        [InlineData("11000000 11000100 00001001", "ROL", "AH,09")]
        [InlineData("11000000 11000101 00001000", "ROL", "CH,08")]
        [InlineData("11000000 11000110 00001000", "ROL", "DH,08")]
        [InlineData("11000000 11000111 00001000", "ROL", "BH,08")]
        [InlineData("11000001 00000000 10111011", "ROL", "Word Ptr [BX+SI],BB")]
        [InlineData("11000001 00000001 01001111", "ROL", "Word Ptr [BX+DI],4F")]
        [InlineData("11000001 11000011 00001001", "ROL", "BX,09")]
        [InlineData("11010010 01000000 10111100", "ROL", "Byte Ptr [BX+SI-44],CL")]
        [InlineData("11010010 01000010 01111000", "ROL", "Byte Ptr [BP+SI+78],CL")]
        [InlineData("11000001 01000100 10110000 00100011", "ROL", "Word Ptr [SI-50],23")]
        [InlineData("11010001 10000001 01001101 01011001", "ROL", "Word Ptr [BX+DI+594D],1")]
        [InlineData("11000001 00000110 10111110 10101111 00001010", "ROL", "Word Ptr [AFBE],0A")]
        public void CheckRol(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Rotate Right
        /// </summary>
        [Theory]
        [InlineData("11010000 00001010", "ROR", "Byte Ptr [BP+SI],1")]
        [InlineData("11010000 11001011", "ROR", "BL,1")]
        [InlineData("11000000 11001000 00001000", "ROR", "AL,08")]
        [InlineData("11000000 11001001 00001000", "ROR", "CL,08")]
        [InlineData("11000000 11001010 00001000", "ROR", "DL,08")]
        [InlineData("11000000 11001011 00001000", "ROR", "BL,08")]
        [InlineData("11000000 11001100 00001000", "ROR", "AH,08")]
        [InlineData("11000000 11001100 00001001", "ROR", "AH,09")]
        [InlineData("11000000 11001101 00001000", "ROR", "CH,08")]
        [InlineData("11000000 11001110 00001000", "ROR", "DH,08")]
        [InlineData("11000000 11001111 00001000", "ROR", "BH,08")]
        [InlineData("11000001 11001011 00001001", "ROR", "BX,09")]
        [InlineData("11000001 01001000 00100010 10010000", "ROR", "Word Ptr [BX+SI+22],90")]
        [InlineData("11000001 01001000 01011100 11111100", "ROR", "Word Ptr [BX+SI+5C],FC")]
        [InlineData("11010000 10001110 11101111 10010111", "ROR", "Byte Ptr [BP-6811],1")]
        public void CheckRor(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Shift Arithmetic Right
        /// </summary>
        [Theory]
        [InlineData("11010010 00111001", "SAR", "Byte Ptr [BX+DI],CL")]
        [InlineData("11010011 11111001", "SAR", "CX,CL")]
        [InlineData("11000000 11111000 00001000", "SAR", "AL,08")]
        [InlineData("11000000 11111001 00001000", "SAR", "CL,08")]
        [InlineData("11000000 11111010 00001000", "SAR", "DL,08")]
        [InlineData("11000000 11111011 00001000", "SAR", "BL,08")]
        [InlineData("11000000 11111100 00001000", "SAR", "AH,08")]
        [InlineData("11000000 11111100 00001001", "SAR", "AH,09")]
        [InlineData("11000000 11111101 00001000", "SAR", "CH,08")]
        [InlineData("11000000 11111110 00001000", "SAR", "DH,08")]
        [InlineData("11000000 11111111 00001000", "SAR", "BH,08")]
        [InlineData("11000001 11111011 00001001", "SAR", "BX,09")]
        [InlineData("00110110 11010010 01111001 10111001", "SAR", "Byte Ptr SS:[BX+DI-47],CL")]
        [InlineData("11010001 10111011 01011010 10110000", "SAR", "Word Ptr [BP+DI-4FA6],1")]
        public void CheckSar(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Shift Logical Left
        /// </summary>
        [Theory]
        [InlineData("11000000 11100000 00001000", "SHL", "AL,08")]
        [InlineData("11000000 11100001 00001000", "SHL", "CL,08")]
        [InlineData("11000000 11100010 00001000", "SHL", "DL,08")]
        [InlineData("11000000 11100011 00001000", "SHL", "BL,08")]
        [InlineData("11000000 11100100 00001000", "SHL", "AH,08")]
        [InlineData("11000000 11100100 00001001", "SHL", "AH,09")]
        [InlineData("11000000 11100101 00001000", "SHL", "CH,08")]
        [InlineData("11000000 11100110 00001000", "SHL", "DH,08")]
        [InlineData("11000000 11100111 00001000", "SHL", "BH,08")]
        [InlineData("11000000 11100111 00101101", "SHL", "BH,2D")]
        [InlineData("11000001 11100011 00001001", "SHL", "BX,09")]
        [InlineData("11010010 01100110 11101111", "SHL", "Byte Ptr [BP-11],CL")]
        [InlineData("11000000 10100000 01000111 10101110 10001001", "SHL", "Byte Ptr [BX+SI-51B9],89")]
        public void CheckShl(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Shift Logical Right
        /// </summary>
        [Theory]
        [InlineData("11010010 11101101", "SHR", "CH,CL")]
        [InlineData("11010011 00101000", "SHR", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 00101010", "SHR", "Word Ptr [BP+SI],CL")]
        [InlineData("11000000 00101001 00101001", "SHR", "Byte Ptr [BX+DI],29")]
        [InlineData("11000000 11101000 00001000", "SHR", "AL,08")]
        [InlineData("11000000 11101000 11111100", "SHR", "AL,FC")]
        [InlineData("11000000 11101001 00001000", "SHR", "CL,08")]
        [InlineData("11000000 11101010 00001000", "SHR", "DL,08")]
        [InlineData("11000000 11101011 00001000", "SHR", "BL,08")]
        [InlineData("11000000 11101100 00001000", "SHR", "AH,08")]
        [InlineData("11000000 11101100 00001001", "SHR", "AH,09")]
        [InlineData("11000000 11101101 00001000", "SHR", "CH,08")]
        [InlineData("11000000 11101110 00001000", "SHR", "DH,08")]
        [InlineData("11000000 11101111 00001000", "SHR", "BH,08")]
        [InlineData("11000001 00101100 10001110", "SHR", "Word Ptr [SI],8E")]
        [InlineData("11000001 00101111 01100010", "SHR", "Word Ptr [BX],62")]
        [InlineData("11000001 11101011 00001001", "SHR", "BX,09")]
        [InlineData("11010001 01101011 00101111", "SHR", "Word Ptr [BP+DI+2F],1")]
        [InlineData("11000001 01101100 11010110 01000010", "SHR", "Word Ptr [SI-2A],42")]
        [InlineData("11010011 10101000 10100101 11111111", "SHR", "Word Ptr [BX+SI-005B],CL")]
        public void CheckShr(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class StackTest : AbstractDecodeTest
    {
        /// <summary>
        /// Pop Value From the Stack
        /// </summary>
        [Theory]
        [InlineData("00000111", "POP", "ES")]
        [InlineData("00010111", "POP", "SS")]
        [InlineData("00011111", "POP", "DS")]
        [InlineData("01011000", "POP", "AX")]
        [InlineData("01011001", "POP", "CX")]
        [InlineData("01011010", "POP", "DX")]
        [InlineData("01011011", "POP", "BX")]
        [InlineData("01011100", "POP", "SP")]
        [InlineData("01011101", "POP", "BP")]
        [InlineData("01011110", "POP", "SI")]
        [InlineData("01011111", "POP", "DI")]
        [InlineData("10001111 00000000", "POP", "Word Ptr [BX+SI]")]
        [InlineData("10001111 00000001", "POP", "Word Ptr [BX+DI]")]
        [InlineData("10001111 00001011", "POP", "Word Ptr [BP+DI]")]
        [InlineData("10001111 00110010", "POP", "Word Ptr [BP+SI]")]
        [InlineData("10001111 00111000", "POP", "Word Ptr [BX+SI]")]
        [InlineData("10001111 11000110", "POP", "SI")]
        [InlineData("10001111 11001100", "POP", "SP")]
        [InlineData("10001111 01011001 11101000", "POP", "Word Ptr [BX+DI-18]")]
        [InlineData("10001111 01110001 10001000", "POP", "Word Ptr [BX+DI-78]")]
        [InlineData("10001111 01110011 01001011", "POP", "Word Ptr [BP+DI+4B]")]
        [InlineData("10001111 10010000 01100100 10001100", "POP", "Word Ptr [BX+SI-739C]")]
        [InlineData("00101110 10001111 00011110 11010001 00001011", "POP", "Word Ptr CS:[0BD1]")]
        public void CheckPop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Pop All General Registers
        /// </summary>
        [Theory]
        [InlineData("01100001", "POPA", "")]
        public void CheckPopa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// </summary>
        [Theory]
        [InlineData("10011101", "POPF", "")]
        public void CheckPopf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push Word Onto the Stack
        /// </summary>
        [Theory]
        [InlineData("00000110", "PUSH", "ES")]
        [InlineData("00001110", "PUSH", "CS")]
        [InlineData("00010110", "PUSH", "SS")]
        [InlineData("00011110", "PUSH", "DS")]
        [InlineData("01010000", "PUSH", "AX")]
        [InlineData("01010001", "PUSH", "CX")]
        [InlineData("01010010", "PUSH", "DX")]
        [InlineData("01010011", "PUSH", "BX")]
        [InlineData("01010100", "PUSH", "SP")]
        [InlineData("01010101", "PUSH", "BP")]
        [InlineData("01010110", "PUSH", "SI")]
        [InlineData("01010111", "PUSH", "DI")]
        [InlineData("01101010 00000000", "PUSH", "00")]
        [InlineData("01101010 00000001", "PUSH", "01")]
        [InlineData("01101010 00000110", "PUSH", "06")]
        [InlineData("01101010 00001001", "PUSH", "09")]
        [InlineData("01101010 00110101", "PUSH", "35")]
        [InlineData("01101010 01001001", "PUSH", "49")]
        [InlineData("01101010 10011111", "PUSH", "9F")]
        [InlineData("01101010 10111101", "PUSH", "BD")]
        [InlineData("01101010 11100111", "PUSH", "E7")]
        [InlineData("01101010 11111011", "PUSH", "FB")]
        [InlineData("11111111 00110010", "PUSH", "[BP+SI]")]
        [InlineData("01101000 00000000 01110101", "PUSH", "7500")]
        [InlineData("01101000 00000001 01111010", "PUSH", "7A01")]
        [InlineData("01101000 00011000 01011010", "PUSH", "5A18")]
        [InlineData("01101000 01010000 00000100", "PUSH", "0450")]
        [InlineData("01101000 01101101 00010100", "PUSH", "146D")]
        [InlineData("01101000 01111110 01100001", "PUSH", "617E")]
        [InlineData("01101000 10000000 10010111", "PUSH", "9780")]
        [InlineData("01101000 10101010 00011000", "PUSH", "18AA")]
        public void CheckPush(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push All General Registers
        /// </summary>
        [Theory]
        [InlineData("01100000", "PUSHA", "")]
        public void CheckPusha(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// </summary>
        [Theory]
        [InlineData("10011100", "PUSHF", "")]
        public void CheckPushf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
    
    public class StringTest : AbstractDecodeTest
    {
        /// <summary>
        /// Compare String Operands
        /// </summary>
        [Theory]
        [InlineData("10100110", "CMPSB", "")]
        public void CheckCmpsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Compare String Operands
        /// </summary>
        [Theory]
        [InlineData("10100111", "CMPSW", "")]
        public void CheckCmpsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        [Theory]
        [InlineData("10101100", "LODSB", "")]
        [InlineData("00111110 10101100", "LODSB", "DS:")]
        public void CheckLodsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        [Theory]
        [InlineData("10101101", "LODSW", "")]
        public void CheckLodsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        [Theory]
        [InlineData("10100100", "MOVSB", "")]
        public void CheckMovsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        [Theory]
        [InlineData("10100101", "MOVSW", "")]
        public void CheckMovsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        [Theory]
        public void CheckRep(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        [Theory]
        [InlineData("11110011", "REPE", "")]
        public void CheckRepe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        [Theory]
        [InlineData("11110010", "REPNE", "")]
        public void CheckRepne(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        [Theory]
        [InlineData("10101110", "SCASB", "")]
        public void CheckScasb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        [Theory]
        [InlineData("10101111", "SCASW", "")]
        public void CheckScasw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        [Theory]
        [InlineData("10101010", "STOSB", "")]
        public void CheckStosb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        [Theory]
        [InlineData("10101011", "STOSW", "")]
        public void CheckStosw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
