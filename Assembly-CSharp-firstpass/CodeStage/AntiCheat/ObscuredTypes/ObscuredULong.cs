using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000028 RID: 40
	[Serializable]
	public struct ObscuredULong : IEquatable<ObscuredULong>, IFormattable
	{
		// Token: 0x06000280 RID: 640 RVA: 0x0000D910 File Offset: 0x0000BD10
		private ObscuredULong(ulong value)
		{
			this.currentCryptoKey = ObscuredULong.cryptoKey;
			this.hiddenValue = ObscuredULong.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0UL : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000D95C File Offset: 0x0000BD5C
		public static void SetNewCryptoKey(ulong newKey)
		{
			ObscuredULong.cryptoKey = newKey;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000D964 File Offset: 0x0000BD64
		public static ulong Encrypt(ulong value)
		{
			return ObscuredULong.Encrypt(value, 0UL);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000D96E File Offset: 0x0000BD6E
		public static ulong Decrypt(ulong value)
		{
			return ObscuredULong.Decrypt(value, 0UL);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000D978 File Offset: 0x0000BD78
		public static ulong Encrypt(ulong value, ulong key)
		{
			if (key == 0UL)
			{
				return value ^ ObscuredULong.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000D98D File Offset: 0x0000BD8D
		public static ulong Decrypt(ulong value, ulong key)
		{
			if (key == 0UL)
			{
				return value ^ ObscuredULong.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000D9A2 File Offset: 0x0000BDA2
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredULong.cryptoKey)
			{
				this.hiddenValue = ObscuredULong.Encrypt(this.InternalDecrypt(), ObscuredULong.cryptoKey);
				this.currentCryptoKey = ObscuredULong.cryptoKey;
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000D9D8 File Offset: 0x0000BDD8
		public void RandomizeCryptoKey()
		{
			ulong value = this.InternalDecrypt();
			this.currentCryptoKey = (ulong)((long)UnityEngine.Random.Range(1, int.MaxValue));
			this.hiddenValue = ObscuredULong.Encrypt(value, this.currentCryptoKey);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000DA10 File Offset: 0x0000BE10
		public ulong GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000DA20 File Offset: 0x0000BE20
		public void SetEncrypted(ulong encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0UL)
			{
				this.currentCryptoKey = ObscuredULong.cryptoKey;
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

		// Token: 0x0600028A RID: 650 RVA: 0x0000DA7C File Offset: 0x0000BE7C
		public ulong GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000DA84 File Offset: 0x0000BE84
		private ulong InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredULong.cryptoKey;
				this.hiddenValue = ObscuredULong.Encrypt(0UL);
				this.fakeValue = 0UL;
				this.fakeValueActive = false;
				this.inited = true;
				return 0UL;
			}
			ulong num = ObscuredULong.Decrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && num != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return num;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000DB0B File Offset: 0x0000BF0B
		public static implicit operator ObscuredULong(ulong value)
		{
			return new ObscuredULong(value);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000DB13 File Offset: 0x0000BF13
		public static implicit operator ulong(ObscuredULong value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000DB1C File Offset: 0x0000BF1C
		public static ObscuredULong operator ++(ObscuredULong input)
		{
			ulong value = input.InternalDecrypt() + 1UL;
			input.hiddenValue = ObscuredULong.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x0600028F RID: 655 RVA: 0x0000DB70 File Offset: 0x0000BF70
		public static ObscuredULong operator --(ObscuredULong input)
		{
			ulong value = input.InternalDecrypt() - 1UL;
			input.hiddenValue = ObscuredULong.Encrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000290 RID: 656 RVA: 0x0000DBC4 File Offset: 0x0000BFC4
		public override bool Equals(object obj)
		{
			return obj is ObscuredULong && this.Equals((ObscuredULong)obj);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000DBE0 File Offset: 0x0000BFE0
		public bool Equals(ObscuredULong obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredULong.Decrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredULong.Decrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000DC38 File Offset: 0x0000C038
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000DC5C File Offset: 0x0000C05C
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000DC80 File Offset: 0x0000C080
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000DC9C File Offset: 0x0000C09C
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000DCB8 File Offset: 0x0000C0B8
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000DCD5 File Offset: 0x0000C0D5
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredULong()
		{
		}

		// Token: 0x0400015D RID: 349
		private static ulong cryptoKey = 444443UL;

		// Token: 0x0400015E RID: 350
		[SerializeField]
		private ulong currentCryptoKey;

		// Token: 0x0400015F RID: 351
		[SerializeField]
		private ulong hiddenValue;

		// Token: 0x04000160 RID: 352
		[SerializeField]
		private bool inited;

		// Token: 0x04000161 RID: 353
		[SerializeField]
		private ulong fakeValue;

		// Token: 0x04000162 RID: 354
		[SerializeField]
		private bool fakeValueActive;
	}
}
