<!-- AIDA - JavaScript Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `let credit`, `obj.credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside JavaScript rules -->
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
- Event listeners without cleanup (addEventListener without removeEventListener)
- Intervals/timeouts without clearInterval/clearTimeout
- Promises without proper cleanup
- Memory leaks from closures retaining large objects
- Unclosed file streams/connections (Node.js)
- WebSocket connections not properly closed
- Global variable pollution
- Circular references causing memory leaks

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- Property access without null/undefined checks (`obj.property` without `obj && obj.property`)
- Array access without bounds checks (`arr[0]` without `arr && arr.length`)
- Function calls on potentially null/undefined objects
- Missing null/undefined guards
- try blocks without catch
- Promise rejections without .catch() or try/catch
- Async/await without proper error handling
- Network requests without error callbacks
- Missing input parameter validation
- Accessing properties on undefined variables

### 🚨 JAVASCRIPT ARCHITECTURE VIOLATIONS:
- Global scope pollution (variables declared without var/let/const)
- Missing strict mode ('use strict')
- Incorrect variable scoping (var vs let/const)
- Missing module pattern or proper exports/imports
- Improper this binding in callbacks
- Closure memory leaks
- Prototype pollution vulnerabilities
- Missing proper error boundaries

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded strings for configuration values
- Magic numbers without named constants
- == instead of === (loose equality)
- String comparisons without proper methods
- Repeated code blocks across files
- Missing centralized configuration
- Hardcoded URLs or API endpoints
- Business logic constants scattered in files
- Unused variables and functions
- Dead code (unreachable code blocks)
- Inconsistent naming conventions
- Missing comments for complex logic

### 🚨 PERFORMANCE VIOLATIONS:
- Inefficient array operations (nested loops, repeated finds)
- Missing optimization for expensive computations
- Synchronous operations blocking event loop (Node.js)
- Large object allocations in loops
- Inefficient regular expressions
- Memory-intensive string concatenation
- Missing lazy loading for large modules
- Blocking operations on main thread
- Heavy DOM manipulations without batching (browser)

### 🚨 ASYNC/PROMISE VIOLATIONS:
- Callback hell instead of Promises/async-await
- Promise constructor anti-pattern (unnecessary wrapping)
- Mixing callbacks with Promises
- Not returning promises from functions
- Race conditions in async code
- Missing Promise.all() for parallel operations
- Unhandled promise rejections
- Blocking async operations with synchronous calls

### 🚨 NODE.JS VIOLATIONS (if applicable):
- Missing error handling for file operations
- Unclosed database connections
- Memory leaks from event emitters
- process.exit() without cleanup
- Missing graceful shutdown handling
- Synchronous file operations on main thread
- Unbounded memory usage
- Missing environment variable validation
- Security vulnerabilities (prototype pollution, etc.)

### 🚨 BROWSER/CLIENT VIOLATIONS:
- Missing feature detection for browser APIs
- Memory leaks from DOM event listeners
- Inefficient CSS selector queries
- Missing viewport meta tag considerations
- localStorage usage without error handling
- Missing browser compatibility checks
- Improper window.postMessage usage
- Cross-origin issues without proper handling

### 🚨 ES6+ VIOLATIONS:
- Using var instead of let/const
- Missing arrow function optimizations
- Not using destructuring where appropriate
- Improper template literal usage
- Missing default parameters
- Not using spread operator for array operations
- Incorrect import/export statements
- Missing async/await for Promise handling

### 🚨 GENERAL JAVASCRIPT VIOLATIONS:
- console.log in production code
- debugger statements
- Global variable declarations without proper scope
- Variable hoisting issues
- Missing semicolons (if required by style guide)
- Type coercion issues (implicit conversions)
- Improper object/array comparisons