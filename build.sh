#!/usr/bin/env bash

set -euo pipefail

printenv

if which dotnet > /dev/null; then
    dotnet cake.cs -- "$@"
else
    echo "error(1): Could not find 'dotnet', please install .NET SDK"
    exit 1
fi
