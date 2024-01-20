#!/usr/bin/env bash
cd simple-website # front-end part

if [ ! $(which git) ]; then
    echo "Git is missing! Please install it."	
    exit
else
    git fetch
    git pull
fi

if [ ! $(which ng) ]; then
    echo "Ng is not present! Please install it."
    exit
else
    ng build
    sudo cp ./dist/simple-website/browser/* /var/www/html/
    sudo systemctl restart apache2
fi
