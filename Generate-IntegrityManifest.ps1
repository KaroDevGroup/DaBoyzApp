# KaroDevGroup
# Josh Karo

param
(
    [Parameter(Mandatory = $true)]
    [string]$BuildFolder
)

$ErrorActionPreference = "Stop"

$BuildFolder = [System.IO.Path]::GetFullPath($BuildFolder)
$BuildFolder = $BuildFolder.TrimEnd("\", "/")

if (-not (Test-Path $BuildFolder))
{
    Write-Host ""
    Write-Host "ERROR: Build folder does not exist:" -ForegroundColor Red
    Write-Host $BuildFolder -ForegroundColor Yellow
    Write-Host ""

    exit 1
}

Write-Host ""
Write-Host "============================================" -ForegroundColor DarkRed
Write-Host "       DA BOYZ INTEGRITY GENERATOR" -ForegroundColor Red
Write-Host "============================================" -ForegroundColor DarkRed
Write-Host ""

Write-Host "Build folder:" -ForegroundColor Gray
Write-Host $BuildFolder -ForegroundColor White
Write-Host ""

$ManifestFiles = @()

function Get-DaBoyzRelativePath
{
    param
    (
        [string]$BasePath,
        [string]$FullPath
    )

    $NormalizedBase = $BasePath.TrimEnd("\", "/")

    if ($FullPath.StartsWith(
        $NormalizedBase,
        [System.StringComparison]::OrdinalIgnoreCase))
    {
        return $FullPath.Substring(
            $NormalizedBase.Length
        ).TrimStart("\", "/")
    }

    return $FullPath
}

function Add-ProtectedFile
{
    param
    (
        [string]$FullPath,
        [string]$RelativePath
    )

    if (-not (Test-Path $FullPath -PathType Leaf))
    {
        Write-Host "[MISSING] $RelativePath" -ForegroundColor Yellow
        return
    }

    $Hash = Get-FileHash `
        -Path $FullPath `
        -Algorithm SHA256

    $NormalizedPath = $RelativePath.Replace("\", "/")

    $script:ManifestFiles += [PSCustomObject]@{

        path = $NormalizedPath

        sha256 = $Hash.Hash.ToLower()

    }

    Write-Host "[HASHED]  $NormalizedPath" -ForegroundColor Green
}

Write-Host "Scanning protected application files..." -ForegroundColor Cyan
Write-Host ""

$MainExecutable = Join-Path $BuildFolder "DaBoyzApp.exe"

Add-ProtectedFile `
    -FullPath $MainExecutable `
    -RelativePath "DaBoyzApp.exe"

$WebViewLoader = Join-Path $BuildFolder "WebView2Loader.dll"

Add-ProtectedFile `
    -FullPath $WebViewLoader `
    -RelativePath "WebView2Loader.dll"

Write-Host ""
Write-Host "Scanning WebView2 files..." -ForegroundColor Cyan
Write-Host ""

$WebViewFiles = Get-ChildItem `
    -Path $BuildFolder `
    -File |
    Where-Object {

        $_.Name -like "Microsoft.Web.WebView2.*.dll"

    } |
    Sort-Object Name

if ($WebViewFiles.Count -eq 0)
{
    Write-Host "[WARNING] No Microsoft.Web.WebView2 files found." -ForegroundColor Yellow
}
else
{
    foreach ($File in $WebViewFiles)
    {
        Add-ProtectedFile `
            -FullPath $File.FullName `
            -RelativePath $File.Name
    }
}

Write-Host ""
Write-Host "Scanning Assets..." -ForegroundColor Cyan
Write-Host ""

$AssetsFolder = Join-Path $BuildFolder "Assets"

if (Test-Path $AssetsFolder)
{
    $AssetFiles = Get-ChildItem `
        -Path $AssetsFolder `
        -File `
        -Recurse |
        Sort-Object FullName

    foreach ($File in $AssetFiles)
    {
        $RelativePath = Get-DaBoyzRelativePath `
            -BasePath $BuildFolder `
            -FullPath $File.FullName

        Add-ProtectedFile `
            -FullPath $File.FullName `
            -RelativePath $RelativePath
    }
}
else
{
    Write-Host "[WARNING] Assets folder was not found." -ForegroundColor Yellow
}

$ManifestFiles = $ManifestFiles |
    Sort-Object path

$Manifest = [PSCustomObject]@{

    manifestVersion = 1

    generatedUtc = [DateTime]::UtcNow.ToString("o")

    algorithm = "SHA256"

    fileCount = $ManifestFiles.Count

    files = $ManifestFiles

}

$ManifestPath = Join-Path `
    $BuildFolder `
    "integrity-manifest.json"

$Manifest |
    ConvertTo-Json -Depth 10 |
    Set-Content `
        -Path $ManifestPath `
        -Encoding UTF8

Write-Host ""
Write-Host "============================================" -ForegroundColor DarkRed
Write-Host "          MANIFEST COMPLETE" -ForegroundColor Green
Write-Host "============================================" -ForegroundColor DarkRed
Write-Host ""

Write-Host "Protected files: $($ManifestFiles.Count)" -ForegroundColor White

Write-Host ""

Write-Host "Manifest:" -ForegroundColor Gray
Write-Host $ManifestPath -ForegroundColor White

Write-Host ""