FROM mcr.microsoft.com/mssql/server:latest

ENV ACCEPT_EULA=Y

ENV SA_PASSWORD=P@ssword1

EXPOSE 1433

COPY init.sql /docker-entrypoint-initdb.d/