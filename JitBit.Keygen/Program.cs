using System;
using System.Text;
using System.Security.Cryptography;

namespace JitBit.Keygen
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.Title = "JitBit Macro Recorder Keygen by #Decryptor";

			while (true)
			{
				Console.WriteLine("Enter Username:");
				string command = Console.ReadLine();

				if (command == "exit") { break; }

				string publicKeyXml = @"<DSAKeyValue><P>3N35IcqKMJLdrg5HmSYa6duURBVDNZgj7BCnwcz/ufmuTgBqQSf3cxqHNTX31BTKJWBBdfF2LxA+uLRmTXZGzw==</P><Q>hEN4EgQsu/HHDcZh9Qwxg43wkL8=</Q><G>gYixcJeFwqXYS9td15uvi1o5Ontd6U00qjtvo7aPo4ccNB7jt5SGLEBM9RPsYPKnmC8PRBze5gm2MBgZIm4YsQ==</G><Y>RSijtNxu4sTZc50YrQLR19KX3PEsIGSrvcRYdAUKb1nWGJNY0aAdt/E5HtbMbSqIFPI3mLcOYdgxu9WyzGkRNw==</Y><J>AAAAAat+p7co8MRenHZUQ+BsY94gSFBLvhftoBGgwzmSBZZc+PRlV6daw3iAVN6y</J><Seed>J0VzBGcedEyNe+AWgq/mC/Wf9RU=</Seed><PgenCounter>pg==</PgenCounter><X>EaOoelpYoydZvGFMZHUobAPlfSY=</X></DSAKeyValue>";
				string newKey = CreateSignature(command, publicKeyXml);
				int index = newKey.Length - 2;
				int length = 2;

				Console.Clear();
				Console.WriteLine("Username: " + command);
				Console.WriteLine("Serial Key: " + newKey.Remove(index, Math.Min(length, newKey.Length - index)).Insert(index, "7+"));
				Console.WriteLine("");
			}
		}

		public static string CreateSignature(string inputData, String privateKey)
		{
			DSACryptoServiceProvider dsa = new DSACryptoServiceProvider(512);
			dsa.FromXmlString(privateKey);
			byte[] data = UTF8Encoding.ASCII.GetBytes(inputData);
			byte[] signature = dsa.SignData(data);
			return Convert.ToBase64String(signature);
		}
	}
}
