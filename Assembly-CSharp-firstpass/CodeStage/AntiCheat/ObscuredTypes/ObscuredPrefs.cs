using System;
using System.Text;
using CodeStage.AntiCheat.Utils;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	// Token: 0x0200001E RID: 30
	public static class ObscuredPrefs
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x0000AB92 File Offset: 0x00008F92
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x0000AB8A File Offset: 0x00008F8A
		public static string CryptoKey
		{
			get
			{
				return ObscuredPrefs.cryptoKey;
			}
			set
			{
				ObscuredPrefs.cryptoKey = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000AB99 File Offset: 0x00008F99
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x0000ABB9 File Offset: 0x00008FB9
		public static string DeviceId
		{
			get
			{
				if (string.IsNullOrEmpty(ObscuredPrefs.deviceId))
				{
					ObscuredPrefs.deviceId = ObscuredPrefs.GetDeviceId();
				}
				return ObscuredPrefs.deviceId;
			}
			set
			{
				ObscuredPrefs.deviceId = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x0000ABC1 File Offset: 0x00008FC1
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x0000ABC8 File Offset: 0x00008FC8
		[Obsolete("This property is obsolete, please use DeviceId instead.")]
		internal static string DeviceID
		{
			get
			{
				return ObscuredPrefs.DeviceId;
			}
			set
			{
				ObscuredPrefs.DeviceId = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000ABD0 File Offset: 0x00008FD0
		private static uint DeviceIdHash
		{
			get
			{
				if (ObscuredPrefs.deviceIdHash == 0u)
				{
					ObscuredPrefs.deviceIdHash = ObscuredPrefs.CalculateChecksum(ObscuredPrefs.DeviceId);
				}
				return ObscuredPrefs.deviceIdHash;
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000ABF0 File Offset: 0x00008FF0
		public static void ForceLockToDeviceInit()
		{
			if (string.IsNullOrEmpty(ObscuredPrefs.deviceId))
			{
				ObscuredPrefs.deviceId = ObscuredPrefs.GetDeviceId();
				ObscuredPrefs.deviceIdHash = ObscuredPrefs.CalculateChecksum(ObscuredPrefs.deviceId);
			}
			else
			{
				Debug.LogWarning("[ACTk] ObscuredPrefs.ForceLockToDeviceInit() is called, but device ID is already obtained!");
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000AC29 File Offset: 0x00009029
		[Obsolete("This method is obsolete, use property CryptoKey instead")]
		internal static void SetNewCryptoKey(string newKey)
		{
			ObscuredPrefs.CryptoKey = newKey;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000AC31 File Offset: 0x00009031
		public static void SetInt(string key, int value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptIntValue(key, value));
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000AC45 File Offset: 0x00009045
		public static int GetInt(string key)
		{
			return ObscuredPrefs.GetInt(key, 0);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000AC50 File Offset: 0x00009050
		public static int GetInt(string key, int defaultValue)
		{
			string text = ObscuredPrefs.EncryptKey(key);
			if (!PlayerPrefs.HasKey(text) && PlayerPrefs.HasKey(key))
			{
				int @int = PlayerPrefs.GetInt(key, defaultValue);
				if (!ObscuredPrefs.preservePlayerPrefs)
				{
					ObscuredPrefs.SetInt(key, @int);
					PlayerPrefs.DeleteKey(key);
				}
				return @int;
			}
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, text);
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptIntValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000ACC4 File Offset: 0x000090C4
		internal static string EncryptIntValue(string key, int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.Int);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000ACE0 File Offset: 0x000090E0
		internal static int DecryptIntValue(string key, string encryptedInput, int defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				int num;
				int.TryParse(text, out num);
				ObscuredPrefs.SetInt(key, num);
				return num;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitConverter.ToInt32(array, 0);
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000AD3F File Offset: 0x0000913F
		public static void SetUInt(string key, uint value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptUIntValue(key, value));
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000AD53 File Offset: 0x00009153
		public static uint GetUInt(string key)
		{
			return ObscuredPrefs.GetUInt(key, 0u);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000AD5C File Offset: 0x0000915C
		public static uint GetUInt(string key, uint defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptUIntValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000AD94 File Offset: 0x00009194
		private static string EncryptUIntValue(string key, uint value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.UInt);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000ADB4 File Offset: 0x000091B4
		private static uint DecryptUIntValue(string key, string encryptedInput, uint defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				uint num;
				uint.TryParse(text, out num);
				ObscuredPrefs.SetUInt(key, num);
				return num;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitConverter.ToUInt32(array, 0);
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000AE13 File Offset: 0x00009213
		public static void SetString(string key, string value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptStringValue(key, value));
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000AE27 File Offset: 0x00009227
		public static string GetString(string key)
		{
			return ObscuredPrefs.GetString(key, string.Empty);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000AE34 File Offset: 0x00009234
		public static string GetString(string key, string defaultValue)
		{
			string text = ObscuredPrefs.EncryptKey(key);
			if (!PlayerPrefs.HasKey(text) && PlayerPrefs.HasKey(key))
			{
				string @string = PlayerPrefs.GetString(key, defaultValue);
				if (!ObscuredPrefs.preservePlayerPrefs)
				{
					ObscuredPrefs.SetString(key, @string);
					PlayerPrefs.DeleteKey(key);
				}
				return @string;
			}
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, text);
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptStringValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000AEA8 File Offset: 0x000092A8
		internal static string EncryptStringValue(string key, string value)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.String);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000AECC File Offset: 0x000092CC
		internal static string DecryptStringValue(string key, string encryptedInput, string defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				ObscuredPrefs.SetString(key, text);
				return text;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return Encoding.UTF8.GetString(array, 0, array.Length);
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000AF2A File Offset: 0x0000932A
		public static void SetFloat(string key, float value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptFloatValue(key, value));
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000AF3E File Offset: 0x0000933E
		public static float GetFloat(string key)
		{
			return ObscuredPrefs.GetFloat(key, 0f);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000AF4C File Offset: 0x0000934C
		public static float GetFloat(string key, float defaultValue)
		{
			string text = ObscuredPrefs.EncryptKey(key);
			if (!PlayerPrefs.HasKey(text) && PlayerPrefs.HasKey(key))
			{
				float @float = PlayerPrefs.GetFloat(key, defaultValue);
				if (!ObscuredPrefs.preservePlayerPrefs)
				{
					ObscuredPrefs.SetFloat(key, @float);
					PlayerPrefs.DeleteKey(key);
				}
				return @float;
			}
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, text);
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptFloatValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000AFC0 File Offset: 0x000093C0
		internal static string EncryptFloatValue(string key, float value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.Float);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000AFE0 File Offset: 0x000093E0
		internal static float DecryptFloatValue(string key, string encryptedInput, float defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				float num;
				float.TryParse(text, out num);
				ObscuredPrefs.SetFloat(key, num);
				return num;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitConverter.ToSingle(array, 0);
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000B03F File Offset: 0x0000943F
		public static void SetDouble(string key, double value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptDoubleValue(key, value));
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000B053 File Offset: 0x00009453
		public static double GetDouble(string key)
		{
			return ObscuredPrefs.GetDouble(key, 0.0);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000B064 File Offset: 0x00009464
		public static double GetDouble(string key, double defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptDoubleValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000B09C File Offset: 0x0000949C
		private static string EncryptDoubleValue(string key, double value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.Double);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000B0BC File Offset: 0x000094BC
		private static double DecryptDoubleValue(string key, string encryptedInput, double defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				double num;
				double.TryParse(text, out num);
				ObscuredPrefs.SetDouble(key, num);
				return num;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitConverter.ToDouble(array, 0);
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000B11B File Offset: 0x0000951B
		public static void SetDecimal(string key, decimal value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptDecimalValue(key, value));
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000B12F File Offset: 0x0000952F
		public static decimal GetDecimal(string key)
		{
			return ObscuredPrefs.GetDecimal(key, 0m);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000B140 File Offset: 0x00009540
		public static decimal GetDecimal(string key, decimal defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptDecimalValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000B178 File Offset: 0x00009578
		private static string EncryptDecimalValue(string key, decimal value)
		{
			byte[] bytes = BitconverterExt.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.Decimal);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000B198 File Offset: 0x00009598
		private static decimal DecryptDecimalValue(string key, string encryptedInput, decimal defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				decimal num;
				decimal.TryParse(text, out num);
				ObscuredPrefs.SetDecimal(key, num);
				return num;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitconverterExt.ToDecimal(array);
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000B1F6 File Offset: 0x000095F6
		public static void SetLong(string key, long value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptLongValue(key, value));
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000B20A File Offset: 0x0000960A
		public static long GetLong(string key)
		{
			return ObscuredPrefs.GetLong(key, 0L);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000B214 File Offset: 0x00009614
		public static long GetLong(string key, long defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptLongValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000B24C File Offset: 0x0000964C
		private static string EncryptLongValue(string key, long value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.Long);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000B26C File Offset: 0x0000966C
		private static long DecryptLongValue(string key, string encryptedInput, long defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				long num;
				long.TryParse(text, out num);
				ObscuredPrefs.SetLong(key, num);
				return num;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitConverter.ToInt64(array, 0);
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000B2CB File Offset: 0x000096CB
		public static void SetULong(string key, ulong value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptULongValue(key, value));
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000B2DF File Offset: 0x000096DF
		public static ulong GetULong(string key)
		{
			return ObscuredPrefs.GetULong(key, 0UL);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000B2EC File Offset: 0x000096EC
		public static ulong GetULong(string key, ulong defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptULongValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000B324 File Offset: 0x00009724
		private static string EncryptULongValue(string key, ulong value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.ULong);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000B344 File Offset: 0x00009744
		private static ulong DecryptULongValue(string key, string encryptedInput, ulong defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				ulong num;
				ulong.TryParse(text, out num);
				ObscuredPrefs.SetULong(key, num);
				return num;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitConverter.ToUInt64(array, 0);
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000B3A3 File Offset: 0x000097A3
		public static void SetBool(string key, bool value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptBoolValue(key, value));
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000B3B7 File Offset: 0x000097B7
		public static bool GetBool(string key)
		{
			return ObscuredPrefs.GetBool(key, false);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000B3C0 File Offset: 0x000097C0
		public static bool GetBool(string key, bool defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptBoolValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000B3F8 File Offset: 0x000097F8
		private static string EncryptBoolValue(string key, bool value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.Bool);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000B418 File Offset: 0x00009818
		private static bool DecryptBoolValue(string key, string encryptedInput, bool defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				int num;
				int.TryParse(text, out num);
				ObscuredPrefs.SetBool(key, num == 1);
				return num == 1;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return defaultValue;
				}
				return BitConverter.ToBoolean(array, 0);
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000B47D File Offset: 0x0000987D
		public static void SetByteArray(string key, byte[] value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptByteArrayValue(key, value));
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000B491 File Offset: 0x00009891
		public static byte[] GetByteArray(string key)
		{
			return ObscuredPrefs.GetByteArray(key, 0, 0);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000B49C File Offset: 0x0000989C
		public static byte[] GetByteArray(string key, byte defaultValue, int defaultLength)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			if (encryptedPrefsString == "{not_found}")
			{
				return ObscuredPrefs.ConstructByteArray(defaultValue, defaultLength);
			}
			return ObscuredPrefs.DecryptByteArrayValue(key, encryptedPrefsString, defaultValue, defaultLength);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000B4D7 File Offset: 0x000098D7
		private static string EncryptByteArrayValue(string key, byte[] value)
		{
			return ObscuredPrefs.EncryptData(key, value, ObscuredPrefs.DataType.ByteArray);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000B4E4 File Offset: 0x000098E4
		private static byte[] DecryptByteArrayValue(string key, string encryptedInput, byte defaultValue, int defaultLength)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return ObscuredPrefs.ConstructByteArray(defaultValue, defaultLength);
				}
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				ObscuredPrefs.SetByteArray(key, bytes);
				return bytes;
			}
			else
			{
				byte[] array = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array == null)
				{
					return ObscuredPrefs.ConstructByteArray(defaultValue, defaultLength);
				}
				return array;
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000B54C File Offset: 0x0000994C
		private static byte[] ConstructByteArray(byte value, int length)
		{
			byte[] array = new byte[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = value;
			}
			return array;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000B577 File Offset: 0x00009977
		public static void SetVector2(string key, Vector2 value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptVector2Value(key, value));
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000B58B File Offset: 0x0000998B
		public static Vector2 GetVector2(string key)
		{
			return ObscuredPrefs.GetVector2(key, Vector2.zero);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000B598 File Offset: 0x00009998
		public static Vector2 GetVector2(string key, Vector2 defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptVector2Value(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000B5D0 File Offset: 0x000099D0
		private static string EncryptVector2Value(string key, Vector2 value)
		{
			byte[] array = new byte[8];
			Buffer.BlockCopy(BitConverter.GetBytes(value.x), 0, array, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.y), 0, array, 4, 4);
			return ObscuredPrefs.EncryptData(key, array, ObscuredPrefs.DataType.Vector2);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000B618 File Offset: 0x00009A18
		private static Vector2 DecryptVector2Value(string key, string encryptedInput, Vector2 defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				string[] array = text.Split(new char[]
				{
					"|"[0]
				});
				float x;
				float.TryParse(array[0], out x);
				float y;
				float.TryParse(array[1], out y);
				Vector2 vector = new Vector2(x, y);
				ObscuredPrefs.SetVector2(key, vector);
				return vector;
			}
			else
			{
				byte[] array2 = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array2 == null)
				{
					return defaultValue;
				}
				Vector2 result;
				result.x = BitConverter.ToSingle(array2, 0);
				result.y = BitConverter.ToSingle(array2, 4);
				return result;
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000B6C3 File Offset: 0x00009AC3
		public static void SetVector3(string key, Vector3 value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptVector3Value(key, value));
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000B6D7 File Offset: 0x00009AD7
		public static Vector3 GetVector3(string key)
		{
			return ObscuredPrefs.GetVector3(key, Vector3.zero);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000B6E4 File Offset: 0x00009AE4
		public static Vector3 GetVector3(string key, Vector3 defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptVector3Value(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000B71C File Offset: 0x00009B1C
		private static string EncryptVector3Value(string key, Vector3 value)
		{
			byte[] array = new byte[12];
			Buffer.BlockCopy(BitConverter.GetBytes(value.x), 0, array, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.y), 0, array, 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.z), 0, array, 8, 4);
			return ObscuredPrefs.EncryptData(key, array, ObscuredPrefs.DataType.Vector3);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000B77C File Offset: 0x00009B7C
		private static Vector3 DecryptVector3Value(string key, string encryptedInput, Vector3 defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				string[] array = text.Split(new char[]
				{
					"|"[0]
				});
				float x;
				float.TryParse(array[0], out x);
				float y;
				float.TryParse(array[1], out y);
				float z;
				float.TryParse(array[2], out z);
				Vector3 vector = new Vector3(x, y, z);
				ObscuredPrefs.SetVector3(key, vector);
				return vector;
			}
			else
			{
				byte[] array2 = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array2 == null)
				{
					return defaultValue;
				}
				Vector3 result;
				result.x = BitConverter.ToSingle(array2, 0);
				result.y = BitConverter.ToSingle(array2, 4);
				result.z = BitConverter.ToSingle(array2, 8);
				return result;
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000B843 File Offset: 0x00009C43
		public static void SetQuaternion(string key, Quaternion value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptQuaternionValue(key, value));
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000B857 File Offset: 0x00009C57
		public static Quaternion GetQuaternion(string key)
		{
			return ObscuredPrefs.GetQuaternion(key, Quaternion.identity);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000B864 File Offset: 0x00009C64
		public static Quaternion GetQuaternion(string key, Quaternion defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptQuaternionValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000B89C File Offset: 0x00009C9C
		private static string EncryptQuaternionValue(string key, Quaternion value)
		{
			byte[] array = new byte[16];
			Buffer.BlockCopy(BitConverter.GetBytes(value.x), 0, array, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.y), 0, array, 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.z), 0, array, 8, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.w), 0, array, 12, 4);
			return ObscuredPrefs.EncryptData(key, array, ObscuredPrefs.DataType.Quaternion);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000B910 File Offset: 0x00009D10
		private static Quaternion DecryptQuaternionValue(string key, string encryptedInput, Quaternion defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				string[] array = text.Split(new char[]
				{
					"|"[0]
				});
				float x;
				float.TryParse(array[0], out x);
				float y;
				float.TryParse(array[1], out y);
				float z;
				float.TryParse(array[2], out z);
				float w;
				float.TryParse(array[3], out w);
				Quaternion quaternion = new Quaternion(x, y, z, w);
				ObscuredPrefs.SetQuaternion(key, quaternion);
				return quaternion;
			}
			else
			{
				byte[] array2 = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array2 == null)
				{
					return defaultValue;
				}
				Quaternion result;
				result.x = BitConverter.ToSingle(array2, 0);
				result.y = BitConverter.ToSingle(array2, 4);
				result.z = BitConverter.ToSingle(array2, 8);
				result.w = BitConverter.ToSingle(array2, 12);
				return result;
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000B9F4 File Offset: 0x00009DF4
		public static void SetColor(string key, Color32 value)
		{
			uint value2 = (uint)((int)value.a << 24 | (int)value.r << 16 | (int)value.g << 8 | (int)value.b);
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptColorValue(key, value2));
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000BA3B File Offset: 0x00009E3B
		public static Color32 GetColor(string key)
		{
			return ObscuredPrefs.GetColor(key, new Color32(0, 0, 0, 1));
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000BA4C File Offset: 0x00009E4C
		public static Color32 GetColor(string key, Color32 defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			if (encryptedPrefsString == "{not_found}")
			{
				return defaultValue;
			}
			uint num = ObscuredPrefs.DecryptUIntValue(key, encryptedPrefsString, 16777216u);
			byte a = (byte)(num >> 24);
			byte r = (byte)(num >> 16);
			byte g = (byte)(num >> 8);
			byte b = (byte)(num >> 0);
			return new Color32(r, g, b, a);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000BAA8 File Offset: 0x00009EA8
		private static string EncryptColorValue(string key, uint value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return ObscuredPrefs.EncryptData(key, bytes, ObscuredPrefs.DataType.Color);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000BAC5 File Offset: 0x00009EC5
		public static void SetRect(string key, Rect value)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), ObscuredPrefs.EncryptRectValue(key, value));
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000BAD9 File Offset: 0x00009ED9
		public static Rect GetRect(string key)
		{
			return ObscuredPrefs.GetRect(key, new Rect(0f, 0f, 0f, 0f));
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000BAFC File Offset: 0x00009EFC
		public static Rect GetRect(string key, Rect defaultValue)
		{
			string encryptedPrefsString = ObscuredPrefs.GetEncryptedPrefsString(key, ObscuredPrefs.EncryptKey(key));
			return (!(encryptedPrefsString == "{not_found}")) ? ObscuredPrefs.DecryptRectValue(key, encryptedPrefsString, defaultValue) : defaultValue;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000BB34 File Offset: 0x00009F34
		private static string EncryptRectValue(string key, Rect value)
		{
			byte[] array = new byte[16];
			Buffer.BlockCopy(BitConverter.GetBytes(value.x), 0, array, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.y), 0, array, 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.width), 0, array, 8, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(value.height), 0, array, 12, 4);
			return ObscuredPrefs.EncryptData(key, array, ObscuredPrefs.DataType.Rect);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000BBA8 File Offset: 0x00009FA8
		private static Rect DecryptRectValue(string key, string encryptedInput, Rect defaultValue)
		{
			if (encryptedInput.IndexOf(':') > -1)
			{
				string text = ObscuredPrefs.DeprecatedDecryptValue(encryptedInput);
				if (text == string.Empty)
				{
					return defaultValue;
				}
				string[] array = text.Split(new char[]
				{
					"|"[0]
				});
				float x;
				float.TryParse(array[0], out x);
				float y;
				float.TryParse(array[1], out y);
				float width;
				float.TryParse(array[2], out width);
				float height;
				float.TryParse(array[3], out height);
				Rect rect = new Rect(x, y, width, height);
				ObscuredPrefs.SetRect(key, rect);
				return rect;
			}
			else
			{
				byte[] array2 = ObscuredPrefs.DecryptData(key, encryptedInput);
				if (array2 == null)
				{
					return defaultValue;
				}
				return new Rect
				{
					x = BitConverter.ToSingle(array2, 0),
					y = BitConverter.ToSingle(array2, 4),
					width = BitConverter.ToSingle(array2, 8),
					height = BitConverter.ToSingle(array2, 12)
				};
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000BC94 File Offset: 0x0000A094
		public static void SetRawValue(string key, string encryptedValue)
		{
			PlayerPrefs.SetString(ObscuredPrefs.EncryptKey(key), encryptedValue);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000BCA4 File Offset: 0x0000A0A4
		public static string GetRawValue(string key)
		{
			string key2 = ObscuredPrefs.EncryptKey(key);
			return PlayerPrefs.GetString(key2);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000BCC0 File Offset: 0x0000A0C0
		internal static ObscuredPrefs.DataType GetRawValueType(string value)
		{
			ObscuredPrefs.DataType result = ObscuredPrefs.DataType.Unknown;
			byte[] array;
			try
			{
				array = Convert.FromBase64String(value);
			}
			catch (Exception)
			{
				return result;
			}
			if (array.Length < 7)
			{
				return result;
			}
			int num = array.Length;
			result = (ObscuredPrefs.DataType)array[num - 7];
			byte b = array[num - 6];
			if (b > 10)
			{
				result = ObscuredPrefs.DataType.Unknown;
			}
			return result;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000BD20 File Offset: 0x0000A120
		internal static string EncryptKey(string key)
		{
			key = ObscuredString.EncryptDecrypt(key, ObscuredPrefs.cryptoKey);
			key = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
			return key;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000BD42 File Offset: 0x0000A142
		public static bool HasKey(string key)
		{
			return PlayerPrefs.HasKey(key) || PlayerPrefs.HasKey(ObscuredPrefs.EncryptKey(key));
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000BD5D File Offset: 0x0000A15D
		public static void DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(ObscuredPrefs.EncryptKey(key));
			if (!ObscuredPrefs.preservePlayerPrefs)
			{
				PlayerPrefs.DeleteKey(key);
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000BD7A File Offset: 0x0000A17A
		public static void DeleteAll()
		{
			PlayerPrefs.DeleteAll();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000BD81 File Offset: 0x0000A181
		public static void Save()
		{
			PlayerPrefs.Save();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000BD88 File Offset: 0x0000A188
		private static string GetEncryptedPrefsString(string key, string encryptedKey)
		{
			string @string = PlayerPrefs.GetString(encryptedKey, "{not_found}");
			if (@string == "{not_found}" && PlayerPrefs.HasKey(key))
			{
				Debug.LogWarning("[ACTk] Are you trying to read regular PlayerPrefs data using ObscuredPrefs (key = " + key + ")?");
			}
			return @string;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000BDD4 File Offset: 0x0000A1D4
		private static string EncryptData(string key, byte[] cleanBytes, ObscuredPrefs.DataType type)
		{
			int num = cleanBytes.Length;
			byte[] src = ObscuredPrefs.EncryptDecryptBytes(cleanBytes, num, key + ObscuredPrefs.cryptoKey);
			uint num2 = xxHash.CalculateHash(cleanBytes, num, 0u);
			byte[] src2 = new byte[]
			{
				(byte)(num2 & 255u),
				(byte)(num2 >> 8 & 255u),
				(byte)(num2 >> 16 & 255u),
				(byte)(num2 >> 24 & 255u)
			};
			byte[] array = null;
			int num3;
			if (ObscuredPrefs.lockToDevice != ObscuredPrefs.DeviceLockLevel.None)
			{
				num3 = num + 11;
				uint num4 = ObscuredPrefs.DeviceIdHash;
				array = new byte[]
				{
					(byte)(num4 & 255u),
					(byte)(num4 >> 8 & 255u),
					(byte)(num4 >> 16 & 255u),
					(byte)(num4 >> 24 & 255u)
				};
			}
			else
			{
				num3 = num + 7;
			}
			byte[] array2 = new byte[num3];
			Buffer.BlockCopy(src, 0, array2, 0, num);
			if (array != null)
			{
				Buffer.BlockCopy(array, 0, array2, num, 4);
			}
			array2[num3 - 7] = (byte)type;
			array2[num3 - 6] = 2;
			array2[num3 - 5] = (byte)ObscuredPrefs.lockToDevice;
			Buffer.BlockCopy(src2, 0, array2, num3 - 4, 4);
			return Convert.ToBase64String(array2);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000BEFC File Offset: 0x0000A2FC
		internal static byte[] DecryptData(string key, string encryptedInput)
		{
			byte[] array;
			try
			{
				array = Convert.FromBase64String(encryptedInput);
			}
			catch (Exception)
			{
				ObscuredPrefs.SavesTampered();
				return null;
			}
			if (array.Length <= 0)
			{
				ObscuredPrefs.SavesTampered();
				return null;
			}
			int num = array.Length;
			byte b = array[num - 6];
			if (b != 2)
			{
				ObscuredPrefs.SavesTampered();
				return null;
			}
			ObscuredPrefs.DeviceLockLevel deviceLockLevel = (ObscuredPrefs.DeviceLockLevel)array[num - 5];
			byte[] array2 = new byte[4];
			Buffer.BlockCopy(array, num - 4, array2, 0, 4);
			uint num2 = (uint)((int)array2[0] | (int)array2[1] << 8 | (int)array2[2] << 16 | (int)array2[3] << 24);
			uint num3 = 0u;
			int num4;
			if (deviceLockLevel != ObscuredPrefs.DeviceLockLevel.None)
			{
				num4 = num - 11;
				if (ObscuredPrefs.lockToDevice != ObscuredPrefs.DeviceLockLevel.None)
				{
					byte[] array3 = new byte[4];
					Buffer.BlockCopy(array, num4, array3, 0, 4);
					num3 = (uint)((int)array3[0] | (int)array3[1] << 8 | (int)array3[2] << 16 | (int)array3[3] << 24);
				}
			}
			else
			{
				num4 = num - 7;
			}
			byte[] array4 = new byte[num4];
			Buffer.BlockCopy(array, 0, array4, 0, num4);
			byte[] array5 = ObscuredPrefs.EncryptDecryptBytes(array4, num4, key + ObscuredPrefs.cryptoKey);
			uint num5 = xxHash.CalculateHash(array5, num4, 0u);
			if (num5 != num2)
			{
				ObscuredPrefs.SavesTampered();
				return null;
			}
			if (ObscuredPrefs.lockToDevice == ObscuredPrefs.DeviceLockLevel.Strict && num3 == 0u && !ObscuredPrefs.emergencyMode && !ObscuredPrefs.readForeignSaves)
			{
				return null;
			}
			if (num3 != 0u && !ObscuredPrefs.emergencyMode)
			{
				uint num6 = ObscuredPrefs.DeviceIdHash;
				if (num3 != num6)
				{
					ObscuredPrefs.PossibleForeignSavesDetected();
					if (!ObscuredPrefs.readForeignSaves)
					{
						return null;
					}
				}
			}
			return array5;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000C090 File Offset: 0x0000A490
		private static uint CalculateChecksum(string input)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(input + ObscuredPrefs.cryptoKey);
			return xxHash.CalculateHash(bytes, bytes.Length, 0u);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000C0BF File Offset: 0x0000A4BF
		private static void SavesTampered()
		{
			if (ObscuredPrefs.onAlterationDetected != null)
			{
				ObscuredPrefs.onAlterationDetected();
				ObscuredPrefs.onAlterationDetected = null;
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000C0DB File Offset: 0x0000A4DB
		private static void PossibleForeignSavesDetected()
		{
			if (ObscuredPrefs.onPossibleForeignSavesDetected != null && !ObscuredPrefs.foreignSavesReported)
			{
				ObscuredPrefs.foreignSavesReported = true;
				ObscuredPrefs.onPossibleForeignSavesDetected();
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000C104 File Offset: 0x0000A504
		private static string GetDeviceId()
		{
			string text = string.Empty;
			if (string.IsNullOrEmpty(text))
			{
				text = SystemInfo.deviceUniqueIdentifier;
			}
			return text;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000C12C File Offset: 0x0000A52C
		private static byte[] EncryptDecryptBytes(byte[] bytes, int dataLength, string key)
		{
			int length = key.Length;
			byte[] array = new byte[dataLength];
			for (int i = 0; i < dataLength; i++)
			{
				array[i] = (byte)((char)bytes[i] ^ key[i % length]);
			}
			return array;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000C16C File Offset: 0x0000A56C
		private static string DeprecatedDecryptValue(string value)
		{
			string[] array = value.Split(new char[]
			{
				':'
			});
			if (array.Length < 2)
			{
				ObscuredPrefs.SavesTampered();
				return string.Empty;
			}
			string text = array[0];
			string a = array[1];
			byte[] array2;
			try
			{
				array2 = Convert.FromBase64String(text);
			}
			catch
			{
				ObscuredPrefs.SavesTampered();
				return string.Empty;
			}
			string @string = Encoding.UTF8.GetString(array2, 0, array2.Length);
			string result = ObscuredString.EncryptDecrypt(@string, ObscuredPrefs.cryptoKey);
			if (array.Length == 3)
			{
				if (a != ObscuredPrefs.DeprecatedCalculateChecksum(text + ObscuredPrefs.DeprecatedDeviceId))
				{
					ObscuredPrefs.SavesTampered();
				}
			}
			else if (array.Length == 2)
			{
				if (a != ObscuredPrefs.DeprecatedCalculateChecksum(text))
				{
					ObscuredPrefs.SavesTampered();
				}
			}
			else
			{
				ObscuredPrefs.SavesTampered();
			}
			if (ObscuredPrefs.lockToDevice != ObscuredPrefs.DeviceLockLevel.None && !ObscuredPrefs.emergencyMode)
			{
				if (array.Length >= 3)
				{
					string a2 = array[2];
					if (a2 != ObscuredPrefs.DeprecatedDeviceId)
					{
						if (!ObscuredPrefs.readForeignSaves)
						{
							result = string.Empty;
						}
						ObscuredPrefs.PossibleForeignSavesDetected();
					}
				}
				else if (ObscuredPrefs.lockToDevice == ObscuredPrefs.DeviceLockLevel.Strict)
				{
					if (!ObscuredPrefs.readForeignSaves)
					{
						result = string.Empty;
					}
					ObscuredPrefs.PossibleForeignSavesDetected();
				}
				else if (a != ObscuredPrefs.DeprecatedCalculateChecksum(text))
				{
					if (!ObscuredPrefs.readForeignSaves)
					{
						result = string.Empty;
					}
					ObscuredPrefs.PossibleForeignSavesDetected();
				}
			}
			return result;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000C2EC File Offset: 0x0000A6EC
		private static string DeprecatedCalculateChecksum(string input)
		{
			int num = 0;
			byte[] bytes = Encoding.UTF8.GetBytes(input + ObscuredPrefs.cryptoKey);
			int num2 = bytes.Length;
			int num3 = ObscuredPrefs.cryptoKey.Length ^ 64;
			for (int i = 0; i < num2; i++)
			{
				byte b = bytes[i];
				num += (int)b + (int)b * (i + num3) % 3;
			}
			return num.ToString("X2");
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000C35A File Offset: 0x0000A75A
		private static string DeprecatedDeviceId
		{
			get
			{
				if (string.IsNullOrEmpty(ObscuredPrefs.deprecatedDeviceId))
				{
					ObscuredPrefs.deprecatedDeviceId = ObscuredPrefs.DeprecatedCalculateChecksum(ObscuredPrefs.DeviceId);
				}
				return ObscuredPrefs.deprecatedDeviceId;
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000C37F File Offset: 0x0000A77F
		// Note: this type is marked as 'beforefieldinit'.
		static ObscuredPrefs()
		{
		}

		// Token: 0x04000116 RID: 278
		private const byte VERSION = 2;

		// Token: 0x04000117 RID: 279
		private const string RAW_NOT_FOUND = "{not_found}";

		// Token: 0x04000118 RID: 280
		private const string DATA_SEPARATOR = "|";

		// Token: 0x04000119 RID: 281
		private static bool foreignSavesReported;

		// Token: 0x0400011A RID: 282
		private static string cryptoKey = "e806f6";

		// Token: 0x0400011B RID: 283
		private static string deviceId;

		// Token: 0x0400011C RID: 284
		private static uint deviceIdHash;

		// Token: 0x0400011D RID: 285
		public static Action onAlterationDetected;

		// Token: 0x0400011E RID: 286
		public static bool preservePlayerPrefs;

		// Token: 0x0400011F RID: 287
		public static Action onPossibleForeignSavesDetected;

		// Token: 0x04000120 RID: 288
		public static ObscuredPrefs.DeviceLockLevel lockToDevice;

		// Token: 0x04000121 RID: 289
		public static bool readForeignSaves;

		// Token: 0x04000122 RID: 290
		public static bool emergencyMode;

		// Token: 0x04000123 RID: 291
		private const char DEPRECATED_RAW_SEPARATOR = ':';

		// Token: 0x04000124 RID: 292
		private static string deprecatedDeviceId;

		// Token: 0x0200001F RID: 31
		internal enum DataType : byte
		{
			// Token: 0x04000126 RID: 294
			Unknown,
			// Token: 0x04000127 RID: 295
			Int = 5,
			// Token: 0x04000128 RID: 296
			UInt = 10,
			// Token: 0x04000129 RID: 297
			String = 15,
			// Token: 0x0400012A RID: 298
			Float = 20,
			// Token: 0x0400012B RID: 299
			Double = 25,
			// Token: 0x0400012C RID: 300
			Decimal = 27,
			// Token: 0x0400012D RID: 301
			Long = 30,
			// Token: 0x0400012E RID: 302
			ULong = 32,
			// Token: 0x0400012F RID: 303
			Bool = 35,
			// Token: 0x04000130 RID: 304
			ByteArray = 40,
			// Token: 0x04000131 RID: 305
			Vector2 = 45,
			// Token: 0x04000132 RID: 306
			Vector3 = 50,
			// Token: 0x04000133 RID: 307
			Quaternion = 55,
			// Token: 0x04000134 RID: 308
			Color = 60,
			// Token: 0x04000135 RID: 309
			Rect = 65
		}

		// Token: 0x02000020 RID: 32
		public enum DeviceLockLevel : byte
		{
			// Token: 0x04000137 RID: 311
			None,
			// Token: 0x04000138 RID: 312
			Soft,
			// Token: 0x04000139 RID: 313
			Strict
		}
	}
}
