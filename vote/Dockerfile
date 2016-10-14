# Using official python runtime base image
FROM microsoft/windowsservercore

MAINTAINER alexellis2@gmail.com

SHELL ["powershell"]

RUN $ErrorActionPreference = 'Stop'; \
    wget https://www.python.org/ftp/python/2.7.12/python-2.7.12.msi -OutFile python-2.7.12.msi ; \
    Start-Process python-2.7.12.msi -ArgumentList '/quiet InstallAllUsers=1 PrependPath=1' -Wait ; \
    Remove-Item python-2.7.12.msi -Force

# Set the application directory
WORKDIR /app

RUN setx PATH '%PATH%;C:\\Python27\\'

# Install our requirements.txt
ADD requirements.txt /app/requirements.txt
ENV PYTHONIOENCODING=UTF-8
RUN C:\\Python27\\python.exe -m pip install --upgrade pip ; \
    C:\\Python27\\python.exe -m pip install -r requirements.txt

# Copy our code from the current folder to /app inside the container
ADD . /app

# Make port 80 available for links and/or publish
EXPOSE 80

# Define our command to be run when launching the container
CMD ["C:\\Python27\\python.exe", ".\\app.py"]
