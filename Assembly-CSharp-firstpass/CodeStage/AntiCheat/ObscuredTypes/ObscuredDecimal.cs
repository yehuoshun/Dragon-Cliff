using System;
using System.Runtime.InteropServices;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000016 RID: 22
	[Serializable]
	public struct ObscuredDecimal : IEquatable<ObscuredDecimal>, IFormattable
	{
		// Token: 0x0600011D RID: 285 RVA: 0x000094C4 File Offset: 0x000078C4
		private ObscuredDecimal(decimal value)
		{
			this.currentCryptoKey = ObscuredDecimal.cryptoKey;
			this.hiddenValue = ObscuredDecimal.InternalEncrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0m : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00009514 File Offset: 0x00007914
		public static void SetNewCryptoKey(long newKey)
		{
			ObscuredDecimal.cryptoKey = newKey;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000951C File Offset: 0x0000791C
		public static decimal Encrypt(decimal value)
		{
			return ObscuredDecimal.Encrypt(value, ObscuredDecimal.cryptoKey);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000952C File Offset: 0x0000792C
		public static decimal Encrypt(decimal value, long key)
		{
			ObscuredDecimal.DecimalLongBytesUnion decimalLongBytesUnion = default(ObscuredDecimal.DecimalLongBytesUnion);
			decimalLongBytesUnion.d = value;
			decimalLongBytesUnion.l1 ^= key;
			decimalLongBytesUnion.l2 ^= key;
			return decimalLongBytesUnion.d;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00009570 File Offset: 0x00007970
		private static ACTkByte16 InternalEncrypt(decimal value)
		{
			return ObscuredDecimal.InternalEncrypt(value, 0L);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000957C File Offset: 0x0000797C
		private static ACTkByte16 InternalEncrypt(decimal value, long key)
		{
			long num = key;
			if (num == 0L)
			{
				num = ObscuredDecimal.cryptoKey;
			}
			ObscuredDecimal.DecimalLongBytesUnion decimalLongBytesUnion = default(ObscuredDecimal.DecimalLongBytesUnion);
			decimalLongBytesUnion.d = value;
			decimalLongBytesUnion.l1 ^= num;
			decimalLongBytesUnion.l2 ^= num;
			return decimalLongBytesUnion.b16;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000095D0 File Offset: 0x000079D0
		public static decimal Decrypt(decimal value)
		{
			return ObscuredDecimal.Decrypt(value, ObscuredDecimal.cryptoKey);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000095E0 File Offset: 0x000079E0
		public static decimal Decrypt(decimal value, long key)
		{
			ObscuredDecimal.DecimalLongBytesUnion decimalLongBytesUnion = default(ObscuredDecimal.DecimalLongBytesUnion);
			decimalLongBytesUnion.d = value;
			decimalLongBytesUnion.l1 ^= key;
			decimalLongBytesUnion.l2 ^= key;
			return decimalLongBytesUnion.d;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00009624 File Offset: 0x00007A24
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredDecimal.cryptoKey)
			{
				this.hiddenValue = ObscuredDecimal.InternalEncrypt(this.InternalDecrypt(), ObscuredDecimal.cryptoKey);
				this.currentCryptoKey = ObscuredDecimal.cryptoKey;
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00009658 File Offset: 0x00007A58
		public void RandomizeCryptoKey()
		{
			decimal value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = (long)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0L);
			this.hiddenValue = ObscuredDecimal.InternalEncrypt(value, this.currentCryptoKey);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000096A4 File Offset: 0x00007AA4
		public decimal GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			ObscuredDecimal.DecimalLongBytesUnion decimalLongBytesUnion = default(ObscuredDecimal.DecimalLongBytesUnion);
			decimalLongBytesUnion.b16 = this.hiddenValue;
			return decimalLongBytesUnion.d;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000096D4 File Offset: 0x00007AD4
		public void SetEncrypted(decimal encrypted)
		{
			this.inited = true;
			ObscuredDecimal.DecimalLongBytesUnion decimalLongBytesUnion = default(ObscuredDecimal.DecimalLongBytesUnion);
			decimalLongBytesUnion.d = encrypted;
			this.hiddenValue = decimalLongBytesUnion.b16;
			if (this.currentCryptoKey == 0L)
			{
				this.currentCryptoKey = ObscuredDecimal.cryptoKey;
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

		// Token: 0x06000129 RID: 297 RVA: 0x00009746 File Offset: 0x00007B46
		public decimal GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00009750 File Offset: 0x00007B50
		private decimal InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredDecimal.cryptoKey;
				this.hiddenValue = ObscuredDecimal.InternalEncrypt(0m);
				this.fakeValue = 0m;
				this.fakeValueActive = false;
				this.inited = true;
				return 0m;
			}
			ObscuredDecimal.DecimalLongBytesUnion decimalLongBytesUnion = default(ObscuredDecimal.DecimalLongBytesUnion);
			decimalLongBytesUnion.b16 = this.hiddenValue;
			decimalLongBytesUnion.l1 ^= this.currentCryptoKey;
			decimalLongBytesUnion.l2 ^= this.currentCryptoKey;
			decimal d = decimalLongBytesUnion.d;
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && d != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return d;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000981D File Offset: 0x00007C1D
		public static implicit operator ObscuredDecimal(decimal value)
		{
			return new ObscuredDecimal(value);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00009825 File Offset: 0x00007C25
		public static implicit operator decimal(ObscuredDecimal value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000982E File Offset: 0x00007C2E
		public static explicit operator ObscuredDecimal(ObscuredFloat f)
		{
			return (decimal)f;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00009840 File Offset: 0x00007C40
		public static ObscuredDecimal operator ++(ObscuredDecimal input)
		{
			decimal value = input.InternalDecrypt() + 1m;
			input.hiddenValue = ObscuredDecimal.InternalEncrypt(value, input.currentCryptoKey);
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

		// Token: 0x0600012F RID: 303 RVA: 0x0000989C File Offset: 0x00007C9C
		public static ObscuredDecimal operator --(ObscuredDecimal input)
		{
			decimal value = input.InternalDecrypt() - 1m;
			input.hiddenValue = ObscuredDecimal.InternalEncrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000130 RID: 304 RVA: 0x000098F8 File Offset: 0x00007CF8
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000991C File Offset: 0x00007D1C
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00009938 File Offset: 0x00007D38
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00009954 File Offset: 0x00007D54
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00009971 File Offset: 0x00007D71
		public override bool Equals(object obj)
		{
			return obj is ObscuredDecimal && this.Equals((ObscuredDecimal)obj);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000998C File Offset: 0x00007D8C
		public bool Equals(ObscuredDecimal obj)
		{
			return obj.InternalDecrypt().Equals(this.InternalDecrypt());
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000099B0 File Offset: 0x00007DB0
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000099D1 File Offset: 0x00007DD1
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredDecimal()
		{
		}

		// Token: 0x040000EC RID: 236
		private static long cryptoKey = 209208L;

		// Token: 0x040000ED RID: 237
		[SerializeField]
		private long currentCryptoKey;

		// Token: 0x040000EE RID: 238
		[SerializeField]
		private ACTkByte16 hiddenValue;

		// Token: 0x040000EF RID: 239
		[SerializeField]
		private bool inited;

		// Token: 0x040000F0 RID: 240
		private decimal fakeValue;

		// Token: 0x040000F1 RID: 241
		[SerializeField]
		private bool fakeValueActive;

		// Token: 0x02000017 RID: 23
		[StructLayout(LayoutKind.Explicit)]
		private struct DecimalLongBytesUnion
		{
			// Token: 0x040000F2 RID: 242
			[FieldOffset(0)]
			public decimal d;

			// Token: 0x040000F3 RID: 243
			[FieldOffset(0)]
			public long l1;

			// Token: 0x040000F4 RID: 244
			[FieldOffset(8)]
			public long l2;

			// Token: 0x040000F5 RID: 245
			[FieldOffset(0)]
			public ACTkByte16 b16;
		}
	}
}
