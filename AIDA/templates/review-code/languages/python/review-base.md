<!-- AIDA - Python Review Base Template -->
<!-- PLACEHOLDER: {{REVIEW_BASE}} -->

## 🔥 MANDATORY PROJECT RULES - MUST CHECK FIRST:
<!-- - **🚫 CRITICAL**: Never use `credit` as variable/property name (e.g., `credit = value`, `obj.credit = value`) - reserved for business logic -->
<!-- - **🚫 CRITICAL**: Never use `is_success` as variable name - reserved for business logic -->
<!-- ADD PROJECT-SPECIFIC RULES HERE - These will be checked alongside Python rules -->
<!-- Additional project rules can be added here:
-->

### 🚨 SECURITY VIOLATIONS:
- Hardcoded passwords, API keys, tokens, secrets in code
- SQL injection vulnerabilities (string concatenation in SQL queries)
- Command injection (os.system, subprocess with shell=True and user input)
- Path traversal vulnerabilities (unsafe file operations)
- Use of eval(), exec(), compile() with user input
- Pickle/unpickle with untrusted data
- HTTP instead of HTTPS for sensitive data
- Missing input validation/sanitization
- Unsafe deserialization (json.loads without validation)
- Missing authentication/authorization checks
- Weak random number generation (random instead of secrets)
- Missing rate limiting on API endpoints

### 🚨 RESOURCE LEAKS & MEMORY VIOLATIONS:
- File handles not closed (missing with statement or .close())
- Database connections not properly closed
- Network connections without proper cleanup
- Large files loaded entirely into memory
- Memory leaks from circular references
- Unclosed resources in exception scenarios
- Missing context managers for resource management
- Thread/process pools not properly shutdown
- Large data structures accumulating in memory
- Generator expressions not properly consumed

### 🚨 NULL SAFETY & ERROR HANDLING VIOLATIONS:
- AttributeError from None access (obj.attribute without None check)
- KeyError from dictionary access without checking key existence
- IndexError from list/tuple access without bounds checking
- Missing try/except blocks for error-prone operations
- Bare except clauses (except: instead of specific exceptions)
- File operations without error handling
- Network requests without timeout/retry logic
- Database operations without exception handling
- Missing validation for function parameters
- Silent exception catching without logging

### 🚨 PYTHON ARCHITECTURE VIOLATIONS:
- Global variables for mutable state
- Missing virtual environment usage
- Circular imports between modules
- God classes with too many responsibilities
- Missing __init__.py files in packages
- Improper use of class vs instance methods
- Missing abstract base classes where appropriate
- Tight coupling between modules
- Missing proper package structure
- Mixing different concerns in single module

### 🚨 CODE QUALITY & MAINTAINABILITY VIOLATIONS:
- Magic numbers without named constants
- Hardcoded strings for configuration values
- Missing docstrings for functions/classes
- Non-PEP8 compliant naming (camelCase instead of snake_case)
- Lines longer than 79/88 characters (PEP8 violation)
- Missing type hints for function parameters/returns
- Repeated code blocks across functions/modules
- Missing centralized configuration management
- Hardcoded file paths or URLs
- Business logic mixed with presentation logic

### 🚨 PERFORMANCE VIOLATIONS:
- Using + for string concatenation in loops (use join())
- Inefficient list comprehensions or loops
- Missing list comprehensions where appropriate
- Using list() when generator would suffice
- Inefficient dictionary/set operations
- Missing caching for expensive operations
- Synchronous operations where async would be better
- Large dataset operations without chunking
- Inefficient regular expressions
- Missing optimization for hot code paths

### 🚨 DJANGO/FLASK VIOLATIONS (if applicable):
- Missing CSRF protection in forms
- SQL queries without using ORM parameterization
- Missing input validation in views
- Hardcoded secret keys
- Missing proper error handling in views
- Templates without proper escaping
- Missing authentication decorators
- Insecure cookie settings
- Missing proper logging configuration
- Views without proper HTTP method restrictions

### 🚨 DATABASE VIOLATIONS:
- Raw SQL queries without parameterization
- Missing database connection error handling
- Database operations without transactions
- Missing database connection pooling
- Queries susceptible to injection attacks
- Missing proper indexing considerations
- Long-running operations without timeouts
- Missing database migration handling
- Connections not properly closed
- Missing data validation before database operations

### 🚨 ASYNC/CONCURRENCY VIOLATIONS:
- Blocking operations in async functions
- Missing await keywords for coroutines
- Race conditions in concurrent code
- Improper use of threading/multiprocessing
- Missing proper synchronization (locks, semaphores)
- Deadlock potential in concurrent code
- Not using async libraries for I/O operations
- Missing error handling in async contexts
- Improper exception handling in threads
- Resource sharing without proper protection

### 🚨 TESTING VIOLATIONS:
- Missing unit tests for critical functions
- Tests without proper assertions
- Tests with external dependencies (not mocked)
- Missing test coverage for edge cases
- Tests that don't clean up after themselves
- Hardcoded values in tests
- Missing integration tests for API endpoints
- Tests without proper setup/teardown
- Flaky tests that depend on timing
- Missing parameterized tests where appropriate

### 🚨 PACKAGING/DEPENDENCY VIOLATIONS:
- Missing requirements.txt or pyproject.toml
- Using deprecated packages
- Packages with known security vulnerabilities
- Missing version pinning for dependencies
- Unused imports and dependencies
- Missing virtual environment for development
- Incorrect package structure
- Missing setup.py or pyproject.toml for distribution
- Development dependencies in production requirements
- Missing dependency security audits

### 🚨 GENERAL PYTHON VIOLATIONS:
- print() statements in production code (use logging)
- Missing logging configuration
- Using deprecated Python features
- Missing proper exception hierarchy
- Incorrect use of mutable default arguments
- Missing __slots__ for memory-critical classes
- Improper use of lambda functions
- Missing proper module-level docstrings