using System;

namespace HoursUpdatingTool
{
    public class ProgressInitializeEventArgs : EventArgs
    {
        public string Message { get; }
        public int Minimum { get; }
        public int Maximum { get; }
        public int Value { get; }
        public int StepValue { get; }

        public ProgressInitializeEventArgs(string taskDescription, int minimumSteps, int maximumSteps, int stepValue, int value)
        {
            Message = taskDescription;
            Minimum = minimumSteps;
            Maximum = maximumSteps;
            StepValue = stepValue;
            Value = value;
        }
    }
}