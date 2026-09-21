using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000027 RID: 39
	[Serializable]
	public struct ObscuredUInt : IEquatable<ObscuredUInt>, IFormattable
	{
		// Token: 0x06000267 RID: 615 RVA: 0x0000D538 File Offset: 0x0000B938
		private ObscuredUInt(uint value)
		{
			this.currentCryptoKey = ObscuredUInt.cryptoKey;
			this.hiddenValue = ObscuredUInt.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0u : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000D583 File Offset: 0x0000B983
		public static void SetNewCryptoKey(uint newKey)
		{
			ObscuredUInt.cryptoKey = newKey;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000D58B File Offset: 0x0000B98B
		public static uint Encrypt(uint value)
		{
			return ObscuredUInt.Encrypt(value, 0u);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000D594 File Offset: 0x0000B994
		public static uint Decrypt(uint value)
		{
			return ObscuredUInt.Decrypt(value, 0u);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000D59D File Offset: 0x0000B99D
		public static uint Encrypt(uint value, uint key)
		{
			if (key == 0u)
			{
				return value ^ ObscuredUInt.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000D5B0 File Offset: 0x0000B9B0
		public static uint Decrypt(uint value, uint key)
		{
			if (key == 0u)
			{
				return value ^ ObscuredUInt.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000D5C3 File Offset: 0x0000B9C3
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredUInt.cryptoKey)
			{
				this.hiddenValue = ObscuredUInt.Encrypt(this.InternalDecrypt(), ObscuredUInt.cryptoKey);
				this.currentCryptoKey = ObscuredUInt.cryptoKey;
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000D5F8 File Offset: 0x0000B9F8
		public void RandomizeCryptoKey()
		{
			uint value = this.InternalDecrypt();
			this.currentCryptoKey = (uint)UnityEngine.Random.Range(1, int.MaxValue);
			this.hiddenValue = ObscuredUInt.Encrypt(value, this.currentCryptoKey);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000D62F File Offset: 0x0000BA2F
		public uint GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000D640 File Offset: 0x0000BA40
		public void SetEncrypted(uint encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0u)
			{
				this.currentCryptoKey = ObscuredUInt.cryptoKey;
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

		// Token: 0x06000271 RID: 625 RVA: 0x0000D69A File Offset: 0x0000BA9A
		public uint GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000D6A4 File Offset: 0x0000BAA4
		private uint InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredUInt.cryptoKey;
				this.hiddenValue = ObscuredUInt.Encrypt(0u);
				this.fakeValue = 0u;
				this.fakeValueActive = false;
				this.inited = true;
				return 0u;
			}
			uint num = ObscuredUInt.Decrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && num != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return num;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000D728 File Offset: 0x0000BB28
		public static implicit operator ObscuredUInt(uint value)
		{
			return new ObscuredUInt(value);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000D730 File Offset: 0x0000BB30
		public static implicit operator uint(ObscuredUInt value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000D739 File Offset: 0x0000BB39
		public static explicit operator ObscuredInt(ObscuredUInt value)
		{
			return (int)value.InternalDecrypt();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000D748 File Offset: 0x0000BB48
		public static ObscuredUInt operator ++(ObscuredUInt input)
		{
			uint value = input.InternalDecrypt() + 1u;
			input.hiddenValue = ObscuredUInt.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000277 RID: 631 RVA: 0x0000D79C File Offset: 0x0000BB9C
		public static ObscuredUInt operator --(ObscuredUInt input)
		{
			uint value = input.InternalDecrypt() - 1u;
			input.hiddenValue = ObscuredUInt.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000278 RID: 632 RVA: 0x0000D7EF File Offset: 0x0000BBEF
		public override bool Equals(object obj)
		{
			return obj is ObscuredUInt && this.Equals((ObscuredUInt)obj);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000D80C File Offset: 0x0000BC0C
		public bool Equals(ObscuredUInt obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredUInt.Decrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredUInt.Decrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000D864 File Offset: 0x0000BC64
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000D888 File Offset: 0x0000BC88
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000D8A4 File Offset: 0x0000BCA4
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000D8C8 File Offset: 0x0000BCC8
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000D8E4 File Offset: 0x0000BCE4
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000D901 File Offset: 0x0000BD01
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredUInt()
		{
		}

		// Token: 0x04000157 RID: 343
		private static uint cryptoKey = 240513u;

		// Token: 0x04000158 RID: 344
		[SerializeField]
		private uint currentCryptoKey;

		// Token: 0x04000159 RID: 345
		[SerializeField]
		private uint hiddenValue;

		// Token: 0x0400015A RID: 346
		[SerializeField]
		private bool inited;

		// Token: 0x0400015B RID: 347
		[SerializeField]
		private uint fakeValue;

		// Token: 0x0400015C RID: 348
		[SerializeField]
		private bool fakeValueActive;
	}
}
