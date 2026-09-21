using System;
using System.Collections.Generic;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000021 RID: 33
	internal class BitconverterExt
	{
		// Token: 0x06000208 RID: 520 RVA: 0x0000C38B File Offset: 0x0000A78B
		public BitconverterExt()
		{
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000C394 File Offset: 0x0000A794
		public static byte[] GetBytes(decimal dec)
		{
			int[] bits = decimal.GetBits(dec);
			List<byte> list = new List<byte>();
			foreach (int value in bits)
			{
				list.AddRange(BitConverter.GetBytes(value));
			}
			return list.ToArray();
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000C3E0 File Offset: 0x0000A7E0
		public static decimal ToDecimal(byte[] bytes)
		{
			if (bytes.Length != 16)
			{
				throw new Exception("[ACTk] A decimal must be created from exactly 16 bytes");
			}
			int[] array = new int[4];
			for (int i = 0; i <= 15; i += 4)
			{
				array[i / 4] = BitConverter.ToInt32(bytes, i);
			}
			return new decimal(array);
		}
	}
}
