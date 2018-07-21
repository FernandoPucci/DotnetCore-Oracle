FROM sath89/oracle-xe-11g

MAINTAINER fsilvapucci@gmail.com

USER root

ENV DATABASES=hr

ADD template.schema.sql /template.schema.sql
ADD entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh