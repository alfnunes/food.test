$image = "teste-andre"
docker build -t $image .
docker run -p 5000:5000 $image