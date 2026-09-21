using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x02000022 RID: 34
	[Serializable]
	public struct ObscuredQuaternion
	{
		// Token: 0x0600020B RID: 523 RVA: 0x0000C430 File Offset: 0x0000A830
		private ObscuredQuaternion(Quaternion value)
		{
			this.currentCryptoKey = ObscuredQuaternion.cryptoKey;
			this.hiddenValue = ObscuredQuaternion.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? ObscuredQuaternion.identity : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000C480 File Offset: 0x0000A880
		public ObscuredQuaternion(float x, float y, float z, float w)
		{
			this.currentCryptoKey = ObscuredQuaternion.cryptoKey;
			this.hiddenValue = ObscuredQuaternion.Encrypt(x, y, z, w, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				this.fakeValue.x = x;
				this.fakeValue.y = y;
				this.fakeValue.z = z;
				this.fakeValue.w = w;
				this.fakeValueActive = true;
			}
			else
			{
				this.fakeValue = ObscuredQuaternion.identity;
				this.fakeValueActive = false;
			}
			this.inited = true;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000C50E File Offset: 0x0000A90E
		public static void SetNewCryptoKey(int newKey)
		{
			ObscuredQuaternion.cryptoKey = newKey;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000C516 File Offset: 0x0000A916
		public static ObscuredQuaternion.RawEncryptedQuaternion Encrypt(Quaternion value)
		{
			return ObscuredQuaternion.Encrypt(value, 0);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000C51F File Offset: 0x0000A91F
		public static ObscuredQuaternion.RawEncryptedQuaternion Encrypt(Quaternion value, int key)
		{
			return ObscuredQuaternion.Encrypt(value.x, value.y, value.z, value.w, key);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000C544 File Offset: 0x0000A944
		public static ObscuredQuaternion.RawEncryptedQuaternion Encrypt(float x, float y, float z, float w, int key)
		{
			if (key == 0)
			{
				key = ObscuredQuaternion.cryptoKey;
			}
			ObscuredQuaternion.RawEncryptedQuaternion result;
			result.x = ObscuredFloat.Encrypt(x, key);
			result.y = ObscuredFloat.Encrypt(y, key);
			result.z = ObscuredFloat.Encrypt(z, key);
			result.w = ObscuredFloat.Encrypt(w, key);
			return result;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000C59C File Offset: 0x0000A99C
		public static Quaternion Decrypt(ObscuredQuaternion.RawEncryptedQuaternion value)
		{
			return ObscuredQuaternion.Decrypt(value, 0);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000C5A8 File Offset: 0x0000A9A8
		public static Quaternion Decrypt(ObscuredQuaternion.RawEncryptedQuaternion value, int key)
		{
			if (key == 0)
			{
				key = ObscuredQuaternion.cryptoKey;
			}
			Quaternion result;
			result.x = ObscuredFloat.Decrypt(value.x, key);
			result.y = ObscuredFloat.Decrypt(value.y, key);
			result.z = ObscuredFloat.Decrypt(value.z, key);
			result.w = ObscuredFloat.Decrypt(value.w, key);
			return result;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000C613 File Offset: 0x0000AA13
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredQuaternion.cryptoKey)
			{
				this.hiddenValue = ObscuredQuaternion.Encrypt(this.InternalDecrypt(), ObscuredQuaternion.cryptoKey);
				this.currentCryptoKey = ObscuredQuaternion.cryptoKey;
			}
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000C648 File Offset: 0x0000AA48
		public void RandomizeCryptoKey()
		{
			Quaternion value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0);
			this.hiddenValue = ObscuredQuaternion.Encrypt(value, this.currentCryptoKey);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000C68E File Offset: 0x0000AA8E
		public ObscuredQuaternion.RawEncryptedQuaternion GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000C69C File Offset: 0x0000AA9C
		public void SetEncrypted(ObscuredQuaternion.RawEncryptedQuaternion encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredQuaternion.cryptoKey;
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

		// Token: 0x06000217 RID: 535 RVA: 0x0000C6F6 File Offset: 0x0000AAF6
		public Quaternion GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000C700 File Offset: 0x0000AB00
		private Quaternion InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredQuaternion.cryptoKey;
				this.hiddenValue = ObscuredQuaternion.Encrypt(ObscuredQuaternion.identity);
				this.fakeValue = ObscuredQuaternion.identity;
				this.fakeValueActive = false;
				this.inited = true;
				return ObscuredQuaternion.identity;
			}
			Quaternion quaternion;
			quaternion.x = ObscuredFloat.Decrypt(this.hiddenValue.x, this.currentCryptoKey);
			quaternion.y = ObscuredFloat.Decrypt(this.hiddenValue.y, this.currentCryptoKey);
			quaternion.z = ObscuredFloat.Decrypt(this.hiddenValue.z, this.currentCryptoKey);
			quaternion.w = ObscuredFloat.Decrypt(this.hiddenValue.w, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && !this.CompareQuaternionsWithTolerance(quaternion, this.fakeValue))
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return quaternion;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000C7F8 File Offset: 0x0000ABF8
		private bool CompareQuaternionsWithTolerance(Quaternion q1, Quaternion q2)
		{
			float quaternionEpsilon = ObscuredCheatingDetector.Instance.quaternionEpsilon;
			return Math.Abs(q1.x - q2.x) < quaternionEpsilon && Math.Abs(q1.y - q2.y) < quaternionEpsilon && Math.Abs(q1.z - q2.z) < quaternionEpsilon && Math.Abs(q1.w - q2.w) < quaternionEpsilon;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000C878 File Offset: 0x0000AC78
		public static implicit operator ObscuredQuaternion(Quaternion value)
		{
			return new ObscuredQuaternion(value);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000C880 File Offset: 0x0000AC80
		public static implicit operator Quaternion(ObscuredQuaternion value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000C88C File Offset: 0x0000AC8C
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000C8B0 File Offset: 0x0000ACB0
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000C8D4 File Offset: 0x0000ACD4
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000C8F0 File Offset: 0x0000ACF0
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredQuaternion()
		{
		}

		// Token: 0x0400013A RID: 314
		private static int cryptoKey = 120205;

		// Token: 0x0400013B RID: 315
		private static readonly Quaternion identity = Quaternion.identity;

		// Token: 0x0400013C RID: 316
		[SerializeField]
		private int currentCryptoKey;

		// Token: 0x0400013D RID: 317
		[SerializeField]
		private ObscuredQuaternion.RawEncryptedQuaternion hiddenValue;

		// Token: 0x0400013E RID: 318
		[SerializeField]
		private bool inited;

		// Token: 0x0400013F RID: 319
		[SerializeField]
		private Quaternion fakeValue;

		// Token: 0x04000140 RID: 320
		[SerializeField]
		private bool fakeValueActive;

		// Token: 0x02000023 RID: 35
		[Serializable]
		public struct RawEncryptedQuaternion
		{
			// Token: 0x04000141 RID: 321
			public int x;

			// Token: 0x04000142 RID: 322
			public int y;

			// Token: 0x04000143 RID: 323
			public int z;

			// Token: 0x04000144 RID: 324
			public int w;
		}
	}
}
