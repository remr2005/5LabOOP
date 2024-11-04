using DeviceControl;
using System;
using System.Threading;

namespace MeasureLengthDeviceNamespace
{
    public abstract class MeasureDataDevice : IMeasuringDevice
    {
        protected Units unitsToUse;
        protected int[] dataCaptured;
        protected int mostRecentMeasure;
        protected DeviceController? controller;
        protected abstract DeviceType measurementType { get; }

        // Абстрактные методы для конкретных устройств
        public abstract decimal MetricValue();
        public abstract decimal ImperialValue();

        public void StartCollecting()
        {
            controller = DeviceController.StartDevice(measurementType);
            GetMeasurements();
        }

        public void StopCollecting()
        {
            if (controller != null)
            {
                DeviceController.StopDevice();
                controller = null;
            }
        }

        public int[] GetRawData()
        {
            return dataCaptured;
        }

        // Метод для получения измерений
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