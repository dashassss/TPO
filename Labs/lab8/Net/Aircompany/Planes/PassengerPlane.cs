using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private int _passengersCapacity;
        public int PassengersCapacity
        {
            get { return _passengersCapacity; }
        }

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
{
    if (obj == null || GetType() != obj.GetType())
    {
        return false;
    }

    if (!base.Equals(obj))
    {
        return false;
    }

    var plane = (PassengerPlane)obj;
    return _passengersCapacity == plane._passengersCapacity;
}

        public override int GetHashCode()
        {
            var hashCode = 751774561;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _passengersCapacity.GetHashCode();
            return hashCode;
        }

        

       
        public override string ToString()
        {
            return base.ToString() + $", passengersCapacity={_passengersCapacity}}}";
        }

    }
}
