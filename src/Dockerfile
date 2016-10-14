FROM microsoft/iis:10.0.14393.206
MAINTAINER alexellis2@gmail.com


SHELL ["powershell"]

RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \
    Install-WindowsFeature Web-Asp-Net45

COPY VoteService VoteService
RUN Remove-WebSite -Name 'Default Web Site'
RUN New-Website -Name 'VoteService' -Port 80 \
    -PhysicalPath 'c:\VoteService' -ApplicationPool '.NET v4.5'
EXPOSE 80

CMD Write-Host IIS Started... ; \
    while ($true) { Start-Sleep -Seconds 3600 }
