FROM node:8.4.0

ENV TZ=America/Sao_Paulo

# cria o diretório web
WORKDIR /var/www/web

# instala todas dependências do node
COPY package.json .

RUN npm install

COPY . .

RUN echo 'America/Sao_Paulo' > /etc/timezone 

EXPOSE 3000
CMD [ "npm", "start" ]