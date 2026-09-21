using System;

namespace TMPro
{
	// Token: 0x02000B60 RID: 2912
	[Serializable]
	public class TMP_DigitValidator : TMP_InputValidator
	{
		// Token: 0x06004D32 RID: 19762 RVA: 0x001F5861 File Offset: 0x001F3C61
		public TMP_DigitValidator()
		{
		}

		// Token: 0x06004D33 RID: 19763 RVA: 0x001F5869 File Offset: 0x001F3C69
		public override char Validate(ref string text, ref int pos, char ch)
		{
			if (ch >= '0' && ch <= '9')
			{
				pos++;
				return ch;
			}
			return '\0';
		}
	}
}
