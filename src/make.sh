#!/bin/sh

dotnet build   Thawed
dotnet test    Thawed.UnitTests
dotnet pack    Thawed           -o ../dist

