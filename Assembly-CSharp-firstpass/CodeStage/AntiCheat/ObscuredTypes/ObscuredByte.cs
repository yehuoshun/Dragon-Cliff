using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000014 RID: 20
	[Serializable]
	public struct ObscuredByte : IEquatable<ObscuredByte>, IFormattable
	{
		// Token: 0x060000F1 RID: 241 RVA: 0x00008D50 File Offset: 0x00007150
		private ObscuredByte(byte value)
		{
			this.currentCryptoKey = ObscuredByte.cryptoKey;
			this.hiddenValue = ObscuredByte.EncryptDecrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0 : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008D9B File Offset: 0x0000719B
		public static void SetNewCryptoKey(byte newKey)
		{
			ObscuredByte.cryptoKey = newKey;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00008DA3 File Offset: 0x000071A3
		public static byte EncryptDecrypt(byte value)
		{
			return ObscuredByte.EncryptDecrypt(value, 0);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00008DAC File Offset: 0x000071AC
		public static void EncryptDecrypt(byte[] value)
		{
			ObscuredByte.EncryptDecrypt(value, 0);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00008DB5 File Offset: 0x000071B5
		public static byte EncryptDecrypt(byte value, byte key)
		{
			if (key == 0)
			{
				return value ^ ObscuredByte.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00008DCC File Offset: 0x000071CC
		public static void EncryptDecrypt(byte[] value, byte key)
		{
			int num = value.Length;
			for (int i = 0; i < num; i++)
			{
				if (key == 0)
				{
					value[i] ^= ObscuredByte.cryptoKey;
				}
				else
				{
					value[i] ^= key;
				}
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00008E10 File Offset: 0x00007210
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredByte.cryptoKey)
			{
				this.hiddenValue = ObscuredByte.EncryptDecrypt(this.InternalDecrypt(), ObscuredByte.cryptoKey);
				this.currentCryptoKey = ObscuredByte.cryptoKey;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00008E44 File Offset: 0x00007244
		public void RandomizeCryptoKey()
		{
			byte value = this.InternalDecrypt();
			this.currentCryptoKey = (byte)UnityEngine.Random.Range(1, 255);
			this.hiddenValue = ObscuredByte.EncryptDecrypt(value, this.currentCryptoKey);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00008E7C File Offset: 0x0000727C
		public byte GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00008E8C File Offset: 0x0000728C
		public void SetEncrypted(byte encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredByte.cryptoKey;
			}
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				this.fakeValue = this.InternalDecrypt();
				this.fakeValueActive = true;
			}
			else
			{
				this.fakeValueActive = false;
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00008EE6 File Offset: 0x000072E6
		public byte GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00008EF0 File Offset: 0x000072F0
		private byte InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredByte.cryptoKey;
				this.hiddenValue = ObscuredByte.EncryptDecrypt(0);
				this.fakeValue = 0;
				this.fakeValueActive = false;
				this.inited = true;
				return 0;
			}
			byte b = ObscuredByte.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && b != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return b;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00008F74 File Offset: 0x00007374
		public static implicit operator ObscuredByte(byte value)
		{
			return new ObscuredByte(value);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00008F7C File Offset: 0x0000737C
		public static implicit operator byte(ObscuredByte value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00008F88 File Offset: 0x00007388
		public static ObscuredByte operator ++(ObscuredByte input)
		{
			byte value = input.InternalDecrypt() + 1;
			input.hiddenValue = ObscuredByte.EncryptDecrypt(value, input.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				input.fakeValue = value;
				input.fakeValueActive = true;
			}
			else
			{
				input.fakeValueActive = false;
			}
			return input;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00008FDC File Offset: 0x000073DC
		public static ObscuredByte operator --(ObscuredByte input)
		{
			byte value = input.InternalDecrypt() - 1;
			input.hiddenValue = ObscuredByte.EncryptDecrypt(value, input.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				input.fakeValue = value;
				input.fakeValueActive = true;
			}
			else
			{
				input.fakeValueActive = false;
			}
			return input;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00009030 File Offset: 0x00007430
		public override bool Equals(object obj)
		{
			return obj is ObscuredByte && this.Equals((ObscuredByte)obj);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000904C File Offset: 0x0000744C
		public bool Equals(ObscuredByte obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredByte.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredByte.EncryptDecrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000090A4 File Offset: 0x000074A4
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000090C8 File Offset: 0x000074C8
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000090E4 File Offset: 0x000074E4
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00009108 File Offset: 0x00007508
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00009124 File Offset: 0x00007524
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00009141 File Offset: 0x00007541
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredByte()
		{
		}

		// Token: 0x040000E0 RID: 224
		private static byte cryptoKey = 244;

		// Token: 0x040000E1 RID: 225
		private byte currentCryptoKey;

		// Token: 0x040000E2 RID: 226
		private byte hiddenValue;

		// Token: 0x040000E3 RID: 227
		private bool inited;

		// Token: 0x040000E4 RID: 228
		private byte fakeValue;

		// Token: 0x040000E5 RID: 229
		private bool fakeValueActive;
	}
}
