<!-- AIDA - C# Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `var credit`, `obj.Credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `IsSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside C# rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets in code
- SQL injection vulnerabilities (concatenated SQL strings)
- XSS vulnerabilities (unescaped HTML output)
- Unsafe file operations, path traversal
- Authentication/authorization bypasses
- Deserializing untrusted data without validation
- HTTP instead of HTTPS endpoints
- No input validation/sanitization
- Unvalidated redirects and forwards
- Missing CSRF protection
- Weak cryptographic implementations
- Directory traversal vulnerabilities

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- IDisposable not disposed (missing using statements)
- Event handlers without unsubscription
- Timers without disposal
- File/stream handles not closed
- Database connections not properly closed
- Memory leaks from event subscriptions
- Tasks without proper cancellation tokens
- Large object heap pressure

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- Null reference access without checks (`obj.Property` without null check)
- Array/collection access without bounds checks
- Method calls on potentially null objects
- Missing null-conditional operators (?. and ?[])
- try blocks without catch or finally
- Exceptions swallowed without logging
- Async methods without proper error handling
- Database operations without transaction handling
- Network calls without timeout/retry logic
- Missing argument validation in public methods

### 🚨 .NET ARCHITECTURE VIOLATIONS:
- Controllers with business logic (fat controllers)
- Direct database access from controllers
- Circular dependencies between layers
- Static classes with state
- God objects (classes with too many responsibilities)
- Tight coupling between layers
- Missing dependency injection usage
- Improper async/await usage
- Blocking calls in async methods
- ConfigureAwait(false) misuse in libraries

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded strings for configuration values
- Magic numbers without named constants
- String comparisons without StringComparison
- Repeated string literals across files
- Missing centralized configuration
- Hardcoded URLs or connection strings
- Business logic constants scattered in controllers
- Unused using statements
- Unused variables and methods
- Dead code (unreachable code blocks)
- Improper naming conventions (PascalCase/camelCase)
- Missing XML documentation for public APIs

### 🚨 PERFORMANCE VIOLATIONS:
- StringBuilder not used for string concatenation in loops
- LINQ queries that could be optimized
- Synchronous calls in async contexts
- Heavy operations on UI thread
- Inefficient database queries (N+1 problem)
- Boxing/unboxing in performance-critical code
- Reflection usage without caching
- Large objects allocated frequently
- Missing async/await for I/O operations

### 🚨 ENTITY FRAMEWORK VIOLATIONS:
- Queries without AsNoTracking for read-only operations
- Missing Include for navigation properties
- Cartesian explosion in queries
- DbContext not disposed properly
- Lazy loading in loops
- Missing query filters
- Synchronous operations (ToList() instead of ToListAsync())

### 🚨 ASP.NET CORE VIOLATIONS:
- Controllers not using dependency injection
- Missing model validation attributes
- ActionResult without proper status codes
- Missing authorization attributes
- Improper exception handling middleware
- Missing CORS configuration
- Insecure cookie settings
- Missing request validation

### 🚨 C# LANGUAGE VIOLATIONS:
- Console.WriteLine in production code
- Debug.WriteLine without conditional compilation
- Environment.Exit() usage
- GC.Collect() calls
- Thread.Sleep() in async code
- Raw Task.Result usage (deadlock potential)