using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000029 RID: 41
	[Serializable]
	public struct ObscuredUShort : IEquatable<ObscuredUShort>, IFormattable
	{
		// Token: 0x06000298 RID: 664 RVA: 0x0000DCE4 File Offset: 0x0000C0E4
		private ObscuredUShort(ushort value)
		{
			this.currentCryptoKey = ObscuredUShort.cryptoKey;
			this.hiddenValue = ObscuredUShort.EncryptDecrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0 : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000DD2F File Offset: 0x0000C12F
		public static void SetNewCryptoKey(ushort newKey)
		{
			ObscuredUShort.cryptoKey = newKey;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000DD37 File Offset: 0x0000C137
		public static ushort EncryptDecrypt(ushort value)
		{
			return ObscuredUShort.EncryptDecrypt(value, 0);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000DD40 File Offset: 0x0000C140
		public static ushort EncryptDecrypt(ushort value, ushort key)
		{
			if (key == 0)
			{
				return value ^ ObscuredUShort.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000DD55 File Offset: 0x0000C155
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredUShort.cryptoKey)
			{
				this.hiddenValue = ObscuredUShort.EncryptDecrypt(this.InternalDecrypt(), ObscuredUShort.cryptoKey);
				this.currentCryptoKey = ObscuredUShort.cryptoKey;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000DD88 File Offset: 0x0000C188
		public void RandomizeCryptoKey()
		{
			ushort value = this.InternalDecrypt();
			this.currentCryptoKey = (ushort)UnityEngine.Random.Range(1, 32767);
			this.hiddenValue = ObscuredUShort.EncryptDecrypt(value, this.currentCryptoKey);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000DDC0 File Offset: 0x0000C1C0
		public ushort GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000DDD0 File Offset: 0x0000C1D0
		public void SetEncrypted(ushort encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredUShort.cryptoKey;
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

		// Token: 0x060002A0 RID: 672 RVA: 0x0000DE2A File Offset: 0x0000C22A
		public ushort GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000DE34 File Offset: 0x0000C234
		private ushort InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredUShort.cryptoKey;
				this.hiddenValue = ObscuredUShort.EncryptDecrypt(0);
				this.fakeValue = 0;
				this.fakeValueActive = false;
				this.inited = true;
				return 0;
			}
			ushort num = ObscuredUShort.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && num != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return num;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000DEB8 File Offset: 0x0000C2B8
		public static implicit operator ObscuredUShort(ushort value)
		{
			return new ObscuredUShort(value);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000DEC0 File Offset: 0x0000C2C0
		public static implicit operator ushort(ObscuredUShort value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000DECC File Offset: 0x0000C2CC
		public static ObscuredUShort operator ++(ObscuredUShort input)
		{
			ushort value = input.InternalDecrypt() + 1;
			input.hiddenValue = ObscuredUShort.EncryptDecrypt(value, input.currentCryptoKey);
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

		// Token: 0x060002A5 RID: 677 RVA: 0x0000DF20 File Offset: 0x0000C320
		public static ObscuredUShort operator --(ObscuredUShort input)
		{
			ushort value = input.InternalDecrypt() - 1;
			input.hiddenValue = ObscuredUShort.EncryptDecrypt(value, input.currentCryptoKey);
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

		// Token: 0x060002A6 RID: 678 RVA: 0x0000DF74 File Offset: 0x0000C374
		public override bool Equals(object obj)
		{
			return obj is ObscuredUShort && this.Equals((ObscuredUShort)obj);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000DF90 File Offset: 0x0000C390
		public bool Equals(ObscuredUShort obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredUShort.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredUShort.EncryptDecrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000DFE8 File Offset: 0x0000C3E8
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000E00C File Offset: 0x0000C40C
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000E028 File Offset: 0x0000C428
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000E04C File Offset: 0x0000C44C
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000E068 File Offset: 0x0000C468
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000E085 File Offset: 0x0000C485
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredUShort()
		{
		}

		// Token: 0x04000163 RID: 355
		private static ushort cryptoKey = 224;

		// Token: 0x04000164 RID: 356
		private ushort currentCryptoKey;

		// Token: 0x04000165 RID: 357
		private ushort hiddenValue;

		// Token: 0x04000166 RID: 358
		private bool inited;

		// Token: 0x04000167 RID: 359
		private ushort fakeValue;

		// Token: 0x04000168 RID: 360
		private bool fakeValueActive;
	}
}
