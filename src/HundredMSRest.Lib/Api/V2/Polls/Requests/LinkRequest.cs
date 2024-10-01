using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Polls.Commands;

/// <summary>
/// Class <c>LinkPollRequest></c> Request to link polls to a room
/// </summary>
public record LinkRequest(string [] polls) : RequestRecord;