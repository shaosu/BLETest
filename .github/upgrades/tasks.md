# BLETest .NET 8.0 Upgrade Tasks

## Overview

This document tracks the execution of the all-at-once upgrade of the repository to .NET 8.0. All projects that require migration will be upgraded simultaneously in a single atomic operation, followed by test execution and validation.

**Progress**: 0/3 tasks complete (0%) ![0%](https://progress-bar.xyz/0)

---

## Tasks

### [▶] TASK-001: Verify prerequisites
**References**: Plan §Prerequisites, Plan §Migration Strategy

- [▶] (1) Verify .NET 8.0 SDK is installed on build machines per Plan §Prerequisites (e.g., `dotnet --list-sdks`)
- [ ] (2) Runtime/SDK version meets plan requirements (**Verify**)  
- [ ] (3) If `global.json` exists, verify it is compatible with a .NET 8.x SDK or note required update per Plan §Prerequisites  
- [ ] (4) Verify required platform/tooling for WinForms (`net8.0-windows` / Windows Desktop support) and other environment requirements are present (**Verify**)

### [ ] TASK-002: Atomic framework and package upgrade with compilation fixes
**References**: Plan §Migration Strategy, Plan §Project-by-Project Plans, Plan §Package Update Reference, Plan §Breaking Changes Catalog

- [ ] (1) Update all classic project files to SDK-style and set target TFMs per Plan §Project-by-Project Plans (`BLE48Test1` → `net8.0-windows`, `ConsoleBLENet48` → `net8.0`)  
- [ ] (2) Update package references across projects per Plan §Package Update Reference (preserve versions unless required by build)  
- [ ] (3) Restore dependencies for the solution (`dotnet restore`)  
- [ ] (4) Build the solution and perform a single bounded pass to fix all compilation errors caused by framework/package upgrades (address items from Plan §Breaking Changes Catalog: WinForms, designer code, `System.Drawing`, configuration, serialization)  
- [ ] (5) Solution builds with 0 errors (**Verify**)  
- [ ] (6) Commit changes with message: "TASK-002: Atomic framework and package upgrade"

### [ ] TASK-003: Run tests and validate upgrade
**References**: Plan §Testing & Validation Strategy, Plan §Breaking Changes Catalog, Plan §Source Control Strategy

- [ ] (1) Run tests for the test projects listed in Plan §Testing & Validation Strategy using `dotnet test` (run the specific projects referenced in the plan)  
- [ ] (2) Fix any test failures identified (reference remediation patterns in Plan §Breaking Changes Catalog)  
- [ ] (3) Re-run the same test projects after fixes  
- [ ] (4) All tests pass with 0 failures (**Verify**)  
- [ ] (5) Commit test fixes with message: "TASK-003: Complete testing and validation"
