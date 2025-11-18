<!-- AIDA - TypeScript Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `let credit`, `obj.credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside TypeScript rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets in code
- SQL injection vulnerabilities (dynamic query construction)
- XSS vulnerabilities (innerHTML without sanitization)
- Unsafe file operations, path traversal
- Authentication/authorization bypasses
- eval() or Function() constructor usage
- HTTP instead of HTTPS endpoints
- No input validation/sanitization
- Unsafe HTML rendering without sanitization
- Missing CSRF protection
- Weak cryptographic implementations
- Direct DOM manipulation without validation

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- Event listeners without cleanup
- Intervals/timeouts without clearInterval/clearTimeout
- Promises without proper cleanup
- Memory leaks from closures
- Unclosed file streams/connections
- WebSocket connections not properly closed
- Observable subscriptions without unsubscription
- Service worker registrations without cleanup

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- Property access without null/undefined checks (`obj.property` without `obj?.property`)
- Array access without bounds checks (`arr[0]` without `arr?.length`)
- Function calls on potentially null/undefined objects
- Missing null/undefined guards
- try blocks without catch
- Promise rejections without .catch() or try/catch
- Async/await without proper error handling
- Network requests without error callbacks
- Missing input parameter validation
- Non-null assertion (!) without proper validation

### 🚨 TYPESCRIPT ARCHITECTURE VIOLATIONS:
- Using `any` type extensively without justification
- Missing type definitions for function parameters/returns
- Incorrect generic type constraints
- Interface vs type usage inconsistencies
- Missing readonly modifiers for immutable data
- Circular type dependencies
- Improper union/intersection type usage
- Missing strict null checks compliance
- Explicit any casting without validation

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded strings for configuration values
- Magic numbers without named constants
- String comparisons without proper methods
- Repeated string literals across files
- Missing centralized configuration
- Hardcoded URLs or API endpoints
- Business logic constants scattered in files
- Unused imports and variables
- Dead code (unreachable code blocks)
- Inconsistent naming conventions (camelCase/PascalCase)
- Missing JSDoc for public APIs

### 🚨 PERFORMANCE VIOLATIONS:
- Inefficient array operations (nested loops, repeated finds)
- Missing memoization for expensive computations
- Synchronous operations blocking event loop
- Large object allocations in loops
- Inefficient regular expressions
- Memory-intensive string concatenation
- Missing lazy loading for large modules
- Blocking operations on main thread
- Heavy DOM manipulations without batching

### 🚨 ASYNC/PROMISE VIOLATIONS:
- Missing await keywords for Promise-returning functions
- Promise constructor anti-pattern (unnecessary wrapping)
- Mixing callbacks with Promises/async-await
- Promise chains that could use async/await
- Not returning promises from functions
- Race conditions in async code
- Missing Promise.all() for parallel operations
- Unhandled promise rejections

### 🚨 NODE.JS VIOLATIONS (if applicable):
- Missing error handling for file operations
- Unclosed database connections
- Memory leaks from event emitters
- Process.exit() without cleanup
- Missing graceful shutdown handling
- Synchronous file operations on main thread
- Unbounded memory usage
- Missing environment variable validation

### 🚨 BROWSER/CLIENT VIOLATIONS:
- Missing feature detection for browser APIs
- Memory leaks from DOM event listeners
- Inefficient CSS selector queries
- Missing viewport meta tag considerations
- Local storage usage without error handling
- Missing browser compatibility checks
- Improper window.postMessage usage

### 🚨 TYPESCRIPT/JAVASCRIPT VIOLATIONS:
- console.log in production code
- debugger statements
- Global variable declarations
- == instead of === comparisons
- Missing semicolons (if required by style guide)
- Improper this binding in callbacks
- Variable hoisting issues