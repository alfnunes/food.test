FROM microsoft/dotnet:2.0-sdk

# Environment vars
ENV TZ=America/Sao_Paulo
ENV ASPNETCORE_ENVIRONMENT development

RUN echo 'America/Sao_Paulo' > /etc/timezone && \
	apt-get update

# Copia os arquivos para a pasta app
COPY . /app

# seta o workdir
WORKDIR /app/api

# executa comando dotnet restore
RUN cd /app && dotnet restore

# realiza dotnet build como release
RUN dotnet build -c release

# Configura container
ENTRYPOINT ["dotnet", "run", "-c", "release"]
