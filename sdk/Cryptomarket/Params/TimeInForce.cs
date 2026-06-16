namespace Cryptomarket.Params
{
    /// <summary>
    /// Time in force
    /// </summary>
    public enum TimeInForce
    {
        /// <summary>
        /// good till canceled
        /// </summary>
        GTC,
        /// <summary>
        /// inmediate or cancel
        /// </summary>
        IOC,
        /// <summary>
        /// fill or kill
        /// </summary>
        FOK,
        /// <summary>
        /// day
        /// </summary>
        DAY,
        /// <summary>
        /// good till date
        /// </summary>
        GTD
    }
}