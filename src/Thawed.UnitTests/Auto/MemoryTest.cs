using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class MemoryTest : AbstractDecodeTest
    {
        #region [LDS, MOV] Load Far Pointer
        [Theory]
        [InlineData("11000101 11000101", "LDS", "AX,DBP")]
        public void CheckLdsV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11000101 00000000", "LDS", "AX,DWord Ptr [BX+SI]")]
        [InlineData("11000101 00101100", "LDS", "BP,DWord Ptr [SI]")]
        [InlineData("00111110 11000101 00010001", "LDS", "DX,DWord Ptr DS:[BX+DI]")]
        [InlineData("11000101 01000000 00010001", "LDS", "AX,DWord Ptr [BX+SI+11]")]
        [InlineData("11000101 00000110 00010001 00000000", "LDS", "AX,DWord Ptr [0011]")]
        [InlineData("11000101 10000000 00010001 00000000", "LDS", "AX,DWord Ptr [BX+SI+0011]")]
        public void CheckLdsV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LEA, LDEA] Load Effective Address
        [Theory]
        [InlineData("10001101 11000101", "LEA", "AX,BP")]
        public void CheckLeaV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10001101 00000000", "LEA", "AX,[BX+SI]")]
        [InlineData("10001101 00000111", "LEA", "AX,[BX]")]
        [InlineData("00100110 10001101 00010001", "LEA", "DX,ES:[BX+DI]")]
        [InlineData("10001101 01000000 01000010", "LEA", "AX,[BX+SI+42]")]
        [InlineData("10001101 00000110 00010001 00000000", "LEA", "AX,[0011]")]
        [InlineData("10001101 10001011 11110100 01110000", "LEA", "CX,[BP+DI+70F4]")]
        public void CheckLeaV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LES, MOV] Load Far Pointer
        [Theory]
        [InlineData("11000100 11000010", "LES", "AX,DDX")]
        public void CheckLesV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11000100 00000000", "LES", "AX,DWord Ptr [BX+SI]")]
        [InlineData("11000100 00000111", "LES", "AX,DWord Ptr [BX]")]
        [InlineData("00111110 11000100 00010001", "LES", "DX,DWord Ptr DS:[BX+DI]")]
        [InlineData("11000100 01000001 00010111", "LES", "AX,DWord Ptr [BX+DI+17]")]
        [InlineData("11000100 00000110 00010001 00000000", "LES", "AX,DWord Ptr [0011]")]
        [InlineData("11000100 10000001 10100111 10100111", "LES", "AX,DWord Ptr [BX+DI-5859]")]
        public void CheckLesV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [MOV] Move
        [Theory]
        [InlineData("10001100 00111001", "MOV", "Word Ptr [BX+DI],DS")]
        public void CheckMovV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10100000 00000000 00110110", "MOV", "AL,[3600]")]
        [InlineData("10100000 00000110 11100111", "MOV", "AL,[E706]")]
        [InlineData("00100110 10100000 00010001 00000000", "MOV", "AL,ES:[0011]")]
        [InlineData("00110110 10100000 01100100 01011011", "MOV", "AL,SS:[5B64]")]
        public void CheckMovV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10100001 00000000 10110110", "MOV", "AX,[B600]")]
        [InlineData("10100001 11011011 00000001", "MOV", "AX,[01DB]")]
        [InlineData("00100110 10100001 00010001 00000000", "MOV", "AX,ES:[0011]")]
        [InlineData("00101110 10100001 10111111 01110111", "MOV", "AX,CS:[77BF]")]
        public void CheckMovV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10100011 00000000 01001010", "MOV", "[4A00],AX")]
        [InlineData("10100011 01111111 11000110", "MOV", "[C67F],AX")]
        [InlineData("00100110 10100011 00010001 00000000", "MOV", "ES:[0011],AX")]
        [InlineData("00100110 10100011 01000101 10110100", "MOV", "ES:[B445],AX")]
        public void CheckMovV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10100010 00000001 11001000", "MOV", "[C801],AL")]
        [InlineData("10100010 00101110 00000110", "MOV", "[062E],AL")]
        [InlineData("00100110 10100010 00010001 00000000", "MOV", "ES:[0011],AL")]
        [InlineData("00111110 10100010 01101100 11000101", "MOV", "DS:[C56C],AL")]
        public void CheckMovV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10111000 00001011 11100100", "MOV", "AX,E40B")]
        [InlineData("10111011 00001001 00000000", "MOV", "BX,0009")]
        public void CheckMovV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10001011 00000000", "MOV", "AX,Word Ptr [BX+SI]")]
        [InlineData("10001011 11010011", "MOV", "DX,BX")]
        [InlineData("00111110 10001011 00010001", "MOV", "DX,Word Ptr DS:[BX+DI]")]
        [InlineData("10001011 01101011 10011101", "MOV", "BP,Word Ptr [BP+DI-63]")]
        [InlineData("00101110 10001011 01101011 01100011", "MOV", "BP,Word Ptr CS:[BP+DI+63]")]
        [InlineData("10001011 00000110 00010001 00000000", "MOV", "AX,Word Ptr [0011]")]
        public void CheckMovV7(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10110000 00000000", "MOV", "AL,00")]
        [InlineData("10110000 11100110", "MOV", "AL,E6")]
        public void CheckMovV8(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10001010 00000000", "MOV", "AL,Byte Ptr [BX+SI]")]
        [InlineData("10001010 11010111", "MOV", "DL,BH")]
        [InlineData("00111110 10001010 00010001", "MOV", "DL,Byte Ptr DS:[BX+DI]")]
        [InlineData("10001010 01111010 11001110", "MOV", "BH,Byte Ptr [BP+SI-32]")]
        [InlineData("10001010 00000110 00010001 00000000", "MOV", "AL,Byte Ptr [0011]")]
        [InlineData("10001010 10001010 11001101 01100000", "MOV", "CL,Byte Ptr [BP+SI+60CD]")]
        public void CheckMovV9(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11000111 00000001 00100000 11110111", "MOV", "Word Ptr [BX+DI],F720")]
        [InlineData("11000111 11000000 00010001 00000000", "MOV", "AX,0011")]
        [InlineData("11000111 01000000 00010001 00000000 11001000", "MOV", "Word Ptr [BX+SI+11],C800")]
        [InlineData("11000111 01000100 00010001 00000000 11001000", "MOV", "Word Ptr [SI+11],C800")]
        [InlineData("11000111 00000110 00010001 00000000 11001000 00000000", "MOV", "Word Ptr [0011],00C8")]
        [InlineData("11000111 10000000 00010001 00000000 11001000 00000000", "MOV", "Word Ptr [BX+SI+0011],00C8")]
        [InlineData("00111110 11000111 10000000 00011001 10000011 01110100 11101101", "MOV", "Word Ptr DS:[BX+SI-7CE7],ED74")]
        public void CheckMovV10(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10001001 00000000", "MOV", "Word Ptr [BX+SI],AX")]
        [InlineData("10001001 11011011", "MOV", "BX,BX")]
        [InlineData("00111110 10001001 00010001", "MOV", "Word Ptr DS:[BX+DI],DX")]
        [InlineData("10001001 01001010 00011001", "MOV", "Word Ptr [BP+SI+19],CX")]
        [InlineData("10001001 00000110 00010001 00000000", "MOV", "Word Ptr [0011],AX")]
        [InlineData("10001001 10000010 10001111 00101100", "MOV", "Word Ptr [BP+SI+2C8F],AX")]
        public void CheckMovV11(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10001100 00000000", "MOV", "Word Ptr [BX+SI],ES")]
        [InlineData("10001100 11000101", "MOV", "BP,ES")]
        [InlineData("00111110 10001100 00010001", "MOV", "Word Ptr DS:[BX+DI],SS")]
        [InlineData("10001100 01000000 00010001", "MOV", "Word Ptr [BX+SI+11],ES")]
        [InlineData("10001100 00000110 00010001 00000000", "MOV", "Word Ptr [0011],ES")]
        [InlineData("10001100 10100001 11110111 11100101", "MOV", "Word Ptr [BX+DI-1A09],ES")]
        public void CheckMovV12(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11000110 00000000 10001001", "MOV", "Byte Ptr [BX+SI],89")]
        [InlineData("11000110 11000000 00010001", "MOV", "AL,11")]
        [InlineData("11000110 01000000 00010001 00000000", "MOV", "Byte Ptr [BX+SI+11],00")]
        [InlineData("11000110 01000100 00010001 00000000", "MOV", "Byte Ptr [SI+11],00")]
        [InlineData("11000110 00000110 00010001 00000000 11001000", "MOV", "Byte Ptr [0011],C8")]
        [InlineData("11000110 10000000 00010001 00000000 11001000", "MOV", "Byte Ptr [BX+SI+0011],C8")]
        [InlineData("00100110 11000110 00000110 00110010 01110100 10110000", "MOV", "Byte Ptr ES:[7432],B0")]
        public void CheckMovV13(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10001000 00000000", "MOV", "Byte Ptr [BX+SI],AL")]
        [InlineData("10001000 11001110", "MOV", "DH,CL")]
        [InlineData("00111110 10001000 00010001", "MOV", "Byte Ptr DS:[BX+DI],DL")]
        [InlineData("10001000 01111010 01100010", "MOV", "Byte Ptr [BP+SI+62],BH")]
        [InlineData("10001000 00000110 00010001 00000000", "MOV", "Byte Ptr [0011],AL")]
        [InlineData("10001000 10000000 00010001 00000000", "MOV", "Byte Ptr [BX+SI+0011],AL")]
        public void CheckMovV14(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10001110 00000000", "MOV", "ES,Word Ptr [BX+SI]")]
        [InlineData("10001110 11011011", "MOV", "DS,BX")]
        [InlineData("00111110 10001110 00010001", "MOV", "SS,Word Ptr DS:[BX+DI]")]
        [InlineData("10001110 01000000 00010001", "MOV", "ES,Word Ptr [BX+SI+11]")]
        [InlineData("10001110 00000110 00010001 00000000", "MOV", "ES,Word Ptr [0011]")]
        [InlineData("10001110 10000000 00010001 00000000", "MOV", "ES,Word Ptr [BX+SI+0011]")]
        public void CheckMovV15(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11000110 11111000 00010001", "MOV", "AL,11")]
        public void CheckMovV16(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11000111 11111000 00010001 00000000", "MOV", "AX,0011")]
        public void CheckMovV17(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [XCHG, XCH] Exchange Register/Memory
        [Theory]
        [InlineData("10010001", "XCHG", "AX,CX")]
        public void CheckXchgV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10000111 00000000", "XCHG", "Word Ptr [BX+SI],AX")]
        [InlineData("10000111 11000010", "XCHG", "DX,AX")]
        [InlineData("00111110 10000111 00010001", "XCHG", "Word Ptr DS:[BX+DI],DX")]
        [InlineData("10000111 01000000 00010001", "XCHG", "Word Ptr [BX+SI+11],AX")]
        [InlineData("10000111 00000110 00010001 00000000", "XCHG", "Word Ptr [0011],AX")]
        [InlineData("10000111 10000011 00001110 11110011", "XCHG", "Word Ptr [BP+DI-0CF2],AX")]
        public void CheckXchgV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("10000110 00000000", "XCHG", "Byte Ptr [BX+SI],AL")]
        [InlineData("10000110 11010001", "XCHG", "CL,DL")]
        [InlineData("00111110 10000110 00010001", "XCHG", "Byte Ptr DS:[BX+DI],DL")]
        [InlineData("10000110 01000010 00011001", "XCHG", "Byte Ptr [BP+SI+19],AL")]
        [InlineData("10000110 00000110 00010001 00000000", "XCHG", "Byte Ptr [0011],AL")]
        [InlineData("10000110 10001010 11001001 00100000", "XCHG", "Byte Ptr [BP+SI+20C9],CL")]
        public void CheckXchgV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [XLAT, TRANS] Table Lookup Translation
        [Theory]
        [InlineData("11010111", "XLAT", "")]
        public void CheckXlatV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
