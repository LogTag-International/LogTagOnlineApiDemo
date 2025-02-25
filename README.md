# LogTagOnlineApiDemo

This application provides basic examples of how to consume our External APIs. It is intended for educational purposes and is not production-grade code.

## Version
This web application is built on .NET 8.0 and references API Documentation rev 1.1.

## Configuration
Typically, no configuration adjustments are necessary unless you need to change environments. If this is required, modify the following files:
- `Api/appsettings.json`
- `Api/appsettings.Development.json`

## Running with VS Code
To run this project in VS Code, ensure you have the C# Dev Kit extension by Microsoft installed.

### Steps:
1. Open the Backend folder as a workspace in VS Code.
   ```
   PS C:\src\LogTagOnlineApiDemo>
   ```
2. Use the following launch command:
   ```
   dotnet watch run --project .\Api\Api.csproj --launch-profile http
   ```
3. Alternatively, use the Run and Debug menu for full debugging support.

## Running with Visual Studio 2022
1. Open `LogTagOnlineApiDemo.sln` with Visual Studio.
2. Allow some time for the packages to restore.
3. Press Play (Run and Debug).

## How to Use
The Swagger UI is available in debug mode and can be used to perform the following steps. Alternatively, use a tool like Postman to make requests.

### Steps:
1. **Retrieve Token and Team Details**:
   - Use the `GetToken` endpoint in the `AuthModule` to obtain a valid token and team details.
2. **Retrieve Devices List**:
   - Use the `GetDevices` endpoint in the `DevicesModule` with a valid token and team ID to get your devices list.
3. **Retrieve Device Readings**:
   - Use the `ReadingsModule` endpoints to fetch readings for the devices obtained from the `GetDevices` endpoint. Supply at the very least a valid token, team ID, and applicable serial number.
4. **Retrieve Profiles List**:
   - Use the `GetProfiles` endpoint in the `ProfilesModule` with a valid token and team ID to get your profiles list.
5. **Retrieve Shipments List with Alarm Details**:
   - Use the `GetShipmentDetails` endpoint in the `ShipmentsModule` to fetch details for a specific shipment. Supply a valid token, team ID, and Shipment State Filter Id.

   ## Shipment State Filter Id
   The Shipment State Filter Id is used to categorize the different states of a shipment:
   - **Pending (1)**: The shipment is awaiting processing or has not yet started its journey.
   - **InTransit (2)**: The shipment is currently on its way to the destination.
   - **Completed (3)**: The shipment has successfully reached its destination and the process is finished.
   - **Active (4)**: The shipment is currently being handled (includes both Pending and InTransit states).
   - **All (5)**: Includes all shipments, regardless of their current status.
