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

The application provides a reliable location for:

- Gaming information and databases.
- Game guides.
- Music projects.
- Community updates.
- Patch notes.
- Administrative resources.
- Additional DaBoyz community tools.

> *Much of the application's content is packaged locally, allowing many features to continue functioning without an active internet connection.*

---

# </> Installation 

## 1. </> Download DaBoyzApp

Open the official GitHub **Releases** page:

[![Download](https://img.shields.io/badge/Download-DaBoyzApp--Setup.exe-C1121F?style=for-the-badge&logo=github&logoColor=white)](https://github.com/KaroDevGroup/DaBoyzApp/releases)

Download the latest:

```text
DaBoyzApp-Setup.exe
```

> *If you receive a warning about the download - allow it to continue.*

---

## 2. </> Run the installer

Open **DaBoyzApp-Setup.exe** and choose an install location.

Default location:

```text
C:\Program Files\DaBoyzApp
```

> *The installation will ask for administrator rights - allow.*

---

# </> Developer Setup 

If you want to inspect, modify, or build **DaBoyzApp** from source, you can clone the repository.

---

## </> Prerequisites 

Before cloning the repository, install: 

- Git.
- .NET 10 SDK.
- Visual Studio Code, or Visual Studio 2022 or newer.
- The **.NET Desktop Development** workload in Visual Studio.
- Microsoft Edge WebView2 Runtime.

> *These are the minimum requirements - a manifest file will need to be generated as well.*

---

## </> Clone the Repository 

Open **Powershell**, **Command Prompt**, or **Git Bash** and run:

```bash
git clone https://github.com/KaroDevGroup/DaBoyzApp.git
```

---

## </> Open the Project 

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

> *Visual Studio 22 or newer is recommended over VSCode - If you are less experienced, I'd suggest VSCode instead.*

---

## </> Build DaBoyzApp 

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

> *If it doesn't build - locate any errrors within the terminal.*

---

## </> Run DaBoyzApp 

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

> *Do not run with debugging enabled unless you plan on modifying parts of the project.*

---

## </> Creating your Own Branch 

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

> *Cloning does **NOT** mean you can claim the project as yours.*

---

## </> v1.1.9 Project Structure

```text
DaBoyzApp/                              
├── Assets/                
│   ├── Beats/                      
│   ├── Games/                      
│   └── Icons/                      
│
├── Controls/                       
│   ├── YouTubePlayer.xaml
│   └── YouTubePlayer.xaml.cs
│
├── Pages/                           
│   ├── Admin/              
│   │   ├── Commands/    
│   │   │   ├── DiscordCommandsPage.xaml
│   │   │   └── DiscordCommandsPage.xaml.cs
│   │   │          
│   │   ├── Dashboard/    
│   │   │   ├── AdminDashboardPage.xaml
│   │   │   └── AdminDashboardPage.xaml.cs
│   │   │         
│   │   ├── Decisions/  
│   │   │   ├── Ban/
│   │   │   │   ├── BanMemberPage.xaml
│   │   │   │   └── BanMemberPage.xaml.cs
│   │   │   │
│   │   │   ├── Clear/
│   │   │   │   ├── ClearMessagesPage.xaml
│   │   │   │   └── ClearMessagesPage.xaml.cs
│   │   │   │
│   │   │   ├── Kick/
│   │   │   │   ├── KickMemberPage.xaml
│   │   │   │   └── KickMemberPage.xaml.cs
│   │   │   │
│   │   │   ├── Lock/
│   │   │   │   ├── LockChannelPage.xaml
│   │   │   │   └── LockChannelPage.xaml.cs
│   │   │   │
│   │   │   ├── Timeout/
│   │   │   │   ├── TimeoutMemberPage.xaml
│   │   │   │   └── TimeoutMemberPage.xaml.cs
│   │   │   │
│   │   │   ├── Unban/
│   │   │   │   ├── UnbanMemberPage.xaml
│   │   │   │   └── UnbanMemberPage.xaml.cs
│   │   │   │
│   │   │   ├── Unlock/
│   │   │   │   ├── UnlockChannelPage.xaml
│   │   │   │   └── UnlockChannelPage.xaml.cs
│   │   │   │
│   │   │   ├── Warn/
│   │   │   │   ├── WarnMemberPage.xaml
│   │   │   │   └── WarnMemberPage.xaml.cs
│   │   │   │
│   │   │   ├── DecisionsPage.xaml
│   │   │   └── DecisionsPage.xaml.cs
│   │   │      
│   │   ├── Punishments/
│   │   │   ├── PunishmentSlatePage.xaml
│   │   │   └── PunishmentSlatePage.xaml.cs
│   │   │         
│   │   ├── Rules/   
│   │   │   ├── RulesPage.xaml
│   │   │   └── RulesPage.xaml.cs
│   │   │              
│   │   ├── Staff/
│   │   │   ├── StaffMembersPage.xaml
│   │   │   └── StaffMembersPage.xaml.cs
│   │   │               
│   │   ├── AdminPage.xaml
│   │   └── AdminPage.xaml.cs
│   │
│   ├── Gaming/              
│   │   ├── CallofDuty/  
│   │   │   ├── Loadouts/
│   │   │   │   ├── LoadoutsPage.xaml
│   │   │   │   └── LoadoutsPage.xaml.cs
│   │   │   │
│   │   │   ├── StatTracker/
│   │   │   │   ├── StatTrackerPage.xaml
│   │   │   │   └── StatTrackerPage.xaml.cs
│   │   │   │
│   │   │   ├── CallofDutyPage.xaml
│   │   │   └── CallofDutyPage.xaml.cs
│   │   │
│   │   ├── Destiny2/ 
│   │   │   ├── Builds/
│   │   │   │   ├── BuildsPage.xaml
│   │   │   │   └── BuildsPage.xaml.cs
│   │   │   │
│   │   │   ├── LightGG/
│   │   │   │   ├── LightGGPage.xaml
│   │   │   │   └── LightGGPage.xaml.cs
│   │   │   │
│   │   │   ├── RaidReport/
│   │   │   │   ├── RaidReportPage.xaml
│   │   │   │   └── RaidReportPage.xaml.cs
│   │   │   │
│   │   │   ├── Raids/
│   │   │   │   ├── DeepStoneCrypt/
│   │   │   │   │   ├── Atraks1Page.xaml
│   │   │   │   │   ├── Atraks1Page.xaml.cs
│   │   │   │   │   ├── CryptSecurityPage.xaml
│   │   │   │   │   ├── CryptSecurityPage.xaml.cs
│   │   │   │   │   ├── DeepStoneCryptPage.xaml
│   │   │   │   │   ├── DeepStoneCryptPage.xaml.cs
│   │   │   │   │   ├── TaniksAbominationPage.xaml
│   │   │   │   │   ├── TaniksAbominationPage.xaml.cs
│   │   │   │   │   ├── TaniksRebornPage.xaml
│   │   │   │   │   └── TaniksRebornPage.xaml.cs
│   │   │   │   │
│   │   │   │   ├── GardenOfSalvation/
│   │   │   │   │   ├── DefeatConsecratedMindPage.xaml
│   │   │   │   │   ├── DefeatConsecratedMindPage.xaml.cs
│   │   │   │   │   ├── DefeatSanctifiedMindPage.xaml
│   │   │   │   │   ├── DefeatSanctifiedMindPage.xaml.cs
│   │   │   │   │   ├── EvadeConsecratedMindPage.xaml
│   │   │   │   │   ├── EvadeConsecratedMindPage.xaml.cs
│   │   │   │   │   ├── GardenOfSalvationPage.xaml
│   │   │   │   │   ├── GardenOfSalvationPage.xaml.cs
│   │   │   │   │   ├── SummonConsecratedMindPage.xaml
│   │   │   │   │   └── SummonConsecratedMindPage.xaml.cs
│   │   │   │   │
│   │   │   │   ├── KingsFall/
│   │   │   │   │   ├── DaughtersPage.xaml
│   │   │   │   │   ├── DaughtersPage.xaml.cs
│   │   │   │   │   ├── GolgorothPage.xaml
│   │   │   │   │   ├── GolgorothPage.xaml.cs
│   │   │   │   │   ├── KingsFallPage.xaml
│   │   │   │   │   ├── KingsFallPage.xaml.cs
│   │   │   │   │   ├── OryxPage.xaml
│   │   │   │   │   ├── OryxPage.xaml.cs
│   │   │   │   │   ├── TotemsPage.xaml
│   │   │   │   │   ├── TotemsPage.xaml.cs
│   │   │   │   │   ├── WarpriestPage.xaml
│   │   │   │   │   └── WarpriestPage.xaml.cs
│   │   │   │   │
│   │   │   │   ├── LastWish/
│   │   │   │   │   ├── KalliPage.xaml
│   │   │   │   │   ├── KalliPage.xaml.cs
│   │   │   │   │   ├── LastWishPage.xaml
│   │   │   │   │   ├── LastWishPage.xaml.cs
│   │   │   │   │   ├── MorgethPage.xaml
│   │   │   │   │   ├── MorgethPage.xaml.cs
│   │   │   │   │   ├── QueenswalkPage.xaml
│   │   │   │   │   ├── QueenswalkPage.xaml.cs
│   │   │   │   │   ├── RivenPage.xaml 
│   │   │   │   │   ├── RivenPage.xaml.cs
│   │   │   │   │   ├── ShuroChiPage.xaml
│   │   │   │   │   ├── ShuroChiPage.xaml.cs
│   │   │   │   │   ├── VaultPage.xaml
│   │   │   │   │   └── VaultPage.xaml.cs
│   │   │   │   │
│   │   │   │   ├── Destiny2RaidsPage.xaml
│   │   │   │   └── Destiny2RaidsPage.xaml.cs
│   │   │   │
│   │   │   ├── Destiny2Page.xaml
│   │   │   └── Destiny2Page.xaml.cs
│   │   │
│   │   ├── FiveM/   
│   │   │   ├── CFX/
│   │   │   │   ├── CFXPage.xaml
│   │   │   │   └── CFXPage.xaml.cs
│   │   │   │
│   │   │   ├── Servers/
│   │   │   │   ├── FiveMServerPage.xaml
│   │   │   │   └── FiveMServerPage.xaml.cs
│   │   │   │
│   │   │   ├── FiveMPage.xaml
│   │   │   └── FiveMPage.xaml.cs
│   │   │
│   │   ├── Helldivers2/
│   │   │   ├── InfoHub/
│   │   │   │   ├── InfoHubPage.xaml
│   │   │   │   └── InfoHubPage.xaml.cs
│   │   │   │
│   │   │   ├── Map/
│   │   │   │   ├── HelldiversMapPage.xaml
│   │   │   │   └── HelldiversMapPage.xaml.cs
│   │   │   │
│   │   │   ├── HelldiversPage.xaml
│   │   │   └── HelldiversPage.xaml.cs
│   │   │
│   │   ├── MarvelRivals/   
│   │   │   ├── StatTracker/
│   │   │   │   ├── RivalsTrackerPage.xaml
│   │   │   │   └── RivalsTrackerPage.xaml.cs
│   │   │   │
│   │   │   ├── WiKi/
│   │   │   │   ├── WiKiPage.xaml
│   │   │   │   └── WiKiPage.xaml.cs
│   │   │   │
│   │   │   ├── MarvelRivalsPage.xaml
│   │   │   └── MarvelRivalsPage.xaml.cs
│   │   │
│   │   ├── Minecraft/ 
│   │   │   ├── Mods/
│   │   │   │   ├── MCModsPage.xaml
│   │   │   │   └── MCModsPage.xaml.cs
│   │   │   │
│   │   │   ├── Servers/
│   │   │   │   ├── MCServerPage.xaml
│   │   │   │   └── MCServerPage.xaml.cs
│   │   │   │
│   │   │   ├── MinecraftPage.xaml
│   │   │   └── MinecraftPage.xaml.cs
│   │   │
│   │   ├── Rainbow/  
│   │   │   ├── Maps/
│   │   │   │   ├── MapsPage.xaml
│   │   │   │   └── MapsPage.xaml.cs
│   │   │   │
│   │   │   ├── StatTracker/
│   │   │   │   ├── SiegeTrackerPage.xaml
│   │   │   │   └── SiegeTrackerPage.xaml.cs
│   │   │   │
│   │   │   ├── Rainbow6SiegePage.xaml
│   │   │   └── Rainbow6SiegePage.xaml.cs
│   │   │
│   │   ├── RocketLeague/ 
│   │   │   ├── Garage/
│   │   │   │   ├── GaragePage.xaml
│   │   │   │   └── GaragePage.xaml.cs
│   │   │   │
│   │   │   ├── StatTracker/
│   │   │   │   ├── RocketTrackerPage.xaml
│   │   │   │   └── RocketTrackerPage.xaml.cs
│   │   │   │
│   │   │   ├── RocketLeaguePage.xaml
│   │   │   └── RocketLeaguePage.xaml.cs
│   │   │
│   │   ├── GamingPage.xaml
│   │   └── GamingPage.xaml.cs
│   │
│   ├── Home/                      
│   │   ├── HomePage.xaml
│   │   └── HomePage.xaml.cs
│   │
│   ├── KDG/                 
│   │   ├── KDGApp/
│   │   │   ├── KDGAppPage.xaml
│   │   │   └── KDGAppPage.xaml.cs
│   │   │  
│   │   ├── KDGBot/
│   │   │   ├── KDGBotPage.xaml
│   │   │   └── KDGBotPage.xaml.cs
│   │   │
│   │   ├── KDGPostal/
│   │   │   ├── KDGPostalPage.xaml
│   │   │   └── KDGPostalPage.xaml.cs
│   │   │
│   │   ├── KDGTexture/
│   │   │   ├── KDGTexturePage.xaml
│   │   │   └── KDGTexturePage.xaml.cs
│   │   │
│   │   ├── KDGPage.xaml
│   │   └── KDGPage.xaml.cs
│   │
│   ├── Music/                      
│   │   ├── MusicPage.xaml
│   │   └── MusicPage.xaml.cs
│   │
│   ├── PatchNotes/                
│   │   ├── PatchNotesPage.xaml
│   │   └── PatchNotesPage.xaml.cs
│   │ 
│   └── Settings/                 
│       ├── SettingsPage.xaml
│       └── SettingsPage.xaml.cs
│   
├── Security/                      
│   ├── IntegrityManifest.cs
│   ├── IntegrityResult.cs
│   └── IntegrityService.cs
│   
├── Services/                      
│   ├── AdminAuthService.cs
│   ├── CardAnimationService.cs
│   ├── ModerationService.cs
│   ├── SupabaseAuthService.cs
│   └── UpdateServices.cs
│
├── Windows/                       
│   ├── AntiCheatWindow.xaml
│   ├── AntiCheatWindow.xaml.cs
│   ├── UpdateWindow.xaml
│   └── UpdateWindow.xaml.cs
│
├── App.xaml                        # Application-level XAML resources
├── App.xaml.cs                     # Application startup logic
├── AssemblyInfo.cs                 # Assembly metadata
├── DaBoyzApp.cspoj                 # Project entry point
├── Generate-IntegrityManifest.ps1  # Integrity manifest 
├── MainWindow.xaml                 # Main application window
├── MainWindow.xaml.cs              # Main application logic
├── SettingsManager.cs              # Settings page logic
├── SplashWindow.xaml               # Startup window
└── SplashWindow.xaml.cs            # Startup window logic
```

---