using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;
using DeviceControl;

namespace MeasureLengthDeviceNamespace
{
    public class MeasureLengthDevice : IMeasuringDevice
    {
        private Units unitsToUse;
        private int[] dataCaptured;
        private int mostRecentMeasure;
        private DeviceController? controller;
        private const DeviceType measurementType = DeviceType.LENGTH;
        public MeasureLengthDevice(Units units)
        {
            unitsToUse = units;
            dataCaptured = new int[10]; // Буфер данных фиксированного размера
        }
        /// <summary>
        /// Converts the raw data collected by the measuring device into a metric value
        /// </summary>
        ///<returns>The latest measurement from the device converted to metric units.</returns>
        public decimal MetricValue() => (unitsToUse.Equals(Units.Metric)) ? mostRecentMeasure : mostRecentMeasure * 25.4m;
        /// <summary>
        /// Converts the raw data collected by the measuring device into an imperial value.
        /// </summary>
        ///<returns>The latest measurement from the device converted to imperial units.</returns>
        public decimal ImperialValue() => (unitsToUse.Equals(Units.Metric)) ? mostRecentMeasure : mostRecentMeasure * 0.03937m;
        /// <summary>
        /// Starts the measuring device.
        /// </summary>
        public void StartCollecting()
        {
            controller = (controller == null) ? DeviceController.StartDevice(measurementType) : controller;
            GetMeasurements();
        }
        /// <summary>
        /// Stops the measuring device.
        /// </summary>
        public void StopCollecting()
        {
            if (controller != null)
            {
                DeviceController.StopDevice();
                controller = null;
            }
        }
        /// <summary>
        /// Enables access to the raw data from the device in whatever units are native to the device
        /// </summary>
        /// <returns>The raw data from the device in native format.</returns>
        public int[] GetRawData()
        {
            return dataCaptured;
        }
        /// <summary>
        /// Что то делает(я просто скопировал функцию из методы)
        /// </summary>
        private void GetMeasurements()
        {
            ThreadPool.QueueUserWorkItem((_) =>
            {
                int x = 0;
                Random timer = new Random();
                while (controller != null)
                {
                    Thread.Sleep(timer.Next(1000, 5000));
                    if (controller != null)
                    {
                        dataCaptured[x] = DeviceController.TakeMeasurement();
                        mostRecentMeasure = dataCaptured[x];
                        x = (x + 1) % dataCaptured.Length;
                    }
                }
            });
        }
    }
}
