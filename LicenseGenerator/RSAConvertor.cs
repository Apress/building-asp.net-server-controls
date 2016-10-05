using System;
using System.IO;
using System.Security.Cryptography;

namespace LicenseGenerator
{
	public class RSAConvertor
	{

        public static void FillPublicKeyRSAParameters(byte[] key, ref RSAParameters paramsRSA)
        {
        
            MemoryStream stm = new MemoryStream(key);
            
        }

		public static byte[] GetPrivateKeyBytes(RSAParameters paramsRSA)
		{
            MemoryStream stm = new MemoryStream();
            stm.Write(paramsRSA.P, 0, paramsRSA.P.Length);
            stm.Write(paramsRSA.Q, 0, paramsRSA.Q.Length);
            stm.Write(paramsRSA.D, 0, paramsRSA.D.Length);
            stm.Write(paramsRSA.DP, 0, paramsRSA.DP.Length);
            stm.Write(paramsRSA.DQ, 0, paramsRSA.DQ.Length);
            stm.Write(paramsRSA.InverseQ, 0, paramsRSA.InverseQ.Length);
            stm.Write(paramsRSA.Exponent, 0, paramsRSA.Exponent.Length);
            stm.Write(paramsRSA.Modulus, 0, paramsRSA.Modulus.Length);
            
            return stm.GetBuffer();
		}

        public static byte[] GetPublicKeyBytes(RSAParameters paramsRSA)
        {
            MemoryStream stm = new MemoryStream();
            stm.Write(paramsRSA.Exponent, 0, paramsRSA.Exponent.Length);
            stm.Write(paramsRSA.Modulus, 0, paramsRSA.Modulus.Length);
            
            return stm.GetBuffer();
        }
	}
}
