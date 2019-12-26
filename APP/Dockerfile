# FROM node:10.13-alpine
# ENV NODE_ENV production
# WORKDIR /usr/src/app
# COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]
# RUN npm install --production --silent && mv node_modules ../
# COPY . .
# EXPOSE 4300
# CMD npm start

FROM node:alpine as build

# Create a work directory and copy over our dependency manifest files.
WORKDIR /app
COPY / /app

RUN npm install

RUN npm start
