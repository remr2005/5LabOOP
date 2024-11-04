namespace MeasureLengthDeviceNamespace
{
    public interface IMeasuringDevice
    {
        /// <summary>
        /// Converts the raw data collected by the measuring device into a metric value
        /// </summary>
        ///<returns>The latest measurement from the device converted to metric units.</returns>
        public decimal MetricValue();
        /// <summary>
        /// Converts the raw data collected by the measuring device into an imperial value.
        /// </summary>
        ///<returns>The latest measurement from the device converted to imperial units.</returns>
        public decimal ImperialValue();
        /// <summary>
        /// Starts the measuring device.
        /// </summary>
        public void StartCollecting();
        /// <summary>
        /// Stops the measuring device.
        /// </summary>
        public void StopCollecting();
        /// <summary>
        /// Enables access to the raw data from the device in whatever units are native to the device
        /// </summary>
        /// <returns>The raw data from the device in native format.</returns>
        public int[] GetRawData();
    }
}
