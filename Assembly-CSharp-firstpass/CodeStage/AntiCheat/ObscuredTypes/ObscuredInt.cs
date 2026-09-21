using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	public struct ObscuredInt : IEquatable<ObscuredInt>, IFormattable
	{
		// Token: 0x0600016D RID: 365 RVA: 0x0000A398 File Offset: 0x00008798
		private ObscuredInt(int value)
		{
			this.currentCryptoKey = ObscuredInt.cryptoKey;
			this.hiddenValue = ObscuredInt.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0 : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000A3E3 File Offset: 0x000087E3
		public static void SetNewCryptoKey(int newKey)
		{
			ObscuredInt.cryptoKey = newKey;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000A3EB File Offset: 0x000087EB
		public static int Encrypt(int value)
		{
			return ObscuredInt.Encrypt(value, 0);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000A3F4 File Offset: 0x000087F4
		public static int Encrypt(int value, int key)
		{
			if (key == 0)
			{
				return value ^ ObscuredInt.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000A407 File Offset: 0x00008807
		public static int Decrypt(int value)
		{
			return ObscuredInt.Decrypt(value, 0);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000A410 File Offset: 0x00008810
		public static int Decrypt(int value, int key)
		{
			if (key == 0)
			{
				return value ^ ObscuredInt.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000A423 File Offset: 0x00008823
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredInt.cryptoKey)
			{
				this.hiddenValue = ObscuredInt.Encrypt(this.InternalDecrypt(), ObscuredInt.cryptoKey);
				this.currentCryptoKey = ObscuredInt.cryptoKey;
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000A458 File Offset: 0x00008858
		public void RandomizeCryptoKey()
		{
			this.hiddenValue = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0);
			this.hiddenValue = ObscuredInt.Encrypt(this.hiddenValue, this.currentCryptoKey);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000A4A8 File Offset: 0x000088A8
		public int GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000A4B8 File Offset: 0x000088B8
		public void SetEncrypted(int encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredInt.cryptoKey;
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

		// Token: 0x06000177 RID: 375 RVA: 0x0000A512 File Offset: 0x00008912
		public int GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000A51C File Offset: 0x0000891C
		private int InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredInt.cryptoKey;
				this.hiddenValue = ObscuredInt.Encrypt(0);
				this.fakeValue = 0;
				this.fakeValueActive = false;
				this.inited = true;
				return 0;
			}
			int num = ObscuredInt.Decrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && num != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return num;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000A5A0 File Offset: 0x000089A0
		public static implicit operator ObscuredInt(int value)
		{
			return new ObscuredInt(value);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000A5A8 File Offset: 0x000089A8
		public static implicit operator int(ObscuredInt value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000A5B1 File Offset: 0x000089B1
		public static implicit operator ObscuredFloat(ObscuredInt value)
		{
			return (float)value.InternalDecrypt();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000A5C0 File Offset: 0x000089C0
		public static implicit operator ObscuredDouble(ObscuredInt value)
		{
			return (double)value.InternalDecrypt();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000A5CF File Offset: 0x000089CF
		public static explicit operator ObscuredUInt(ObscuredInt value)
		{
			return (uint)value.InternalDecrypt();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000A5E0 File Offset: 0x000089E0
		public static ObscuredInt operator ++(ObscuredInt input)
		{
			int value = input.InternalDecrypt() + 1;
			input.hiddenValue = ObscuredInt.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x0600017F RID: 383 RVA: 0x0000A634 File Offset: 0x00008A34
		public static ObscuredInt operator --(ObscuredInt input)
		{
			int value = input.InternalDecrypt() - 1;
			input.hiddenValue = ObscuredInt.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000180 RID: 384 RVA: 0x0000A687 File Offset: 0x00008A87
		public override bool Equals(object obj)
		{
			return obj is ObscuredInt && this.Equals((ObscuredInt)obj);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000A6A4 File Offset: 0x00008AA4
		public bool Equals(ObscuredInt obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredInt.Decrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredInt.Decrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000A6FC File Offset: 0x00008AFC
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000A720 File Offset: 0x00008B20
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000A744 File Offset: 0x00008B44
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000A760 File Offset: 0x00008B60
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000A77C File Offset: 0x00008B7C
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000A799 File Offset: 0x00008B99
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredInt()
		{
		}

		// Token: 0x0400010A RID: 266
		private static int cryptoKey = 444444;

		// Token: 0x0400010B RID: 267
		[SerializeField]
		private int currentCryptoKey;

		// Token: 0x0400010C RID: 268
		[SerializeField]
		private int hiddenValue;

		// Token: 0x0400010D RID: 269
		[SerializeField]
		private bool inited;

		// Token: 0x0400010E RID: 270
		[SerializeField]
		private int fakeValue;

		// Token: 0x0400010F RID: 271
		[SerializeField]
		private bool fakeValueActive;
	}
}
