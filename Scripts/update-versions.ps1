<#
.SYNOPSIS
    Update project and installer version numbers from version.txt.

.DESCRIPTION
    Replaces product/version fields in .csproj files and the VERSION define in the installer
    Version.wxi. Intended to run from the repository Scripts folder (the script sets location
    to its own folder automatically). 

.USAGE
    .\update-versions.ps1                # reads version from version.txt
    .\update-versions.ps1 -NewVersion 1.6.0
#>

param(
    [string]$NewVersion
)

Set-StrictMode -Version Latest

try {
    # ensure script runs from its directory (matches batch behavior)
    Set-Location -Path $PSScriptRoot

    if (-not $NewVersion) {
        $versionFile = Join-Path $PSScriptRoot 'version.txt'
        if (-not (Test-Path $versionFile)) {
            Write-Error "version.txt not found at $versionFile"
            exit 1
        }

        $raw = Get-Content -Path $versionFile -Raw -ErrorAction Stop
        $NewVersion = $raw.Trim()
    }

    if ([string]::IsNullOrWhiteSpace($NewVersion)) {
        Write-Error 'No version found or provided.'
        exit 1
    }

    Write-Host "New Version: $NewVersion"

    # Regex patterns (uses .NET regex)
    $versionNumberRegex = '\d+(?:\.\d+){2,3}'
    $csprojProductVersionRegex = "(<Version>)$versionNumberRegex(</Version>)"
    $csprojVersionReplacement = '${1}' + $NewVersion + '${2}'

    $wixVersionRegex = '(<\?define\s+VERSION\s*=\s*")' + $versionNumberRegex + '("\s*\?>)'
    $wixVersionReplacement = '${1}' + $NewVersion + '${2}'

    $txd = 'Trixter.XDream'

    function Replace-InFile {
        param(
            [Parameter(Mandatory=$true)][string]$Path,
            [Parameter(Mandatory=$true)][string]$Pattern,
            [Parameter(Mandatory=$true)][string]$Replacement
        )

        if (-not (Test-Path $Path)) {
            Write-Error "File not found: $Path"
            return $false
        }

        # Read/Write using UTF8 to match original script behavior
        $content = Get-Content -Path $Path -Raw -Encoding UTF8
        $newContent = [regex]::Replace($content, $Pattern, $Replacement)

        if ($newContent -ne $content) {
            Set-Content -Path $Path -Value $newContent -Encoding UTF8
            Write-Host "Updated: $Path"
        }
        else {
            Write-Host "No matching pattern found in: $Path"
        }

        return $true
    }

    Write-Host 'Updating API'
    $apiProj = Join-Path $PSScriptRoot "..\$txd.API\$txd.API.csproj"
    if (-not (Replace-InFile -Path $apiProj -Pattern $csprojProductVersionRegex -Replacement $csprojVersionReplacement)) { exit 1 }

    Write-Host 'Updating Diagnostics'
    $diagProj = Join-Path $PSScriptRoot "..\$txd.Diagnostics\$txd.Diagnostics.csproj"
    if (-not (Replace-InFile -Path $diagProj -Pattern $csprojProductVersionRegex -Replacement $csprojVersionReplacement)) { exit 1 }

    Write-Host 'Updating Test Controller'
    $tcProj = Join-Path $PSScriptRoot "..\$txd.TestController\$txd.TestController.csproj"
    if (-not (Replace-InFile -Path $tcProj -Pattern $csprojProductVersionRegex -Replacement $csprojVersionReplacement)) { exit 1 }

    Write-Host 'Updating installer project'
    $wxi = Join-Path $PSScriptRoot "..\$txd.Installer\Version.wxi"
    if (-not (Replace-InFile -Path $wxi -Pattern $wixVersionRegex -Replacement $wixVersionReplacement)) { exit 1 }

    Write-Host 'Done.'
    exit 0
}
catch {
    Write-Error $_.Exception.Message
    exit 1
}