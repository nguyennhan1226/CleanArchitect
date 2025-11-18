<!-- AIDA - Go Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `credit := value`, `obj.Credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside Go rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets in code
- SQL injection vulnerabilities (string concatenation in SQL queries)
- Command injection (exec.Command with user input)
- Path traversal vulnerabilities (unsafe file operations)
- Unsafe deserialization of untrusted data
- Missing input validation/sanitization
- HTTP instead of HTTPS for sensitive data
- Weak random number generation (math/rand instead of crypto/rand)
- Missing authentication/authorization checks
- Unsafe reflection usage
- Directory traversal in file operations
- Missing rate limiting on HTTP endpoints

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- File handles not closed (missing defer file.Close())
- HTTP response bodies not closed (missing defer resp.Body.Close())
- Database connections not properly closed
- Goroutine leaks (goroutines that never terminate)
- Channel resource leaks (unclosed channels)
- Context not properly cancelled
- Missing mutex unlocks (missing defer mu.Unlock())
- Memory leaks from infinite loops
- Large slices/maps accumulating data without bounds
- Timer/Ticker not stopped properly

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- Ignoring errors (using _ = err)
- Panic usage instead of proper error handling
- Missing error checks for critical operations
- Interface{} type assertions without checking
- Pointer dereference without nil checks
- Map access without checking if key exists
- Channel operations without proper error handling
- Missing validation for function parameters
- Network operations without timeout
- File operations without error handling

### 🚨 GO ARCHITECTURE VIOLATIONS:
- Global variables for mutable state
- Missing go.mod file for dependency management
- Circular dependencies between packages
- God structs with too many responsibilities
- Missing interfaces for testability
- Improper use of init() functions
- Package naming not following Go conventions
- Missing proper package documentation
- Tight coupling between packages
- Business logic mixed with HTTP handlers

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Magic numbers without named constants
- Hardcoded strings for configuration values
- Missing comments for exported functions/types
- Non-Go naming conventions (not camelCase/PascalCase)
- Functions longer than 50 lines
- Missing error wrapping with context
- Repeated code blocks across functions
- Missing centralized configuration management
- Hardcoded file paths or URLs
- Business logic mixed with presentation logic

### 🚨 PERFORMANCE VIOLATIONS:
- String concatenation in loops (use strings.Builder)
- Inefficient slice operations (repeated append without capacity)
- Missing slice capacity hints for known sizes
- Goroutines created without proper synchronization
- Missing buffered channels where appropriate
- Inefficient JSON marshaling/unmarshaling
- Using reflection in hot paths
- Memory allocation in tight loops
- Missing connection pooling for databases/HTTP
- Blocking operations without timeout

### 🚨 GOROUTINE/CONCURRENCY VIOLATIONS:
- Race conditions in concurrent access
- Goroutines without proper synchronization
- Shared memory access without mutexes
- Channel operations that can deadlock
- Missing context cancellation in goroutines
- Goroutine leaks from infinite loops
- WaitGroup used incorrectly
- Missing proper error handling in goroutines
- Data races detected by race detector
- Improper use of sync.Once

### 🚨 HTTP/WEB VIOLATIONS:
- Missing CORS configuration
- HTTP handlers without error handling
- Missing request timeouts
- Insecure cookie settings
- Missing CSRF protection
- HTTP handlers without proper status codes
- Missing input validation in handlers
- Large request bodies without size limits
- Missing proper logging/monitoring
- HTTP clients without timeouts

### 🚨 DATABASE VIOLATIONS:
- SQL queries without parameterization
- Missing database connection error handling
- Database operations without transactions where needed
- Missing database connection pooling
- Queries susceptible to injection attacks
- Missing proper indexing considerations
- Long-running queries without timeouts
- Database connections not properly closed
- Missing database migration handling
- Missing data validation before database operations

### 🚨 TESTING VIOLATIONS:
- Missing unit tests for critical functions
- Tests without proper assertions
- Tests with external dependencies (not mocked)
- Missing test coverage for edge cases
- Tests that don't clean up after themselves
- Hardcoded values in tests
- Missing table-driven tests where appropriate
- Tests without proper setup/teardown
- Missing benchmark tests for performance-critical code
- Tests that don't use testify or similar frameworks

### 🚨 PACKAGE/DEPENDENCY VIOLATIONS:
- Missing go.mod file
- Using deprecated packages
- Packages with known security vulnerabilities
- Missing version constraints for dependencies
- Unused imports
- Circular import dependencies
- Missing go.sum file
- Incorrect module paths
- Development dependencies in production
- Missing dependency security audits

### 🚨 GENERAL GO VIOLATIONS:
- fmt.Print/Printf in production code (use proper logging)
- Missing proper logging framework (logrus, zap)
- Using panic() for error handling
- Missing proper error types/wrapping
- Incorrect use of pointers vs values
- Missing proper struct tags for JSON/DB
- Improper use of embedding
- Missing proper interface definitions
- Incorrect receiver types (pointer vs value)
- Not following Go code review comments guidelines