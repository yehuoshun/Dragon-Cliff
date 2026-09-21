using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public struct ObscuredBool : IEquatable<ObscuredBool>
	{
		// Token: 0x060000DE RID: 222 RVA: 0x00008A50 File Offset: 0x00006E50
		private ObscuredBool(bool value)
		{
			this.currentCryptoKey = ObscuredBool.cryptoKey;
			this.hiddenValue = ObscuredBool.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = (existsAndIsRunning && value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00008A9B File Offset: 0x00006E9B
		public static void SetNewCryptoKey(byte newKey)
		{
			ObscuredBool.cryptoKey = newKey;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00008AA3 File Offset: 0x00006EA3
		public static int Encrypt(bool value)
		{
			return ObscuredBool.Encrypt(value, 0);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00008AAC File Offset: 0x00006EAC
		public static int Encrypt(bool value, byte key)
		{
			if (key == 0)
			{
				key = ObscuredBool.cryptoKey;
			}
			int num = (!value) ? 181 : 213;
			return num ^ (int)key;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00008AE1 File Offset: 0x00006EE1
		public static bool Decrypt(int value)
		{
			return ObscuredBool.Decrypt(value, 0);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00008AEA File Offset: 0x00006EEA
		public static bool Decrypt(int value, byte key)
		{
			if (key == 0)
			{
				key = ObscuredBool.cryptoKey;
			}
			value ^= (int)key;
			return value != 181;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00008B09 File Offset: 0x00006F09
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredBool.cryptoKey)
			{
				this.hiddenValue = ObscuredBool.Encrypt(this.InternalDecrypt(), ObscuredBool.cryptoKey);
				this.currentCryptoKey = ObscuredBool.cryptoKey;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00008B3C File Offset: 0x00006F3C
		public void RandomizeCryptoKey()
		{
			bool value = this.InternalDecrypt();
			this.currentCryptoKey = (byte)UnityEngine.Random.Range(1, 150);
			this.hiddenValue = ObscuredBool.Encrypt(value, this.currentCryptoKey);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00008B74 File Offset: 0x00006F74
		public int GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00008B84 File Offset: 0x00006F84
		public void SetEncrypted(int encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredBool.cryptoKey;
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

		// Token: 0x060000E8 RID: 232 RVA: 0x00008BDE File Offset: 0x00006FDE
		public bool GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00008BE8 File Offset: 0x00006FE8
		private bool InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredBool.cryptoKey;
				this.hiddenValue = ObscuredBool.Encrypt(false);
				this.fakeValue = false;
				this.fakeValueActive = false;
				this.inited = true;
				return false;
			}
			int num = this.hiddenValue;
			num ^= (int)this.currentCryptoKey;
			bool flag = num != 181;
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && flag != this.fakeValue)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return flag;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00008C76 File Offset: 0x00007076
		public static implicit operator ObscuredBool(bool value)
		{
			return new ObscuredBool(value);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00008C7E File Offset: 0x0000707E
		public static implicit operator bool(ObscuredBool value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00008C87 File Offset: 0x00007087
		public override bool Equals(object obj)
		{
			return obj is ObscuredBool && this.Equals((ObscuredBool)obj);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00008CA4 File Offset: 0x000070A4
		public bool Equals(ObscuredBool obj)
		{
			if (this.currentCryptoKey == obj.currentCryptoKey)
			{
				return this.hiddenValue == obj.hiddenValue;
			}
			return ObscuredBool.Decrypt(this.hiddenValue, this.currentCryptoKey) == ObscuredBool.Decrypt(obj.hiddenValue, obj.currentCryptoKey);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00008CFC File Offset: 0x000070FC
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00008D20 File Offset: 0x00007120
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00008D41 File Offset: 0x00007141
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredBool()
		{
		}

		// Token: 0x040000DA RID: 218
		private static byte cryptoKey = 215;

		// Token: 0x040000DB RID: 219
		[SerializeField]
		private byte currentCryptoKey;

		// Token: 0x040000DC RID: 220
		[SerializeField]
		private int hiddenValue;

		// Token: 0x040000DD RID: 221
		[SerializeField]
		private bool inited;

		// Token: 0x040000DE RID: 222
		[SerializeField]
		private bool fakeValue;

		// Token: 0x040000DF RID: 223
		[SerializeField]
		[FormerlySerializedAs("fakeValueChanged")]
		private bool fakeValueActive;
	}
}
