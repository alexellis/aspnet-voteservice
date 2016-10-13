Porting of the Python "vote" app is currently work in progress, use curl instead against the ASP.NET webservice:

i.e. 

Submit a vote:
```
curl -X POST -d '{}' http://serviceIP/voting/v/1/submit/{voteid}/a
```
