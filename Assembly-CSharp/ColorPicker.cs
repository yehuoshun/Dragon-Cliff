using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000A00 RID: 2560
public static class ColorPicker
{
	// Token: 0x17000DBE RID: 3518
	// (get) Token: 0x06004599 RID: 17817 RVA: 0x001C2079 File Offset: 0x001C0479
	public static Color Blue
	{
		get
		{
			return ColorPicker.Rare;
		}
	}

	// Token: 0x0600459A RID: 17818 RVA: 0x001C2080 File Offset: 0x001C0480
	public static Color GetGradientColor(int index, int listSize)
	{
		if (listSize == 3)
		{
			return ColorPicker.Gradients[3 * index + 1];
		}
		if (listSize == 9)
		{
			return ColorPicker.Gradients[index];
		}
		throw new Exception("Number of color block is:" + listSize + ", which is not supported");
	}

	// Token: 0x0600459B RID: 17819 RVA: 0x001C20D2 File Offset: 0x001C04D2
	public static string HaxColor(Color color)
	{
		return "#" + ColorUtility.ToHtmlStringRGB(color);
	}

	// Token: 0x0600459C RID: 17820 RVA: 0x001C20E4 File Offset: 0x001C04E4
	public static string GetHaxString(Color color, string text)
	{
		return string.Concat(new string[]
		{
			"<color=",
			ColorPicker.HaxColor(color),
			">",
			text,
			"</color>"
		});
	}

	// Token: 0x0600459D RID: 17821 RVA: 0x001C2118 File Offset: 0x001C0518
	public static Color GetGradeColor(QualityGrade grade, bool isStar = false)
	{
		if (isStar)
		{
			return ColorPicker.Star;
		}
		switch (grade)
		{
		case QualityGrade.Normal:
			return ColorPicker.Normal;
		case QualityGrade.Rare:
			return ColorPicker.Rare;
		case QualityGrade.Epic:
			return ColorPicker.Epic;
		case QualityGrade.Legendary:
			return ColorPicker.Legendary;
		case QualityGrade.Ancient:
			return ColorPicker.Ancient;
		default:
			return ColorPicker.Normal;
		}
	}

	// Token: 0x0600459E RID: 17822 RVA: 0x001C2178 File Offset: 0x001C0578
	public static string GetOutputTypeString(OutputType output, string text)
	{
		Color color;
		switch (output)
		{
		case OutputType.None:
			color = ColorPicker.White;
			break;
		case OutputType.Physical:
			color = ColorPicker.PhysicalColor;
			break;
		case OutputType.Fire:
			color = ColorPicker.FireColor;
			break;
		case OutputType.Ice:
			color = ColorPicker.IceColor;
			break;
		case OutputType.Shadow:
			color = ColorPicker.ShadowColor;
			break;
		case OutputType.Poison:
			color = ColorPicker.PoisonColor;
			break;
		case OutputType.Divine:
			color = ColorPicker.DivineColor;
			break;
		case OutputType.Lightening:
			color = ColorPicker.LightningColor;
			break;
		case OutputType.RealDamage:
			color = ColorPicker.RealDamageColor;
			break;
		case OutputType.Heal:
			color = ColorPicker.HealColor;
			break;
		case OutputType.RealHeal:
			color = ColorPicker.HealColor;
			break;
		default:
			color = ColorPicker.White;
			break;
		}
		return ColorPicker.GetHaxString(color, text);
	}

	// Token: 0x0600459F RID: 17823 RVA: 0x001C2248 File Offset: 0x001C0648
	public static Color GetOutputTypeColor(OutputType output)
	{
		switch (output)
		{
		case OutputType.None:
			return ColorPicker.White;
		case OutputType.Physical:
			return ColorPicker.PhysicalColor;
		case OutputType.Fire:
			return ColorPicker.FireColor;
		case OutputType.Ice:
			return ColorPicker.IceColor;
		case OutputType.Shadow:
			return ColorPicker.ShadowColor;
		case OutputType.Poison:
			return ColorPicker.PoisonColor;
		case OutputType.Divine:
			return ColorPicker.DivineColor;
		case OutputType.Lightening:
			return ColorPicker.LightningColor;
		case OutputType.RealDamage:
			return ColorPicker.RealDamageColor;
		case OutputType.Heal:
			return ColorPicker.HealColor;
		case OutputType.RealHeal:
			return ColorPicker.HealColor;
		default:
			return ColorPicker.White;
		}
	}

