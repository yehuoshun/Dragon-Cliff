using System;

namespace Steamworks
{
	// Token: 0x02000122 RID: 290
	public enum EControllerActionOrigin
	{
		// Token: 0x04000541 RID: 1345
		k_EControllerActionOrigin_None,
		// Token: 0x04000542 RID: 1346
		k_EControllerActionOrigin_A,
		// Token: 0x04000543 RID: 1347
		k_EControllerActionOrigin_B,
		// Token: 0x04000544 RID: 1348
		k_EControllerActionOrigin_X,
		// Token: 0x04000545 RID: 1349
		k_EControllerActionOrigin_Y,
		// Token: 0x04000546 RID: 1350
		k_EControllerActionOrigin_LeftBumper,
		// Token: 0x04000547 RID: 1351
		k_EControllerActionOrigin_RightBumper,
		// Token: 0x04000548 RID: 1352
		k_EControllerActionOrigin_LeftGrip,
		// Token: 0x04000549 RID: 1353
		k_EControllerActionOrigin_RightGrip,
		// Token: 0x0400054A RID: 1354
		k_EControllerActionOrigin_Start,
		// Token: 0x0400054B RID: 1355
		k_EControllerActionOrigin_Back,
		// Token: 0x0400054C RID: 1356
		k_EControllerActionOrigin_LeftPad_Touch,
		// Token: 0x0400054D RID: 1357
		k_EControllerActionOrigin_LeftPad_Swipe,
		// Token: 0x0400054E RID: 1358
		k_EControllerActionOrigin_LeftPad_Click,
		// Token: 0x0400054F RID: 1359
		k_EControllerActionOrigin_LeftPad_DPadNorth,
		// Token: 0x04000550 RID: 1360
		k_EControllerActionOrigin_LeftPad_DPadSouth,
		// Token: 0x04000551 RID: 1361
		k_EControllerActionOrigin_LeftPad_DPadWest,
		// Token: 0x04000552 RID: 1362
		k_EControllerActionOrigin_LeftPad_DPadEast,
		// Token: 0x04000553 RID: 1363
		k_EControllerActionOrigin_RightPad_Touch,
		// Token: 0x04000554 RID: 1364
		k_EControllerActionOrigin_RightPad_Swipe,
		// Token: 0x04000555 RID: 1365
		k_EControllerActionOrigin_RightPad_Click,
		// Token: 0x04000556 RID: 1366
		k_EControllerActionOrigin_RightPad_DPadNorth,
		// Token: 0x04000557 RID: 1367
		k_EControllerActionOrigin_RightPad_DPadSouth,
		// Token: 0x04000558 RID: 1368
		k_EControllerActionOrigin_RightPad_DPadWest,
		// Token: 0x04000559 RID: 1369
		k_EControllerActionOrigin_RightPad_DPadEast,
		// Token: 0x0400055A RID: 1370
		k_EControllerActionOrigin_LeftTrigger_Pull,
		// Token: 0x0400055B RID: 1371
		k_EControllerActionOrigin_LeftTrigger_Click,
		// Token: 0x0400055C RID: 1372
		k_EControllerActionOrigin_RightTrigger_Pull,
		// Token: 0x0400055D RID: 1373
		k_EControllerActionOrigin_RightTrigger_Click,
		// Token: 0x0400055E RID: 1374
		k_EControllerActionOrigin_LeftStick_Move,
		// Token: 0x0400055F RID: 1375
		k_EControllerActionOrigin_LeftStick_Click,
		// Token: 0x04000560 RID: 1376
		k_EControllerActionOrigin_LeftStick_DPadNorth,
		// Token: 0x04000561 RID: 1377
		k_EControllerActionOrigin_LeftStick_DPadSouth,
		// Token: 0x04000562 RID: 1378
		k_EControllerActionOrigin_LeftStick_DPadWest,
		// Token: 0x04000563 RID: 1379
		k_EControllerActionOrigin_LeftStick_DPadEast,
		// Token: 0x04000564 RID: 1380
		k_EControllerActionOrigin_Gyro_Move,
		// Token: 0x04000565 RID: 1381
		k_EControllerActionOrigin_Gyro_Pitch,
		// Token: 0x04000566 RID: 1382
		k_EControllerActionOrigin_Gyro_Yaw,
		// Token: 0x04000567 RID: 1383
		k_EControllerActionOrigin_Gyro_Roll,
		// Token: 0x04000568 RID: 1384
		k_EControllerActionOrigin_PS4_X,
		// Token: 0x04000569 RID: 1385
		k_EControllerActionOrigin_PS4_Circle,
		// Token: 0x0400056A RID: 1386
		k_EControllerActionOrigin_PS4_Triangle,
		// Token: 0x0400056B RID: 1387
		k_EControllerActionOrigin_PS4_Square,
		// Token: 0x0400056C RID: 1388
		k_EControllerActionOrigin_PS4_LeftBumper,
		// Token: 0x0400056D RID: 1389
		k_EControllerActionOrigin_PS4_RightBumper,
		// Token: 0x0400056E RID: 1390
		k_EControllerActionOrigin_PS4_Options,
		// Token: 0x0400056F RID: 1391
		k_EControllerActionOrigin_PS4_Share,
		// Token: 0x04000570 RID: 1392
		k_EControllerActionOrigin_PS4_LeftPad_Touch,
		// Token: 0x04000571 RID: 1393
		k_EControllerActionOrigin_PS4_LeftPad_Swipe,
		// Token: 0x04000572 RID: 1394
		k_EControllerActionOrigin_PS4_LeftPad_Click,
		// Token: 0x04000573 RID: 1395
		k_EControllerActionOrigin_PS4_LeftPad_DPadNorth,
		// Token: 0x04000574 RID: 1396
		k_EControllerActionOrigin_PS4_LeftPad_DPadSouth,
		// Token: 0x04000575 RID: 1397
		k_EControllerActionOrigin_PS4_LeftPad_DPadWest,
		// Token: 0x04000576 RID: 1398
		k_EControllerActionOrigin_PS4_LeftPad_DPadEast,
		// Token: 0x04000577 RID: 1399
		k_EControllerActionOrigin_PS4_RightPad_Touch,
		// Token: 0x04000578 RID: 1400
		k_EControllerActionOrigin_PS4_RightPad_Swipe,
		// Token: 0x04000579 RID: 1401
		k_EControllerActionOrigin_PS4_RightPad_Click,
		// Token: 0x0400057A RID: 1402
		k_EControllerActionOrigin_PS4_RightPad_DPadNorth,
		// Token: 0x0400057B RID: 1403
		k_EControllerActionOrigin_PS4_RightPad_DPadSouth,
		// Token: 0x0400057C RID: 1404
		k_EControllerActionOrigin_PS4_RightPad_DPadWest,
		// Token: 0x0400057D RID: 1405
		k_EControllerActionOrigin_PS4_RightPad_DPadEast,
		// Token: 0x0400057E RID: 1406
		k_EControllerActionOrigin_PS4_CenterPad_Touch,
		// Token: 0x0400057F RID: 1407
		k_EControllerActionOrigin_PS4_CenterPad_Swipe,
		// Token: 0x04000580 RID: 1408
		k_EControllerActionOrigin_PS4_CenterPad_Click,
		// Token: 0x04000581 RID: 1409
		k_EControllerActionOrigin_PS4_CenterPad_DPadNorth,
		// Token: 0x04000582 RID: 1410
		k_EControllerActionOrigin_PS4_CenterPad_DPadSouth,
		// Token: 0x04000583 RID: 1411
		k_EControllerActionOrigin_PS4_CenterPad_DPadWest,
		// Token: 0x04000584 RID: 1412
		k_EControllerActionOrigin_PS4_CenterPad_DPadEast,
		// Token: 0x04000585 RID: 1413
		k_EControllerActionOrigin_PS4_LeftTrigger_Pull,
		// Token: 0x04000586 RID: 1414
		k_EControllerActionOrigin_PS4_LeftTrigger_Click,
		// Token: 0x04000587 RID: 1415
		k_EControllerActionOrigin_PS4_RightTrigger_Pull,
		// Token: 0x04000588 RID: 1416
		k_EControllerActionOrigin_PS4_RightTrigger_Click,
		// Token: 0x04000589 RID: 1417
		k_EControllerActionOrigin_PS4_LeftStick_Move,
		// Token: 0x0400058A RID: 1418
		k_EControllerActionOrigin_PS4_LeftStick_Click,
		// Token: 0x0400058B RID: 1419
		k_EControllerActionOrigin_PS4_LeftStick_DPadNorth,
		// Token: 0x0400058C RID: 1420
		k_EControllerActionOrigin_PS4_LeftStick_DPadSouth,
		// Token: 0x0400058D RID: 1421
		k_EControllerActionOrigin_PS4_LeftStick_DPadWest,
		// Token: 0x0400058E RID: 1422
		k_EControllerActionOrigin_PS4_LeftStick_DPadEast,
		// Token: 0x0400058F RID: 1423
		k_EControllerActionOrigin_PS4_RightStick_Move,
		// Token: 0x04000590 RID: 1424
		k_EControllerActionOrigin_PS4_RightStick_Click,
		// Token: 0x04000591 RID: 1425
		k_EControllerActionOrigin_PS4_RightStick_DPadNorth,
		// Token: 0x04000592 RID: 1426
		k_EControllerActionOrigin_PS4_RightStick_DPadSouth,
		// Token: 0x04000593 RID: 1427
		k_EControllerActionOrigin_PS4_RightStick_DPadWest,
		// Token: 0x04000594 RID: 1428
		k_EControllerActionOrigin_PS4_RightStick_DPadEast,
		// Token: 0x04000595 RID: 1429
		k_EControllerActionOrigin_PS4_DPad_North,
		// Token: 0x04000596 RID: 1430
		k_EControllerActionOrigin_PS4_DPad_South,
		// Token: 0x04000597 RID: 1431
		k_EControllerActionOrigin_PS4_DPad_West,
		// Token: 0x04000598 RID: 1432
		k_EControllerActionOrigin_PS4_DPad_East,
		// Token: 0x04000599 RID: 1433
		k_EControllerActionOrigin_PS4_Gyro_Move,
		// Token: 0x0400059A RID: 1434
		k_EControllerActionOrigin_PS4_Gyro_Pitch,
		// Token: 0x0400059B RID: 1435
		k_EControllerActionOrigin_PS4_Gyro_Yaw,
		// Token: 0x0400059C RID: 1436
		k_EControllerActionOrigin_PS4_Gyro_Roll,
		// Token: 0x0400059D RID: 1437
		k_EControllerActionOrigin_XBoxOne_A,
		// Token: 0x0400059E RID: 1438
		k_EControllerActionOrigin_XBoxOne_B,
		// Token: 0x0400059F RID: 1439
		k_EControllerActionOrigin_XBoxOne_X,
		// Token: 0x040005A0 RID: 1440
		k_EControllerActionOrigin_XBoxOne_Y,
		// Token: 0x040005A1 RID: 1441
		k_EControllerActionOrigin_XBoxOne_LeftBumper,
		// Token: 0x040005A2 RID: 1442
		k_EControllerActionOrigin_XBoxOne_RightBumper,
		// Token: 0x040005A3 RID: 1443
		k_EControllerActionOrigin_XBoxOne_Menu,
		// Token: 0x040005A4 RID: 1444
		k_EControllerActionOrigin_XBoxOne_View,
		// Token: 0x040005A5 RID: 1445
		k_EControllerActionOrigin_XBoxOne_LeftTrigger_Pull,
		// Token: 0x040005A6 RID: 1446
		k_EControllerActionOrigin_XBoxOne_LeftTrigger_Click,
		// Token: 0x040005A7 RID: 1447
		k_EControllerActionOrigin_XBoxOne_RightTrigger_Pull,
		// Token: 0x040005A8 RID: 1448
		k_EControllerActionOrigin_XBoxOne_RightTrigger_Click,
		// Token: 0x040005A9 RID: 1449
		k_EControllerActionOrigin_XBoxOne_LeftStick_Move,
		// Token: 0x040005AA RID: 1450
		k_EControllerActionOrigin_XBoxOne_LeftStick_Click,
		// Token: 0x040005AB RID: 1451
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadNorth,
		// Token: 0x040005AC RID: 1452
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadSouth,
		// Token: 0x040005AD RID: 1453
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadWest,
		// Token: 0x040005AE RID: 1454
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadEast,
		// Token: 0x040005AF RID: 1455
		k_EControllerActionOrigin_XBoxOne_RightStick_Move,
		// Token: 0x040005B0 RID: 1456
		k_EControllerActionOrigin_XBoxOne_RightStick_Click,
		// Token: 0x040005B1 RID: 1457
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadNorth,
		// Token: 0x040005B2 RID: 1458
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadSouth,
		// Token: 0x040005B3 RID: 1459
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadWest,
		// Token: 0x040005B4 RID: 1460
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadEast,
		// Token: 0x040005B5 RID: 1461
		k_EControllerActionOrigin_XBoxOne_DPad_North,
		// Token: 0x040005B6 RID: 1462
		k_EControllerActionOrigin_XBoxOne_DPad_South,
		// Token: 0x040005B7 RID: 1463
		k_EControllerActionOrigin_XBoxOne_DPad_West,
		// Token: 0x040005B8 RID: 1464
		k_EControllerActionOrigin_XBoxOne_DPad_East,
		// Token: 0x040005B9 RID: 1465
		k_EControllerActionOrigin_XBox360_A,
		// Token: 0x040005BA RID: 1466
		k_EControllerActionOrigin_XBox360_B,
		// Token: 0x040005BB RID: 1467
		k_EControllerActionOrigin_XBox360_X,
		// Token: 0x040005BC RID: 1468
		k_EControllerActionOrigin_XBox360_Y,
		// Token: 0x040005BD RID: 1469
		k_EControllerActionOrigin_XBox360_LeftBumper,
		// Token: 0x040005BE RID: 1470
		k_EControllerActionOrigin_XBox360_RightBumper,
		// Token: 0x040005BF RID: 1471
		k_EControllerActionOrigin_XBox360_Start,
		// Token: 0x040005C0 RID: 1472
		k_EControllerActionOrigin_XBox360_Back,
		// Token: 0x040005C1 RID: 1473
		k_EControllerActionOrigin_XBox360_LeftTrigger_Pull,
		// Token: 0x040005C2 RID: 1474
		k_EControllerActionOrigin_XBox360_LeftTrigger_Click,
		// Token: 0x040005C3 RID: 1475
		k_EControllerActionOrigin_XBox360_RightTrigger_Pull,
		// Token: 0x040005C4 RID: 1476
		k_EControllerActionOrigin_XBox360_RightTrigger_Click,
		// Token: 0x040005C5 RID: 1477
		k_EControllerActionOrigin_XBox360_LeftStick_Move,
		// Token: 0x040005C6 RID: 1478
		k_EControllerActionOrigin_XBox360_LeftStick_Click,
		// Token: 0x040005C7 RID: 1479
		k_EControllerActionOrigin_XBox360_LeftStick_DPadNorth,
		// Token: 0x040005C8 RID: 1480
		k_EControllerActionOrigin_XBox360_LeftStick_DPadSouth,
		// Token: 0x040005C9 RID: 1481
		k_EControllerActionOrigin_XBox360_LeftStick_DPadWest,
		// Token: 0x040005CA RID: 1482
		k_EControllerActionOrigin_XBox360_LeftStick_DPadEast,
		// Token: 0x040005CB RID: 1483
		k_EControllerActionOrigin_XBox360_RightStick_Move,
		// Token: 0x040005CC RID: 1484
		k_EControllerActionOrigin_XBox360_RightStick_Click,
		// Token: 0x040005CD RID: 1485
		k_EControllerActionOrigin_XBox360_RightStick_DPadNorth,
		// Token: 0x040005CE RID: 1486
		k_EControllerActionOrigin_XBox360_RightStick_DPadSouth,
		// Token: 0x040005CF RID: 1487
		k_EControllerActionOrigin_XBox360_RightStick_DPadWest,
		// Token: 0x040005D0 RID: 1488
		k_EControllerActionOrigin_XBox360_RightStick_DPadEast,
		// Token: 0x040005D1 RID: 1489
		k_EControllerActionOrigin_XBox360_DPad_North,
		// Token: 0x040005D2 RID: 1490
		k_EControllerActionOrigin_XBox360_DPad_South,
		// Token: 0x040005D3 RID: 1491
		k_EControllerActionOrigin_XBox360_DPad_West,
		// Token: 0x040005D4 RID: 1492
		k_EControllerActionOrigin_XBox360_DPad_East,
		// Token: 0x040005D5 RID: 1493
		k_EControllerActionOrigin_SteamV2_A,
		// Token: 0x040005D6 RID: 1494
		k_EControllerActionOrigin_SteamV2_B,
		// Token: 0x040005D7 RID: 1495
		k_EControllerActionOrigin_SteamV2_X,
		// Token: 0x040005D8 RID: 1496
		k_EControllerActionOrigin_SteamV2_Y,
		// Token: 0x040005D9 RID: 1497
		k_EControllerActionOrigin_SteamV2_LeftBumper,
		// Token: 0x040005DA RID: 1498
		k_EControllerActionOrigin_SteamV2_RightBumper,
		// Token: 0x040005DB RID: 1499
		k_EControllerActionOrigin_SteamV2_LeftGrip,
		// Token: 0x040005DC RID: 1500
		k_EControllerActionOrigin_SteamV2_RightGrip,
		// Token: 0x040005DD RID: 1501
		k_EControllerActionOrigin_SteamV2_LeftGrip_Upper,
		// Token: 0x040005DE RID: 1502
		k_EControllerActionOrigin_SteamV2_RightGrip_Upper,
		// Token: 0x040005DF RID: 1503
		k_EControllerActionOrigin_SteamV2_LeftBumper_Pressure,
		// Token: 0x040005E0 RID: 1504
		k_EControllerActionOrigin_SteamV2_RightBumper_Pressure,
		// Token: 0x040005E1 RID: 1505
		k_EControllerActionOrigin_SteamV2_LeftGrip_Pressure,
		// Token: 0x040005E2 RID: 1506
		k_EControllerActionOrigin_SteamV2_RightGrip_Pressure,
		// Token: 0x040005E3 RID: 1507
		k_EControllerActionOrigin_SteamV2_LeftGrip_Upper_Pressure,
		// Token: 0x040005E4 RID: 1508
		k_EControllerActionOrigin_SteamV2_RightGrip_Upper_Pressure,
		// Token: 0x040005E5 RID: 1509
		k_EControllerActionOrigin_SteamV2_Start,
		// Token: 0x040005E6 RID: 1510
		k_EControllerActionOrigin_SteamV2_Back,
		// Token: 0x040005E7 RID: 1511
		k_EControllerActionOrigin_SteamV2_LeftPad_Touch,
		// Token: 0x040005E8 RID: 1512
		k_EControllerActionOrigin_SteamV2_LeftPad_Swipe,
		// Token: 0x040005E9 RID: 1513
		k_EControllerActionOrigin_SteamV2_LeftPad_Click,
		// Token: 0x040005EA RID: 1514
		k_EControllerActionOrigin_SteamV2_LeftPad_Pressure,
		// Token: 0x040005EB RID: 1515
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadNorth,
		// Token: 0x040005EC RID: 1516
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadSouth,
		// Token: 0x040005ED RID: 1517
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadWest,
		// Token: 0x040005EE RID: 1518
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadEast,
		// Token: 0x040005EF RID: 1519
		k_EControllerActionOrigin_SteamV2_RightPad_Touch,
		// Token: 0x040005F0 RID: 1520
		k_EControllerActionOrigin_SteamV2_RightPad_Swipe,
		// Token: 0x040005F1 RID: 1521
		k_EControllerActionOrigin_SteamV2_RightPad_Click,
		// Token: 0x040005F2 RID: 1522
		k_EControllerActionOrigin_SteamV2_RightPad_Pressure,
		// Token: 0x040005F3 RID: 1523
		k_EControllerActionOrigin_SteamV2_RightPad_DPadNorth,
		// Token: 0x040005F4 RID: 1524
		k_EControllerActionOrigin_SteamV2_RightPad_DPadSouth,
		// Token: 0x040005F5 RID: 1525
		k_EControllerActionOrigin_SteamV2_RightPad_DPadWest,
		// Token: 0x040005F6 RID: 1526
		k_EControllerActionOrigin_SteamV2_RightPad_DPadEast,
		// Token: 0x040005F7 RID: 1527
		k_EControllerActionOrigin_SteamV2_LeftTrigger_Pull,
		// Token: 0x040005F8 RID: 1528
		k_EControllerActionOrigin_SteamV2_LeftTrigger_Click,
		// Token: 0x040005F9 RID: 1529
		k_EControllerActionOrigin_SteamV2_RightTrigger_Pull,
		// Token: 0x040005FA RID: 1530
		k_EControllerActionOrigin_SteamV2_RightTrigger_Click,
		// Token: 0x040005FB RID: 1531
		k_EControllerActionOrigin_SteamV2_LeftStick_Move,
		// Token: 0x040005FC RID: 1532
		k_EControllerActionOrigin_SteamV2_LeftStick_Click,
		// Token: 0x040005FD RID: 1533
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadNorth,
		// Token: 0x040005FE RID: 1534
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadSouth,
		// Token: 0x040005FF RID: 1535
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadWest,
		// Token: 0x04000600 RID: 1536
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadEast,
		// Token: 0x04000601 RID: 1537
		k_EControllerActionOrigin_SteamV2_Gyro_Move,
		// Token: 0x04000602 RID: 1538
		k_EControllerActionOrigin_SteamV2_Gyro_Pitch,
		// Token: 0x04000603 RID: 1539
		k_EControllerActionOrigin_SteamV2_Gyro_Yaw,
		// Token: 0x04000604 RID: 1540
		k_EControllerActionOrigin_SteamV2_Gyro_Roll,
		// Token: 0x04000605 RID: 1541
		k_EControllerActionOrigin_Count
	}
}
