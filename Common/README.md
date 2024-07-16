## Commends

    dotnet build ./src/Training.Common
    dotnet pack ./src/Training.Common
    dotnet nuget push --source "TrainerFeed" --api-key az ./src/Training.Common/bin/Debug/Training.Common.0.4.3.nupkg
