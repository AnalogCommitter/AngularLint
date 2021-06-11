cd Formula1
docker rm formula1-tests 
docker rmi formula1 
docker build -t formula1 . 
docker run --name formula1-tests formula1 
docker cp formula1-tests:/src/Formula1.CoreTest/TestResults/unittestResults.xml . 