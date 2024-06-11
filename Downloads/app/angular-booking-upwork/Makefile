#!/usr/bin/make -f

MAKEFLAGS += --silent

name ?= ''
env ?= development
$(shell cp .config/environments/.env.$(env) .env)
include .env
export $(shell sed 's/=.*//' .env)


Services := gateway
Frontend := scheduling-ui

noop =
comma := ,
space = $(noop) $(noop)

OS := $(shell uname)

nprocs := 2

ifeq ($(OS), Linux)
    nprocs = $(shell nproc)
endif
ifeq ($(OS), Darwin)
    nprocs = $(shell sysctl -n hw.ncpu)
endif

install: FORCE

updateDeps:
	@echo "Installing Dependencies for frontend"
	cd $(Frontend) && npm install
	@echo "Restoring Dependencies for services"
	cd $(Services) && dotnet restore

build:
	$(MAKE) updateDeps
	$(MAKE) build.scheduling-ui
	$(MAKE) build.gateway
	$(MAKE) env.set

env.set:
	cp .config/environments/.env.$(env) .env
	for service in $(Services) ; do \
		mkdir -p ./gateway/ >/dev/null 2>&1 ; \
		cp .env ./gateway/.env ; \
	done

	@echo "$(env) environment variables for services are set"

dev.scheduling-ui: env.set
	cd $(Frontend) && npm run start

dev.gateway: env.set
	cd $(Services) && dotnet restore && dotnet watch run

build.scheduling-ui: env.set updateDeps
	cd $(Frontend) && npm run build

build.gateway: env.set updateDeps
	cd $(Services) && dotnet restore && dotnet build

db.migrate: env.set
	cd $(Services) && dotnet ef migrations add $(name)

db.update: env.set
	cd $(Services) && dotnet ef database update

cpus:
	@echo "Number of CPUs: $(nprocs)"