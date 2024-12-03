#!/usr/bin/env bash
rm -rf 2-new_project
mkdir 2-new_project
cd 2-new_project
dotnet new console
dotnet build
dotnet run

