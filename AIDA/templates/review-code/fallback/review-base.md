```markdown
<!-- AIDA - General Review Base Template (Fallback) -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
- **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `let credit`, `obj.credit = value`) - reserved for business logic
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside general rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets
- SQL injection vulnerabilities (dynamic SQL construction)
- XSS vulnerabilities (unescaped user input)
- Unsafe file operations, path traversal
- Authentication/authorization bypasses
- Unsafe dynamic content rendering
- HTTP instead of HTTPS endpoints
- No input validation/sanitization
- Unsafe third-party library usage
- Missing CSRF protection
- Direct system command execution
- Unsafe deserialization

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- Database connections without cleanup
- File handles without proper closure
- Event listeners without cleanup
- Timers without cleanup
- Memory leaks from unmanaged objects
- Resource-intensive operations without disposal
- Infinite loops or recursion
- Large object allocations without cleanup

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- `.` access without null checks (`obj.property` without null guards)
- Array access without bounds checking
- Function calls without existence validation
- Untyped variables without proper validation
- Missing null/undefined guards
- `try` blocks without `catch`
- Promise/async operations without error handling
- Network calls without error callbacks
- Missing error handling in critical paths
- Silent error swallowing
- No error logging or monitoring

### 🚨 CODE ARCHITECTURE VIOLATIONS:
- Missing separation of concerns
- Business logic mixed with presentation
- Large functions/classes (>500 lines)
- Tight coupling between components
- Circular dependencies
- Missing abstraction layers
- Violation of SOLID principles
- Inappropriate design patterns usage
- Poor module organization
- Missing interface definitions

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded strings for configuration or business values
- Magic numbers without named constants
- String comparisons without constants/enums
- Repeated code blocks (DRY violations)
- Missing centralized configuration
- Hardcoded URLs or endpoints
- Business logic constants scattered across files
- Unused imports, variables, and functions
- Dead code (unreachable code blocks)
- Inconsistent naming conventions
- Redundant or duplicate code blocks
- Missing documentation for complex logic

### 🚨 PERFORMANCE VIOLATIONS:
- Inefficient algorithms or data structures
- Unnecessary loops or iterations
- Missing caching mechanisms
- Synchronous operations blocking execution
- Heavy computations in frequently called methods
- Unnecessary data fetching or processing
- Missing pagination for large datasets
- Resource-intensive operations on main thread
- Inefficient database queries
- Missing optimization for frequently used operations

### 🚨 DATA HANDLING VIOLATIONS:
- Missing data validation
- Unsafe data transformations
- No data sanitization
- Missing data encryption for sensitive information
- Improper data storage practices
- No data backup or recovery mechanisms
- Missing audit trails for critical operations
- Inadequate data access controls

### 🚨 GENERAL PROGRAMMING VIOLATIONS:
- `console.log` or debug statements in production code
- `debugger` statements
- Global variables usage
- Magic numbers without constants
- Hardcoded environment-specific values
- Missing proper logging mechanisms
- No proper configuration management
- Violation of coding standards and conventions

```