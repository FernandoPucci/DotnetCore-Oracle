FROM microsoft/dotnet:2.0-sdk
COPY pub/ /root/
WORKDIR /root/
ENV ASPNETCORE_URLS="http://*:8080"
EXPOSE 8080/tcp
ENTRYPOINT ["dotnet", "EmployeesAPI.dll"]

#.NET Core applcation vs. Docker 
# https://automationrhapsody.com/build-a-rest-api-with-net-core-2-and-run-it-on-docker-linux-container/ 