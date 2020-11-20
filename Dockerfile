FROM nginx:alpine

WORKDIR /dinopolis

COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY . /etc/nginx/html

CMD sed -i 's/$PORT/'"$PORT"'/g' /etc/nginx/conf.d/default.conf && nginx -g 'daemon off;'