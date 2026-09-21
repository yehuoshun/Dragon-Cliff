using System;
using System.Runtime.InteropServices;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x0200001A RID: 26
	[Serializable]
	public struct ObscuredFloat : IEquatable<ObscuredFloat>, IFormattable
	{
		// Token: 0x06000153 RID: 339 RVA: 0x00009EDC File Offset: 0x000082DC
		private ObscuredFloat(float value)
		{
			this.currentCryptoKey = ObscuredFloat.cryptoKey;
			this.hiddenValue = ObscuredFloat.InternalEncrypt(value);
			this.hiddenValueOld = null;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			this.fakeValue = ((!existsAndIsRunning) ? 0f : value);
			this.fakeValueActive = existsAndIsRunning;
			this.inited = true;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00009F32 File Offset: 0x00008332
		public static void SetNewCryptoKey(int newKey)
		{
			ObscuredFloat.cryptoKey = newKey;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00009F3A File Offset: 0x0000833A
		public static int Encrypt(float value)
		{
			return ObscuredFloat.Encrypt(value, ObscuredFloat.cryptoKey);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00009F48 File Offset: 0x00008348
		public static int Encrypt(float value, int key)
		{
			ObscuredFloat.FloatIntBytesUnion floatIntBytesUnion = default(ObscuredFloat.FloatIntBytesUnion);
			floatIntBytesUnion.f = value;
			floatIntBytesUnion.i ^= key;
			return floatIntBytesUnion.i;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00009F7C File Offset: 0x0000837C
		private static ACTkByte4 InternalEncrypt(float value)
		{
			return ObscuredFloat.InternalEncrypt(value, 0);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00009F88 File Offset: 0x00008388
		private static ACTkByte4 InternalEncrypt(float value, int key)
		{
			int num = key;
			if (num == 0)
			{
				num = ObscuredFloat.cryptoKey;
			}
			ObscuredFloat.FloatIntBytesUnion floatIntBytesUnion = default(ObscuredFloat.FloatIntBytesUnion);
			floatIntBytesUnion.f = value;
			floatIntBytesUnion.i ^= num;
			return floatIntBytesUnion.b4;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00009FCA File Offset: 0x000083CA
		public static float Decrypt(int value)
		{
			return ObscuredFloat.Decrypt(value, ObscuredFloat.cryptoKey);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00009FD8 File Offset: 0x000083D8
		public static float Decrypt(int value, int key)
		{
			ObscuredFloat.FloatIntBytesUnion floatIntBytesUnion = default(ObscuredFloat.FloatIntBytesUnion);
			floatIntBytesUnion.i = (value ^ key);
			return floatIntBytesUnion.f;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00009FFE File Offset: 0x000083FE
		public void ApplyNewCryptoKey()
		{
			if (this.currentCryptoKey != ObscuredFloat.cryptoKey)
			{
				this.hiddenValue = ObscuredFloat.InternalEncrypt(this.InternalDecrypt(), ObscuredFloat.cryptoKey);
				this.currentCryptoKey = ObscuredFloat.cryptoKey;
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000A034 File Offset: 0x00008434
		public void RandomizeCryptoKey()
		{
			float value = this.InternalDecrypt();
			do
			{
				this.currentCryptoKey = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (this.currentCryptoKey == 0);
			this.hiddenValue = ObscuredFloat.InternalEncrypt(value, this.currentCryptoKey);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000A07C File Offset: 0x0000847C
		public int GetEncrypted()
		{
			this.ApplyNewCryptoKey();
			ObscuredFloat.FloatIntBytesUnion floatIntBytesUnion = default(ObscuredFloat.FloatIntBytesUnion);
			floatIntBytesUnion.b4 = this.hiddenValue;
			return floatIntBytesUnion.i;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000A0AC File Offset: 0x000084AC
		public void SetEncrypted(int encrypted)
		{
			this.inited = true;
			ObscuredFloat.FloatIntBytesUnion floatIntBytesUnion = default(ObscuredFloat.FloatIntBytesUnion);
			floatIntBytesUnion.i = encrypted;
			this.hiddenValue = floatIntBytesUnion.b4;
			if (this.currentCryptoKey == 0)
			{
				this.currentCryptoKey = ObscuredFloat.cryptoKey;
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

		// Token: 0x0600015F RID: 351 RVA: 0x0000A11C File Offset: 0x0000851C
		public float GetDecrypted()
		{
			return this.InternalDecrypt();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000A124 File Offset: 0x00008524
		private float InternalDecrypt()
		{
			if (!this.inited)
			{
				this.currentCryptoKey = ObscuredFloat.cryptoKey;
				this.hiddenValue = ObscuredFloat.InternalEncrypt(0f);
				this.fakeValue = 0f;
				this.fakeValueActive = false;
				this.inited = true;
				return 0f;
			}
			ObscuredFloat.FloatIntBytesUnion floatIntBytesUnion = default(ObscuredFloat.FloatIntBytesUnion);
			floatIntBytesUnion.b4 = this.hiddenValue;
			floatIntBytesUnion.i ^= this.currentCryptoKey;
			float f = floatIntBytesUnion.f;
			if (ObscuredCheatingDetector.ExistsAndIsRunning && this.fakeValueActive && Math.Abs(f - this.fakeValue) > ObscuredCheatingDetector.Instance.floatEpsilon)
			{
				ObscuredCheatingDetector.Instance.OnCheatingDetected();
			}
			return f;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000A1E4 File Offset: 0x000085E4
		public static implicit operator ObscuredFloat(float value)
		{
			return new ObscuredFloat(value);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000A1EC File Offset: 0x000085EC
		public static implicit operator float(ObscuredFloat value)
		{
			return value.InternalDecrypt();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000A1F8 File Offset: 0x000085F8
		public static ObscuredFloat operator ++(ObscuredFloat input)
		{
			float value = input.InternalDecrypt() + 1f;
			input.hiddenValue = ObscuredFloat.InternalEncrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000164 RID: 356 RVA: 0x0000A250 File Offset: 0x00008650
		public static ObscuredFloat operator --(ObscuredFloat input)
		{
			float value = input.InternalDecrypt() - 1f;
			input.hiddenValue = ObscuredFloat.InternalEncrypt(value, input.currentCryptoKey);
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

		// Token: 0x06000165 RID: 357 RVA: 0x0000A2A7 File Offset: 0x000086A7
		public override bool Equals(object obj)
		{
			return obj is ObscuredFloat && this.Equals((ObscuredFloat)obj);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000A2C4 File Offset: 0x000086C4
		public bool Equals(ObscuredFloat obj)
		{
			double num = (double)obj.InternalDecrypt();
			double obj2 = (double)this.InternalDecrypt();
			return num.Equals(obj2);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000A2EC File Offset: 0x000086EC
		public override int GetHashCode()
		{
			return this.InternalDecrypt().GetHashCode();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000A310 File Offset: 0x00008710
		public override string ToString()
		{
			return this.InternalDecrypt().ToString();
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000A334 File Offset: 0x00008734
		public string ToString(string format)
		{
			return this.InternalDecrypt().ToString(format);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000A350 File Offset: 0x00008750
		public string ToString(IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(provider);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000A36C File Offset: 0x0000876C
		public string ToString(string format, IFormatProvider provider)
		{
			return this.InternalDecrypt().ToString(format, provider);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000A389 File Offset: 0x00008789
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredFloat()
		{
		}

		// Token: 0x04000100 RID: 256
		private static int cryptoKey = 230887;

		// Token: 0x04000101 RID: 257
		[SerializeField]
		private int currentCryptoKey;

		// Token: 0x04000102 RID: 258
		[SerializeField]
		private ACTkByte4 hiddenValue;

		// Token: 0x04000103 RID: 259
		[SerializeField]
		[FormerlySerializedAs("hiddenValue")]
		private byte[] hiddenValueOld;

		// Token: 0x04000104 RID: 260
		[SerializeField]
		private bool inited;

		// Token: 0x04000105 RID: 261
		[SerializeField]
		private float fakeValue;

		// Token: 0x04000106 RID: 262
		[SerializeField]
		private bool fakeValueActive;

		// Token: 0x0200001B RID: 27
		[StructLayout(LayoutKind.Explicit)]
		private struct FloatIntBytesUnion
		{
			// Token: 0x04000107 RID: 263
			[FieldOffset(0)]
			public float f;

			// Token: 0x04000108 RID: 264
			[FieldOffset(0)]
			public int i;

			// Token: 0x04000109 RID: 265
			[FieldOffset(0)]
			public ACTkByte4 b4;
		}
	}
}
