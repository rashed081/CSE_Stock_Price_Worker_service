FROM ubuntu
MAINTAINER rony

ARG DEBIAN_FRONTEND=noninteractive

RUN apt-get update && \
    apt-get install -y apache2

WORKDIR /var

EXPOSE 8000

CMD apachectl -D FOREGROUND