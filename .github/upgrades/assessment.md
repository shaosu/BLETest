# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v8.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [BLE48Test1\BLE48Test1.csproj](#ble48test1ble48test1csproj)
  - [BLE90Test1\BLE90Test1.csproj](#ble90test1ble90test1csproj)
  - [ConsoleBLENet48\ConsoleBLENet48.csproj](#consoleblenet48consoleblenet48csproj)
  - [ConsoleBLENet90\ConsoleBLE90Test.csproj](#consoleblenet90consoleble90testcsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 4 | 2 require upgrade |
| Total NuGet Packages | 3 | All compatible |
| Total Code Files | 34 |  |
| Total Code Files with Incidents | 17 |  |
| Total Lines of Code | 11218 |  |
| Total Number of Issues | 5919 |  |
| Estimated LOC to modify | 5915+ | at least 52.7% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :--- |
| [BLE48Test1\BLE48Test1.csproj](#ble48test1ble48test1csproj) | net48 | 🟡 Medium | 0 | 5915 | 5915+ | ClassicWinForms, Sdk Style = False |
| [BLE90Test1\BLE90Test1.csproj](#ble90test1ble90test1csproj) | net10.0-windows10.0.22000.0 | ✅ None | 0 | 0 |  | WinForms, Sdk Style = True |
| [ConsoleBLENet48\ConsoleBLENet48.csproj](#consoleblenet48consoleblenet48csproj) | net48 | 🟢 Low | 0 | 0 |  | ClassicDotNetApp, Sdk Style = False |
| [ConsoleBLENet90\ConsoleBLE90Test.csproj](#consoleblenet90consoleble90testcsproj) | net9.0-windows10.0.26100.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 3 | 100.0% |
| ⚠️ Incompatible | 0 | 0.0% |
| 🔄 Upgrade Recommended | 0 | 0.0% |
| ***Total NuGet Packages*** | ***3*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 5621 | High - Require code changes |
| 🟡 Source Incompatible | 294 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 11444 |  |
| ***Total APIs Analyzed*** | ***17359*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| Microsoft.Windows.SDK.Contracts | 10.0.22000.196 |  | [BLE48Test1.csproj](#ble48test1ble48test1csproj)<br/>[ConsoleBLENet48.csproj](#consoleblenet48consoleblenet48csproj) | ✅Compatible |
| Newtonsoft.Json | 13.0.4 |  | [BLE48Test1.csproj](#ble48test1ble48test1csproj) | ✅Compatible |
| System.Runtime.WindowsRuntime | 4.7.0 |  | [BLE48Test1.csproj](#ble48test1ble48test1csproj) | ✅Compatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| Windows Forms | 5621 | 95.0% | Windows Forms APIs for building Windows desktop applications with traditional Forms-based UI that are available in .NET on Windows. Enable Windows Desktop support: Option 1 (Recommended): Target net9.0-windows; Option 2: Add <UseWindowsDesktop>true</UseWindowsDesktop>; Option 3 (Legacy): Use Microsoft.NET.Sdk.WindowsDesktop SDK. |
| GDI+ / System.Drawing | 253 | 4.3% | System.Drawing APIs for 2D graphics, imaging, and printing that are available via NuGet package System.Drawing.Common. Note: Not recommended for server scenarios due to Windows dependencies; consider cross-platform alternatives like SkiaSharp or ImageSharp for new code. |
| Legacy Configuration System | 2 | 0.0% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |
| Deprecated Remoting & Serialization | 2 | 0.0% | Legacy .NET Remoting, BinaryFormatter, and related serialization APIs that are deprecated and removed for security reasons. Remoting provided distributed object communication but had significant security vulnerabilities. Migrate to gRPC, HTTP APIs, or modern serialization (System.Text.Json, protobuf). |
| Windows Forms Legacy Controls | 1 | 0.0% | Legacy Windows Forms controls that have been removed from .NET Core/5+ including StatusBar, DataGrid, ContextMenu, MainMenu, MenuItem, and ToolBar. These controls were replaced by more modern alternatives. Use ToolStrip, MenuStrip, ContextMenuStrip, and DataGridView instead. |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |
| T:System.Windows.Forms.Label | 744 | 12.6% | Binary Incompatible |
| T:System.Windows.Forms.AnchorStyles | 363 | 6.1% | Binary Incompatible |
| T:System.Windows.Forms.Button | 325 | 5.5% | Binary Incompatible |
| T:System.Windows.Forms.TableLayoutPanel | 241 | 4.1% | Binary Incompatible |
| T:System.Windows.Forms.TextBox | 228 | 3.9% | Binary Incompatible |
| T:System.Drawing.ContentAlignment | 183 | 3.1% | Source Incompatible |
| T:System.Windows.Forms.NumericUpDown | 177 | 3.0% | Binary Incompatible |
| T:System.Windows.Forms.ComboBox | 165 | 2.8% | Binary Incompatible |
| P:System.Windows.Forms.Control.Name | 146 | 2.5% | Binary Incompatible |
| P:System.Windows.Forms.Control.Size | 145 | 2.5% | Binary Incompatible |
| P:System.Windows.Forms.Control.TabIndex | 139 | 2.3% | Binary Incompatible |
| P:System.Windows.Forms.Control.Location | 139 | 2.3% | Binary Incompatible |
| T:System.Windows.Forms.TableLayoutControlCollection | 110 | 1.9% | Binary Incompatible |
| P:System.Windows.Forms.TableLayoutPanel.Controls | 110 | 1.9% | Binary Incompatible |
| M:System.Windows.Forms.TableLayoutControlCollection.Add(System.Windows.Forms.Control,System.Int32,System.Int32) | 110 | 1.9% | Binary Incompatible |
| T:System.Windows.Forms.Padding | 92 | 1.6% | Binary Incompatible |
| P:System.Windows.Forms.Control.Anchor | 91 | 1.5% | Binary Incompatible |
| T:System.Windows.Forms.ListBox | 82 | 1.4% | Binary Incompatible |
| T:System.Windows.Forms.DockStyle | 72 | 1.2% | Binary Incompatible |
| F:System.Windows.Forms.AnchorStyles.Right | 65 | 1.1% | Binary Incompatible |
| F:System.Windows.Forms.AnchorStyles.Left | 63 | 1.1% | Binary Incompatible |
| P:System.Windows.Forms.Label.TextAlign | 61 | 1.0% | Binary Incompatible |
| P:System.Windows.Forms.Label.Text | 61 | 1.0% | Binary Incompatible |
| P:System.Windows.Forms.Label.AutoSize | 61 | 1.0% | Binary Incompatible |
| M:System.Windows.Forms.Label.#ctor | 61 | 1.0% | Binary Incompatible |
| P:System.Windows.Forms.TextBox.Text | 57 | 1.0% | Binary Incompatible |
| T:System.Windows.Forms.RowStyle | 49 | 0.8% | Binary Incompatible |
| T:System.Windows.Forms.TableLayoutRowStyleCollection | 49 | 0.8% | Binary Incompatible |
| P:System.Windows.Forms.TableLayoutPanel.RowStyles | 49 | 0.8% | Binary Incompatible |
| M:System.Windows.Forms.TableLayoutRowStyleCollection.Add(System.Windows.Forms.RowStyle) | 49 | 0.8% | Binary Incompatible |
| T:System.Windows.Forms.SizeType | 44 | 0.7% | Binary Incompatible |
| T:System.Windows.Forms.TabPage | 43 | 0.7% | Binary Incompatible |
| P:System.Windows.Forms.Control.Margin | 42 | 0.7% | Binary Incompatible |
| T:System.Windows.Forms.Panel | 36 | 0.6% | Binary Incompatible |
| P:System.Windows.Forms.NumericUpDown.Value | 36 | 0.6% | Binary Incompatible |
| M:System.Windows.Forms.Padding.#ctor(System.Int32) | 36 | 0.6% | Binary Incompatible |
| T:System.Windows.Forms.Control.ControlCollection | 32 | 0.5% | Binary Incompatible |
| P:System.Windows.Forms.Control.Controls | 32 | 0.5% | Binary Incompatible |
| M:System.Windows.Forms.Control.ControlCollection.Add(System.Windows.Forms.Control) | 32 | 0.5% | Binary Incompatible |
| F:System.Drawing.ContentAlignment.MiddleRight | 32 | 0.5% | Source Incompatible |
| M:System.Windows.Forms.RowStyle.#ctor | 31 | 0.5% | Binary Incompatible |
| T:System.Windows.Forms.CheckBox | 30 | 0.5% | Binary Incompatible |
| T:System.Windows.Forms.FlowLayoutPanel | 30 | 0.5% | Binary Incompatible |
| T:System.Windows.Forms.GroupBox | 30 | 0.5% | Binary Incompatible |
| P:System.Windows.Forms.ButtonBase.Text | 29 | 0.5% | Binary Incompatible |
| T:System.Windows.Forms.DialogResult | 28 | 0.5% | Binary Incompatible |
| F:System.Drawing.ContentAlignment.MiddleLeft | 27 | 0.5% | Source Incompatible |
| E:System.Windows.Forms.Control.Click | 27 | 0.5% | Binary Incompatible |
| P:System.Windows.Forms.ComboBox.SelectedIndex | 27 | 0.5% | Binary Incompatible |
| P:System.Windows.Forms.ButtonBase.UseVisualStyleBackColor | 26 | 0.4% | Binary Incompatible |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>⚙️&nbsp;BLE48Test1.csproj</b><br/><small>net48</small>"]
    P2["<b>📦&nbsp;BLE90Test1.csproj</b><br/><small>net10.0-windows10.0.22000.0</small>"]
    P3["<b>⚙️&nbsp;ConsoleBLENet48.csproj</b><br/><small>net48</small>"]
    P4["<b>📦&nbsp;ConsoleBLE90Test.csproj</b><br/><small>net9.0-windows10.0.26100.0</small>"]
    click P1 "#ble48test1ble48test1csproj"
    click P2 "#ble90test1ble90test1csproj"
    click P3 "#consoleblenet48consoleblenet48csproj"
    click P4 "#consoleblenet90consoleble90testcsproj"

```

## Project Details

<a id="ble48test1ble48test1csproj"></a>
### BLE48Test1\BLE48Test1.csproj

#### Project Info

- **Current Target Framework:** net48
- **Proposed Target Framework:** net8.0-windows
- **SDK-style**: False
- **Project Kind:** ClassicWinForms
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 29
- **Number of Files with Incidents**: 16
- **Lines of Code**: 8215
- **Estimated LOC to modify**: 5915+ (at least 72.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["BLE48Test1.csproj"]
        MAIN["<b>⚙️&nbsp;BLE48Test1.csproj</b><br/><small>net48</small>"]
        click MAIN "#ble48test1ble48test1csproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 5621 | High - Require code changes |
| 🟡 Source Incompatible | 294 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 10627 |  |
| ***Total APIs Analyzed*** | ***16542*** |  |

#### Project Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| Legacy Configuration System | 2 | 0.0% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |
| Windows Forms Legacy Controls | 1 | 0.0% | Legacy Windows Forms controls that have been removed from .NET Core/5+ including StatusBar, DataGrid, ContextMenu, MainMenu, MenuItem, and ToolBar. These controls were replaced by more modern alternatives. Use ToolStrip, MenuStrip, ContextMenuStrip, and DataGridView instead. |
| GDI+ / System.Drawing | 253 | 4.3% | System.Drawing APIs for 2D graphics, imaging, and printing that are available via NuGet package System.Drawing.Common. Note: Not recommended for server scenarios due to Windows dependencies; consider cross-platform alternatives like SkiaSharp or ImageSharp for new code. |
| Windows Forms | 5621 | 95.0% | Windows Forms APIs for building Windows desktop applications with traditional Forms-based UI that are available in .NET on Windows. Enable Windows Desktop support: Option 1 (Recommended): Target net9.0-windows; Option 2: Add <UseWindowsDesktop>true</UseWindowsDesktop>; Option 3 (Legacy): Use Microsoft.NET.Sdk.WindowsDesktop SDK. |
| Deprecated Remoting & Serialization | 2 | 0.0% | Legacy .NET Remoting, BinaryFormatter, and related serialization APIs that are deprecated and removed for security reasons. Remoting provided distributed object communication but had significant security vulnerabilities. Migrate to gRPC, HTTP APIs, or modern serialization (System.Text.Json, protobuf). |

<a id="ble90test1ble90test1csproj"></a>
### BLE90Test1\BLE90Test1.csproj

#### Project Info

- **Current Target Framework:** net10.0-windows10.0.22000.0✅
- **SDK-style**: True
- **Project Kind:** WinForms
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 6
- **Lines of Code**: 1820
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["BLE90Test1.csproj"]
        MAIN["<b>📦&nbsp;BLE90Test1.csproj</b><br/><small>net10.0-windows10.0.22000.0</small>"]
        click MAIN "#ble90test1ble90test1csproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="consoleblenet48consoleblenet48csproj"></a>
### ConsoleBLENet48\ConsoleBLENet48.csproj

#### Project Info

- **Current Target Framework:** net48
- **Proposed Target Framework:** net8.0
- **SDK-style**: False
- **Project Kind:** ClassicDotNetApp
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 4
- **Number of Files with Incidents**: 1
- **Lines of Code**: 921
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ConsoleBLENet48.csproj"]
        MAIN["<b>⚙️&nbsp;ConsoleBLENet48.csproj</b><br/><small>net48</small>"]
        click MAIN "#consoleblenet48consoleblenet48csproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 817 |  |
| ***Total APIs Analyzed*** | ***817*** |  |

<a id="consoleblenet90consoleble90testcsproj"></a>
### ConsoleBLENet90\ConsoleBLE90Test.csproj

#### Project Info

- **Current Target Framework:** net9.0-windows10.0.26100.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 1
- **Lines of Code**: 262
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ConsoleBLE90Test.csproj"]
        MAIN["<b>📦&nbsp;ConsoleBLE90Test.csproj</b><br/><small>net9.0-windows10.0.26100.0</small>"]
        click MAIN "#consoleblenet90consoleble90testcsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

