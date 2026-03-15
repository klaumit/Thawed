namespace Thawed
{
    public enum OpDirection
    {
        /// <summary>
        /// REG --> MOD R/M  
        /// </summary>
        RegIsSrc = 0,

        /// <summary>
        /// MOD R/M --> REG
        /// </summary>
        RegIsDst = 1
    }
}