namespace StaySharp.JavaUtils
{
    using System;

    /// <summary>
    ///     An internal clone of the java util class Arrays
    /// <see href="https://docs.oracle.com/javase/7/docs/api/java/util/Arrays.html"/>
    /// </summary>
    internal class Arrays
    {
        internal static int HashCode(long[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;


            foreach (var element in values)
            {
                int elementHash = (int)(element ^ (element >> 32));
                result = 31 * result + elementHash;
            }

            return result;
        }

        internal static int HashCode(int[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;


            foreach (var element in values)
            {
                result = 31 * result + element;
            }

            return result;
        }

        internal static int HashCode(short[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;


            foreach (var element in values)
            {
                result = 31 * result + element;
            }

            return result;
        }

        internal static int HashCode(char[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;


            foreach (var element in values)
            {
                result = 31 * result + element;
            }

            return result;
        }

        internal static int HashCode(byte[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;


            foreach (var element in values)
            {
                result = 31 * result + element;
            }

            return result;
        }

        internal static int HashCode(bool[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;


            foreach (var element in values)
            {
                result = 31 * result + (element ? 1231 : 1237);
            }

            return result;
        }

        internal static int HashCode(double[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;

            foreach (var element in values)
            {
                long bits = BitConverter.DoubleToInt64Bits(element);
                result = 31 * result + (int)(bits ^ (bits >> 32));
            }

            return result;
        }

        internal static int HashCode(float[] values)
        {
            throw new NotImplementedException();
        }

        internal static int HashCode(object[] values)
        {
            if (values == null)
            {
                return 0;
            }
            var result = 1;


            foreach (var element in values)
            {
                result = 31 * result + (element?.GetHashCode() ?? 0);
            }

            return result;
        }
    }
}