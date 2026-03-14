using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class ShiftTest : AbstractDecodeTest
    {
        #region [RCL, ROLC] Rotate Through Carry Left
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010001 00010000", "RCL", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 11010000", "RCL", "AX,1")]
        // [InlineData("00111110 11010001 00010001", "RCL", "Word Ptr DS:[BX+DI],1")]
        // [InlineData("11010001 01010000 00010001", "RCL", "Word Ptr [BX+SI+11],1")]
        // [InlineData("11010001 00010110 00010001 00000000", "RCL", "Word Ptr [0011],1")]
        // [InlineData("11010001 10010000 00010001 00000000", "RCL", "Word Ptr [BX+SI+0011],1")]
        public void CheckRclV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010011 00010000", "RCL", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 11010111", "RCL", "DI,CL")]
        // [InlineData("00111110 11010011 00010001", "RCL", "Word Ptr DS:[BX+DI],CL")]
        // [InlineData("11010011 01010000 00010001", "RCL", "Word Ptr [BX+SI+11],CL")]
        // [InlineData("11010011 00010110 00010001 00000000", "RCL", "Word Ptr [0011],CL")]
        // [InlineData("11010011 10010000 00010001 00000000", "RCL", "Word Ptr [BX+SI+0011],CL")]
        public void CheckRclV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000001 00010000 00010001", "RCL", "Word Ptr [BX+SI],11")]
        [InlineData("11000001 11010011 00001001", "RCL", "BX,09")]
        // [InlineData("00111110 11000001 00010001 00000000", "RCL", "Word Ptr DS:[BX+DI],00")]
        // [InlineData("11000001 01010000 00010001 00000000", "RCL", "Word Ptr [BX+SI+11],00")]
        // [InlineData("11000001 00010110 00010001 00000000 11001000", "RCL", "Word Ptr [0011],C8")]
        // [InlineData("11000001 10010000 00010001 00000000 11001000", "RCL", "Word Ptr [BX+SI+0011],C8")]
        public void CheckRclV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010000 00010000", "RCL", "Byte Ptr [BX+SI],1")]
        [InlineData("11010000 11010000", "RCL", "AL,1")]
        // [InlineData("00111110 11010000 00010001", "RCL", "Byte Ptr DS:[BX+DI],1")]
        // [InlineData("11010000 01010000 00010001", "RCL", "Byte Ptr [BX+SI+11],1")]
        // [InlineData("11010000 00010110 00010001 00000000", "RCL", "Byte Ptr [0011],1")]
        // [InlineData("11010000 10010000 00010001 00000000", "RCL", "Byte Ptr [BX+SI+0011],1")]
        public void CheckRclV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010010 00010000", "RCL", "Byte Ptr [BX+SI],CL")]
        [InlineData("11010010 11010000", "RCL", "AL,CL")]
        // [InlineData("00111110 11010010 00010001", "RCL", "Byte Ptr DS:[BX+DI],CL")]
        // [InlineData("11010010 01010000 00010001", "RCL", "Byte Ptr [BX+SI+11],CL")]
        // [InlineData("11010010 00010110 00010001 00000000", "RCL", "Byte Ptr [0011],CL")]
        // [InlineData("11010010 10010000 00010001 00000000", "RCL", "Byte Ptr [BX+SI+0011],CL")]
        public void CheckRclV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000000 00010000 00010001", "RCL", "Byte Ptr [BX+SI],11")]
        [InlineData("11000000 11010100 00001001", "RCL", "AH,09")]
        // [InlineData("00111110 11000000 00010001 00000000", "RCL", "Byte Ptr DS:[BX+DI],00")]
        // [InlineData("11000000 01010000 00010001 00000000", "RCL", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("11000000 00010110 00010001 00000000 11001000", "RCL", "Byte Ptr [0011],C8")]
        // [InlineData("11000000 10010000 00010001 00000000 11001000", "RCL", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckRclV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [RCR, RORC] Rotate Through Carry Right
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010001 00011000", "RCR", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 11011100", "RCR", "SP,1")]
        // [InlineData("11010001 01011000 00010001", "RCR", "Word Ptr [BX+SI+11],1")]
        // [InlineData("11010001 01011100 00010001", "RCR", "Word Ptr [SI+11],1")]
        // [InlineData("11010001 00011110 00010001 00000000", "RCR", "Word Ptr [0011],1")]
        // [InlineData("11010001 10011011 10111101 01110100", "RCR", "Word Ptr [BP+DI+74BD],1")]
        public void CheckRcrV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010011 00011000", "RCR", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 11011101", "RCR", "BP,CL")]
        // [InlineData("11010011 01011000 00010001", "RCR", "Word Ptr [BX+SI+11],CL")]
        // [InlineData("11010011 01011100 00010001", "RCR", "Word Ptr [SI+11],CL")]
        // [InlineData("11010011 00011110 00010001 00000000", "RCR", "Word Ptr [0011],CL")]
        // [InlineData("11010011 10011000 00010001 00000000", "RCR", "Word Ptr [BX+SI+0011],CL")]
        public void CheckRcrV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000001 00011000 00010001", "RCR", "Word Ptr [BX+SI],11")]
        [InlineData("11000001 11011011 00001001", "RCR", "BX,09")]
        // [InlineData("11000001 01011000 00010001 00000000", "RCR", "Word Ptr [BX+SI+11],00")]
        // [InlineData("11000001 01011100 00010001 00000000", "RCR", "Word Ptr [SI+11],00")]
        // [InlineData("11000001 00011110 00010001 00000000 11001000", "RCR", "Word Ptr [0011],C8")]
        // [InlineData("11000001 10011000 00010001 00000000 11001000", "RCR", "Word Ptr [BX+SI+0011],C8")]
        public void CheckRcrV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010000 00011000", "RCR", "Byte Ptr [BX+SI],1")]
        [InlineData("11010000 11011111", "RCR", "BH,1")]
        // [InlineData("11010000 01011000 00010001", "RCR", "Byte Ptr [BX+SI+11],1")]
        // [InlineData("11010000 01011100 00010001", "RCR", "Byte Ptr [SI+11],1")]
        // [InlineData("00110110 11010000 01011001 00001011", "RCR", "Byte Ptr SS:[BX+DI+0B],1")]
        // [InlineData("11010000 00011110 00010001 00000000", "RCR", "Byte Ptr [0011],1")]
        public void CheckRcrV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010010 00011000", "RCR", "Byte Ptr [BX+SI],CL")]
        [InlineData("11010010 11011000", "RCR", "AL,CL")]
        // [InlineData("11010010 01011000 00010001", "RCR", "Byte Ptr [BX+SI+11],CL")]
        // [InlineData("11010010 01011100 00010001", "RCR", "Byte Ptr [SI+11],CL")]
        // [InlineData("11010010 00011110 00010001 00000000", "RCR", "Byte Ptr [0011],CL")]
        // [InlineData("11010010 10011000 00010001 00000000", "RCR", "Byte Ptr [BX+SI+0011],CL")]
        public void CheckRcrV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000000 00011000 00010001", "RCR", "Byte Ptr [BX+SI],11")]
        [InlineData("11000000 11011100 00001001", "RCR", "AH,09")]
        // [InlineData("11000000 01011100 00010001 00000000", "RCR", "Byte Ptr [SI+11],00")]
        // [InlineData("11000000 01011100 00111100 10111011", "RCR", "Byte Ptr [SI+3C],BB")]
        // [InlineData("11000000 00011110 00010001 00000000 11001000", "RCR", "Byte Ptr [0011],C8")]
        // [InlineData("11000000 10011000 00010001 00000000 11001000", "RCR", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckRcrV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [ROL] Rotate Left
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010001 00000000", "ROL", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 11000000", "ROL", "AX,1")]
        // [InlineData("11010001 01000000 00010001", "ROL", "Word Ptr [BX+SI+11],1")]
        // [InlineData("11010001 01000100 00010001", "ROL", "Word Ptr [SI+11],1")]
        // [InlineData("11010001 00000110 00010001 00000000", "ROL", "Word Ptr [0011],1")]
        // [InlineData("11010001 10000001 01001101 01011001", "ROL", "Word Ptr [BX+DI+594D],1")]
        public void CheckRolV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010011 00000000", "ROL", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 11000000", "ROL", "AX,CL")]
        // [InlineData("11010011 01000000 00010001", "ROL", "Word Ptr [BX+SI+11],CL")]
        // [InlineData("11010011 01000100 00010001", "ROL", "Word Ptr [SI+11],CL")]
        // [InlineData("11010011 00000110 00010001 00000000", "ROL", "Word Ptr [0011],CL")]
        // [InlineData("11010011 10000000 00010001 00000000", "ROL", "Word Ptr [BX+SI+0011],CL")]
        public void CheckRolV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000001 00000000 10111011", "ROL", "Word Ptr [BX+SI],BB")]
        [InlineData("11000001 11000011 00001001", "ROL", "BX,09")]
        // [InlineData("11000001 01000000 00010001 00000000", "ROL", "Word Ptr [BX+SI+11],00")]
        // [InlineData("11000001 01000100 00010001 00000000", "ROL", "Word Ptr [SI+11],00")]
        // [InlineData("11000001 00000110 00010001 00000000 11001000", "ROL", "Word Ptr [0011],C8")]
        // [InlineData("11000001 10000000 00010001 00000000 11001000", "ROL", "Word Ptr [BX+SI+0011],C8")]
        public void CheckRolV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010000 00000000", "ROL", "Byte Ptr [BX+SI],1")]
        [InlineData("11010000 11000000", "ROL", "AL,1")]
        // [InlineData("11010000 01000000 00010001", "ROL", "Byte Ptr [BX+SI+11],1")]
        // [InlineData("11010000 01000100 00010001", "ROL", "Byte Ptr [SI+11],1")]
        // [InlineData("11010000 00000110 00010001 00000000", "ROL", "Byte Ptr [0011],1")]
        // [InlineData("11010000 10000000 00010001 00000000", "ROL", "Byte Ptr [BX+SI+0011],1")]
        public void CheckRolV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010010 00000000", "ROL", "Byte Ptr [BX+SI],CL")]
        [InlineData("11010010 11000000", "ROL", "AL,CL")]
        // [InlineData("11010010 01000000 10111100", "ROL", "Byte Ptr [BX+SI-44],CL")]
        // [InlineData("11010010 01000100 00010001", "ROL", "Byte Ptr [SI+11],CL")]
        // [InlineData("11010010 00000110 00010001 00000000", "ROL", "Byte Ptr [0011],CL")]
        // [InlineData("11010010 10000000 00010001 00000000", "ROL", "Byte Ptr [BX+SI+0011],CL")]
        public void CheckRolV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000000 00000000 01100011", "ROL", "Byte Ptr [BX+SI],63")]
        [InlineData("11000000 11000100 00001001", "ROL", "AH,09")]
        // [InlineData("11000000 01000000 00010001 00000000", "ROL", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("11000000 01000100 00010001 00000000", "ROL", "Byte Ptr [SI+11],00")]
        // [InlineData("11000000 00000110 00010001 00000000 11001000", "ROL", "Byte Ptr [0011],C8")]
        // [InlineData("11000000 10000000 00010001 00000000 11001000", "ROL", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckRolV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [ROR] Rotate Right
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010001 00001000", "ROR", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 11001000", "ROR", "AX,1")]
        // [InlineData("11010001 01001000 00010001", "ROR", "Word Ptr [BX+SI+11],1")]
        // [InlineData("11010001 01001100 00010001", "ROR", "Word Ptr [SI+11],1")]
        // [InlineData("11010001 00001110 00010001 00000000", "ROR", "Word Ptr [0011],1")]
        // [InlineData("11010001 10001000 00010001 00000000", "ROR", "Word Ptr [BX+SI+0011],1")]
        public void CheckRorV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010011 00001000", "ROR", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 11001000", "ROR", "AX,CL")]
        // [InlineData("11010011 01001000 00010001", "ROR", "Word Ptr [BX+SI+11],CL")]
        // [InlineData("11010011 01001100 00010001", "ROR", "Word Ptr [SI+11],CL")]
        // [InlineData("11010011 00001110 00010001 00000000", "ROR", "Word Ptr [0011],CL")]
        // [InlineData("11010011 10001000 00010001 00000000", "ROR", "Word Ptr [BX+SI+0011],CL")]
        public void CheckRorV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000001 00001000 00010001", "ROR", "Word Ptr [BX+SI],11")]
        [InlineData("11000001 11001011 00001001", "ROR", "BX,09")]
        // [InlineData("11000001 01001000 01011100 11111100", "ROR", "Word Ptr [BX+SI+5C],FC")]
        // [InlineData("11000001 01001100 00010001 00000000", "ROR", "Word Ptr [SI+11],00")]
        // [InlineData("11000001 00001110 00010001 00000000 11001000", "ROR", "Word Ptr [0011],C8")]
        // [InlineData("11000001 10001000 00010001 00000000 11001000", "ROR", "Word Ptr [BX+SI+0011],C8")]
        public void CheckRorV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010000 00001010", "ROR", "Byte Ptr [BP+SI],1")]
        [InlineData("11010000 11001011", "ROR", "BL,1")]
        // [InlineData("11010000 01001000 00010001", "ROR", "Byte Ptr [BX+SI+11],1")]
        // [InlineData("11010000 01001100 00010001", "ROR", "Byte Ptr [SI+11],1")]
        // [InlineData("11010000 00001110 00010001 00000000", "ROR", "Byte Ptr [0011],1")]
        // [InlineData("11010000 10001000 00010001 00000000", "ROR", "Byte Ptr [BX+SI+0011],1")]
        public void CheckRorV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010010 00001000", "ROR", "Byte Ptr [BX+SI],CL")]
        [InlineData("11010010 11001000", "ROR", "AL,CL")]
        // [InlineData("11010010 01001000 00010001", "ROR", "Byte Ptr [BX+SI+11],CL")]
        // [InlineData("11010010 01001100 00010001", "ROR", "Byte Ptr [SI+11],CL")]
        // [InlineData("11010010 00001110 00010001 00000000", "ROR", "Byte Ptr [0011],CL")]
        // [InlineData("11010010 10001000 00010001 00000000", "ROR", "Byte Ptr [BX+SI+0011],CL")]
        public void CheckRorV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000000 00001000 00010001", "ROR", "Byte Ptr [BX+SI],11")]
        [InlineData("11000000 11001100 00001001", "ROR", "AH,09")]
        // [InlineData("11000000 01001000 00010001 00000000", "ROR", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("11000000 01001100 00010001 00000000", "ROR", "Byte Ptr [SI+11],00")]
        // [InlineData("11000000 00001110 00010001 00000000 11001000", "ROR", "Byte Ptr [0011],C8")]
        // [InlineData("11000000 10001000 00010001 00000000 11001000", "ROR", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckRorV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [SAR, SHRA] Shift Arithmetic Right
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010001 00111000", "SAR", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 11111000", "SAR", "AX,1")]
        // [InlineData("11010001 01111000 00010001", "SAR", "Word Ptr [BX+SI+11],1")]
        // [InlineData("11010001 01111100 00010001", "SAR", "Word Ptr [SI+11],1")]
        // [InlineData("11010001 00111110 00010001 00000000", "SAR", "Word Ptr [0011],1")]
        // [InlineData("11010001 10111011 01011010 10110000", "SAR", "Word Ptr [BP+DI-4FA6],1")]
        public void CheckSarV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010011 00111000", "SAR", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 11111001", "SAR", "CX,CL")]
        // [InlineData("11010011 01111000 00010001", "SAR", "Word Ptr [BX+SI+11],CL")]
        // [InlineData("11010011 01111100 00010001", "SAR", "Word Ptr [SI+11],CL")]
        // [InlineData("11010011 00111110 00010001 00000000", "SAR", "Word Ptr [0011],CL")]
        // [InlineData("11010011 10111000 00010001 00000000", "SAR", "Word Ptr [BX+SI+0011],CL")]
        // [InlineData("00100110 11010011 10111000 00011111 11111111", "SAR", "Word Ptr ES:[BX+SI-00E1],CL")]
        public void CheckSarV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000001 00111000 00010001", "SAR", "Word Ptr [BX+SI],11")]
        [InlineData("11000001 11111011 00001001", "SAR", "BX,09")]
        // [InlineData("11000001 01111000 00010001 00000000", "SAR", "Word Ptr [BX+SI+11],00")]
        // [InlineData("11000001 01111100 00010001 00000000", "SAR", "Word Ptr [SI+11],00")]
        // [InlineData("11000001 00111110 00010001 00000000 11001000", "SAR", "Word Ptr [0011],C8")]
        // [InlineData("11000001 10111000 00010001 00000000 11001000", "SAR", "Word Ptr [BX+SI+0011],C8")]
        public void CheckSarV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010000 00111000", "SAR", "Byte Ptr [BX+SI],1")]
        [InlineData("11010000 11111000", "SAR", "AL,1")]
        // [InlineData("11010000 01111000 00010001", "SAR", "Byte Ptr [BX+SI+11],1")]
        // [InlineData("11010000 01111100 00010001", "SAR", "Byte Ptr [SI+11],1")]
        // [InlineData("11010000 00111110 00010001 00000000", "SAR", "Byte Ptr [0011],1")]
        // [InlineData("11010000 10111000 00010001 00000000", "SAR", "Byte Ptr [BX+SI+0011],1")]
        public void CheckSarV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010010 00111001", "SAR", "Byte Ptr [BX+DI],CL")]
        [InlineData("11010010 11111000", "SAR", "AL,CL")]
        // [InlineData("11010010 01111000 00010001", "SAR", "Byte Ptr [BX+SI+11],CL")]
        // [InlineData("11010010 01111100 00010001", "SAR", "Byte Ptr [SI+11],CL")]
        // [InlineData("00110110 11010010 01111001 10111001", "SAR", "Byte Ptr SS:[BX+DI-47],CL")]
        // [InlineData("11010010 00111110 00010001 00000000", "SAR", "Byte Ptr [0011],CL")]
        public void CheckSarV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000000 00111000 00010001", "SAR", "Byte Ptr [BX+SI],11")]
        [InlineData("11000000 11111100 00001001", "SAR", "AH,09")]
        // [InlineData("11000000 01111000 00010001 00000000", "SAR", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("11000000 01111100 00010001 00000000", "SAR", "Byte Ptr [SI+11],00")]
        // [InlineData("11000000 00111110 00010001 00000000 11001000", "SAR", "Byte Ptr [0011],C8")]
        // [InlineData("11000000 10111000 00010001 00000000 11001000", "SAR", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckSarV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [SHL] Shift Logical Left
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010001 00100000", "SHL", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 11100000", "SHL", "AX,1")]
        // [InlineData("11010001 01100000 00010001", "SHL", "Word Ptr [BX+SI+11],1")]
        // [InlineData("11010001 01100100 00010001", "SHL", "Word Ptr [SI+11],1")]
        // [InlineData("11010001 00100110 00010001 00000000", "SHL", "Word Ptr [0011],1")]
        // [InlineData("11010001 10100000 00010001 00000000", "SHL", "Word Ptr [BX+SI+0011],1")]
        public void CheckShlV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010011 00100000", "SHL", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 11100000", "SHL", "AX,CL")]
        // [InlineData("11010011 01100000 00010001", "SHL", "Word Ptr [BX+SI+11],CL")]
        // [InlineData("11010011 01100100 00010001", "SHL", "Word Ptr [SI+11],CL")]
        // [InlineData("11010011 00100110 00010001 00000000", "SHL", "Word Ptr [0011],CL")]
        // [InlineData("11010011 10100000 00010001 00000000", "SHL", "Word Ptr [BX+SI+0011],CL")]
        public void CheckShlV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000001 00100000 00010001", "SHL", "Word Ptr [BX+SI],11")]
        [InlineData("11000001 11100011 00001001", "SHL", "BX,09")]
        // [InlineData("11000001 01100000 00010001 00000000", "SHL", "Word Ptr [BX+SI+11],00")]
        // [InlineData("11000001 01100100 00010001 00000000", "SHL", "Word Ptr [SI+11],00")]
        // [InlineData("11000001 00100110 00010001 00000000 11001000", "SHL", "Word Ptr [0011],C8")]
        // [InlineData("11000001 10100000 00010001 00000000 11001000", "SHL", "Word Ptr [BX+SI+0011],C8")]
        public void CheckShlV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010000 00100000", "SHL", "Byte Ptr [BX+SI],1")]
        [InlineData("11010000 11100000", "SHL", "AL,1")]
        // [InlineData("11010000 01100000 00010001", "SHL", "Byte Ptr [BX+SI+11],1")]
        // [InlineData("11010000 01100100 00010001", "SHL", "Byte Ptr [SI+11],1")]
        // [InlineData("11010000 00100110 00010001 00000000", "SHL", "Byte Ptr [0011],1")]
        // [InlineData("11010000 10100000 00010001 00000000", "SHL", "Byte Ptr [BX+SI+0011],1")]
        public void CheckShlV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010010 00100000", "SHL", "Byte Ptr [BX+SI],CL")]
        [InlineData("11010010 11100000", "SHL", "AL,CL")]
        // [InlineData("11010010 01100000 00010001", "SHL", "Byte Ptr [BX+SI+11],CL")]
        // [InlineData("11010010 01100110 11101111", "SHL", "Byte Ptr [BP-11],CL")]
        // [InlineData("11010010 00100110 00010001 00000000", "SHL", "Byte Ptr [0011],CL")]
        // [InlineData("11010010 10100000 00010001 00000000", "SHL", "Byte Ptr [BX+SI+0011],CL")]
        public void CheckShlV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000000 00100000 00010001", "SHL", "Byte Ptr [BX+SI],11")]
        [InlineData("11000000 11100100 00001001", "SHL", "AH,09")]
        // [InlineData("11000000 01100000 00010001 00000000", "SHL", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("11000000 01100100 00010001 00000000", "SHL", "Byte Ptr [SI+11],00")]
        // [InlineData("11000000 00100110 00010001 00000000 11001000", "SHL", "Byte Ptr [0011],C8")]
        // [InlineData("11000000 10100000 01000111 10101110 10001001", "SHL", "Byte Ptr [BX+SI-51B9],89")]
        public void CheckShlV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [SHR] Shift Logical Right
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010001 00101000", "SHR", "Word Ptr [BX+SI],1")]
        [InlineData("11010001 11101000", "SHR", "AX,1")]
        // [InlineData("11010001 01101011 00101111", "SHR", "Word Ptr [BP+DI+2F],1")]
        // [InlineData("11010001 01101100 00010001", "SHR", "Word Ptr [SI+11],1")]
        // [InlineData("11010001 00101110 00010001 00000000", "SHR", "Word Ptr [0011],1")]
        // [InlineData("11010001 10101000 00010001 00000000", "SHR", "Word Ptr [BX+SI+0011],1")]
        public void CheckShrV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010011 00101000", "SHR", "Word Ptr [BX+SI],CL")]
        [InlineData("11010011 11101000", "SHR", "AX,CL")]
        // [InlineData("11010011 01101000 00010001", "SHR", "Word Ptr [BX+SI+11],CL")]
        // [InlineData("11010011 01101100 00010001", "SHR", "Word Ptr [SI+11],CL")]
        // [InlineData("11010011 00101110 00010001 00000000", "SHR", "Word Ptr [0011],CL")]
        // [InlineData("11010011 10101000 10100101 11111111", "SHR", "Word Ptr [BX+SI-005B],CL")]
        public void CheckShrV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000001 00101000 00010001", "SHR", "Word Ptr [BX+SI],11")]
        [InlineData("11000001 11101011 00001001", "SHR", "BX,09")]
        // [InlineData("11000001 01101000 00010001 00000000", "SHR", "Word Ptr [BX+SI+11],00")]
        // [InlineData("11000001 01101100 00010001 00000000", "SHR", "Word Ptr [SI+11],00")]
        // [InlineData("11000001 00101110 00010001 00000000 11001000", "SHR", "Word Ptr [0011],C8")]
        // [InlineData("11000001 10101000 00010001 00000000 11001000", "SHR", "Word Ptr [BX+SI+0011],C8")]
        public void CheckShrV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010000 00101000", "SHR", "Byte Ptr [BX+SI],1")]
        [InlineData("11010000 11101000", "SHR", "AL,1")]
        // [InlineData("11010000 01101000 00010001", "SHR", "Byte Ptr [BX+SI+11],1")]
        // [InlineData("11010000 01101100 00010001", "SHR", "Byte Ptr [SI+11],1")]
        // [InlineData("11010000 00101110 00010001 00000000", "SHR", "Byte Ptr [0011],1")]
        // [InlineData("11010000 10101000 00010001 00000000", "SHR", "Byte Ptr [BX+SI+0011],1")]
        public void CheckShrV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11010010 00101000", "SHR", "Byte Ptr [BX+SI],CL")]
        [InlineData("11010010 11101101", "SHR", "CH,CL")]
        // [InlineData("11010010 01101000 00010001", "SHR", "Byte Ptr [BX+SI+11],CL")]
        // [InlineData("11010010 01101100 00010001", "SHR", "Byte Ptr [SI+11],CL")]
        // [InlineData("11010010 00101110 00010001 00000000", "SHR", "Byte Ptr [0011],CL")]
        // [InlineData("11010010 10101000 00010001 00000000", "SHR", "Byte Ptr [BX+SI+0011],CL")]
        public void CheckShrV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11000000 00101001 00101001", "SHR", "Byte Ptr [BX+DI],29")]
        [InlineData("11000000 11101100 00001001", "SHR", "AH,09")]
        // [InlineData("11000000 01101000 00010001 00000000", "SHR", "Byte Ptr [BX+SI+11],00")]
        // [InlineData("11000000 01101100 00010001 00000000", "SHR", "Byte Ptr [SI+11],00")]
        // [InlineData("11000000 00101110 00010001 00000000 11001000", "SHR", "Byte Ptr [0011],C8")]
        // [InlineData("11000000 10101000 00010001 00000000 11001000", "SHR", "Byte Ptr [BX+SI+0011],C8")]
        public void CheckShrV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
