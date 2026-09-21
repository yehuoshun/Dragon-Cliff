using System;
using UnityEngine;

// Token: 0x020001BE RID: 446
public class AspectUtility : MonoBehaviour
{
	// Token: 0x06000C10 RID: 3088 RVA: 0x0001B2B0 File Offset: 0x000196B0
	public AspectUtility()
	{
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x0001B2C4 File Offset: 0x000196C4
	private void Awake()
	{
		AspectUtility.cam = base.GetComponent<Camera>();
		if (!AspectUtility.cam)
		{
			AspectUtility.cam = Camera.main;
		}
		if (!AspectUtility.cam)
		{
			Debug.LogError("No camera available");
			return;
		}
		AspectUtility.wantedAspectRatio = this._wantedAspectRatio;
		AspectUtility.SetCamera();
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0001B320 File Offset: 0x00019720
	public static void SetCamera()
	{
		float num = (float)Screen.width / (float)Screen.height;
		if ((float)((int)(num * 100f)) / 100f == (float)((int)(AspectUtility.wantedAspectRatio * 100f)) / 100f)
		{
			AspectUtility.cam.rect = new Rect(0f, 0f, 1f, 1f);
			if (AspectUtility.backgroundCam)
			{
				UnityEngine.Object.Destroy(AspectUtility.backgroundCam.gameObject);
			}
			return;
		}
		if (num > AspectUtility.wantedAspectRatio)
		{
			float num2 = 1f - AspectUtility.wantedAspectRatio / num;
			AspectUtility.cam.rect = new Rect(num2 / 2f, 0f, 1f - num2, 1f);
		}
		else
		{
			float num3 = 1f - num / AspectUtility.wantedAspectRatio;
			AspectUtility.cam.rect = new Rect(0f, num3 / 2f, 1f, 1f - num3);
		}
		if (!AspectUtility.backgroundCam)
		{
			AspectUtility.backgroundCam = new GameObject("BackgroundCam", new Type[]
			{
				typeof(Camera)
			}).GetComponent<Camera>();
			AspectUtility.backgroundCam.depth = -2.14748365E+09f;
			AspectUtility.backgroundCam.clearFlags = CameraClearFlags.Color;
			AspectUtility.backgroundCam.backgroundColor = Color.black;
			AspectUtility.backgroundCam.cullingMask = 0;
		}
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000C13 RID: 3091 RVA: 0x0001B488 File Offset: 0x00019888
	public static int screenHeight
	{
		get
		{
			return (int)((float)Screen.height * AspectUtility.cam.rect.height);
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000C14 RID: 3092 RVA: 0x0001B4B0 File Offset: 0x000198B0
	public static int screenWidth
	{
		get
		{
			return (int)((float)Screen.width * AspectUtility.cam.rect.width);
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000C15 RID: 3093 RVA: 0x0001B4D8 File Offset: 0x000198D8
	public static int xOffset
	{
		get
		{
			return (int)((float)Screen.width * AspectUtility.cam.rect.x);
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x06000C16 RID: 3094 RVA: 0x0001B500 File Offset: 0x00019900
	public static int yOffset
	{
		get
		{
			return (int)((float)Screen.height * AspectUtility.cam.rect.y);
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000C17 RID: 3095 RVA: 0x0001B528 File Offset: 0x00019928
	public static Rect screenRect
	{
		get
		{
			return new Rect(AspectUtility.cam.rect.x * (float)Screen.width, AspectUtility.cam.rect.y * (float)Screen.height, AspectUtility.cam.rect.width * (float)Screen.width, AspectUtility.cam.rect.height * (float)Screen.height);
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000C18 RID: 3096 RVA: 0x0001B5A0 File Offset: 0x000199A0
	public static Vector3 mousePosition
	{
		get
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.y -= (float)((int)(AspectUtility.cam.rect.y * (float)Screen.height));
			mousePosition.x -= (float)((int)(AspectUtility.cam.rect.x * (float)Screen.width));
			return mousePosition;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x06000C19 RID: 3097 RVA: 0x0001B608 File Offset: 0x00019A08
	public static Vector2 guiMousePosition
	{
		get
		{
			Vector2 mousePosition = Event.current.mousePosition;
			mousePosition.y = Mathf.Clamp(mousePosition.y, AspectUtility.cam.rect.y * (float)Screen.height, AspectUtility.cam.rect.y * (float)Screen.height + AspectUtility.cam.rect.height * (float)Screen.height);
			mousePosition.x = Mathf.Clamp(mousePosition.x, AspectUtility.cam.rect.x * (float)Screen.width, AspectUtility.cam.rect.x * (float)Screen.width + AspectUtility.cam.rect.width * (float)Screen.width);
			return mousePosition;
		}
	}

	// Token: 0x040009A9 RID: 2473
	public float _wantedAspectRatio = 1.33333325f;

	// Token: 0x040009AA RID: 2474
	private static float wantedAspectRatio;

	// Token: 0x040009AB RID: 2475
	private static Camera cam;

	// Token: 0x040009AC RID: 2476
	private static Camera backgroundCam;
}
