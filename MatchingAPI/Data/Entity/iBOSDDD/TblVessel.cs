using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity.iBOSDDD;

public partial class TblVessel
{
    public long IntVesselId { get; set; }

    public string? StrVesselName { get; set; }

    public long? IntOwnerId { get; set; }

    public string? StrOwnerName { get; set; }

    public decimal? NumDeadWeight { get; set; }

    public bool? IsOtherInfo { get; set; }

    public string? DteYearOfBuilt { get; set; }

    public string? StrShipYard { get; set; }

    public string? NumImono { get; set; }

    public string? StrCallSign { get; set; }

    public string? StrClassName { get; set; }

    public long? IntFlagId { get; set; }

    public string? StrFlag { get; set; }

    public string? StrPiclub { get; set; }

    public decimal? NumGrt { get; set; }

    public decimal? NumNrt { get; set; }

    public decimal? NumLoa { get; set; }

    public decimal? NumLbp { get; set; }

    public decimal? NumBeam { get; set; }

    public decimal? NumDepth { get; set; }

    public string? StrTpconSummerFreeBoard { get; set; }

    public string? StrActual { get; set; }

    public decimal? NumHoldCubicGrain { get; set; }

    public decimal? NumHoldCubicBale { get; set; }

    public decimal? NumHoldsLengthBreadth { get; set; }

    public decimal? NumUpperDeckStrength { get; set; }

    public string? StrHatchCover { get; set; }

    public string? StrHatchCoverLengthBreadth { get; set; }

    public string? StrHatchCoverStrength { get; set; }

    public string? StrCranes { get; set; }

    public string? StrGrabs { get; set; }

    public string? StrSpeedAndConsumptionAtSea { get; set; }

    public string? StrEcoAndConsumptionAtSea { get; set; }

    public string? StrInPortWorking { get; set; }

    public string? StrRemarks { get; set; }

    public bool? IsOwnVessel { get; set; }

    public long? IntAccountId { get; set; }

    public long? IntBusinessUnitId { get; set; }

    public long? IntCostCenterId { get; set; }

    public string? StrCostCenterName { get; set; }

    public long? IntRevenueCenterId { get; set; }

    public string? StrRevenueCenterName { get; set; }

    public long? IntProfitCenterId { get; set; }

    public string? StrProfitCenterName { get; set; }

    public long? IntInsertby { get; set; }

    public DateTime? DteLastActionTime { get; set; }

    public DateTime? DteServerDatetime { get; set; }

    public bool? IsActive { get; set; }

    public decimal? NumBallastSpeed { get; set; }

    public decimal? NumLadenSpeed { get; set; }

    public decimal? NumIfoatsea { get; set; }

    public decimal? NumMgoatSea { get; set; }

    public decimal? NumMgoatportWorking { get; set; }

    public decimal? NumMgoatportIdle { get; set; }

    public decimal? NumIfoatportIdle { get; set; }

    public decimal? NumIfoatportWorking { get; set; }
}
