# Migration Plan: Upgrade to .NET 8.0 (All-At-Once)

## Table of Contents

- Executive Summary
- Migration Strategy
- Detailed Dependency Analysis
- Project-by-Project Plans
- Package Update Reference
- Breaking Changes Catalog
- Detailed Execution Steps
- Testing & Validation Strategy
- Risk Management
- Source Control Strategy
- Success Criteria
- Appendix: Assessment reference

---

## Executive Summary

Selected Strategy: **All-At-Once Strategy** ¡ª upgrade all projects that require it simultaneously in a single coordinated operation.

Rationale:
- Solution contains 4 projects (small solution). Two projects target .NET Framework 4.8 and require upgrade (`BLE48Test1`, `ConsoleBLENet48`). Two projects are already modern SDK-style targeting net9/net10 and require no change.
- Assessment shows heavy WinForms API incompatibilities concentrated in `BLE48Test1` (¡Ö 5,621 binary-incompatible API usages and ~294 source-incompatible items). This creates a large, cross-cutting surface that is easier to address in a single coordinated upgrade so references, package versions and compiler errors are visible and can be fixed together.
- NuGet packages in the solution are reported as compatible; no security-vulnerability package actions are required by the assessment.

Tradeoffs:
- All-at-once is faster and yields a single unified branch and commit, but increases initial risk because many compilation errors and code fixes will appear at once. The plan includes mitigations (backups, branch isolation, clear validation checkpoints).

Key metrics (from assessment):
- Total projects: 4 (2 require upgrade)
- Files analyzed: 34
- Lines of code: 11,218
- BLE48Test1 LOC: 8,215 (¡Ö 72% estimated LOC to modify)
- Binary-incompatible API usages (BLE48Test1): ~5,621


## Migration Strategy

Approach: All-At-Once
- Convert classic projects to SDK-style and set their TargetFramework to `net8.0` (or `net8.0-windows` for WinForms desktop) in a single atomic operation across the repository.
- Update package references and restore in the same operation.
- Build entire solution and fix compilation errors as a single bounded pass.
- After build succeeds, run available test projects and full-solution verification.

Scope:
- Projects to upgrade simultaneously:
  - `BLE48Test1` (current: `net48`) ¡ú target: `net8.0-windows` (UseWindowsForms = true)
  - `ConsoleBLENet48` (current: `net48`) ¡ú target: `net8.0`
- Projects not changed (verify compatibility):
  - `BLE90Test1` (already SDK-style targeting net10.0-windows)
  - `ConsoleBLE90Test` (already SDK-style targeting net9.0-windows)

Prerequisites (must be completed before atomic upgrade):
- Ensure .NET 8.0 SDK is installed on build machines and CI. (Validate with tooling or `dotnet --list-sdks`.)
- If `global.json` exists, update its SDK version to a .NET 8-compatible SDK or add one for build reproducibility.
- Source-control: handle pending changes (assessment indicates pending changes exist). Action: commit pending changes on current branch before creating the upgrade branch.
- Create and switch to upgrade branch: `upgrade-to-NET8`.


## Detailed Dependency Analysis

Summary:
- There are no project-to-project dependencies between the classic net48 projects and the SDK-style net9/net10 projects in the assessment output. Each project is effectively independent for the purposes of framework change.
- Migration order constraint (dependency-first) is satisfied because there are no inter-project project references requiring phased ordering.

Implication for All-At-Once:
- With no dependency graph constraints, the atomic operation can update all applicable projects at once without cross-project ordering concerns.

(Expanded)

- Project dependency summary:
  - No project-to-project project references found in the assessment. Each project is independent for framework upgrade purposes.
  - Leaf/root identification: All projects are effectively roots (no inbound/outbound project references discovered).

- Circular dependencies: None detected.

- Critical path: `BLE48Test1` is the critical path due to highest LOC and API incompatibilities; fixes here determine effort for the atomic upgrade.


## Project-by-Project Plans

### Project: `BLE48Test1` (Classic WinForms)
Current state:
- Target: `net48` (classic project file)
- SDK-style: False
- Files: 29, LOC: 8,215
- Major issues: ~5,621 binary-incompatible API usages, 294 source-incompatible

Target state:
- Target: `net8.0-windows`
- SDK-style: True (Microsoft.NET.Sdk or Microsoft.NET.Sdk.WindowsDesktop with `<UseWindowsForms>true</UseWindowsForms>`)

