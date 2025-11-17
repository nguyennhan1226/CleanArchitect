# HR Leave Management System - Technical Flow Diagrams

## System Architecture Flow

```mermaid
graph TB
    subgraph "Presentation Layer"
        BUI[Blazor WebAssembly UI]
        API[Web API Controllers]
    end
    
    subgraph "Application Layer"
        MED[MediatR]
        CMD[Command Handlers]
        QRY[Query Handlers]
        VAL[Validators]
        MAP[AutoMapper]
    end
    
    subgraph "Domain Layer"
        ENT[Domain Entities]
        BE[Base Entity]
    end
    
    subgraph "Infrastructure Layer"
        REPO[Repositories]
        DB[Entity Framework]
        EMAIL[Email Service]
        LOG[Logging Service]
    end
    
    BUI -->|HTTP Requests| API
    API -->|Commands/Queries| MED
    MED --> CMD
    MED --> QRY
    CMD --> VAL
    CMD --> MAP
    QRY --> MAP
    CMD --> REPO
    QRY --> REPO
    REPO --> DB
    CMD --> EMAIL
    CMD --> LOG
    
    MAP --> ENT
    ENT --> BE
    DB --> ENT
```

## Leave Request Processing Flow

```mermaid
sequenceDiagram
    participant E as Employee
    participant UI as Blazor UI
    participant API as Web API
    participant MED as MediatR
    participant H as Command Handler
    participant V as Validator
    participant R as Repository
    participant DB as Database
    participant ES as Email Service

    E->>UI: Submit Leave Request
    UI->>API: POST /api/leaverequest
    API->>MED: CreateLeaveRequestCommand
    MED->>H: Handle Command
    H->>V: Validate Request
    
    alt Validation Fails
        V-->>H: Validation Errors
        H-->>API: BadRequestException
        API-->>UI: 400 Bad Request
        UI-->>E: Show Validation Errors
    else Validation Success
        V-->>H: Valid
        H->>R: CreateAsync(LeaveRequest)
        R->>DB: Insert Record
        DB-->>R: Success
        R-->>H: Entity Created
        
        H->>ES: Send Email Notification
        ES-->>H: Email Sent
        
        H-->>MED: Success
        MED-->>API: Unit
        API-->>UI: 201 Created
        UI-->>E: Success Message
    end
```

## Leave Approval Workflow

```mermaid
stateDiagram-v2
    [*] --> Submitted: Employee submits request
    Submitted --> PendingApproval: Manager notified
    PendingApproval --> Approved: Manager approves
    PendingApproval --> Rejected: Manager rejects
    Approved --> Cancelled: Employee cancels
    Submitted --> Cancelled: Employee cancels
    Approved --> [*]: Process complete
    Rejected --> [*]: Process complete
    Cancelled --> [*]: Process complete
    
    note right of PendingApproval
        Email sent to manager
        Request appears in manager's queue
    end note
    
    note right of Approved
        Email sent to employee
        Leave allocation updated
    end note
    
    note right of Rejected
        Email sent to employee
        No allocation changes
    end note
```

## Data Access Pattern Flow

```mermaid
graph LR
    subgraph "Application Layer"
        CH[Command Handler]
        QH[Query Handler]
    end
    
    subgraph "Repository Pattern"
        IGR[IGenericRepository<T>]
        ILT[ILeaveTypeRepository]
        ILR[ILeaveRequestRepository]
        ILA[ILeaveAllocationRepository]
        
        GR[GenericRepository<T>]
        LTR[LeaveTypeRepository]
        LRR[LeaveRequestRepository]
        LAR[LeaveAllocationRepository]
    end
    
    subgraph "Data Access"
        EF[Entity Framework Core]
        DB[(SQL Server Database)]
    end
    
    CH --> ILT
    CH --> ILR
    CH --> ILA
    QH --> ILT
    QH --> ILR
    QH --> ILA
    
    ILT -.implements.- LTR
    ILR -.implements.- LRR
    ILA -.implements.- LAR
    
    IGR -.implements.- GR
    LTR -.extends.- GR
    LRR -.extends.- GR
    LAR -.extends.- GR
    
    GR --> EF
    LTR --> EF
    LRR --> EF
    LAR --> EF
    
    EF --> DB
```

## CQRS Implementation Flow

```mermaid
graph TB
    subgraph "Commands (Write)"
        CC[Create Commands]
        UC[Update Commands]
        DC[Delete Commands]
        
        CCH[Create Handlers]
        UCH[Update Handlers]
        DCH[Delete Handlers]
    end
    
    subgraph "Queries (Read)"
        GQ[Get Queries]
        LQ[List Queries]
        
        GQH[Get Query Handlers]
        LQH[List Query Handlers]
    end
    
    subgraph "Shared"
        MED[MediatR Pipeline]
        VAL[Validation Behavior]
        LOG[Logging Behavior]
    end
    
    subgraph "Data Layer"
        WREPO[Write Repository]
        RREPO[Read Repository]
        DB[(Database)]
    end
    
    CC --> MED
    UC --> MED
    DC --> MED
    GQ --> MED
    LQ --> MED
    
    MED --> VAL
    VAL --> LOG
    
    LOG --> CCH
    LOG --> UCH
    LOG --> DCH
    LOG --> GQH
    LOG --> LQH
    
    CCH --> WREPO
    UCH --> WREPO
    DCH --> WREPO
    
    GQH --> RREPO
    LQH --> RREPO
    
    WREPO --> DB
    RREPO --> DB
```

