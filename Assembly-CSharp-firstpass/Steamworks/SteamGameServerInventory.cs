using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000180 RID: 384
	public static class SteamGameServerInventory
	{
		// Token: 0x060007E1 RID: 2017 RVA: 0x000139B5 File Offset: 0x00011DB5
		public static EResult GetResultStatus(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GetResultStatus(CSteamGameServerAPIContext.GetSteamInventory(), resultHandle);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x000139C7 File Offset: 0x00011DC7
		public static bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GetResultItems(CSteamGameServerAPIContext.GetSteamInventory(), resultHandle, pOutItemsArray, ref punOutItemsArraySize);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x000139DC File Offset: 0x00011DDC
		public static bool GetResultItemProperty(SteamInventoryResult_t resultHandle, uint unItemIndex, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)punValueBufferSizeOut);
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				bool flag = NativeMethods.ISteamInventory_GetResultItemProperty(CSteamGameServerAPIContext.GetSteamInventory(), resultHandle, unItemIndex, utf8StringHandle, intPtr, ref punValueBufferSizeOut);
				pchValueBuffer = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
				Marshal.FreeHGlobal(intPtr);
				result = flag;
			}
			return result;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x00013A50 File Offset: 0x00011E50
		public static uint GetResultTimestamp(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GetResultTimestamp(CSteamGameServerAPIContext.GetSteamInventory(), resultHandle);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00013A62 File Offset: 0x00011E62
		public static bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_CheckResultSteamID(CSteamGameServerAPIContext.GetSteamInventory(), resultHandle, steamIDExpected);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00013A75 File Offset: 0x00011E75
		public static void DestroyResult(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamInventory_DestroyResult(CSteamGameServerAPIContext.GetSteamInventory(), resultHandle);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00013A87 File Offset: 0x00011E87
		public static bool GetAllItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GetAllItems(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00013A99 File Offset: 0x00011E99
		public static bool GetItemsByID(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GetItemsByID(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, pInstanceIDs, unCountInstanceIDs);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00013AAD File Offset: 0x00011EAD
		public static bool SerializeResult(SteamInventoryResult_t resultHandle, byte[] pOutBuffer, out uint punOutBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_SerializeResult(CSteamGameServerAPIContext.GetSteamInventory(), resultHandle, pOutBuffer, out punOutBufferSize);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00013AC1 File Offset: 0x00011EC1
		public static bool DeserializeResult(out SteamInventoryResult_t pOutResultHandle, byte[] pBuffer, uint unBufferSize, bool bRESERVED_MUST_BE_FALSE = false)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_DeserializeResult(CSteamGameServerAPIContext.GetSteamInventory(), out pOutResultHandle, pBuffer, unBufferSize, bRESERVED_MUST_BE_FALSE);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00013AD6 File Offset: 0x00011ED6
		public static bool GenerateItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GenerateItems(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, pArrayItemDefs, punArrayQuantity, unArrayLength);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00013AEB File Offset: 0x00011EEB
		public static bool GrantPromoItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GrantPromoItems(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00013AFD File Offset: 0x00011EFD
		public static bool AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_AddPromoItem(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, itemDef);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x00013B10 File Offset: 0x00011F10
		public static bool AddPromoItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_AddPromoItems(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, pArrayItemDefs, unArrayLength);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x00013B24 File Offset: 0x00011F24
		public static bool ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_ConsumeItem(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, itemConsume, unQuantity);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x00013B38 File Offset: 0x00011F38
		public static bool ExchangeItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayGenerate, uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t[] pArrayDestroy, uint[] punArrayDestroyQuantity, uint unArrayDestroyLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_ExchangeItems(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, pArrayGenerate, punArrayGenerateQuantity, unArrayGenerateLength, pArrayDestroy, punArrayDestroyQuantity, unArrayDestroyLength);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00013B53 File Offset: 0x00011F53
		public static bool TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_TransferItemQuantity(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, itemIdSource, unQuantity, itemIdDest);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00013B68 File Offset: 0x00011F68
		public static void SendItemDropHeartbeat()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamInventory_SendItemDropHeartbeat(CSteamGameServerAPIContext.GetSteamInventory());
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00013B79 File Offset: 0x00011F79
		public static bool TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_TriggerItemDrop(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, dropListDefinition);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00013B8C File Offset: 0x00011F8C
		public static bool TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, SteamItemInstanceID_t[] pArrayGive, uint[] pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t[] pArrayGet, uint[] pArrayGetQuantity, uint nArrayGetLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_TradeItems(CSteamGameServerAPIContext.GetSteamInventory(), out pResultHandle, steamIDTradePartner, pArrayGive, pArrayGiveQuantity, nArrayGiveLength, pArrayGet, pArrayGetQuantity, nArrayGetLength);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00013BB4 File Offset: 0x00011FB4
		public static bool LoadItemDefinitions()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_LoadItemDefinitions(CSteamGameServerAPIContext.GetSteamInventory());
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00013BC5 File Offset: 0x00011FC5
		public static bool GetItemDefinitionIDs(SteamItemDef_t[] pItemDefIDs, out uint punItemDefIDsArraySize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GetItemDefinitionIDs(CSteamGameServerAPIContext.GetSteamInventory(), pItemDefIDs, out punItemDefIDsArraySize);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00013BD8 File Offset: 0x00011FD8
		public static bool GetItemDefinitionProperty(SteamItemDef_t iDefinition, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)punValueBufferSizeOut);
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				bool flag = NativeMethods.ISteamInventory_GetItemDefinitionProperty(CSteamGameServerAPIContext.GetSteamInventory(), iDefinition, utf8StringHandle, intPtr, ref punValueBufferSizeOut);
				pchValueBuffer = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
				Marshal.FreeHGlobal(intPtr);
				result = flag;
			}
			return result;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00013C48 File Offset: 0x00012048
		public static SteamAPICall_t RequestEligiblePromoItemDefinitionsIDs(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamInventory_RequestEligiblePromoItemDefinitionsIDs(CSteamGameServerAPIContext.GetSteamInventory(), steamID);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00013C5F File Offset: 0x0001205F
		public static bool GetEligiblePromoItemDefinitionIDs(CSteamID steamID, SteamItemDef_t[] pItemDefIDs, ref uint punItemDefIDsArraySize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamInventory_GetEligiblePromoItemDefinitionIDs(CSteamGameServerAPIContext.GetSteamInventory(), steamID, pItemDefIDs, ref punItemDefIDsArraySize);
		}
	}
}
