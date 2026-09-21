using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000015 RID: 21
	[Serializable]
	public struct ObscuredChar : IEquatable<ObscuredChar>
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00009150 File Offset: 0x00007550
		private ObscuredChar(char value)
		{
			this.currentCryptoKey = ObscuredChar.cryptoKey;
			this.hiddenValue = ObscuredChar.EncryptDecrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? '\0' : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000919B File Offset: 0x0000759B
		public static void SetNewCryptoKey(char newKey)
		{
			ObscuredChar.cryptoKey = newKey;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000091A3 File Offset: 0x000075A3
		public static char EncryptDecrypt(char value)
		{
			return ObscuredChar.EncryptDecrypt(value, '\0');
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000091AC File Offset: 0x000075AC
		public static char EncryptDecrypt(char value, char key)
		{
			if (key == '\0')
			{
				return value ^ ObscuredChar.cryptoKey;
			}
			return value ^ key;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000091C1 File Offset: 0x000075C1
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredChar.cryptoKey)
			{
				this.hiddenValue = ObscuredChar.EncryptDecrypt(this.InternalDecrypt(), ObscuredChar.cryptoKey);
				this.currentCryptoKey = ObscuredChar.cryptoKey;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000091F4 File Offset: 0x000075F4
		public void RandomizeCryptoKey()
		{
			char value = this.InternalDecrypt();
			this.currentCryptoKey = (char)UnityEngine.Random.Range(1, 65535);
			this.hiddenValue = ObscuredChar.EncryptDecrypt(value, this.currentCryptoKey);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000922C File Offset: 0x0000762C
		public char GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000923C File Offset: 0x0000763C
		public void SetEncrypted(char encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == '\0')
			{
				this.currentCryptoKey = ObscuredChar.cryptoKey;
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

		// Token: 0x06000111 RID: 273 RVA: 0x00009296 File Offset: 0x00007696
		public char GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000092A0 File Offset: 0x000076A0
		private char InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredChar.cryptoKey;
				this.hiddenValue = ObscuredChar.EncryptDecrypt('\0');
				this.fakeValue = '\0';
				this.fakeValueActive = false;
				this.inited = true;
				return '\0';
			}
			char c = ObscuredChar.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && c != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return c;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00009324 File Offset: 0x00007724
		public static implicit operator ObscuredChar(char value)
		{
			return new ObscuredChar(value);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000932C File Offset: 0x0000772C
		public static implicit operator char(ObscuredChar value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00009338 File Offset: 0x00007738
		public static ObscuredChar operator ++(ObscuredChar input)
		{
			char value = input.InternalDecrypt() + '\u0001';
			input.hiddenValue = ObscuredChar.EncryptDecrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000116 RID: 278 RVA: 0x0000938C File Offset: 0x0000778C
		public static ObscuredChar operator --(ObscuredChar input)
		{
			char value = input.InternalDecrypt() - '\u0001';
			input.hiddenValue = ObscuredChar.EncryptDecrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000117 RID: 279 RVA: 0x000093E0 File Offset: 0x000077E0
		public override bool Equals(object obj)
		{
			return obj is ObscuredChar && this.Equals((ObscuredChar)obj);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000093FC File Offset: 0x000077FC
		public bool Equals(ObscuredChar obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredChar.EncryptDecrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredChar.EncryptDecrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00009454 File Offset: 0x00007854
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00009478 File Offset: 0x00007878
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00009494 File Offset: 0x00007894
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000094B5 File Offset: 0x000078B5
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredChar()
		{
		}

		// Token: 0x040000E6 RID: 230
		private static char cryptoKey = '—';

		// Token: 0x040000E7 RID: 231
		private char currentCryptoKey;

		// Token: 0x040000E8 RID: 232
		private char hiddenValue;

		// Token: 0x040000E9 RID: 233
		private bool inited;

		// Token: 0x040000EA RID: 234
		private char fakeValue;

		// Token: 0x040000EB RID: 235
		private bool fakeValueActive;
	}
}
