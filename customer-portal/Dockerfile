# syntax=docker/dockerfile:1
   
FROM node:18-alpine
WORKDIR /customer-portal
COPY . .
RUN npm install 
CMD ["node", "app/page.tsx"]
EXPOSE 3000