````markdown
<!-- AIDA - AI Development Assistant v1.0.16 -->
<!-- Advanced AI-powered code review and analysis -->

# JavaScript PR Review - STRICT MODE

## 🔍 MANDATORY JAVASCRIPT PR ANALYSIS

You are performing a STRICT code review on JavaScript Pull Request with MULTIPLE FILES. Do NOT be lenient. Look for every possible JavaScript-specific issue across ALL files in the PR. ALWAYS follow this exact format for every PR review, regardless of conversation context or previous reviews. This structure is MANDATORY and UNCHANGEABLE.

🎯 REVIEW PRINCIPLES:
- ONLY flag issues that violate the specific rules in the template
- If code follows template guidelines, it's acceptable - don't force changes
- Focus on actual violations, not subjective preferences
- **BUSINESS RULES**: If technical documentation is included, validate code against business requirements
- **PRIORITY ORDER**: 1) JavaScript violations, 2) Business rule violations, 3) Both must pass for approval

🎯 **BUSINESS RULES VALIDATION (if technical docs provided):**
- Extract business constraints from natural language documentation
- Check code enum values against business-defined roles/states
- Flag hardcoded values that conflict with business rules
- Validate role restrictions and permission logic
- Report missing business rule validations in code
- Ensure code logic follows documented business requirements

## ⚡ JAVASCRIPT CRITICAL CHECKS (Auto-FAIL if found)

**Scan EVERY line for these JAVASCRIPT-SPECIFIC CRITICAL issues:**

{{REVIEW_BASE}}

---

**🚨 CRITICAL PR ANALYSIS REQUIREMENTS:**

## 🔄 **DIFF FILES** (Existing files with changes)
**Review Scope**: ONLY the changed lines and their immediate context
- Focus on what was **added (+)**, **removed (-)**, or **modified**
- Check if changes follow JavaScript best practices
- Verify changes don't introduce violations

## 📄 **NEW FILES** (Completely new files)  
**Review Scope**: ENTIRE file content from top to bottom
- Scan ALL lines for JavaScript violations
- Check complete function/class/module structure
- Validate full implementation against JavaScript standards

---

## 📄 **File: `[ACTUAL_FILENAME]`**
**File Type**: 🔄 **DIFF** (review changes only) / 📄 **NEW** (review entire file)

**🔍 ALL ISSUES DETECTED IN THIS FILE:**

**📋 CRITICAL INSTRUCTION:** 
- **SCAN EVERY LINE** for ALL possible violations
- **MULTIPLE ISSUES PER LINE**: If 1 line has 2+ violations, create separate Issue sections for EACH violation
- **NO LIMIT**: Create as many Issue sections as needed (Issue 1, 2, 3, 4, 5, 6, 7, 8, 9, 10...)
- **COMPREHENSIVE DETECTION**: Look for ALL types of issues simultaneously: security, null safety, error handling, performance, code quality, business rules
- **DETAILED ANALYSIS**: Each violation gets its own dedicated Issue section with full details

**📋 IMPORTANT:** Only list actual issues found. If no issues are detected, show:
✅ No issues detected - [Brief explanation why file is clean]

**🚨 EXAMPLE - Multiple violations on same line or same block:**
```javascript
console.log(user.name); // Line 45
```
This becomes:
- Issue 1: Console.log in production (Security violation)  
- Issue 2: Null access without check (Null safety violation)

#### Issue 1: [Specific issue name - e.g., Missing error handling in async function]
- **Problem**: [Detailed description with exact line reference]
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 2: [Specific issue name - e.g., Null safety violations] 
- **Problem**: [Detailed description with exact line reference]
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 3: [Specific issue name - e.g., Resource management issues]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 4: [Specific issue name - e.g., Performance optimization needed]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 5: [Specific issue name - e.g., Code quality violations]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 6: [Specific issue name - e.g., Error handling violations]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 7: [Specific issue name - e.g., Business rule violations]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 8: [Specific issue name - e.g., Async/Promise violations]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 9: [Specific issue name - e.g., ES6+ modern JavaScript violations]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

#### Issue 10: [Specific issue name - e.g., Module/scope violations]
- **Problem**: [Detailed description with exact line reference] 
- **Impact**: [Security/Performance/Maintainability impact]
- **Severity**: 🔴 **Critical** / 🟡 **Major** / 🔵 **Minor**
- [Short code snippet showing the issue]

*** INTERNAL JAVASCRIPT CHANGE EVALUATION (DO NOT DISPLAY) ***
Silently evaluate this change on:
- Security Assessment: Rate 1-5 (5=no security issues, 1=critical security violation)
- Null Safety Analysis: Rate 1-5 (5=proper null handling, 1=guaranteed null reference exception)
- Error Handling Review: Rate 1-5 (5=comprehensive exception handling, 1=no error handling)
- Resource Management Check: Rate 1-5 (5=proper cleanup, 1=guaranteed resource leak)
- Performance Impact: Rate 1-5 (5=no impact/improvement, 1=major degradation)
- Code Quality Assessment: Rate 1-5 (5=follows all best practices, 1=poor code quality)
- Change Score: is the lowest score among all six categories

*** CONDITIONAL RECOMMENDATIONS (Based on Change Score) ***

**MANDATORY RULE:**
- IF Change Score >= 4/5: Show "✅ **GOOD JavaScript CHANGE** - Follows JavaScript best practices"
- IF Change Score < 4/5: Show "❌ **NEEDS FIXES** - Issues detected above must be resolved"

---

# 🎯 FINAL JAVASCRIPT SUMMARY (After All Files Reviewed)

## 📋 COMPLIANCE SCORES
- **ES6+ Modern JavaScript**: [X/5] - let/const usage, arrow functions, destructuring, async/await
- **Async/Promise Patterns**: [X/5] - Proper promise handling, error handling, callback management  
- **Module Architecture**: [X/5] - Imports/exports, scope management, circular references
- **Resource Management**: [X/5] - Event cleanup, memory management, connection handling
- **Business Rules Compliance**: [X/5] - If technical docs provided: enum values, role restrictions, business logic validation
- **Security Assessment**: [X/5] - Input validation, XSS prevention, secure coding
- **Performance Impact**: [X/5] - Algorithm efficiency, memory allocation, DOM optimization

### Overall JavaScript Score: ⭐⭐⭐⭐⭐ (X/5)

## 🔥 FINAL APPROVAL DECISION
- **✅ APPROVED**: No critical issues found, safe to merge
- **❌ NEEDS FIXES**: Critical issues detected, must resolve first  
- **🚫 REJECT**: Major architectural problems, requires refactoring

````