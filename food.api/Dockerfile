FROM microsoft/dotnet:2.0-sdk

# Environment vars
ENV TZ=America/Sao_Paulo
ENV ASPNETCORE_ENVIRONMENT development

RUN echo 'America/Sao_Paulo' > /etc/timezone && \
	apt-get update && \
	apt-get install nginx -y
	
COPY nginx.conf /etc/nginx/nginx.conf	

# Copia os arquivos para a pasta app
COPY . /app

# seta o workdir
WORKDIR /app/api

# executa comando dotnet restore
RUN cd /app && dotnet restore

# realiza dotnet build como release
RUN dotnet build -c release

RUN service nginx start

# Configura container
ENTRYPOINT ["dotnet", "run", "-c", "release"]