## Email Notification Flow

```mermaid
sequenceDiagram
    participant H as Command Handler
    participant ES as Email Service
    participant SMTP as SMTP Server
    participant M as Manager
    participant E as Employee

    Note over H: Leave Request Created
    H->>ES: SendEmail(EmailMessage)
    ES->>SMTP: Send notification email
    SMTP->>M: Email notification
    
    Note over H: Leave Request Approved/Rejected
    H->>ES: SendEmail(StatusUpdate)
    ES->>SMTP: Send status email
    SMTP->>E: Status notification
    
    Note over H: Error handling
    alt Email fails
        ES-->>H: Exception
        H->>H: Log warning and continue
    end
```

## Entity Relationship Diagram

```mermaid
erDiagram
    BaseEntity {
        int Id PK
        datetime DateCreated
        datetime DateModified
    }
    
    LeaveType {
        int Id PK
        string Name
        int DefaultDays
        datetime DateCreated
        datetime DateModified
    }
    
    LeaveRequest {
        int Id PK
        datetime StartDate
        datetime EndDate
        int LeaveTypeId FK
        datetime DateRequested
        string RequestComments
        bool Approved
        bool Cancelled
        string RequestingEmployeeId
        datetime DateCreated
        datetime DateModified
    }
    
    LeaveAllocation {
        int Id PK
        int NumberOfDays
        int LeaveTypeId FK
        int Period
        string EmployeeId
        datetime DateCreated
        datetime DateModified
    }
    
    BaseEntity ||--|| LeaveType : inherits
    BaseEntity ||--|| LeaveRequest : inherits
    BaseEntity ||--|| LeaveAllocation : inherits
    
    LeaveType ||--o{ LeaveRequest : "has many"
    LeaveType ||--o{ LeaveAllocation : "has many"
```

## Authentication & Authorization Flow (Future Implementation)

```mermaid
sequenceDiagram
    participant U as User
    participant BUI as Blazor UI
    participant API as Web API
    participant AUTH as Auth Service
    participant DB as Database

    U->>BUI: Login Request
    BUI->>AUTH: Authenticate
    AUTH->>DB: Verify Credentials
    DB-->>AUTH: User Data
    AUTH-->>BUI: JWT Token
    BUI-->>U: Login Success
    
    Note over BUI: Store JWT in memory/localStorage
    
    U->>BUI: API Request
    BUI->>API: Request + JWT Token
    API->>API: Validate JWT
    
    alt Valid Token
        API->>API: Check Permissions
        alt Authorized
            API-->>BUI: Response Data
            BUI-->>U: Display Data
        else Unauthorized
            API-->>BUI: 403 Forbidden
            BUI-->>U: Access Denied
        end
    else Invalid Token
        API-->>BUI: 401 Unauthorized
        BUI->>BUI: Redirect to Login
        BUI-->>U: Please Login
    end
```

## Deployment Flow

```mermaid
graph TB
    subgraph "Development"
        DEV[Developer Machine]
        GIT[Git Repository]
    end
    
    subgraph "CI/CD Pipeline"
        BUILD[Build Server]
        TEST[Automated Tests]
        PACK[Package Application]
    end
    
    subgraph "Production Environment"
        LB[Load Balancer]
        WEB[Web Server]
        API_INST[API Instance]
        DB_PROD[Production Database]
        STATIC[Static File Server]
    end
    
    DEV --> GIT
    GIT --> BUILD
    BUILD --> TEST
    TEST --> PACK
    
    PACK --> LB
    LB --> WEB
    LB --> API_INST
    WEB --> STATIC
    API_INST --> DB_PROD
```

## Performance Monitoring Flow

```mermaid
graph LR
    subgraph "Application"
        API[Web API]
        BUI[Blazor UI]
        DB[(Database)]
    end
    
    subgraph "Monitoring"
        LOG[Application Logs]
        METRICS[Performance Metrics]
        HEALTH[Health Checks]
    end
    
    subgraph "Observability"
        DASH[Dashboard]
        ALERT[Alerting]
        TRACE[Distributed Tracing]
    end
    
    API --> LOG
    API --> METRICS
    API --> HEALTH
    BUI --> METRICS
    DB --> METRICS
    
    LOG --> DASH
    METRICS --> DASH
    HEALTH --> DASH
    
    DASH --> ALERT
    METRICS --> TRACE
```

## Error Handling Flow

```mermaid
flowchart TD
    REQ[Incoming Request] --> MW[Exception Middleware]
    MW --> CTRL[Controller Action]
    CTRL --> MED[MediatR Handler]
    
    MED --> {Exception?}
    
    {Exception?} -->|ValidationException| VE[Validation Error]
    {Exception?} -->|NotFoundException| NF[Not Found Error]
    {Exception?} -->|BadRequestException| BR[Bad Request Error]
    {Exception?} -->|General Exception| GE[Internal Server Error]
    {Exception?} -->|No Exception| SUCCESS[Success Response]
    
    VE --> FORMAT[Format Error Response]
    NF --> FORMAT
    BR --> FORMAT
    GE --> FORMAT
    
    FORMAT --> LOG[Log Error]
    LOG --> RESPONSE[Return Error Response]
    
    SUCCESS --> RESPONSE[Return Success Response]
    
    RESPONSE --> CLIENT[Client Application]
```