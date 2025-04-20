# AspireAppHost
EXE to launch an Aspire dashboard for viewing real time OTel
1. Just run the console (F5)
1. Point your browser at http://localhost:15277/structuredlogs
1. Run the OtelLogNoiseMaker.exe to generate some OTel logging and use the "structuredlogs" endpoint to view logs

TODO: testing for metric and traces

WARN: the Aspire framework opens TCP ports 4317 and 4318 so you can't run the dashboard with an otel collector (or anything else listening on 4317/4318) or the ports collide.

