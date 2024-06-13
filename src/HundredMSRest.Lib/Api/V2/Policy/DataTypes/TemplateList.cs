namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

public record TemplateList(int limit, Template[] data, string last);
