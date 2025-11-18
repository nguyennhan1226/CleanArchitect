<!-- AIDA - Angular Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
- **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `let credit`, `obj.credit = value`) - reserved for business logic
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside Angular rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets
- SQL injection vulnerabilities (dynamic SQL construction)
- XSS vulnerabilities (innerHTML without sanitization)
- Unsafe file operations, path traversal
- Authentication/authorization bypasses
- innerHTML with dynamic content
- HTTP instead of HTTPS endpoints
- No input validation/sanitization
- bypassSecurityTrust* without proper validation
- Missing CSRF protection
- Unsafe pipe implementations
- Direct DOM manipulation (ElementRef.nativeElement)

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- Observables without unsubscribe
- Event listeners without cleanup
- Timers without clearInterval/clearTimeout
- Missing takeUntil pattern for cleanup
- Subject memory leaks
- Memory leaks from unmanaged subscriptions
- Nested subscriptions (subscribe inside subscribe)

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- `.` access without null checks (`obj.property` without `obj?.property`)
- Array access without length checks (`arr[0]` without `arr?.length`)
- Function calls without existence checks
- `any` type usage without proper validation
- Missing null/undefined guards
- `try` blocks without `catch`
- Promise/Observable without error handling
- HTTP calls without error callbacks
- Missing error handling in operators
- Non-null assertion (`!`) without null checks

### 🚨 ANGULAR ARCHITECTURE VIOLATIONS:
- Components without OnDestroy
- Direct DOM manipulation
- Business logic in templates
- Large components (>300 lines)
- Missing ChangeDetectionStrategy.OnPush
- Heavy operations in lifecycle hooks
- Circular dependencies between modules
- Services not provided in root when singleton needed
- File naming conventions violations
- Component selector prefix missing
- Service suffix naming incorrect
- Module organization violations

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded strings for roles, error messages, or business values
- Magic numbers without named constants
- String comparisons without constants/enums
- Repeated string literals across files
- Missing centralized configuration for business values
- Hardcoded URLs or API endpoints
- Business logic constants scattered in components
- Unused imports in TypeScript files
- Unused variables and methods
- Unused injected services in constructor
- Dead code (unreachable code blocks)
- Unused component inputs/outputs
- Unused CSS classes and styles
- Redundant or duplicate code blocks

### 🚨 PERFORMANCE VIOLATIONS:
- Missing trackBy in *ngFor
- Function calls in template expressions
- Large bundle imports without lazy loading
- Synchronous operations in lifecycle hooks
- Heavy computations in getters
- Missing virtual scrolling for large lists
- Unnecessary change detection cycles
- Blocking operations on main thread
- Inline styles in templates

### 🚨 RXJS VIOLATIONS:
- Wrong operator choice (mergeMap vs switchMap vs concatMap)
- Not using async pipe in templates
- Cold vs hot observable misuse
- Subject exposed instead of Observable
- ShareReplay misuse without refCount

### 🚨 TYPESCRIPT/JAVASCRIPT VIOLATIONS:
- `console.log` in production code
- `debugger` statements
- `eval()` or `Function()` usage
- Global variables
- Magic numbers without constants
