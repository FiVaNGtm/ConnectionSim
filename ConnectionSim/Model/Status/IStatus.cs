using System;

namespace ConnectionSim.Model.Status
{
    public interface IStatus<TStatus> where TStatus : Enum
    {
        TStatus Status    { get; set; }

        void StatusChange(TStatus workingStatus);

        public delegate void StatusChangedEventHandler(TStatus status);
    }
}