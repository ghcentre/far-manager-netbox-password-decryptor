setlocal enableextensions enabledelayedexpansion
if not exist build (mkdir build)

pushd src\FarNetboxPasswordDecryptor
dotnet publish FarNetboxPasswordDecryptor.csproj -c Release -o ..\..\build\ --sc -r win-x64 -p:PublishSingleFile=true
popd

endlocal