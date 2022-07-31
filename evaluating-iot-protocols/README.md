# Evaluating the performance of IoT-Protocols for autonomous vehicles

## Introduction
This article aims to compare the most recent IoT-Protocols
(AMQP, MQTT, HTTP) to find out the best protocol that can be integrated in Internet of Things
(IoT) devices to ensure high performance and security. 
In our experiment, we will use Azure IoT-Hub to process the data from simulated application. 
The result shows which IoT protocol processes a big amount of data with high performance. 

## Architecture

Presuming, that there are three tractors running in a farm where every tractor uses different IoT-protcol (AMQP, MQTT, HTTP). 
Each of this tractors has many sensor devices that send data such as motortemperature, speed, locationX, locationY to Azure hub.

The goal is to calculate the duration of processed data when sending 100, 1000 and 3000 requests asynchronously from each tractor to azure IoT Hub. The IoT device (e.g. sensors) are simulated using a console application. 

In order to implement the solution the following services were provisioned:
 - Azure IoT Hub
 - Function App
 - Storage Account Gen2 with Azure Storage Account Table
 - Power BI
 - A simulated console application

The proposed experiment in this article is built based on the architecture shown in figure 1:

![alt text](https://github.com/melashkr/technical-articles/blob/main/evaluating-iot-protocols/images/architeckture.png?row=true "IoT Architecture")

## Expertmental steps

The first step was to create an IoT Hub as a broker in Azure which included three IoT-Devices: Device-AMQP,
Device-Http and Device-MQTT. Those devices were registered in the Hub. The second step was to connect the
azure function app to the IoT Hub. Once the function is ready, it will be triggered by the IoT Hub. The purpose of
the function app is to process the incoming data and store it to the storage account table.

The number of messages sent to the hub are shown in the telemetry in figure 2. It shows that 12 thousands messages
haven been sent from the simulated app to the IoT Hub in the cloud.

![alt text](https://github.com/melashkr/technical-articles/blob/main/evaluating-iot-protocols/images/count-msgs-app-to-cloud.PNG?row=true "Count of sent messages to Cloud")

## Evaluation and Result
The duration of processed data sent from the console app to the cloud is used to evaluate the experiement. Three cases are used to evaluate the application with different number of requests: 
 - First case: processing 100 requests for AMQP, MQTT and HTTP protocol
 - Second case: processing 1000 requests for AMQP, MQTT and HTTP protocol
 - Third case: processing 3000 requests for AMQP, MQTT and HTTP protocol
 
 The result of the caculation for the duration of processed data is show in giure 3:
 
![alt text](https://github.com/melashkr/technical-articles/blob/main/evaluating-iot-protocols/images/evaluation-iot-output.PNG?row=true "Count of sent messages to Cloud")

The simulated process is conducted to identify the best performance and to understand the behaviour of the IoT Protocols.
In order to measure the performance for received data on the cloud, we store the timestamp of every request to
determine when was the first processed request and what was the last processed request.

According to the result in figure 3, the findings of the execution are described:
 - 100 requests: the duration to process the first 100 requests from MQTT and AMQP is actually the same but HTTP
took more time. Higher duration indicates more consummation of CPU and RAM. HTTP took about 35.5 seconds (35564 milliseconds)
 - 1000 requests: MQTT took more time than AMQP and HTTP by processing the data, but AMQP has the best performance
in this case in comparison MQTT and HTTP. AMQP took about 53.6 seconds (53669 milliseconds)
 - 3000 requests: The result showed that HTTP is the worst protocol in request processing after 2000 requests. This concludes that MQTT delivers the best performance
for processing the 3000 requests taking 179 seconds (179651 milliseconds), and AMQP delivers the best performance for processing 100 requests

## Conclusion of the Experiment
The evaluation has proven that MQTT-Protocol is the best protocol for heavy workload after 2000 requests and the lowest performance protocol is HTTP. We were able to find the best performance of the protocols based on the accuracy duration in millisecond and with different workloads.

### Feedback
Please reach out to us if you have any feedback. We hope, the aricle is helpful for you. <br />
E-Mail: mohamed.elashkr@gmail.com <br />
E-Mail: wael.amer@gmail.com

**References** <br />
https://sandervandevelde.wordpress.com/2016/06/10/adding-the-power-of-bi-to-your-iot-hub/ <br />
https://www.c-sharpcorner.com/article/integrating-azure-table-storage-to-azure-function/ <br />
https://github.com/MicrosoftDocs/azure-docs.de-de/blob/master/articles/azure-functions/functions-bindings-storage-table-input.md <br />


