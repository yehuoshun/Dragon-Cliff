using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ca.HenrySoftware.Rage
{
	// Token: 0x020000A1 RID: 161
	public static class Ease
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x00059598 File Offset: 0x00057998
		public static IEnumerator Go(MonoBehaviour m, float from, float to, float time, Action<float> update, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease.GoCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000595C8 File Offset: 0x000579C8
		private static IEnumerator GoCoroutine(MonoBehaviour m, float from, float to, float time, Action<float> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			int counter = repeat;
			while (repeat == 0 || repeat == -1 || counter > 0)
			{
				if (delay > 0f)
				{
					if (realTime)
					{
						yield return new WaitForSecondsRealtime(delay);
					}
					else
					{
						yield return new WaitForSeconds(delay);
					}
				}
				float t = 0f;
				while (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					update(Ease.Types[type](from, to, Mathf.Clamp01(t)));
					yield return null;
				}
				if (pingPong)
				{
					if (delay > 0f)
					{
						if (realTime)
						{
							yield return new WaitForSecondsRealtime(delay);
						}
						else
						{
							yield return new WaitForSeconds(delay);
						}
					}
					t = 0f;
					while (t <= 1f)
					{
						t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
						update(Ease.Types[type](to, from, Mathf.Clamp01(t)));
						yield return null;
					}
				}
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
			}
			if (repeat != 0 && complete != null)
			{
				complete();
			}
			yield break;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0005962C File Offset: 0x00057A2C
		private static float GetAlpha(Component m)
		{
			CanvasGroup component = m.GetComponent<CanvasGroup>();
			if (component != null)
			{
				return component.alpha;
			}
			Image component2 = m.GetComponent<Image>();
			if (component2 != null)
			{
				return component2.color.a;
			}
			return Camera.main.backgroundColor.a;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00059688 File Offset: 0x00057A88
		public static IEnumerator GoAlphaTo(MonoBehaviour m, float to, float time, Action<float> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			return Ease.GoAlpha(m, Ease.GetAlpha(m), to, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000596B0 File Offset: 0x00057AB0
		public static IEnumerator GoAlphaBy(MonoBehaviour m, float by, float time, Action<float> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			float alpha = Ease.GetAlpha(m);
			return Ease.GoAlpha(m, alpha, alpha + by, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000596DC File Offset: 0x00057ADC
		public static IEnumerator GoAlpha(MonoBehaviour m, float from, float to, float time, Action<float> update, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease.GoAlphaCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0005970C File Offset: 0x00057B0C
		private static IEnumerator GoAlphaCoroutine(MonoBehaviour m, float from, float to, float time, Action<float> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			Image image = m.GetComponent<Image>();
			CanvasGroup canvasGroup = m.GetComponent<CanvasGroup>();
			Action<float> setAlpha = delegate(float value)
			{
				if (canvasGroup != null)
				{
					canvasGroup.alpha = value;
				}
				else if (image != null)
				{
					image.color = image.color.SetAlpha(value);
				}
				else
				{
					Camera.main.backgroundColor = Camera.main.backgroundColor.SetAlpha(value);
				}
			};
			int counter = repeat;
			while (repeat == 0 || repeat == -1 || counter > 0)
			{
				if (delay > 0f)
				{
					if (realTime)
					{
						yield return new WaitForSecondsRealtime(delay);
					}
					else
					{
						yield return new WaitForSeconds(delay);
					}
				}
				float t = 0f;
				while (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					float p = Ease.Types[type](from, to, Mathf.Clamp01(t));
					setAlpha(p);
					if (update != null)
					{
						update(p);
					}
					yield return null;
				}
				setAlpha(to);
				if (pingPong)
				{
					if (delay > 0f)
					{
						if (realTime)
						{
							yield return new WaitForSecondsRealtime(delay);
						}
						else
						{
							yield return new WaitForSeconds(delay);
						}
					}
					t = 0f;
					while (t <= 1f)
					{
						t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
						float p2 = Ease.Types[type](to, from, Mathf.Clamp01(t));
						setAlpha(p2);
						if (update != null)
						{
							update(p2);
						}
						yield return null;
					}
					setAlpha(from);
				}
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
			}
			if (repeat != 0 && complete != null)
			{
				complete();
			}
			yield break;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00059774 File Offset: 0x00057B74
		public static float SineIn(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, 1f - Mathf.Cos(time * 1.57079637f));
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0005978F File Offset: 0x00057B8F
		public static float SineOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, Mathf.Sin(time * 1.57079637f));
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x000597A4 File Offset: 0x00057BA4
		public static float SineInOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, 0.5f * (1f - Mathf.Cos(3.14159274f * time)));
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x000597C5 File Offset: 0x00057BC5
		public static float QuadIn(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, time * time);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x000597D1 File Offset: 0x00057BD1
		public static float QuadOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, -time * (time - 2f));
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x000597E4 File Offset: 0x00057BE4
		public static float QuadInOut(float from, float to, float time)
		{
			if ((time /= 0.5f) < 1f)
			{
				return Mathf.Lerp(from, to, 0.5f * time * time);
			}
			return Mathf.Lerp(from, to, -0.5f * ((time -= 1f) * (time - 2f) - 1f));
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0005983B File Offset: 0x00057C3B
		public static float CubicIn(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, time * time * time);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00059849 File Offset: 0x00057C49
		public static float CubicOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, (time -= 1f) * time * time + 1f);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00059868 File Offset: 0x00057C68
		public static float CubicInOut(float from, float to, float time)
		{
			if ((time /= 0.5f) < 1f)
			{
				return Mathf.Lerp(from, to, 0.5f * time * time * time);
			}
			return Mathf.Lerp(from, to, 0.5f * ((time -= 2f) * time * time + 2f));
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000598BD File Offset: 0x00057CBD
		public static float QuartIn(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, time * time * time * time);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000598CD File Offset: 0x00057CCD
		public static float QuartOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, -((time -= 1f) * time * time * time - 1f));
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x000598F0 File Offset: 0x00057CF0
		public static float QuartInOut(float from, float to, float time)
		{
			if ((time /= 0.5f) < 1f)
			{
				return Mathf.Lerp(from, to, 0.5f * time * time * time * time);
			}
			return Mathf.Lerp(from, to, -0.5f * ((time -= 2f) * time * time * time - 2f));
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00059949 File Offset: 0x00057D49
		public static float QuintIn(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, time * time * time * time * time);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0005995B File Offset: 0x00057D5B
		public static float QuintOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, (time -= 1f) * time * time * time * time + 1f);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0005997C File Offset: 0x00057D7C
		public static float QuintInOut(float from, float to, float time)
		{
			if ((time /= 0.5f) < 1f)
			{
				return Mathf.Lerp(from, to, 0.5f * time * time * time * time * time);
			}
			return Mathf.Lerp(from, to, 0.5f * ((time -= 2f) * time * time * time * time + 2f));
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x000599D9 File Offset: 0x00057DD9
		public static float ExpoIn(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, Mathf.Pow(2f, 10f * (time - 1f)));
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x000599F9 File Offset: 0x00057DF9
		public static float ExpoOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, -Mathf.Pow(2f, -10f * time) + 1f);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00059A1C File Offset: 0x00057E1C
		public static float ExpoInOut(float from, float to, float time)
		{
			if ((time /= 0.5f) < 1f)
			{
				return Mathf.Lerp(from, to, 0.5f * Mathf.Pow(2f, 10f * (time - 1f)));
			}
			return Mathf.Lerp(from, to, 0.5f * (-Mathf.Pow(2f, -10f * (time -= 1f)) + 2f));
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00059A90 File Offset: 0x00057E90
		public static float CircIn(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, -(Mathf.Sqrt(1f - time * time) - 1f));
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00059AAE File Offset: 0x00057EAE
		public static float CircOut(float from, float to, float time)
		{
			return Mathf.Lerp(from, to, Mathf.Sqrt(1f - (time -= 1f) * time));
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00059AD0 File Offset: 0x00057ED0
		public static float CircInOut(float from, float to, float time)
		{
			if ((time /= 0.5f) < 1f)
			{
				return Mathf.Lerp(from, to, -0.5f * (Mathf.Sqrt(1f - time * time) - 1f));
			}
			return Mathf.Lerp(from, to, 0.5f * (Mathf.Sqrt(1f - (time -= 2f) * time) + 1f));
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00059B3D File Offset: 0x00057F3D
		public static float BackIn(float from, float to, float time)
		{
			to -= from;
			return to * time * time * (2.70158f * time - 1.70158f) + from;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00059B59 File Offset: 0x00057F59
		public static float BackOut(float from, float to, float time)
		{
			to -= from;
			return to * ((time -= 1f) * time * (2.70158f * time + 1.70158f) + 1f) + from;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00059B84 File Offset: 0x00057F84
		public static float BackInOut(float from, float to, float time)
		{
			to -= from;
			if ((time /= 0.5f) < 1f)
			{
				return to * 0.5f * (time * time * (3.59490943f * time - 2.59490943f)) + from;
			}
			return to * 0.5f * ((time -= 2f) * time * (3.59490943f * time + 2.59490943f) + 2f) + from;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00059BF0 File Offset: 0x00057FF0
		public static float ElasticIn(float from, float to, float time)
		{
			to -= from;
			return to * -(Mathf.Pow(2f, 10f * (time -= 1f)) * Mathf.Sin((time - 0.075f) * 6.28318548f / 0.3f)) + from;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00059C2F File Offset: 0x0005802F
		public static float ElasticOut(float from, float to, float time)
		{
			to -= from;
			return to * Mathf.Pow(2f, -10f * time) * Mathf.Sin((time - 0.075f) * 6.28318548f / 0.3f) + to + from;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00059C68 File Offset: 0x00058068
		public static float ElasticInOut(float from, float to, float time)
		{
			to -= from;
			if ((time /= 0.5f) < 1f)
			{
				return -0.5f * (to * Mathf.Pow(2f, 10f * (time -= 1f)) * Mathf.Sin((time - 0.112500004f) * 6.28318548f / 0.450000018f)) + from;
			}
			return to * Mathf.Pow(2f, -10f * (time -= 1f)) * Mathf.Sin((time - 0.112500004f) * 6.28318548f / 0.450000018f) * 0.5f + to + from;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00059D0B File Offset: 0x0005810B
		public static float BounceIn(float from, float to, float time)
		{
			to -= from;
			return to - Ease.BounceOut(0f, to, 1f - time) + from;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00059D28 File Offset: 0x00058128
		public static float BounceOut(float from, float to, float time)
		{
			to -= from;
			if (time < 0.363636374f)
			{
				return to * (7.5625f * time * time) + from;
			}
			if (time < 0.727272749f)
			{
				return to * (7.5625f * (time -= 0.545454562f) * time + 0.75f) + from;
			}
			if (time < 0.909090936f)
			{
				return to * (7.5625f * (time -= 0.8181818f) * time + 0.9375f) + from;
			}
			return to * (7.5625f * (time -= 0.954545438f) * time + 0.984375f) + from;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00059DC0 File Offset: 0x000581C0
		public static float BounceInOut(float from, float to, float time)
		{
			to -= from;
			if (time < 0.5f)
			{
				return Ease.BounceIn(0f, to, time * 2f) * 0.5f + from;
			}
			return Ease.BounceOut(0f, to, time * 2f - 1f) * 0.5f + to * 0.5f + from;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00059E20 File Offset: 0x00058220
		public static float Spring(float from, float to, float time)
		{
			time = Mathf.Clamp01(time);
			time = (Mathf.Sin(time * 3.14159274f * (0.2f + 2.5f * time * time * time)) * Mathf.Pow(1f - time, 2.2f) + time) * (1f + 1.2f * (1f - time));
			return from + (to - from) * time;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00059E84 File Offset: 0x00058284
		// Note: this type is marked as 'beforefieldinit'.
		static Ease()
		{
			Dictionary<EaseType, Func<float, float, float, float>> dictionary = new Dictionary<EaseType, Func<float, float, float, float>>();
			Dictionary<EaseType, Func<float, float, float, float>> dictionary2 = dictionary;
			EaseType key = EaseType.Linear;
			if (Ease.<>f__mg$cache0 == null)
			{
				Ease.<>f__mg$cache0 = new Func<float, float, float, float>(Mathf.Lerp);
			}
			dictionary2.Add(key, Ease.<>f__mg$cache0);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary3 = dictionary;
			EaseType key2 = EaseType.SineIn;
			if (Ease.<>f__mg$cache1 == null)
			{
				Ease.<>f__mg$cache1 = new Func<float, float, float, float>(Ease.SineIn);
			}
			dictionary3.Add(key2, Ease.<>f__mg$cache1);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary4 = dictionary;
			EaseType key3 = EaseType.SineOut;
			if (Ease.<>f__mg$cache2 == null)
			{
				Ease.<>f__mg$cache2 = new Func<float, float, float, float>(Ease.SineOut);
			}
			dictionary4.Add(key3, Ease.<>f__mg$cache2);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary5 = dictionary;
			EaseType key4 = EaseType.SineInOut;
			if (Ease.<>f__mg$cache3 == null)
			{
				Ease.<>f__mg$cache3 = new Func<float, float, float, float>(Ease.SineInOut);
			}
			dictionary5.Add(key4, Ease.<>f__mg$cache3);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary6 = dictionary;
			EaseType key5 = EaseType.QuadIn;
			if (Ease.<>f__mg$cache4 == null)
			{
				Ease.<>f__mg$cache4 = new Func<float, float, float, float>(Ease.QuadIn);
			}
			dictionary6.Add(key5, Ease.<>f__mg$cache4);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary7 = dictionary;
			EaseType key6 = EaseType.QuadOut;
			if (Ease.<>f__mg$cache5 == null)
			{
				Ease.<>f__mg$cache5 = new Func<float, float, float, float>(Ease.QuadOut);
			}
			dictionary7.Add(key6, Ease.<>f__mg$cache5);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary8 = dictionary;
			EaseType key7 = EaseType.QuadInOut;
			if (Ease.<>f__mg$cache6 == null)
			{
				Ease.<>f__mg$cache6 = new Func<float, float, float, float>(Ease.QuadInOut);
			}
			dictionary8.Add(key7, Ease.<>f__mg$cache6);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary9 = dictionary;
			EaseType key8 = EaseType.CubicIn;
			if (Ease.<>f__mg$cache7 == null)
			{
				Ease.<>f__mg$cache7 = new Func<float, float, float, float>(Ease.CubicIn);
			}
			dictionary9.Add(key8, Ease.<>f__mg$cache7);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary10 = dictionary;
			EaseType key9 = EaseType.CubicOut;
			if (Ease.<>f__mg$cache8 == null)
			{
				Ease.<>f__mg$cache8 = new Func<float, float, float, float>(Ease.CubicOut);
			}
			dictionary10.Add(key9, Ease.<>f__mg$cache8);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary11 = dictionary;
			EaseType key10 = EaseType.CubicInOut;
			if (Ease.<>f__mg$cache9 == null)
			{
				Ease.<>f__mg$cache9 = new Func<float, float, float, float>(Ease.CubicInOut);
			}
			dictionary11.Add(key10, Ease.<>f__mg$cache9);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary12 = dictionary;
			EaseType key11 = EaseType.QuartIn;
			if (Ease.<>f__mg$cacheA == null)
			{
				Ease.<>f__mg$cacheA = new Func<float, float, float, float>(Ease.QuartIn);
			}
			dictionary12.Add(key11, Ease.<>f__mg$cacheA);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary13 = dictionary;
			EaseType key12 = EaseType.QuartOut;
			if (Ease.<>f__mg$cacheB == null)
			{
				Ease.<>f__mg$cacheB = new Func<float, float, float, float>(Ease.QuartOut);
			}
			dictionary13.Add(key12, Ease.<>f__mg$cacheB);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary14 = dictionary;
			EaseType key13 = EaseType.QuartInOut;
			if (Ease.<>f__mg$cacheC == null)
			{
				Ease.<>f__mg$cacheC = new Func<float, float, float, float>(Ease.QuartInOut);
			}
			dictionary14.Add(key13, Ease.<>f__mg$cacheC);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary15 = dictionary;
			EaseType key14 = EaseType.QuintIn;
			if (Ease.<>f__mg$cacheD == null)
			{
				Ease.<>f__mg$cacheD = new Func<float, float, float, float>(Ease.QuintIn);
			}
			dictionary15.Add(key14, Ease.<>f__mg$cacheD);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary16 = dictionary;
			EaseType key15 = EaseType.QuintOut;
			if (Ease.<>f__mg$cacheE == null)
			{
				Ease.<>f__mg$cacheE = new Func<float, float, float, float>(Ease.QuintOut);
			}
			dictionary16.Add(key15, Ease.<>f__mg$cacheE);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary17 = dictionary;
			EaseType key16 = EaseType.QuintInOut;
			if (Ease.<>f__mg$cacheF == null)
			{
				Ease.<>f__mg$cacheF = new Func<float, float, float, float>(Ease.QuintInOut);
			}
			dictionary17.Add(key16, Ease.<>f__mg$cacheF);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary18 = dictionary;
			EaseType key17 = EaseType.ExpoIn;
			if (Ease.<>f__mg$cache10 == null)
			{
				Ease.<>f__mg$cache10 = new Func<float, float, float, float>(Ease.ExpoIn);
			}
			dictionary18.Add(key17, Ease.<>f__mg$cache10);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary19 = dictionary;
			EaseType key18 = EaseType.ExpoOut;
			if (Ease.<>f__mg$cache11 == null)
			{
				Ease.<>f__mg$cache11 = new Func<float, float, float, float>(Ease.ExpoOut);
			}
			dictionary19.Add(key18, Ease.<>f__mg$cache11);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary20 = dictionary;
			EaseType key19 = EaseType.ExpoInOut;
			if (Ease.<>f__mg$cache12 == null)
			{
				Ease.<>f__mg$cache12 = new Func<float, float, float, float>(Ease.ExpoInOut);
			}
			dictionary20.Add(key19, Ease.<>f__mg$cache12);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary21 = dictionary;
			EaseType key20 = EaseType.CircIn;
			if (Ease.<>f__mg$cache13 == null)
			{
				Ease.<>f__mg$cache13 = new Func<float, float, float, float>(Ease.CircIn);
			}
			dictionary21.Add(key20, Ease.<>f__mg$cache13);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary22 = dictionary;
			EaseType key21 = EaseType.CircOut;
			if (Ease.<>f__mg$cache14 == null)
			{
				Ease.<>f__mg$cache14 = new Func<float, float, float, float>(Ease.CircOut);
			}
			dictionary22.Add(key21, Ease.<>f__mg$cache14);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary23 = dictionary;
			EaseType key22 = EaseType.CircInOut;
			if (Ease.<>f__mg$cache15 == null)
			{
				Ease.<>f__mg$cache15 = new Func<float, float, float, float>(Ease.CircInOut);
			}
			dictionary23.Add(key22, Ease.<>f__mg$cache15);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary24 = dictionary;
			EaseType key23 = EaseType.BackIn;
			if (Ease.<>f__mg$cache16 == null)
			{
				Ease.<>f__mg$cache16 = new Func<float, float, float, float>(Ease.BackIn);
			}
			dictionary24.Add(key23, Ease.<>f__mg$cache16);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary25 = dictionary;
			EaseType key24 = EaseType.BackOut;
			if (Ease.<>f__mg$cache17 == null)
			{
				Ease.<>f__mg$cache17 = new Func<float, float, float, float>(Ease.BackOut);
			}
			dictionary25.Add(key24, Ease.<>f__mg$cache17);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary26 = dictionary;
			EaseType key25 = EaseType.BackInOut;
			if (Ease.<>f__mg$cache18 == null)
			{
				Ease.<>f__mg$cache18 = new Func<float, float, float, float>(Ease.BackInOut);
			}
			dictionary26.Add(key25, Ease.<>f__mg$cache18);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary27 = dictionary;
			EaseType key26 = EaseType.ElasticIn;
			if (Ease.<>f__mg$cache19 == null)
			{
				Ease.<>f__mg$cache19 = new Func<float, float, float, float>(Ease.ElasticIn);
			}
			dictionary27.Add(key26, Ease.<>f__mg$cache19);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary28 = dictionary;
			EaseType key27 = EaseType.ElasticOut;
			if (Ease.<>f__mg$cache1A == null)
			{
				Ease.<>f__mg$cache1A = new Func<float, float, float, float>(Ease.ElasticOut);
			}
			dictionary28.Add(key27, Ease.<>f__mg$cache1A);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary29 = dictionary;
			EaseType key28 = EaseType.ElasticInOut;
			if (Ease.<>f__mg$cache1B == null)
			{
				Ease.<>f__mg$cache1B = new Func<float, float, float, float>(Ease.ElasticInOut);
			}
			dictionary29.Add(key28, Ease.<>f__mg$cache1B);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary30 = dictionary;
			EaseType key29 = EaseType.BounceIn;
			if (Ease.<>f__mg$cache1C == null)
			{
				Ease.<>f__mg$cache1C = new Func<float, float, float, float>(Ease.BounceIn);
			}
			dictionary30.Add(key29, Ease.<>f__mg$cache1C);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary31 = dictionary;
			EaseType key30 = EaseType.BounceOut;
			if (Ease.<>f__mg$cache1D == null)
			{
				Ease.<>f__mg$cache1D = new Func<float, float, float, float>(Ease.BounceOut);
			}
			dictionary31.Add(key30, Ease.<>f__mg$cache1D);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary32 = dictionary;
			EaseType key31 = EaseType.BounceInOut;
			if (Ease.<>f__mg$cache1E == null)
			{
				Ease.<>f__mg$cache1E = new Func<float, float, float, float>(Ease.BounceInOut);
			}
			dictionary32.Add(key31, Ease.<>f__mg$cache1E);
			Dictionary<EaseType, Func<float, float, float, float>> dictionary33 = dictionary;
			EaseType key32 = EaseType.Spring;
			if (Ease.<>f__mg$cache1F == null)
			{
				Ease.<>f__mg$cache1F = new Func<float, float, float, float>(Ease.Spring);
			}
			dictionary33.Add(key32, Ease.<>f__mg$cache1F);
			Ease.Types = dictionary;
		}

		// Token: 0x0400086B RID: 2155
		private static readonly Dictionary<EaseType, Func<float, float, float, float>> Types;

		// Token: 0x0400086C RID: 2156
		private const float HalfPi = 1.57079637f;

		// Token: 0x0400086D RID: 2157
		private const float DoublePi = 6.28318548f;

		// Token: 0x0400086E RID: 2158
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache0;

		// Token: 0x0400086F RID: 2159
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache1;

		// Token: 0x04000870 RID: 2160
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache2;

		// Token: 0x04000871 RID: 2161
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache3;

		// Token: 0x04000872 RID: 2162
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache4;

		// Token: 0x04000873 RID: 2163
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache5;

		// Token: 0x04000874 RID: 2164
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache6;

		// Token: 0x04000875 RID: 2165
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache7;

		// Token: 0x04000876 RID: 2166
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache8;

		// Token: 0x04000877 RID: 2167
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache9;

		// Token: 0x04000878 RID: 2168
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cacheA;

		// Token: 0x04000879 RID: 2169
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cacheB;

		// Token: 0x0400087A RID: 2170
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cacheC;

		// Token: 0x0400087B RID: 2171
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cacheD;

		// Token: 0x0400087C RID: 2172
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cacheE;

		// Token: 0x0400087D RID: 2173
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cacheF;

		// Token: 0x0400087E RID: 2174
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache10;

		// Token: 0x0400087F RID: 2175
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache11;

		// Token: 0x04000880 RID: 2176
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache12;

		// Token: 0x04000881 RID: 2177
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache13;

		// Token: 0x04000882 RID: 2178
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache14;

		// Token: 0x04000883 RID: 2179
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache15;

		// Token: 0x04000884 RID: 2180
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache16;

		// Token: 0x04000885 RID: 2181
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache17;

		// Token: 0x04000886 RID: 2182
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache18;

		// Token: 0x04000887 RID: 2183
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache19;

		// Token: 0x04000888 RID: 2184
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache1A;

		// Token: 0x04000889 RID: 2185
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache1B;

		// Token: 0x0400088A RID: 2186
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache1C;

		// Token: 0x0400088B RID: 2187
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache1D;

		// Token: 0x0400088C RID: 2188
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache1E;

		// Token: 0x0400088D RID: 2189
		[CompilerGenerated]
		private static Func<float, float, float, float> <>f__mg$cache1F;

		// Token: 0x02000BB6 RID: 2998
		[CompilerGenerated]
		private sealed class <GoCoroutine>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004F98 RID: 20376 RVA: 0x0005A334 File Offset: 0x00058734
			[DebuggerHidden]
			public <GoCoroutine>c__Iterator0()
			{
			}

			// Token: 0x06004F99 RID: 20377 RVA: 0x0005A33C File Offset: 0x0005873C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					counter = repeat;
					goto IL_2AB;
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_140;
				case 4u:
					goto IL_1C5;
				case 5u:
					goto IL_1C5;
				case 6u:
					goto IL_255;
				default:
					return false;
				}
				IL_B0:
				t = 0f;
				IL_140:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					update(Ease.Types[type](from, to, Mathf.Clamp01(t)));
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				if (!pingPong)
				{
					goto IL_265;
				}
				if (delay > 0f)
				{
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					return true;
				}
				IL_1C5:
				t = 0f;
				IL_255:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					update(Ease.Types[type](to, from, Mathf.Clamp01(t)));
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					return true;
				}
				IL_265:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_2AB:
				if (repeat != 0 && repeat != -1 && counter <= 0)
				{
					if (repeat != 0 && complete != null)
					{
						complete();
					}
					this.$PC = -1;
				}
				else
				{
					if (delay <= 0f)
					{
						goto IL_B0;
					}
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 1;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				return false;
			}

			// Token: 0x170010DE RID: 4318
			// (get) Token: 0x06004F9A RID: 20378 RVA: 0x0005A642 File Offset: 0x00058A42
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010DF RID: 4319
			// (get) Token: 0x06004F9B RID: 20379 RVA: 0x0005A64A File Offset: 0x00058A4A
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004F9C RID: 20380 RVA: 0x0005A652 File Offset: 0x00058A52
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004F9D RID: 20381 RVA: 0x0005A662 File Offset: 0x00058A62
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D40 RID: 15680
			internal int repeat;

			// Token: 0x04003D41 RID: 15681
			internal int <counter>__0;

			// Token: 0x04003D42 RID: 15682
			internal float delay;

			// Token: 0x04003D43 RID: 15683
			internal bool realTime;

			// Token: 0x04003D44 RID: 15684
			internal float <t>__1;

			// Token: 0x04003D45 RID: 15685
			internal float time;

			// Token: 0x04003D46 RID: 15686
			internal Action<float> update;

			// Token: 0x04003D47 RID: 15687
			internal EaseType type;

			// Token: 0x04003D48 RID: 15688
			internal float from;

			// Token: 0x04003D49 RID: 15689
			internal float to;

			// Token: 0x04003D4A RID: 15690
			internal bool pingPong;

			// Token: 0x04003D4B RID: 15691
			internal Action complete;

			// Token: 0x04003D4C RID: 15692
			internal object $current;

			// Token: 0x04003D4D RID: 15693
			internal bool $disposing;

			// Token: 0x04003D4E RID: 15694
			internal int $PC;
		}

		// Token: 0x02000BB7 RID: 2999
		[CompilerGenerated]
		private sealed class <GoAlphaCoroutine>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004F9E RID: 20382 RVA: 0x0005A669 File Offset: 0x00058A69
			[DebuggerHidden]
			public <GoAlphaCoroutine>c__Iterator1()
			{
			}

			// Token: 0x06004F9F RID: 20383 RVA: 0x0005A674 File Offset: 0x00058A74
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
				{
					Image image = m.GetComponent<Image>();
					CanvasGroup canvasGroup = m.GetComponent<CanvasGroup>();
					setAlpha = delegate(float value)
					{
						if (canvasGroup != null)
						{
							canvasGroup.alpha = value;
						}
						else if (image != null)
						{
							image.color = image.color.SetAlpha(value);
						}
						else
						{
							Camera.main.backgroundColor = Camera.main.backgroundColor.SetAlpha(value);
						}
					};
					counter = repeat;
					goto IL_377;
				}
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_1C2;
				case 4u:
					goto IL_258;
				case 5u:
					goto IL_258;
				case 6u:
					goto IL_310;
				default:
					return false;
				}
				IL_10A:
				t = 0f;
				IL_1C2:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p = Ease.Types[type](from, to, Mathf.Clamp01(t));
					setAlpha(p);
					if (update != null)
					{
						update(p);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				setAlpha(to);
				if (!pingPong)
				{
					goto IL_331;
				}
				if (delay > 0f)
				{
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					return true;
				}
				IL_258:
				t = 0f;
				IL_310:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p2 = Ease.Types[type](to, from, Mathf.Clamp01(t));
					setAlpha(p2);
					if (update != null)
					{
						update(p2);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					return true;
				}
				setAlpha(from);
				IL_331:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_377:
				if (repeat != 0 && repeat != -1 && counter <= 0)
				{
					if (repeat != 0 && complete != null)
					{
						complete();
					}
					this.$PC = -1;
				}
				else
				{
					if (delay <= 0f)
					{
						goto IL_10A;
					}
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 1;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				return false;
			}

			// Token: 0x170010E0 RID: 4320
			// (get) Token: 0x06004FA0 RID: 20384 RVA: 0x0005AA46 File Offset: 0x00058E46
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010E1 RID: 4321
			// (get) Token: 0x06004FA1 RID: 20385 RVA: 0x0005AA4E File Offset: 0x00058E4E
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FA2 RID: 20386 RVA: 0x0005AA56 File Offset: 0x00058E56
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FA3 RID: 20387 RVA: 0x0005AA66 File Offset: 0x00058E66
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D4F RID: 15695
			internal MonoBehaviour m;

			// Token: 0x04003D50 RID: 15696
			internal Action<float> <setAlpha>__0;

			// Token: 0x04003D51 RID: 15697
			internal int repeat;

			// Token: 0x04003D52 RID: 15698
			internal int <counter>__0;

			// Token: 0x04003D53 RID: 15699
			internal float delay;

			// Token: 0x04003D54 RID: 15700
			internal bool realTime;

			// Token: 0x04003D55 RID: 15701
			internal float <t>__1;

			// Token: 0x04003D56 RID: 15702
			internal float time;

			// Token: 0x04003D57 RID: 15703
			internal EaseType type;

			// Token: 0x04003D58 RID: 15704
			internal float from;

			// Token: 0x04003D59 RID: 15705
			internal float to;

			// Token: 0x04003D5A RID: 15706
			internal float <p>__2;

			// Token: 0x04003D5B RID: 15707
			internal Action<float> update;

			// Token: 0x04003D5C RID: 15708
			internal bool pingPong;

			// Token: 0x04003D5D RID: 15709
			internal float <p>__3;

			// Token: 0x04003D5E RID: 15710
			internal Action complete;

			// Token: 0x04003D5F RID: 15711
			internal object $current;

			// Token: 0x04003D60 RID: 15712
			internal bool $disposing;

			// Token: 0x04003D61 RID: 15713
			internal int $PC;

			// Token: 0x04003D62 RID: 15714
			private Ease.<GoAlphaCoroutine>c__Iterator1.<GoAlphaCoroutine>c__AnonStorey2 $locvar0;

			// Token: 0x02000BB8 RID: 3000
			private sealed class <GoAlphaCoroutine>c__AnonStorey2
			{
				// Token: 0x06004FA4 RID: 20388 RVA: 0x0005AA6D File Offset: 0x00058E6D
				public <GoAlphaCoroutine>c__AnonStorey2()
				{
				}

				// Token: 0x06004FA5 RID: 20389 RVA: 0x0005AA78 File Offset: 0x00058E78
				internal void <>m__0(float value)
				{
					if (this.canvasGroup != null)
					{
						this.canvasGroup.alpha = value;
					}
					else if (this.image != null)
					{
						this.image.color = this.image.color.SetAlpha(value);
					}
					else
					{
						Camera.main.backgroundColor = Camera.main.backgroundColor.SetAlpha(value);
					}
				}

				// Token: 0x04003D63 RID: 15715
				internal CanvasGroup canvasGroup;

				// Token: 0x04003D64 RID: 15716
				internal Image image;

				// Token: 0x04003D65 RID: 15717
				internal Ease.<GoAlphaCoroutine>c__Iterator1 <>f__ref$1;
			}
		}
	}
}
