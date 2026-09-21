using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200005C RID: 92
	public class MMKVPMarshaller
	{
		// Token: 0x060003B4 RID: 948 RVA: 0x00010318 File Offset: 0x0000E718
		public MMKVPMarshaller(MatchMakingKeyValuePair_t[] filters)
		{
			if (filters == null)
			{
				return;
			}
			int num = Marshal.SizeOf(typeof(MatchMakingKeyValuePair_t));
			this.m_pNativeArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * filters.Length);
			this.m_pArrayEntries = Marshal.AllocHGlobal(num * filters.Length);
			for (int i = 0; i < filters.Length; i++)
			{
				Marshal.StructureToPtr(filters[i], new IntPtr(this.m_pArrayEntries.ToInt64() + (long)(i * num)), false);
			}
			Marshal.WriteIntPtr(this.m_pNativeArray, this.m_pArrayEntries);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x000103C4 File Offset: 0x0000E7C4
		~MMKVPMarshaller()
		{
			if (this.m_pArrayEntries != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pArrayEntries);
			}
			if (this.m_pNativeArray != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pNativeArray);
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00010430 File Offset: 0x0000E830
		public static implicit operator IntPtr(MMKVPMarshaller that)
		{
			return that.m_pNativeArray;
		}

		// Token: 0x040001C0 RID: 448
		private IntPtr m_pNativeArray;

		// Token: 0x040001C1 RID: 449
		private IntPtr m_pArrayEntries;
	}
}
