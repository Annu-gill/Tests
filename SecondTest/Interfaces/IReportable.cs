namespace DigitalPettyCashLedger.Interfaces
{
    /// <summary>
    /// Interface to enforce reporting functionality.
    /// Any class implementing this must provide a summary output.
    /// </summary>
    public interface IReportable
    {
        /// <summary>
        /// Returns a string summary of the transaction
        /// </summary>
        string GetSummary();
    }
}
