using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000025 RID: 37
	[Serializable]
	public struct ObscuredShort : IEquatable<ObscuredShort>, IFormattable
	{
		// Token: 0x06000236 RID: 566 RVA: 0x0000CCCC File Offset: 0x0000B0CC
		private ObscuredShort(short value)
		{
			this.currentCryptoKey = ObscuredShort.cryptoKey;
			this.hiddenValue = ObscuredShort.EncryptDecrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0 : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000CD17 File Offset: 0x0000B117
		public static void SetNewCryptoKey(short newKey)
		{
			ObscuredShort.cryptoKey = newKey;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000CD1F File Offset: 0x0000B11F
		public static short EncryptDecrypt(short value)
		{
			return ObscuredShort.EncryptDecrypt(value, 0);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000CD28 File Offset: 0x0000B128
		public static short EncryptDecrypt(short value, short key)
		{
			if (key == 0)
			{
				return value ^ ObscuredShort.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000CD3D File Offset: 0x0000B13D
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredShort.cryptoKey)
			{
				this.hiddenValue = ObscuredShort.EncryptDecrypt(this.InternalDecrypt(), ObscuredShort.cryptoKey);
				this.currentCryptoKey = ObscuredShort.cryptoKey;
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000CD70 File Offset: 0x0000B170
		public void RandomizeCryptoKey()
		{
			short value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = (short)UnityEngine.Random.Range(-32768, 32767);
			}
			while (this.currentCryptoKey == 0);
			this.hiddenValue = ObscuredShort.EncryptDecrypt(value, this.currentCryptoKey);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000CDB7 File Offset: 0x0000B1B7
		public short GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000CDC8 File Offset: 0x0000B1C8
		public void SetEncrypted(short encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredShort.cryptoKey;
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

		// Token: 0x0600023E RID: 574 RVA: 0x0000CE22 File Offset: 0x0000B222
		public short GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000CE2C File Offset: 0x0000B22C
		private short InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredShort.cryptoKey;
				this.hiddenValue = ObscuredShort.EncryptDecrypt(0);
				this.fakeValue = 0;
				this.fakeValueActive = false;
				this.inited = true;
				return 0;
			}
			short num = ObscuredShort.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && num != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return num;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000CEB0 File Offset: 0x0000B2B0
		public static implicit operator ObscuredShort(short value)
		{
			return new ObscuredShort(value);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000CEB8 File Offset: 0x0000B2B8
		public static implicit operator short(ObscuredShort value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000CEC4 File Offset: 0x0000B2C4
		public static ObscuredShort operator ++(ObscuredShort input)
		{
			short value = input.InternalDecrypt() + 1;
			input.hiddenValue = ObscuredShort.EncryptDecrypt(value);
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

		// Token: 0x06000243 RID: 579 RVA: 0x0000CF14 File Offset: 0x0000B314
		public static ObscuredShort operator --(ObscuredShort input)
		{
			short value = input.InternalDecrypt() - 1;
			input.hiddenValue = ObscuredShort.EncryptDecrypt(value);
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

		// Token: 0x06000244 RID: 580 RVA: 0x0000CF61 File Offset: 0x0000B361
		public override bool Equals(object obj)
		{
			return obj is ObscuredShort && this.Equals((ObscuredShort)obj);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000CF7C File Offset: 0x0000B37C
		public bool Equals(ObscuredShort obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredShort.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredShort.EncryptDecrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000CFD4 File Offset: 0x0000B3D4
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000CFF8 File Offset: 0x0000B3F8
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000D014 File Offset: 0x0000B414
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000D038 File Offset: 0x0000B438
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000D054 File Offset: 0x0000B454
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000D071 File Offset: 0x0000B471
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredShort()
		{
		}

		// Token: 0x0400014B RID: 331
		private static short cryptoKey = 214;

		// Token: 0x0400014C RID: 332
		[SerializeField]
		private short currentCryptoKey;

		// Token: 0x0400014D RID: 333
		[SerializeField]
		private short hiddenValue;

		// Token: 0x0400014E RID: 334
		[SerializeField]
		private bool inited;

		// Token: 0x0400014F RID: 335
		[SerializeField]
		private short fakeValue;

		// Token: 0x04000150 RID: 336
		[SerializeField]
		private bool fakeValueActive;
	}
}
