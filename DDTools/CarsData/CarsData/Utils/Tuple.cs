using System;
using System.Collections;
using System.Collections.Generic;

namespace Types
{
    [Serializable]
    public class Tuple<T1, T2>
    {
        public T1 first;
        public T2 second;

        public Tuple(T1 first, T2 second)
        {
            this.first = first;
            this.second = second;
        }

        public override string ToString()
        {
            return string.Format("<{0}, {1}>", first, second);
        }

        public static bool operator ==(Tuple<T1, T2> a, Tuple<T1, T2> b)
        {
            if (Tuple<T1, T2>.IsNull(a) && !Tuple<T1, T2>.IsNull(b))
                return false;

            if (!Tuple<T1, T2>.IsNull(a) && Tuple<T1, T2>.IsNull(b))
                return false;

            if (Tuple<T1, T2>.IsNull(a) && Tuple<T1, T2>.IsNull(b))
                return true;

            return
                a.first.Equals(b.first) &&
                a.second.Equals(b.second);
        }

        public static bool operator !=(Tuple<T1, T2> a, Tuple<T1, T2> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + first.GetHashCode();
            hash = hash * 23 + second.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Tuple<T1, T2>;
            if (object.ReferenceEquals(other, null))
                return false;
            else
                return first.Equals(other.first) && second.Equals(other.first);
        }

        private static bool IsNull(object obj)
        {
            return object.ReferenceEquals(obj, null);
        }
    }
    [Serializable]
    public class Tuple<T1, T2, T3>
    {
        public T1 first;
        public T2 second;
        public T3 third;

        public Tuple(T1 first, T2 second, T3 third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }

        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}>", first, second, third);
        }

        public static bool operator ==(Tuple<T1, T2, T3> a, Tuple<T1, T2, T3> b)
        {
            if (Tuple<T1, T2, T3>.IsNull(a) && !Tuple<T1, T2, T3>.IsNull(b))
                return false;

            if (!Tuple<T1, T2, T3>.IsNull(a) && Tuple<T1, T2, T3>.IsNull(b))
                return false;

            if (Tuple<T1, T2, T3>.IsNull(a) && Tuple<T1, T2, T3>.IsNull(b))
                return true;

            return
                a.first.Equals(b.first) &&
                a.second.Equals(b.second) &&
                a.third.Equals(b.third);
        }

        public static bool operator !=(Tuple<T1, T2, T3> a, Tuple<T1, T2, T3> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + first.GetHashCode();
            hash = hash * 23 + second.GetHashCode();
            hash = hash * 23 + third.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Tuple<T1, T2, T3>;
            if (object.ReferenceEquals(other, null))
                return false;
            else
                return first.Equals(other.first) && second.Equals(other.first) && second.Equals(other.third);
        }

        private static bool IsNull(object obj)
        {
            return object.ReferenceEquals(obj, null);
        }
    }
}