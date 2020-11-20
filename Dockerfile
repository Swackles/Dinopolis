FROM gableroux/unity3d:2020.1.13f1-webgl as build-stage
WORKDIR /app
COPY ./ .

FROM nginx
RUN mkdir /dinopolis
COPY --from=build-stage /app/build/. /etc/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf