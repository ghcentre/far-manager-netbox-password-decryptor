#!/usr/bin/sh
[ -d ./build ] || mkdir ./build

cd src/FarNetboxPasswordDecryptor
dotnet publish FarNetboxPasswordDecryptor.csproj -c Release -o ../../build/ --sc -r win-x64 -p:PublishSingleFile=true
cd ../../