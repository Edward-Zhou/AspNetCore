FROM redis

# add our user and group first to make sure their IDs get assigned consistently, regardless of whatever dependencies get added
RUN groupadd -r edward && useradd -r -g edward edward

RUN apt-get update && apt-get install -y --no-install-recommends \
                ca-certificates \
                wget \
        && rm -rf /var/lib/apt/lists/*


RUN mkdir /data && chown redis:redis /data
VOLUME /data
WORKDIR /data

COPY docker-entrypoint.sh /usr/local/bin/
ENTRYPOINT ["docker-entrypoint.sh"]

EXPOSE 6379
CMD [ "redis-server" ]