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
│   ├── Beats/                                             # MP3 files for music page
│   ├── Games/                                             # Game icons for database
│   └── Icons/                                             # Icons for various pages
│
├── Controls/                       
│   ├── YouTubePlayer.xaml                                 # YouTube WebView player
│   └── YouTubePlayer.xaml.cs                              # YouTube WebView player logic
│
├── Pages/                           
│   ├── Admin/              
│   │   ├── Commands/    
│   │   │   ├── DiscordCommandsPage.xaml                   # Commands page for discord commands
│   │   │   └── DiscordCommandsPage.xaml.cs                # Commands page logic
│   │   │          
│   │   ├── Dashboard/    
│   │   │   ├── AdminDashboardPage.xaml                    # Main dashboard page
│   │   │   └── AdminDashboardPage.xaml.cs                 # Main dashboard logic
│   │   │         
│   │   ├── Decisions/  
│   │   │   ├── Ban/
│   │   │   │   ├── BanMemberPage.xaml                     # Form page for banning members
│   │   │   │   └── BanMemberPage.xaml.cs                  # Ban logic/database flow
│   │   │   │
│   │   │   ├── Clear/
│   │   │   │   ├── ClearMessagesPage.xaml                 # Form page for clearing messages
│   │   │   │   └── ClearMessagesPage.xaml.cs              # Clear logic/database flow
│   │   │   │
│   │   │   ├── Kick/
│   │   │   │   ├── KickMemberPage.xaml                    # Form page for kicking members
│   │   │   │   └── KickMemberPage.xaml.cs                 # Kick logic/database flow
│   │   │   │
│   │   │   ├── Lock/
│   │   │   │   ├── LockChannelPage.xaml                   # Form page for locking channels
│   │   │   │   └── LockChannelPage.xaml.cs                # Lock logic/database flow
│   │   │   │
│   │   │   ├── Timeout/
│   │   │   │   ├── TimeoutMemberPage.xaml                 # Form page for timing out members
│   │   │   │   └── TimeoutMemberPage.xaml.cs              # Timeout logic/database flow
│   │   │   │
│   │   │   ├── Unban/
│   │   │   │   ├── UnbanMemberPage.xaml                   # Form page for unbanning users
│   │   │   │   └── UnbanMemberPage.xaml.cs                # Unban logic/database flow
│   │   │   │
│   │   │   ├── Unlock/
│   │   │   │   ├── UnlockChannelPage.xaml                 # Form page for unlocking channels
│   │   │   │   └── UnlockChannelPage.xaml.cs              # Unlock logic/database flow
│   │   │   │
│   │   │   ├── Warn/
│   │   │   │   ├── WarnMemberPage.xaml                    # Form page for warning members
│   │   │   │   └── WarnMemberPage.xaml.cs                 # Warn logic/database flow
│   │   │   │
│   │   │   ├── DecisionsPage.xaml                         # Main decisions page
│   │   │   └── DecisionsPage.xaml.cs                      # Main decisions logic
│   │   │      
│   │   ├── Punishments/ 
│   │   │   ├── PunishmentSlatePage.xaml                   # Page displaying staff punishment slate
│   │   │   └── PunishmentSlatePage.xaml.cs                # Slate page logic
│   │   │         
│   │   ├── Rules/   
│   │   │   ├── RulesPage.xaml                             # Page displaying discord server rules
│   │   │   └── RulesPage.xaml.cs                          # Rules page logic
│   │   │               
│   │   ├── Staff/ 
│   │   │   ├── StaffMembersPage.xaml                      # Page displaying discord staff members
│   │   │   └── StaffMembersPage.xaml.cs                   # Staff page logic
│   │   │                   
│   │   ├── AdminPage.xaml                                 # Main admin page
│   │   └── AdminPage.xaml.cs                              # Main admin logic
│   │
│   ├── Gaming/              
│   │   ├── CallofDuty/  
│   │   │   ├── Loadouts/
│   │   │   │   ├── LoadoutsPage.xaml                      # WebView2 COD loadouts page
│   │   │   │   └── LoadoutsPage.xaml.cs                   # WebView2 COD loadouts logic
│   │   │   │
│   │   │   ├── StatTracker/
│   │   │   │   ├── StatTrackerPage.xaml                   # WebView2 COD tracker page
│   │   │   │   └── StatTrackerPage.xaml.cs                # WebView2 COD tracker logic
│   │   │   │
│   │   │   ├── CallofDutyPage.xaml                        # COD main page
│   │   │   └── CallofDutyPage.xaml.cs                     # COD main logic
│   │   │
│   │   ├── Destiny2/ 
│   │   │   ├── Builds/
│   │   │   │   ├── BuildsPage.xaml                        # WebView2 D2 builds page
│   │   │   │   └── BuildsPage.xaml.cs                     # WebView2 D2 builds logic
│   │   │   │
│   │   │   ├── LightGG/
│   │   │   │   ├── LightGGPage.xaml                       # WebView2 D2 lightgg page
│   │   │   │   └── LightGGPage.xaml.cs                    # WebView2 D2 lightgg logic
│   │   │   │
│   │   │   ├── RaidReport/
│   │   │   │   ├── RaidReportPage.xaml                    # WebView2 D2 raidreport page
│   │   │   │   └── RaidReportPage.xaml.cs                 # WebView2 D2 raidreport logic
│   │   │   │
│   │   │   ├── Raids/
│   │   │   │   ├── DeepStoneCrypt/
│   │   │   │   │   ├── Atraks1Page.xaml                   # DSC encounter page
│   │   │   │   │   ├── Atraks1Page.xaml.cs                # DSC encounter logic
│   │   │   │   │   ├── CryptSecurityPage.xaml             # DSC encounter page
│   │   │   │   │   ├── CryptSecurityPage.xaml.cs          # DSC encounter page 
│   │   │   │   │   ├── DeepStoneCryptPage.xaml            # DSC main page
│   │   │   │   │   ├── DeepStoneCryptPage.xaml.cs         # DSC main logic
│   │   │   │   │   ├── TaniksAbominationPage.xaml         # DSC encounter page
│   │   │   │   │   ├── TaniksAbominationPage.xaml.cs      # DSC encounter logic
│   │   │   │   │   ├── TaniksRebornPage.xaml              # DSC encounter page
│   │   │   │   │   └── TaniksRebornPage.xaml.cs           # DSC encounter logic
│   │   │   │   │
│   │   │   │   ├── GardenOfSalvation/
│   │   │   │   │   ├── DefeatConsecratedMindPage.xaml     # GOS encounter page
│   │   │   │   │   ├── DefeatConsecratedMindPage.xaml.cs  # GOS encounter logic
│   │   │   │   │   ├── DefeatSanctifiedMindPage.xaml      # GOS encounter page
│   │   │   │   │   ├── DefeatSanctifiedMindPage.xaml.cs   # GOS encounter logic
│   │   │   │   │   ├── EvadeConsecratedMindPage.xaml      # GOS encounter page
│   │   │   │   │   ├── EvadeConsecratedMindPage.xaml.cs   # GOS encounter logic
│   │   │   │   │   ├── GardenOfSalvationPage.xaml         # GOS main page 
│   │   │   │   │   ├── GardenOfSalvationPage.xaml.cs      # GOS main logic
│   │   │   │   │   ├── SummonConsecratedMindPage.xaml     # GOS encounter page
│   │   │   │   │   └── SummonConsecratedMindPage.xaml.cs  # GOS encounter logic
│   │   │   │   │
│   │   │   │   ├── KingsFall/
│   │   │   │   │   ├── DaughtersPage.xaml                 # KF encounter page
│   │   │   │   │   ├── DaughtersPage.xaml.cs              # KF encounter logic
│   │   │   │   │   ├── GolgorothPage.xaml                 # KF encounter page
│   │   │   │   │   ├── GolgorothPage.xaml.cs              # KF encounter logic
│   │   │   │   │   ├── KingsFallPage.xaml                 # KF main page
│   │   │   │   │   ├── KingsFallPage.xaml.cs              # KF main logic
│   │   │   │   │   ├── OryxPage.xaml                      # KF encounter page
│   │   │   │   │   ├── OryxPage.xaml.cs                   # KF encounter logic
│   │   │   │   │   ├── TotemsPage.xaml                    # KF encounter page
│   │   │   │   │   ├── TotemsPage.xaml.cs                 # KF encounter logic
│   │   │   │   │   ├── WarpriestPage.xaml                 # KF encounter page
│   │   │   │   │   └── WarpriestPage.xaml.cs              # KF encounter logic
│   │   │   │   │
│   │   │   │   ├── LastWish/
│   │   │   │   │   ├── KalliPage.xaml                     # LW encounter page
│   │   │   │   │   ├── KalliPage.xaml.cs                  # LW encounter logic
│   │   │   │   │   ├── LastWishPage.xaml                  # LW main page
│   │   │   │   │   ├── LastWishPage.xaml.cs               # LW main logic
│   │   │   │   │   ├── MorgethPage.xaml                   # LW encounter page
│   │   │   │   │   ├── MorgethPage.xaml.cs                # LW encounter logic
│   │   │   │   │   ├── QueenswalkPage.xaml                # LW encounter page
│   │   │   │   │   ├── QueenswalkPage.xaml.cs             # LW encounter logic
│   │   │   │   │   ├── RivenPage.xaml                     # LW encounter page
│   │   │   │   │   ├── RivenPage.xaml.cs                  # LW encounter logic
│   │   │   │   │   ├── ShuroChiPage.xaml                  # LW encounter page
│   │   │   │   │   ├── ShuroChiPage.xaml.cs               # LW encounter logic
│   │   │   │   │   ├── VaultPage.xaml                     # LW encounter page
│   │   │   │   │   └── VaultPage.xaml.cs                  # LW encounter logic
│   │   │   │   │
│   │   │   │   ├── Destiny2RaidsPage.xaml                 # D2 raids page
│   │   │   │   └── Destiny2RaidsPage.xaml.cs              # D2 raids logic
│   │   │   │
│   │   │   ├── Destiny2Page.xaml                          # D2 page
│   │   │   └── Destiny2Page.xaml.cs                       # D2 logic
│   │   │
│   │   ├── FiveM/   
│   │   │   ├── CFX/
│   │   │   │   ├── CFXPage.xaml                           # WebView2 CFX page
│   │   │   │   └── CFXPage.xaml.cs                        # WebView2 CFX logic
│   │   │   │
│   │   │   ├── Servers/
│   │   │   │   ├── FiveMServerPage.xaml                   # WebView2 FiveM server page
│   │   │   │   └── FiveMServerPage.xaml.cs                # WebView2 FiveM server logic
│   │   │   │
│   │   │   ├── FiveMPage.xaml                             # Main FiveM page
│   │   │   └── FiveMPage.xaml.cs                          # Main FiveM logic
│   │   │
│   │   ├── Helldivers2/
│   │   │   ├── InfoHub/
│   │   │   │   ├── InfoHubPage.xaml                       # WebView2 HD2 info page
│   │   │   │   └── InfoHubPage.xaml.cs                    # WebView2 HD2 info logic
│   │   │   │
│   │   │   ├── Map/
│   │   │   │   ├── HelldiversMapPage.xaml                 # WebView2 HD2 map page
│   │   │   │   └── HelldiversMapPage.xaml.cs              # WebView2 HD2 map logic
│   │   │   │
│   │   │   ├── HelldiversPage.xaml                        # Main Helldivers page
│   │   │   └── HelldiversPage.xaml.cs                     # Main helldivers logic
│   │   │
│   │   ├── MarvelRivals/    
│   │   │   ├── StatTracker/
│   │   │   │   ├── RivalsTrackerPage.xaml                 # WebView2 Rivals tracker page
│   │   │   │   └── RivalsTrackerPage.xaml.cs              # WebView2 Rivals tracker logic
│   │   │   │
│   │   │   ├── WiKi/
│   │   │   │   ├── WiKiPage.xaml                          # WebView2 Rivals wiki page
│   │   │   │   └── WiKiPage.xaml.cs                       # WebView2 Rivals wiki logic
│   │   │   │
│   │   │   ├── MarvelRivalsPage.xaml                      # Main Rivals page
│   │   │   └── MarvelRivalsPage.xaml.cs                   # Main Rivals logic
│   │   │
│   │   ├── Minecraft/  
│   │   │   ├── Mods/
│   │   │   │   ├── MCModsPage.xaml                        # WebView2 MC mods page
│   │   │   │   └── MCModsPage.xaml.cs                     # WebView2 MC mods logic
│   │   │   │
│   │   │   ├── Servers/
│   │   │   │   ├── MCServerPage.xaml                      # WebView2 MC server page
│   │   │   │   └── MCServerPage.xaml.cs                   # WebView2 MC server logic
│   │   │   │
│   │   │   ├── MinecraftPage.xaml                         # Main MC page
│   │   │   └── MinecraftPage.xaml.cs                      # Main MC logic
│   │   │
│   │   ├── Rainbow/  
│   │   │   ├── Maps/
│   │   │   │   ├── MapsPage.xaml                          # WebView2 R6 maps page
│   │   │   │   └── MapsPage.xaml.cs                       # WebView2 R6 maps logic
│   │   │   │
│   │   │   ├── StatTracker/
│   │   │   │   ├── SiegeTrackerPage.xaml                  # WebView2 R6 tracker page
│   │   │   │   └── SiegeTrackerPage.xaml.cs               # WebView2 R6 tacker logic
│   │   │   │
│   │   │   ├── Rainbow6SiegePage.xaml                     # Main R6 page
│   │   │   └── Rainbow6SiegePage.xaml.cs                  # Main R6 logic
│   │   │
│   │   ├── RocketLeague/ 
│   │   │   ├── Garage/
│   │   │   │   ├── GaragePage.xaml                        # WebView2 RL garage page
│   │   │   │   └── GaragePage.xaml.cs                     # WebView2 RL garage logic
│   │   │   │
│   │   │   ├── StatTracker/
│   │   │   │   ├── RocketTrackerPage.xaml                 # WebView2 RL tracker page
│   │   │   │   └── RocketTrackerPage.xaml.cs              # WebView2 RL tracker logic
│   │   │   │
│   │   │   ├── RocketLeaguePage.xaml                      # Main RL page
│   │   │   └── RocketLeaguePage.xaml.cs                   # Main RL logic
│   │   │ 
│   │   ├── GamingPage.xaml                                # Main gaming page
│   │   └── GamingPage.xaml.cs                             # Main gaming logic
│   │
│   ├── Home/                      
│   │   ├── HomePage.xaml                                  # Starting page
│   │   └── HomePage.xaml.cs                               # Starting page logic
│   │
│   ├── KDG/                 
│   │   ├── KDGApp/
│   │   │   ├── KDGAppPage.xaml                            # WebView2 github app page
│   │   │   └── KDGAppPage.xaml.cs                         # WebView2 github app logic
│   │   │  
│   │   ├── KDGBot/
│   │   │   ├── KDGBotPage.xaml                            # WebView2 github bot page
│   │   │   └── KDGBotPage.xaml.cs                         # WebView2 github bot logic
│   │   │ 
│   │   ├── KDGPostal/
│   │   │   ├── KDGPostalPage.xaml                         # WebView2 github postal page
│   │   │   └── KDGPostalPage.xaml.cs                      # WebView2 github postal logic
│   │   │
│   │   ├── KDGTexture/
│   │   │   ├── KDGTexturePage.xaml                        # WebView2 github texture page
│   │   │   └── KDGTexturePage.xaml.cs                     # WebView2 github texture logic
│   │   │
│   │   ├── KDGPage.xaml                                   # Main KaroDevGroup page
│   │   └── KDGPage.xaml.cs                                # Main KaroDevGroup logic
│   │
│   ├── Music/                                           
│   │   ├── MusicPage.xaml                                 # Music directory page
│   │   └── MusicPage.xaml.cs                              # Music directory logic
│   │ 
│   ├── PatchNotes/                
│   │   ├── PatchNotesPage.xaml                            # Patchnotes page
│   │   └── PatchNotesPage.xaml.cs                         # Patchnotes logic
│   │ 
│   └── Settings/                  
│       ├── SettingsPage.xaml                              # Settings page
│       └── SettingsPage.xaml.cs                           # Settings page logic
│   
├── Security/                                     
│   ├── IntegrityManifest.cs                               # Integrity manifest logic
│   ├── IntegrityResult.cs                                 # Integrity result logic
│   └── IntegrityService.cs                                # Integrity anti-cheat logic
│   
├── Services/                                 
│   ├── AdminAuthService.cs                                # Admin auth logic
│   ├── CardAnimationService.cs                            # Button/card logic
│   ├── ModerationService.cs                               # Supabase/bot logic
│   ├── SupabaseAuthService.cs                             # Supabase admin auth logic
│   └── UpdateServices.cs                                  # Updater logic
│
├── Windows/                       
│   ├── AntiCheatWindow.xaml                               # Anti-cheat page
│   ├── AntiCheatWindow.xaml.cs                            # Anti-cheat logic
│   ├── UpdateWindow.xaml                                  # Updater page
│   └── UpdateWindow.xaml.cs                               # Updater logic
│
├── App.xaml                                               # Application-level XAML resources
├── App.xaml.cs                                            # Application startup logic
├── AssemblyInfo.cs                                        # Assembly metadata
├── DaBoyzApp.cspoj                                        # Project entry point
├── Generate-IntegrityManifest.ps1                         # Integrity manifest 
├── MainWindow.xaml                                        # Main application window
├── MainWindow.xaml.cs                                     # Main application logic
├── SettingsManager.cs                                     # Settings page logic
├── SplashWindow.xaml                                      # Startup window
└── SplashWindow.xaml.cs                                   # Startup window logic
```

---