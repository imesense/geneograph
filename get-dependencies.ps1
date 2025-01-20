if (-Not (Test-Path -Path "dep"))
{
    New-Item -Path "dep" -ItemType Directory
}

function Download-File
{
    param
    (
        [string] $Url,
        [string] $File
    )

    if (-Not (Test-Path -Path $File))
    {
        Invoke-WebRequest -Uri $Url -OutFile $File
    }
}

function Extract-Archive
{
    param
    (
        [string] $File,
        [string] $Destination
    )

    if (-Not (Test-Path -Path $Destination))
    {
        Expand-Archive -Path $File -DestinationPath $Destination
    }
}

function Get-InterFont
{
    $version = "4.1"
    $url = "https://github.com/rsms/inter/releases/download/v$version/Inter-$version.zip"
    $file = "Inter-$version.zip"

    Download-File -Url $url -File dep\$file
    Extract-Archive -File dep\$file -Destination dep\Inter\$version
}

function Get-RobotoFont
{
    $version = "3.010"
    $url = "https://github.com/googlefonts/roboto-3-classic/releases/download/v$version/Roboto_v$version.zip"
    $file = "Roboto_v$version.zip"

    Download-File -Url $url -File dep\$file
    Extract-Archive -File dep\$file -Destination dep\Roboto\$version

    Remove-Item -Path dep\Roboto\$version\__MACOSX -Recurse -Force
}

Get-InterFont
Get-RobotoFont
