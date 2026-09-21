using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000024 RID: 36
	[Serializable]
	public struct ObscuredSByte : IEquatable<ObscuredSByte>, IFormattable
	{
		// Token: 0x06000220 RID: 544 RVA: 0x0000C908 File Offset: 0x0000AD08
		private ObscuredSByte(sbyte value)
		{
			this.currentCryptoKey = ObscuredSByte.cryptoKey;
			this.hiddenValue = ObscuredSByte.EncryptDecrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0 : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000C953 File Offset: 0x0000AD53
		public static void SetNewCryptoKey(sbyte newKey)
		{
			ObscuredSByte.cryptoKey = newKey;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000C95B File Offset: 0x0000AD5B
		public static sbyte EncryptDecrypt(sbyte value)
		{
			return ObscuredSByte.EncryptDecrypt(value, 0);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000C964 File Offset: 0x0000AD64
		public static sbyte EncryptDecrypt(sbyte value, sbyte key)
		{
			if ((int)key == 0)
			{
				return (sbyte)((int)value ^ (int)ObscuredSByte.cryptoKey);
			}
			return (sbyte)((int)value ^ (int)key);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000C97E File Offset: 0x0000AD7E
		public void ApplyNewCryptoKey()
		{
			if ((int)this.currentCryptoKey != (int)ObscuredSByte.cryptoKey)
			{
				this.hiddenValue = ObscuredSByte.EncryptDecrypt(this.InternalDecrypt(), ObscuredSByte.cryptoKey);
				this.currentCryptoKey = ObscuredSByte.cryptoKey;
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000C9B4 File Offset: 0x0000ADB4
		public void RandomizeCryptoKey()
		{
			sbyte value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = (sbyte)UnityEngine.Random.Range(-128, 127);
			}
			while ((int)this.currentCryptoKey == 0);
			this.hiddenValue = ObscuredSByte.EncryptDecrypt(value, this.currentCryptoKey);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000C9F6 File Offset: 0x0000ADF6
		public sbyte GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000CA04 File Offset: 0x0000AE04
		public void SetEncrypted(sbyte encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if ((int)this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredSByte.cryptoKey;
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

		// Token: 0x06000228 RID: 552 RVA: 0x0000CA5F File Offset: 0x0000AE5F
		public sbyte GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000CA68 File Offset: 0x0000AE68
		private sbyte InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredSByte.cryptoKey;
				this.hiddenValue = ObscuredSByte.EncryptDecrypt(0);
				this.fakeValue = 0;
				this.fakeValueActive = false;
				this.inited = true;
				return 0;
			}
			sbyte b = ObscuredSByte.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && (int)b != (int)this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return b;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000CAEE File Offset: 0x0000AEEE
		public static implicit operator ObscuredSByte(sbyte value)
		{
			return new ObscuredSByte(value);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000CAF6 File Offset: 0x0000AEF6
		public static implicit operator sbyte(ObscuredSByte value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000CB00 File Offset: 0x0000AF00
		public static ObscuredSByte operator ++(ObscuredSByte input)
		{
			sbyte value = (sbyte)((int)input.InternalDecrypt() + 1);
			input.hiddenValue = ObscuredSByte.EncryptDecrypt(value, input.currentCryptoKey);
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

		// Token: 0x0600022D RID: 557 RVA: 0x0000CB58 File Offset: 0x0000AF58
		public static ObscuredSByte operator --(ObscuredSByte input)
		{
			sbyte value = (sbyte)((int)input.InternalDecrypt() - 1);
			input.hiddenValue = ObscuredSByte.EncryptDecrypt(value, input.currentCryptoKey);
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

		// Token: 0x0600022E RID: 558 RVA: 0x0000CBAD File Offset: 0x0000AFAD
		public override bool Equals(object obj)
		{
			return obj is ObscuredSByte && this.Equals((ObscuredSByte)obj);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000CBC8 File Offset: 0x0000AFC8
		public bool Equals(ObscuredSByte obj)
		{
			if ((int)this.currentCryptoKey == (int)obj.currentCryptoKey)
			{
				return (int)this.hiddenValue == (int)obj.hiddenValue;
			}
			return (int)ObscuredSByte.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey) == (int)ObscuredSByte.EncryptDecrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000CC24 File Offset: 0x0000B024
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000CC48 File Offset: 0x0000B048
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000CC64 File Offset: 0x0000B064
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000CC88 File Offset: 0x0000B088
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000CCA4 File Offset: 0x0000B0A4
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000CCC1 File Offset: 0x0000B0C1
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredSByte()
		{
		}

		// Token: 0x04000145 RID: 325
		private static sbyte cryptoKey = 112;

		// Token: 0x04000146 RID: 326
		private sbyte currentCryptoKey;

		// Token: 0x04000147 RID: 327
		private sbyte hiddenValue;

		// Token: 0x04000148 RID: 328
		private bool inited;

		// Token: 0x04000149 RID: 329
		private sbyte fakeValue;

		// Token: 0x0400014A RID: 330
		private bool fakeValueActive;
	}
}
