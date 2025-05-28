# API-Azure
echo -e '\033[1;32m>>>> Deleting API Azure'
echo ''
kubectl delete deployment api-azure -n gamedevsconnect
kubectl delete service api-azure -n gamedevsconnect
echo ''

# API-Comment
echo -e '\033[1;32m>>>> Deleting API Comment'
echo ''
kubectl delete deployment api-comment -n gamedevsconnect
kubectl delete service api-comment -n gamedevsconnect
echo ''

# API-File
echo -e '\033[1;32m>>>> Deleting API File'
echo ''
kubectl delete deployment api-file -n gamedevsconnect
kubectl delete service api-file -n gamedevsconnect
echo ''

# API-Gateway
echo -e '\033[1;32m>>>> Deleting API Gateway'
echo ''
kubectl delete deployment api-gateway -n gamedevsconnect
kubectl delete service api-gateway -n gamedevsconnect
echo ''

# API-Notification
echo -e '\033[1;32m>>>> Deleting API Notification'
echo ''
kubectl delete deployment api-notification -n gamedevsconnect
kubectl delete service api-notification -n gamedevsconnect
echo ''

# API-Profile
echo -e '\033[1;32m>>>> Deleting API Profile'
echo ''
kubectl delete deployment api-profile -n gamedevsconnect
kubectl delete service api-profile -n gamedevsconnect
echo ''

# API-Project
echo -e '\033[1;32m>>>> Deleting API Project'
echo ''
kubectl delete deployment api-project -n gamedevsconnect
kubectl delete service api-project -n gamedevsconnect
echo ''

# API-Request
echo -e '\033[1;32m>>>> Deleting API Request'
echo ''
kubectl delete deployment api-request -n gamedevsconnect
kubectl delete service api-request -n gamedevsconnect
echo ''

# API-Tag
echo -e '\033[1;32m>>>> Deleting API Tag'
echo ''
kubectl delete deployment api-tag -n gamedevsconnect
kubectl delete service api-tag -n gamedevsconnect
echo ''

# API-User
echo -e '\033[1;32m>>>> Deleting API User'
echo ''
kubectl delete deployment api-user -n gamedevsconnect
kubectl delete service api-user -n gamedevsconnect

# API-User
echo -e '\033[1;32m>>>> Deleting Frontend'
echo ''
kubectl delete deployment frontend -n gamedevsconnect
kubectl delete service frontend -n gamedevsconnect

echo -e '\033[1;32m>>>> Deleting Ingress'
echo ''
kubectl delete ingress gamedevsconnect-ingress -n gamedevsconnect

kubectl get svc -n gamedevsconnect

kubectl delete namespace gamedevsconnect
