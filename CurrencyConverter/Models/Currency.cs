namespace CurrencyConverter.Models
{
    /// <summary>
    /// Contains Currency Code and Currency Description
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Rate { get; set; }
    }
}
