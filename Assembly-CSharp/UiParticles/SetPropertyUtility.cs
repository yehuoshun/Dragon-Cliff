using System;
using UnityEngine;

namespace UiParticles
{
	// Token: 0x02000BB1 RID: 2993
	internal static class SetPropertyUtility
	{
		// Token: 0x06004F79 RID: 20345 RVA: 0x002074A8 File Offset: 0x002058A8
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			if (currentValue.r == newValue.r && currentValue.g == newValue.g && currentValue.b == newValue.b && currentValue.a == newValue.a)
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06004F7A RID: 20346 RVA: 0x00207507 File Offset: 0x00205907
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			if (currentValue.Equals(newValue))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06004F7B RID: 20347 RVA: 0x0020752C File Offset: 0x0020592C
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}
	}
}
