using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000026 RID: 38
	[Serializable]
	public sealed class ObscuredString
	{
		// Token: 0x0600024C RID: 588 RVA: 0x0000D07D File Offset: 0x0000B47D
		private ObscuredString()
		{
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000D088 File Offset: 0x0000B488
		private ObscuredString(string value)
		{
			this.currentCryptoKey = ObscuredString.cryptoKey;
			this.hiddenValue = ObscuredString.InternalEncrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? null : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000D0D9 File Offset: 0x0000B4D9
		public static void SetNewCryptoKey(string newKey)
		{
			ObscuredString.cryptoKey = newKey;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000D0E1 File Offset: 0x0000B4E1
		public static string EncryptDecrypt(string value)
		{
			return ObscuredString.EncryptDecrypt(value, string.Empty);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000D0F0 File Offset: 0x0000B4F0
		public static string EncryptDecrypt(string value, string key)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(key))
			{
				key = ObscuredString.cryptoKey;
			}
			int length = key.Length;
			int length2 = value.Length;
			char[] array = new char[length2];
			for (int i = 0; i < length2; i++)
			{
				array[i] = (value[i] ^ key[i % length]);
			}
			return new string(array);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000D162 File Offset: 0x0000B562
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredString.cryptoKey)
			{
				this.hiddenValue = ObscuredString.InternalEncrypt(this.InternalDecrypt());
				this.currentCryptoKey = ObscuredString.cryptoKey;
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000D198 File Offset: 0x0000B598
		public void RandomizeCryptoKey()
		{
			string value = this.InternalDecrypt();
			this.currentCryptoKey = UnityEngine.Random.Range(int.MinValue, int.MaxValue).ToString();
			this.hiddenValue = ObscuredString.InternalEncrypt(value, this.currentCryptoKey);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000D1E1 File Offset: 0x0000B5E1
		public string GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return ObscuredString.GetString(this.hiddenValue);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000D1F4 File Offset: 0x0000B5F4
		public void SetEncrypted(string encrypted)
		{
			this.inited = true;
			this.hiddenValue = ObscuredString.GetBytes(encrypted);
			if (string.IsNullOrEmpty(this.currentCryptoKey))
			{
				this.currentCryptoKey = ObscuredString.cryptoKey;
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

		// Token: 0x06000255 RID: 597 RVA: 0x0000D258 File Offset: 0x0000B658
		public string GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000D260 File Offset: 0x0000B660
		private static byte[] InternalEncrypt(string value)
		{
			return ObscuredString.InternalEncrypt(value, ObscuredString.cryptoKey);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000D26D File Offset: 0x0000B66D
		private static byte[] InternalEncrypt(string value, string key)
		{
			return ObscuredString.GetBytes(ObscuredString.EncryptDecrypt(value, key));
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000D27C File Offset: 0x0000B67C
		private string InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredString.cryptoKey;
				this.hiddenValue = ObscuredString.InternalEncrypt(string.Empty);
				this.fakeValue = string.Empty;
				this.fakeValueActive = false;
				this.inited = true;
				return string.Empty;
			}
			string text = this.currentCryptoKey;
			if (string.IsNullOrEmpty(text))
			{
				text = ObscuredString.cryptoKey;
			}
			string text2 = ObscuredString.EncryptDecrypt(ObscuredString.GetString(this.hiddenValue), text);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && text2 != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return text2;
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0000D329 File Offset: 0x0000B729
		public int Length
		{
			get
			{
				return this.hiddenValue.Length / 2;
			}
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000D335 File Offset: 0x0000B735
		public static implicit operator ObscuredString(string value)
		{
			return (value != null) ? new ObscuredString(value) : null;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000D349 File Offset: 0x0000B749
		public static implicit operator string(ObscuredString value)
		{
			return (!(value == null)) ? value.InternalDecrypt() : null;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000D363 File Offset: 0x0000B763
		public override string ToString()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000D36C File Offset: 0x0000B76C
		public static bool operator ==(ObscuredString a, ObscuredString b)
		{
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			if (a.currentCryptoKey == b.currentCryptoKey)
			{
				return ObscuredString.ArraysEquals(a.hiddenValue, b.hiddenValue);
			}
			return string.Equals(a.InternalDecrypt(), b.InternalDecrypt());
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000D3CE File Offset: 0x0000B7CE
		public static bool operator !=(ObscuredString a, ObscuredString b)
		{
			return !(a == b);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000D3DA File Offset: 0x0000B7DA
		public override bool Equals(object obj)
		{
			return obj is ObscuredString && this.Equals((ObscuredString)obj);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000D3F8 File Offset: 0x0000B7F8
		public bool Equals(ObscuredString value)
		{
			if (value == null)
			{
				return false;
			}
			if (this.currentCryptoKey == value.currentCryptoKey)
			{
				return ObscuredString.ArraysEquals(this.hiddenValue, value.hiddenValue);
			}
			return string.Equals(this.InternalDecrypt(), value.InternalDecrypt());
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000D44C File Offset: 0x0000B84C
		public bool Equals(ObscuredString value, StringComparison comparisonType)
		{
			return !(value == null) && string.Equals(this.InternalDecrypt(), value.InternalDecrypt(), comparisonType);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000D46E File Offset: 0x0000B86E
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000D47C File Offset: 0x0000B87C
		private static byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length * 2];
			Buffer.BlockCopy(str.ToCharArray(), 0, array, 0, array.Length);
			return array;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000D4AC File Offset: 0x0000B8AC
		private static string GetString(byte[] bytes)
		{
			char[] array = new char[bytes.Length / 2];
			Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
			return new string(array);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000D4D8 File Offset: 0x0000B8D8
		private static bool ArraysEquals(byte[] a1, byte[] a2)
		{
			if (a1 == a2)
			{
				return true;
			}
			if (a1 == null || a2 == null)
			{
				return false;
			}
			if (a1.Length != a2.Length)
			{
				return false;
			}
			for (int i = 0; i < a1.Length; i++)
			{
				if (a1[i] != a2[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000D52B File Offset: 0x0000B92B
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredString()
		{
		}

		// Token: 0x04000151 RID: 337
		private static string cryptoKey = "4441";

		// Token: 0x04000152 RID: 338
		[SerializeField]
		private string currentCryptoKey;

		// Token: 0x04000153 RID: 339
		[SerializeField]
		private byte[] hiddenValue;

		// Token: 0x04000154 RID: 340
		[SerializeField]
		private bool inited;

		// Token: 0x04000155 RID: 341
		[SerializeField]
		private string fakeValue;

		// Token: 0x04000156 RID: 342
		[SerializeField]
		private bool fakeValueActive;
	}
}
