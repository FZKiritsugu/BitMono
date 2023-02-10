<p align="center">
  <img src="https://raw.githubusercontent.com/sunnamed434/BitMono/main/resources/logo/BitMonoLogo.png" alt="BitMono logo" width="180" /><br>
  Free open-source obfuscator for Mono<br>
</p>

## BitMono
[![Build status][image_appveyor_main_badge]][appveyor_main_build]
[![Test status][image_test]][test]
[![Codefactor][image_codefactor]][codefactor]
[![DeepSource][image_deepsource]][deepsource]
[![Gitter Chat][image_gitter]][gitter]
[![MIT License][image_license]][license]

BitMono is an free open-source C# obfuscator that in most cases works **only** with Mono - well known as a fork of .NET framework but for Unity, you can still use this for a whole .NET, but be careful that something working not as intentional, etc. Which uses **[AsmResolver][asmresolver]** for assembly manipulation. If you have any questions/issues please let me know **[there][bitmono_issues]**. You can install the latest version of BitMono **[here][bitmono_releases]**.

<p align="center">
<img src="https://raw.githubusercontent.com/sunnamed434/BitMono/main/resources/images/preview/before-after.png"
  alt="Before and after obfuscation preview by BitMono"
</p>

<p align="center">
<img src="https://raw.githubusercontent.com/sunnamed434/BitMono/main/resources/images/preview/GUI.png"
  alt="GUI"
</p>

<p align="center">
<img src="https://raw.githubusercontent.com/sunnamed434/BitMono/main/resources/images/preview/CLI.png"
  alt="CLI"
</p>

<p align="center">
<img src="https://raw.githubusercontent.com/sunnamed434/BitMono/main/resources/images/preview/configuration.png"
  alt="Configuration"
</p>

## Documentation 
Open the **[wiki][bitmono_wiki]** to read protection, functionality and more.

## How your app will look since BitMono obfuscation - just in a few words
* Looks like C++ application but is an actual C# application
* Crash of decompilers when analyzing types
* Broken decompilers
* Broken IL Code
* Invisible types
* No code 

## Obfuscation Features
* StringsEncryption
* **[BitDotNet][bitdotnet_source]** (based and improved on existing protection)
* **[BitMethodDotnet][bitmethoddotnet_source]** (based and improved on existing protection)
* **[DotNetHook][dotnethook_source]** (based on existing protection)
* CallToCalli
* ObjectReturnType
* NoNamespaces
* FullRenamer
* AntiDebugBreakpoints
* AntiDecompiler
* BitDateTimeStamp
* BitMono

## Usage
`BitMono.CLI <path to file>/drag-and-drop or use BitMono.GUI (GUI Windows only)`

Always drop dependencies in `libs` directory in the same path where `file` for obfuscation is located


### Detailed build status
Branch        | AppVeyor
------------- | ------------- 
main          | [![Build status][image_appveyor_main_badge]][appveyor_main_build] 
dev           | [![Build status][image_appveyor_dev_badge]][appveyor_dev_build]

Credits
-------
**[0x59R11][author_0x59r11]** for his acquaintance in big part of **[BitDotNet][bitdotnet_source]** that breaks files for mono executables!

**[Gazzi][author_gazzi]** for his help that [me][author_sunnamed434] asked a lot!

**[Elliesaur][author_ellisaur]** for his acquaintance in **[DotNetHook][dotnethook_source]** that hooks methods.

**[Weka][author_naweka]** for his advices, help and motivation. 

**[ConfuserEx and their Forks][confuserex_source]** for most things that I watched for the architecture of BitMono and the obfuscator engine as an application and solving plenty of User solutions which I would be knew in the very long future after much fail usage of BitMono and reports by other Users. Day-by-day I'm looking for something interesting there to improve myself in knowledge and BitMono also.

**[Kao and his blogs][author_kao_blog]** thanks a lot of these blogs.

[test]: https://ci.appveyor.com/project/sunnamed434/bitmono/branch/main/tests
[codefactor]: https://www.codefactor.io/repository/github/sunnamed434/bitmono/overview/main
[deepsource]: https://deepsource.io/gh/sunnamed434/BitMono/?ref=repository-badge
[gitter]: https://gitter.im/BitMonoSpeech/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge
[license]: https://github.com/sunnamed434/BitMono/blob/main/LICENSE
[asmresolver]: https://github.com/Washi1337/AsmResolver
[bitmono_issues]: https://github.com/sunnamed434/BitMono/issues
[bitmono_releases]: https://github.com/sunnamed434/BitMono/releases
[bitmono_wiki]: https://github.com/sunnamed434/BitMono/wiki
[bitdotnet_source]: https://github.com/0x59R11/BitDotNet
[bitmethoddotnet_source]: https://github.com/sunnamed434/BitMethodDotnet
[dotnethook_source]: https://github.com/Elliesaur/DotNetHook
[confuserex_source]: https://github.com/yck1509/ConfuserEx
[author_0x59r11]: https://github.com/0x59R11
[author_gazzi]: https://github.com/GazziFX
[author_ellisaur]: https://github.com/Elliesaur
[author_naweka]: https://github.com/naweka
[author_kao_blog]: https://lifeinhex.com/
[author_sunnamed434]: https://github.com/sunnamed434
[appveyor_main_build]: https://ci.appveyor.com/project/sunnamed434/bitmono/branch/main
[appveyor_dev_build]: https://ci.appveyor.com/project/sunnamed434/bitmono/branch/dev

[image_build]: https://ci.appveyor.com/api/projects/status/8jh35hfno6riq25j?svg=true&style=plastic
[image_test]: https://img.shields.io/appveyor/tests/sunnamed434/bitmono/main
[image_codefactor]: https://www.codefactor.io/repository/github/sunnamed434/bitmono/badge/main
[image_deepsource]: https://deepsource.io/gh/sunnamed434/BitMono.svg/?label=active+issues&show_trend=true&token=_FJf25YbtCpPyX7SRveXCaGd
[image_gitter]: https://badges.gitter.im/BitMonoSpeech/community.svg?style=plastic
[image_license]: https://img.shields.io/github/license/sunnamed434/bitmono
[image_appveyor_main_badge]: https://ci.appveyor.com/api/projects/status/8jh35hfno6riq25j/branch/main?svg=true
[image_appveyor_dev_badge]: https://ci.appveyor.com/api/projects/status/b9rm3l7kduryjgcj/branch/dev?svg=true