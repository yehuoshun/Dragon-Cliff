using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

// Token: 0x020002EA RID: 746
public class IntegerInputField : MonoBehaviour
{
	// Token: 0x060013D5 RID: 5077 RVA: 0x000A4BB4 File Offset: 0x000A2FB4
	public IntegerInputField()
	{
	}

	// Token: 0x060013D6 RID: 5078 RVA: 0x000A4BBC File Offset: 0x000A2FBC
	public void OnInputChange()
	{
		Regex regex = new Regex("^[1-9]\\d?\\d?$");
		if (regex.IsMatch(this.InputField.text))
		{
			this._lastValue = this.InputField.text;
		}
		else
		{
			this.InputField.text = this._lastValue;
		}
	}

	// Token: 0x060013D7 RID: 5079 RVA: 0x000A4C14 File Offset: 0x000A3014
	public int GetInputFieldValue()
	{
		int result = 0;
		if (!string.IsNullOrEmpty(this.InputField.text))
		{
			result = 0;
		}
		else
		{
			int.TryParse(this.InputField.text, out result);
		}
		return result;
	}

	// Token: 0x060013D8 RID: 5080 RVA: 0x000A4C53 File Offset: 0x000A3053
	public void SetInputFieldValue(int value)
	{
		this.InputField.text = value.ToString();
	}

	// Token: 0x0400143E RID: 5182
	public TMP_InputField InputField;

	// Token: 0x0400143F RID: 5183
	private string _lastValue;
}
