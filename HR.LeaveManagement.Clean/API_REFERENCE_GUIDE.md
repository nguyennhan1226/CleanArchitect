# HR Leave Management System - API Reference Guide

## Overview
This document provides comprehensive API documentation for the HR Leave Management System, including all available endpoints, request/response formats, and usage examples.

## Base Configuration
- **Base URL**: `https://localhost:7xxx/api` (Development)
- **Content-Type**: `application/json`
- **API Version**: v1.0
- **Framework**: ASP.NET Core Web API (.NET 9)

## Response Format Standards

### Success Response
```json
{
    "data": { ... },
    "message": "Operation completed successfully",
    "statusCode": 200
}
```

### Error Response
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "Bad Request",
    "status": 400,
    "detail": "Validation failed",
    "errors": {
        "fieldName": ["Error message 1", "Error message 2"]
    }
}
```

## Authentication (Future Implementation)
All endpoints will require JWT bearer token authentication in production:
```
Authorization: Bearer <JWT_TOKEN>
```

## Leave Types API

### Get All Leave Types
Retrieves a list of all available leave types.

**Endpoint**: `GET /api/leavetypes`

**Response**: `200 OK`
```json
[
    {
        "id": 1,
        "name": "Annual Leave",
        "defaultDays": 25
    },
    {
        "id": 2,
        "name": "Sick Leave",
        "defaultDays": 10
    }
]
```

### Get Leave Type by ID
Retrieves detailed information about a specific leave type.

**Endpoint**: `GET /api/leavetypes/{id}`

**Parameters**:
- `id` (path, integer, required): Leave type identifier

**Response**: `200 OK`
```json
{
    "id": 1,
    "name": "Annual Leave",
    "defaultDays": 25,
    "dateCreated": "2024-01-01T00:00:00Z",
    "dateModified": "2024-01-01T00:00:00Z"
}
```

**Error Responses**:
- `404 Not Found`: Leave type not found

### Create Leave Type
Creates a new leave type.

**Endpoint**: `POST /api/leavetypes`

**Request Body**:
```json
{
    "name": "Personal Leave",
    "defaultDays": 5
}
```

**Validation Rules**:
- `name`: Required, maximum 100 characters, must be unique
- `defaultDays`: Required, must be greater than 0, maximum 365

**Response**: `201 Created`
```json
{
    "id": 3,
    "message": "Leave type created successfully"
}
```

**Error Responses**:
- `400 Bad Request`: Validation errors
- `409 Conflict`: Leave type name already exists

### Update Leave Type
Updates an existing leave type.

**Endpoint**: `PUT /api/leavetypes/{id}`

**Parameters**:
- `id` (path, integer, required): Leave type identifier

**Request Body**:
```json
{
    "id": 1,
    "name": "Annual Leave (Updated)",
    "defaultDays": 30
}
```

**Response**: `204 No Content`

**Error Responses**:
- `400 Bad Request`: Validation errors
- `404 Not Found`: Leave type not found

### Delete Leave Type
Deletes a leave type (soft delete).

**Endpoint**: `DELETE /api/leavetypes/{id}`

**Parameters**:
- `id` (path, integer, required): Leave type identifier

**Response**: `204 No Content`

**Error Responses**:
- `404 Not Found`: Leave type not found
- `409 Conflict`: Leave type is in use and cannot be deleted

## Leave Requests API

### Get All Leave Requests
Retrieves all leave requests with optional filtering.

**Endpoint**: `GET /api/leaverequest`

**Query Parameters**:
- `employeeId` (optional): Filter by employee ID
- `status` (optional): Filter by status (pending, approved, rejected, cancelled)
- `startDate` (optional): Filter by start date range
- `endDate` (optional): Filter by end date range

**Response**: `200 OK`
```json
[
    {
        "id": 1,
        "startDate": "2024-02-01T00:00:00Z",
        "endDate": "2024-02-05T00:00:00Z",
        "leaveType": {
            "id": 1,
            "name": "Annual Leave",
            "defaultDays": 25
        },
        "dateRequested": "2024-01-15T10:30:00Z",
        "requestingEmployeeId": "EMP001",
        "approved": null
    }
]
```

### Get Leave Request by ID
Retrieves detailed information about a specific leave request.

**Endpoint**: `GET /api/leaverequest/{id}`

**Parameters**:
- `id` (path, integer, required): Leave request identifier

**Response**: `200 OK`
```json
{
    "id": 1,
    "startDate": "2024-02-01T00:00:00Z",
    "endDate": "2024-02-05T00:00:00Z",
    "leaveType": {
        "id": 1,
        "name": "Annual Leave",
        "defaultDays": 25
    },
    "leaveTypeId": 1,
    "dateRequested": "2024-01-15T10:30:00Z",
    "requestComments": "Family vacation to the mountains",
    "approved": null,
    "cancelled": false,
    "requestingEmployeeId": "EMP001"
}
```

### Create Leave Request
Submits a new leave request.

**Endpoint**: `POST /api/leaverequest`

**Request Body**:
```json
{
    "startDate": "2024-03-01T00:00:00Z",
    "endDate": "2024-03-05T00:00:00Z",
    "leaveTypeId": 1,
    "requestComments": "Annual family vacation"
}
```

**Validation Rules**:
- `startDate`: Required, must be future date
- `endDate`: Required, must be after start date
- `leaveTypeId`: Required, must exist
- `requestComments`: Optional, maximum 500 characters

**Response**: `201 Created`
```json
{
    "id": 2,
    "message": "Leave request submitted successfully"
}
```

**Error Responses**:
- `400 Bad Request`: Validation errors
- `409 Conflict`: Overlapping leave requests

### Update Leave Request
Updates an existing leave request (only allowed for pending requests).

**Endpoint**: `PUT /api/leaverequest/{id}`

**Request Body**:
```json
{
    "id": 1,
    "startDate": "2024-03-02T00:00:00Z",
    "endDate": "2024-03-06T00:00:00Z",
    "leaveTypeId": 1,
    "requestComments": "Extended family vacation"
}
```

**Response**: `204 No Content`

**Error Responses**:
- `400 Bad Request`: Validation errors or request already processed
- `404 Not Found`: Leave request not found

### Approve/Reject Leave Request
Changes the approval status of a leave request.

**Endpoint**: `PUT /api/leaverequest/approval/{id}`

**Request Body**:
```json
{
    "id": 1,
    "approved": true
}
```

**Response**: `204 No Content`

**Error Responses**:
- `404 Not Found`: Leave request not found
- `400 Bad Request`: Request already processed

### Cancel Leave Request
Cancels a leave request.

**Endpoint**: `PUT /api/leaverequest/cancel/{id}`

**Response**: `204 No Content`

**Error Responses**:
- `404 Not Found`: Leave request not found
- `400 Bad Request`: Request cannot be cancelled

### Delete Leave Request
Deletes a leave request (hard delete, admin only).

**Endpoint**: `DELETE /api/leaverequest/{id}`

**Response**: `204 No Content`

## Leave Allocations API

### Get All Leave Allocations
Retrieves all leave allocations with optional filtering.

**Endpoint**: `GET /api/leaveallocation`

**Query Parameters**:
- `employeeId` (optional): Filter by employee ID
- `period` (optional): Filter by period (year)
- `leaveTypeId` (optional): Filter by leave type

**Response**: `200 OK`
```json
[
    {
        "id": 1,
        "numberOfDays": 25,
        "leaveType": {
            "id": 1,
            "name": "Annual Leave",
            "defaultDays": 25
        },
        "leaveTypeId": 1,
        "period": 2024
    }
]
```

### Get Leave Allocation by ID
Retrieves detailed information about a specific leave allocation.

**Endpoint**: `GET /api/leaveallocation/{id}`

**Response**: `200 OK`
```json
{
    "id": 1,
    "numberOfDays": 25,
    "leaveType": {
        "id": 1,
        "name": "Annual Leave",
        "defaultDays": 25
    },
    "leaveTypeId": 1,
    "period": 2024,
    "employeeId": "EMP001"
}
```

### Create Leave Allocation
Creates a new leave allocation for an employee.

**Endpoint**: `POST /api/leaveallocation`

**Request Body**:
```json
{
    "numberOfDays": 25,
    "leaveTypeId": 1,
    "period": 2024,
    "employeeId": "EMP001"
}
```

**Validation Rules**:
- `numberOfDays`: Required, must be greater than 0
- `leaveTypeId`: Required, must exist
- `period`: Required, valid year
- `employeeId`: Required

**Response**: `201 Created`

**Error Responses**:
- `400 Bad Request`: Validation errors
- `409 Conflict`: Allocation already exists for employee/period/leave type

### Update Leave Allocation
Updates an existing leave allocation.

**Endpoint**: `PUT /api/leaveallocation/{id}`

**Request Body**:
```json
{
    "id": 1,
    "numberOfDays": 30,
    "leaveTypeId": 1,
    "period": 2024
}
```

**Response**: `204 No Content`

### Delete Leave Allocation
Deletes a leave allocation.

**Endpoint**: `DELETE /api/leaveallocation/{id}`

**Response**: `204 No Content`

## Error Codes Reference

| Status Code | Description | Common Causes |
|-------------|-------------|---------------|
| 200 | OK | Successful GET request |
| 201 | Created | Successful POST request |
| 204 | No Content | Successful PUT/DELETE request |
| 400 | Bad Request | Validation errors, invalid input |
| 401 | Unauthorized | Missing or invalid authentication |
| 403 | Forbidden | Insufficient permissions |
| 404 | Not Found | Resource not found |
| 409 | Conflict | Resource already exists, business rule violation |
| 500 | Internal Server Error | Unexpected server error |

## Rate Limiting (Future Implementation)
- **Limit**: 1000 requests per hour per user
- **Headers**: 
  - `X-RateLimit-Limit`: Request limit
  - `X-RateLimit-Remaining`: Requests remaining
  - `X-RateLimit-Reset`: Reset timestamp

## Pagination (Future Implementation)
For endpoints returning large datasets:

**Query Parameters**:
- `page`: Page number (default: 1)
- `pageSize`: Items per page (default: 10, max: 100)

**Response Headers**:
- `X-Pagination-TotalCount`: Total number of items
- `X-Pagination-PageCount`: Total number of pages
- `X-Pagination-CurrentPage`: Current page number

## WebHooks (Future Implementation)
Event-driven notifications for leave request status changes:

**Events**:
- `leave_request.created`
- `leave_request.approved`
- `leave_request.rejected`
- `leave_request.cancelled`

**Payload Example**:
```json
{
    "event": "leave_request.approved",
    "timestamp": "2024-01-15T10:30:00Z",
    "data": {
        "leaveRequestId": 123,
        "employeeId": "EMP001",
        "approvedBy": "MGR001"
    }
}
```

## SDK and Client Libraries (Future)
- **C# SDK**: NuGet package for .NET applications
- **JavaScript SDK**: NPM package for web applications
- **Postman Collection**: Complete API collection for testing

## Testing Endpoints
Use the following test data for API testing:

### Test Leave Types
```json
[
    {"name": "Annual Leave", "defaultDays": 25},
    {"name": "Sick Leave", "defaultDays": 10},
    {"name": "Personal Leave", "defaultDays": 5}
]
```

### Test Employees
- EMP001, EMP002, EMP003
- MGR001 (Manager)
- HR001 (HR Admin)

This API reference provides all necessary information for integrating with the HR Leave Management System API.