<!-- AIDA - Vue Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `const credit`, `data.credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside Vue rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets in code
- XSS vulnerabilities (v-html without sanitization)
- Unsafe href attributes (javascript: protocol)
- eval() or Function() constructor usage
- HTTP instead of HTTPS for sensitive data
- Missing input validation/sanitization
- Unescaped user input in templates
- Missing CSRF protection in forms
- Insecure random number generation
- Direct DOM manipulation bypassing Vue
- Missing Content Security Policy considerations
- Unsafe external script loading in templates

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- Event listeners not removed in beforeDestroy/beforeUnmount
- Timers/intervals without cleanup
- Subscriptions without unsubscription
- Memory leaks from closures in watchers
- WebSocket connections not properly closed
- Large reactive data objects not properly cleared
- Infinite reactivity loops from watchers
- Component refs not properly cleaned up
- Third-party library instances not disposed
- Global event listeners not removed

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- Property access without null/undefined checks in templates
- Array access without bounds checks in v-for
- Function calls on potentially null/undefined objects
- Missing null/undefined guards in computed properties
- try blocks without catch in async operations
- Promise rejections without .catch() or try/catch
- API calls without error handling
- Missing error handling in async data fetching
- Unhandled async errors in lifecycle hooks
- Missing validation for props/data

### 🚨 VUE ARCHITECTURE VIOLATIONS:
- Direct mutation of props (props should be immutable)
- Missing key attributes in v-for loops
- Side effects in computed properties
- Blocking operations in render/template evaluation
- Business logic mixed in presentation components
- Component files larger than 400 lines
- Missing prop validation or incorrect prop types
- Improper use of refs vs reactive data
- Global component registration in production
- Missing component name for debugging

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded strings for configuration values
- Magic numbers without named constants
- Inline styles instead of CSS classes/modules
- Repeated template patterns without component extraction
- Missing centralized error handling
- Hardcoded URLs or API endpoints
- Business logic scattered across components
- Unused imports and variables
- Dead code (unreachable code blocks)
- Inconsistent naming conventions
- Missing component documentation/comments

### 🚨 PERFORMANCE VIOLATIONS:
- Missing v-memo for expensive list rendering (Vue 3)
- Heavy computations in templates without computed properties
- Creating objects/functions in template expressions
- Unnecessary reactivity for large datasets
- Missing lazy loading for large components
- Large bundle sizes without code splitting
- Inefficient list rendering without v-memo/track-by
- Missing image optimization
- Blocking render with synchronous operations
- Not using shallowRef/shallowReactive when appropriate

### 🚨 REACTIVITY VIOLATIONS:
- Direct array index assignment in Vue 2
- Object property addition without $set in Vue 2
- Mutating props instead of emitting events
- Incorrect use of reactive vs ref in Vue 3
- Missing deep watching for nested objects
- Watchers without proper cleanup
- Infinite loops in reactive dependencies
- Using non-reactive data where reactivity is needed
- Memory leaks from uncleaned watchers
- Improper use of nextTick

### 🚨 TEMPLATE VIOLATIONS:
- Missing key attributes in v-for loops
- Using array index as key in dynamic lists
- v-html without proper sanitization
- Inline event handlers with complex logic
- Missing accessibility attributes (aria-*, role)
- Non-semantic HTML usage
- Images without alt text
- Forms without proper labels
- Missing focus management
- Inconsistent conditional rendering patterns

### 🚨 COMPOSITION API VIOLATIONS (Vue 3):
- Using Options API and Composition API inconsistently
- Not properly destructuring reactive objects
- Missing onUnmounted cleanup functions
- Incorrect use of reactive vs ref
- Watchers not properly cleaned up
- Using computed without return value
- Side effects in setup function without lifecycle hooks
- Not using provide/inject properly for dependency injection
- Missing proper TypeScript integration with Composition API
- Improper use of toRefs/toRef

### 🚨 VUEX/PINIA VIOLATIONS:
- Direct state mutation in components
- Missing action types as constants
- Side effects in mutations
- Async operations in mutations (should be in actions)
- Large state objects without proper normalization
- Missing state validation
- Not using getters for derived state
- Improper module organization
- State updates not following immutability
- Missing error handling in actions

### 🚨 ROUTING VIOLATIONS:
- Missing route guards for protected routes
- Hardcoded route paths in components
- Missing error handling for route navigation
- Not using router.push for programmatic navigation
- Missing route meta information for permissions
- Route parameters without validation
- Missing loading states during route transitions
- Improper use of router-link vs programmatic navigation
- Route components without proper lifecycle management
- Missing scroll restoration configuration

### 🚨 TESTING VIOLATIONS:
- Components not testable (tightly coupled)
- Missing data-testid attributes for testing
- Tests with external dependencies (not mocked)
- Missing test coverage for user interactions
- Tests without proper assertions
- Hardcoded values in tests
- Missing accessibility testing
- Components without unit tests
- Integration tests without proper setup/teardown
- Missing Vue Test Utils best practices

### 🚨 BUILD/DEPLOYMENT VIOLATIONS:
- Missing environment variable configuration
- Hardcoded API URLs in production builds
- Missing production optimizations
- Large bundle sizes without analysis
- Missing PWA configurations where appropriate
- Development dependencies in production bundle
- Missing proper error tracking setup
- Insecure environment variable exposure
- Missing proper routing for SPA deployment
- Development code in production builds

### 🚨 ACCESSIBILITY VIOLATIONS:
- Missing alt text for images
- Forms without proper labels
- Interactive elements without keyboard support
- Missing ARIA attributes
- Poor color contrast in component styles
- Missing focus indicators
- Inaccessible modal/dialog implementations
- Missing screen reader support
- Improper heading hierarchy
- Missing skip links for navigation

### 🚨 GENERAL VUE VIOLATIONS:
- console.log in production code
- debugger statements
- Global variables in Vue context
- Component naming not following PascalCase
- Missing Vue import where required
- Improper error boundary implementation
- Missing Suspense for async components
- Incorrect Vue version usage patterns
- Missing proper TypeScript integration
- Not following Vue style guide conventions