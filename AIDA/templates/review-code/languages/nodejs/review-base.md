<!-- AIDA - Node.js Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `let credit`, `obj.credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside Node.js rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets in code
- SQL injection vulnerabilities (dynamic query construction)
- Command injection (child_process with user input)
- Path traversal vulnerabilities (unsafe file operations)
- Unvalidated user input in database queries
- eval() or Function() constructor usage
- HTTP instead of HTTPS for sensitive data
- Missing input validation/sanitization
- Unsafe deserialization (JSON.parse without validation)
- Missing rate limiting on endpoints
- Insecure session management
- Missing CORS configuration or wildcard origins

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- HTTP/HTTPS connections not properly closed
- Database connections without connection pooling/closing
- File streams not closed (missing .end(), .close())
- Event emitters without removing listeners
- Timers without clearInterval/clearTimeout
- Memory leaks from unclosed resources
- Large files loaded entirely into memory
- Circular references in objects
- Global variables accumulating data
- Worker threads not properly terminated

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- Callback functions without error handling (err parameter ignored)
- Promise rejections without .catch() or try/catch
- Async/await without proper error handling
- Missing null/undefined checks before property access
- Database operations without error handling
- File operations without error callbacks
- Network requests without timeout handling
- Missing validation for required environment variables
- Uncaught exceptions not handled (process.on('uncaughtException'))
- Unhandled promise rejections

### 🚨 NODE.JS ARCHITECTURE VIOLATIONS:
- Blocking synchronous operations on main thread (fs.readFileSync)
- Missing graceful shutdown handling
- process.exit() without cleanup
- Heavy CPU operations blocking event loop
- Large payload processing without streaming
- Missing middleware error handling in Express
- Improper use of clusters/worker processes
- Missing health check endpoints
- Inadequate logging and monitoring
- Tight coupling between modules

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded configuration values (ports, URLs, credentials)
- Magic numbers without named constants
- Missing environment variable validation
- Repeated code blocks across modules
- Missing centralized error handling
- Hardcoded file paths
- Business logic mixed with route handlers
- Unused dependencies in package.json
- Missing input validation middleware
- Inconsistent naming conventions

### 🚨 PERFORMANCE VIOLATIONS:
- Synchronous file operations (fs.readFileSync, fs.writeFileSync)
- Missing caching for expensive operations
- Inefficient database queries (N+1 problem)
- Large JSON payloads without streaming
- Missing compression middleware
- CPU-intensive operations on main thread
- Memory-intensive operations without limits
- Missing connection pooling for databases
- Blocking operations in request handlers
- Large dependencies loaded unnecessarily

### 🚨 EXPRESS.JS VIOLATIONS (if applicable):
- Missing helmet.js security headers
- Routes without error handling middleware
- Missing request validation middleware
- Insecure cookie settings
- Missing CSRF protection
- Routes without proper authentication
- Missing request size limits
- Improper middleware order
- Missing request logging/monitoring
- Trust proxy settings misconfigured

### 🚨 DATABASE VIOLATIONS:
- SQL queries without parameterized statements
- Database connections not pooled
- Missing transaction handling for critical operations
- Database credentials hardcoded
- Missing database connection error handling
- Queries without proper indexing considerations
- Missing data validation before database operations
- Long-running queries without timeouts
- Missing database migration handling
- Connections not properly closed

### 🚨 ASYNC/PROMISE VIOLATIONS:
- Mixing callbacks with Promises/async-await
- Missing await keywords for async operations
- Promise constructor anti-pattern
- Not returning promises from functions
- Race conditions in async code
- Missing Promise.all() for parallel operations
- Callback hell instead of async/await
- Blocking async operations with synchronous calls
- Missing error handling in promise chains

### 🚨 NPM/DEPENDENCY VIOLATIONS:
- Using packages with known security vulnerabilities
- Unused dependencies in package.json
- Missing package-lock.json or yarn.lock
- Using deprecated packages
- Wildcard version ranges in dependencies
- Missing dependency security audits
- Large bundle sizes from unnecessary dependencies
- Development dependencies in production
- Missing peer dependency declarations

### 🚨 GENERAL NODE.JS VIOLATIONS:
- console.log in production code (use proper logging)
- Missing proper logging framework (winston, bunyan)
- process.env access without defaults
- Missing cluster mode for production
- Inadequate monitoring and health checks
- Missing process signal handling
- Global error handlers not implemented
- Missing request correlation IDs