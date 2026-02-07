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

    $txd = 'Trixter.XDream'

    function Replace-InFile {
        param(
            [Parameter(Mandatory=$true)][string]$Path,
            [Parameter(Mandatory=$true)][string]$NewVersion,
            [Parameter(Mandatory=$true)][bool]$isCsproj
        )

        if (-not (Test-Path $Path)) {
            Write-Error "File not found: $Path"
            return $false
        }

        # Read/Write using UTF8 to match original script behavior
        [xml]$content = Get-Content -Path $Path -Raw -Encoding UTF8
                
        if ($isCsProj) {
            $content.Project.PropertyGroup.Version = $NewVersion
        } else {
            $content.Include.define = 'VERSION = "'+$NewVersion+'"'
        }
        $content.Save($Path)
        Write-Host "Updated: $Path"        

        return $true
    }

    Write-Host 'Updating API'
    $apiProj = Join-Path $PSScriptRoot "..\$txd.API\$txd.API.csproj"
    Replace-InFile -Path $apiProj -NewVersion $NewVersion -isCsproj $true

    Write-Host 'Updating Diagnostics'
    $diagProj = Join-Path $PSScriptRoot "..\$txd.Diagnostics\$txd.Diagnostics.csproj"
    Replace-InFile -Path $diagProj -NewVersion $NewVersion -isCsproj $true 

    Write-Host 'Updating Test Controller'
    $tcProj = Join-Path $PSScriptRoot "..\$txd.TestController\$txd.TestController.csproj"
    Replace-InFile -Path $tcProj -NewVersion $NewVersion -isCsproj $true

    Write-Host 'Updating installer project'
    $wxi = Join-Path $PSScriptRoot "..\$txd.Installer\Version.wxi"
    Replace-InFile -Path $wxi -NewVersion $NewVersion -isCsproj $false

    Write-Host 'Done.'
    exit 0
}
catch {
    Write-Error $_.Exception.Message
    exit 1
}