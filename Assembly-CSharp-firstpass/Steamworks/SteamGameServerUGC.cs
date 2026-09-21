using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000183 RID: 387
	public static class SteamGameServerUGC
	{
		// Token: 0x0600081A RID: 2074 RVA: 0x000140CB File Offset: 0x000124CB
		public static UGCQueryHandle_t CreateQueryUserUGCRequest(AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryUserUGCRequest(CSteamGameServerAPIContext.GetSteamUGC(), unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x000140EB File Offset: 0x000124EB
		public static UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryAllUGCRequest(CSteamGameServerAPIContext.GetSteamUGC(), eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00014107 File Offset: 0x00012507
		public static UGCQueryHandle_t CreateQueryUGCDetailsRequest(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryUGCDetailsRequest(CSteamGameServerAPIContext.GetSteamUGC(), pvecPublishedFileID, unNumPublishedFileIDs);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0001411F File Offset: 0x0001251F
		public static SteamAPICall_t SendQueryUGCRequest(UGCQueryHandle_t handle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SendQueryUGCRequest(CSteamGameServerAPIContext.GetSteamUGC(), handle);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00014136 File Offset: 0x00012536
		public static bool GetQueryUGCResult(UGCQueryHandle_t handle, uint index, out SteamUGCDetails_t pDetails)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetQueryUGCResult(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, out pDetails);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0001414C File Offset: 0x0001254C
		public static bool GetQueryUGCPreviewURL(UGCQueryHandle_t handle, uint index, out string pchURL, uint cchURLSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchURLSize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCPreviewURL(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, intPtr, cchURLSize);
			pchURL = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00014190 File Offset: 0x00012590
		public static bool GetQueryUGCMetadata(UGCQueryHandle_t handle, uint index, out string pchMetadata, uint cchMetadatasize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchMetadatasize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCMetadata(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, intPtr, cchMetadatasize);
			pchMetadata = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x000141D3 File Offset: 0x000125D3
		public static bool GetQueryUGCChildren(UGCQueryHandle_t handle, uint index, PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetQueryUGCChildren(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, pvecPublishedFileID, cMaxEntries);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x000141E8 File Offset: 0x000125E8
		public static bool GetQueryUGCStatistic(UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, out ulong pStatValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetQueryUGCStatistic(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, eStatType, out pStatValue);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x000141FD File Offset: 0x000125FD
		public static uint GetQueryUGCNumAdditionalPreviews(UGCQueryHandle_t handle, uint index)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetQueryUGCNumAdditionalPreviews(CSteamGameServerAPIContext.GetSteamUGC(), handle, index);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00014210 File Offset: 0x00012610
		public static bool GetQueryUGCAdditionalPreview(UGCQueryHandle_t handle, uint index, uint previewIndex, out string pchURLOrVideoID, uint cchURLSize, out string pchOriginalFileName, uint cchOriginalFileNameSize, out EItemPreviewType pPreviewType)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchURLSize);
			IntPtr intPtr2 = Marshal.AllocHGlobal((int)cchOriginalFileNameSize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCAdditionalPreview(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, previewIndex, intPtr, cchURLSize, intPtr2, cchOriginalFileNameSize, out pPreviewType);
			pchURLOrVideoID = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			pchOriginalFileName = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr2));
			Marshal.FreeHGlobal(intPtr2);
			return flag;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0001427E File Offset: 0x0001267E
		public static uint GetQueryUGCNumKeyValueTags(UGCQueryHandle_t handle, uint index)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetQueryUGCNumKeyValueTags(CSteamGameServerAPIContext.GetSteamUGC(), handle, index);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00014294 File Offset: 0x00012694
		public static bool GetQueryUGCKeyValueTag(UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, out string pchKey, uint cchKeySize, out string pchValue, uint cchValueSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchKeySize);
			IntPtr intPtr2 = Marshal.AllocHGlobal((int)cchValueSize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCKeyValueTag(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, keyValueTagIndex, intPtr, cchKeySize, intPtr2, cchValueSize);
			pchKey = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			pchValue = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr2));
			Marshal.FreeHGlobal(intPtr2);
			return flag;
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00014300 File Offset: 0x00012700
		public static bool ReleaseQueryUGCRequest(UGCQueryHandle_t handle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_ReleaseQueryUGCRequest(CSteamGameServerAPIContext.GetSteamUGC(), handle);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x00014314 File Offset: 0x00012714
		public static bool AddRequiredTag(UGCQueryHandle_t handle, string pTagName)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pTagName))
			{
				result = NativeMethods.ISteamUGC_AddRequiredTag(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00014360 File Offset: 0x00012760
		public static bool AddExcludedTag(UGCQueryHandle_t handle, string pTagName)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pTagName))
			{
				result = NativeMethods.ISteamUGC_AddExcludedTag(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x000143AC File Offset: 0x000127AC
		public static bool SetReturnOnlyIDs(UGCQueryHandle_t handle, bool bReturnOnlyIDs)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnOnlyIDs(CSteamGameServerAPIContext.GetSteamUGC(), handle, bReturnOnlyIDs);
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x000143BF File Offset: 0x000127BF
		public static bool SetReturnKeyValueTags(UGCQueryHandle_t handle, bool bReturnKeyValueTags)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnKeyValueTags(CSteamGameServerAPIContext.GetSteamUGC(), handle, bReturnKeyValueTags);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x000143D2 File Offset: 0x000127D2
		public static bool SetReturnLongDescription(UGCQueryHandle_t handle, bool bReturnLongDescription)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnLongDescription(CSteamGameServerAPIContext.GetSteamUGC(), handle, bReturnLongDescription);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x000143E5 File Offset: 0x000127E5
		public static bool SetReturnMetadata(UGCQueryHandle_t handle, bool bReturnMetadata)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnMetadata(CSteamGameServerAPIContext.GetSteamUGC(), handle, bReturnMetadata);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x000143F8 File Offset: 0x000127F8
		public static bool SetReturnChildren(UGCQueryHandle_t handle, bool bReturnChildren)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnChildren(CSteamGameServerAPIContext.GetSteamUGC(), handle, bReturnChildren);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0001440B File Offset: 0x0001280B
		public static bool SetReturnAdditionalPreviews(UGCQueryHandle_t handle, bool bReturnAdditionalPreviews)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnAdditionalPreviews(CSteamGameServerAPIContext.GetSteamUGC(), handle, bReturnAdditionalPreviews);
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0001441E File Offset: 0x0001281E
		public static bool SetReturnTotalOnly(UGCQueryHandle_t handle, bool bReturnTotalOnly)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnTotalOnly(CSteamGameServerAPIContext.GetSteamUGC(), handle, bReturnTotalOnly);
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00014431 File Offset: 0x00012831
		public static bool SetReturnPlaytimeStats(UGCQueryHandle_t handle, uint unDays)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetReturnPlaytimeStats(CSteamGameServerAPIContext.GetSteamUGC(), handle, unDays);
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x00014444 File Offset: 0x00012844
		public static bool SetLanguage(UGCQueryHandle_t handle, string pchLanguage)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchLanguage))
			{
				result = NativeMethods.ISteamUGC_SetLanguage(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00014490 File Offset: 0x00012890
		public static bool SetAllowCachedResponse(UGCQueryHandle_t handle, uint unMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetAllowCachedResponse(CSteamGameServerAPIContext.GetSteamUGC(), handle, unMaxAgeSeconds);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x000144A4 File Offset: 0x000128A4
		public static bool SetCloudFileNameFilter(UGCQueryHandle_t handle, string pMatchCloudFileName)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pMatchCloudFileName))
			{
				result = NativeMethods.ISteamUGC_SetCloudFileNameFilter(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x000144F0 File Offset: 0x000128F0
		public static bool SetMatchAnyTag(UGCQueryHandle_t handle, bool bMatchAnyTag)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetMatchAnyTag(CSteamGameServerAPIContext.GetSteamUGC(), handle, bMatchAnyTag);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00014504 File Offset: 0x00012904
		public static bool SetSearchText(UGCQueryHandle_t handle, string pSearchText)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pSearchText))
			{
				result = NativeMethods.ISteamUGC_SetSearchText(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00014550 File Offset: 0x00012950
		public static bool SetRankedByTrendDays(UGCQueryHandle_t handle, uint unDays)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetRankedByTrendDays(CSteamGameServerAPIContext.GetSteamUGC(), handle, unDays);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00014564 File Offset: 0x00012964
		public static bool AddRequiredKeyValueTag(UGCQueryHandle_t handle, string pKey, string pValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pValue))
				{
					result = NativeMethods.ISteamUGC_AddRequiredKeyValueTag(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x000145D0 File Offset: 0x000129D0
		public static SteamAPICall_t RequestUGCDetails(PublishedFileId_t nPublishedFileID, uint unMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RequestUGCDetails(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID, unMaxAgeSeconds);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x000145E8 File Offset: 0x000129E8
		public static SteamAPICall_t CreateItem(AppId_t nConsumerAppId, EWorkshopFileType eFileType)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_CreateItem(CSteamGameServerAPIContext.GetSteamUGC(), nConsumerAppId, eFileType);
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x00014600 File Offset: 0x00012A00
		public static UGCUpdateHandle_t StartItemUpdate(AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (UGCUpdateHandle_t)NativeMethods.ISteamUGC_StartItemUpdate(CSteamGameServerAPIContext.GetSteamUGC(), nConsumerAppId, nPublishedFileID);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00014618 File Offset: 0x00012A18
		public static bool SetItemTitle(UGCUpdateHandle_t handle, string pchTitle)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchTitle))
			{
				result = NativeMethods.ISteamUGC_SetItemTitle(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00014664 File Offset: 0x00012A64
		public static bool SetItemDescription(UGCUpdateHandle_t handle, string pchDescription)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchDescription))
			{
				result = NativeMethods.ISteamUGC_SetItemDescription(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x000146B0 File Offset: 0x00012AB0
		public static bool SetItemUpdateLanguage(UGCUpdateHandle_t handle, string pchLanguage)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchLanguage))
			{
				result = NativeMethods.ISteamUGC_SetItemUpdateLanguage(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x000146FC File Offset: 0x00012AFC
		public static bool SetItemMetadata(UGCUpdateHandle_t handle, string pchMetaData)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchMetaData))
			{
				result = NativeMethods.ISteamUGC_SetItemMetadata(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00014748 File Offset: 0x00012B48
		public static bool SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetItemVisibility(CSteamGameServerAPIContext.GetSteamUGC(), handle, eVisibility);
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0001475B File Offset: 0x00012B5B
		public static bool SetItemTags(UGCUpdateHandle_t updateHandle, IList<string> pTags)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_SetItemTags(CSteamGameServerAPIContext.GetSteamUGC(), updateHandle, new InteropHelp.SteamParamStringArray(pTags));
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00014778 File Offset: 0x00012B78
		public static bool SetItemContent(UGCUpdateHandle_t handle, string pszContentFolder)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszContentFolder))
			{
				result = NativeMethods.ISteamUGC_SetItemContent(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x000147C4 File Offset: 0x00012BC4
		public static bool SetItemPreview(UGCUpdateHandle_t handle, string pszPreviewFile)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszPreviewFile))
			{
				result = NativeMethods.ISteamUGC_SetItemPreview(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00014810 File Offset: 0x00012C10
		public static bool RemoveItemKeyValueTags(UGCUpdateHandle_t handle, string pchKey)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = NativeMethods.ISteamUGC_RemoveItemKeyValueTags(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0001485C File Offset: 0x00012C5C
		public static bool AddItemKeyValueTag(UGCUpdateHandle_t handle, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					result = NativeMethods.ISteamUGC_AddItemKeyValueTag(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x000148C8 File Offset: 0x00012CC8
		public static bool AddItemPreviewFile(UGCUpdateHandle_t handle, string pszPreviewFile, EItemPreviewType type)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszPreviewFile))
			{
				result = NativeMethods.ISteamUGC_AddItemPreviewFile(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle, type);
			}
			return result;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00014914 File Offset: 0x00012D14
		public static bool AddItemPreviewVideo(UGCUpdateHandle_t handle, string pszVideoID)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszVideoID))
			{
				result = NativeMethods.ISteamUGC_AddItemPreviewVideo(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00014960 File Offset: 0x00012D60
		public static bool UpdateItemPreviewFile(UGCUpdateHandle_t handle, uint index, string pszPreviewFile)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszPreviewFile))
			{
				result = NativeMethods.ISteamUGC_UpdateItemPreviewFile(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x000149AC File Offset: 0x00012DAC
		public static bool UpdateItemPreviewVideo(UGCUpdateHandle_t handle, uint index, string pszVideoID)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszVideoID))
			{
				result = NativeMethods.ISteamUGC_UpdateItemPreviewVideo(CSteamGameServerAPIContext.GetSteamUGC(), handle, index, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x000149F8 File Offset: 0x00012DF8
		public static bool RemoveItemPreview(UGCUpdateHandle_t handle, uint index)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_RemoveItemPreview(CSteamGameServerAPIContext.GetSteamUGC(), handle, index);
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00014A0C File Offset: 0x00012E0C
		public static SteamAPICall_t SubmitItemUpdate(UGCUpdateHandle_t handle, string pchChangeNote)
		{
			InteropHelp.TestIfAvailableGameServer();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchChangeNote))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamUGC_SubmitItemUpdate(CSteamGameServerAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00014A5C File Offset: 0x00012E5C
		public static EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle_t handle, out ulong punBytesProcessed, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetItemUpdateProgress(CSteamGameServerAPIContext.GetSteamUGC(), handle, out punBytesProcessed, out punBytesTotal);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00014A70 File Offset: 0x00012E70
		public static SteamAPICall_t SetUserItemVote(PublishedFileId_t nPublishedFileID, bool bVoteUp)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SetUserItemVote(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID, bVoteUp);
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00014A88 File Offset: 0x00012E88
		public static SteamAPICall_t GetUserItemVote(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_GetUserItemVote(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00014A9F File Offset: 0x00012E9F
		public static SteamAPICall_t AddItemToFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_AddItemToFavorites(CSteamGameServerAPIContext.GetSteamUGC(), nAppId, nPublishedFileID);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00014AB7 File Offset: 0x00012EB7
		public static SteamAPICall_t RemoveItemFromFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RemoveItemFromFavorites(CSteamGameServerAPIContext.GetSteamUGC(), nAppId, nPublishedFileID);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00014ACF File Offset: 0x00012ECF
		public static SteamAPICall_t SubscribeItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SubscribeItem(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00014AE6 File Offset: 0x00012EE6
		public static SteamAPICall_t UnsubscribeItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_UnsubscribeItem(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00014AFD File Offset: 0x00012EFD
		public static uint GetNumSubscribedItems()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetNumSubscribedItems(CSteamGameServerAPIContext.GetSteamUGC());
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00014B0E File Offset: 0x00012F0E
		public static uint GetSubscribedItems(PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetSubscribedItems(CSteamGameServerAPIContext.GetSteamUGC(), pvecPublishedFileID, cMaxEntries);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00014B21 File Offset: 0x00012F21
		public static uint GetItemState(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetItemState(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00014B34 File Offset: 0x00012F34
		public static bool GetItemInstallInfo(PublishedFileId_t nPublishedFileID, out ulong punSizeOnDisk, out string pchFolder, uint cchFolderSize, out uint punTimeStamp)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchFolderSize);
			bool flag = NativeMethods.ISteamUGC_GetItemInstallInfo(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID, out punSizeOnDisk, intPtr, cchFolderSize, out punTimeStamp);
			pchFolder = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00014B79 File Offset: 0x00012F79
		public static bool GetItemDownloadInfo(PublishedFileId_t nPublishedFileID, out ulong punBytesDownloaded, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_GetItemDownloadInfo(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID, out punBytesDownloaded, out punBytesTotal);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00014B8D File Offset: 0x00012F8D
		public static bool DownloadItem(PublishedFileId_t nPublishedFileID, bool bHighPriority)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUGC_DownloadItem(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID, bHighPriority);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00014BA0 File Offset: 0x00012FA0
		public static bool BInitWorkshopForGameServer(DepotId_t unWorkshopDepotID, string pszFolder)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszFolder))
			{
				result = NativeMethods.ISteamUGC_BInitWorkshopForGameServer(CSteamGameServerAPIContext.GetSteamUGC(), unWorkshopDepotID, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00014BEC File Offset: 0x00012FEC
		public static void SuspendDownloads(bool bSuspend)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamUGC_SuspendDownloads(CSteamGameServerAPIContext.GetSteamUGC(), bSuspend);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00014BFE File Offset: 0x00012FFE
		public static SteamAPICall_t StartPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_StartPlaytimeTracking(CSteamGameServerAPIContext.GetSteamUGC(), pvecPublishedFileID, unNumPublishedFileIDs);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00014C16 File Offset: 0x00013016
		public static SteamAPICall_t StopPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_StopPlaytimeTracking(CSteamGameServerAPIContext.GetSteamUGC(), pvecPublishedFileID, unNumPublishedFileIDs);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00014C2E File Offset: 0x0001302E
		public static SteamAPICall_t StopPlaytimeTrackingForAllItems()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_StopPlaytimeTrackingForAllItems(CSteamGameServerAPIContext.GetSteamUGC());
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00014C44 File Offset: 0x00013044
		public static SteamAPICall_t AddDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_AddDependency(CSteamGameServerAPIContext.GetSteamUGC(), nParentPublishedFileID, nChildPublishedFileID);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00014C5C File Offset: 0x0001305C
		public static SteamAPICall_t RemoveDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RemoveDependency(CSteamGameServerAPIContext.GetSteamUGC(), nParentPublishedFileID, nChildPublishedFileID);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00014C74 File Offset: 0x00013074
		public static SteamAPICall_t AddAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_AddAppDependency(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID, nAppID);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00014C8C File Offset: 0x0001308C
		public static SteamAPICall_t RemoveAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RemoveAppDependency(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID, nAppID);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00014CA4 File Offset: 0x000130A4
		public static SteamAPICall_t GetAppDependencies(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_GetAppDependencies(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x00014CBB File Offset: 0x000130BB
		public static SteamAPICall_t DeleteItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_DeleteItem(CSteamGameServerAPIContext.GetSteamUGC(), nPublishedFileID);
		}
	}
}
