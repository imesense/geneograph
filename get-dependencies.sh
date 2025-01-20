#!/usr/bin/env bash

if [ ! -d "dep" ]
then
    mkdir -p dep
fi

download_file()
{
    local url=""
    local file=""

    while [[ $# -gt 0 ]]
    do
        case "$1" in
            --url)
                url="$2"
                shift 2
                ;;
            --file)
                file="$2"
                shift 2
                ;;
        esac
    done

    if [ ! -f "$file" ]
    then
        wget -O "$file" "$url"
    fi
}

extract_archive()
{
    local file=""
    local destination=""

    while [[ $# -gt 0 ]]
    do
        case "$1" in
            --file)
                file="$2"
                shift 2
                ;;
            --destination)
                destination="$2"
                shift 2
                ;;
        esac
    done

    if [ ! -d "$destination" ]
    then
        mkdir -p "$destination"
        unzip "$file" -d "$destination"
    fi
}

get_interfont()
{
    local version="4.1"
    local url="https://github.com/rsms/inter/releases/download/v$version/Inter-$version.zip"
    local file="Inter-$version.zip"

    download_file --url "$url" --file "dep/$file"
    extract_archive --file "dep/$file" --destination "dep/Inter/$version"
}

get_robotofont()
{
    local version="3.010"
    local url="https://github.com/googlefonts/roboto-3-classic/releases/download/v$version/Roboto_v$version.zip"
    local file="Roboto_v$version.zip"

    download_file --url "$url" --file "dep/$file"
    extract_archive --file "dep/$file" --destination "dep/Roboto/$version"

    rm -rf dep/Roboto/$version/__MACOSX
}

get_interfont
get_robotofont
