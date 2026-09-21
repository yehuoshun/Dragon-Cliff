using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D8 RID: 216
	[CallbackIdentity(1318)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageGetPublishedFileDetailsResult_t
	{
		// Token: 0x0400037C RID: 892
		public const int k_iCallback = 1318;

		// Token: 0x0400037D RID: 893
		public EResult m_eResult;

		// Token: 0x0400037E RID: 894
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x0400037F RID: 895
		public AppId_t m_nCreatorAppID;

		// Token: 0x04000380 RID: 896
		public AppId_t m_nConsumerAppID;

		// Token: 0x04000381 RID: 897
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
		public string m_rgchTitle;

		// Token: 0x04000382 RID: 898
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)]
		public string m_rgchDescription;

		// Token: 0x04000383 RID: 899
		public UGCHandle_t m_hFile;

		// Token: 0x04000384 RID: 900
		public UGCHandle_t m_hPreviewFile;

		// Token: 0x04000385 RID: 901
		public ulong m_ulSteamIDOwner;

		// Token: 0x04000386 RID: 902
		public uint m_rtimeCreated;

		// Token: 0x04000387 RID: 903
		public uint m_rtimeUpdated;

		// Token: 0x04000388 RID: 904
		public ERemoteStoragePublishedFileVisibility m_eVisibility;

		// Token: 0x04000389 RID: 905
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;

		// Token: 0x0400038A RID: 906
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
		public string m_rgchTags;

		// Token: 0x0400038B RID: 907
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;

		// Token: 0x0400038C RID: 908
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_pchFileName;

		// Token: 0x0400038D RID: 909
		public int m_nFileSize;

		// Token: 0x0400038E RID: 910
		public int m_nPreviewFileSize;

		// Token: 0x0400038F RID: 911
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;

		// Token: 0x04000390 RID: 912
		public EWorkshopFileType m_eFileType;

		// Token: 0x04000391 RID: 913
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;
	}
}
