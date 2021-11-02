# NordcloudTask

## Solution projects
* *NordcloudTask.App* - Console application. Based on two json files with points and stations data finds best station for each point.
* *NordcloudTask.PowerManagement* - liblary with used models, helper classes for calculations and logic elements for picking right station.
* *NordcloudTask.PowerManagement.MsTests* - basic tests for logic nd calculations from *NordcloudTask.PowerManagement* project

## Points and stations data

Points and stations data used in application are loadec from *Points.json* and *Stations.json* files in *NordcloudTask.App\Resources* folder.

## Logs

Logs are automatically saved in C:\temp\Log\NordclouedTask.App.txt* file.
To change log settings *Nlog.dll.nlog* file has to be modified.

## Application

Application o run can be found in *Application* folder.