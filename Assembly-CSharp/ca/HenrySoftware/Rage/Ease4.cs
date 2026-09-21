using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ca.HenrySoftware.Rage
{
	// Token: 0x020000A3 RID: 163
	public static class Ease4
	{
		// Token: 0x06000531 RID: 1329 RVA: 0x0005CF74 File Offset: 0x0005B374
		public static IEnumerator Go(MonoBehaviour m, Vector4 from, Vector4 to, float time, Action<Vector4> update, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease4.GoCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0005CFA4 File Offset: 0x0005B3A4
		private static IEnumerator GoCoroutine(MonoBehaviour m, Vector4 from, Vector4 to, float time, Action<Vector4> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
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
					update(Ease4.Types[type](from, to, Mathf.Clamp01(t)));
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
						update(Ease4.Types[type](to, from, Mathf.Clamp01(t)));
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

		// Token: 0x06000533 RID: 1331 RVA: 0x0005D008 File Offset: 0x0005B408
		private static Color GetColor(MonoBehaviour m)
		{
			Image component = m.GetComponent<Image>();
			return (!(component == null)) ? component.color : Camera.main.backgroundColor;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0005D040 File Offset: 0x0005B440
		public static IEnumerator GoColorTo(MonoBehaviour m, Vector4 to, float time, Action<Vector4> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			return Ease4.GoColor(m, Ease4.GetColor(m).GetVector4(), to, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0005D070 File Offset: 0x0005B470
		public static IEnumerator GoColorBy(MonoBehaviour m, Vector4 by, float time, Action<Vector4> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			Vector4 vector = Ease4.GetColor(m).GetVector4();
			return Ease4.GoColor(m, vector, vector + by, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0005D0A8 File Offset: 0x0005B4A8
		public static IEnumerator GoColor(MonoBehaviour m, Vector4 from, Vector4 to, float time, Action<Vector4> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease4.GoColorCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0005D0D8 File Offset: 0x0005B4D8
		private static IEnumerator GoColorCoroutine(MonoBehaviour m, Vector4 from, Vector4 to, float time, Action<Vector4> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			Image image = m.GetComponent<Image>();
			Camera camera = Camera.main;
			Action<Vector4> setColor = delegate(Vector4 value)
			{
				if (image == null)
				{
					camera.backgroundColor = value.GetColor();
				}
				else
				{
					image.color = value.GetColor();
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
					Vector4 p = Ease4.Types[type](from, to, Mathf.Clamp01(t));
					setColor(p);
					if (update != null)
					{
						update(p);
					}
					yield return null;
				}
				setColor(to);
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
						Vector4 p2 = Ease4.Types[type](to, from, Mathf.Clamp01(t));
						setColor(p2);
						if (update != null)
						{
							update(p2);
						}
						yield return null;
					}
					setColor(from);
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

		// Token: 0x06000538 RID: 1336 RVA: 0x0005D140 File Offset: 0x0005B540
		// Note: this type is marked as 'beforefieldinit'.
		static Ease4()
		{
			Dictionary<EaseType, Func<Vector4, Vector4, float, Vector4>> dictionary = new Dictionary<EaseType, Func<Vector4, Vector4, float, Vector4>>();
			Dictionary<EaseType, Func<Vector4, Vector4, float, Vector4>> dictionary2 = dictionary;
			EaseType key = EaseType.Linear;
			if (Ease4.<>f__mg$cache0 == null)
			{
				Ease4.<>f__mg$cache0 = new Func<Vector4, Vector4, float, Vector4>(Vector4.Lerp);
			}
			dictionary2.Add(key, Ease4.<>f__mg$cache0);
			dictionary.Add(EaseType.SineIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.SineIn(from.x, to.x, time), Ease.SineIn(from.y, to.y, time), Ease.SineIn(from.z, to.z, time), Ease.SineIn(from.w, to.w, time)));
			dictionary.Add(EaseType.SineOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.SineOut(from.x, to.x, time), Ease.SineOut(from.y, to.y, time), Ease.SineOut(from.z, to.z, time), Ease.SineOut(from.w, to.w, time)));
			dictionary.Add(EaseType.SineInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.SineInOut(from.x, to.x, time), Ease.SineInOut(from.y, to.y, time), Ease.SineInOut(from.z, to.z, time), Ease.SineInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.QuadIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuadIn(from.x, to.x, time), Ease.QuadIn(from.y, to.y, time), Ease.QuadIn(from.z, to.z, time), Ease.QuadIn(from.w, to.w, time)));
			dictionary.Add(EaseType.QuadOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuadOut(from.x, to.x, time), Ease.QuadOut(from.y, to.y, time), Ease.QuadOut(from.z, to.z, time), Ease.QuadOut(from.w, to.w, time)));
			dictionary.Add(EaseType.QuadInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuadInOut(from.x, to.x, time), Ease.QuadInOut(from.y, to.y, time), Ease.QuadInOut(from.z, to.z, time), Ease.QuadInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.CubicIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.CubicIn(from.x, to.x, time), Ease.CubicIn(from.y, to.y, time), Ease.CubicIn(from.z, to.z, time), Ease.CubicIn(from.w, to.w, time)));
			dictionary.Add(EaseType.CubicOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.CubicOut(from.x, to.x, time), Ease.CubicOut(from.y, to.y, time), Ease.CubicOut(from.z, to.z, time), Ease.CubicOut(from.w, to.w, time)));
			dictionary.Add(EaseType.CubicInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.CubicInOut(from.x, to.x, time), Ease.CubicInOut(from.y, to.y, time), Ease.CubicInOut(from.z, to.z, time), Ease.CubicInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.QuartIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuartIn(from.x, to.x, time), Ease.QuartIn(from.y, to.y, time), Ease.QuartIn(from.z, to.z, time), Ease.QuartIn(from.w, to.w, time)));
			dictionary.Add(EaseType.QuartOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuartOut(from.x, to.x, time), Ease.QuartOut(from.y, to.y, time), Ease.QuartOut(from.z, to.z, time), Ease.QuartOut(from.w, to.w, time)));
			dictionary.Add(EaseType.QuartInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuartInOut(from.x, to.x, time), Ease.QuartInOut(from.y, to.y, time), Ease.QuartInOut(from.z, to.z, time), Ease.QuartInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.QuintIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuintIn(from.x, to.x, time), Ease.QuintIn(from.y, to.y, time), Ease.QuintIn(from.z, to.z, time), Ease.QuintIn(from.w, to.w, time)));
			dictionary.Add(EaseType.QuintOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuintOut(from.x, to.x, time), Ease.QuintOut(from.y, to.y, time), Ease.QuintOut(from.z, to.z, time), Ease.QuintOut(from.w, to.w, time)));
			dictionary.Add(EaseType.QuintInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.QuintInOut(from.x, to.x, time), Ease.QuintInOut(from.y, to.y, time), Ease.QuintInOut(from.z, to.z, time), Ease.QuintInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.ExpoIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.ExpoIn(from.x, to.x, time), Ease.ExpoIn(from.y, to.y, time), Ease.ExpoIn(from.z, to.z, time), Ease.ExpoIn(from.w, to.w, time)));
			dictionary.Add(EaseType.ExpoOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.ExpoOut(from.x, to.x, time), Ease.ExpoOut(from.y, to.y, time), Ease.ExpoOut(from.z, to.z, time), Ease.ExpoOut(from.w, to.w, time)));
			dictionary.Add(EaseType.ExpoInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.ExpoInOut(from.x, to.x, time), Ease.ExpoInOut(from.y, to.y, time), Ease.ExpoInOut(from.z, to.z, time), Ease.ExpoInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.CircIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.CircIn(from.x, to.x, time), Ease.CircIn(from.y, to.y, time), Ease.CircIn(from.z, to.z, time), Ease.CircIn(from.w, to.w, time)));
			dictionary.Add(EaseType.CircOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.CircOut(from.x, to.x, time), Ease.CircOut(from.y, to.y, time), Ease.CircOut(from.z, to.z, time), Ease.CircOut(from.w, to.w, time)));
			dictionary.Add(EaseType.CircInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.CircInOut(from.x, to.x, time), Ease.CircInOut(from.y, to.y, time), Ease.CircInOut(from.z, to.z, time), Ease.CircInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.BackIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.BackIn(from.x, to.x, time), Ease.BackIn(from.y, to.y, time), Ease.BackIn(from.z, to.z, time), Ease.BackIn(from.w, to.w, time)));
			dictionary.Add(EaseType.BackOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.BackOut(from.x, to.x, time), Ease.BackOut(from.y, to.y, time), Ease.BackOut(from.z, to.z, time), Ease.BackOut(from.w, to.w, time)));
			dictionary.Add(EaseType.BackInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.BackInOut(from.x, to.x, time), Ease.BackInOut(from.y, to.y, time), Ease.BackInOut(from.z, to.z, time), Ease.BackInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.ElasticIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.ElasticIn(from.x, to.x, time), Ease.ElasticIn(from.y, to.y, time), Ease.ElasticIn(from.z, to.z, time), Ease.ElasticIn(from.w, to.w, time)));
			dictionary.Add(EaseType.ElasticOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.ElasticOut(from.x, to.x, time), Ease.ElasticOut(from.y, to.y, time), Ease.ElasticOut(from.z, to.z, time), Ease.ElasticOut(from.w, to.w, time)));
			dictionary.Add(EaseType.ElasticInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.ElasticInOut(from.x, to.x, time), Ease.ElasticInOut(from.y, to.y, time), Ease.ElasticInOut(from.z, to.z, time), Ease.ElasticInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.BounceIn, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.BounceIn(from.x, to.x, time), Ease.BounceIn(from.y, to.y, time), Ease.BounceIn(from.z, to.z, time), Ease.BounceIn(from.w, to.w, time)));
			dictionary.Add(EaseType.BounceOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.BounceOut(from.x, to.x, time), Ease.BounceOut(from.y, to.y, time), Ease.BounceOut(from.z, to.z, time), Ease.BounceOut(from.w, to.w, time)));
			dictionary.Add(EaseType.BounceInOut, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.BounceInOut(from.x, to.x, time), Ease.BounceInOut(from.y, to.y, time), Ease.BounceInOut(from.z, to.z, time), Ease.BounceInOut(from.w, to.w, time)));
			dictionary.Add(EaseType.Spring, (Vector4 from, Vector4 to, float time) => new Vector4(Ease.Spring(from.x, to.x, time), Ease.Spring(from.y, to.y, time), Ease.Spring(from.z, to.z, time), Ease.Spring(from.w, to.w, time)));
			Ease4.Types = dictionary;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0005D3E4 File Offset: 0x0005B7E4
		[CompilerGenerated]
		private static Vector4 <Types>m__0(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.SineIn(from.x, to.x, time), Ease.SineIn(from.y, to.y, time), Ease.SineIn(from.z, to.z, time), Ease.SineIn(from.w, to.w, time));
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0005D448 File Offset: 0x0005B848
		[CompilerGenerated]
		private static Vector4 <Types>m__1(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.SineOut(from.x, to.x, time), Ease.SineOut(from.y, to.y, time), Ease.SineOut(from.z, to.z, time), Ease.SineOut(from.w, to.w, time));
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0005D4AC File Offset: 0x0005B8AC
		[CompilerGenerated]
		private static Vector4 <Types>m__2(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.SineInOut(from.x, to.x, time), Ease.SineInOut(from.y, to.y, time), Ease.SineInOut(from.z, to.z, time), Ease.SineInOut(from.w, to.w, time));
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0005D510 File Offset: 0x0005B910
		[CompilerGenerated]
		private static Vector4 <Types>m__3(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuadIn(from.x, to.x, time), Ease.QuadIn(from.y, to.y, time), Ease.QuadIn(from.z, to.z, time), Ease.QuadIn(from.w, to.w, time));
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0005D574 File Offset: 0x0005B974
		[CompilerGenerated]
		private static Vector4 <Types>m__4(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuadOut(from.x, to.x, time), Ease.QuadOut(from.y, to.y, time), Ease.QuadOut(from.z, to.z, time), Ease.QuadOut(from.w, to.w, time));
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0005D5D8 File Offset: 0x0005B9D8
		[CompilerGenerated]
		private static Vector4 <Types>m__5(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuadInOut(from.x, to.x, time), Ease.QuadInOut(from.y, to.y, time), Ease.QuadInOut(from.z, to.z, time), Ease.QuadInOut(from.w, to.w, time));
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0005D63C File Offset: 0x0005BA3C
		[CompilerGenerated]
		private static Vector4 <Types>m__6(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.CubicIn(from.x, to.x, time), Ease.CubicIn(from.y, to.y, time), Ease.CubicIn(from.z, to.z, time), Ease.CubicIn(from.w, to.w, time));
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0005D6A0 File Offset: 0x0005BAA0
		[CompilerGenerated]
		private static Vector4 <Types>m__7(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.CubicOut(from.x, to.x, time), Ease.CubicOut(from.y, to.y, time), Ease.CubicOut(from.z, to.z, time), Ease.CubicOut(from.w, to.w, time));
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0005D704 File Offset: 0x0005BB04
		[CompilerGenerated]
		private static Vector4 <Types>m__8(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.CubicInOut(from.x, to.x, time), Ease.CubicInOut(from.y, to.y, time), Ease.CubicInOut(from.z, to.z, time), Ease.CubicInOut(from.w, to.w, time));
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0005D768 File Offset: 0x0005BB68
		[CompilerGenerated]
		private static Vector4 <Types>m__9(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuartIn(from.x, to.x, time), Ease.QuartIn(from.y, to.y, time), Ease.QuartIn(from.z, to.z, time), Ease.QuartIn(from.w, to.w, time));
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0005D7CC File Offset: 0x0005BBCC
		[CompilerGenerated]
		private static Vector4 <Types>m__A(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuartOut(from.x, to.x, time), Ease.QuartOut(from.y, to.y, time), Ease.QuartOut(from.z, to.z, time), Ease.QuartOut(from.w, to.w, time));
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0005D830 File Offset: 0x0005BC30
		[CompilerGenerated]
		private static Vector4 <Types>m__B(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuartInOut(from.x, to.x, time), Ease.QuartInOut(from.y, to.y, time), Ease.QuartInOut(from.z, to.z, time), Ease.QuartInOut(from.w, to.w, time));
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0005D894 File Offset: 0x0005BC94
		[CompilerGenerated]
		private static Vector4 <Types>m__C(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuintIn(from.x, to.x, time), Ease.QuintIn(from.y, to.y, time), Ease.QuintIn(from.z, to.z, time), Ease.QuintIn(from.w, to.w, time));
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0005D8F8 File Offset: 0x0005BCF8
		[CompilerGenerated]
		private static Vector4 <Types>m__D(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuintOut(from.x, to.x, time), Ease.QuintOut(from.y, to.y, time), Ease.QuintOut(from.z, to.z, time), Ease.QuintOut(from.w, to.w, time));
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0005D95C File Offset: 0x0005BD5C
		[CompilerGenerated]
		private static Vector4 <Types>m__E(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.QuintInOut(from.x, to.x, time), Ease.QuintInOut(from.y, to.y, time), Ease.QuintInOut(from.z, to.z, time), Ease.QuintInOut(from.w, to.w, time));
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0005D9C0 File Offset: 0x0005BDC0
		[CompilerGenerated]
		private static Vector4 <Types>m__F(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.ExpoIn(from.x, to.x, time), Ease.ExpoIn(from.y, to.y, time), Ease.ExpoIn(from.z, to.z, time), Ease.ExpoIn(from.w, to.w, time));
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0005DA24 File Offset: 0x0005BE24
		[CompilerGenerated]
		private static Vector4 <Types>m__10(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.ExpoOut(from.x, to.x, time), Ease.ExpoOut(from.y, to.y, time), Ease.ExpoOut(from.z, to.z, time), Ease.ExpoOut(from.w, to.w, time));
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0005DA88 File Offset: 0x0005BE88
		[CompilerGenerated]
		private static Vector4 <Types>m__11(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.ExpoInOut(from.x, to.x, time), Ease.ExpoInOut(from.y, to.y, time), Ease.ExpoInOut(from.z, to.z, time), Ease.ExpoInOut(from.w, to.w, time));
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0005DAEC File Offset: 0x0005BEEC
		[CompilerGenerated]
		private static Vector4 <Types>m__12(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.CircIn(from.x, to.x, time), Ease.CircIn(from.y, to.y, time), Ease.CircIn(from.z, to.z, time), Ease.CircIn(from.w, to.w, time));
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0005DB50 File Offset: 0x0005BF50
		[CompilerGenerated]
		private static Vector4 <Types>m__13(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.CircOut(from.x, to.x, time), Ease.CircOut(from.y, to.y, time), Ease.CircOut(from.z, to.z, time), Ease.CircOut(from.w, to.w, time));
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0005DBB4 File Offset: 0x0005BFB4
		[CompilerGenerated]
		private static Vector4 <Types>m__14(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.CircInOut(from.x, to.x, time), Ease.CircInOut(from.y, to.y, time), Ease.CircInOut(from.z, to.z, time), Ease.CircInOut(from.w, to.w, time));
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0005DC18 File Offset: 0x0005C018
		[CompilerGenerated]
		private static Vector4 <Types>m__15(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.BackIn(from.x, to.x, time), Ease.BackIn(from.y, to.y, time), Ease.BackIn(from.z, to.z, time), Ease.BackIn(from.w, to.w, time));
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0005DC7C File Offset: 0x0005C07C
		[CompilerGenerated]
		private static Vector4 <Types>m__16(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.BackOut(from.x, to.x, time), Ease.BackOut(from.y, to.y, time), Ease.BackOut(from.z, to.z, time), Ease.BackOut(from.w, to.w, time));
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0005DCE0 File Offset: 0x0005C0E0
		[CompilerGenerated]
		private static Vector4 <Types>m__17(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.BackInOut(from.x, to.x, time), Ease.BackInOut(from.y, to.y, time), Ease.BackInOut(from.z, to.z, time), Ease.BackInOut(from.w, to.w, time));
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0005DD44 File Offset: 0x0005C144
		[CompilerGenerated]
		private static Vector4 <Types>m__18(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.ElasticIn(from.x, to.x, time), Ease.ElasticIn(from.y, to.y, time), Ease.ElasticIn(from.z, to.z, time), Ease.ElasticIn(from.w, to.w, time));
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0005DDA8 File Offset: 0x0005C1A8
		[CompilerGenerated]
		private static Vector4 <Types>m__19(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.ElasticOut(from.x, to.x, time), Ease.ElasticOut(from.y, to.y, time), Ease.ElasticOut(from.z, to.z, time), Ease.ElasticOut(from.w, to.w, time));
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0005DE0C File Offset: 0x0005C20C
		[CompilerGenerated]
		private static Vector4 <Types>m__1A(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.ElasticInOut(from.x, to.x, time), Ease.ElasticInOut(from.y, to.y, time), Ease.ElasticInOut(from.z, to.z, time), Ease.ElasticInOut(from.w, to.w, time));
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0005DE70 File Offset: 0x0005C270
		[CompilerGenerated]
		private static Vector4 <Types>m__1B(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.BounceIn(from.x, to.x, time), Ease.BounceIn(from.y, to.y, time), Ease.BounceIn(from.z, to.z, time), Ease.BounceIn(from.w, to.w, time));
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0005DED4 File Offset: 0x0005C2D4
		[CompilerGenerated]
		private static Vector4 <Types>m__1C(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.BounceOut(from.x, to.x, time), Ease.BounceOut(from.y, to.y, time), Ease.BounceOut(from.z, to.z, time), Ease.BounceOut(from.w, to.w, time));
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0005DF38 File Offset: 0x0005C338
		[CompilerGenerated]
		private static Vector4 <Types>m__1D(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.BounceInOut(from.x, to.x, time), Ease.BounceInOut(from.y, to.y, time), Ease.BounceInOut(from.z, to.z, time), Ease.BounceInOut(from.w, to.w, time));
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0005DF9C File Offset: 0x0005C39C
		[CompilerGenerated]
		private static Vector4 <Types>m__1E(Vector4 from, Vector4 to, float time)
		{
			return new Vector4(Ease.Spring(from.x, to.x, time), Ease.Spring(from.y, to.y, time), Ease.Spring(from.z, to.z, time), Ease.Spring(from.w, to.w, time));
		}

		// Token: 0x04000890 RID: 2192
		private static readonly Dictionary<EaseType, Func<Vector4, Vector4, float, Vector4>> Types;

		// Token: 0x04000891 RID: 2193
		[CompilerGenerated]
		private static Func<Vector4, Vector4, float, Vector4> <>f__mg$cache0;

		// Token: 0x02000BC0 RID: 3008
		[CompilerGenerated]
		private sealed class <GoCoroutine>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004FC8 RID: 20424 RVA: 0x0005DFFE File Offset: 0x0005C3FE
			[DebuggerHidden]
			public <GoCoroutine>c__Iterator0()
			{
			}

			// Token: 0x06004FC9 RID: 20425 RVA: 0x0005E008 File Offset: 0x0005C408
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
					update(Ease4.Types[type](from, to, Mathf.Clamp01(t)));
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
					update(Ease4.Types[type](to, from, Mathf.Clamp01(t)));
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

			// Token: 0x170010EC RID: 4332
			// (get) Token: 0x06004FCA RID: 20426 RVA: 0x0005E30E File Offset: 0x0005C70E
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010ED RID: 4333
			// (get) Token: 0x06004FCB RID: 20427 RVA: 0x0005E316 File Offset: 0x0005C716
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FCC RID: 20428 RVA: 0x0005E31E File Offset: 0x0005C71E
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FCD RID: 20429 RVA: 0x0005E32E File Offset: 0x0005C72E
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003DC6 RID: 15814
			internal int repeat;

			// Token: 0x04003DC7 RID: 15815
			internal int <counter>__0;

			// Token: 0x04003DC8 RID: 15816
			internal float delay;

			// Token: 0x04003DC9 RID: 15817
			internal bool realTime;

			// Token: 0x04003DCA RID: 15818
			internal float <t>__1;

			// Token: 0x04003DCB RID: 15819
			internal float time;

			// Token: 0x04003DCC RID: 15820
			internal Action<Vector4> update;

			// Token: 0x04003DCD RID: 15821
			internal EaseType type;

			// Token: 0x04003DCE RID: 15822
			internal Vector4 from;

			// Token: 0x04003DCF RID: 15823
			internal Vector4 to;

			// Token: 0x04003DD0 RID: 15824
			internal bool pingPong;

			// Token: 0x04003DD1 RID: 15825
			internal Action complete;

			// Token: 0x04003DD2 RID: 15826
			internal object $current;

			// Token: 0x04003DD3 RID: 15827
			internal bool $disposing;

			// Token: 0x04003DD4 RID: 15828
			internal int $PC;
		}

		// Token: 0x02000BC1 RID: 3009
		[CompilerGenerated]
		private sealed class <GoColorCoroutine>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004FCE RID: 20430 RVA: 0x0005E335 File Offset: 0x0005C735
			[DebuggerHidden]
			public <GoColorCoroutine>c__Iterator1()
			{
			}

			// Token: 0x06004FCF RID: 20431 RVA: 0x0005E340 File Offset: 0x0005C740
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
				{
					Image image = m.GetComponent<Image>();
					Camera camera = Camera.main;
					setColor = delegate(Vector4 value)
					{
						if (image == null)
						{
							camera.backgroundColor = value.GetColor();
						}
						else
						{
							image.color = value.GetColor();
						}
					};
					counter = repeat;
					goto IL_371;
				}
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_1BC;
				case 4u:
					goto IL_252;
				case 5u:
					goto IL_252;
				case 6u:
					goto IL_30A;
				default:
					return false;
				}
				IL_104:
				t = 0f;
				IL_1BC:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p = Ease4.Types[type](from, to, Mathf.Clamp01(t));
					setColor(p);
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
				setColor(to);
				if (!pingPong)
				{
					goto IL_32B;
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
				IL_252:
				t = 0f;
				IL_30A:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p2 = Ease4.Types[type](to, from, Mathf.Clamp01(t));
					setColor(p2);
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
				setColor(from);
				IL_32B:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_371:
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
						goto IL_104;
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

			// Token: 0x170010EE RID: 4334
			// (get) Token: 0x06004FD0 RID: 20432 RVA: 0x0005E70C File Offset: 0x0005CB0C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010EF RID: 4335
			// (get) Token: 0x06004FD1 RID: 20433 RVA: 0x0005E714 File Offset: 0x0005CB14
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FD2 RID: 20434 RVA: 0x0005E71C File Offset: 0x0005CB1C
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FD3 RID: 20435 RVA: 0x0005E72C File Offset: 0x0005CB2C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003DD5 RID: 15829
			internal MonoBehaviour m;

			// Token: 0x04003DD6 RID: 15830
			internal Action<Vector4> <setColor>__0;

			// Token: 0x04003DD7 RID: 15831
			internal int repeat;

			// Token: 0x04003DD8 RID: 15832
			internal int <counter>__0;

			// Token: 0x04003DD9 RID: 15833
			internal float delay;

			// Token: 0x04003DDA RID: 15834
			internal bool realTime;

			// Token: 0x04003DDB RID: 15835
			internal float <t>__1;

			// Token: 0x04003DDC RID: 15836
			internal float time;

			// Token: 0x04003DDD RID: 15837
			internal EaseType type;

			// Token: 0x04003DDE RID: 15838
			internal Vector4 from;

			// Token: 0x04003DDF RID: 15839
			internal Vector4 to;

			// Token: 0x04003DE0 RID: 15840
			internal Vector4 <p>__2;

			// Token: 0x04003DE1 RID: 15841
			internal Action<Vector4> update;

			// Token: 0x04003DE2 RID: 15842
			internal bool pingPong;

			// Token: 0x04003DE3 RID: 15843
			internal Vector4 <p>__3;

			// Token: 0x04003DE4 RID: 15844
			internal Action complete;

			// Token: 0x04003DE5 RID: 15845
			internal object $current;

			// Token: 0x04003DE6 RID: 15846
			internal bool $disposing;

			// Token: 0x04003DE7 RID: 15847
			internal int $PC;

			// Token: 0x04003DE8 RID: 15848
			private Ease4.<GoColorCoroutine>c__Iterator1.<GoColorCoroutine>c__AnonStorey2 $locvar0;

			// Token: 0x02000BC2 RID: 3010
			private sealed class <GoColorCoroutine>c__AnonStorey2
			{
				// Token: 0x06004FD4 RID: 20436 RVA: 0x0005E733 File Offset: 0x0005CB33
				public <GoColorCoroutine>c__AnonStorey2()
				{
				}

				// Token: 0x06004FD5 RID: 20437 RVA: 0x0005E73B File Offset: 0x0005CB3B
				internal void <>m__0(Vector4 value)
				{
					if (this.image == null)
					{
						this.camera.backgroundColor = value.GetColor();
					}
					else
					{
						this.image.color = value.GetColor();
					}
				}

				// Token: 0x04003DE9 RID: 15849
				internal Image image;

				// Token: 0x04003DEA RID: 15850
				internal Camera camera;

				// Token: 0x04003DEB RID: 15851
				internal Ease4.<GoColorCoroutine>c__Iterator1 <>f__ref$1;
			}
		}
	}
}
