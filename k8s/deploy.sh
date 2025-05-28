###### Create Namespace 
echo -e '\033[1;32m>>>> Creating Namespace gamedevsconnect'
echo ''
kubectl apply -f namespace.yaml
echo ''

###### API-Azure 
echo -e '\033[1;32m>>>> Apply API Azure'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-azure.yaml
# Service
kubectl apply -f services/service-api-azure.yaml
echo ''

###### API-Comment 
echo -e '\033[1;32m>>>> Apply API Comment'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-comment.yaml
# Service
kubectl apply -f services/service-api-comment.yaml
echo ''

###### API-File 
echo -e '\033[1;32m>>>> Apply API File'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-file.yaml
# Service
kubectl apply -f services/service-api-file.yaml
echo ''

###### API-Gateway 
echo -e '\033[1;32m>>>> Apply API Gateway'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-gateway.yaml
# Service
kubectl apply -f services/service-api-gateway.yaml
echo ''

###### API-Notification 
echo -e '\033[1;32m>>>> Apply API Notification'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-notification.yaml
# Service
kubectl apply -f services/service-api-notification.yaml
echo ''

###### API-Profile 
echo -e '\033[1;32m>>>> Apply API Profile'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-profile.yaml
# Service
kubectl apply -f services/service-api-profile.yaml
echo ''

###### API-Project 
echo -e '\033[1;32m>>>> Apply API Project'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-project.yaml
# Service
kubectl apply -f services/service-api-project.yaml
echo ''

###### API-Request 
echo -e '\033[1;32m>>>> Apply API Request'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-request.yaml
# Service
kubectl apply -f services/service-api-request.yaml
echo ''

###### API-Tag 
echo -e '\033[1;32m>>>> Apply API Tag'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-tag.yaml
# Service
kubectl apply -f services/service-api-tag.yaml
echo ''

###### API-User 
echo -e '\033[1;32m>>>> Apply API User'
echo ''
# Deployment
kubectl apply -f deployments/deployment-api-user.yaml
# Service
kubectl apply -f services/service-api-user.yaml
echo ''

###### Frontend 
echo -e '\033[1;32m>>>> Apply Frontend'
echo ''
# Deployment
kubectl apply -f deployments/deployment-frontend.yaml
# Service
kubectl apply -f services/service-frontend.yaml
echo ''

echo -e '\033[1;32m>>>> Apply Ingress'
echo ''
kubectl apply -f ingress.yaml


kubectl get svc -n gamedevsconnect
echo ''
kubectl get pods -n gamedevsconnect