using System;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x02000399 RID: 921
	public static class CreateLUT
	{
		// Token: 0x0600189E RID: 6302 RVA: 0x000BEB60 File Offset: 0x000BCF60
		public static void fromGradient(int steps, Gradient gradient, ref Texture2D texture)
		{
			if (texture)
			{
				UnityEngine.Object.Destroy(texture);
			}
			texture = new Texture2D(steps, 1);
			texture.SetPixel(0, 0, gradient.Evaluate(0f));
			texture.SetPixel(steps - 1, 0, gradient.Evaluate(1f));
			for (int i = 1; i < steps - 1; i++)
			{
				Color color = gradient.Evaluate((float)i / (float)steps);
				texture.SetPixel(i, 0, color);
			}
			texture.Apply();
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x000BEBE4 File Offset: 0x000BCFE4
		public static void fromAnimationCurve(int steps, AnimationCurve curve, ref Texture2D texture)
		{
			if (texture)
			{
				UnityEngine.Object.Destroy(texture);
			}
			texture = new Texture2D(steps, 1);
			texture.SetPixel(0, 0, new Color(0f, 0f, 0f, curve.Evaluate(0f)));
			texture.SetPixel(steps - 1, 0, new Color(0f, 0f, 0f, curve.Evaluate(1f)));
			for (int i = 1; i < steps - 1; i++)
			{
				float a = curve.Evaluate((float)i / (float)steps);
				texture.SetPixel(i, 0, new Color(0f, 0f, 0f, a));
			}
			texture.Apply();
		}
	}
}
