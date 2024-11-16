@echo off
echo starting Mock Plan...
pause
for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YY=%dt:~2,2%" & set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "HH=%dt:~8,2%" & set "Min=%dt:~10,2%" & set "Sec=%dt:~12,2%"

set "datestamp=%YYYY%%MM%%DD%" & set "timestamp=%HH%%Min%%Sec%"
set "fullstamp=%YYYY%-%MM%-%DD%_%HH%-%Min%-%Sec%"

set "myNumThreads=10"
set "myRampUpPeriod=1"
set "myLoopCount=1"

C:\Tools\apache-jmeter-5.6.3\bin\jmeter -JmyNumThreads=%myNumThreads% -JmyRampUpPeriod=%myRampUpPeriod% -JmyLoopCount=%myLoopCount% -JmyTimestamp=%fullstamp% -q myprops.properties -n -t mockPlan.jmx -l mock_results_%fullstamp%_%myNumThreads%_%myRampUpPeriod%_%myLoopCount%.jtl -e -o mock_results_%fullstamp%_%myNumThreads%_%myRampUpPeriod%_%myLoopCount%
echo ended!
pause