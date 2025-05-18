name="gamedevsconnect_server_gdc"
password="P@ssword1"
entry_port=1400
docker_network="gamedevsconnect_network"

echo "Stopping Docker Container"
docker stop $name

echo "Removing Docker Container"
docker rm $name

echo "Creating Docker Network..."
docker network create $docker_network

echo "Starting SQL Server..."
docker run -d --name $name --network $docker_network \
  -e ACCEPT_EULA=Y \
  -e SA_PASSWORD=$password \
  -p $entry_port:1433 \
  mcr.microsoft.com/mssql/server:latest

echo "Initiate Database Script..."
docker run --rm --network $docker_network \
  -v $(pwd)/init.sql:/init.sql \
  mcr.microsoft.com/mssql-tools \
  /opt/mssql-tools/bin/sqlcmd -S $name -U sa -P $password -i /init.sql

echo "Removing Docker Network..."
docker network rm $docker_network -f