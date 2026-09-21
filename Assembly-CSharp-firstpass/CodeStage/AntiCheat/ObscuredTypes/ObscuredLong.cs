using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x0200001D RID: 29
	[Serializable]
	public struct ObscuredLong : IEquatable<ObscuredLong>, IFormattable
	{
		// Token: 0x06000188 RID: 392 RVA: 0x0000A7A8 File Offset: 0x00008BA8
		private ObscuredLong(long value)
		{
			this.currentCryptoKey = ObscuredLong.cryptoKey;
			this.hiddenValue = ObscuredLong.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0L : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000A7F4 File Offset: 0x00008BF4
		public static void SetNewCryptoKey(long newKey)
		{
			ObscuredLong.cryptoKey = newKey;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000A7FC File Offset: 0x00008BFC
		public static long Encrypt(long value)
		{
			return ObscuredLong.Encrypt(value, 0L);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000A806 File Offset: 0x00008C06
		public static long Decrypt(long value)
		{
			return ObscuredLong.Decrypt(value, 0L);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000A810 File Offset: 0x00008C10
		public static long Encrypt(long value, long key)
		{
			if (key == 0L)
			{
				return value ^ ObscuredLong.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000A825 File Offset: 0x00008C25
		public static long Decrypt(long value, long key)
		{
			if (key == 0L)
			{
				return value ^ ObscuredLong.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000A83A File Offset: 0x00008C3A
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredLong.cryptoKey)
			{
				this.hiddenValue = ObscuredLong.Encrypt(this.InternalDecrypt(), ObscuredLong.cryptoKey);
				this.currentCryptoKey = ObscuredLong.cryptoKey;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000A870 File Offset: 0x00008C70
		public void RandomizeCryptoKey()
		{
			long value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = (long)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0L);
			this.hiddenValue = ObscuredLong.Encrypt(value, this.currentCryptoKey);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000A8B9 File Offset: 0x00008CB9
		public long GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000A8C8 File Offset: 0x00008CC8
		public void SetEncrypted(long encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0L)
			{
				this.currentCryptoKey = ObscuredLong.cryptoKey;
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

		// Token: 0x06000192 RID: 402 RVA: 0x0000A924 File Offset: 0x00008D24
		public long GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000A92C File Offset: 0x00008D2C
		private long InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredLong.cryptoKey;
				this.hiddenValue = ObscuredLong.Encrypt(0L);
				this.fakeValue = 0L;
				this.fakeValueActive = false;
				this.inited = true;
				return 0L;
			}
			long num = ObscuredLong.Decrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && num != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return num;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000A9B3 File Offset: 0x00008DB3
		public static implicit operator ObscuredLong(long value)
		{
			return new ObscuredLong(value);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000A9BB File Offset: 0x00008DBB
		public static implicit operator long(ObscuredLong value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000A9C4 File Offset: 0x00008DC4
		public static ObscuredLong operator ++(ObscuredLong input)
		{
			long value = input.InternalDecrypt() + 1L;
			input.hiddenValue = ObscuredLong.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000197 RID: 407 RVA: 0x0000AA18 File Offset: 0x00008E18
		public static ObscuredLong operator --(ObscuredLong input)
		{
			long value = input.InternalDecrypt() - 1L;
			input.hiddenValue = ObscuredLong.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000198 RID: 408 RVA: 0x0000AA6C File Offset: 0x00008E6C
		public override bool Equals(object obj)
		{
			return obj is ObscuredLong && this.Equals((ObscuredLong)obj);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000AA88 File Offset: 0x00008E88
		public bool Equals(ObscuredLong obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredLong.Decrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredLong.Decrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000AAE0 File Offset: 0x00008EE0
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000AB04 File Offset: 0x00008F04
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000AB28 File Offset: 0x00008F28
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000AB44 File Offset: 0x00008F44
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000AB60 File Offset: 0x00008F60
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000AB7D File Offset: 0x00008F7D
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredLong()
		{
		}

		// Token: 0x04000110 RID: 272
		private static long cryptoKey = 444442L;

		// Token: 0x04000111 RID: 273
		[SerializeField]
		private long currentCryptoKey;

		// Token: 0x04000112 RID: 274
		[SerializeField]
		private long hiddenValue;

		// Token: 0x04000113 RID: 275
		[SerializeField]
		private bool inited;

		// Token: 0x04000114 RID: 276
		[SerializeField]
		private long fakeValue;

		// Token: 0x04000115 RID: 277
		[SerializeField]
		private bool fakeValueActive;
	}
}
