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

1. Rooms (complete)
2. ActiveRooms (complete)
3. External Streams
4. Live Streams
5. Sessions (Complete)
6. Policy
7. Analytics
8. Room Codes
9. Recordings
10. Recoding assets
11. Stream Key
12. Polls

---

### Rooms

[100ms Rooms Overview](https://www.100ms.live/docs/server-side/v2/api-reference/Rooms/overview)

In this section we will provide examples of function usage within the Rooms functional area

1. Create a new room

   ```c#
      var result = await RoomRestCommand.CreateRoomAsync(
         "RoomName",
         "RoomDescription",
         "TemplateId"
      );
   ```

2. List all rooms

   ```c#
      var result = await RoomRestCommand.ListRoomsAsync();
   ```

3. Retrieve a specific room

   ```c#
      var result = await RoomRestCommand.GetRoomAsync("RoomId");
   ```

4. Update a room

   ```c#
      var updateRoomRequest = new UpdateRoomRequestBuilder()
               .AddName("RoomName")
               .AddDescription("RoomDescription")
               .AddRecordingInfo()
               .AddUploadInfo(StorageType.S3, "Bucket", region: Region.Aws.<region>)
               .AddCredentials("BucketAccessKey", "BucketSecretKey")
               .Build();

      var result = await RoomRestCommand.UpdateRoomAsync("RoomId", updateRoomRequest);
   ```

5. Disable / Enable a room

   ```c#
      var enableDisableRoomRequest = new EnableDisableRoomRequest()
      {
         enabled = true
      };

      var result = await RoomRestCommand.EnableDisableRoomAsync(
         "RoomId",
         enableDisableRoomRequest
      );
   ```

### Sessions

[100ms Sessions Overview](https://www.100ms.live/docs/server-side/v2/api-reference/Sessions/object)

In this section we will provide examples of function usage within the Sessions functional area

1. Retrieve a specific session

   ```c#
      var result = await SessionRestCommand.GetAsync(_settings.SessionId);
   ```

2. List Sessions based on filter values

   ```c#
      var filter = new SessionsRequestFilter()
         .AddRoomId("RoomId")
         .AddActive(false)
         .AddAfter("AfterDateTime")
         .AddBefore("BeforeDateTime")
         .AddLimit(25)
         .Filter();

      var result = await SessionRestCommand.ListSessionsAsync(filter);
   ```
