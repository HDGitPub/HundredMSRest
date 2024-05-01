namespace HundredMSRest.Lib.Api.Rooms.DataTypes;

public record UploadInfo(string type, string location, string prefix, Options options, Credentials credentials);
