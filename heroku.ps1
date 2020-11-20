Copy-Item Dockerfile, nginx.conf -Destination ./build

cd ./build

heroku container:push web -a elu-dinopolis
heroku container:release web -a elu-dinopolis

cd ../