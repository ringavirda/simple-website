#!/usr/bin/env bash
cd SimpleApi || exit # back-end part

if [ ! "$(which git)" ]; then
    echo "Git is missing! Please install it."	
    exit
else
    git fetch
    git pull
fi

if [ ! "$(which dotnet)" ]; then
    echo "Dotnet is not present! Please install it."
    exit
else
    sudo dotnet publish -c Release -o /var/srv/simple-api/   
    sudo systemctl restart simple-api
fi
