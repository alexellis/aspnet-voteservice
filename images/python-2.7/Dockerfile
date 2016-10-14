FROM microsoft/windowsservercore
MAINTAINER alexellis2@gmail.com


SHELL ["powershell"]

RUN setx PATH '%PATH%;C:\\Python27\\'

ENV PYTHONIOENCODING=UTF-8

RUN $ErrorActionPreference = 'Stop'; \
    wget https://www.python.org/ftp/python/2.7.12/python-2.7.12.msi -OutFile python-2.7.12.msi ; \
    Start-Process python-2.7.12.msi -ArgumentList '/quiet InstallAllUsers=1 PrependPath=1' -Wait ; \
    Remove-Item python-2.7.12.msi -Force ; \
    C:\\Python27\\python.exe -m pip install --upgrade pip

# Define our command to be run when launching the container
CMD ["C:\\Python27\\python.exe"]
