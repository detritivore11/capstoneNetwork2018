# agBOT Web Service - Set up Guide

The agBOT web service is based on a similar web service created by Sam Marriot (the master branch of this repository) 
to store and provide diagnostic data, received from an All-Terrain Vehicle (ATV), to an Augmented Reality (AR) application. 

The project was developed using Microsoft Visual Studio, ASP.NET framework, Amazon Web Services (AWS) Elastic Beanstalk and
a Microsoft SQL Server on an Amazon Relational Database Services (RDS) instance. This document provides a guide, 
mostly for future members of the agBOT team and the Agriculture Ergonomics Lab at the University of Manitoba, 
but also for anyone with a general interest on how to set up a similar project.

## Code Summmary

The _Controllers_ folder contains the logic for controlling how the web service reacts to requests.

The _Models_ folder contains objects used to store vehicle information.

## Prerequisites
### Visual Studio Installation and Configuration

* [Download the Visual Studio Installer](https://visualstudio.microsoft.com/vs/community/). This will allow you to set up the 
Visual Studio IDE, which will be used for development of the application, and other useful packages.

* Select and install the **.NET desktop development** and the **ASP.NET and web development** workloads. 
They both include tools and libraries that will be used for the project.
![ASP.NET Workload](/docs/asp.net_workload.jpg)

* Install the AWS Toolkit for Visual Studio extension. This can be done in one of two ways:
	* Download the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=AmazonWebServices.AWSToolkitforVisualStudio2017).
	
	* Open the Visual Studio IDE and go to **Tools > Extensions and Updates > Online > Visual Studio Marketplace**. 
	Search for AWS and download the AWS Toolkit for Visual Studio 2017 and 2019. You may need to restart the Visual Studio IDE 
	for the extension to be installed properly.
	![AWS Extension](/docs/aws_extension.jpg)
	
### AWS Elastic Beanstalk and RDS Configuration
* [Create an AWS account](https://aws.amazon.com/). An AWS account offers 12 months free for certain services, including 
750 hours per month of an Amazon RDS db.t2.micro database usage (which will run the MS SQL database) and 750 hours per month of Windows t2.micro instance usage (which will run the web app on an Elastic Beanstalk instance).

* AWS has a [well-documented guide for getting started with Elastic Beanstalk](https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/GettingStarted.html?icmpid=docs_elasticbeanstalk_console). Please follow it.
When setting up a new application environment, select the .NET (Windows/IIS) platform. You may start with a sample application, which can be replaced later.

* Follow the instructions under _**The Launching and Connecting to an External Amazon RDS Instance in a Default VPC**_ heading from the AWS How-to guide on [Using Elastic Beanstalk with Amazon Relational Database Service](https://github.com/awsdocs/aws-elastic-beanstalk-developer-guide/blob/master/doc_source/AWSHowTo.RDS.md).

## Migrating to new EBS and RDS Instances

* Clone the [GitHub Repository](https://github.com/detritivore11/capstoneNetwork2018.git).

* Open the project in Visual Studio IDE. Edit the **Web.Config** file to modify the app settings with the properties of 
the database you just created.
![Web.Config file modification](/docs/database_configuration.jpg)

* Enable Inbound traffic from Anywhere on the MS SQL database instance. This should only be temporary during the development process.

* Open the Package Manager Console. From the Tools menu select **NuGet Package Manager > Package Manager Console**.

* Run
```
Update-Database
```
This will create the tables and seeded data on the RDS database. For more information about these commands see the [Entity Framework Core tools reference](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell).

* Verify that the application is working by running it using IIS. Add /api/vehicle to the localhost url. You should see the following response:
``` JSON
"[{\"ID\":4,\"Version\":\"0.01\",\"Key\":\"\",\"Params\":[{\"ID\":0,\"Name\":\"Oil Level\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"mm\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":4},{\"ID\":1,\"Name\":\"Engine Temperature\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"C\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":4},{\"ID\":2,\"Name\":\"Air Temperature\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"C\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":4}]},{\"ID\":5,\"Version\":\"0.01\",\"Key\":\"\",\"Params\":[{\"ID\":0,\"Name\":\"Oil Level\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"mm\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":5},{\"ID\":1,\"Name\":\"Engine Temperature\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"C\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":5},{\"ID\":2,\"Name\":\"Air Temperature\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"C\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":5}]},{\"ID\":6,\"Version\":\"0.01\",\"Key\":\"\",\"Params\":[{\"ID\":0,\"Name\":\"Oil Level\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"mm\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":6},{\"ID\":1,\"Name\":\"Engine Temperature\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"C\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":6},{\"ID\":2,\"Name\":\"Air Temperature\",\"Value\":\"hello world 1544478309.21\",\"Type\":\"float\",\"Units\":\"C\",\"Timestamp\":1544478309,\"Message\":\"\",\"VehicleID\":6}]}]"
```
* Follow the steps in this [AWS Elastic Beanstalk tutorial](https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/create_deploy_NET.quickstart.html) to deploy the application to the EBS instance from Visual Studio.

