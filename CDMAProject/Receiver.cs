using System;

namespace CDMAProject
{
    public class Receiver
    {
        public int[] WalshCode { get; }

        public Receiver(int[] walshCode)
        {
            WalshCode = walshCode;
        }

        public string DecodeMessage(int[] combinedSignal, int messageLength)
        {
            var decodedBinary = new int[messageLength * 8]; // *8, так как ASCII-кодировка использует 8 бит на символ
            int codeLength = WalshCode.Length;

            for (int i = 0; i < messageLength * 8; i++)
            {
                int sum = 0;
                for (int j = 0; j < codeLength; j++)
                {
                    sum += combinedSignal[i * codeLength + j] * WalshCode[j];
                }
                decodedBinary[i] = sum > 0 ? 1 : 0;
            }
            if (decodedBinary.Length % 8 != 0)
            {
                throw new InvalidOperationException("Decoded binary length is not divisible by 8.");
            }

            return CDMAHelper.BinaryToString(decodedBinary);
        }

    }
}