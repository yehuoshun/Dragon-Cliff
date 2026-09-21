using System;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x0200002A RID: 42
	[Serializable]
	public struct ObscuredVector2
	{
		// Token: 0x060002AE RID: 686 RVA: 0x0000E094 File Offset: 0x0000C494
		private ObscuredVector2(Vector2 value)
		{
			this.currentCryptoKey = ObscuredVector2.cryptoKey;
			this.hiddenValue = ObscuredVector2.Encrypt(value);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? ObscuredVector2.zero : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000E0E4 File Offset: 0x0000C4E4
		public ObscuredVector2(float x, float y)
		{
			this.currentCryptoKey = ObscuredVector2.cryptoKey;
			this.hiddenValue = ObscuredVector2.Encrypt(x, y, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				this.fakeValue.x = x;
				this.fakeValue.y = y;
				this.fakeValueActive = true;
			}
			else
			{
				this.fakeValue = ObscuredVector2.zero;
				this.fakeValueActive = false;
			}
			this.inited = true;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x0000E158 File Offset: 0x0000C558
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x0000E1B8 File Offset: 0x0000C5B8
		public float x
		{
			get
			{
				float num = this.InternalDecryptField(this.hiddenValue.x);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && Math.Abs(num - this.fakeValue.x) > ObscuredCheatingDetector.Instance.vector2Epsilon)
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
					this.fakeValueActive = true;
				}
				else
				{
					this.fakeValueActive = false;
				}
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000E21C File Offset: 0x0000C61C
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x0000E27C File Offset: 0x0000C67C
		public float y
		{
			get
			{
				float num = this.InternalDecryptField(this.hiddenValue.y);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && Math.Abs(num - this.fakeValue.y) > ObscuredCheatingDetector.Instance.vector2Epsilon)
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
					this.fakeValueActive = true;
				}
				else
				{
					this.fakeValueActive = false;
				}
			}
		}

		// Token: 0x1700001A RID: 26
		public float this[int index]
		{
			get
			{
				if (index == 0)
				{
					return this.x;
				}
				if (index != 1)
				{
					throw new IndexOutOfRangeException("Invalid ObscuredVector2 index!");
				}
				return this.y;
			}
			set
			{
				if (index != 0)
				{
					if (index != 1)
					{
						throw new IndexOutOfRangeException("Invalid ObscuredVector2 index!");
					}
					this.y = value;
				}
				else
				{
					this.x = value;
				}
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000E343 File Offset: 0x0000C743
		public static void SetNewCryptoKey(int newKey)
		{
			ObscuredVector2.cryptoKey = newKey;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000E34B File Offset: 0x0000C74B
		public static ObscuredVector2.RawEncryptedVector2 Encrypt(Vector2 value)
		{
			return ObscuredVector2.Encrypt(value, 0);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000E354 File Offset: 0x0000C754
		public static ObscuredVector2.RawEncryptedVector2 Encrypt(Vector2 value, int key)
		{
			return ObscuredVector2.Encrypt(value.x, value.y, key);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000E36C File Offset: 0x0000C76C
		public static ObscuredVector2.RawEncryptedVector2 Encrypt(float x, float y, int key)
		{
			if (key == 0)
			{
				key = ObscuredVector2.cryptoKey;
			}
			ObscuredVector2.RawEncryptedVector2 result;
			result.x = ObscuredFloat.Encrypt(x, key);
			result.y = ObscuredFloat.Encrypt(y, key);
			return result;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000E3A3 File Offset: 0x0000C7A3
		public static Vector2 Decrypt(ObscuredVector2.RawEncryptedVector2 value)
		{
			return ObscuredVector2.Decrypt(value, 0);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000E3AC File Offset: 0x0000C7AC
		public static Vector2 Decrypt(ObscuredVector2.RawEncryptedVector2 value, int key)
		{
			if (key == 0)
			{
				key = ObscuredVector2.cryptoKey;
			}
			Vector2 result;
			result.x = ObscuredFloat.Decrypt(value.x, key);
			result.y = ObscuredFloat.Decrypt(value.y, key);
			return result;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000E3EF File Offset: 0x0000C7EF
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredVector2.cryptoKey)
			{
				this.hiddenValue = ObscuredVector2.Encrypt(this.InternalDecrypt(), ObscuredVector2.cryptoKey);
				this.currentCryptoKey = ObscuredVector2.cryptoKey;
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000E424 File Offset: 0x0000C824
		public void RandomizeCryptoKey()
		{
			Vector2 value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0);
			this.hiddenValue = ObscuredVector2.Encrypt(value, this.currentCryptoKey);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000E46A File Offset: 0x0000C86A
		public ObscuredVector2.RawEncryptedVector2 GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			return this.hiddenValue;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000E478 File Offset: 0x0000C878
		public void SetEncrypted(ObscuredVector2.RawEncryptedVector2 encrypted)
		{
			this.inited = true;
			this.hiddenValue = encrypted;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredVector2.cryptoKey;
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

		// Token: 0x060002C0 RID: 704 RVA: 0x0000E4D2 File Offset: 0x0000C8D2
		public Vector2 GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000E4DC File Offset: 0x0000C8DC
		private Vector2 InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredVector2.cryptoKey;
				this.hiddenValue = ObscuredVector2.Encrypt(ObscuredVector2.zero);
				this.fakeValue = ObscuredVector2.zero;
				this.fakeValueActive = false;
				this.inited = true;
				return ObscuredVector2.zero;
			}
			Vector2 vector;
			vector.x = ObscuredFloat.Decrypt(this.hiddenValue.x, this.currentCryptoKey);
			vector.y = ObscuredFloat.Decrypt(this.hiddenValue.y, this.currentCryptoKey);
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && !this.CompareVectorsWithTolerance(vector, this.fakeValue))
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return vector;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000E59C File Offset: 0x0000C99C
		private bool CompareVectorsWithTolerance(Vector2 vector1, Vector2 vector2)
		{
			float vector2Epsilon = ObscuredCheatingDetector.Instance.vector2Epsilon;
			return Math.Abs(vector1.x - vector2.x) < vector2Epsilon && Math.Abs(vector1.y - vector2.y) < vector2Epsilon;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000E5E8 File Offset: 0x0000C9E8
		private float InternalDecryptField(int encrypted)
		{
			int key = ObscuredVector2.cryptoKey;
			if (this.currentCryptoKey != ObscuredVector2.cryptoKey)
			{
				key = this.currentCryptoKey;
			}
			return ObscuredFloat.Decrypt(encrypted, key);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000E61C File Offset: 0x0000CA1C
		private int InternalEncryptField(float encrypted)
		{
			return ObscuredFloat.Encrypt(encrypted, ObscuredVector2.cryptoKey);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000E636 File Offset: 0x0000CA36
		public static implicit operator ObscuredVector2(Vector2 value)
		{
			return new ObscuredVector2(value);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000E63E File Offset: 0x0000CA3E
		public static implicit operator Vector2(ObscuredVector2 value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000E648 File Offset: 0x0000CA48
		public static implicit operator Vector3(ObscuredVector2 value)
		{
			Vector2 vector = value.InternalDecrypt();
			return new Vector3(vector.x, vector.y, 0f);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000E678 File Offset: 0x0000CA78
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000E69C File Offset: 0x0000CA9C
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000E6C0 File Offset: 0x0000CAC0
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000E6DC File Offset: 0x0000CADC
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredVector2()
		{
		}

		// Token: 0x04000169 RID: 361
		private static int cryptoKey = 120206;

		// Token: 0x0400016A RID: 362
		private static readonly Vector2 zero = Vector2.zero;

		// Token: 0x0400016B RID: 363
		[SerializeField]
		private int currentCryptoKey;

		// Token: 0x0400016C RID: 364
		[SerializeField]
		private ObscuredVector2.RawEncryptedVector2 hiddenValue;

		// Token: 0x0400016D RID: 365
		[SerializeField]
		private bool inited;

		// Token: 0x0400016E RID: 366
		[SerializeField]
		private Vector2 fakeValue;

		// Token: 0x0400016F RID: 367
		[SerializeField]
		private bool fakeValueActive;

		// Token: 0x0200002B RID: 43
		[Serializable]
		public struct RawEncryptedVector2
		{
			// Token: 0x04000170 RID: 368
			public int x;

			// Token: 0x04000171 RID: 369
			public int y;
		}
	}
}
