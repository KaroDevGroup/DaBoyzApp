<div align="center">

<img src="Assets\DaBoyzLogoPNG.png" width="180">

---

# DaBoyzApp

### ✦ Da Boyz — Community Hub ✦

A Windows desktop application for the **DaBoyz Discord community**.

<br>

[![Latest Release](https://img.shields.io/badge/Download-Latest%20Release-C1121F?style=for-the-badge&logo=github&logoColor=white)](https://github.com/KaroDevGroup/DaBoyzApp/releases)
[![Discord](https://img.shields.io/badge/Join-DaBoyz%20Discord-C1121F?style=for-the-badge&logo=discord&logoColor=white)](https://discord.gg/tpcbMxMJjv)

<br>

![Windows](https://img.shields.io/badge/Windows-10%2B-C1121F?style=flat-square&logo=windows11&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-x64-C1121F?style=flat-square)
![.NET](https://img.shields.io/badge/.NET-10-C1121F?style=flat-square&logo=dotnet&logoColor=white)
![Framework](https://img.shields.io/badge/UI-WPF-C1121F?style=flat-square)
![Status](https://img.shields.io/badge/Status-Beta-C1121F?style=flat-square)

</div>

---
<div align="center">

## Created By

**KaroDevGroup**

[![KaroDevGroup](https://img.shields.io/badge/GitHub-KaroDevGroup-181717?style=for-the-badge&logo=github)](https://github.com/KaroDevGroup)
[![TheKaro](https://img.shields.io/badge/GitHub-TheKaro-181717?style=for-the-badge&logo=github)](https://github.com/TheKaro)

</div>

---

## </> About DaBoyzApp

**DaBoyzApp** is a Windows desktop application built for the **DaBoyz Discord server**.

The application provides a centralized and reliable location for:

- Gaming information and databases.
- Game guides.
- Music projects.
- Community updates.
- Patch notes.
- Administrative resources.
- Additional DaBoyz community tools.

> *Much of the application's content is packaged locally, allowing many features to continue functioning without an active internet connection.*

---

# </> Installation </>

## 1. ✦ Download DaBoyzApp ✦

Open the official GitHub **Releases** page:

[![Download](https://img.shields.io/badge/Download-DaBoyzApp--Setup.exe-C1121F?style=for-the-badge&logo=github&logoColor=white)](https://github.com/KaroDevGroup/DaBoyzApp/releases)

Download the latest:

```text
DaBoyzApp-Setup.exe
```

---

## 2. ✦ Run the installer ✦

Open **DaBoyzApp-Setup.exe** and choose an install location.

Default location:

```text
C:\Program Files\DaBoyzApp
```

---

# </> Developer Setup </>

If you want to inspect, modify, or build **DaBoyzApp** from source, you can clone the repository.

---

## ✦ Prerequisites ✦

Before cloning the repository, install: 

- Git.
- .NET 10 SDK.
- Visual Studio Code, or Visual Studio 2022 or newer.
- The **.NET Desktop Development** workload in Visual Studio.
- Microsoft Edge WebView2 Runtime.

---

## ✦ Clone the Repository ✦

Open **Powershell**, **Command Prompt**, or **Git Bash** and run:

```bash
git clone https://github.com/KaroDevGroup/DaBoyzApp.git
```

---

## ✦ Open the Project ✦

Inside the cloned repository, locate the **DaBoyzApp** solution or project file.

Depending on the repository structure, this will usually be:

```text
DaBoyzApp.sln
```

or:

```text
DaBoyzApp.csproj
```

Double-Click the **__.sln__** file to open the entire solution in Visual Studio.

Alternatively:

1. Open Visual Studio.
2. Select **Open a project or solution**.
3. Navigate to the cloned **__DaBoyzApp__** folder.
4. Select:
```text
DaBoyzApp.sln
```
5. Click **Open**.

---

## ✦ Build DaBoyzApp ✦

From Visual Studio:

1. Open the solution.
2. Select:
```text
Build > Build Solution
```
or press:
```text
Ctrl + Shift + B
```

You can also build from the command line:
```bash
dotnet build
```

---

## ✦ Run DaBoyzApp ✦

From Visual Studio, press:
```text
F5
```
tp run with debugging enabled.

Or press:
```text
Ctrl + F5
```
to run without debugging.

From the command line:
```bash
dotnet run
```
or specify:
```bash
dotnet run --project DaBoyzApp.csproj
```

If using VSCode:
```bash
code .
```

---

## ✦ Creating your Own Branch ✦

If you plan to make changes to the build:
```bash
git checkout -b feature/my-change
```

Examples:
```text
feature/music-player
fix/updater-error
docs/readme-update
```

Make your changes, then commit them:
```bash
git add .
git commit -m "Changes"
```

Push your branch:
```bash
git push -u origin feature/my-change
```
You can then open a pull request on **GitHub.**