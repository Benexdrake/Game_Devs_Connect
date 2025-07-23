# Tutorial: Game Devs Connect

`Game Devs Connect` is an innovative social platform designed for game developers to **connect and collaborate**. It features a user-friendly *frontend application* built with Next.js, allowing users to browse and create posts, manage profiles, and participate in engaging quests. The platform's powerful functionalities are driven by a set of *independent backend microservices*, ensuring scalability and efficient management of user data, content, and challenges. The entire system's development and deployment processes are highly *automated* for reliability and speed.


## Visual Overview

```mermaid
flowchart TD
    A0["Frontend Web Application
"]
    A1["Backend Microservices
"]
    A2["API Communication & Data Models
"]
    A3["Authentication System
"]
    A4["Post & Content Management System
"]
    A5["Quest System
"]
    A6["Containerization (Docker)
"]
    A7["CI/CD (GitHub Actions)
"]
    A8["Infrastructure Provisioning (Terraform)
"]
    A9["Data Persistence (GDCDbContext)
"]
    A0 -- "Requests data" --> A1
    A1 -- "Implements APIs" --> A2
    A2 -- "Defines structure for" --> A0
    A1 -- "Uses" --> A9
    A0 -- "Utilizes" --> A3
    A1 -- "Provides" --> A4
    A1 -- "Provides" --> A5
    A6 -- "Packages" --> A0
    A6 -- "Packages" --> A1
    A7 -- "Automates" --> A6
    A8 -- "Deploys" --> A6
    A8 -- "Provisions database" --> A9
```

## Chapters

1. [API Communication & Data Models
](01_api_communication_data_models.md)
2. [Frontend Web Application
](02_frontend_web_application.md)
3. [Authentication System
](03_authentication_system.md)
4. [Backend Microservices
](04_backend_microservices.md)
5. [Post & Content Management System
](05_post_content_management_system.md)
6. [Quest System
](06_quest_system.md)
7. [Data Persistence (GDCDbContext)
](07_data_persistence_gdcdbcontext.md)
8. [Containerization (Docker)
](08_containerization_docker.md)
9. [Infrastructure Provisioning (Terraform)
](09_infrastructure_provisioning_terraform.md)
10. [CI/CD (GitHub Actions)
](10_ci_cd_github_actions.md)
