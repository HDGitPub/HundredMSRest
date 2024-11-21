# 100ms (HundredMS) Rest Client Library

This library provides a rich object layer over the 100 MS rest API. You can use the classes in this library
to easily access the 100ms api to make GET, POST, PUT, and DELETE calls. The components are designed to
match the 100 MS documentation to make it easy to get up and running. All components have references to
the original 100MS documentation for convenience.

---

### General usage instructions

Getting up and running with the HundredMS rest client library is easy.

1. Select the functional area you wish to target i.e. Rooms.
2. Locate the corresponding command class i.e. RoomRestCommand.
3. Call functions in the form of Command.Function(params) to initiate an api call.
4. Use the resulting rich object within your code.

---

### API Functional Areas

The HundredMS rest client library matches the main functional areas of the 100ms api. Below is a
list of the current functional areas and their current HundredMS rest library development status.
Any line items without a status have not been developed at this time.

1. Rooms
2. ActiveRooms
3. External Streams
4. Live Streams
5. Sessions
6. Policy
7. Analytics
8. Room Codes
9. Recordings
10. Recording assets
11. Polls

---

### Rooms

[100ms Rooms Overview](https://www.100ms.live/docs/server-side/v2/api-reference/Rooms/overview)

This section provides code examples for the Rooms Server Side API

1. Create a new room

   ```c#
      var roomName = "Room Name";
      var roomDescription = "Room Description";
      var templateId = "Template Id";

      var result = await RoomRestCommand.CreateRoomAsync(
         roomName,
         roomDescription,
         templateId
      );
   ```

2. List all rooms

   ```c#
      var result = await RoomRestCommand.ListRoomsAsync();
   ```

3. Retrieve a specific room

   ```c#
      var roomId = "Room Id";

      var result = await RoomRestCommand.GetRoomAsync(roomId);
   ```

4. Update a room

   ```c#
      var roomId = "Room Id";
      var roomName = "Room Name";
      var roomDescription = "Room Description";
      var bucketName = "Bucket Name";
      var bucketAccessKey = "Bucket Access Key";
      var bucketSecretKey = "Bucket Secret Key";

      var updateRoomRequest = new UpdateRoomRequestBuilder()
               .AddName(roomName)
               .AddDescription(roomDescription)
               .AddRecordingInfo()
               .AddUploadInfo(StorageType.S3, bucketName, region: Region.Aws.<region>)
               .AddCredentials(bucketAccessKey, bucketSecretKey)
               .Build();

      var result = await RoomRestCommand.UpdateRoomAsync(roomId, updateRoomRequest);
   ```

5. Disable / Enable a room

   ```c#
      var roomId = "Room Id";
      var enableDisableRoomRequest = new EnableDisableRoomRequest()
      {
         enabled = true
      };

      var result = await RoomRestCommand.EnableDisableRoomAsync(
         roomId,
         enableDisableRoomRequest
      );
   ```

---

### External Streams

[100ms External Streams Overview](https://www.100ms.live/docs/server-side/v2/api-reference/external-streams/overview)

This section provides code examples for the External Streams Server Side API

1. Start a new External Stream

   ```c#
      var rtmp_urls = new string[] { "" };
      var roomId = "Room Id";

      var request = new StartExternalStreamRequest(rtmp_urls);
      var result = await ExternalStreamsRestCommand.StartAsync(roomId, request);
   ```

2. Stop an External Stream for a specified room

   ```c#
      var roomId = "Room Id";

      var result = await ExternalStreamsRestCommand.StopRoomStreamAsync(roomId);
   ```

3. Stop an External Stream using stream id

   ```c#
      var streamId = "Stream Id";

      var result = await ExternalStreamsRestCommand.StopStreamAsync(streamId);
   ```

4. Get a reference to an External Stream by stream id

   ```c#
      var streamId = "Stream Id";

      var result = await ExternalStreamsRestCommand.GetAsync(streamId);
   ```

5. Get a list of External Streams

   ```c#
      var result = await ExternalStreamsRestCommand.ListAsync();
   ```

---

### Live Streams

[100ms Live Streams Overview](https://www.100ms.live/docs/server-side/v2/api-reference/live-streams/overview)

This section provides code examples for the Live Streams Server Side API

1. Start a new Live Stream

   ```c#
      var roomId = "Room Id";
      var transScriptName = "Transcript Name";
      var meetingUrl = "Meeting Url";
      var summaryName = "Summary Name";

      var request = new StartLiveStreamRequest();
      request.meeting_url = meetingUrl;
      request.recording = new Recording()
      {
         hls_vod = true | false,
         single_file_per_layer = true | false
      };

      var transcription = new TranscriptionBuilder(transScriptName)
            .AddEnabled(true)
            .AddSummary(true, summaryName, 0.1f)
            .Build();

      request.transcription = transcription;

      var result = await LiveStreamsRestCommand.StartAsync(roomId, request);
   ```

2. Stop a Live Stream

   ```c#
      var roomId = "Room Id";

      var result = await LiveStreamsRestCommand.StopAsync(roomId);
   ```

3. Get a reference to a Live Stream

   ```c#
      var streamId = "Stream Id"

      var result = await LiveStreamsRestCommand.GetAsync(streamId);
   ```

4. List Live Streams for a workspace

   ```c#
      var result = await LiveStreamsRestCommand.ListAsync();
   ```

   ##### Using Filter

   ```c#
      var limit = 10;
      var roomId = "Room Id";
      var filter = new LiveStreamFilter()
            .AddLimit(limit)
            .AddRoomId(roomId)
            .Filter();

      var result = await LiveStreamsRestCommand.ListAsync(filter);
   ```

5. Stop a Live Stream using a stream id

   ```c#
      var streamId = "Stream Id"

      var result = await LiveStreamsRestCommand.StopByIdAsync(streamId);
   ```

6. Send Live Stream timed meta-data

   ```c#
      var streamId = "Stream Id";
      var payload = "Payload";
      var duration = 100;

      var request = new TimedMetaDataRequest(payload, duration);

      var result = await LiveStreamsRestCommand.SendTimedMetaData(streamId, request);
   ```

7. Pause a Live Stream using a stream id

   ```c#
      var streamId = "Stream Id";

      var result = await LiveStreamsRestCommand.PauseRecordingAsync(streamId);
   ```

8. Resume a Live Stream using a stream id

   ```c#
      var streamId = "Stream Id";

      var result = await LiveStreamsRestCommand.ResumeRecordingAsync(streamId);
   ```

---

### Sessions

[100ms Sessions Overview](https://www.100ms.live/docs/server-side/v2/api-reference/Sessions/object)

This section provides code examples for the Sessions Server Side API

1. Retrieve a specific session

   ```c#
      var sessionId = "Session Id";

      var result = await SessionRestCommand.GetAsync(sessionId);
   ```

2. List Sessions based on filter values

   ```c#

      var roomId = "Room Id";
      var afterDateTime = "After Date Time";
      var beforeDateTime = "Before Date Time";
      var active = true | false;
      var limit = 25;

      var filter = new SessionsRequestFilter()
         .AddRoomId(roomId)
         .AddActive(active)
         .AddAfter(afterDateTime)
         .AddBefore(beforeDateTime)
         .AddLimit(limit)
         .Filter();

      var result = await SessionRestCommand.ListSessionsAsync(filter);
   ```

---

### Policy

[100ms Policy Overview](https://www.100ms.live/docs/server-side/v2/api-reference/policy/create-template-via-api)

This section provides code examples for the Policy Server Side API

1. Create a new policy template object

   ```c#
      var GUEST_ROLE = "guest";
      var HOST_ROLE = "host";
      var RECORDER_ROLE = "recorder";

      IEnumerable<TrackType> hostAllowedTracks = new List<TrackType>()
      {
         TrackType.AUDIO,
         TrackType.VIDEO,
         TrackType.SCREEN,
      };

      IEnumerable<TrackType> guestAllowedTracks = new List<TrackType>()
      {
         TrackType.AUDIO,
         TrackType.VIDEO
      };

      // The associated role can share audio, video, and screen tracks
      var hostPublishParams = new PublishParamsBuilder()
         .AddAudio()
         .AddVideo(bitRate: 850, frameRate: 30, width: 720, height: 1280)
         .AddScreen(bitRate: 1000, frameRate: 10, width: 1280, height: 720)
         .AddAllowedTracks(hostAllowedTracks)
         .Build();

      var guestPublishParams = new PublishParamsBuilder()
         .AddAudio()
         .AddVideo(bitRate: 850, frameRate: 30, width: 1280, height: 720)
         .AddAllowedTracks(guestAllowedTracks)
         .Build();

      var recorderPublishParams = new PublishParamsBuilder().AddAllowedTracks().Build();

      var hostPermissions = new PermissionsBuilder()
         .EnableHlsStreaming(false)
         .EnableRtmpStreaming(false)
         .EnableBrowserRecording(true)
         .EnableSendRoomState(true)
         .EnableRemoveOthers(true)
         .EnableMute(true)
         .EnableUnmute(true)
         .EnableChangeRole(true)
         .EnablePollWrite(true)
         .EnablePollRead(true)
         .EnableEndRoom(true)
         .Build();

      var guestPermissions = new PermissionsBuilder()
         .EnableHlsStreaming(false)
         .EnableRtmpStreaming(false)
         .EnableBrowserRecording(false)
         .EnableSendRoomState(true)
         .EnablePollWrite(true)
         .EnablePollRead(true)
         .Build();

      var recorderPermissions = new PermissionsBuilder()
         .EnableHlsStreaming(true)
         .EnableRtmpStreaming(true)
         .EnableBrowserRecording(true)
         .EnableSendRoomState(true)
         .Build();

      var subscribeParams = new SubscribeParamsBuilder()
         .AddMaxSubsBitRate(3200)
         .AddSubscribeToRoles(new List<string>() { HOST_ROLE, GUEST_ROLE })
         .AddDegradation(25)
         .Build();

      var hostRole = new RoleBuilder()
         .AddName(HOST_ROLE)
         .AddPriority(1)
         .AddPermissions(hostPermissions)
         .AddPublishParams(hostPublishParams)
         .AddSubscribeParams(subscribeParams)
         .AddMaxPeerCount(50) // 0, n, -1
         .Build();

      var guestRole = new RoleBuilder()
         .AddName(GUEST_ROLE)
         .AddPriority(2)
         .AddPermissions(guestPermissions)
         .AddPublishParams(guestPublishParams)
         .AddSubscribeParams(subscribeParams)
         .AddMaxPeerCount(50) // 0, n, -1
         .Build();

      var recorderRole = new RoleBuilder()
         .AddName(RECORDER_ROLE)
         .AddPriority(1)
         .AddPermissions(recorderPermissions)
         .AddSubscribeParams(subscribeParams)
         .Build();

      var bucketName = "Bucket Name";
      var bucketAccessKey = "Bucket Access Key";
      var bucketSecretKey = "Bucket Secret Key";
      var accountId = "Account Id";
      var prefix = "Prefix";
      var region = Region.Aws.US_EAST_1;

      var recordingInfo = new RecordingInfoBuilder()
         .AddUploadInfo(
                StorageType.S3,
                bucketName,
                prefix: prefix,
                accountId: accountId,
                region: region
            )
         .AddCredentials(bucketAccessKey, bucketSecretKey)
         .Build();

      var settings = new SettingsBuilder()
         .AddRegion(Region.Geographic.UNITED_STATES)
         .AddRoomState(5, true, true)
         .AddRecordingInfo(recordingInfo)
         .Build();

      var rtmpDestination = "RTMP Destination";
      var rtmpDestinations = new RtmpDestinationsBuilder(rtmpDestination)
         .AddWidth(1080)
         .AddHeight(1920)
         .AddMaxDuration(1800)
         .AddAutoStopTimeout(5)
         .SetRecordingEnabled(true)
         .Build();

      var destinations = new DestinationsBuilder().AddRtmpDestinations(rtmpDestinations).Build();

      var templateName = "Template Name";
      var template = new PolicyBuilder()
         .AddName(templateName)
         .AddRole(hostRole)
         .AddRole(guestRole)
         .AddRole(recorderRole)
         .AddSettings(settings)
         .AddDestinations(destinations)
         .Build();

      var templateRecording = new TemplateRecordingBuilder(
         recorderRole.name ?? "default",
         RECORDER_ROLE
      )
      .AddCompositeRecording(false, true, false, 0, 1280, 720)
      .AddStreamRecording(1280, 720)
      .Build();

      var result = await PolicyRestCommand.CreateAsync(template);
   ```

2. Get a policy template by id

   ```c#
      var policyTemplateId = "Template Id";

      var result = await PolicyRestCommand.GetAsync(policyTemplateId);
   ```

3. Lists all policy templates

   ```c#
      var result = await PolicyRestCommand.ListAsync();
   ```

4. Lists all policy templates

   ```c#
      var policyTemplateId = "Policy Template Id";
      var template = await PolicyRestCommand.GetAsync(policyTemplateId);

      Role testRole = new RoleBuilder()
            .AddName("Test")
            .AddMaxPeerCount(10)
            .AddPriority(4)
            .Build();
      template?.roles.Add(testRole?.name, testRole);

      var result = await PolicyRestCommand.UpdateAsync(template);
   ```

5. Get a policy role

   ```c#
      var policyTemplateId = "Policy Template Id";
      var roleName = "Role Name";

      var result = await PolicyRestCommand.GetRoleAsync(policyTemplateId, roleName);
   ```

6. Update a policy role

   ```c#
      var templateId = "Policy Template Id";
      var roleName = "Role Name";

      var role = await PolicyRestCommand.GetRoleAsync(templateId, roleName);
      if (role is not null)
      {
         role.maxPeerCount = _settings.MaxPeerCount;
      }

      var result = await PolicyRestCommand.UpdateRoleAsync(templateId, role);
   ```

7. Delete a policy role

   ```c#
      var templateId = "Policy Template Id";
      var roleName = "Role Name";

      var result = await PolicyRestCommand.DeleteRoleAsync(templateId, roleName);
   ```

---

### Analytics

[100ms Analytics Overview](https://www.100ms.live/docs/server-side/v2/api-reference/analytics/overview)

This section provides code examples for the Analytics Server Side API

1. Get Track Events that can be used to understand participant's activity during the session

   ```c#
      var roomId = "Room Id";

      var filter = new EventFilter(roomId).AddType(EventType.TRACK_ADD_SUCCESS)
                                          .AddType(EventType.TRACK_REMOVE_SUCCESS)
                                          .AddType(EventType.TRACK_UPDATE_SUCCESS)
                                          .Filter();

      var result = await AnalyticsRestCommand.GetAsync<TrackEvent>(filter);
   ```

2. Get Recording Events

   ```c#
      var roomId = "Room Id";

      var filter = new EventFilter(roomId).AddType(EventType.BEAM_RECORDING_SUCCESS)
                                          .Filter();

      var result = await AnalyticsRestCommand.GetAsync<RecordingEvent>(filter);
   ```

3. Get Error Events that provide insight into specific problems faced by users

   ```c#
      var roomId = "Room Id";

      var filter = new EventFilter(roomId).AddType(EventType.CLIENT_CONNECT_FAILED)
                                          .AddType(EventType.CLIENT_JOIN_FAILED)
                                          .AddType(EventType.CLIENT_PUBLISH_FAILED)
                                          .AddType(EventType.CLIENT_SUBSCRIBE_FAILED)
                                          .AddType(EventType.CLIENT_DISCONNECTED)
                                          .Filter();

      var result = await AnalyticsRestCommand.GetAsync<ErrorEvent>(filter);
   ```

---

### Room Codes

[100ms Room Codes Overview](https://www.100ms.live/docs/server-side/v2/api-reference/room-codes/room-code-overview)

This section provides code examples for the Room Codes Server Side API

1. Creates Room Code for every Role in the Room at once

   ```c#
      var roomId = "Room Id";

      var result = await RoomCodeRestCommand.CreateAsync(roomId);
   ```

2. Creates a Room Code for a specific Role in a Room

   ```c#
      var roomId = "Room Id";
      var role = "guest";

      var result = await RoomCodeRestCommand.CreateRoleRoomCodeAsync(roomId, role);
   ```

3. Retrieves Room Codes for all Roles in a Room

   ```c#
      var roomId = "Room Id";

      var result = await RoomCodeRestCommand.ListAsync(roomId);
   ```

4. Updates the current state for a given Room Code.

   ```c#
      var roomCode = "Room Code";
      var enabled = false;

      var result = await RoomCodeRestCommand.UpdateAsync(roomCode, enabled);
   ```

---

### Recordings

[100ms Recordings Overview](https://www.100ms.live/docs/server-side/v2/api-reference/recordings/overview)

This section provides code examples for the Recordings Server Side API

1. Start a recording job for a room.

   ```c#
      var roomId = "Room Id";
      var width = 1280;
      var height = 720;
      var request = new RecordingRequestBuilder().AddResolution(width, height).Build();

      var result = await RecordingRestCommand.StartRecordingAsync(roomId, request);
   ```

2. Stop all recordings running in a room

   ```c#
      var roomId = "Room Id";

      var result = await RecordingRestCommand.StopRecordingAsync(roomId);
   ```

3. Stop a specific recording for a room by recording id

   ```c#
      var recordingId = "Recording Id";

      var result = await RecordingRestCommand.StopRecordingByIdAsync(recordingId);
   ```

4. Get the recording job object at any point after it has been created.

   ```c#
      var recordingId = "Recording Id";

      var result = await RecordingRestCommand.GetAsync(recordingId);
   ```

5. List and filter through recording jobs of a workspace. The response is paginated.

   ```c#
      var roomId = "Room Id";
      var status = "Status";
      var sessionId = "Session Id";
      var start = "Start";
      var limit = 100;

      // Note: filter fields are optional
      var requestFilter = new RecordingRequestFilter()
         .AddRoomId(roomId)
         .AddStatus(status)
         .AddSessionId(sessionId)
         .AddStart(start)
         .AddLimit(limit)
         .Filter();

      var result = await RecordingRestCommand.ListRecordingsAsync(requestFilter);
   ```

6. Pause recording for a specified room.

   ```c#
      var roomId = "Room Id";

      var result = await RecordingRestCommand.PauseRecordingAsync(roomId);
   ```

7. Resume recording for a specified room.

   ```c#
      var roomId = "Room Id";

      var result = await RecordingRestCommand.ResumeRecordingAsync(roomId);
   ```

---

### Recording Assets

[100ms Recording Assets Overview](https://www.100ms.live/docs/server-side/v2/api-reference/recording-assets/overview)

This section provides code examples for the Recording Assets Server Side API

1. Get a specific recording asset by id

   ```c#
      var assetId = "Recording Asset Id;

      var result = await RecordingAssetRestCommand.GetAsync(assetId);
   ```

2. Generate a short-lived pre-signed URL for a recording asset.

   ```c#
      var assetId = "Recording Asset Id";

      var result = await RecordingAssetRestCommand.GetPreSignedUrlAsync(assetId);
   ```

3. List and filter through recording assets of a workspace.

   ```c#
      var roomId = "Room Id";
      var status = "Status";
      var sessionId = "Session Id";
      var start = "Start";
      var limit = 100;

      var filter = new RecordingAssetFilter()
         .AddRoomId(roomId)
         .AddStatus(status)
         .AddSessionId(sessionId)
         .AddStart(start)
         .AddLimit(limit)
         .filter();

      var result = await RecordingAssetRestCommand.ListAsync(filter);
   ```

### Polls

[100ms Polls Overview](https://www.100ms.live/docs/server-side/v2/api-reference/polls/overview)

This section provides code examples for the Polls Server Side API

1. Create a poll

   ```c#
      var option1 = new Option()
      {
         index = 1,
         text = "Option1",
         weight = 1
      };

      var answer1 = new Answer()
      {
         hidden = false,
         text = "Answer1",
         options = [option1],
         trim = true,
         @case = false
      };

      var question1 = new QuestionBuilder(1, "Test Question 1", "text", false)
         .AddAnswer(answer1)
         .AddOption(option1)
         .Build();

      var poll = new PollBuilder("TestPoll", 1, true).AddQuestion(question1).Build();

      var result = await PollRestCommand.CreateAsync(poll);
   ```

2. Update a poll

   ```c#
      var pollId = "Poll Id";
      var updateTitle = $"Updated Title";
      var updateDuration = 10;

      var poll = await PollRestCommand.GetAsync(pollId);
      poll.duration = updateDuration;
      poll.Title = updateTitle;

      var result = await PollRestCommand.UpdateAsync(poll);
   ```

3. Get a specific poll by id

   ```c#
      var pollId = "Poll Id";


      var result = await PollRestCommand.GetAsync(pollId);
   ```

4. Get sessions in which the specified poll was run.

   ```c#
      var pollId = "Poll Id";

      var result = await PollRestCommand.GetSessionsAsync(pollId);
   ```

5. Get a specific response submitted by a user using a response_id

   ```c#
      var pollId = "Poll Id";
      var responseId = "Response Id";

      var result = await PollRestCommand.GetResponseAsync(pollId, responseId);
   ```

6. Get responses submitted by users for a given poll_id.

   ```c#
      var pollId = "Poll Id";

      var result = await PollRestCommand.GetResponsesAsync(pollId);
   ```

7. Get result for a given result_id

   ```c#
      var pollId = "Poll Id";
      var resultId = "Result Id";

      var result = await PollRestCommand.GetResultAsync(pollId, resultId);
   ```

8. This endpoint is used to get results about a given poll_id

   ```c#
      var pollId = "Poll Id";

      var result = await PollRestCommand.GetResultsAsync(pollId);
   ```

9. Get filtered poll results

   ```c#
      var pollId = "Poll Id";
      var start = "Last Response Id";
      var limit = 10;
      var questionIndex = 1;

      var filter = new PollFilter()
                        .AddStart(start)
                        .AddLimit(limit)
                        .AddQuestion(questionIndex)
                        .Filter();

      var result = await PollRestCommand.GetResultsAsync(pollId, filter);
   ```

10. Get filtered poll responses

```c#
   var pollId = "Poll Id";
   var all = false;
   var start = "Last Response Id";
   var limit = 10;
   var questionIndex = 1;

   var filter = new PollFilter()
                     .AddAll(all)
                     .AddStart(start)
                     .AddLimit(limit)
                     .AddQuestion(questionIndex)
                     .Filter();

   var result = await PollRestCommand.GetResponsesAsync(pollId, filter);
```

#### Last Updated

This README was last updated on [11/21/2024].
