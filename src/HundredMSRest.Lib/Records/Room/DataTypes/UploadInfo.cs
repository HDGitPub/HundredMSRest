namespace HundredMSRest.Lib.Records.Room.DataTypes;

public record UploadInfo(string type, string location, string prefix, Options options, Credentials credentials);
