## Commends
## Training.Common.Hexagon.Core
    dotnet build ./src/Training.Common.Hexagon.Core
    dotnet pack ./src/Training.Common.Hexagon.Core
    dotnet nuget push --source "TrainerFeed" --api-key az ./src/Training.Common.Hexagon.Core/bin/Debug/Training.Common.Hexagon.Core.0.1.0.nupkg

## Training.Common.Hexagon.Integration
    dotnet build ./src/Training.Common.Hexagon.Integration
    dotnet pack ./src/Training.Common.Hexagon.Integration
    dotnet nuget push --source "TrainerFeed" --api-key az ./src/Training.Common.Hexagon.Integration/bin/Debug/Training.Common.Hexagon.Integration.0.1.0.nupkg

## Training.Common.Hexagon.Persistance
    dotnet build ./src/Training.Common.Hexagon.Persistance
    dotnet pack ./src/Training.Common.Hexagon.Persistance
    dotnet nuget push --source "TrainerFeed" --api-key az ./src/Training.Common.Hexagon.Persistance/bin/Debug/Training.Common.Hexagon.Persistance.0.1.0.nupkg

## Training.Common.Hexagon.AspNetCore
    dotnet build ./src/Training.Common.Hexagon.AspNetCore
    dotnet pack ./src/Training.Common.Hexagon.AspNetCore
    dotnet nuget push --source "TrainerFeed" --api-key az ./src/Training.Common.Hexagon.AspNetCore/bin/Debug/Training.Common.Hexagon.AspNetCore.0.1.0.nupkg

## Training.Common.Hexagon.API
    dotnet build ./src/Training.Common.Hexagon.API
    dotnet pack ./src/Training.Common.Hexagon.API
    dotnet nuget push --source "TrainerFeed" --api-key az ./src/Training.Common.Hexagon.API/bin/Debug/Training.Common.Hexagon.API.0.1.1.nupkg