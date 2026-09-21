using System;
using System.Runtime.InteropServices;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000018 RID: 24
	[Serializable]
	public struct ObscuredDouble : IEquatable<ObscuredDouble>, IFormattable
	{
		// Token: 0x06000138 RID: 312 RVA: 0x000099E0 File Offset: 0x00007DE0
		private ObscuredDouble(double value)
		{
			this.currentCryptoKey = ObscuredDouble.cryptoKey;
			this.hiddenValue = ObscuredDouble.InternalEncrypt(value);
			this.hiddenValueOld = null;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0.0 : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00009A3A File Offset: 0x00007E3A
		public static void SetNewCryptoKey(long newKey)
		{
			ObscuredDouble.cryptoKey = newKey;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00009A42 File Offset: 0x00007E42
		public static long Encrypt(double value)
		{
			return ObscuredDouble.Encrypt(value, ObscuredDouble.cryptoKey);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00009A50 File Offset: 0x00007E50
		public static long Encrypt(double value, long key)
		{
			ObscuredDouble.DoubleLongBytesUnion doubleLongBytesUnion = default(ObscuredDouble.DoubleLongBytesUnion);
			doubleLongBytesUnion.d = value;
			doubleLongBytesUnion.l ^= key;
			return doubleLongBytesUnion.l;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00009A84 File Offset: 0x00007E84
		private static ACTkByte8 InternalEncrypt(double value)
		{
			return ObscuredDouble.InternalEncrypt(value, 0L);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00009A90 File Offset: 0x00007E90
		private static ACTkByte8 InternalEncrypt(double value, long key)
		{
			long num = key;
			if (num == 0L)
			{
				num = ObscuredDouble.cryptoKey;
			}
			ObscuredDouble.DoubleLongBytesUnion doubleLongBytesUnion = default(ObscuredDouble.DoubleLongBytesUnion);
			doubleLongBytesUnion.d = value;
			doubleLongBytesUnion.l ^= num;
			return doubleLongBytesUnion.b8;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00009AD4 File Offset: 0x00007ED4
		public static double Decrypt(long value)
		{
			return ObscuredDouble.Decrypt(value, ObscuredDouble.cryptoKey);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00009AE4 File Offset: 0x00007EE4
		public static double Decrypt(long value, long key)
		{
			ObscuredDouble.DoubleLongBytesUnion doubleLongBytesUnion = default(ObscuredDouble.DoubleLongBytesUnion);
			doubleLongBytesUnion.l = (value ^ key);
			return doubleLongBytesUnion.d;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00009B0A File Offset: 0x00007F0A
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredDouble.cryptoKey)
			{
				this.hiddenValue = ObscuredDouble.InternalEncrypt(this.InternalDecrypt(), ObscuredDouble.cryptoKey);
				this.currentCryptoKey = ObscuredDouble.cryptoKey;
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00009B40 File Offset: 0x00007F40
		public void RandomizeCryptoKey()
		{
			double value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = (long)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0L);
			this.hiddenValue = ObscuredDouble.InternalEncrypt(value, this.currentCryptoKey);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00009B8C File Offset: 0x00007F8C
		public long GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			ObscuredDouble.DoubleLongBytesUnion doubleLongBytesUnion = default(ObscuredDouble.DoubleLongBytesUnion);
			doubleLongBytesUnion.b8 = this.hiddenValue;
			return doubleLongBytesUnion.l;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00009BBC File Offset: 0x00007FBC
		public void SetEncrypted(long encrypted)
		{
			this.inited = true;
			ObscuredDouble.DoubleLongBytesUnion doubleLongBytesUnion = default(ObscuredDouble.DoubleLongBytesUnion);
			doubleLongBytesUnion.l = encrypted;
			this.hiddenValue = doubleLongBytesUnion.b8;
			if (this.currentCryptoKey == 0L)
			{
				this.currentCryptoKey = ObscuredDouble.cryptoKey;
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
			if (this.currentCryptoKey == 0L)
			{
				this.currentCryptoKey = ObscuredDouble.cryptoKey;
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00009C46 File Offset: 0x00008046
		public double GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00009C50 File Offset: 0x00008050
		private double InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredDouble.cryptoKey;
				this.hiddenValue = ObscuredDouble.InternalEncrypt(0.0);
				this.fakeValue = 0.0;
				this.fakeValueActive = false;
				this.inited = true;
				return 0.0;
			}
			ObscuredDouble.DoubleLongBytesUnion doubleLongBytesUnion = default(ObscuredDouble.DoubleLongBytesUnion);
			doubleLongBytesUnion.b8 = this.hiddenValue;
			doubleLongBytesUnion.l ^= this.currentCryptoKey;
			double d = doubleLongBytesUnion.d;
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && Math.Abs(d - this.fakeValue) > 1E-06)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return d;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00009D1B File Offset: 0x0000811B
		public static implicit operator ObscuredDouble(double value)
		{
			return new ObscuredDouble(value);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00009D23 File Offset: 0x00008123
		public static implicit operator double(ObscuredDouble value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00009D2C File Offset: 0x0000812C
		public static explicit operator ObscuredDouble(ObscuredFloat f)
		{
			return (double)f;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00009D3C File Offset: 0x0000813C
		public static ObscuredDouble operator ++(ObscuredDouble input)
		{
			double value = input.InternalDecrypt() + 1.0;
			input.hiddenValue = ObscuredDouble.InternalEncrypt(value, input.currentCryptoKey);
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

		// Token: 0x0600014A RID: 330 RVA: 0x00009D98 File Offset: 0x00008198
		public static ObscuredDouble operator --(ObscuredDouble input)
		{
			double value = input.InternalDecrypt() - 1.0;
			input.hiddenValue = ObscuredDouble.InternalEncrypt(value, input.currentCryptoKey);
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

		// Token: 0x0600014B RID: 331 RVA: 0x00009DF4 File Offset: 0x000081F4
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00009E18 File Offset: 0x00008218
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00009E34 File Offset: 0x00008234
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00009E50 File Offset: 0x00008250
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00009E6D File Offset: 0x0000826D
		public override bool Equals(object obj)
		{
			return obj is ObscuredDouble && this.Equals((ObscuredDouble)obj);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00009E88 File Offset: 0x00008288
		public bool Equals(ObscuredDouble obj)
		{
			return obj.InternalDecrypt().Equals(this.InternalDecrypt());
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00009EAC File Offset: 0x000082AC
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00009ECD File Offset: 0x000082CD
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredDouble()
		{
		}

		// Token: 0x040000F6 RID: 246
		private static long cryptoKey = 210987L;

		// Token: 0x040000F7 RID: 247
		[SerializeField]
		private long currentCryptoKey;

		// Token: 0x040000F8 RID: 248
		[SerializeField]
		private ACTkByte8 hiddenValue;

		// Token: 0x040000F9 RID: 249
		[SerializeField]
		[FormerlySerializedAs("hiddenValue")]
		private byte[] hiddenValueOld;

		// Token: 0x040000FA RID: 250
		[SerializeField]
		private bool inited;

		// Token: 0x040000FB RID: 251
		[SerializeField]
		private double fakeValue;

		// Token: 0x040000FC RID: 252
		[SerializeField]
		private bool fakeValueActive;

		// Token: 0x02000019 RID: 25
		[StructLayout(LayoutKind.Explicit)]
		private struct DoubleLongBytesUnion
		{
			// Token: 0x040000FD RID: 253
			[FieldOffset(0)]
			public double d;

			// Token: 0x040000FE RID: 254
			[FieldOffset(0)]
			public long l;

			// Token: 0x040000FF RID: 255
			[FieldOffset(0)]
			public ACTkByte8 b8;
		}
	}
}
