# Deployment package

The Deployment package provides a cohesive interface to deploy assets for Unity Gaming Services (UGS).
It provides the base tooling for UGS to have shared functionality for deploying service configuration files on the servers.

> [!NOTE]
> A deployment is when service configuration files are synced
with service resources so that service clients can interact with them.

The Deployment package is not used on its own. Services integrate with it, allowing the service configuration to
be saved in version control.

|Topic|Description|
|---|---|
|[Getting started](./getting_started.md)|Get started with the Deployment package.|
|[Deployment window](./deployment_window.md)|Use the Deployment window to deploy assets.|
|[Deployment Definition](./deployment_definition.md)|Use Deployment Definitions to group assets for deployment.|
|[Environments](./environments.md)|Deploy assets to specific environments.|

## Supported packages

- [com.unity.services.cloudcode](https://docs.unity.com/cloud-code) **from 2.1.0**
- [com.unity.remote-config](https://docs.unity.com/remote-config) **from 3.2.0**
