# Using official python runtime base image
# This is still a work-in progress. Local connections work but not remote ones over a NAT connection.

FROM microsoft/windowsservercore
SHELL ["powershell"]
RUN $ErrorActionPreference = 'Stop'; \
    wget https://github.com/MSOpenTech/redis/releases/download/win-3.2.100/Redis-x64-3.2.100.msi -OutFile Redis-x64-3.2.100.msi ; \
    Start-Process Redis-x64-3.2.100.msi -ArgumentList '/quiet InstallAllUsers=1 PrependPath=1' -Wait ; \
    Remove-Item Redis-x64-3.2.100.msi -Force

RUN setx PATH '%PATH%;C:\\Program Files\\Redis\\'
WORKDIR 'C:\\Program Files\\Redis\\'



RUN Get-Content redis.windows.conf | Where { $_ -notmatch 'bind 127.0.0.1' } | Set-Content redis.openport.conf ; \
  Get-Content redis.openport.conf | Where { $_ -notmatch 'protected-mode yes' } | Set-Content redis.unprotected.conf ; \
  Add-Content redis.unprotected.conf 'protected-mode no' ; \
    Add-Content redis.unprotected.conf 'bind 0.0.0.0' ; \
  Get-Content redis.unprotected.conf

EXPOSE 6379

# Define our command to be run when launching the container
CMD .\\redis-server.exe .\\redis.unprotected.conf --loglevel verbose --port 6379 ; \
    Write-Host Redis Started... ; \
    while ($true) { Start-Sleep -Seconds 3600 }

# CMD [".\\redis-server.exe", ".\\redis.windows.conf"]

