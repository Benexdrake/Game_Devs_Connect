# Gateway
echo -e '\033[1;32m>>>> Building Gateway'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.Gateway/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_gateway ../
echo ''

# Azure
echo -e '\033[1;32m>>>> Building Azure'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.Azure/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_azure ../
echo ''

# Comment
echo -e '\033[1;32m>>>> Building Comment'
echo ''                             
docker build --no-cache -f ../GameDevsConnect.Backend.API.Comment/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_comment ../
echo ''

# File
echo -e '\033[1;32m>>>> Building File'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.File/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_file ../
echo ''

# Notification
echo -e '\033[1;32m>>>> Building Notification'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.Notification/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_notification ../
echo ''

# Profile
echo -e '\033[1;32m>>>> Building Profile'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.Profile/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_profile ../
echo ''

# Project
echo -e '\033[1;32m>>>> Building Project'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.Project/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_project ../
echo ''

# Request
echo -e '\033[1;32m>>>> Building Request'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.Request/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_request ../
echo ''

# Tag
echo -e '\033[1;32m>>>> Building Tag'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.Tag/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_tag ../
echo ''

# User
echo -e '\033[1;32m>>>> Building User'
echo ''
docker build --no-cache -f ../GameDevsConnect.Backend.API.User/Dockerfile -t benexdrake012/gamedevsconnect_backend_api_user ../
echo ''

# Frontend
echo -e '\033[1;32m>>>> Building Frontend'
echo ''
docker build --no-cache -f ../GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/Dockerfile -t benexdrake012/gamedevsconnect_frontend ../GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web