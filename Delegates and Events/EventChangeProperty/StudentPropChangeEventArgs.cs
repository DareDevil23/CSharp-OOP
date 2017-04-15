using System;

namespace EventChangeProperty
{
    public class StudentPropChangeEventArgs : EventArgs
    {
        public StudentPropChangeEventArgs(string propName, object oldPropValue, object newPropValue)
        {
            this.propName = propName;
            this.OldProp = oldPropValue;
            this.NewProp = newPropValue;
        }

        public string propName { get; set; }
        public object OldProp { get; set; }
        public object NewProp { get; set; }
    }
}
