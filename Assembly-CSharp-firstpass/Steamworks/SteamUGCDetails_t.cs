using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000173 RID: 371
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUGCDetails_t
	{
		// Token: 0x0400092D RID: 2349
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x0400092E RID: 2350
		public EResult m_eResult;

		// Token: 0x0400092F RID: 2351
		public EWorkshopFileType m_eFileType;

		// Token: 0x04000930 RID: 2352
		public AppId_t m_nCreatorAppID;

		// Token: 0x04000931 RID: 2353
		public AppId_t m_nConsumerAppID;

		// Token: 0x04000932 RID: 2354
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
		public string m_rgchTitle;

		// Token: 0x04000933 RID: 2355
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)]
		public string m_rgchDescription;

		// Token: 0x04000934 RID: 2356
		public ulong m_ulSteamIDOwner;

		// Token: 0x04000935 RID: 2357
		public uint m_rtimeCreated;

		// Token: 0x04000936 RID: 2358
		public uint m_rtimeUpdated;

		// Token: 0x04000937 RID: 2359
		public uint m_rtimeAddedToUserList;

		// Token: 0x04000938 RID: 2360
		public ERemoteStoragePublishedFileVisibility m_eVisibility;

		// Token: 0x04000939 RID: 2361
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;

		// Token: 0x0400093A RID: 2362
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;

		// Token: 0x0400093B RID: 2363
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;

		// Token: 0x0400093C RID: 2364
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
		public string m_rgchTags;

		// Token: 0x0400093D RID: 2365
		public UGCHandle_t m_hFile;

		// Token: 0x0400093E RID: 2366
		public UGCHandle_t m_hPreviewFile;

		// Token: 0x0400093F RID: 2367
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_pchFileName;

		// Token: 0x04000940 RID: 2368
		public int m_nFileSize;

		// Token: 0x04000941 RID: 2369
		public int m_nPreviewFileSize;

		// Token: 0x04000942 RID: 2370
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;

		// Token: 0x04000943 RID: 2371
		public uint m_unVotesUp;

		// Token: 0x04000944 RID: 2372
		public uint m_unVotesDown;

		// Token: 0x04000945 RID: 2373
		public float m_flScore;

		// Token: 0x04000946 RID: 2374
		public uint m_unNumChildren;
	}
}
