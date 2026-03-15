namespace Thawed
{
    public enum OpMod
    {
        NoDisplacement = 0b00,
        Bit8Displace = 0b01,
        Bit16Displace = 0b10,
        RegisterDirect = 0b11
    }
}