using System;
using System.Text;

namespace CDMAProject
{
    public class Transmitter
    {
        public int[] WalshCode { get; }
        public string Message { get; }

        public Transmitter(int[] walshCode, string message)
        {
            WalshCode = walshCode;
            Message = message;
        }

        public int[] EncodeMessage()
        {
            var binaryMessage = CDMAHelper.StringToBinary(Message);
            var encodedSignal = new int[WalshCode.Length * binaryMessage.Length];

            for (int i = 0; i < binaryMessage.Length; i++)
            {
                for (int j = 0; j < WalshCode.Length; j++)
                {
                    encodedSignal[i * WalshCode.Length + j] = binaryMessage[i] * WalshCode[j];
                }
            }

            return encodedSignal;
        }
    }
}