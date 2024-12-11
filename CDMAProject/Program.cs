using System;
using System.Collections.Generic;
using System.Linq;

namespace CDMAProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var messages = new List<string> { "GOD", "CAT", "HAM", "SUN" };
            var walshCodes = WalshCodeGenerator.GenerateWalshCodes(3);

            var transmitters = messages
                .Select((msg, index) => new Transmitter(walshCodes[index], msg))
                .ToList();

            int[] combinedSignal = transmitters
                .Select(t => t.EncodeMessage())
                .Aggregate((signal1, signal2) => signal1.Zip(signal2, (x, y) => x + y).ToArray());

            foreach (var transmitter in transmitters)
            {
                var receiver = new Receiver(transmitter.WalshCode);
                string decodedMessage = receiver.DecodeMessage(combinedSignal, transmitter.Message.Length);
                Console.WriteLine($"Decoded Message: {decodedMessage}");
            }

        }
    }
}