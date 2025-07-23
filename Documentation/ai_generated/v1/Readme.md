# Tutorial: Game_Devs_Connect

Game_Devs_Connect is an *online social platform* designed for **game developers** to connect and collaborate. Users can share ideas and progress through **posts** (including text and images), manage their *developer profiles*, and participate in a unique *quest system* to engage in challenges and tasks.


## Visual Overview

```mermaid
flowchart TD

    A0["Backend Microservices"]
    A1["Frontend Web Application"]
    A2["Infrastructure Provisioning (Terraform)"]
    A3["Containerization & CI/CD"]
    A4["API Communication & Data Models"]
    A5["Authentication System"]
    A6["Post & Content Management"]
    A7["Quest System"]

    A1 -- "Consumes Services" --> A0
    A1 -- "Uses Contracts" --> A4
    A1 -- "Integrates Login" --> A5
    A1 -- "Displays Content" --> A6
    A1 -- "Displays Quests" --> A7
    A0 -- "Defines Contracts" --> A4
    A5 -- "Manages User Data" --> A0
    A5 -- "Uses Data Models" --> A4
    A6 -- "Manages Content" --> A0
    A6 -- "Uses Data Models" --> A4
    A7 -- "Manages Quests" --> A0
    A7 -- "Uses Data Models" --> A4
    A2 -- "Deploys Services" --> A0
    A2 -- "Deploys Application" --> A1
    A3 -- "Packages Services" --> A0
    A3 -- "Packages Application" --> A1
    A3 -- "Provides Containers" --> A2
```

## Chapters

1. [Frontend Web Application
](01_frontend_web_application.md)
2. [Authentication System
](02_authentication_system.md)
3. [Post & Content Management
](03_post_content_management.md)
4. [Quest System
](04_quest_system.md)
5. [Backend Microservices
](05_backend_microservices.md)
6. [API Communication & Data Models
](06_api_communication_data_models.md)
7. [Containerization & CI/CD
](07_containerization_ci_cd.md)
8. [Infrastructure Provisioning (Terraform)
](08_infrastructure_provisioning_terraform.md)

---