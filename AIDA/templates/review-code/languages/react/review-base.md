<!-- AIDA - React Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `const credit`, `obj.credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `isSuccess` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside React rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets in code
- XSS vulnerabilities (dangerouslySetInnerHTML without sanitization)
- Unsafe href attributes (javascript: protocol)
- eval() or Function() constructor usage
- HTTP instead of HTTPS for sensitive data
- Missing input validation/sanitization
- Unescaped user input in JSX
- Missing CSRF protection in forms
- Insecure random number generation
- Direct DOM manipulation bypassing React
- Missing Content Security Policy considerations
- Unsafe external script loading

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- useEffect without cleanup function (missing return)
- Event listeners not removed in cleanup
- Timers/intervals without cleanup
- Subscriptions without unsubscription
- Memory leaks from closures in useCallback/useMemo
- WebSocket connections not properly closed
- Large state objects not properly cleared
- Infinite re-renders from dependency issues
- Component refs not properly cleaned up
- Third-party library instances not disposed

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- Property access without null/undefined checks (`obj.property` without `obj?.property`)
- Array access without bounds checks (`arr[0]` without `arr?.length`)
- Function calls on potentially null/undefined objects
- Missing null/undefined guards in JSX
- try blocks without catch in async operations
- Promise rejections without .catch() or try/catch
- API calls without error handling
- Missing error boundaries for component trees
- Unhandled async errors in useEffect
- Missing validation for props/state

### 🚨 REACT ARCHITECTURE VIOLATIONS:
- Direct state mutation (modifying state objects directly)
- Missing key props in list rendering
- Incorrect dependency arrays in useEffect/useMemo/useCallback
- Side effects in render function
- Blocking operations in render phase
- Missing React.memo for expensive components
- Improper use of useCallback/useMemo
- Component files larger than 300 lines
- Business logic mixed in presentation components
- Missing prop validation (PropTypes or TypeScript)

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Hardcoded strings for configuration values
- Magic numbers without named constants
- Inline styles instead of CSS classes/styled-components
- Repeated JSX patterns without component extraction
- Missing centralized error handling
- Hardcoded URLs or API endpoints
- Business logic scattered across components
- Unused imports and variables
- Dead code (unreachable code blocks)
- Inconsistent naming conventions
- Missing component documentation/comments

### 🚨 PERFORMANCE VIOLATIONS:
- Missing React.memo for pure components
- Incorrect useMemo/useCallback dependency arrays
- Heavy computations in render without useMemo
- Creating objects/functions in render
- Unnecessary re-renders from context updates
- Missing lazy loading for large components
- Large bundle sizes without code splitting
- Inefficient list rendering without virtualization
- Missing image optimization
- Blocking render with synchronous operations

### 🚨 HOOKS VIOLATIONS:
- Hooks called conditionally (if statements, loops)
- Hooks called outside functional components
- Custom hooks not following naming convention (use*)
- Missing dependency arrays in useEffect
- Infinite re-renders from incorrect dependencies
- useState with complex objects (should use useReducer)
- Multiple useState calls for related state
- useEffect for state synchronization instead of derived state
- Missing cleanup functions for subscriptions
- Overuse of useEffect for derived state

### 🚨 JSX/RENDERING VIOLATIONS:
- Missing key props in dynamic lists
- Using array index as key for dynamic lists
- dangerouslySetInnerHTML without sanitization
- Inline event handlers creating new functions on every render
- Missing accessibility attributes (aria-*, role)
- Non-semantic HTML usage
- Images without alt text
- Forms without proper labels
- Missing focus management
- Inconsistent conditional rendering patterns

### 🚨 STATE MANAGEMENT VIOLATIONS:
- Direct state mutation in Redux
- Missing action types as constants
- Side effects in reducers
- Large state objects in useState (should use useReducer)
- Global state for component-local data
- Missing state normalization for complex data
- Improper context usage for frequently changing data
- State updates not following immutability
- Missing state validation
- Prop drilling instead of proper state management

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
- Missing error boundary testing

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
- Poor color contrast
- Missing focus indicators
- Inaccessible modal/dialog implementations
- Missing screen reader support
- Improper heading hierarchy
- Missing skip links for navigation

### 🚨 GENERAL REACT VIOLATIONS:
- console.log in production code
- debugger statements
- Global variables in React context
- Component naming not following PascalCase
- Missing React import (for older React versions)
- Improper error boundary implementation
- Missing Suspense for lazy components
- Incorrect React version usage patterns