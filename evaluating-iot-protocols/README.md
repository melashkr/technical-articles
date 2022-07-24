# Evaluating the performance of IoT-Protocols for autonmous vehicle

## Introduction
This article aims to compare the most recent IoT-Protocols
(AMQP, MQTT, HTTP) to find out the best protocol that can be integrated in Internet of Things
(IoT) devices to ensure high performance and security. 
In our experiment, we will use Azure IoT-Hub to process the data from simulated application. 
The result will be used to secure transferring the IoT-Data by automated vehicles.

## Architecture

Presuming that three tractor are running in a farm wich every tractor use different iot-procol (AMQP, MQTT, HTTP). 
This tractor has many sensor devices that send data such as motortemperature, speed, locationX, locationY to IoTHub.

The goal is to calculate the duration by 100, 1000 and 3000 requests which will be sent asynchronous to azure IoT Hub.

In order to implement the solution we need to provision the following services:
 - Azure IoT Hub
 - Function App
 - Storage Account Gen2 with Azure Storage Account Table
 - Power BI
 - A simulated console application

The proposed experiment in this study is built based on the architecture shown in figure 1