Migration Steps (what executor will perform):
1. Prerequisites: ensure .NET 8 SDK and Windows Desktop support available.
2. Convert project file to SDK-style. Replace legacy properties with SDK-style project file. Use `Sdk="Microsoft.NET.Sdk.WindowsDesktop"` and set `<UseWindowsForms>true</UseWindowsForms>` and `<TargetFramework>net8.0-windows</TargetFramework>`.
3. Migrate package references from `packages.config` (if present) or legacy references to `<PackageReference>` items in the SDK-style file.
4. Add explicit package references only if assessment requires (e.g., `Microsoft.Windows.SDK.Contracts` can stay as needed). Keep `Newtonsoft.Json` as-is (13.0.4) unless issues are encountered.
5. Restore packages and build solution (atomic build across all projects).
6. Fix compilation errors caused by API incompatibilities ¡ª see Breaking Changes Catalog for likely areas (WinForms control properties, layout APIs, System.Drawing usage). Replace or adapt APIs and control usage where needed.
7. Rebuild solution and verify zero build errors.
8. Update configuration usage: if `app.config` usage exists, add `System.Configuration.ConfigurationManager` package as a compatibility shim if needed.

Validation checklist (project-level):
- [ ] Project file converted to SDK-style and in `upgrade-to-NET8` branch
- [ ] `<TargetFramework>` set to `net8.0-windows` and `<UseWindowsForms>true</UseWindowsForms>` present
- [ ] All required `PackageReference` entries present
- [ ] Solution restores and builds with 0 errors
- [ ] Core runtime flows exercised manually / with automated UI tests if available

Notes & Risks:
- This project is the highest-risk item due to large number of WinForms-related incompatibilities. Expect to perform multiple code fixes around Windows Forms layout and control API usage.

(detailed)
- Complexity: High (Large LOC, heavy WinForms API usage)
- Risk level: High
- Primary focus areas: Project file conversion, Windows Forms APIs, System.Drawing usage, configuration compatibility.
- [Details to be addressed during TASK-001] See Breaking Changes Catalog.


### Project: `ConsoleBLENet48` (Classic Console)
Current state:
- Target: `net48` (classic project file)
- SDK-style: False
- Files: 4

Target state:
- Target: `net8.0`
- SDK-style: True (Microsoft.NET.Sdk)

Migration Steps:
1. Convert project file to SDK-style (`Sdk="Microsoft.NET.Sdk"`) and set `<TargetFramework>net8.0</TargetFramework>`.
2. Migrate package references to `<PackageReference>`.
3. Restore and build as part of atomic upgrade.
4. Fix any small API or compatibility issues identified by the compiler (likely low risk per assessment).

Validation checklist:
- [ ] Project uses SDK-style and `TargetFramework` set
- [ ] Solution builds with 0 errors after atomic upgrade

(detailed)
- Complexity: Low
- Risk level: Low
- Primary focus areas: Project file conversion to SDK style, PackageReference migration.


### Projects not requiring changes (verify)
- `BLE90Test1` (net10.0-windows) ¡ª verify it builds after solution-wide changes, no project file edits expected.
- `ConsoleBLE90Test` (net9.0-windows) ¡ª verify it builds after solution-wide changes.

(detailed)
- `BLE90Test1`:
  - Complexity: Low
  - Risk level: Low
  - Primary focus areas: Validate solution build after atomic upgrade, no project file edits expected.

- `ConsoleBLE90Test`:
  - Complexity: Low
  - Risk level: Low
  - Primary focus areas: Validate solution build after atomic upgrade, no project file edits expected.


## Package Update Reference

From assessment ¨C all packages marked compatible. Include them explicitly in plan to ensure reproducible references.

- `Microsoft.Windows.SDK.Contracts` ¡ª current: `10.0.22000.196` ¡ª used by `BLE48Test1`, `ConsoleBLENet48`. Keep or update only if needed for new target; ensure correct package reference is present in SDK projects that require Windows APIs.
- `Newtonsoft.Json` ¡ª current: `13.0.4` ¡ª used by `BLE48Test1` ¡ª keep as `<PackageReference Include="Newtonsoft.Json" Version="13.0.4" />`.
- `System.Runtime.WindowsRuntime` ¡ª current: `4.7.0` ¡ª used by `BLE48Test1` ¡ª include as explicit `<PackageReference>` only if build requires it under net8.0.

Guidance:
- Do not introduce unspecified package upgrades. Only update package versions if compiler or runtime errors require newer versions.
- Address any security-vulnerability flagged packages during the atomic upgrade if and only if they appear in the assessment (none were flagged).


## Breaking Changes Catalog (expanded)

This catalog captures expected breaking changes and suggested remediation patterns based on the assessment findings. Use it as a prioritized checklist during the atomic upgrade.