	// Token: 0x060045A0 RID: 17824 RVA: 0x001C22D4 File Offset: 0x001C06D4
	public static string ReplaceSkillTag(string text)
	{
		text = text.Replace("<physical>", "<color=" + ColorPicker.HaxColor(ColorPicker.PhysicalColor) + ">");
		text = text.Replace("</physical>", "</color>");
		text = text.Replace("<lightning>", "<color=" + ColorPicker.HaxColor(ColorPicker.LightningColor) + ">");
		text = text.Replace("</lightning>", "</color>");
		text = text.Replace("<poison>", "<color=" + ColorPicker.HaxColor(ColorPicker.PoisonColor) + ">");
		text = text.Replace("</poison>", "</color>");
		text = text.Replace("<caster>", "<color=" + ColorPicker.HaxColor(ColorPicker.CasterColor) + ">");
		text = text.Replace("</caster>", "</color>");
		text = text.Replace("<fire>", "<color=" + ColorPicker.HaxColor(ColorPicker.FireColor) + ">");
		text = text.Replace("</fire>", "</color>");
		text = text.Replace("<ice>", "<color=" + ColorPicker.HaxColor(ColorPicker.IceColor) + ">");
		text = text.Replace("</ice>", "</color>");
		text = text.Replace("<divine>", "<color=" + ColorPicker.HaxColor(ColorPicker.DivineColor) + ">");
		text = text.Replace("</divine>", "</color>");
		text = text.Replace("<heal>", "<color=" + ColorPicker.HaxColor(ColorPicker.HealColor) + ">");
		text = text.Replace("</heal>", "</color>");
		text = text.Replace("<shadow>", "<color=" + ColorPicker.HaxColor(ColorPicker.ShadowColor) + ">");
		text = text.Replace("</shadow>", "</color>");
		text = text.Replace("<random>", "<color=" + ColorPicker.HaxColor(ColorPicker.RandomColor) + ">");
		text = text.Replace("</random>", "</color>");
		text = text.Replace("<real>", "<color=" + ColorPicker.HaxColor(ColorPicker.RealDamageColor) + ">");
		text = text.Replace("</real>", "</color>");
		return text;
	}

	// Token: 0x060045A1 RID: 17825 RVA: 0x001C254C File Offset: 0x001C094C
	public static string GetColoredCompareText(double requiredAmount, double availableAmount, string title = null)
	{
		bool flag = availableAmount >= requiredAmount;
		string text = requiredAmount.RoundDouble(0) + "/" + availableAmount.RoundDouble(0);
		text = ((!flag) ? ColorPicker.GetNegativeColoredString(text) : ColorPicker.GetPositiveColoredString(text));
		if (string.IsNullOrEmpty(title))
		{
			return text;
		}
		return title + ": " + text;
	}

	// Token: 0x060045A2 RID: 17826 RVA: 0x001C25B5 File Offset: 0x001C09B5
	public static string GetPosNegColor(bool isPos, string text)
	{
		if (isPos)
		{
			return ColorPicker.GetHaxString(ColorPicker.PositiveGreen, text);
		}
		return ColorPicker.GetHaxString(ColorPicker.NagetiveRed, text);
	}

	// Token: 0x060045A3 RID: 17827 RVA: 0x001C25D4 File Offset: 0x001C09D4
	public static string GetPositiveColoredString(string text)
	{
		return ColorPicker.GetHaxString(ColorPicker.PositiveGreen, text);
	}

	// Token: 0x060045A4 RID: 17828 RVA: 0x001C25E1 File Offset: 0x001C09E1
	public static string GetNegativeColoredString(string text)
	{
		return ColorPicker.GetHaxString(ColorPicker.NagetiveRed, text);
	}

	// Token: 0x060045A5 RID: 17829 RVA: 0x001C25EE File Offset: 0x001C09EE
	public static Color GetPosNegColor(int number)
	{
		return (number < 0) ? ColorPicker.NagetiveRed : ColorPicker.PositiveGreen;
	}

	// Token: 0x060045A6 RID: 17830 RVA: 0x001C2606 File Offset: 0x001C0A06
	public static Color GetPosNegColor(double number)
	{
		return (number < 0.0) ? ColorPicker.NagetiveRed : ColorPicker.PositiveGreen;
	}

	// Token: 0x060045A7 RID: 17831 RVA: 0x001C2626 File Offset: 0x001C0A26
	public static Color GetPosNegColor(float number)
	{
		return (number < 0f) ? ColorPicker.NagetiveRed : ColorPicker.PositiveGreen;
	}

	// Token: 0x060045A8 RID: 17832 RVA: 0x001C2642 File Offset: 0x001C0A42
	public static string GetPosNegString(int number)
	{
		return ColorPicker.GetHaxString(ColorPicker.GetPosNegColor(number), number.ToString());
	}

	// Token: 0x060045A9 RID: 17833 RVA: 0x001C265C File Offset: 0x001C0A5C
	public static string GetPosNegString(double number)
	{
		return ColorPicker.GetHaxString(ColorPicker.GetPosNegColor(number), number.DoubleToString());
	}

	// Token: 0x060045AA RID: 17834 RVA: 0x001C266F File Offset: 0x001C0A6F
	public static string GetPosNegString(float number)
	{
		return ColorPicker.GetHaxString(ColorPicker.GetPosNegColor(number), number.FloatToString());
	}

	// Token: 0x060045AB RID: 17835 RVA: 0x001C2684 File Offset: 0x001C0A84
	// Note: this type is marked as 'beforefieldinit'.
	static ColorPicker()
	{
	}

