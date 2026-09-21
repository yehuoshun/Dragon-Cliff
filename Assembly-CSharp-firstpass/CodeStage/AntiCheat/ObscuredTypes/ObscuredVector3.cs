using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x0200002C RID: 44
	[Serializable]
	public struct ObscuredVector3
	{
		// Token: 0x060002CC RID: 716 RVA: 0x0000E6F4 File Offset: 0x0000CAF4
		private ObscuredVector3(Vector3 value)
		{
			this.currentCryptoKey = ObscuredVector3.cryptoKey;
			this.hiddenValue = ObscuredVector3.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? ObscuredVector3.zero : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000E744 File Offset: 0x0000CB44
		public ObscuredVector3(float x, float y, float z)
		{
			this.currentCryptoKey = ObscuredVector3.cryptoKey;
			this.hiddenValue = ObscuredVector3.Encrypt(x, y, z, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				this.fakeValue.x = x;
				this.fakeValue.y = y;
				this.fakeValue.z = z;
				this.fakeValueActive = true;
			}
			else
			{
				this.fakeValue = ObscuredVector3.zero;
				this.fakeValueActive = false;
			}
			this.inited = true;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060002CE RID: 718 RVA: 0x0000E7C4 File Offset: 0x0000CBC4
		// (set) Token: 0x060002CF RID: 719 RVA: 0x0000E824 File Offset: 0x0000CC24
		public float x
		{
			get
			{
				float num = this.InternalDecryptField(this.hiddenValue.x);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && Math.Abs(num - this.fakeValue.x) > ObscuredCheatingDetector.Instance.vector3Epsilon)
				{
					ObscuredCheatingDetector.Instance.OnCheatingDetected();
				}
				return num;
			}
			set
			{
				this.hiddenValue.x = this.InternalEncryptField(value);
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					this.fakeValue.x = value;
					this.fakeValue.y = this.InternalDecryptField(this.hiddenValue.y);
					this.fakeValue.z = this.InternalDecryptField(this.hiddenValue.z);
					this.fakeValueActive = true;
				}
				else
				{
					this.fakeValueActive = false;
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x0000E8A4 File Offset: 0x0000CCA4
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x0000E904 File Offset: 0x0000CD04
		public float y
		{
			get
			{
				float num = this.InternalDecryptField(this.hiddenValue.y);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && Math.Abs(num - this.fakeValue.y) > ObscuredCheatingDetector.Instance.vector3Epsilon)
				{
					ObscuredCheatingDetector.Instance.OnCheatingDetected();
				}
				return num;
			}
			set
			{
				this.hiddenValue.y = this.InternalEncryptField(value);
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					this.fakeValue.x = this.InternalDecryptField(this.hiddenValue.x);
					this.fakeValue.y = value;
					this.fakeValue.z = this.InternalDecryptField(this.hiddenValue.z);
					this.fakeValueActive = true;
				}
				else
				{
					this.fakeValueActive = false;
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x0000E984 File Offset: 0x0000CD84
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x0000E9E4 File Offset: 0x0000CDE4
		public float z
		{
			get
			{
				float num = this.InternalDecryptField(this.hiddenValue.z);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && Math.Abs(num - this.fakeValue.z) > ObscuredCheatingDetector.Instance.vector3Epsilon)
				{
					ObscuredCheatingDetector.Instance.OnCheatingDetected();
				}
				return num;
			}
			set
			{
				this.hiddenValue.z = this.InternalEncryptField(value);
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					this.fakeValue.x = this.InternalDecryptField(this.hiddenValue.x);
					this.fakeValue.y = this.InternalDecryptField(this.hiddenValue.y);
					this.fakeValue.z = value;
					this.fakeValueActive = true;
				}
				else
				{
					this.fakeValueActive = false;
				}
			}
		}

		// Token: 0x1700001E RID: 30
		public float this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.x;
				case 1:
					return this.y;
				case 2:
					return this.z;
				default:
					throw new IndexOutOfRangeException("Invalid ObscuredVector3 index!");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.x = value;
					break;
				case 1:
					this.y = value;
					break;
				case 2:
					this.z = value;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid ObscuredVector3 index!");
				}
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000EAEF File Offset: 0x0000CEEF
		public static void SetNewCryptoKey(int newKey)
		{
			ObscuredVector3.cryptoKey = newKey;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000EAF7 File Offset: 0x0000CEF7
		public static ObscuredVector3.RawEncryptedVector3 Encrypt(Vector3 value)
		{
			return ObscuredVector3.Encrypt(value, 0);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000EB00 File Offset: 0x0000CF00
		public static ObscuredVector3.RawEncryptedVector3 Encrypt(Vector3 value, int key)
		{
			return ObscuredVector3.Encrypt(value.x, value.y, value.z, key);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000EB20 File Offset: 0x0000CF20
		public static ObscuredVector3.RawEncryptedVector3 Encrypt(float x, float y, float z, int key)
		{
			if (key == 0)
			{
				key = ObscuredVector3.cryptoKey;
			}
			ObscuredVector3.RawEncryptedVector3 result;
			result.x = ObscuredFloat.Encrypt(x, key);
			result.y = ObscuredFloat.Encrypt(y, key);
			result.z = ObscuredFloat.Encrypt(z, key);
			return result;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000EB65 File Offset: 0x0000CF65
		public static Vector3 Decrypt(ObscuredVector3.RawEncryptedVector3 value)
		{
			return ObscuredVector3.Decrypt(value, 0);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000EB70 File Offset: 0x0000CF70
		public static Vector3 Decrypt(ObscuredVector3.RawEncryptedVector3 value, int key)
		{
			if (key == 0)
			{
				key = ObscuredVector3.cryptoKey;
			}
			Vector3 result;
			result.x = ObscuredFloat.Decrypt(value.x, key);
			result.y = ObscuredFloat.Decrypt(value.y, key);
			result.z = ObscuredFloat.Decrypt(value.z, key);
			return result;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000EBC7 File Offset: 0x0000CFC7
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredVector3.cryptoKey)
			{
				this.hiddenValue = ObscuredVector3.Encrypt(this.InternalDecrypt(), ObscuredVector3.cryptoKey);
				this.currentCryptoKey = ObscuredVector3.cryptoKey;
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000EBFC File Offset: 0x0000CFFC
		public void RandomizeCryptoKey()
		{
			Vector3 value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0);
			this.hiddenValue = ObscuredVector3.Encrypt(value, this.currentCryptoKey);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000EC42 File Offset: 0x0000D042
		public ObscuredVector3.RawEncryptedVector3 GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000EC50 File Offset: 0x0000D050
		public void SetEncrypted(ObscuredVector3.RawEncryptedVector3 encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredVector3.cryptoKey;
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

		// Token: 0x060002E0 RID: 736 RVA: 0x0000ECAA File Offset: 0x0000D0AA
		public Vector3 GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000ECB4 File Offset: 0x0000D0B4
		private Vector3 InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredVector3.cryptoKey;
				this.hiddenValue = ObscuredVector3.Encrypt(ObscuredVector3.zero, ObscuredVector3.cryptoKey);
				this.fakeValue = ObscuredVector3.zero;
				this.fakeValueActive = false;
				this.inited = true;
				return ObscuredVector3.zero;
			}
			Vector3 vector;
			vector.x = ObscuredFloat.Decrypt(this.hiddenValue.x, this.currentCryptoKey);
			vector.y = ObscuredFloat.Decrypt(this.hiddenValue.y, this.currentCryptoKey);
			vector.z = ObscuredFloat.Decrypt(this.hiddenValue.z, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && !this.CompareVectorsWithTolerance(vector, this.fakeValue))
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return vector;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000ED94 File Offset: 0x0000D194
		private bool CompareVectorsWithTolerance(Vector3 vector1, Vector3 vector2)
		{
			float vector3Epsilon = ObscuredCheatingDetector.Instance.vector3Epsilon;
			return Math.Abs(vector1.x - vector2.x) < vector3Epsilon && Math.Abs(vector1.y - vector2.y) < vector3Epsilon && Math.Abs(vector1.z - vector2.z) < vector3Epsilon;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000EDFC File Offset: 0x0000D1FC
		private float InternalDecryptField(int encrypted)
		{
			int key = ObscuredVector3.cryptoKey;
			if (this.currentCryptoKey != ObscuredVector3.cryptoKey)
			{
				key = this.currentCryptoKey;
			}
			return ObscuredFloat.Decrypt(encrypted, key);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000EE30 File Offset: 0x0000D230
		private int InternalEncryptField(float encrypted)
		{
			return ObscuredFloat.Encrypt(encrypted, ObscuredVector3.cryptoKey);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000EE4A File Offset: 0x0000D24A
		public static implicit operator ObscuredVector3(Vector3 value)
		{
			return new ObscuredVector3(value);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000EE52 File Offset: 0x0000D252
		public static implicit operator Vector3(ObscuredVector3 value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000EE5B File Offset: 0x0000D25B
		public static ObscuredVector3 operator +(ObscuredVector3 a, ObscuredVector3 b)
		{
			return a.InternalDecrypt() + b.InternalDecrypt();
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000EE75 File Offset: 0x0000D275
		public static ObscuredVector3 operator +(Vector3 a, ObscuredVector3 b)
		{
			return a + b.InternalDecrypt();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000EE89 File Offset: 0x0000D289
		public static ObscuredVector3 operator +(ObscuredVector3 a, Vector3 b)
		{
			return a.InternalDecrypt() + b;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000EE9D File Offset: 0x0000D29D
		public static ObscuredVector3 operator -(ObscuredVector3 a, ObscuredVector3 b)
		{
			return a.InternalDecrypt() - b.InternalDecrypt();
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000EEB7 File Offset: 0x0000D2B7
		public static ObscuredVector3 operator -(Vector3 a, ObscuredVector3 b)
		{
			return a - b.InternalDecrypt();
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000EECB File Offset: 0x0000D2CB
		public static ObscuredVector3 operator -(ObscuredVector3 a, Vector3 b)
		{
			return a.InternalDecrypt() - b;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000EEDF File Offset: 0x0000D2DF
		public static ObscuredVector3 operator -(ObscuredVector3 a)
		{
			return -a.InternalDecrypt();
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000EEF2 File Offset: 0x0000D2F2
		public static ObscuredVector3 operator *(ObscuredVector3 a, float d)
		{
			return a.InternalDecrypt() * d;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000EF06 File Offset: 0x0000D306
		public static ObscuredVector3 operator *(float d, ObscuredVector3 a)
		{
			return d * a.InternalDecrypt();
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000EF1A File Offset: 0x0000D31A
		public static ObscuredVector3 operator /(ObscuredVector3 a, float d)
		{
			return a.InternalDecrypt() / d;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000EF2E File Offset: 0x0000D32E
		public static bool operator ==(ObscuredVector3 lhs, ObscuredVector3 rhs)
		{
			return lhs.InternalDecrypt() == rhs.InternalDecrypt();
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000EF43 File Offset: 0x0000D343
		public static bool operator ==(Vector3 lhs, ObscuredVector3 rhs)
		{
			return lhs == rhs.InternalDecrypt();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000EF52 File Offset: 0x0000D352
		public static bool operator ==(ObscuredVector3 lhs, Vector3 rhs)
		{
			return lhs.InternalDecrypt() == rhs;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000EF61 File Offset: 0x0000D361
		public static bool operator !=(ObscuredVector3 lhs, ObscuredVector3 rhs)
		{
			return lhs.InternalDecrypt() != rhs.InternalDecrypt();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000EF76 File Offset: 0x0000D376
		public static bool operator !=(Vector3 lhs, ObscuredVector3 rhs)
		{
			return lhs != rhs.InternalDecrypt();
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000EF85 File Offset: 0x0000D385
		public static bool operator !=(ObscuredVector3 lhs, Vector3 rhs)
		{
			return lhs.InternalDecrypt() != rhs;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000EF94 File Offset: 0x0000D394
		public override bool Equals(object other)
		{
			return this.InternalDecrypt().Equals(other);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000EFB8 File Offset: 0x0000D3B8
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000EFDC File Offset: 0x0000D3DC
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000F000 File Offset: 0x0000D400
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000F01C File Offset: 0x0000D41C
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredVector3()
		{
		}

		// Token: 0x04000172 RID: 370
		private static int cryptoKey = 120207;

		// Token: 0x04000173 RID: 371
		private static readonly Vector3 zero = Vector3.zero;

		// Token: 0x04000174 RID: 372
		[SerializeField]
		private int currentCryptoKey;

		// Token: 0x04000175 RID: 373
		[SerializeField]
		private ObscuredVector3.RawEncryptedVector3 hiddenValue;

		// Token: 0x04000176 RID: 374
		[SerializeField]
		private bool inited;

		// Token: 0x04000177 RID: 375
		[SerializeField]
		private Vector3 fakeValue;

		// Token: 0x04000178 RID: 376
		[SerializeField]
		private bool fakeValueActive;

		// Token: 0x0200002D RID: 45
		[Serializable]
		public struct RawEncryptedVector3
		{
			// Token: 0x04000179 RID: 377
			public int x;

			// Token: 0x0400017A RID: 378
			public int y;

			// Token: 0x0400017B RID: 379
			public int z;
		}
	}
}