1. WinForms control and layout API changes
   - Symptoms: compilation errors pointing to `System.Windows.Forms` types (Label, Button, TextBox, TableLayoutPanel, etc.).
   - Remediation patterns:
     - Where control constructors or property behaviors changed, update initialization code to use supported overloads or set properties explicitly after initialization.
     - Replace obsolete menu controls (MainMenu, MenuItem) with `MenuStrip`/`ToolStripMenuItem` alternatives.
     - For `TableLayoutPanel` and row/column APIs, verify `RowStyles` and `ColumnStyles` initialization; some layout behaviors changed.

2. Designer-generated code issues
   - Symptoms: designer partial class code referencing internal designer-only members or constructs not supported after SDK conversion.
   - Remediation patterns:
     - Re-open forms in Visual Studio designer in migrated SDK-style project to let designer re-generate code where possible.
     - If designer cannot open, migrate code manually by extracting initialization into methods with explicit types and property assignments.

3. System.Drawing and imaging code
   - Symptoms: references to `System.Drawing` types that require NuGet `System.Drawing.Common` or different behavior.
   - Remediation patterns:
     - Add `<PackageReference Include="System.Drawing.Common" Version="7.0.0" />` or newer compatible version when required.
     - Prefer to isolate imaging logic and add abstraction to enable replacement with SkiaSharp if cross-platform needs arise.

4. Configuration (app.config) and ConfigurationManager
   - Symptoms: code using `ConfigurationManager` or `app.config` settings.
   - Remediation patterns:
     - Add NuGet `System.Configuration.ConfigurationManager` package for compatibility, or migrate configuration to `Microsoft.Extensions.Configuration`.

5. BinaryFormatter / remoting usage
   - Symptoms: compilation warnings or runtime issues referencing `BinaryFormatter` or `Remoting` APIs.
   - Remediation patterns:
     - Replace with `System.Text.Json` or other safe serialization approaches. Treat as security-lifecycle item.


## Detailed Execution Steps (expanded)

Preparation (pre-TASK-000):
- Ensure working directory clean or pending changes committed as per selected pending change action.
- Confirm `For48ToNet10` is the source branch and create `upgrade-to-NET8` branch.
- Ensure .NET 8 SDK installed and `dotnet --list-sdks` shows 8.x.
- Backup: push current branches to remote.

TASK-001: Atomic framework and package upgrade (single coordinated operation)
- Step A: Convert project files
  - For `BLE48Test1`:
    - Replace classic project XML with SDK-style header:
      ```xml
      <Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">
        <PropertyGroup>
          <OutputType>WinExe</OutputType>
          <TargetFramework>net8.0-windows</TargetFramework>
          <UseWindowsForms>true</UseWindowsForms>
          <Nullable>enable</Nullable>
        </PropertyGroup>
      </Project>
      ```
    - For `ConsoleBLENet48` use `Microsoft.NET.Sdk` and `<TargetFramework>net8.0</TargetFramework>`.

- Step B: Migrate package references to `<PackageReference>` entries in the SDK-style files. Include versions from assessment where available.

- Step C: Update `Directory.Build.props`/`Directory.Packages.props` if they contain imports or package versions that assume older frameworks.

- Step D: `dotnet restore` for the solution.

- Step E: Build solution and capture compilation errors.

- Step F: Fix compilation errors in code (one bounded pass as part of this task):
  - Address WinForms API changes, adjust designer code where needed.
  - Add compatibility package references (System.Configuration.ConfigurationManager, System.Drawing.Common) as required.
  - Replace deprecated serialization usages.

- Step G: Rebuild solution to verify 0 errors.

Deliverable: single commit containing project file conversions and package reference changes; subsequent commits for code fixes are allowed but prefer small focused commits grouped logically.


TASK-002: Tests and Validation
- Discover test projects and run tests
- Fix failing tests
- Manual smoke test of the WinForms app (startup, main flows)


## Testing & Validation Strategy (expanded)

- Automated
  - `dotnet restore` and `dotnet build` (solution) must succeed with 0 errors.
  - Run `dotnet test` for any test projects found.

- Manual
  - Launch `BLE48Test1` and verify the application starts and main UI loads.
  - Verify critical flows (BLE scanning, device listing, characteristic read/write) as available.


## Source Control Strategy (expanded)

- Branching:
  - `For48ToNet10` (current)
  - Create `upgrade-to-NET8` for all changes
- Commit pattern:
  - Commit 1: project file conversions & package reference changes (atomic)
  - Commit 2..N: code fixes discovered during build, grouped by area (UI, Configuration, Serialization)
- PR: Single PR from `upgrade-to-NET8` into `For48ToNet10` or mainline branch for review


## Success Criteria (expanded)

- All upgraded projects target `net8.0` (with `-windows` TFM for WinForms) and are SDK-style.
- Solution builds and tests pass.
- No unresolved package compatibility warnings remain.


---

Plan draft complete. Next: finalize any remaining per-project package update matrix and produce TASK-001/TASK-002 task markdown if desired.
