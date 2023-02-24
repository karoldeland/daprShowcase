# Dapr Showcase

This part of the repository is used to demo Dapr service invocation and F5 experience in my Dapr talks.

# Run the demo

## Environment setup

### Install and initialize Dapr

1. Install instructions here: https://docs.dapr.io/getting-started/install-dapr-cli/
2. run `dapr init`

### Install Consul

For this demo to run, you'll need Consul. This tool is used for DNS resolution. It's a common scenario when deploying outside of Kubernetes to allow dynamic registration of running services for service discovery.

In some cases, Consul can be required because of conflict of different VPN configurations/tools with mDNS. 

1. Install Consul : https://developer.hashicorp.com/consul/docs/install
2. Launch using `consul agent --dev`

### Launch Identity Server

Identity Server is used as a local IdP for OAuth. It's required for the OAuth and bearer middlewares to run.

```
cd IdentityServer 
dotnet run --urls=https://localhost:5001/
```

## Run the demo

Open VS Code and hit F5. You should use the `Frontend + Cart with Dapr` launch configuration.
