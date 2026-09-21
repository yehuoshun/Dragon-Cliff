using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Steamworks
{
	// Token: 0x02000059 RID: 89
	public class InteropHelp
	{
		// Token: 0x060003AA RID: 938 RVA: 0x0000FFF0 File Offset: 0x0000E3F0
		public InteropHelp()
		{
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000FFF8 File Offset: 0x0000E3F8
		public static void TestIfPlatformSupported()
		{
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000FFFA File Offset: 0x0000E3FA
		public static void TestIfAvailableClient()
		{
			InteropHelp.TestIfPlatformSupported();
			if (CSteamAPIContext.GetSteamClient() == IntPtr.Zero && !CSteamAPIContext.Init())
			{
				throw new InvalidOperationException("Steamworks is not initialized.");
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0001002A File Offset: 0x0000E42A
		public static void TestIfAvailableGameServer()
		{
			InteropHelp.TestIfPlatformSupported();
			if (CSteamGameServerAPIContext.GetSteamClient() == IntPtr.Zero && !CSteamGameServerAPIContext.Init())
			{
				throw new InvalidOperationException("Steamworks GameServer is not initialized.");
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0001005C File Offset: 0x0000E45C
		public static string PtrToStringUTF8(IntPtr nativeUtf8)
		{
			if (nativeUtf8 == IntPtr.Zero)
			{
				return null;
			}
			int num = 0;
			while (Marshal.ReadByte(nativeUtf8, num) != 0)
			{
				num++;
			}
			if (num == 0)
			{
				return string.Empty;
			}
			byte[] array = new byte[num];
			Marshal.Copy(nativeUtf8, array, 0, array.Length);
			return Encoding.UTF8.GetString(array);
		}

		// Token: 0x0200005A RID: 90
		public class UTF8StringHandle : SafeHandleZeroOrMinusOneIsInvalid
		{
			// Token: 0x060003AF RID: 943 RVA: 0x000100BC File Offset: 0x0000E4BC
			public UTF8StringHandle(string str) : base(true)
			{
				if (str == null)
				{
					base.SetHandle(IntPtr.Zero);
					return;
				}
				byte[] array = new byte[Encoding.UTF8.GetByteCount(str) + 1];
				Encoding.UTF8.GetBytes(str, 0, str.Length, array, 0);
				IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
				Marshal.Copy(array, 0, intPtr, array.Length);
				base.SetHandle(intPtr);
			}

			// Token: 0x060003B0 RID: 944 RVA: 0x00010125 File Offset: 0x0000E525
			protected override bool ReleaseHandle()
			{
				if (!this.IsInvalid)
				{
					Marshal.FreeHGlobal(this.handle);
				}
				return true;
			}
		}

		// Token: 0x0200005B RID: 91
		public class SteamParamStringArray
		{
			// Token: 0x060003B1 RID: 945 RVA: 0x00010140 File Offset: 0x0000E540
			public SteamParamStringArray(IList<string> strings)
			{
				if (strings == null)
				{
					this.m_pSteamParamStringArray = IntPtr.Zero;
					return;
				}
				this.m_Strings = new IntPtr[strings.Count];
				for (int i = 0; i < strings.Count; i++)
				{
					byte[] array = new byte[Encoding.UTF8.GetByteCount(strings[i]) + 1];
					Encoding.UTF8.GetBytes(strings[i], 0, strings[i].Length, array, 0);
					this.m_Strings[i] = Marshal.AllocHGlobal(array.Length);
					Marshal.Copy(array, 0, this.m_Strings[i], array.Length);
				}
				this.m_ptrStrings = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * this.m_Strings.Length);
				SteamParamStringArray_t steamParamStringArray_t = new SteamParamStringArray_t
				{
					m_ppStrings = this.m_ptrStrings,
					m_nNumStrings = this.m_Strings.Length
				};
				Marshal.Copy(this.m_Strings, 0, steamParamStringArray_t.m_ppStrings, this.m_Strings.Length);
				this.m_pSteamParamStringArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SteamParamStringArray_t)));
				Marshal.StructureToPtr(steamParamStringArray_t, this.m_pSteamParamStringArray, false);
			}

			// Token: 0x060003B2 RID: 946 RVA: 0x00010280 File Offset: 0x0000E680
			protected override void Finalize()
			{
				try
				{
					foreach (IntPtr hglobal in this.m_Strings)
					{
						Marshal.FreeHGlobal(hglobal);
					}
					if (this.m_ptrStrings != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(this.m_ptrStrings);
					}
					if (this.m_pSteamParamStringArray != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(this.m_pSteamParamStringArray);
					}
				}
				finally
				{
					base.Finalize();
				}
			}

			// Token: 0x060003B3 RID: 947 RVA: 0x00010310 File Offset: 0x0000E710
			public static implicit operator IntPtr(InteropHelp.SteamParamStringArray that)
			{
				return that.m_pSteamParamStringArray;
			}

			// Token: 0x040001BD RID: 445
			private IntPtr[] m_Strings;

			// Token: 0x040001BE RID: 446
			private IntPtr m_ptrStrings;

			// Token: 0x040001BF RID: 447
			private IntPtr m_pSteamParamStringArray;
		}
	}
}