	// Token: 0x040034D9 RID: 13529
	public static Color Transparent = new Color(255f, 255f, 255f, 0f);

	// Token: 0x040034DA RID: 13530
	public static Color FullHealthGreen = new Color(0f, 203f, 0f, 255f);

	// Token: 0x040034DB RID: 13531
	public static Color ZeroHealthGreen = new Color(255f, 0f, 0f, 255f);

	// Token: 0x040034DC RID: 13532
	public static Color White = Color.white;

	// Token: 0x040034DD RID: 13533
	public static Color ButtonPressed = new Color(0.78f, 0.78f, 0.78f, 1f);

	// Token: 0x040034DE RID: 13534
	public static Color Normal = Color.white;

	// Token: 0x040034DF RID: 13535
	public static Color Rare = new Color32(0, 112, byte.MaxValue, byte.MaxValue);

	// Token: 0x040034E0 RID: 13536
	public static Color Epic = new Color32(163, 53, 238, byte.MaxValue);

	// Token: 0x040034E1 RID: 13537
	public static Color Legendary = new Color32(byte.MaxValue, 128, 0, byte.MaxValue);

	// Token: 0x040034E2 RID: 13538
	public static Color Ancient = new Color32(220, 20, 60, byte.MaxValue);

	// Token: 0x040034E3 RID: 13539
	public static Color Star = new Color32(byte.MaxValue, 246, 0, byte.MaxValue);

	// Token: 0x040034E4 RID: 13540
	public static Color Set = new Color32(0, byte.MaxValue, 0, byte.MaxValue);

	// Token: 0x040034E5 RID: 13541
	public static Color Grey = new Color32(105, 105, 105, byte.MaxValue);

	// Token: 0x040034E6 RID: 13542
	public static Color Yellow = Color.yellow;

	// Token: 0x040034E7 RID: 13543
	public static Color MoneyTextColor = new Color32(221, 167, 26, byte.MaxValue);

	// Token: 0x040034E8 RID: 13544
	public static Color AshTextColor = ColorPicker.Epic;

	// Token: 0x040034E9 RID: 13545
	public static Color PolicyTextColor = new Color32(252, byte.MaxValue, 62, byte.MaxValue);

	// Token: 0x040034EA RID: 13546
	public static Color SpecialEffectTextColor = new Color32(byte.MaxValue, 183, 28, byte.MaxValue);

	// Token: 0x040034EB RID: 13547
	public static Color PositiveGreen = new Color32(139, 212, 66, byte.MaxValue);

	// Token: 0x040034EC RID: 13548
	public static Color NagetiveRed = ColorPicker.Ancient;

	// Token: 0x040034ED RID: 13549
	public static Color QuestCompletedColor = new Color32(byte.MaxValue, 202, 28, byte.MaxValue);

	// Token: 0x040034EE RID: 13550
	public static Color PhysicalColor = new Color32(221, 0, 0, byte.MaxValue);

	// Token: 0x040034EF RID: 13551
	public static Color LightningColor = new Color32(62, 71, byte.MaxValue, byte.MaxValue);

	// Token: 0x040034F0 RID: 13552
	public static Color PoisonColor = new Color32(0, 143, 1, byte.MaxValue);

	// Token: 0x040034F1 RID: 13553
	public static Color CasterColor = new Color32(234, 22, 141, byte.MaxValue);

	// Token: 0x040034F2 RID: 13554
	public static Color FireColor = new Color32(byte.MaxValue, 58, 0, byte.MaxValue);

	// Token: 0x040034F3 RID: 13555
	public static Color IceColor = new Color32(0, 181, byte.MaxValue, byte.MaxValue);

	// Token: 0x040034F4 RID: 13556
	public static Color DivineColor = new Color32(231, 227, 83, byte.MaxValue);

	// Token: 0x040034F5 RID: 13557
	public static Color HealColor = new Color32(41, byte.MaxValue, 78, byte.MaxValue);

	// Token: 0x040034F6 RID: 13558
	public static Color ShadowColor = new Color32(124, 0, 203, byte.MaxValue);

	// Token: 0x040034F7 RID: 13559
	public static Color RealDamageColor = new Color32(230, 0, byte.MaxValue, byte.MaxValue);

	// Token: 0x040034F8 RID: 13560
	public static Color RandomColor = Color.white;

	// Token: 0x040034F9 RID: 13561
	public static List<Color> Gradients = new List<Color>
	{
		new Color32(36, 188, 106, byte.MaxValue),
		new Color32(36, 188, 43, byte.MaxValue),
		new Color32(104, 188, 36, byte.MaxValue),
		new Color32(154, 188, 36, byte.MaxValue),
		new Color32(185, 188, 36, byte.MaxValue),
		new Color32(188, 147, 36, byte.MaxValue),
		new Color32(188, 103, 36, byte.MaxValue),
		new Color32(188, 64, 36, byte.MaxValue),
		new Color32(188, 36, 36, byte.MaxValue)
	};
}
