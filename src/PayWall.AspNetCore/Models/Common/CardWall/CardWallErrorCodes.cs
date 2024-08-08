namespace PayWall.AspNetCore.Models.Common.CardWall;

public enum CardWallErrorCodes
{
    Success = 0,
    Unsuccessful = 1,
    InvalidData = 2,
    HeaderMissing = 3,
    CardExists = 4,
    CardNotFound = 5,
    MerchantNotFound = 6,
    UniqueCodeEmpty = 7,
    RelationalId1Required = 8,
    InvalidCard = 9,
    NicknameCannotBeEmpty = 10,
    InvalidNickname = 10,
    HolderNameCannotBeEmpty = 11,
    InvalidHolderName = 11,
    CardNumberCannotBeEmpty = 12,
    InvalidCardNumber = 13,
    MonthLengthCannotBeMoreThan2 = 14,
    MonthInvalid = 15,
    YearLengthMustBe4 = 16,
    YearInvalid = 17,
    RelationalIdCannotEmpty = 18,
    PartnerIdentityIsRequiredForPartnerBased = 19,
    PartnerAccessDenied = 20,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404
}