using System;
using System.Linq;
using System.Text;

namespace CDMAProject
{
    public static class CDMAHelper
    {
        public static int[] StringToBinary(string input)
        {
            return Encoding.ASCII.GetBytes(input)
                .SelectMany(b => Convert.ToString(b, 2).PadLeft(8, '0')
                    .Select(c => c == '1' ? 1 : -1))
                .ToArray();
        }

        public static string BinaryToString(int[] binary)
        {
            if (binary.Length % 8 != 0)
            {
                throw new InvalidOperationException("Binary array length must be divisible by 8.");
            }

            var bytes = new byte[binary.Length / 8];
            for (int i = 0; i < binary.Length; i += 8)
            {
                string byteString = new string(binary.Skip(i).Take(8)
                    .Select(b => b > 0 ? '1' : '0').ToArray());
                bytes[i / 8] = Convert.ToByte(byteString, 2);
            }
            return Encoding.ASCII.GetString(bytes);
        }

    }
}