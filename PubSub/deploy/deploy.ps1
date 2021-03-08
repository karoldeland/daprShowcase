# Helm config
helm repo add bitnami https://charts.bitnami.com/bitnami
helm repo add dapr https://dapr.github.io/helm-charts/
helm repo update

# Install Redis
helm install redis bitnami/redis --wait

kubectl get pods 

# Install Dapr on Kubernetes
helm upgrade --install dapr dapr/dapr  `
--version=1.0.0 `
--namespace dapr-system `
--create-namespace `
--set global.ha.enabled=true `
--wait

kubectl apply -f appconfig.yaml
kubectl apply -f zipkin.yaml
kubectl apply -f redis-pubsub.yaml


cd ../src
docker build -t cart:stable -f ./cart/Dockerfile .
docker build -t email:stable -f ./email/Dockerfile .
docker build -t shipping:stable -f ./shipping/Dockerfile .

helm upgrade --install cart ./cart/charts/cart
helm upgrade --install email ./email/charts/email
helm upgrade --install shipping ./shipping/charts/shipping

