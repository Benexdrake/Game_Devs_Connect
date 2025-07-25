# Frontend
echo -e '\033[1;32m>>>> Building Frontend'
echo ''
docker build --no-cache -f ../GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/Dockerfile -t benexdrake012/gamedevsconnect_frontend ../GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web

# Frontend
echo -e '\033[1;32m>>>> Pushing Frontend'
echo ''
docker push benexdrake012/gamedevsconnect_frontend