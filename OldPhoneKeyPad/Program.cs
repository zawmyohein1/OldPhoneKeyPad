using System;

namespace OldPhoneKeyPad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OldPhonePad.Decode("33#")); //Output : E
            Console.WriteLine(OldPhonePad.Decode("227*#")); //Output : B
            Console.WriteLine(OldPhonePad.Decode("4433555 555666#")); //Output : HELLO
            Console.WriteLine(OldPhonePad.Decode("8 88777444666*664#")); //Output : TURING                    
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
