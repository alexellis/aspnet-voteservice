FROM msbuild:12

MAINTAINER alexellis2@gmail.com


RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \
    Install-WindowsFeature Web-Asp-Net45

WORKDIR 'C:\'
COPY . votingservice

WORKDIR 'C:\votingservice\'
RUN Get-Item .
# RUN Install-Package MSBuild.Microsoft.VisualStudio.Web.targets -Confirm
RUN mv 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\MSBuild.Microsoft.VisualStudio.Web.targets.12.0.4\tools\VSToolsPath\*' 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\'

RUN nuget restore -PackagesDirectory .\Packages
RUN ["C:\\Program Files (x86)\\MSBuild\\12.0\\Bin\\msbuild.exe", ".\\VoteService.sln"]
