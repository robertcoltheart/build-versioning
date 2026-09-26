#!/usr/bin/env dotnet
#:sdk Cake.Sdk

var target = Argument("target", "Package");

Task("Clean")
    .Does(() =>
{
    CleanDirectory("./artifacts");
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetRestore();
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        StartProcess("dotnet", "build --configuration Release --no-restore ");
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    StartProcess("dotnet", "test --configuration Release --no-restore --no-build");
});

Task("Package")
    .IsDependentOn("Test")
    .Does(() =>
{
});

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
{
});

RunTarget(target);
