using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class BitwiseTest : AbstractDecodeTest
    {
        #region [AND] Logical AND
        [Theory(Skip = "Too complicated!")]
        [InlineData("00100100 00000000", "AND", "AL,00")]
        // [InlineData("00100100 10101100", "AND", "AL,AC")]
        public void CheckAndV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00100101 00000000 11100011", "AND", "AX,E300")]
        // [InlineData("00100101 10111001 00000110", "AND", "AX,06B9")]
        public void CheckAndV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00100011 00000000", "AND", "AX,Word Ptr [BX+SI]")]
        [InlineData("00100011 11000000", "AND", "AX,AX")]
        // [InlineData("00100011 01000010 01010010", "AND", "AX,Word Ptr [BP+SI+52]")]
        // [InlineData("00111110 00100011 00010001", "AND", "DX,Word Ptr DS:[BX+DI]")]
        // [InlineData("00100011 00000110 00010001 00000000", "AND", "AX,Word Ptr [0011]")]
        // [InlineData("00100011 10011001 01111101 10001100", "AND", "BX,Word Ptr [BX+DI-7383]")]
        public void CheckAndV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00100010 00000000", "AND", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00100010 11000100", "AND", "AL,AH")]
        // [InlineData("00100010 01100010 10001011", "AND", "AH,Byte Ptr [BP+SI-75]")]
        // [InlineData("00111110 00100010 00010001", "AND", "DL,Byte Ptr DS:[BX+DI]")]
        // [InlineData("00100010 00000110 00010001 00000000", "AND", "AL,Byte Ptr [0011]")]
        // [InlineData("00100010 10001001 01100010 10010001", "AND", "CL,Byte Ptr [BX+DI-6E9E]")]
        public void CheckAndV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000001 00100000 00010001 00000000", "AND", "Word Ptr [BX+SI],0011")]
        [InlineData("10000001 11100000 00010001 00000000", "AND", "AX,0011")]
        // [InlineData("00111110 10000001 00100000 01101100 10001110", "AND", "Word Ptr DS:[BX+SI],8E6C")]
        // [InlineData("10000001 01100000 00010001 00000000 11001000", "AND", "Word Ptr [BX+SI+11],C800")]
        // [InlineData("10000001 00100110 00010001 00000000 11001000 00000000", "AND", "Word Ptr [0011],00C8")]
        // [InlineData("10000001 10100000 00010001 00000000 11001000 00000000", "AND", "Word Ptr [BX+SI+0011],00C8")]
        public void CheckAndV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000011 00100000 00010001", "AND", "Word Ptr [BX+SI],+11")]
        [InlineData("10000011 11100011 00001001", "AND", "BX,+09")]
        // [InlineData("10000011 01100000 00010001 00000000", "AND", "Word Ptr [BX+SI+11],+00")]
        // [InlineData("10000011 01100100 00010001 00000000", "AND", "Word Ptr [SI+11],+00")]
        // [InlineData("10000011 00100110 00010001 00000000 11001000", "AND", "Word Ptr [0011],-38")]
        // [InlineData("10000011 10100000 00010001 00000000 11001000", "AND", "Word Ptr [BX+SI+0011],-38")]
        public void CheckAndV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00100001 00000000", "AND", "Word Ptr [BX+SI],AX")]
        [InlineData("00100001 11011011", "AND", "BX,BX")]
        // [InlineData("00100001 01100010 10101000", "AND", "Word Ptr [BP+SI-58],SP")]
        // [InlineData("00111110 00100001 00010001", "AND", "Word Ptr DS:[BX+DI],DX")]
        // [InlineData("00100001 00000110 00010001 00000000", "AND", "Word Ptr [0011],AX")]
        // [InlineData("00100001 10100000 00100111 01100010", "AND", "Word Ptr [BX+SI+6227],SP")]
        public void CheckAndV7(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000010 00100011 10100010", "AND", "Byte Ptr [BP+DI],A2")]
        [InlineData("10000010 11100000 00010001", "AND", "AL,11")]
        // [InlineData("10000010 01100000 00010001 00000000", "AND", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("10000010 01100100 00010001 00000000", "AND", "Byte Ptr [SI+11],00")]
        // [InlineData("10000010 00100110 00010001 00000000 11001000", "AND", "Byte Ptr [0011],C8")]
        // [InlineData("10000010 10100000 00010001 00000000 11001000", "AND", "Byte Ptr [BX+SI+0011],C8")]
        // [InlineData("00111110 10000010 10100111 11011000 11011010 10011000", "AND", "Byte Ptr DS:[BX-2528],98")]
        public void CheckAndV8(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000000 00100000 00010001", "AND", "Byte Ptr [BX+SI],11")]
        [InlineData("10000000 11100100 00001001", "AND", "AH,09")]
        // [InlineData("10000000 01100000 00010001 00000000", "AND", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("10000000 01100100 00010001 00000000", "AND", "Byte Ptr [SI+11],00")]
        // [InlineData("10000000 00100110 00010001 00000000 11001000", "AND", "Byte Ptr [0011],C8")]
        // [InlineData("10000000 10100010 11011100 00011011 00001111", "AND", "Byte Ptr [BP+SI+1BDC],0F")]
        public void CheckAndV9(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00100000 00000001", "AND", "Byte Ptr [BX+DI],AL")]
        [InlineData("00100000 11010001", "AND", "CL,DL")]
        // [InlineData("00100000 01001010 01111110", "AND", "Byte Ptr [BP+SI+7E],CL")]
        // [InlineData("00111110 00100000 00010001", "AND", "Byte Ptr DS:[BX+DI],DL")]
        // [InlineData("00100000 00000110 00010001 00000000", "AND", "Byte Ptr [0011],AL")]
        // [InlineData("00100000 00000110 10011111 10100001", "AND", "Byte Ptr [A19F],AL")]
        public void CheckAndV10(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [NOT] One's Complement Negation
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11110111 00010000", "NOT", "Word Ptr [BX+SI]")]
        [InlineData("11110111 11010011", "NOT", "BX")]
        // [InlineData("00111110 11110111 00010001", "NOT", "Word Ptr DS:[BX+DI]")]
        // [InlineData("11110111 01010000 00010001", "NOT", "Word Ptr [BX+SI+11]")]
        // [InlineData("11110111 00010110 00010001 00000000", "NOT", "Word Ptr [0011]")]
        // [InlineData("11110111 10010000 00010001 00000000", "NOT", "Word Ptr [BX+SI+0011]")]
        public void CheckNotV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11110110 00010000", "NOT", "Byte Ptr [BX+SI]")]
        [InlineData("11110110 11010100", "NOT", "AH")]
        // [InlineData("00111110 11110110 00010001", "NOT", "Byte Ptr DS:[BX+DI]")]
        // [InlineData("11110110 01010000 00010001", "NOT", "Byte Ptr [BX+SI+11]")]
        // [InlineData("11110110 00010110 00010001 00000000", "NOT", "Byte Ptr [0011]")]
        // [InlineData("11110110 10010000 00010001 00000000", "NOT", "Byte Ptr [BX+SI+0011]")]
        public void CheckNotV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [OR] Logical Inclusive OR
        [Theory(Skip = "Too complicated!")]
        [InlineData("00001100 00000000", "OR", "AL,00")]
        // [InlineData("00001100 10101000", "OR", "AL,A8")]
        public void CheckOrV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00001101 00000001 10110010", "OR", "AX,B201")]
        // [InlineData("00001101 10010111 00000010", "OR", "AX,0297")]
        public void CheckOrV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00001011 00000000", "OR", "AX,Word Ptr [BX+SI]")]
        [InlineData("00001011 11001001", "OR", "CX,CX")]
        // [InlineData("00001011 01000011 00011001", "OR", "AX,Word Ptr [BP+DI+19]")]
        // [InlineData("00111110 00001011 00010001", "OR", "DX,Word Ptr DS:[BX+DI]")]
        // [InlineData("00001011 00000110 00010001 00000000", "OR", "AX,Word Ptr [0011]")]
        // [InlineData("00001011 10000000 00010001 00000000", "OR", "AX,Word Ptr [BX+SI+0011]")]
        // [InlineData("00110110 00001011 10011011 01000000 00011110", "OR", "BX,Word Ptr SS:[BP+DI+1E40]")]
        public void CheckOrV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00001010 00000000", "OR", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00001010 11011101", "OR", "BL,CH")]
        // [InlineData("00001010 01010000 11101000", "OR", "DL,Byte Ptr [BX+SI-18]")]
        // [InlineData("00111110 00001010 00010001", "OR", "DL,Byte Ptr DS:[BX+DI]")]
        // [InlineData("00001010 00000110 00010001 00000000", "OR", "AL,Byte Ptr [0011]")]
        // [InlineData("00001010 10100001 01011000 11001101", "OR", "AH,Byte Ptr [BX+DI-32A8]")]
        public void CheckOrV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000001 00001000 00010001 00000000", "OR", "Word Ptr [BX+SI],0011")]
        [InlineData("10000001 11001000 00010001 00000000", "OR", "AX,0011")]
        // [InlineData("10000001 01001000 00010001 00000000 11001000", "OR", "Word Ptr [BX+SI+11],C800")]
        // [InlineData("10000001 01001100 00010001 00000000 11001000", "OR", "Word Ptr [SI+11],C800")]
        // [InlineData("10000001 00001110 00010001 00000000 11001000 00000000", "OR", "Word Ptr [0011],00C8")]
        // [InlineData("10000001 10001101 10100010 01011010 00110100 10101001", "OR", "Word Ptr [DI+5AA2],A934")]
        public void CheckOrV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000011 00001000 00010001", "OR", "Word Ptr [BX+SI],+11")]
        [InlineData("10000011 11001011 00001001", "OR", "BX,+09")]
        // [InlineData("10000011 01001000 00010001 00000000", "OR", "Word Ptr [BX+SI+11],+00")]
        // [InlineData("10000011 01001100 00010001 00000000", "OR", "Word Ptr [SI+11],+00")]
        // [InlineData("10000011 00001110 00010001 00000000 11001000", "OR", "Word Ptr [0011],-38")]
        // [InlineData("10000011 10001000 00010001 00000000 11001000", "OR", "Word Ptr [BX+SI+0011],-38")]
        public void CheckOrV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00001001 00000000", "OR", "Word Ptr [BX+SI],AX")]
        [InlineData("00001001 11011011", "OR", "BX,BX")]
        // [InlineData("00001001 01011010 01111000", "OR", "Word Ptr [BP+SI+78],BX")]
        // [InlineData("00111110 00001001 00010001", "OR", "Word Ptr DS:[BX+DI],DX")]
        // [InlineData("00001001 00000110 00010001 00000000", "OR", "Word Ptr [0011],AX")]
        // [InlineData("00001001 10000000 00010001 00000000", "OR", "Word Ptr [BX+SI+0011],AX")]
        // [InlineData("00100110 00001001 10010000 11100001 11100111", "OR", "Word Ptr ES:[BX+SI-181F],DX")]
        public void CheckOrV7(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000010 00001000 00010001", "OR", "Byte Ptr [BX+SI],11")]
        [InlineData("10000010 11001000 00010001", "OR", "AL,11")]
        // [InlineData("10000010 01001000 00010001 00000000", "OR", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("10000010 01001100 00010001 00000000", "OR", "Byte Ptr [SI+11],00")]
        // [InlineData("10000010 00001110 00010001 00000000 11001000", "OR", "Byte Ptr [0011],C8")]
        // [InlineData("10000010 10001000 00010001 00000000 11001000", "OR", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckOrV8(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000000 00001000 00010001", "OR", "Byte Ptr [BX+SI],11")]
        [InlineData("10000000 11001100 00001001", "OR", "AH,09")]
        // [InlineData("10000000 01001000 00010001 00000000", "OR", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("10000000 01001100 00010001 00000000", "OR", "Byte Ptr [SI+11],00")]
        // [InlineData("10000000 00001110 00010001 00000000 11001000", "OR", "Byte Ptr [0011],C8")]
        // [InlineData("10000000 10001000 00010001 00000000 11001000", "OR", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckOrV9(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00001000 00000000", "OR", "Byte Ptr [BX+SI],AL")]
        [InlineData("00001000 11010101", "OR", "CH,DL")]
        // [InlineData("00001000 01000000 00010001", "OR", "Byte Ptr [BX+SI+11],AL")]
        // [InlineData("00111110 00001000 00010001", "OR", "Byte Ptr DS:[BX+DI],DL")]
        // [InlineData("00001000 00000110 00010001 00000000", "OR", "Byte Ptr [0011],AL")]
        // [InlineData("00001000 10000010 00110010 11110101", "OR", "Byte Ptr [BP+SI-0ACE],AL")]
        public void CheckOrV10(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [TEST] Logical Compare
        [Theory(Skip = "Too complicated!")]
        [InlineData("10101000 00000000", "TEST", "AL,00")]
        // [InlineData("10101000 11001100", "TEST", "AL,CC")]
        public void CheckTestV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("10101001 00000000 10110100", "TEST", "AX,B400")]
        // [InlineData("10101001 00000001 10011111", "TEST", "AX,9F01")]
        public void CheckTestV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11110111 00000000 11100111 10011111", "TEST", "Word Ptr [BX+SI],9FE7")]
        [InlineData("11110111 11000011 00001001 00000000", "TEST", "BX,0009")]
        // [InlineData("11110111 01000001 01010100 00011110 10111001", "TEST", "Word Ptr [BX+DI+54],B91E")]
        // [InlineData("11110111 01000100 00010001 00000000 11001000", "TEST", "Word Ptr [SI+11],C800")]
        // [InlineData("11110111 00000110 00010001 00000000 11001000 00000000", "TEST", "Word Ptr [0011],00C8")]
        // [InlineData("11110111 10000000 00010001 00000000 11001000 00000000", "TEST", "Word Ptr [BX+SI+0011],00C8")]
        public void CheckTestV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000101 00000000", "TEST", "Word Ptr [BX+SI],AX")]
        [InlineData("10000101 11011010", "TEST", "DX,BX")]
        // [InlineData("00111110 10000101 00010001", "TEST", "Word Ptr DS:[BX+DI],DX")]
        // [InlineData("10000101 01000000 00010001", "TEST", "Word Ptr [BX+SI+11],AX")]
        // [InlineData("10000101 00000110 00010001 00000000", "TEST", "Word Ptr [0011],AX")]
        // [InlineData("10000101 10000000 00010001 00000000", "TEST", "Word Ptr [BX+SI+0011],AX")]
        public void CheckTestV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11110110 00000001 10100000", "TEST", "Byte Ptr [BX+DI],A0")]
        [InlineData("11110110 11000100 00001001", "TEST", "AH,09")]
        // [InlineData("11110110 01000000 00010001 00000000", "TEST", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("11110110 01000100 00010001 00000000", "TEST", "Byte Ptr [SI+11],00")]
        // [InlineData("11110110 00000110 00010001 00000000 11001000", "TEST", "Byte Ptr [0011],C8")]
        // [InlineData("11110110 10000000 00010001 00000000 11001000", "TEST", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckTestV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000100 00000000", "TEST", "Byte Ptr [BX+SI],AL")]
        [InlineData("10000100 11001000", "TEST", "AL,CL")]
        // [InlineData("00111110 10000100 00010001", "TEST", "Byte Ptr DS:[BX+DI],DL")]
        // [InlineData("10000100 01000011 01101101", "TEST", "Byte Ptr [BP+DI+6D],AL")]
        // [InlineData("10000100 00000110 00010001 00000000", "TEST", "Byte Ptr [0011],AL")]
        // [InlineData("10000100 10000000 00010001 00000000", "TEST", "Byte Ptr [BX+SI+0011],AL")]
        public void CheckTestV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [XOR] Logical Exclusive OR
        [Theory(Skip = "Too complicated!")]
        [InlineData("00110100 00000000", "XOR", "AL,00")]
        // [InlineData("00110100 11011000", "XOR", "AL,D8")]
        public void CheckXorV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00110101 00000000 11110010", "XOR", "AX,F200")]
        // [InlineData("00110101 00000001 10010101", "XOR", "AX,9501")]
        public void CheckXorV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00110011 00000000", "XOR", "AX,Word Ptr [BX+SI]")]
        [InlineData("00110011 11000111", "XOR", "AX,DI")]
        // [InlineData("00110011 01010000 10110110", "XOR", "DX,Word Ptr [BX+SI-4A]")]
        // [InlineData("00111110 00110011 00010001", "XOR", "DX,Word Ptr DS:[BX+DI]")]
        // [InlineData("00110011 00000110 00010001 00000000", "XOR", "AX,Word Ptr [0011]")]
        // [InlineData("00110011 10011010 11001111 11111000", "XOR", "BX,Word Ptr [BP+SI-0731]")]
        // [InlineData("00101110 00110011 10001000 00101000 00000000", "XOR", "CX,Word Ptr CS:[BX+SI+0028]")]
        public void CheckXorV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00110010 00000000", "XOR", "AL,Byte Ptr [BX+SI]")]
        [InlineData("00110010 11000000", "XOR", "AL,AL")]
        // [InlineData("00110010 01001010 01101101", "XOR", "CL,Byte Ptr [BP+SI+6D]")]
        // [InlineData("00111110 00110010 00010001", "XOR", "DL,Byte Ptr DS:[BX+DI]")]
        // [InlineData("00110010 00000110 00010001 00000000", "XOR", "AL,Byte Ptr [0011]")]
        // [InlineData("00110010 10001001 10001010 00011100", "XOR", "CL,Byte Ptr [BX+DI+1C8A]")]
        public void CheckXorV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000001 00110000 00010001 00000000", "XOR", "Word Ptr [BX+SI],0011")]
        [InlineData("10000001 11110000 00010001 00000000", "XOR", "AX,0011")]
        // [InlineData("10000001 01110000 00010001 00000000 11001000", "XOR", "Word Ptr [BX+SI+11],C800")]
        // [InlineData("10000001 01110100 00010001 00000000 11001000", "XOR", "Word Ptr [SI+11],C800")]
        // [InlineData("10000001 00110110 00010001 00000000 11001000 00000000", "XOR", "Word Ptr [0011],00C8")]
        // [InlineData("10000001 00110110 01011110 01000011 10110001 01111110", "XOR", "Word Ptr [435E],7EB1")]
        public void CheckXorV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000011 00110000 00010001", "XOR", "Word Ptr [BX+SI],+11")]
        [InlineData("10000011 11110011 00001001", "XOR", "BX,+09")]
        // [InlineData("10000011 01110100 00010001 00000000", "XOR", "Word Ptr [SI+11],+00")]
        // [InlineData("10000011 01110110 01101100 10101010", "XOR", "Word Ptr [BP+6C],-56")]
        // [InlineData("10000011 10110000 00010001 00000000 11001000", "XOR", "Word Ptr [BX+SI+0011],-38")]
        // [InlineData("10000011 10110101 00001011 11011101 00111110", "XOR", "Word Ptr [DI-22F5],+3E")]
        public void CheckXorV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00110001 00000000", "XOR", "Word Ptr [BX+SI],AX")]
        [InlineData("00110001 11011010", "XOR", "DX,BX")]
        // [InlineData("00110001 01111011 00101100", "XOR", "Word Ptr [BP+DI+2C],DI")]
        // [InlineData("00111110 00110001 00010001", "XOR", "Word Ptr DS:[BX+DI],DX")]
        // [InlineData("00110001 00000110 00010001 00000000", "XOR", "Word Ptr [0011],AX")]
        // [InlineData("00110001 10010000 10110101 10000000", "XOR", "Word Ptr [BX+SI-7F4B],DX")]
        public void CheckXorV7(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000010 00110001 00111010", "XOR", "Byte Ptr [BX+DI],3A")]
        [InlineData("10000010 11110000 00010001", "XOR", "AL,11")]
        // [InlineData("10000010 01110000 00010001 00000000", "XOR", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("10000010 01110100 00010001 00000000", "XOR", "Byte Ptr [SI+11],00")]
        // [InlineData("10000010 00110110 00010001 00000000 11001000", "XOR", "Byte Ptr [0011],C8")]
        // [InlineData("10000010 10110001 00011101 10111000 00111011", "XOR", "Byte Ptr [BX+DI-47E3],3B")]
        // [InlineData("00110110 10000010 10110100 00011000 00100001 10001000", "XOR", "Byte Ptr SS:[SI+2118],88")]
        public void CheckXorV8(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10000000 00110000 11111011", "XOR", "Byte Ptr [BX+SI],FB")]
        [InlineData("10000000 11110100 00001001", "XOR", "AH,09")]
        // [InlineData("10000000 01110000 00010001 00000000", "XOR", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("10000000 01110100 00010001 00000000", "XOR", "Byte Ptr [SI+11],00")]
        // [InlineData("10000000 00110110 00010001 00000000 11001000", "XOR", "Byte Ptr [0011],C8")]
        // [InlineData("10000000 10110000 00010001 00000000 11001000", "XOR", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckXorV9(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("00110000 00000000", "XOR", "Byte Ptr [BX+SI],AL")]
        [InlineData("00110000 11100100", "XOR", "AH,AH")]
        // [InlineData("00110000 01011010 00111100", "XOR", "Byte Ptr [BP+SI+3C],BL")]
        // [InlineData("00111110 00110000 00010001", "XOR", "Byte Ptr DS:[BX+DI],DL")]
        // [InlineData("00110000 00000110 00010001 00000000", "XOR", "Byte Ptr [0011],AL")]
        // [InlineData("00110000 10000000 00010001 00000000", "XOR", "Byte Ptr [BX+SI+0011],AL")]
        public void CheckXorV10(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
