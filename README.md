# Serverless360 BAM for ASP.NET applications
This repository contains ASP.NET library which allows you to log activities to Serverless360 Business Activity Monitoring Solution.

## Introduction
[Serverless360](https://www.serverless360.com/) is one platform to manage and monitor Azure Serverless components related to enterprise integration.

[Serverless360 BAM](https://docs.serverless360.com/docs/what-is-business-activity-monitoring-tracking) can be used for functional end to end business activity tracking and monitoring product for Azure integration scenarios involving Azure Functions, API's and Azure Logic Apps. With Serverless360 BAM get full visibility of your end to end business process flow across all your components from a single portal.

Currently with services like Logic Apps we provide a [custom connector](https://github.com/Serverless360/Azure-Logic-Apps-BAM-Custom-Connector-for-Serverless360) which you can deploy in your subscription if you want to track activities. For other services you can use our Azure Functions to track activities. But since it is hard for every customer to implement their own logic for communicating our APIs we think this library can reduce that effort vastly.

## Repository Structure
```
root\
    Kovai.Serverless360.Bam.sln - Main Solution
    Kovai.Serverless360.Bam\
        Kovai.Serverless360.Bam.csproj - Library Project
    Kovai.Serverless360.Bam.Tests\
        Kovai.Serverless360.Bam.Tests.csproj - Test Project
    Kovai.Serverless360.Sample\
        Kovai.Serverless360.Sample.csproj - Sample Application
```
## Prerequisites

In your .NET application install this package
```
Install-Package Kovai.Serverless360.Bam -Version 1.0.1
```
Get your Auth Key from Serverless360 portal

![alt text](https://github.com/Serverless360/serverless360-bam-lib/blob/master/docs/serverless360%20bam.png)

## How to use

Once you have package and the key.

Use the following code to start an activity

```
	var receiveResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				IsArchiveEnabled = true,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
			})
```

To update an activity

```
_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
			});
```
